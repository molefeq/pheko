using Pheko.Common.DataTransformObjects;

using Pheko.ServicePresentation.ServiceResponses;

using System.Collections.Generic;

namespace Pheko.ServicePresentation.EntityManager.Interfaces
{
    public interface IPatientPastMedicalHistoryManager
    {
        Result<PatientPastMedicalHistoryDto> GetPatientPastMedicalHistories(int patientId);
        Response<PatientPastMedicalHistoryDto> SavePatientPastMedicalHistories(List<PatientPastMedicalHistoryDto> patientpastMedicalHistories);
    }
}
