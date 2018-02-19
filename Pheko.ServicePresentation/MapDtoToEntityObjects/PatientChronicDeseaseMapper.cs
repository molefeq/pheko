using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class PatientChronicDeseaseMapper
    {
        private ChronicDeseaseMapper _ChronicDeseaseMapper = new ChronicDeseaseMapper();

        public PatientChronicDeseaseMapper() { }

        public PatientChronicDeseaseDto MapToPatientChronicDeseaseDto(PatientChronicDesease patientChronicDesease)
        {
            if (patientChronicDesease == null)
            {
                return null;
            }

            PatientChronicDeseaseDto patientChronicDeseaseDto = new PatientChronicDeseaseDto();

            patientChronicDeseaseDto.PatientChronicDeseaseId = patientChronicDesease.PatientChronicDeseaseId;
            patientChronicDeseaseDto.PatientId = patientChronicDesease.PatientId;
            patientChronicDeseaseDto.ChronicDesease = _ChronicDeseaseMapper.MapToChronicDeseaseDto(patientChronicDesease.ChronicDesease);
            patientChronicDeseaseDto.Value = patientChronicDesease.Value;
            patientChronicDeseaseDto.YearOfDiagnoses = patientChronicDesease.YearOfDiagnoses;
            patientChronicDeseaseDto.SelectedInd = true;

            return patientChronicDeseaseDto;
        }

        public void MapToPatientChronicDesease(PatientChronicDesease patientChronicDesease, PatientChronicDeseaseDto patientChronicDeseaseDto)
        {
            if (patientChronicDeseaseDto == null)
            {
                return;
            }

            patientChronicDesease.PatientId = patientChronicDeseaseDto.PatientId;

            if (patientChronicDeseaseDto.ChronicDesease != null && patientChronicDeseaseDto.ChronicDesease.ChronicDeseaseId != null)
            {
                patientChronicDesease.ChronicDeseaseId = patientChronicDeseaseDto.ChronicDesease.ChronicDeseaseId.Value;
            }

            patientChronicDesease.Value = patientChronicDeseaseDto.Value;
            patientChronicDesease.YearOfDiagnoses = patientChronicDeseaseDto.YearOfDiagnoses;
        }
    }
}
