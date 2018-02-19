using Pheko.Common.DataTransformObjects;

using Pheko.ServicePresentation.ServiceResponses;

using System.Collections.Generic;

namespace Pheko.ServicePresentation.EntityManager.Interfaces
{
    public interface IPatientClinicalExaminationManager
    {
        Result<PatientClinicalExaminationDto> GetPatientClinicalExaminations(int patientConsultationId);
        Response<PatientClinicalExaminationDto> SavePatientClinicalExaminations(List<PatientClinicalExaminationDto> patientClinicalExaminations);
    }
}
