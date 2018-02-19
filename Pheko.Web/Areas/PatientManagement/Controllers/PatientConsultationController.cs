using Pheko.WebPresentation.Library;
using Pheko.WebPresentation.ServiceHandlers.Classes;
using Pheko.WebPresentation.ServiceHandlers.Interfaces;
using Pheko.WebPresentation.Utility;
using Pheko.WebPresentation.ViewModels;
using System.Web.Mvc;

namespace Pheko.Web.Areas.PatientManagement.Controllers
{
    [SecurityFilter()]
    public class PatientConsultationController : PhekoController
    {
        private IPatientConsultationHandler _IPatientConsultationHandler = new PatientConsultationHandler();
        private IListHandler _IListHandler = new ListHandler();

        [HttpGet]
        public ActionResult PatientConsultation()
        {
            DataSourceResult result = _IPatientConsultationHandler.Search(PatientId.Value, string.Empty);

            return View(result.Data);
        }

        [HttpPost]
        public ActionResult GetCreatePatientConsultationView()
        {
            PatientConsultationViewModel model = new PatientConsultationViewModel() { PatientId = PatientId, ConsultationStatus = "NEW" };

            ViewBag.Doctors = _IListHandler.GetDoctors();

            return PartialView("PatientConsultationEditor", model);
        }

        [HttpPost]
        public ActionResult SavePatientConsultation(PatientConsultationViewModel model)
        {
            try
            {
                PatientConsultationViewModel patientConsultationViewModel = _IPatientConsultationHandler.SavePatientConsultation(model);

                PatientConsultationId = patientConsultationViewModel.PatientConsultationId;

                string returnUrl = Url.Action("PatientVitalSigns", "PatientVitalSigns", new { area = "PatientManagement" });

                return JavaScript("window.location='" + returnUrl + "'");
            }
            catch (ModelException ex)
            {
                return Json(new { errors = ex.ModelErrors });
            }
        }

        [HttpGet]
        public ActionResult ViewPatientConsultation(int id)
        {
            PatientConsultationId = id;

            string returnUrl = Url.Action("PatientVitalSigns", "PatientVitalSigns", new { area = "PatientManagement" });

            return Redirect(returnUrl);
        }
    }
}
