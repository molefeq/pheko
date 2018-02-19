using Pheko.WebPresentation.Library;
using Pheko.WebPresentation.ViewModels;

using System.Collections.Generic;
using System.Data;

namespace Pheko.WebPresentation.ServiceHandlers.Interfaces
{
    public interface IPatientHandler
    {
        PatientViewModel GetPatientDetails(int patientId, List<PatientMedicalAidDependancyViewModel> patientMedicalAidDepandancies);

        DataSourceResult Search(SearchPatientViewModel searchPatientViewModel);

        PatientViewModel SavePatient(PatientViewModel patientViewModel);

        PatientViewModel CreatePatient(CreatePatientViewModel createPatientViewModel);
    }
}
