using Pheko.Common.DataTransformObjects;
using Pheko.Common.UtilityComponent;

using Pheko.DataAccess.Repository;

using Pheko.ServicePresentation.ServiceResponses;

namespace Pheko.ServicePresentation.BusinessRules
{
    public class PatientClinicalExaminationBusinessRules
    {
        public Response<PatientClinicalExaminationDto> SaveCheck(PatientClinicalExaminationDto patientClinicalExaminationDto)
        {
            Response<PatientClinicalExaminationDto> response = new Response<PatientClinicalExaminationDto>();

            if (patientClinicalExaminationDto.PatientConsultationId == int.MinValue)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "Patient clinical examination must belong to an consultation." });
                return response;
            }

            if (patientClinicalExaminationDto.ClinicalExamination == null || patientClinicalExaminationDto.ClinicalExamination.ClinicalExaminationId == null)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "The patient clinical examination has no clinical examination for it." });
                return response;
            }

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                if (patientClinicalExaminationDto.PatientClinicalExaminationId != null && unitOfWork.PatientClinicalExaminationRepository.GetByID(item => item.PatientClinicalExaminationId == patientClinicalExaminationDto.PatientClinicalExaminationId) == null)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { ErrorMessage = "The clinical examination you trying to edit does not exist." });
                    return response;
                }
            }

            return response;
        }
    }
}
