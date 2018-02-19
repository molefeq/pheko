using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class VitalSignMapper
    {
        public VitalSignMapper() { }

        public VitalSignDto MapToVitalSignDto(VitalSign vitalSign)
        {
            if (vitalSign == null)
            {
                return null;
            }

            VitalSignDto vitalSignDto = new VitalSignDto();

            vitalSignDto.VitalSignId = vitalSign.VitalSignId;
            vitalSignDto.Name = vitalSign.Name;
            vitalSignDto.SortKey = vitalSign.SortKey;

            return vitalSignDto;
        }

        public VitalSign MapToVitalSign(VitalSignDto vitalSignDto)
        {
            if (vitalSignDto == null)
            {
                return null;
            }

            VitalSign vitalSign = new VitalSign();

            if (vitalSignDto.VitalSignId != null)
            {
                vitalSign.VitalSignId = vitalSignDto.VitalSignId.Value;
            }

            vitalSign.Name = vitalSignDto.Name;
            vitalSign.SortKey = vitalSignDto.SortKey;

            return vitalSign;
        }
    }
}
