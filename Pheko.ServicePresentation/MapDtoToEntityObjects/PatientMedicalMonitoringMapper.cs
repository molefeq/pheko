using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class PatientMedicalMonitoringMapper
    {
        private MedicalMonitoringMapper _MedicalMonitoringMapper = new MedicalMonitoringMapper();

        public PatientMedicalMonitoringMapper() { }

        public PatientMedicalMonitoringDto MapToPatientMedicalMonitoringDto(PatientMedicalMonitoring patientMedicalMonitoring)
        {
            if (patientMedicalMonitoring == null)
            {
                return null;
            }

            PatientMedicalMonitoringDto patientMedicalMonitoringDto = new PatientMedicalMonitoringDto();

            patientMedicalMonitoringDto.PatientMedicalMonitoringId = patientMedicalMonitoring.PatientMedicalMonitoringId;
            patientMedicalMonitoringDto.PatientConsultationId = patientMedicalMonitoring.PatientConsultationId;
            patientMedicalMonitoringDto.MedicalMonitoring = _MedicalMonitoringMapper.MapToMedicalMonitoringDto(patientMedicalMonitoring.MedicalMonitoring);
            patientMedicalMonitoringDto.Value = patientMedicalMonitoring.Value;

            return patientMedicalMonitoringDto;
        }

        public void MapToPatientMedicalMonitoring(PatientMedicalMonitoring patientMedicalMonitoring, PatientMedicalMonitoringDto patientMedicalMonitoringDto)
        {
            if (patientMedicalMonitoringDto == null)
            {
                return;
            }

            patientMedicalMonitoring.PatientConsultationId = patientMedicalMonitoringDto.PatientConsultationId;

            if (patientMedicalMonitoringDto.MedicalMonitoring != null && patientMedicalMonitoringDto.MedicalMonitoring.MedicalMonitoringId != null)
            {
                patientMedicalMonitoring.MedicalMonitoringId = patientMedicalMonitoringDto.MedicalMonitoring.MedicalMonitoringId.Value;
            }

            patientMedicalMonitoring.Value = patientMedicalMonitoringDto.Value;
        }
    }
}
