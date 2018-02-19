using Pheko.Common.UtilityComponent;

using Pheko.WebPresentation.Library;
using Pheko.WebPresentation.MappingViewModelsToDtos;
using Pheko.WebPresentation.PhekoService;
using Pheko.WebPresentation.ServiceHandlers.Interfaces;
using Pheko.WebPresentation.Utility;
using Pheko.WebPresentation.ViewModels;

using System.Linq;

namespace Pheko.WebPresentation.ServiceHandlers.Classes
{
    public class PatientConsultationHandler : IPatientConsultationHandler
    {  
        private PhekoServiceClient _PhekoServiceClient = new PhekoServiceClient();
        private PatientConsultationViewModelMapper _PatientConsultationViewModelMapper = new PatientConsultationViewModelMapper();

        public PatientConsultationHandler() { }

        public DataSourceResult Search(int patientId, string searchText)
        {
            PatientConsultationDtoResult response = _PhekoServiceClient.GetPatientConsultations(patientId, searchText);
            
            return new DataSourceResult()
            {
                Total = response.Models.Count(),
                Data = response.Models.Select(item => _PatientConsultationViewModelMapper.MapToPatientConsultationViewModel(item)).ToList<PatientConsultationViewModel>()
            };
        }

        public PatientConsultationViewModel SavePatientConsultation(PatientConsultationViewModel patientConsultationViewModel)
        {
            PatientConsultationDtoResponse response = _PhekoServiceClient.SavePatientConsultation(_PatientConsultationViewModelMapper.MapToPatientConsultationDto(patientConsultationViewModel));

            if (response.HasErrors)
            {
                ModelException modelException = new ModelException();

                response.FieldErrors.ToList<FieldError>().ForEach(item => modelException.ModelErrors.Add(new ModelError() { FieldName = item.FieldName, Message = item.ErrorMessage }));

                throw modelException;
            }

            return _PatientConsultationViewModelMapper.MapToPatientConsultationViewModel(response.Model);
        }
    }
}
