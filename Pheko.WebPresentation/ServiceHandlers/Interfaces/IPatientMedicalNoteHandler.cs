using Pheko.WebPresentation.ViewModels;

using System.Collections.Generic;

namespace Pheko.WebPresentation.ServiceHandlers.Interfaces
{
    public interface IPatientMedicalNoteHandler
    {
        List<PatientMedicalNoteViewModel> GetPatientMedicalNotes(int patientConsultationId);

        void SavePatientMedicalNotes(List<PatientMedicalNoteViewModel> patientMedicalNoteViewModels);

        List<PatientChronicDeseaseViewModel> GetPatientChronicDeseases(int patientId);

        void SavePatientChronicDeseases(List<PatientChronicDeseaseViewModel> patientChronicDeseaseViewModels);

        List<PatientPastMedicalHistoryViewModel> GetPatientPastMedicalHistories(int patientId);

        void SavePastMedicalHistories(List<PatientPastMedicalHistoryViewModel> patientPastMedicalHistoryViewModels);
        
        List<PatientDeseaseScreeningViewModel> GetPatientDeseaseScreenings(int patientId);

        void SavePatientDeseaseScreenings(List<PatientDeseaseScreeningViewModel> patientDeseaseScreeningViewModels);
    }
}
