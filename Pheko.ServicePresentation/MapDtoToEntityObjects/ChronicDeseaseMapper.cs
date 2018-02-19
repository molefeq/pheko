using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class ChronicDeseaseMapper
    {
        public ChronicDeseaseMapper() { }

        public ChronicDeseaseDto MapToChronicDeseaseDto(ChronicDesease chronicDesease)
        {
            if (chronicDesease == null)
            {
                return null;
            }

            ChronicDeseaseDto chronicDeseaseDto = new ChronicDeseaseDto();

            chronicDeseaseDto.ChronicDeseaseId = chronicDesease.ChronicDeseaseId;
            chronicDeseaseDto.Name = chronicDesease.Name;
            chronicDeseaseDto.SortKey = chronicDesease.SortKey;

            return chronicDeseaseDto;
        }

        public ChronicDesease MapToChronicDesease(ChronicDeseaseDto chronicDeseaseDto)
        {
            if (chronicDeseaseDto == null)
            {
                return null;
            }

            ChronicDesease chronicDesease = new ChronicDesease();

            if (chronicDeseaseDto.ChronicDeseaseId != null)
            {
                chronicDesease.ChronicDeseaseId = chronicDeseaseDto.ChronicDeseaseId.Value;
            }

            chronicDesease.Name = chronicDeseaseDto.Name;
            chronicDesease.SortKey = chronicDeseaseDto.SortKey;

            return chronicDesease;
        }
    }
}
