using Pheko.WebPresentation.Library;

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace Pheko.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

            if (HttpContext.Current.User != null &&
                HttpContext.Current.User.Identity.IsAuthenticated &&
                HttpContext.Current.User.Identity is FormsIdentity)
            {
                FormsIdentity identity = (FormsIdentity)HttpContext.Current.User.Identity;
                FormsAuthenticationTicket ticket = identity.Ticket;

                string ticketUserRoles = ticket.UserData.Split(new string[] { "|" }, StringSplitOptions.None)[0];
                string ticketUserAdditionalInformation = ticket.UserData.Split(new string[] { "|" }, StringSplitOptions.None)[1];

                List<string> roles = new List<string>();

                roles.AddRange(ticketUserRoles.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));

                string userName = ticketUserAdditionalInformation.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0];
                string userDisplayName = ticketUserAdditionalInformation.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[1];
                string userSugeryName = ticketUserAdditionalInformation.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[2];

                HttpContext.Current.User = new CustomPrincipal(identity, roles, userName, userDisplayName, userSugeryName);
            }
        }
    }
}
