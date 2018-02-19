using Pheko.Common.DataTransformObjects;

using Pheko.ServicePresentation.ServiceResponses;

using System.Collections.Generic;

namespace Pheko.ServicePresentation.EntityManager.Interfaces
{
    public interface IPatientDeseaseScreeningManager
    {
        Result<PatientDeseaseScreeningDto> GetPatientDeseaseScreenings(int patientId);
        Response<PatientDeseaseScreeningDto> SavePatientDeseaseScreenings(List<PatientDeseaseScreeningDto> patientDeseaseScreenings);
    }
}
