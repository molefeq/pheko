using Pheko.Common.DataTransformObjects;
using Pheko.Common.UtilityComponent;

using Pheko.DataAccess.Repository;

using Pheko.ServicePresentation.ServiceResponses;

namespace Pheko.ServicePresentation.BusinessRules
{
    public class PatientChronicDeseaseBusinessRules
    {
        public Response<PatientChronicDeseaseDto> SaveCheck(PatientChronicDeseaseDto patientChronicDeseaseDto)
        {
            Response<PatientChronicDeseaseDto> response = new Response<PatientChronicDeseaseDto>();

            if (patientChronicDeseaseDto.PatientId == int.MinValue)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "Patient does not exist." });
                return response;
            }

            if (patientChronicDeseaseDto.ChronicDesease == null || patientChronicDeseaseDto.ChronicDesease.ChronicDeseaseId == null)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "The patient chronic desease has no chronic desease for it." });
                return response;
            }

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                if (patientChronicDeseaseDto.PatientChronicDeseaseId != null && unitOfWork.PatientChronicDeseaseRepository.GetByID(item => item.PatientChronicDeseaseId == patientChronicDeseaseDto.PatientChronicDeseaseId) == null)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { ErrorMessage = "The patient chronic desease you trying to edit does not exist." });
                    return response;
                }
            }

            return response;
        }
    }
}
