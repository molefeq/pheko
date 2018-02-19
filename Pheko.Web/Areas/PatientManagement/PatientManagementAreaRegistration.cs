using System.Web.Mvc;

namespace Pheko.Web.Areas.PatientManagement
{
    public class PatientManagementAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "PatientManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "PatientManagement_default",
                "PatientManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
