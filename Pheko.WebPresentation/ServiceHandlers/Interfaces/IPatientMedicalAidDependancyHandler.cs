using Pheko.WebPresentation.ViewModels;

namespace Pheko.WebPresentation.ServiceHandlers.Interfaces
{
    public interface IPatientMedicalAidDependancyHandler
    {
        PatientMedicalAidDependancyViewModel SavePatientMedicalAidDependancy(PatientMedicalAidDependancyViewModel patientMedicalAidDependancyViewModel);
    }
}
