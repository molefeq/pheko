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
    public class PatientClinicalExaminationHandler : IPatientClinicalExaminationHandler
    {
        private PhekoServiceClient _PhekoServiceClient = new PhekoServiceClient();
        private PatientClinicalExaminationViewModelMapper _PatientClinicalExaminationViewModelMapper = new PatientClinicalExaminationViewModelMapper();

        public PatientClinicalExaminationHandler() { }

        public List<PatientClinicalExaminationViewModel> GetPatientClinicalExaminations(int patientConsultationId)
        {
            PatientClinicalExaminationDtoResult response = _PhekoServiceClient.GetPatientClinicalExaminations(patientConsultationId);

            return response.Models.Select(item => _PatientClinicalExaminationViewModelMapper.MapToPatientClinicalExaminationViewModel(item)).ToList<PatientClinicalExaminationViewModel>();
        }

        public void SavePatientClinicalExaminations(List<PatientClinicalExaminationViewModel> patientClinicalExaminationViewModels)
        {
            PatientClinicalExaminationDto[] patientClinicalExaminationDtos = patientClinicalExaminationViewModels.Select(item => _PatientClinicalExaminationViewModelMapper.MapToPatientClinicalExaminationDto(item)).ToArray();
            PatientClinicalExaminationDtoResponse response = _PhekoServiceClient.SavePatientClinicalExaminations(patientClinicalExaminationDtos);

            if (response.HasErrors)
            {
                ModelException modelException = new ModelException();

                response.FieldErrors.ToList<FieldError>().ForEach(item => modelException.ModelErrors.Add(new ModelError() { FieldName = item.FieldName, Message = item.ErrorMessage }));

                throw modelException;
            }

        }
    }
}
