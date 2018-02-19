using Pheko.Common.DataTransformObjects;
using Pheko.Common.UtilityComponent;

using Pheko.WebPresentation.MappingViewModelsToDtos;
using Pheko.WebPresentation.PhekoService;
using Pheko.WebPresentation.ServiceHandlers.Interfaces;
using Pheko.WebPresentation.Utility;
using Pheko.WebPresentation.ViewModels;

using System.Linq;

namespace Pheko.WebPresentation.ServiceHandlers.Classes
{
    public class PatientConsultationSickNoteHandler : IPatientConsultationSickNoteHandler
    {
        private PhekoServiceClient _PhekoServiceClient = new PhekoServiceClient();
        private PatientConsultationSickNoteViewModelMapper _PatientConsultationSickNoteViewModelMapper = new PatientConsultationSickNoteViewModelMapper();

        public PatientConsultationSickNoteViewModel GetPatientConsultationSickNote(int patientConsultationId, int patientId)
        {
            PatientConsultationSickNoteDto response = _PhekoServiceClient.GetPatientConsultationSickNote(patientConsultationId);

            return response == null ? new PatientConsultationSickNoteViewModel() { PatientId = patientId, PatientConsultationId = patientConsultationId } : _PatientConsultationSickNoteViewModelMapper.MapToPatientConsultationSickNoteViewModel(_PhekoServiceClient.GetPatientConsultationSickNote(patientConsultationId));
        }

        public PatientConsultationSickNoteViewModel SavePatientConsultationSickNote(PatientConsultationSickNoteViewModel patientConsultationSickNoteViewModel)
        {
            PatientConsultationSickNoteDtoResponse response = _PhekoServiceClient.SavePatientConsultationSickNote(_PatientConsultationSickNoteViewModelMapper.MapToPatientConsultationSickNoteDto(patientConsultationSickNoteViewModel));

            if (response.HasErrors)
            {
                ModelException modelException = new ModelException();

                response.FieldErrors.ToList<FieldError>().ForEach(item => modelException.ModelErrors.Add(new ModelError() { FieldName = item.FieldName, Message = item.ErrorMessage }));

                throw modelException;
            }

            return _PatientConsultationSickNoteViewModelMapper.MapToPatientConsultationSickNoteViewModel(response.Model);
        }
    }
}
