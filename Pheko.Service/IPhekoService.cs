using Pheko.Common.DataTransformObjects;

using Pheko.ServicePresentation.ServiceResponses;

using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

namespace Pheko.Service
{
    [ServiceContract]
    public interface IPhekoService
    {
        #region Security User

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [OperationContract]
        Response<SecurityUserDto> Login(string username, string password);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [OperationContract]
        Response<SecurityUserDto> ResetPassword(string username);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        [OperationContract]
        Response<SecurityUserDto> ChangePassword(string username, string oldPassword, string newPassword);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="securityUser"></param>
        /// <returns></returns>
        [OperationContract]
        Response<SecurityUserDto> SaveUser(SecurityUserDto securityUser);

        #endregion

        #region Patient
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        [OperationContract]
        PatientDetailResponse GetPatientDetails(int patientId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchPatient"></param>
        /// <returns></returns>
        [OperationContract]
        Result<PatientDto> Search(PatientDto searchPatient);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientDto"></param>
        /// <returns></returns>
        [OperationContract]
        PatientDetailResponse SavePatient(PatientDto patientDto);
        
        #endregion

        #region Patient Medical Aid Dependancy

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientMedicalAidDependancyDto"></param>
        /// <returns></returns>
        [OperationContract]
        Response<PatientMedicalAidDependancyDto> SavePatientMedicalAidDependancy(PatientMedicalAidDependancyDto patientMedicalAidDependancyDto);

        #endregion

        #region Patient Consultation

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientConsultationDto"></param>
        /// <returns></returns>
        [OperationContract]
        Response<PatientConsultationDto> SavePatientConsultation(PatientConsultationDto patientConsultationDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="searchText"></param>
        /// <returns></returns>
        [OperationContract]
        Result<PatientConsultationDto> GetPatientConsultations(int patientId, string searchText);

        #endregion

        #region Patient Vital Sign

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientConsultationId"></param>
        /// <returns></returns>
        [OperationContract]
        Result<PatientVitalSignDto> GetPatientVitalSigns(int patientConsultationId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientVitalSigns"></param>
        /// <returns></returns>
        [OperationContract]
        Response<PatientVitalSignDto> SavePatientVitalSigns(List<PatientVitalSignDto> patientVitalSigns);

        #endregion

        #region Patient Medical Notes

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientConsultationId"></param>
        /// <returns></returns>
        [OperationContract]
        Result<PatientMedicalNoteDto> GetPatientMedicalNotes(int patientConsultationId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientMedicalNotes"></param>
        /// <returns></returns>
        [OperationContract]
        Response<PatientMedicalNoteDto> SavePatientMedicalNotes(List<PatientMedicalNoteDto> patientMedicalNotes);

        #endregion

        #region Patient Chronic Deseases

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        [OperationContract]
        Result<PatientChronicDeseaseDto> GetPatientChronicDeseases(int patientId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientChronicDeseases"></param>
        /// <returns></returns>
        [OperationContract]
        Response<PatientChronicDeseaseDto> SavePatientChronicDeseases(List<PatientChronicDeseaseDto> patientChronicDeseases);

        #endregion

        #region Patient Desease Screenings

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        [OperationContract]
        Result<PatientDeseaseScreeningDto> GetPatientDeseaseScreenings(int patientId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientDeseaseScreenings"></param>
        /// <returns></returns>
        [OperationContract]
        Response<PatientDeseaseScreeningDto> SavePatientDeseaseScreenings(List<PatientDeseaseScreeningDto> patientDeseaseScreenings);

        #endregion

        #region Patient Past Medical Histories

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        [OperationContract]
        Result<PatientPastMedicalHistoryDto> GetPatientPastMedicalHistories(int patientId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientPastMedicalHistories"></param>
        /// <returns></returns>
        [OperationContract]
        Response<PatientPastMedicalHistoryDto> SavePatientPastMedicalHistories(List<PatientPastMedicalHistoryDto> patientPastMedicalHistories);

        #endregion

        #region Patient Clinical Examinations

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientConsultationId"></param>
        /// <returns></returns>
        [OperationContract]
        Result<PatientClinicalExaminationDto> GetPatientClinicalExaminations(int patientConsultationId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientClinicalExaminations"></param>
        /// <returns></returns>
        [OperationContract]
        Response<PatientClinicalExaminationDto> SavePatientClinicalExaminations(List<PatientClinicalExaminationDto> patientClinicalExaminations);

        #endregion

        #region Patient Medical Monitorings

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientConsultationId"></param>
        /// <returns></returns>
        [OperationContract]
        Result<PatientMedicalMonitoringDto> GetPatientMedicalMonitorings(int patientConsultationId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientMedicalMonitorings"></param>
        /// <returns></returns>
        [OperationContract]
        Response<PatientMedicalMonitoringDto> SavePatientMedicalMonitorings(List<PatientMedicalMonitoringDto> patientMedicalMonitorings);

        #endregion

        #region Patient Consultation Sick Note

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientConsultationId"></param>
        /// <returns></returns>
        [OperationContract]
        PatientConsultationSickNoteDto GetPatientConsultationSickNote(int patientConsultationId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientConsultationSickNoteDto"></param>
        /// <returns></returns>
        [OperationContract]
        Response<PatientConsultationSickNoteDto> SavePatientConsultationSickNote(PatientConsultationSickNoteDto patientConsultationSickNoteDto);

        #endregion

        #region Lists

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CountryDto> GetCountries();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        [OperationContract]
        List<ProvinceDto> GetCountryProvinces(int? countryId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        [OperationContract]
        List<FieldValueDto> GetFieldValues(string tableName, string fieldName);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<DoctorDto> GetDoctors();

        #endregion

        #region Document Schedules

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetPatientSchedule(int patientId, int userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientConsultationId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetPatientSickNoteSchedule(int patientConsultationId, int userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientConsultationId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [OperationContract]
        DataSet GetPatientScriptNoteSchedule(int patientConsultationId, int userId);
        
        #endregion
    }
}
