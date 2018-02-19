using Pheko.Common.DataTransformObjects;
using Pheko.Common.UtilityComponent;

using Pheko.DataAccess.Repository;

using Pheko.ServicePresentation.ServiceResponses;

namespace Pheko.ServicePresentation.BusinessRules
{
    public class PatientVitalSignBusinessRules
    {
        public Response<PatientVitalSignDto> SaveCheck(PatientVitalSignDto patientVitalSignDto)
        {
            Response<PatientVitalSignDto> response = new Response<PatientVitalSignDto>();

            if (patientVitalSignDto.PatientConsultationId == int.MinValue)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "Patient vital sign must belong to an consultation." });
                return response;
            }

            if (patientVitalSignDto.VitalSign == null || patientVitalSignDto.VitalSign.VitalSignId == null)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "The patient vital sign has no vital sign for it." });
                return response;
            }
            
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                if (patientVitalSignDto.PatientVitalSignId != null && unitOfWork.PatientVitalSignRepository.GetByID(item => item.PatientVitalSignId == patientVitalSignDto.PatientVitalSignId) == null)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { ErrorMessage = "The patient vital sign you trying to edit does not exist." });
                    return response;
                }
            }

            return response;
        }
    }
}
