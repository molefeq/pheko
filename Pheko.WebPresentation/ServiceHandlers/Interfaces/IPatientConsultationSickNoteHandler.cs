using Pheko.WebPresentation.ViewModels;

namespace Pheko.WebPresentation.ServiceHandlers.Interfaces
{
    public interface IPatientConsultationSickNoteHandler
    {
        PatientConsultationSickNoteViewModel GetPatientConsultationSickNote(int patientConsultationId, int patientId);

        PatientConsultationSickNoteViewModel SavePatientConsultationSickNote(PatientConsultationSickNoteViewModel patientConsultationSickNoteViewModel);
    }
}
