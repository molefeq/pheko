using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class PatientPastMedicalHistoryMapper
    {
        private PastMedicalHistoryMapper _PastMedicalHistoryMapper = new PastMedicalHistoryMapper();

        public PatientPastMedicalHistoryMapper() { }

        public PatientPastMedicalHistoryDto MapToPatientPastMedicalHistoryDto(PatientPastMedicalHistory patientPastMedicalHistory)
        {
            if (patientPastMedicalHistory == null)
            {
                return null;
            }

            PatientPastMedicalHistoryDto patientPastMedicalHistoryDto = new PatientPastMedicalHistoryDto();

            patientPastMedicalHistoryDto.PatientPastMedicalHistoryId = patientPastMedicalHistory.PatientPastMedicalHistoryId;
            patientPastMedicalHistoryDto.PatientId = patientPastMedicalHistory.PatientId;
            patientPastMedicalHistoryDto.PastMedicalHistory = _PastMedicalHistoryMapper.MapToPastMedicalHistoryDto(patientPastMedicalHistory.PastMedicalHistory);
            patientPastMedicalHistoryDto.Value = patientPastMedicalHistory.Value;

            return patientPastMedicalHistoryDto;
        }

        public void MapToPatientPastMedicalHistory(PatientPastMedicalHistory patientPastMedicalHistory, PatientPastMedicalHistoryDto patientPastMedicalHistoryDto)
        {
            if (patientPastMedicalHistoryDto == null)
            {
                return;
            }

            patientPastMedicalHistory.PatientId = patientPastMedicalHistoryDto.PatientId;

            if (patientPastMedicalHistoryDto.PastMedicalHistory != null && patientPastMedicalHistoryDto.PastMedicalHistory.PastMedicalHistoryId != null)
            {
                patientPastMedicalHistory.PastMedicalHistoryId = patientPastMedicalHistoryDto.PastMedicalHistory.PastMedicalHistoryId.Value;
            }

            patientPastMedicalHistory.Value = patientPastMedicalHistoryDto.Value;
        }
    }
}
