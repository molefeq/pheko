using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class DeseaseScreeningMapper
    {
        public DeseaseScreeningMapper() { }

        public DeseaseScreeningDto MapToDeseaseScreeningDto(DeseaseScreening deseaseScreening)
        {
            if (deseaseScreening == null)
            {
                return null;
            }

            DeseaseScreeningDto deseaseScreeningDto = new DeseaseScreeningDto();

            deseaseScreeningDto.DeseaseScreeningId = deseaseScreening.DeseaseScreeningId;
            deseaseScreeningDto.Name = deseaseScreening.Name;
            deseaseScreeningDto.SortKey = deseaseScreening.SortKey;

            return deseaseScreeningDto;
        }

        public DeseaseScreening MapToDeseaseScreening(DeseaseScreeningDto deseaseScreeningDto)
        {
            if (deseaseScreeningDto == null)
            {
                return null;
            }

            DeseaseScreening DeseaseScreening = new DeseaseScreening();

            if (deseaseScreeningDto.DeseaseScreeningId != null)
            {
                DeseaseScreening.DeseaseScreeningId = deseaseScreeningDto.DeseaseScreeningId.Value;
            }

            DeseaseScreening.Name = deseaseScreeningDto.Name;
            DeseaseScreening.SortKey = deseaseScreeningDto.SortKey;

            return DeseaseScreening;
        }
    }
}
