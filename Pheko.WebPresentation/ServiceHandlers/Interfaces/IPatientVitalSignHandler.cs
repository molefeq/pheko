using Pheko.WebPresentation.ViewModels;

using System.Collections.Generic;

namespace Pheko.WebPresentation.ServiceHandlers.Interfaces
{
    public interface IPatientVitalSignHandler
    {
        List<PatientVitalSignViewModel> GetPatientVitalSigns(int patientConsultationId);

        void SavePatientVitalSigns(List<PatientVitalSignViewModel> patientVitalSignViewModels);
    }
}
