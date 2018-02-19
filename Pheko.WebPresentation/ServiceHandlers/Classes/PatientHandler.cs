using Pheko.Common.UtilityComponent;

using Pheko.WebPresentation.Library;
using Pheko.WebPresentation.MappingViewModelsToDtos;
using Pheko.WebPresentation.PhekoService;
using Pheko.WebPresentation.ServiceHandlers.Interfaces;
using Pheko.WebPresentation.Utility;
using Pheko.WebPresentation.ViewModels;

using System.Collections.Generic;
using System.Linq;

namespace Pheko.WebPresentation.ServiceHandlers.Classes
{
    public class PatientHandler : IPatientHandler
    {
        private PhekoServiceClient _PhekoServiceClient = new PhekoServiceClient();
        private PatientViewModelMapper _PatientViewModelMapper = new PatientViewModelMapper();
        private PatientMedicalAidDependancyViewModelMapper _PatientMedicalAidDependancyViewModelMapper = new PatientMedicalAidDependancyViewModelMapper();

        public PatientHandler() { }

        public PatientViewModel GetPatientDetails(int patientId, List<PatientMedicalAidDependancyViewModel> patientMedicalAidDepandancies)
        {
            PatientDetailResponse response = _PhekoServiceClient.GetPatientDetails(patientId);
            ServiceResponse<PatientViewModel> serviceResponse = new ServiceResponse<PatientViewModel>();

            serviceResponse.IsModelValid = response.HasErrors;

            if (response.HasErrors)
            {
                ModelException modelException = new ModelException();

                response.FieldErrors.ToList<FieldError>().ForEach(item => modelException.ModelErrors.Add(new ModelError() { FieldName = item.FieldName, Message = item.ErrorMessage }));

                throw modelException;
            }

            PatientViewModel model = _PatientViewModelMapper.MapToPatientViewModel(response.Patient);

            if (response.PatientMedicalAidDependancies != null && response.PatientMedicalAidDependancies.Count() > 0)
            {
                response.PatientMedicalAidDependancies.ToList().ForEach(item => patientMedicalAidDepandancies.Add(_PatientMedicalAidDependancyViewModelMapper.MapToPatientMedicalAidDependancyViewModel(item)));
            }

            return model;
        }

        public DataSourceResult Search(SearchPatientViewModel searchPatientViewModel)
        {
            PatientDtoResult response = _PhekoServiceClient.Search(_PatientViewModelMapper.MapSearchPatientViewModelToPatientDto(searchPatientViewModel));

            //if (response.)
            //{
            //    ModelException modelException = new ModelException();

            //    response.FieldErrors.ToList<FieldError>().ForEach(item => modelException.ModelErrors.Add(new ModelError() { FieldName = item.FieldName, Message = item.ErrorMessage }));

            //    throw modelException;
            //}

            return new DataSourceResult()
            {
                Total = response.Models.Count(),
                Data = response.Models.Select(item => _PatientViewModelMapper.MapToPatientViewModel(item)).ToList<PatientViewModel>()
            };
        }

        public PatientViewModel SavePatient(PatientViewModel patientViewModel)
        {
            PatientDetailResponse response = _PhekoServiceClient.SavePatient(_PatientViewModelMapper.MapToPatientDto(patientViewModel));

            if (response.HasErrors)
            {
                ModelException modelException = new ModelException();

                response.FieldErrors.ToList<FieldError>().ForEach(item => modelException.ModelErrors.Add(new ModelError() { FieldName = item.FieldName, Message = item.ErrorMessage }));

                throw modelException;
            }

            return _PatientViewModelMapper.MapToPatientViewModel(response.Patient);
        }

        public PatientViewModel CreatePatient(CreatePatientViewModel createPatientViewModel)
        {
            PatientDetailResponse response = _PhekoServiceClient.SavePatient(_PatientViewModelMapper.MapCreatePatientViewModelToPatientDto(createPatientViewModel));

            if (response.HasErrors)
            {
                ModelException modelException = new ModelException();

                response.FieldErrors.ToList<FieldError>().ForEach(item => modelException.ModelErrors.Add(new ModelError() { FieldName = item.FieldName, Message = item.ErrorMessage }));

                throw modelException;
            }

            return _PatientViewModelMapper.MapToPatientViewModel(response.Patient);
        }

    }
}
