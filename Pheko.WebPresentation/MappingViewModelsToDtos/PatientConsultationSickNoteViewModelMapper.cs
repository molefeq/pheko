using Pheko.Common.DataTransformObjects;
using Pheko.Common.UtilityComponent;

using Pheko.WebPresentation.ViewModels;

namespace Pheko.WebPresentation.MappingViewModelsToDtos
{
    public class PatientConsultationSickNoteViewModelMapper
    {
        public PatientConsultationSickNoteViewModelMapper() { }

        public PatientConsultationSickNoteDto MapToPatientConsultationSickNoteDto(PatientConsultationSickNoteViewModel patientConsultationSickNoteViewModel)
        {
            if (patientConsultationSickNoteViewModel == null)
            {
                return null;
            }

            PatientConsultationSickNoteDto patientConsultationSickNoteDto = new PatientConsultationSickNoteDto();

            patientConsultationSickNoteDto.PatientConsultationSickNoteId = patientConsultationSickNoteViewModel.PatientConsultationSickNoteId;
            patientConsultationSickNoteDto.PatientConsultationId = patientConsultationSickNoteViewModel.PatientConsultationId;
            patientConsultationSickNoteDto.PatientId = patientConsultationSickNoteViewModel.PatientId;
            patientConsultationSickNoteDto.SicknessReason = patientConsultationSickNoteViewModel.SicknessReason;
            patientConsultationSickNoteDto.Diagnoses = patientConsultationSickNoteViewModel.Diagnoses;
            patientConsultationSickNoteDto.StartDate = Converter.StringToDate(patientConsultationSickNoteViewModel.StartDate);
            patientConsultationSickNoteDto.EndDate = Converter.StringToDate(patientConsultationSickNoteViewModel.EndDate);

            return patientConsultationSickNoteDto;
        }

        public PatientConsultationSickNoteViewModel MapToPatientConsultationSickNoteViewModel(PatientConsultationSickNoteDto patientConsultationSickNoteDto)
        {
            if (patientConsultationSickNoteDto == null)
            {
                return null;
            }

            PatientConsultationSickNoteViewModel patientConsultationSickNoteViewModel = new PatientConsultationSickNoteViewModel();

            patientConsultationSickNoteViewModel.PatientConsultationSickNoteId = patientConsultationSickNoteDto.PatientConsultationSickNoteId;
            patientConsultationSickNoteViewModel.PatientConsultationId = patientConsultationSickNoteDto.PatientConsultationId;
            patientConsultationSickNoteViewModel.PatientId = patientConsultationSickNoteDto.PatientId;
            patientConsultationSickNoteViewModel.SicknessReason = patientConsultationSickNoteDto.SicknessReason;
            patientConsultationSickNoteViewModel.Diagnoses = patientConsultationSickNoteDto.Diagnoses;
            patientConsultationSickNoteViewModel.StartDate = Converter.DateToString(patientConsultationSickNoteDto.StartDate);
            patientConsultationSickNoteViewModel.EndDate = Converter.DateToString(patientConsultationSickNoteDto.EndDate);

            return patientConsultationSickNoteViewModel;
        }
    }
}
