using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class ClinicalExaminationMapper
    {
        public ClinicalExaminationMapper() { }

        public ClinicalExaminationDto MapToClinicalExaminationDto(ClinicalExamination clinicalExamination)
        {
            if (clinicalExamination == null)
            {
                return null;
            }

            ClinicalExaminationDto clinicalExaminationDto = new ClinicalExaminationDto();

            clinicalExaminationDto.ClinicalExaminationId = clinicalExamination.ClinicalExaminationId;
            clinicalExaminationDto.Name = clinicalExamination.Name;
            clinicalExaminationDto.SortKey = clinicalExamination.SortKey;

            return clinicalExaminationDto;
        }

        public ClinicalExamination MapToClinicalExamination(ClinicalExaminationDto clinicalExaminationDto)
        {
            if (clinicalExaminationDto == null)
            {
                return null;
            }

            ClinicalExamination clinicalExamination = new ClinicalExamination();

            if (clinicalExaminationDto.ClinicalExaminationId != null)
            {
                clinicalExamination.ClinicalExaminationId = clinicalExaminationDto.ClinicalExaminationId.Value;
            }

            clinicalExamination.Name = clinicalExaminationDto.Name;
            clinicalExamination.SortKey = clinicalExaminationDto.SortKey;

            return clinicalExamination;
        }
    }
}
