using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class ProvinceMapper
    {
        public ProvinceMapper() { }

        public ProvinceDto MapToProvinceDto(Province province)
        {
            if (province == null)
            {
                return null;
            }

            ProvinceDto provinceDto = new ProvinceDto();

            provinceDto.ProvinceId = province.ProvinceId;
            provinceDto.ProvinceName = province.ProvinceName;

            return provinceDto;
        }

        public Province MapToProvince(ProvinceDto provinceDto)
        {
            if (provinceDto == null)
            {
                return null;
            }

            Province province = new Province();

            if (provinceDto.ProvinceId != null)
            {
                province.ProvinceId = provinceDto.ProvinceId.Value;
            }

            province.ProvinceName = provinceDto.ProvinceName;

            return province;
        }
          
    }
}
