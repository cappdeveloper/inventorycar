using ChallengerApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace ChallengerApp.Controllers
{
   
    public class VehicleController : ChallengerBaseController
    {
        public ActionResult Index()
        {
            List<vehicletype> data = new List<vehicletype>();

            data = Context.VehicleRepository.Get(filter:x=>x.UserName==WebSecurity.CurrentUserName ,orderBy: c => c.OrderBy(x => x.Id))
                .ToList().Select(a => ModelFactory.Create(a)).ToList();
           
            return View(data);
        }



        public ActionResult CreateEdit(int id = 0)
        {
            var model = new vehicletype();
            if (id > 0)
            {
                model = ModelFactory.Create(Context.VehicleRepository.GetByID(id));
                ViewBag.Action = "Edit";
            }
            else
            {
                ViewBag.Action = "Create";
            }
            return View(model);
        }
        [HttpPost]
       public ActionResult CreateEdit(vehicletype abc)
        {
            RequestResultModel requestModel = new RequestResultModel();
            try
            {
                if (abc.Id > 0)
                {
                    var vehicle = Context.VehicleRepository.GetByID(abc.Id);
                    vehicle.Model = abc.Model;
                    vehicle.Year = abc.Year;
                    vehicle.Brand = abc.Brand;
                    vehicle.IsNew = abc.IsNew;
                    vehicle.Price = abc.Price;

                    Context.VehicleRepository.Update(vehicle);
                }
                else
                {
                    var vehicle = ModelFactory.Create(abc);
                     Context.VehicleRepository.Insert(vehicle);
                }

                Context.Save();

                requestModel.Message = GetMessage("save");
                requestModel.Title = "Success!";
                requestModel.InfoType = RequestResultInfoType.Success;
                return Json(new
                {
                    Success = true,
                    NotifyType = NotifyType.PageInline,
                    Html = this.RenderPartialView(@"_RequestResultPageInlineMessage", requestModel)

                }, JsonRequestBehavior.AllowGet);

            }

            catch (Exception)
            {

                requestModel.Message = GetMessage("error");
            }

            //we've come this far then something is wrong
            requestModel.Title = "Error!";
            requestModel.InfoType = RequestResultInfoType.ErrorOrDanger;
            return Json(new
            {
                Success = false,
                NotifyType = NotifyType.PageInline,
                Html = this.RenderPartialView(@"_RequestResultPageInlineMessage", requestModel)

            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Context.VehicleRepository.Delete(id);
                Context.Save();
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {


            }

            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

       

       
       
        #region Helpers
      
        private void LoadYearSelect(int selectedValue = 2014)
        {
            int yearLimit = int.Parse(ConfigurationManager.AppSettings["year-limit"]);
            ViewBag.YearSelect = new SelectList(LookupHelpers.GenereateYearsSelection(yearLimit),"Value","Text",selectedValue.ToString());
        }
        #endregion

    }
}
