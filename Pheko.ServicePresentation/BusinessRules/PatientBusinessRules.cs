using Pheko.Common.DataTransformObjects;
using Pheko.Common.UtilityComponent;
using Pheko.DataAccess;
using Pheko.DataAccess.Repository;
using Pheko.ServicePresentation.ServiceResponses;

using System.Linq;

namespace Pheko.ServicePresentation.BusinessRules
{
    public class PatientBusinessRules
    {
        public PatientDetailResponse SaveCheck(PatientDto patient)
        {
            PatientDetailResponse response = new PatientDetailResponse();

            if (patient == null)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "The entry you trying to save does not exist." });
            }

            return response;
        }

        public PatientDetailResponse CreateCheck(PatientDto patient)
        {
            PatientDetailResponse response = new PatientDetailResponse();

            if (patient == null)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "The entry you trying to create does not exist." });
                return response;
            }

            if (string.IsNullOrEmpty(patient.FirstName))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "FirstName", ErrorMessage = "First name is requeired when you create a patient." });
            }

            if (string.IsNullOrEmpty(patient.LastName))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "LastName", ErrorMessage = "Last name is required when you create a patient." });
            }

            return response;
        }

        public PatientDetailResponse UpdateCheck(PatientDto patientDto)
        {
            PatientDetailResponse response = new PatientDetailResponse();

            if (patientDto == null ||
                patientDto.PatientId == null ||
                patientDto.PatientId.Value == int.MinValue)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "The entry you trying to update does not exist." });
                return response;
            }

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Patient patient = unitOfWork.PatientRepository.GetByID(p => p.PatientId == patientDto.PatientId.Value);

                if (patient == null)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { ErrorMessage = "The patient entry you trying to update does not exist." });
                    return response;
                }

                if (patientDto.PrincipalMemberInd != null && patientDto.PrincipalMemberInd.Value && patient.PatientMedicalAidDependancies.Where(item => item.PrincipalInd).Count() > 0)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { FieldName = "PrincipalInd", ErrorMessage = "There is already the medical aid principal member." });
                }
            }

            if (string.IsNullOrEmpty(patientDto.FirstName))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "FirstName", ErrorMessage = "First name is requeired when you create a patient." });
            }

            if (string.IsNullOrEmpty(patientDto.LastName))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "LastName", ErrorMessage = "Last name is required when you create a patient." });
            }

            return response;
        }

    }
}
