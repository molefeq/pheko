using Pheko.Common.DataTransformObjects;

using Pheko.ServicePresentation.ServiceResponses;

namespace Pheko.ServicePresentation.EntityManager.Interfaces
{
    public interface IPatientConsultationManager
    {
        Result<PatientConsultationDto> GetPatientConsultations(int patientId, string searchText);
        Response<PatientConsultationDto> SavePatientConsultation(PatientConsultationDto patientConsultationDto);
    }
}
