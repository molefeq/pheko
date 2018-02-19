using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pheko.WebPresentation.Library
{
    public abstract class BaseViewPage : WebViewPage
    {
        public virtual new CustomPrincipal User
        {
            get { return base.User as CustomPrincipal; }
        }

        public virtual string UserDisplayName
        {
            get { return User.UserDisplayName; }
        }

        public virtual bool IsRequestAuthenticated
        {
            get { return base.Request.IsAuthenticated; }
        }

        public virtual int? PatientId
        {
            get
            {
                if (Session["PatientId"] == null)
                {
                    return null;
                }

                return (int)Session["PatientId"];
            }
        }

        public virtual int? PatientConsulationId
        {
            get
            {
                if (Session["PatientConsulationId"] == null)
                {
                    return null;
                }

                return (int)Session["PatientConsulationId"];
            }
        }
    }

    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        public virtual new CustomPrincipal User
        {
            get { return base.User as CustomPrincipal; }
        }

        public virtual string UserDisplayName
        {
            get { return User.UserDisplayName; }
        }

        public virtual bool IsRequestAuthenticated
        {
            get { return base.Request.IsAuthenticated; }
        }

        public virtual int? PatientId
        {
            get
            {
                if (Session["PatientId"] == null)
                {
                    return null;
                }

                return Convert.ToInt32(Session["PatientId"]);
            }
        }

        public virtual int? PatientConsulationId
        {
            get
            {
                if (Session["PatientConsultationId"] == null)
                {
                    return null;
                }

                return Convert.ToInt32(Session["PatientConsultationId"]);
            }
        }
    }
}
