using Pheko.WebPresentation.ServiceHandlers.Classes;
using Pheko.WebPresentation.ServiceHandlers.Interfaces;
using Pheko.WebPresentation.Utility;
using Pheko.WebPresentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Pheko.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUserHandler _IUserHandler = new UserHandler();

        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Login(LoginViewModel model)
        {
            try
            {
                SecurityUserViewModel response = _IUserHandler.Login(model.UserName, model.Password);
                string returnUrl = Url.Action("PatientManagement", "PatientManagement", new { area = "PatientManagement" });

                FormsAuthenticationLogin(response);

                return JavaScript("window.location='" + returnUrl + "'");
            }
            catch (ModelException ex)
            {
                return Json(new { errors = ex.ModelErrors });
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            // clear authentication cookie
            HttpCookie formsCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            formsCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(formsCookie);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            HttpCookie sessionCookie = new HttpCookie("ASP.NET_SessionId", "");
            sessionCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(sessionCookie);

            FormsAuthentication.RedirectToLoginPage();

            return RedirectToAction("Login", "Home");
        }

        private void FormsAuthenticationLogin(SecurityUserViewModel securityUserViewModel)
        {
            string userDisplayName = securityUserViewModel.Title + " " + securityUserViewModel.FirstName + " " + securityUserViewModel.LastName;

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, securityUserViewModel.SecurityUserId.Value.ToString(), DateTime.Now, DateTime.Now.AddMinutes(30),
                                                                             true, "User|" + securityUserViewModel.UserName + ", " + userDisplayName + ",Midrand Surgery",
                                                                             FormsAuthentication.FormsCookiePath);
            string encryptCookie = FormsAuthentication.Encrypt(ticket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptCookie);

            Response.Cookies.Add(authCookie);
        }
    }
}
