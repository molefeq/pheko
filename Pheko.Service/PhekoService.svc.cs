using Pheko.Common.DataTransformObjects;

using Pheko.ServicePresentation.EntityManager.Classes;
using Pheko.ServicePresentation.EntityManager.Interfaces;
using Pheko.ServicePresentation.ServiceResponses;

using System.Collections.Generic;
using System.Data;

namespace Pheko.Service
{
    [ErrorHandlerAttribute]
    public class PhekoService : IPhekoService
    {
        #region Private Fields

        private IPatientManager _IPatientManager = new PatientManager();
        private ISecurityUserManager _ISecurityUserManager = new SecurityUserManager();
        private IPatientMedicalAidDependancyManager _IPatientMedicalAidDependancyManager = new PatientMedicalAidDependancyManager();
        private IPatientConsultationManager _IPatientConsultationManager = new PatientConsultationManager();
        private IPatientVitalSignManager _IPatientVitalSignManager = new PatientVitalSignManager();
        private IPatientMedicalNoteManager _IPatientMedicalNoteManager = new PatientMedicalNoteManager();
        private IPatientChronicDeseaseManager _IPatientChronicDeseaseManager = new PatientChronicDeseaseManager();
        private IPatientPastMedicalHistoryManager _IPatientPastMedicalHistoryManager = new PatientPastMedicalHistoryManager();
        private IPatientDeseaseScreeningManager _IPatientDeseaseScreeningManager = new PatientDeseaseScreeningManager();
        private IPatientClinicalExaminationManager _IPatientClinicalExaminationManager = new PatientClinicalExaminationManager();
        private IPatientMedicalMonitoringManager _IPatientMedicalMonitoringManager = new PatientMedicalMonitoringManager();
        private IListManager _IListManager = new ListManager();
        private IDocumentScheduleManager _IDocumentScheduleManager = new DocumentScheduleManager();
        private IPatientConsultationSickNoteManager _IPatientConsultationSickNoteManager = new PatientConsultationSickNoteManager();

        #endregion

        #region Security User

        public Response<SecurityUserDto> Login(string username, string password)
        {
            return _ISecurityUserManager.Login(username, password);
        }

        public Response<SecurityUserDto> ResetPassword(string username)
        {
            return _ISecurityUserManager.ResetPassword(username);
        }

        public Response<SecurityUserDto> ChangePassword(string username, string oldPassword, string newPassword)
        {
            return _ISecurityUserManager.ChangePassword(username, oldPassword, newPassword);
        }

        public Response<SecurityUserDto> SaveUser(SecurityUserDto securityUser)
        {
            return _ISecurityUserManager.SaveUser(securityUser);
        }

        #endregion

        #region Patient

        public PatientDetailResponse GetPatientDetails(int patientId)
        {
            return _IPatientManager.GetPatientDetails(patientId);
        }

        public Result<PatientDto> Search(PatientDto searchPatient)
        {
            return _IPatientManager.Search(searchPatient);
        }

        public PatientDetailResponse SavePatient(PatientDto patientDto)
        {
            return _IPatientManager.SavePatient(patientDto);
        }
        
        #endregion

        #region Patient Medical Aid Dependancy

        public Response<PatientMedicalAidDependancyDto> SavePatientMedicalAidDependancy(PatientMedicalAidDependancyDto patientMedicalAidDependancyDto)
        {
            return _IPatientMedicalAidDependancyManager.SavePatientMedicalAidDependancy(patientMedicalAidDependancyDto);
        }

        #endregion

        #region Patient Consultation

        public Response<PatientConsultationDto> SavePatientConsultation(PatientConsultationDto patientConsultationDto)
        {
            return _IPatientConsultationManager.SavePatientConsultation(patientConsultationDto);
        }

        public Result<PatientConsultationDto> GetPatientConsultations(int patientId, string searchText)
        {
            return _IPatientConsultationManager.GetPatientConsultations(patientId, searchText);
        }

        #endregion

        #region Patient Vital Sign

        public Result<PatientVitalSignDto> GetPatientVitalSigns(int patientConsultationId)
        {
            return _IPatientVitalSignManager.GetPatientVitalSigns(patientConsultationId);
        }

        public Response<PatientVitalSignDto> SavePatientVitalSigns(List<PatientVitalSignDto> patientVitalSigns)
        {
            return _IPatientVitalSignManager.SavePatientVitalSigns(patientVitalSigns);
        }

        #endregion

        #region Patient Medical Notes

        public Result<PatientMedicalNoteDto> GetPatientMedicalNotes(int patientConsultationId)
        {
            return _IPatientMedicalNoteManager.GetPatientMedicalNotes(patientConsultationId);
        }

