using Pheko.Common.DataTransformObjects;

using Pheko.ServicePresentation.ServiceResponses;

using System.Collections.Generic;

namespace Pheko.ServicePresentation.EntityManager.Interfaces
{
    public interface IPatientMedicalMonitoringManager
    {
        Result<PatientMedicalMonitoringDto> GetPatientMedicalMonitorings(int patientConsultationId);
        Response<PatientMedicalMonitoringDto> SavePatientMedicalMonitorings(List<PatientMedicalMonitoringDto> patientMedicalMonitorings);
    }
}
