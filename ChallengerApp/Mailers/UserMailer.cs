using Mvc.Mailer;
using System.Configuration;

namespace ChallengerApp.Mailers
{ 
    public class UserMailer : MailerBase, IUserMailer 	
	{
		public UserMailer()
		{
            MasterName = "~/Views/UserMailer/_Layout.cshtml";
		}
		
		public virtual MvcMailMessage Welcome(string emailTo,string userName,string tempPassword)
		{
            ViewBag.UserName = userName;
            ViewBag.TempPassword = tempPassword;

			return Populate(x =>
			{
				x.Subject = "Welcome";
				x.ViewName = "Welcome";
				x.To.Add(emailTo);
			});
		}
 
		public virtual MvcMailMessage PasswordReset(string emailTo,string tempPassword,string token)
		{
            string baseUrl = ConfigurationManager.AppSettings["MvcMailer.BaseURL"];

            ViewBag.PasswordResetLink = baseUrl+"Account/ResetPassword?token="+token+"&email="+emailTo;
			return Populate(x =>
			{
				x.Subject = "Password Reset";
				x.ViewName = "PasswordReset";
				x.To.Add(emailTo);
			});
		}
 	}
}