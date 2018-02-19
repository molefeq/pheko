using Pheko.Common.DataTransformObjects;
using Pheko.Common.Enums;
using Pheko.Common.UtilityComponent;

using Pheko.DataAccess;
using Pheko.DataAccess.Repository;

using Pheko.ServicePresentation.ServiceResponses;

using System;

namespace Pheko.ServicePresentation.BusinessRules
{
    public class PatientConsultationBusinessRules
    {
        public Response<PatientConsultationDto> SaveCheck(PatientConsultationDto patientConsultationDto)
        {
            Response<PatientConsultationDto> response = new Response<PatientConsultationDto>();

            if (patientConsultationDto == null)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "The entry you trying to save does not exist." });

                return response;
            }

            switch (patientConsultationDto.CrudOperation)
            {
                case CrudOperations.Create:
                    return CreateCheck(patientConsultationDto);
                case CrudOperations.Update:
                    return UpdateCheck(patientConsultationDto);
                case CrudOperations.Delete:
                    return DeleteCheck(patientConsultationDto);
                default:
                    throw new ArgumentException("Invalid crud operation.");
            }
        }


        public Response<PatientConsultationDto> CreateCheck(PatientConsultationDto patientConsultationDto)
        {
            Response<PatientConsultationDto> response = new Response<PatientConsultationDto>();

            if (patientConsultationDto == null)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "The entry you trying to create does not exist." });
                return response;
            }

            if (string.IsNullOrEmpty(patientConsultationDto.ConsultationStatus))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "ConsultationStatus", ErrorMessage = "Status is requeired." });
            }

            if (patientConsultationDto.StartDate == DateTime.MinValue)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "StartDate", ErrorMessage = "Start Date is required." });
            }

            if (patientConsultationDto.EndDate == DateTime.MinValue)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "EndDate", ErrorMessage = "End Date is required." });
            }

            if (response.HasErrors) return response;

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Patient patient = unitOfWork.PatientRepository.GetByID(p => p.PatientId == patientConsultationDto.PatientId);

                if (patient == null)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { ErrorMessage = "There is no corresponding patient for the consultation." });
                    return response;
                }

                Doctor doctor = unitOfWork.DoctorRepository.GetByID(p => p.DoctorId == patientConsultationDto.DoctorId);

                if (doctor == null)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { ErrorMessage = "There is no corresponding doctor for the consultation." });
                    return response;
                }
            }

            return response;
        }

        public Response<PatientConsultationDto> UpdateCheck(PatientConsultationDto patientConsultationDto)
        {
            Response<PatientConsultationDto> response = new Response<PatientConsultationDto>();

            if (patientConsultationDto == null ||
                patientConsultationDto.PatientConsultationId == null ||
                patientConsultationDto.PatientConsultationId.Value == int.MinValue)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "The entry you trying to update does not exist." });
                return response;
            }

            if (string.IsNullOrEmpty(patientConsultationDto.ConsultationStatus))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "ConsultationStatus", ErrorMessage = "Status is requeired." });
            }

            if (patientConsultationDto.StartDate == DateTime.MinValue)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "StartDate", ErrorMessage = "Start Date is required." });
            }

            if (patientConsultationDto.EndDate == DateTime.MinValue)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "EndDate", ErrorMessage = "End Date is required." });
            }

            if (response.HasErrors) return response;


            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                PatientConsultation patientConsultation = unitOfWork.PatientConsultationRepository.GetByID(p => p.PatientConsultationId == patientConsultationDto.PatientConsultationId.Value, "Patient, Doctor");

                if (patientConsultation == null)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { ErrorMessage = "The entry you trying to update does not exist." });
                    return response;
                }

                if (patientConsultation.Patient == null)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { ErrorMessage = "There is no corresponding patient for the consultation." });
                    return response;
                }

                if (patientConsultation.Doctor == null)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { ErrorMessage = "There is no corresponding doctor for the consultation." });
                    return response;
                }
            }

            return response;
        }

        public Response<PatientConsultationDto> DeleteCheck(PatientConsultationDto patientConsultationDto)
        {
            Response<PatientConsultationDto> response = new Response<PatientConsultationDto>();

            if (patientConsultationDto == null ||
                 patientConsultationDto.PatientConsultationId == null ||
                 patientConsultationDto.PatientConsultationId.Value == int.MinValue)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "The entry you trying to delete does not exist." });
                return response;
            }

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                PatientConsultation patientConsultation = unitOfWork.PatientConsultationRepository.GetByID(p => p.PatientConsultationId == patientConsultationDto.PatientConsultationId.Value, "Patient, Doctor");

                if (patientConsultation == null)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { ErrorMessage = "The entry you trying to delete does not exist." });
                    return response;
                }
            }

            return response;
        }
    }
}
