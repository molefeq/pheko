using Pheko.WebPresentation.Library;
using Pheko.WebPresentation.PdfDocuments;
using Pheko.WebPresentation.ServiceHandlers.Classes;
using Pheko.WebPresentation.ServiceHandlers.Interfaces;
using Pheko.WebPresentation.Utility;
using Pheko.WebPresentation.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Pheko.Web.Areas.PatientManagement.Controllers
{
    public class PatientMedicalNoteController : PhekoController
    {
        private IPatientMedicalNoteHandler _IPatientMedicalNoteHandler = new PatientMedicalNoteHandler();
        private IPatientClinicalExaminationHandler _IPatientClinicalExaminationHandler = new PatientClinicalExaminationHandler();
        private IPatientMedicalMonitoringHandler _IPatientMedicalMonitoringHandler = new PatientMedicalMonitoringHandler();
        private IPatientConsultationSickNoteHandler _IPatientConsultationSickNoteHandler = new PatientConsultationSickNoteHandler();

        [HttpGet]
        public ActionResult PatientMedicalNote()
        {
            InitialiseLists();

            return View();
        }

        [HttpGet]
        public ActionResult GetPatientMedicalNotes()
        {
            if (PatientId == null)
            {
                throw new Exception("Patient is unknown.");
            }

            if (PatientConsultationId == null)
            {
                throw new Exception("Patient Consultation is unknown.");
            }

            List<PatientMedicalNoteViewModel> patientMedicalNoteViewModels = _IPatientMedicalNoteHandler.GetPatientMedicalNotes(PatientConsultationId.Value);
            List<PatientChronicDeseaseViewModel> patientChronicDeseaseViewModels = _IPatientMedicalNoteHandler.GetPatientChronicDeseases(PatientId.Value);
            List<PatientPastMedicalHistoryViewModel> patientPastMedicalHistoryViewModels = _IPatientMedicalNoteHandler.GetPatientPastMedicalHistories(PatientId.Value);
            List<PatientDeseaseScreeningViewModel> patientDeseaseScreeningViewModels = _IPatientMedicalNoteHandler.GetPatientDeseaseScreenings(PatientId.Value);
            List<PatientClinicalExaminationViewModel> patientClinicalExaminationViewModels = _IPatientClinicalExaminationHandler.GetPatientClinicalExaminations(PatientConsultationId.Value);
            List<PatientMedicalMonitoringViewModel> patientMedicalMonitoringViewModels = _IPatientMedicalMonitoringHandler.GetPatientMedicalMonitorings(PatientConsultationId.Value);
            PatientConsultationSickNoteViewModel patientConsultationSickNoteViewModel = _IPatientConsultationSickNoteHandler.GetPatientConsultationSickNote(PatientConsultationId.Value, PatientId.Value);

            return Json(new
            {
                patientmedicalnotes = patientMedicalNoteViewModels,
                patientchronicdeseases = patientChronicDeseaseViewModels,
                patientpastmedicalhistories = patientPastMedicalHistoryViewModels,
                patientdeseasescreenings = patientDeseaseScreeningViewModels,
                patientclinicalexaminations = patientClinicalExaminationViewModels,
                patientmedicalmonitorings = patientMedicalMonitoringViewModels,
                patientconsultationsicknote = patientConsultationSickNoteViewModel
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SavePatientMedicalNotes(List<PatientMedicalNoteViewModel> patientMedicalNoteViewModels, List<PatientChronicDeseaseViewModel> patientChronicDeseaseViewModels,
                                                    List<PatientPastMedicalHistoryViewModel> patientPastMedicalHistoryViewModels, List<PatientDeseaseScreeningViewModel> patientDeseaseScreeningViewModels,
                                                    List<PatientClinicalExaminationViewModel> patientClinicalExaminationViewModels, List<PatientMedicalMonitoringViewModel> patientMedicalMonitoringViewModels,
                                                    PatientConsultationSickNoteViewModel patientConsultationSickNoteViewModel)
        {
            try
            {
                _IPatientMedicalNoteHandler.SavePatientChronicDeseases(patientChronicDeseaseViewModels);
                _IPatientMedicalNoteHandler.SavePatientDeseaseScreenings(patientDeseaseScreeningViewModels);
                _IPatientMedicalNoteHandler.SavePastMedicalHistories(patientPastMedicalHistoryViewModels);
                _IPatientMedicalNoteHandler.SavePatientMedicalNotes(patientMedicalNoteViewModels);
                _IPatientClinicalExaminationHandler.SavePatientClinicalExaminations(patientClinicalExaminationViewModels);
                _IPatientMedicalMonitoringHandler.SavePatientMedicalMonitorings(patientMedicalMonitoringViewModels);
                _IPatientConsultationSickNoteHandler.SavePatientConsultationSickNote(patientConsultationSickNoteViewModel);

                return Json(new { ok = true, patientId = PatientId.Value });
            }
            catch (ModelException ex)
            {
                return Json(new { errors = ex.ModelErrors });
            }
        }
        
        [HttpPost]
        public ActionResult SavePatientConsultationSickNote(PatientConsultationSickNoteViewModel patientConsultationSickNoteViewModel)
        {
            try
            {
                _IPatientConsultationSickNoteHandler.SavePatientConsultationSickNote(patientConsultationSickNoteViewModel);

                return Json(new { ok = true, patientConsultationId = PatientConsultationId.Value });
            }
            catch (ModelException ex)
            {
                return Json(new { errors = ex.ModelErrors });
            }
        }

        [HttpGet]
        public ActionResult PrintPatientSickNoteSchedule(int patientConsultationId)
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                PatientSickNoteSchedule.CreatePatientSickNoteSchedulePdf(patientConsultationId, SecurityUserId, Server.MapPath("~/XsltTemplates/"), HttpContext, memoryStream);
                byte[] pdf = memoryStream.ToArray();
                string fileName = System.Guid.NewGuid().ToString() + ".pdf";

                return File(pdf, "application/pdf", Server.UrlEncode(fileName));
            }
            catch (ModelException ex)
            {
                return Json(new { errors = ex.ModelErrors });
            }
        }

        private void InitialiseLists()
        {
            var years = Enumerable.Range(1900, DateTime.Now.Year - 1900 + 1);

            ViewBag.Years = years.Select(item => new SelectListItem { Text = item.ToString(), Value = item.ToString() });
        }
    }
}
