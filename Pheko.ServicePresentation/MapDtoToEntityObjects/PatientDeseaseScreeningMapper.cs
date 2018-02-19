using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class PatientDeseaseScreeningMapper
    {
        private DeseaseScreeningMapper _DeseaseScreeningMapper = new DeseaseScreeningMapper();

        public PatientDeseaseScreeningMapper() { }

        public PatientDeseaseScreeningDto MapToPatientDeseaseScreeningDto(PatientDeseaseScreening patientDeseaseScreening)
        {
            if (patientDeseaseScreening == null)
            {
                return null;
            }

            PatientDeseaseScreeningDto patientDeseaseScreeningDto = new PatientDeseaseScreeningDto();

            patientDeseaseScreeningDto.PatientDeseaseScreeningId = patientDeseaseScreening.PatientDeseaseScreeningId;
            patientDeseaseScreeningDto.PatientId = patientDeseaseScreening.PatientId;
            patientDeseaseScreeningDto.DeseaseScreening = _DeseaseScreeningMapper.MapToDeseaseScreeningDto(patientDeseaseScreening.DeseaseScreening);
            patientDeseaseScreeningDto.Value = patientDeseaseScreening.Value;
            patientDeseaseScreeningDto.YearOfScreening = patientDeseaseScreening.YearOfScreening;
            patientDeseaseScreeningDto.SelectedInd = true;

            return patientDeseaseScreeningDto;
        }

        public void MapToPatientDeseaseScreening(PatientDeseaseScreening patientDeseaseScreening, PatientDeseaseScreeningDto patientDeseaseScreeningDto)
        {
            if (patientDeseaseScreeningDto == null)
            {
                return;
            }

            patientDeseaseScreening.PatientId = patientDeseaseScreeningDto.PatientId;

            if (patientDeseaseScreeningDto.DeseaseScreening != null && patientDeseaseScreeningDto.DeseaseScreening.DeseaseScreeningId != null)
            {
                patientDeseaseScreening.DeseaseScreeningId = patientDeseaseScreeningDto.DeseaseScreening.DeseaseScreeningId.Value;
            }

            patientDeseaseScreening.Value = patientDeseaseScreeningDto.Value;
            patientDeseaseScreening.YearOfScreening = patientDeseaseScreeningDto.YearOfScreening;
        }
    }
}
