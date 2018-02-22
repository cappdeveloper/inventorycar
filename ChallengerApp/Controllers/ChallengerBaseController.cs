﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Challenger.Data;
using ChallengerApp.Models;
using System.Web.Security;
using System.Text;

namespace ChallengerApp.Controllers
{
    public class ChallengerBaseController : Controller
    {
        protected UnitOfWork Context;
        protected ModelFactory ModelFactory;
        protected int CurrentUserId = 0;

        public ChallengerBaseController()
        {
            Context = new UnitOfWork();
            ModelFactory = new ModelFactory();
            //if (Request.IsAuthenticated)
            //{
            //    CurrentUserId = (int)Membership.GetUser().ProviderUserKey;
            //}
        }

        protected override void Dispose(bool disposing)
        {
            Context.Dispose();
            base.Dispose(disposing);
        }

        protected string GetValidationErrors()
        {
            var allErrors = ModelState.Values.SelectMany(v => v.Errors);
            StringBuilder validationErrors = new StringBuilder();
            foreach (var item in allErrors)
            {
                validationErrors.Append(String.Format("{0} {1}", item.ErrorMessage, Environment.NewLine));
            }

            return validationErrors.ToString();
        }

        protected string GetMessage(string type)
        {
            string errorMessage = "";
            switch (type)
            {
                case "error":
                    errorMessage = "An error occured while processing your request!";
                    break;
                case "save":
                    errorMessage = "Record has successfully saved.";
                    break;
                case "update":
                    errorMessage = "Updates on record has successfully saved.";
                    break;
                case "delete":
                    errorMessage = "Record has successfully deleted.";
                    break;
                case "unblock":
                    errorMessage = "Member has successfully unblocked.";
                    break;

                default:
                    errorMessage = "An unknown error has occured. Please contact your system administrator";
                    break;
            }

            return errorMessage;
        }
    }
}
