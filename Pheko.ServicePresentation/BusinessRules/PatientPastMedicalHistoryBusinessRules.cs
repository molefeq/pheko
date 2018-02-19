using Pheko.Common.DataTransformObjects;
using Pheko.Common.UtilityComponent;

using Pheko.DataAccess.Repository;

using Pheko.ServicePresentation.ServiceResponses;

namespace Pheko.ServicePresentation.BusinessRules
{
    public class PatientPastMedicalHistoryBusinessRules
    {
        public Response<PatientPastMedicalHistoryDto> SaveCheck(PatientPastMedicalHistoryDto patientPastMedicalHistoryDto)
        {
            Response<PatientPastMedicalHistoryDto> response = new Response<PatientPastMedicalHistoryDto>();

            if (patientPastMedicalHistoryDto.PatientId == int.MinValue)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "Patient does not exists." });
                return response;
            }

            if (patientPastMedicalHistoryDto.PastMedicalHistory == null || patientPastMedicalHistoryDto.PastMedicalHistory.PastMedicalHistoryId == null)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "The patient past medical history has no past medical history for it." });
                return response;
            }

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                if (patientPastMedicalHistoryDto.PatientPastMedicalHistoryId != null && unitOfWork.PatientPastMedicalHistoryRepository.GetByID(item => item.PatientPastMedicalHistoryId == patientPastMedicalHistoryDto.PatientPastMedicalHistoryId) == null)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { ErrorMessage = "The patient past medical history you trying to edit does not exist." });
                    return response;
                }
            }

            return response;
        }
    }
}
