using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class PatientMedicalNoteMapper
    {
        private MedicalNoteMapper _MedicalNoteMapper = new MedicalNoteMapper();

        public PatientMedicalNoteMapper() { }

        public PatientMedicalNoteDto MapToPatientMedicalNoteDto(PatientMedicalNote patientMedicalNote)
        {
            if (patientMedicalNote == null)
            {
                return null;
            }

            PatientMedicalNoteDto patientMedicalNoteDto = new PatientMedicalNoteDto();

            patientMedicalNoteDto.PatientMedicalNoteId = patientMedicalNote.PatientMedicalNoteId;
            patientMedicalNoteDto.PatientConsultationId = patientMedicalNote.PatientConsultationId;
            patientMedicalNoteDto.MedicalNote = _MedicalNoteMapper.MapToMedicalNoteDto(patientMedicalNote.MedicalNote);
            patientMedicalNoteDto.Value = patientMedicalNote.Value;

            return patientMedicalNoteDto;
        }

        public void MapToPatientMedicalNote(PatientMedicalNote patientMedicalNote, PatientMedicalNoteDto patientMedicalNoteDto)
        {
            if (patientMedicalNoteDto == null)
            {
                return;
            }

            patientMedicalNote.PatientConsultationId = patientMedicalNoteDto.PatientConsultationId;

            if (patientMedicalNoteDto.MedicalNote != null && patientMedicalNoteDto.MedicalNote.MedicalNoteId != null)
            {
                patientMedicalNote.MedicalNoteId = patientMedicalNoteDto.MedicalNote.MedicalNoteId.Value;
            }

            patientMedicalNote.Value = patientMedicalNoteDto.Value;
        }
    }
}