        public Response<PatientMedicalNoteDto> SavePatientMedicalNotes(List<PatientMedicalNoteDto> patientMedicalNotes)
        {
            return _IPatientMedicalNoteManager.SavePatientMedicalNotes(patientMedicalNotes);
        }

        #endregion

        #region Patient Chronic Deseases

        public Result<PatientChronicDeseaseDto> GetPatientChronicDeseases(int patientId)
        {
            return _IPatientChronicDeseaseManager.GetPatientChronicDeseases(patientId);
        }

        public Response<PatientChronicDeseaseDto> SavePatientChronicDeseases(List<PatientChronicDeseaseDto> patientChronicDeseases)
        {
            return _IPatientChronicDeseaseManager.SavePatientChronicDeseases(patientChronicDeseases);
        }

        #endregion

        #region Patient Desease Screenings

        public Result<PatientDeseaseScreeningDto> GetPatientDeseaseScreenings(int patientId)
        {
            return _IPatientDeseaseScreeningManager.GetPatientDeseaseScreenings(patientId);
        }

        public Response<PatientDeseaseScreeningDto> SavePatientDeseaseScreenings(List<PatientDeseaseScreeningDto> patientDeseaseScreenings)
        {
            return _IPatientDeseaseScreeningManager.SavePatientDeseaseScreenings(patientDeseaseScreenings);
        }

        #endregion

        #region Patient Past Medical Histories

        public Result<PatientPastMedicalHistoryDto> GetPatientPastMedicalHistories(int patientId)
        {
            return _IPatientPastMedicalHistoryManager.GetPatientPastMedicalHistories(patientId);
        }

        public Response<PatientPastMedicalHistoryDto> SavePatientPastMedicalHistories(List<PatientPastMedicalHistoryDto> patientPastMedicalHistories)
        {
            return _IPatientPastMedicalHistoryManager.SavePatientPastMedicalHistories(patientPastMedicalHistories);
        }

        #endregion

        #region Patient Clinical Examinations

        public Result<PatientClinicalExaminationDto> GetPatientClinicalExaminations(int patientConsultationId)
        {
            return _IPatientClinicalExaminationManager.GetPatientClinicalExaminations(patientConsultationId);
        }

        public Response<PatientClinicalExaminationDto> SavePatientClinicalExaminations(List<PatientClinicalExaminationDto> patientClinicalExaminations)
        {
            return _IPatientClinicalExaminationManager.SavePatientClinicalExaminations(patientClinicalExaminations);
        }

        #endregion

        #region Patient Medical Monitorings

        public Result<PatientMedicalMonitoringDto> GetPatientMedicalMonitorings(int patientConsultationId)
        {
            return _IPatientMedicalMonitoringManager.GetPatientMedicalMonitorings(patientConsultationId);
        }

        public Response<PatientMedicalMonitoringDto> SavePatientMedicalMonitorings(List<PatientMedicalMonitoringDto> patientMedicalMonitorings)
        {
            return _IPatientMedicalMonitoringManager.SavePatientMedicalMonitorings(patientMedicalMonitorings);
        }

        #endregion
        
        #region Patient Consultation Sick Note

        public PatientConsultationSickNoteDto GetPatientConsultationSickNote(int patientConsultationId)
        {
            return _IPatientConsultationSickNoteManager.GetPatientConsultationSickNote(patientConsultationId);
        }

        public Response<PatientConsultationSickNoteDto> SavePatientConsultationSickNote(PatientConsultationSickNoteDto patientConsultationSickNoteDto)
        {
            return _IPatientConsultationSickNoteManager.SavePatientConsultationSickNote(patientConsultationSickNoteDto);
        }

        #endregion

        #region Lists

        public List<CountryDto> GetCountries()
        {
            return _IListManager.GetCountries();
        }

        public List<ProvinceDto> GetCountryProvinces(int? countryId)
        {
            return _IListManager.GetCountryProvinces(countryId);
        }

        public List<FieldValueDto> GetFieldValues(string tableName, string fieldName)
        {
            return _IListManager.GetFieldValues(tableName, fieldName);
        }

        public List<DoctorDto> GetDoctors()
        {
            return _IListManager.GetDoctors();
        }

        #endregion

        #region Document Schedules
        
        public DataSet GetPatientSchedule(int patientId, int userId)
        {
            return _IDocumentScheduleManager.GetPatientSchedule(patientId, userId);
        }

        public DataSet GetPatientSickNoteSchedule(int patientConsultationId, int userId)
        {
            return _IDocumentScheduleManager.GetPatientSickNoteSchedule(patientConsultationId, userId);
        }

        public DataSet GetPatientScriptNoteSchedule(int patientConsultationId, int userId)
        {
            return _IDocumentScheduleManager.GetPatientScriptNoteSchedule(patientConsultationId, userId);
        }

        #endregion
    }
}
