using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class PatientClinicalExaminationMapper
    {
        private ClinicalExaminationMapper _ClinicalExaminationMapper = new ClinicalExaminationMapper();

        public PatientClinicalExaminationMapper() { }

        public PatientClinicalExaminationDto MapToPatientClinicalExaminationDto(PatientClinicalExamination patientClinicalExamination)
        {
            if (patientClinicalExamination == null)
            {
                return null;
            }

            PatientClinicalExaminationDto patientClinicalExaminationDto = new PatientClinicalExaminationDto();

            patientClinicalExaminationDto.PatientClinicalExaminationId = patientClinicalExamination.PatientClinicalExaminationId;
            patientClinicalExaminationDto.PatientConsultationId = patientClinicalExamination.PatientConsultationId;
            patientClinicalExaminationDto.ClinicalExamination = _ClinicalExaminationMapper.MapToClinicalExaminationDto(patientClinicalExamination.ClinicalExamination);
            patientClinicalExaminationDto.Value = patientClinicalExamination.Value;

            return patientClinicalExaminationDto;
        }

        public void MapToPatientClinicalExamination(PatientClinicalExamination patientClinicalExamination, PatientClinicalExaminationDto patientClinicalExaminationDto)
        {
            if (patientClinicalExaminationDto == null)
            {
                return;
            }

            patientClinicalExamination.PatientConsultationId = patientClinicalExaminationDto.PatientConsultationId;

            if (patientClinicalExaminationDto.ClinicalExamination != null && patientClinicalExaminationDto.ClinicalExamination.ClinicalExaminationId != null)
            {
                patientClinicalExamination.ClinicalExaminationId = patientClinicalExaminationDto.ClinicalExamination.ClinicalExaminationId.Value;
            }

            patientClinicalExamination.Value = patientClinicalExaminationDto.Value;
        }
    }
}
