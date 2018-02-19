using Pheko.WebPresentation.ViewModels;

using System.Collections.Generic;

namespace Pheko.WebPresentation.ServiceHandlers.Interfaces
{
    public interface IPatientClinicalExaminationHandler
    {
        List<PatientClinicalExaminationViewModel> GetPatientClinicalExaminations(int patientConsultationId);

        void SavePatientClinicalExaminations(List<PatientClinicalExaminationViewModel> patientClinicalExaminationViewModels);
    }
}
