using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class PatientVitalSignMapper
    {
        public PatientVitalSignMapper() { }

        public PatientVitalSignDto MapToPatientVitalSignDto(PatientVitalSign patientVitalSign)
        {
            if (patientVitalSign == null)
            {
                return null;
            }

            PatientVitalSignDto patientVitalSignDto = new PatientVitalSignDto();
            VitalSignMapper vitalSignMapper = new VitalSignMapper();

            patientVitalSignDto.PatientVitalSignId = patientVitalSign.PatientVitalSignId;
            patientVitalSignDto.PatientConsultationId = patientVitalSign.PatientConsultationId;
            patientVitalSignDto.VitalSign = vitalSignMapper.MapToVitalSignDto(patientVitalSign.VitalSign);
            patientVitalSignDto.VitalSignValue = patientVitalSign.VitalSignValue;

            return patientVitalSignDto;
        }

        public void MapToPatientVitalSign(PatientVitalSignDto patientVitalSignDto, PatientVitalSign patientVitalSign)
        {
            if (patientVitalSignDto == null)
            {
                return;
            }
            
            patientVitalSign.PatientConsultationId = patientVitalSignDto.PatientConsultationId;
            patientVitalSign.PatientConsultationId = patientVitalSignDto.PatientConsultationId;

            if (patientVitalSignDto.VitalSign != null && patientVitalSignDto.VitalSign.VitalSignId != null)
            {
                patientVitalSign.VitalSignId = patientVitalSignDto.VitalSign.VitalSignId.Value;
            }

            patientVitalSign.VitalSignValue = patientVitalSignDto.VitalSignValue;
        }
    }
}
