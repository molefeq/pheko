using Pheko.Common.DataTransformObjects;
using Pheko.Common.UtilityComponent;

using Pheko.WebPresentation.MappingViewModelsToDtos;
using Pheko.WebPresentation.PhekoService;
using Pheko.WebPresentation.ServiceHandlers.Interfaces;
using Pheko.WebPresentation.Utility;
using Pheko.WebPresentation.ViewModels;

using System.Collections.Generic;
using System.Linq;

namespace Pheko.WebPresentation.ServiceHandlers.Classes
{
    public class PatientVitalSignHandler : IPatientVitalSignHandler
    {
        private PhekoServiceClient _PhekoServiceClient = new PhekoServiceClient();
        private PatientVitalSignViewModelMapper _PatientVitalSignViewModelMapper = new PatientVitalSignViewModelMapper();

        public PatientVitalSignHandler() { }

        public List<PatientVitalSignViewModel> GetPatientVitalSigns(int patientConsultationId)
        {
            PatientVitalSignDtoResult response = _PhekoServiceClient.GetPatientVitalSigns(patientConsultationId);

            return response.Models.Select(item => _PatientVitalSignViewModelMapper.MapToPatientVitalSignViewModel(item)).ToList<PatientVitalSignViewModel>();
        }

        public void SavePatientVitalSigns(List<PatientVitalSignViewModel> patientVitalSignViewModels)
        {
            PatientVitalSignDto[] patientVitalSignDtos = patientVitalSignViewModels.Select(item => _PatientVitalSignViewModelMapper.MapToPatientVitalSignDto(item)).ToArray();
            PatientVitalSignDtoResponse response = _PhekoServiceClient.SavePatientVitalSigns(patientVitalSignDtos);

            if (response.HasErrors)
            {
                ModelException modelException = new ModelException();

                response.FieldErrors.ToList<FieldError>().ForEach(item => modelException.ModelErrors.Add(new ModelError() { FieldName = item.FieldName, Message = item.ErrorMessage }));

                throw modelException;
            }

        }

    }
}
