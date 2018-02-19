using Pheko.WebPresentation.Library;
using Pheko.WebPresentation.PdfDocuments;
using Pheko.WebPresentation.ServiceHandlers.Classes;
using Pheko.WebPresentation.ServiceHandlers.Interfaces;
using Pheko.WebPresentation.Utility;
using Pheko.WebPresentation.ViewModels;

using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Pheko.Web.Areas.PatientManagement.Controllers
{
    [SecurityFilter()]
    public class PatientController : PhekoController
    {
        private IPatientHandler _IPatientHandler = new PatientHandler();
        private IPatientMedicalAidDependancyHandler _IPatientMedicalAidDependancyHandler = new PatientMedicalAidDependancyHandler();
        private IListHandler _IListHandler = new ListHandler();

        [HttpGet]
        public ActionResult Patient()
        {
            if (PatientId == null)
            {
                throw new Exception("Patient Unknown.");
            }

            ViewBag.Titles = _IListHandler.GetFieldValues("Patient", "Title");
            ViewBag.MaritalStatuses = _IListHandler.GetFieldValues("Patient", "MaritalStatus");
            ViewBag.MarriageTypes = _IListHandler.GetFieldValues("Patient", "MarriageType");
            ViewBag.Genders = _IListHandler.GetFieldValues("Patient", "Gender");
            ViewBag.PrefferedContactTypes = _IListHandler.GetFieldValues("Patient", "PrefferedContactMethod");
            ViewBag.IDTypes = _IListHandler.GetFieldValues("Patient", "IDType");
            ViewBag.EthnicGroups = _IListHandler.GetFieldValues("Patient", "EthnicGroup");
            ViewBag.SourceOfDiscoveries = _IListHandler.GetFieldValues("Patient", "SourceOfDiscovery");
            ViewBag.EthnicGroups = _IListHandler.GetFieldValues("Patient", "EthnicGroup");
            ViewBag.Provinces = _IListHandler.GetProvinces();
            ViewBag.Relationships = _IListHandler.GetFieldValues("MedicalAidDependancies", "Relationship");

            PatientViewModel model = new PatientViewModel();

            return View(model);
        }

        [HttpGet]
        public ActionResult GetPatient()
        {
            if (PatientId == null)
            {
                throw new Exception("Patient Unknown.");
            }
            List<PatientMedicalAidDependancyViewModel> patientMedicalAidDepandancies = new List<PatientMedicalAidDependancyViewModel>();
            PatientViewModel model = _IPatientHandler.GetPatientDetails(PatientId.Value, patientMedicalAidDepandancies);

            return Json(new { data = model, patientmedicalaiddepandancies = patientMedicalAidDepandancies }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SavePatient(PatientViewModel model)
        {
            try
            {
                model.CrudOperation = ModelCrudOperations.Update;

                PatientViewModel patientViewModel = _IPatientHandler.SavePatient(model);

                return Json(new { ok = true, data = patientViewModel });
            }
            catch (ModelException ex)
            {
                return Json(new { errors = ex.ModelErrors });
            }
        }

        [HttpGet]
        public ActionResult PrintPatientSchedule(int patientId)
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                PatientSchedule.CreatePatientSchedulePdf(patientId, SecurityUserId, Server.MapPath("~/XsltTemplates/"), true, true, HttpContext, memoryStream);
                byte[] pdf = memoryStream.ToArray();
                string fileName = System.Guid.NewGuid().ToString() + ".pdf";

                return File(pdf, "application/pdf", Server.UrlEncode(fileName));
            }
            catch (ModelException ex)
            {
                return Json(new { errors = ex.ModelErrors });
            }
        }

        [HttpPost]
        public ActionResult SavePatientMedicalAidDependancy(PatientMedicalAidDependancyViewModel model)
        {
            try
            {
                PatientMedicalAidDependancyViewModel patientMedicalAidDependancyViewModel = _IPatientMedicalAidDependancyHandler.SavePatientMedicalAidDependancy(model);

                return Json(new { ok = true, data = patientMedicalAidDependancyViewModel });
            }
            catch (ModelException ex)
            {
                return Json(new { errors = ex.ModelErrors });
            }
        }

        [HttpPost]
        public ActionResult DeletePatientMedicalAidDependancy(int patientMedicalAidDependancyId)
        {
            try
            {
                PatientMedicalAidDependancyViewModel model = new PatientMedicalAidDependancyViewModel()
                {
                    CrudOperation = ModelCrudOperations.Delete,
                    PatientMedicalAidDependanciesId = patientMedicalAidDependancyId
                };

                PatientMedicalAidDependancyViewModel patientMedicalAidDependancyViewModel = _IPatientMedicalAidDependancyHandler.SavePatientMedicalAidDependancy(model);

                return Json(new { ok = true });
            }
            catch (ModelException ex)
            {
                return Json(new { errors = ex.ModelErrors });
            }
        }

        [HttpPost]
        public ActionResult PatientMedicalAidDependancyView()
        {
            ViewBag.Titles = _IListHandler.GetFieldValues("Patient", "Title");
            ViewBag.Relationships = _IListHandler.GetFieldValues("MedicalAidDependancies", "Relationship");
            return PartialView("PatientMedicalAidDependancy", new PatientMedicalAidDependancyViewModel());
        }
    }
}
