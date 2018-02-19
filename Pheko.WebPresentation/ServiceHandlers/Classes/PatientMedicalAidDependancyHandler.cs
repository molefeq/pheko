using Pheko.Common.UtilityComponent;

using Pheko.WebPresentation.MappingViewModelsToDtos;
using Pheko.WebPresentation.PhekoService;
using Pheko.WebPresentation.ServiceHandlers.Interfaces;
using Pheko.WebPresentation.Utility;
using Pheko.WebPresentation.ViewModels;

using System.Linq;

namespace Pheko.WebPresentation.ServiceHandlers.Classes
{
    public class PatientMedicalAidDependancyHandler : IPatientMedicalAidDependancyHandler
    {
        private PhekoServiceClient _PhekoServiceClient = new PhekoServiceClient();
        private PatientMedicalAidDependancyViewModelMapper _PatientMedicalAidDependancyViewModelMapper = new PatientMedicalAidDependancyViewModelMapper();

        public PatientMedicalAidDependancyHandler() { }

        public PatientMedicalAidDependancyViewModel SavePatientMedicalAidDependancy(PatientMedicalAidDependancyViewModel patientMedicalAidDependancyViewModel)
        {
            PatientMedicalAidDependancyDtoResponse response = _PhekoServiceClient.SavePatientMedicalAidDependancy(_PatientMedicalAidDependancyViewModelMapper.MapToPatientMedicalAidDependancyDto(patientMedicalAidDependancyViewModel));

            if (response.HasErrors)
            {
                ModelException modelException = new ModelException();

                response.FieldErrors.ToList<FieldError>().ForEach(item => modelException.ModelErrors.Add(new ModelError() { FieldName = item.FieldName, Message = item.ErrorMessage }));

                throw modelException;
            }

            return _PatientMedicalAidDependancyViewModelMapper.MapToPatientMedicalAidDependancyViewModel(response.Model);
        }
    }
}
