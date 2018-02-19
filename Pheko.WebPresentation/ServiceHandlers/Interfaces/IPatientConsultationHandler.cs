using Pheko.WebPresentation.Library;
using Pheko.WebPresentation.ViewModels;

namespace Pheko.WebPresentation.ServiceHandlers.Interfaces
{
    public interface IPatientConsultationHandler
    {
        DataSourceResult Search(int patientId, string searchText);

        PatientConsultationViewModel SavePatientConsultation(PatientConsultationViewModel patientConsultationViewModel);
    }
}
