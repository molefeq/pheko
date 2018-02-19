using Pheko.Common.DataTransformObjects;

using Pheko.ServicePresentation.ServiceResponses;

namespace Pheko.ServicePresentation.EntityManager.Interfaces
{
    public interface IPatientConsultationSickNoteManager
    {
        PatientConsultationSickNoteDto GetPatientConsultationSickNote(int patientConsultationId);

        Response<PatientConsultationSickNoteDto> SavePatientConsultationSickNote(PatientConsultationSickNoteDto patientConsultationSickNoteDto);
    }
}
