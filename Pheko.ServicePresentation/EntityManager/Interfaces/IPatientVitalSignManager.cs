using Pheko.Common.DataTransformObjects;

using Pheko.ServicePresentation.ServiceResponses;

using System.Collections.Generic;

namespace Pheko.ServicePresentation.EntityManager.Interfaces
{
    public interface IPatientVitalSignManager
    {
        Result<PatientVitalSignDto> GetPatientVitalSigns(int patientConsultationId);
        Response<PatientVitalSignDto> SavePatientVitalSigns(List<PatientVitalSignDto> patientVitalSigns);
    }
}
