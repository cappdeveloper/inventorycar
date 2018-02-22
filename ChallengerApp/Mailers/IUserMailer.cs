using Mvc.Mailer;

namespace ChallengerApp.Mailers
{
    public interface IUserMailer
    {
        MvcMailMessage Welcome(string emailTo, string userName, string tempPassword);
        MvcMailMessage PasswordReset(string emailTo,string tempPassword,string token);
    }
}