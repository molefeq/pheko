using Pheko.WebPresentation.Library;
using Pheko.WebPresentation.ServiceHandlers.Classes;
using Pheko.WebPresentation.ServiceHandlers.Interfaces;
using Pheko.WebPresentation.Utility;
using Pheko.WebPresentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pheko.Web.Areas.PatientManagement.Controllers
{
    public class PatientVitalSignsController : PhekoController
    {
        private IPatientVitalSignHandler _IPatientVitalSignHandler = new PatientVitalSignHandler();

        [HttpGet]
        public ActionResult PatientVitalSigns()
        {
            PatientVitalSignViewModel model = new PatientVitalSignViewModel();

            return View(model);
        }

        [HttpGet]
        public ActionResult GetPatientVitalSigns()
        {
            if (PatientConsultationId == null)
            {
                throw new Exception("Patient Unknown.");
            }
            List<PatientVitalSignViewModel> patientVitalSignViewModels = _IPatientVitalSignHandler.GetPatientVitalSigns(PatientConsultationId.Value);

            return Json(new { patientvitalsigns = patientVitalSignViewModels }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SavePatientVitalSign(List<PatientVitalSignViewModel> models)
        {
            try
            {
                _IPatientVitalSignHandler.SavePatientVitalSigns(models);

                return Json(new { ok = true, patientId = PatientId.Value });
            }
            catch (ModelException ex)
            {
                return Json(new { errors = ex.ModelErrors });
            }
        }

    }
}
