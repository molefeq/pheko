using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Pheko.WebPresentation.Library
{
    public class SecurityFilter : FilterAttribute, IAuthorizationFilter
    {
        private string[] _Roles;

        public SecurityFilter() { }

        public SecurityFilter(params string[] roles)
        {
            _Roles = roles;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            bool isAuthorized = _Roles == null ? true : false;

            if (_Roles != null)
            {
                foreach (string role in _Roles)
                {
                    if (user.IsInRole(role))
                    {
                        isAuthorized = true;
                        break;
                    }
                }
            }

            if (!filterContext.RequestContext.HttpContext.Request.IsAuthenticated || !isAuthorized)
            {
                LogOff(filterContext);

                if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult
                    {
                        Data = new
                        {
                            loginUrl = FormsAuthentication.LoginUrl,
                            message = "sorry, but you were logged out"
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };

                    return;
                }

                FormsAuthentication.RedirectToLoginPage();
                filterContext.Result = new ViewResult() { ViewName = "Login" };

                return;
            }

            SessionCleanUp(filterContext);
        }

        private void LogOff(AuthorizationContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Session.Abandon();
            FormsAuthentication.SignOut();

            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            filterContext.RequestContext.HttpContext.Response.Cookies.Add(cookie1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            filterContext.RequestContext.HttpContext.Response.Cookies.Add(cookie2);
        }

        private void SessionCleanUp(AuthorizationContext filterContext)
        {
            HttpSessionStateBase session = filterContext.RequestContext.HttpContext.Session;
            HttpRequestBase httpRequest = filterContext.RequestContext.HttpContext.Request;

            if (session == null)
            {
                return;
            }

            if (httpRequest.RawUrl.Contains("PatientManagement/PatientManagement/PatientManagement"))
            {
                session["PatientId"] = null;
                session["PatientConsulationId"] = null;
            }

            if (httpRequest.RawUrl.Contains("PatientManagement/Patient/Patient"))
            {
                session["PatientConsulationId"] = null;
            }
        }
    }
}
