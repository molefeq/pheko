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
    public class PatientMedicalMonitoringHandler : IPatientMedicalMonitoringHandler
    {
        private PhekoServiceClient _PhekoServiceClient = new PhekoServiceClient();
        private PatientMedicalMonitoringViewModelMapper _PatientMedicalMonitoringViewModelMapper = new PatientMedicalMonitoringViewModelMapper();

        public PatientMedicalMonitoringHandler() { }

        public List<PatientMedicalMonitoringViewModel> GetPatientMedicalMonitorings(int patientConsultationId)
        {
            PatientMedicalMonitoringDtoResult response = _PhekoServiceClient.GetPatientMedicalMonitorings(patientConsultationId);

            return response.Models.Select(item => _PatientMedicalMonitoringViewModelMapper.MapToPatientMedicalMonitoringViewModel(item)).ToList<PatientMedicalMonitoringViewModel>();
        }

        public void SavePatientMedicalMonitorings(List<PatientMedicalMonitoringViewModel> patientMedicalMonitoringViewModels)
        {
            PatientMedicalMonitoringDto[] patientMedicalMonitoringDtos = patientMedicalMonitoringViewModels.Select(item => _PatientMedicalMonitoringViewModelMapper.MapToPatientMedicalMonitoringDto(item)).ToArray();
            PatientMedicalMonitoringDtoResponse response = _PhekoServiceClient.SavePatientMedicalMonitorings(patientMedicalMonitoringDtos);

            if (response.HasErrors)
            {
                ModelException modelException = new ModelException();

                response.FieldErrors.ToList<FieldError>().ForEach(item => modelException.ModelErrors.Add(new ModelError() { FieldName = item.FieldName, Message = item.ErrorMessage }));

                throw modelException;
            }

        }
    }
}
