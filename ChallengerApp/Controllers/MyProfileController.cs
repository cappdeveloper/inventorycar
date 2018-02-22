using ChallengerApp.Models;
using Microsoft.Web.WebPages.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace ChallengerApp.Controllers
{
    [Authorize]
    public class MyProfileController : ChallengerBaseController
    {

        public ActionResult Index()
        {
            MyProfileViewModel model = new MyProfileViewModel();

            var profile = Context.UserProfileRepository.GetByID(CurrentUserId);
            var result = ModelFactory.Create(profile);
            result.RoleName = Roles.GetRolesForUser(result.UserName).FirstOrDefault();

            model.UserProfileModel = result;
            ViewBag.ActiveTab = "Profile";
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateProfile(MyProfileViewModel model)
        {
            try
            {
                ModelState.Remove("UserProfileModel.UserName");
                ModelState.Remove("UserProfileModel.RoleName");
                if (ModelState.IsValid)
                {
                    var profile = Context.UserProfileRepository.GetByID(CurrentUserId);
                    profile.Name = model.UserProfileModel.Name;
                    profile.Modified = DateTime.UtcNow;

                    Context.UserProfileRepository.Update(profile);
                    Context.Save();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = GetValidationErrors();
                }
            }
            catch (Exception)
            {
                TempData["error"] = GetMessage("error");

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(MyProfileViewModel model)
        {
            try
            {
                var userName = User.Identity.Name;

                if (ModelState.IsValid)
                {
                    if (WebSecurity.ChangePassword(userName, model.LocalPasswordModel.OldPassword, model.LocalPasswordModel.NewPassword))
                    {
                        TempData["success"] = "You successfully changed your password. New password will take effect the next time you login.";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["error"] = "Current password is invalid!";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData["error"] = GetValidationErrors();
                }
               
            }
            catch (Exception)
            {

                TempData["error"] = GetMessage("error");
            }
            
            return RedirectToAction("Index");
        }
    }
}
