using Pheko.WebPresentation.ViewModels;

using System.Collections.Generic;

namespace Pheko.WebPresentation.ServiceHandlers.Interfaces
{
    public interface IPatientMedicalMonitoringHandler
    {
        List<PatientMedicalMonitoringViewModel> GetPatientMedicalMonitorings(int patientConsultationId);

        void SavePatientMedicalMonitorings(List<PatientMedicalMonitoringViewModel> patientMedicalMonitoringViewModels);
    }
}
