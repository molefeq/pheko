using Pheko.Common.DataTransformObjects;

using Pheko.ServicePresentation.ServiceResponses;

using System.Collections.Generic;

namespace Pheko.ServicePresentation.EntityManager.Interfaces
{
    public interface IPatientChronicDeseaseManager
    {
        Result<PatientChronicDeseaseDto> GetPatientChronicDeseases(int patientId);
        Response<PatientChronicDeseaseDto> SavePatientChronicDeseases(List<PatientChronicDeseaseDto> patientChronicDeseases);
    }
}
