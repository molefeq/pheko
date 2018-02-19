using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class MedicalMonitoringMapper
    {
        public MedicalMonitoringMapper() { }

        public MedicalMonitoringDto MapToMedicalMonitoringDto(MedicalMonitoring MedicalMonitoring)
        {
            if (MedicalMonitoring == null)
            {
                return null;
            }

            MedicalMonitoringDto MedicalMonitoringDto = new MedicalMonitoringDto();

            MedicalMonitoringDto.MedicalMonitoringId = MedicalMonitoring.MedicalMonitoringId;
            MedicalMonitoringDto.Name = MedicalMonitoring.Name;
            MedicalMonitoringDto.SortKey = MedicalMonitoring.SortKey;

            return MedicalMonitoringDto;
        }

        public MedicalMonitoring MapToMedicalMonitoring(MedicalMonitoringDto MedicalMonitoringDto)
        {
            if (MedicalMonitoringDto == null)
            {
                return null;
            }

            MedicalMonitoring MedicalMonitoring = new MedicalMonitoring();

            if (MedicalMonitoringDto.MedicalMonitoringId != null)
            {
                MedicalMonitoring.MedicalMonitoringId = MedicalMonitoringDto.MedicalMonitoringId.Value;
            }

            MedicalMonitoring.Name = MedicalMonitoringDto.Name;
            MedicalMonitoring.SortKey = MedicalMonitoringDto.SortKey;

            return MedicalMonitoring;
        }
    }
}
