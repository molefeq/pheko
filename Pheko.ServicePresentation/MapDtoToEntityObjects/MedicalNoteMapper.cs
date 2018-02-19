using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class MedicalNoteMapper
    {
        public MedicalNoteMapper() { }

        public MedicalNoteDto MapToMedicalNoteDto(MedicalNote medicalNote)
        {
            if (medicalNote == null)
            {
                return null;
            }

            MedicalNoteDto medicalNoteDto = new MedicalNoteDto();

            medicalNoteDto.MedicalNoteId = medicalNote.MedicalNoteId;
            medicalNoteDto.Name = medicalNote.Name;
            medicalNoteDto.SortKey = medicalNote.SortKey;

            return medicalNoteDto;
        }

        public MedicalNote MapToMedicalNote(MedicalNoteDto medicalNoteDto)
        {
            if (medicalNoteDto == null)
            {
                return null;
            }

            MedicalNote medicalNote = new MedicalNote();

            if (medicalNoteDto.MedicalNoteId != null)
            {
                medicalNote.MedicalNoteId = medicalNoteDto.MedicalNoteId.Value;
            }

            medicalNote.Name = medicalNoteDto.Name;
            medicalNote.SortKey = medicalNoteDto.SortKey;

            return medicalNote;
        }
    }
}
