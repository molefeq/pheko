using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class PastMedicalHistoryMapper
    {
        public PastMedicalHistoryMapper() { }

        public PastMedicalHistoryDto MapToPastMedicalHistoryDto(PastMedicalHistory pastMedicalHistory)
        {
            if (pastMedicalHistory == null)
            {
                return null;
            }

            PastMedicalHistoryDto PastMedicalHistoryDto = new PastMedicalHistoryDto();

            PastMedicalHistoryDto.PastMedicalHistoryId = pastMedicalHistory.PastMedicalHistoryId;
            PastMedicalHistoryDto.Name = pastMedicalHistory.Name;
            PastMedicalHistoryDto.SortKey = pastMedicalHistory.SortKey;

            return PastMedicalHistoryDto;
        }

        public PastMedicalHistory MapToPastMedicalHistory(PastMedicalHistoryDto pastMedicalHistoryDto)
        {
            if (pastMedicalHistoryDto == null)
            {
                return null;
            }

            PastMedicalHistory pastMedicalHistory = new PastMedicalHistory();

            if (pastMedicalHistoryDto.PastMedicalHistoryId != null)
            {
                pastMedicalHistory.PastMedicalHistoryId = pastMedicalHistoryDto.PastMedicalHistoryId.Value;
            }

            pastMedicalHistory.Name = pastMedicalHistoryDto.Name;
            pastMedicalHistory.SortKey = pastMedicalHistoryDto.SortKey;

            return pastMedicalHistory;
        }
    }
}
