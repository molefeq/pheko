using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class PatientConsultationSickNoteMapper
    {
        public PatientConsultationSickNoteMapper() { }

        public PatientConsultationSickNoteDto MapToPatientConsultationSickNoteDto(PatientConsultationSickNote patientConsultationSickNote)
        {
            if (patientConsultationSickNote == null)
            {
                return null;
            }

            PatientConsultationSickNoteDto patientConsultationSickNoteDto = new PatientConsultationSickNoteDto();

            patientConsultationSickNoteDto.PatientConsultationSickNoteId = patientConsultationSickNote.PatientConsultationSickNoteId;
            patientConsultationSickNoteDto.PatientConsultationId = patientConsultationSickNote.PatientConsultationId;
            patientConsultationSickNoteDto.PatientId = patientConsultationSickNote.PatientId;
            patientConsultationSickNoteDto.SicknessReason = patientConsultationSickNote.SicknessReason;
            patientConsultationSickNoteDto.Diagnoses = patientConsultationSickNote.Diagnoses;
            patientConsultationSickNoteDto.StartDate = patientConsultationSickNote.StartDate;
            patientConsultationSickNoteDto.EndDate = patientConsultationSickNote.EndDate;

            return patientConsultationSickNoteDto;
        }

        public void MapToPatientConsultationSickNote(PatientConsultationSickNote patientConsultationSickNote, PatientConsultationSickNoteDto patientConsultationSickNoteDto)
        {
            if (patientConsultationSickNoteDto == null)
            {
                return;
            }

            patientConsultationSickNote.PatientConsultationId = patientConsultationSickNoteDto.PatientConsultationId;
            patientConsultationSickNote.PatientId = patientConsultationSickNoteDto.PatientId;
            patientConsultationSickNote.SicknessReason = patientConsultationSickNoteDto.SicknessReason;
            patientConsultationSickNote.Diagnoses = patientConsultationSickNoteDto.Diagnoses;
            patientConsultationSickNote.StartDate = patientConsultationSickNoteDto.StartDate;
            patientConsultationSickNote.EndDate = patientConsultationSickNoteDto.EndDate;
        }
    }
}
