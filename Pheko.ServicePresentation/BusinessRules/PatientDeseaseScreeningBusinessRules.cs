using Pheko.Common.DataTransformObjects;
using Pheko.Common.UtilityComponent;

using Pheko.DataAccess.Repository;

using Pheko.ServicePresentation.ServiceResponses;

namespace Pheko.ServicePresentation.BusinessRules
{
    public class PatientDeseaseScreeningBusinessRules
    {
        public Response<PatientDeseaseScreeningDto> SaveCheck(PatientDeseaseScreeningDto patientDeseaseScreeningDto)
        {
            Response<PatientDeseaseScreeningDto> response = new Response<PatientDeseaseScreeningDto>();

            if (patientDeseaseScreeningDto.PatientId == int.MinValue)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "Patient does not exist." });
                return response;
            }

            if (patientDeseaseScreeningDto.DeseaseScreening == null || patientDeseaseScreeningDto.DeseaseScreening.DeseaseScreeningId == null)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "The patient desease screening has no desease screening for it." });
                return response;
            }

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                if (patientDeseaseScreeningDto.PatientDeseaseScreeningId != null && unitOfWork.PatientDeseaseScreeningRepository.GetByID(item => item.PatientDeseaseScreeningId == patientDeseaseScreeningDto.PatientDeseaseScreeningId) == null)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { ErrorMessage = "The patient desease screening you trying to edit does not exist." });
                    return response;
                }
            }

            return response;
        }
    }
}
