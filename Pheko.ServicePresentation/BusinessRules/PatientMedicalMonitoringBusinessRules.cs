using Pheko.Common.DataTransformObjects;
using Pheko.Common.UtilityComponent;

using Pheko.DataAccess.Repository;

using Pheko.ServicePresentation.ServiceResponses;

namespace Pheko.ServicePresentation.BusinessRules
{
    public class PatientMedicalMonitoringBusinessRules
    {
        public Response<PatientMedicalMonitoringDto> SaveCheck(PatientMedicalMonitoringDto patientMedicalMonitoringDto)
        {
            Response<PatientMedicalMonitoringDto> response = new Response<PatientMedicalMonitoringDto>();

            if (patientMedicalMonitoringDto.PatientConsultationId == int.MinValue)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "Patient medical note must belong to an consultation." });
                return response;
            }

            if (patientMedicalMonitoringDto.MedicalMonitoring == null || patientMedicalMonitoringDto.MedicalMonitoring.MedicalMonitoringId == null)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "The patient medical note has no medical note for it." });
                return response;
            }

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                if (patientMedicalMonitoringDto.PatientMedicalMonitoringId != null && unitOfWork.PatientMedicalMonitoringRepository.GetByID(item => item.PatientMedicalMonitoringId == patientMedicalMonitoringDto.PatientMedicalMonitoringId) == null)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { ErrorMessage = "The medical note you trying to edit does not exist." });
                    return response;
                }
            }

            return response;
        }
    }
}
