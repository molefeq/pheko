using System;
using System.Web.Mvc;

namespace Pheko.WebPresentation.Library
{
    public class PhekoController : Controller
    {
        protected virtual new CustomPrincipal User
        {
            get { return HttpContext.User as CustomPrincipal; }
        }

        protected virtual int SecurityUserId
        {
            get { return Convert.ToInt32(HttpContext.User.Identity.Name); }
        }

        protected virtual string UserName
        {
            get { return User.UserName; }
        }

        protected string UserDisplayName
        {
            get { return User.UserDisplayName; }
        }

        protected int? PatientId
        {
            get
            {
                if (Session["PatientId"] == null)
                {
                    return null;
                }

                return Convert.ToInt32(Session["PatientId"]);
            }
            set
            {
                Session["PatientId"] = value;
            }
        }

        protected int? PatientPostalAddressId
        {
            get
            {
                if (Session["PatientPostalAddressId"] == null)
                {
                    return null;
                }

                return Convert.ToInt32(Session["PatientPostalAddressId"]);
            }
            set
            {
                Session["PatientPostalAddressId"] = value;
            }
        }

        protected int? PatientPhysicalAddressId
        {
            get
            {
                if (Session["PatientPhysicalAddressId"] == null)
                {
                    return null;
                }

                return Convert.ToInt32(Session["PatientPhysicalAddressId"]);
            }
            set
            {
                Session["PatientPhysicalAddressId"] = value;
            }
        }
        
        protected int? PatientConsultationId
        {
            get
            {
                if (Session["PatientConsultationId"] == null)
                {
                    return null;
                }

                return Convert.ToInt32(Session["PatientConsultationId"]);
            }
            set
            {
                Session["PatientConsultationId"] = value;
            }
        }

    }
}
