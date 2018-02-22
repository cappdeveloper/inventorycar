using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using WebMatrix.WebData;

namespace ChallengerApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //WebSecurity.InitializeDatabaseConnection("ChallengerConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            InitializeMembership();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            
        }

        private void InitializeMembership()
        {
            WebSecurity.InitializeDatabaseConnection("ChallengerConnection",
                "UserProfile", "UserId", "UserName", autoCreateTables: true);

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
           
            
            if (membership.GetUser("admin@demo.com", false) == null)
            {
                membership.CreateUserAndAccount("admin@demo.com", "admin123");
            }
            if (!roles.GetRolesForUser("admin@demo.com").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "admin@demo.com" }, new[] { "Admin" });
            }
        }
    }
}