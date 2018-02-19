using Pheko.WebPresentation.Library;
using Pheko.WebPresentation.ServiceHandlers.Classes;
using Pheko.WebPresentation.ServiceHandlers.Interfaces;
using Pheko.WebPresentation.Utility;
using Pheko.WebPresentation.ViewModels;

using System.Web.Mvc;

namespace Pheko.Web.Areas.PatientManagement.Controllers
{
    [SecurityFilter()]
    public class PatientManagementController : PhekoController
    {
        private IPatientHandler _IPatientHandler = new PatientHandler();

        [HttpGet]
        public ActionResult PatientManagement()
        {
            return View();
        }

        public ActionResult LoadPatients(SearchPatientViewModel model)
        {
            try
            {
                DataSourceResult response = _IPatientHandler.Search(model);
                return Json(new { ok = true, total = response.Total, data = response.Data }, JsonRequestBehavior.AllowGet);
            }
            catch (ModelException ex)
            {
                return Json(new { errors = ex.ModelErrors }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchPatient(SearchPatientViewModel model)
        {
            try
            {
                DataSourceResult response = _IPatientHandler.Search(model);
                //return Json(new { ok = true, total = response.Total, data = response.Data });
                return PartialView("_SearchPatientGrid", response.Data);
            }
            catch (ModelException ex)
            {
                return Json(new { errors = ex.ModelErrors });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePatient(CreatePatientViewModel model)
        {
            try
            {
                string returnUrl = Url.Action("Patient", "Patient", new { area = "PatientManagement" });
                PatientViewModel response = _IPatientHandler.CreatePatient(model);

                PatientId = response.PatientId;

                return JavaScript("window.location='" + returnUrl + "'");
            }
            catch (ModelException ex)
            {
                return Json(new { errors = ex.ModelErrors });
            }
        }
        
        [HttpGet]
        public ActionResult EditPatient(int id)
        {
            string returnUrl = Url.Action("Patient", "Patient", new { area = "PatientManagement" });

            PatientId = id;

            return Redirect(returnUrl);
        }

    }
}
