using ChallengerApp.Mailers;
using ChallengerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace ChallengerApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserAccountsController : ChallengerBaseController
    {
        private IUserMailer _mailer;

        public UserAccountsController()
        {

        }

        public ActionResult Index()
        {
            List<UserProfileViewModel> users = new List<UserProfileViewModel>();
            IEnumerable<UserProfileViewModel> result = null;
            var data = Context.UserProfileRepository.Get(orderBy: c => c.OrderBy(x => x.Name));
            result = data != null ? data.Select(a => ModelFactory.Create(a)) : null;
            if (result != null && result.Count() > 0)
            {
                foreach (var user in result)
                {
                    user.Roles = Roles.GetRolesForUser(user.UserName).ToList();
                    user.RoleName = string.Join(",", user.Roles);
                    users.Add(user);
                }

            }
            ViewBag.SubTitle = "Users Account";
            return View(users);
        }

        public ActionResult CreateEdit(int id = 0)
        {
            UserProfileViewModel user = null;

            if (id > 0)
            {
                user = ModelFactory.Create(Context.UserProfileRepository.GetByID(id));
                user.Roles = Roles.GetRolesForUser(user.UserName).ToList();
                ViewBag.Action = "Edit";
            }
            else
            {
                user = new UserProfileViewModel();
                user.IsActive = true;
                ViewBag.Action = "Create";
            }
            GetUserRoles();
            user.SystemRoles = Roles.GetAllRoles();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit(UserProfileViewModel model)
        {
            model.Created = DateTime.UtcNow;
            model.Modified = DateTime.UtcNow;
            try
            {
                if (model.SystemRoles == null)
                {
                    model.SystemRoles = Roles.GetAllRoles();
                    TempData["error"] = "Roles is required!";
                    ViewBag.Action = (model.UserId > 0) ? "Edit" : "Create";
                    return View(model);
                }

                if (ModelState.IsValid)
                {
                    if (model.UserId > 0)
                    {
                        var user = Context.UserProfileRepository.GetByID(model.UserId);
                        user.Name = model.Name;
                        user.IsActive = model.IsActive;
                        user.Modified = model.Modified;
                        Context.UserProfileRepository.Update(user);

                        if (!user.Name.Equals("Super Administrator"))
                        {
                            string[] userExistingRole = Roles.GetRolesForUser(model.UserName);
                            if (userExistingRole != null && userExistingRole.Length > 0)
                                Roles.RemoveUserFromRoles(user.UserName, userExistingRole);

                            Roles.AddUserToRoles(user.UserName, model.SystemRoles);
                        }

                        Context.Save();

                    }
                    else
                    {
                        if (IsUserNameTaken(model.UserName))
                        {
                            TempData["error"] = "Email is already taken!";
                            GetUserRoles(model.RoleName);
                            return View(model);
                        }

                        string tempPassword = RandomCharGenerator.RandomString(6, true);
                        WebSecurity.CreateUserAndAccount(model.UserName, tempPassword,
                            new
                            {
                                Name = model.Name,
                                IsActive = model.IsActive,
                                Created = DateTime.UtcNow,
                                Modified = DateTime.UtcNow
                            });
                        Roles.AddUserToRoles(model.UserName, model.SystemRoles);

                        try
                        {
                            //send email notification for new account
                            _mailer = new UserMailer();
                            _mailer.Welcome(model.UserName, model.UserName, tempPassword).SendAsync();
                        }
                        catch (Exception)
                        {


                        }
                    }

                    TempData["success"] = GetMessage("save");
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                TempData["error"] = GetMessage("error");
            }

            //we've come this far then something is wrong
            ViewBag.Action = (model.UserId > 0) ? "Edit" : "Create";
            GetUserRoles(model.RoleName);
            model.SystemRoles = Roles.GetAllRoles();
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var user = Context.UserProfileRepository.GetByID(id);

                if (user.Name.Equals("Super Administrator"))
                {
                    return Json(new { success = false, message = "Cannot delete this account!" }, JsonRequestBehavior.AllowGet);
                }

                string[] userRole = Roles.GetRolesForUser(user.UserName);
                if (userRole.Any())
                {
                    Roles.RemoveUserFromRoles(user.UserName, userRole);
                }

                ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(user.UserName); // deletes record from webpages_Membership table
                ((SimpleMembershipProvider)Membership.Provider).DeleteUser(user.UserName, true); // deletes record from UserProfile table

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Details(int id)
        {
            var user = Context.UserProfileRepository.GetByID(id);
            var result = ModelFactory.Create(user);
            result.RoleName = string.Join(",", Roles.GetRolesForUser(user.UserName).ToArray());
            return View(result);
        }

        private void GetUserRoles(string roleName = "")
        {
            ViewBag.SelectRole = new SelectList(Context.RoleRepository.Get(), "RoleName", "RoleName", roleName);
        }

        private bool IsUserNameTaken(string userName)
        {
            var user = Context.UserProfileRepository.Get(c => c.UserName == userName).FirstOrDefault();
            if (user != null)
                return true;
            return false;
        }

        private void GetRolesList()
        {
            ViewBag.UserRoles = Roles.GetAllRoles().ToList();
        }

    }
}
