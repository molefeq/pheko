using Pheko.Common.DataTransformObjects;
using Pheko.Common.UtilityComponent;

using Pheko.DataAccess.Repository;

using Pheko.ServicePresentation.ServiceResponses;

namespace Pheko.ServicePresentation.BusinessRules
{
    public class PatientMedicalNoteBusinessRules
    {
        public Response<PatientMedicalNoteDto> SaveCheck(PatientMedicalNoteDto patientMedicalNoteDto)
        {
            Response<PatientMedicalNoteDto> response = new Response<PatientMedicalNoteDto>();

            if (patientMedicalNoteDto.PatientConsultationId == int.MinValue)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "Patient medical note must belong to an consultation." });
                return response;
            }

            if (patientMedicalNoteDto.MedicalNote == null || patientMedicalNoteDto.MedicalNote.MedicalNoteId == null)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "The patient medical note has no medical note for it." });
                return response;
            }

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                if (patientMedicalNoteDto.PatientMedicalNoteId != null && unitOfWork.PatientMedicalNoteRepository.GetByID(item => item.PatientMedicalNoteId == patientMedicalNoteDto.PatientMedicalNoteId) == null)
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
