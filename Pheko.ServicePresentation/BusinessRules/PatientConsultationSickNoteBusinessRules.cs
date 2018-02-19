using Pheko.Common.DataTransformObjects;
using Pheko.Common.UtilityComponent;

using Pheko.DataAccess.Repository;

using Pheko.ServicePresentation.ServiceResponses;

namespace Pheko.ServicePresentation.BusinessRules
{
    public class PatientConsultationSickNoteBusinessRules
    {
        public Response<PatientConsultationSickNoteDto> SaveCheck(PatientConsultationSickNoteDto patientConsultationSickNoteDto)
        {
            Response<PatientConsultationSickNoteDto> response = new Response<PatientConsultationSickNoteDto>();

            if (patientConsultationSickNoteDto == null)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "The entry you trying to save does not exist." });
            }

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                if (patientConsultationSickNoteDto.PatientConsultationSickNoteId != null)
                {
                    if (unitOfWork.PatientConsultationSickNoteRepository.GetByID(item => item.PatientConsultationSickNoteId == patientConsultationSickNoteDto.PatientConsultationSickNoteId.Value) == null)
                    {
                        response.HasErrors = true;
                        response.FieldErrors.Add(new FieldError() { ErrorMessage = "The entry you trying to save does not exist." });
                    }
                }
            }

            return response;
        }
    }
}
