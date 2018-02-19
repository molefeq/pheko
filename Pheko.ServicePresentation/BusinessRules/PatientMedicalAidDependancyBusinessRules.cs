using Pheko.Common.DataTransformObjects;
using Pheko.Common.Enums;
using Pheko.Common.UtilityComponent;

using Pheko.DataAccess;
using Pheko.DataAccess.Repository;

using Pheko.ServicePresentation.ServiceResponses;

using System;
using System.Linq;

namespace Pheko.ServicePresentation.BusinessRules
{
    public class PatientMedicalAidDependancyBusinessRules
    {
        public Response<PatientMedicalAidDependancyDto> SaveCheck(PatientMedicalAidDependancyDto patientMedicalAidDependancyDto)
        {
            Response<PatientMedicalAidDependancyDto> response = new Response<PatientMedicalAidDependancyDto>();

            if (patientMedicalAidDependancyDto == null)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "The entry you trying to save does not exist." });

                return response;
            }

            switch (patientMedicalAidDependancyDto.CrudOperation)
            {
                case CrudOperations.Create:
                    return CreateCheck(patientMedicalAidDependancyDto);
                case CrudOperations.Update:
                    return UpdateCheck(patientMedicalAidDependancyDto);
                case CrudOperations.Delete:
                    return DeleteCheck(patientMedicalAidDependancyDto);
                default:
                    throw new ArgumentException("Invalid crud operation.");
            }
        }

        public Response<PatientMedicalAidDependancyDto> CreateCheck(PatientMedicalAidDependancyDto patientMedicalAidDependancyDto)
        {
            Response<PatientMedicalAidDependancyDto> response = new Response<PatientMedicalAidDependancyDto>();

            if (patientMedicalAidDependancyDto == null)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "The entry you trying to create does not exist." });
                return response;
            }

            if (string.IsNullOrEmpty(patientMedicalAidDependancyDto.FirstFullName))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "FirstFullName", ErrorMessage = "First name is requeired." });
            }

            if (string.IsNullOrEmpty(patientMedicalAidDependancyDto.LastName))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "LastName", ErrorMessage = "Last name is required." });
            }

            if (string.IsNullOrEmpty(patientMedicalAidDependancyDto.MedicalAidCode))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "MedicalAidCode", ErrorMessage = "Medical Aid Code is required." });
            }

            if (string.IsNullOrEmpty(patientMedicalAidDependancyDto.Relationship))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "Relationship", ErrorMessage = "Relationship is required." });
            }

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Patient patient = unitOfWork.PatientRepository.GetByID(p => p.PatientId == patientMedicalAidDependancyDto.PatientId);

                if (patient == null)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { ErrorMessage = "There is no corresponding patient for the medical aid dependancy." });
                    return response;
                }

                if (patientMedicalAidDependancyDto.PrincipalInd && patient.PrincipalMemberInd.Value)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { FieldName = "PrincipalInd", ErrorMessage = "The patient is already a principal member." });
                }

                if (patientMedicalAidDependancyDto.PrincipalInd &&
                    unitOfWork.PatientMedicalAidDependancyRepository.GetEntities(p => p.PatientId == patientMedicalAidDependancyDto.PatientId && p.PrincipalInd).Count() > 0)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { FieldName = "PrincipalInd", ErrorMessage = "There is already the medical aid member who is a principal member." });
                }
            }

            return response;
        }

        public Response<PatientMedicalAidDependancyDto> UpdateCheck(PatientMedicalAidDependancyDto patientMedicalAidDependancyDto)
        {
            Response<PatientMedicalAidDependancyDto> response = new Response<PatientMedicalAidDependancyDto>();

            if (patientMedicalAidDependancyDto == null ||
                patientMedicalAidDependancyDto.PatientMedicalAidDependanciesId == null ||
                patientMedicalAidDependancyDto.PatientMedicalAidDependanciesId.Value == int.MinValue)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "The entry you trying to update does not exist." });
                return response;
            }

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                PatientMedicalAidDependancy patientMedicalAidDependancy = unitOfWork.PatientMedicalAidDependancyRepository.GetByID(p => p.PatientMedicalAidDependanciesId == patientMedicalAidDependancyDto.PatientMedicalAidDependanciesId.Value);

                if (patientMedicalAidDependancy == null)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { ErrorMessage = "The entry you trying to update does not exist." });
                    return response;
                }

                Patient patient = unitOfWork.PatientRepository.GetByID(p => p.PatientId == patientMedicalAidDependancyDto.PatientId);

                if (patient == null)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { ErrorMessage = "There is no corresponding patient for the medical aid dependancy." });
                    return response;
                }

                if (patientMedicalAidDependancyDto.PrincipalInd && patient.PrincipalMemberInd.Value)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { FieldName = "PrincipalInd", ErrorMessage = "The patient is already a principal member." });
                }

                if (patientMedicalAidDependancyDto.PrincipalInd &&
                    unitOfWork.PatientMedicalAidDependancyRepository.GetEntities(p => p.PatientMedicalAidDependanciesId != patientMedicalAidDependancyDto.PatientMedicalAidDependanciesId.Value &&
                                                                                      p.PatientId == patientMedicalAidDependancyDto.PatientId &&
                                                                                      p.PrincipalInd).Count() > 0)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { FieldName = "PrincipalInd", ErrorMessage = "There is already the medical aid member who is a principal member." });
                }
            }

            if (string.IsNullOrEmpty(patientMedicalAidDependancyDto.FirstFullName))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "FirstFullName", ErrorMessage = "First name is requeired." });
            }

            if (string.IsNullOrEmpty(patientMedicalAidDependancyDto.LastName))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "LastName", ErrorMessage = "Last name is required." });
            }

            if (string.IsNullOrEmpty(patientMedicalAidDependancyDto.MedicalAidCode))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "MedicalAidCode", ErrorMessage = "Medical Aid Code is required." });
            }

            if (string.IsNullOrEmpty(patientMedicalAidDependancyDto.Relationship))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "Relationship", ErrorMessage = "Relationship is required." });
            }

            return response;
        }

        public Response<PatientMedicalAidDependancyDto> DeleteCheck(PatientMedicalAidDependancyDto patientMedicalAidDependancyDto)
        {
            Response<PatientMedicalAidDependancyDto> response = new Response<PatientMedicalAidDependancyDto>();

            if (patientMedicalAidDependancyDto == null ||
                patientMedicalAidDependancyDto.PatientMedicalAidDependanciesId == null ||
                patientMedicalAidDependancyDto.PatientMedicalAidDependanciesId.Value == int.MinValue)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "The entry you trying to delete does not exist." });
                return response;
            }

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                PatientMedicalAidDependancy patientMedicalAidDependancy = unitOfWork.PatientMedicalAidDependancyRepository.GetByID(p => p.PatientMedicalAidDependanciesId == patientMedicalAidDependancyDto.PatientMedicalAidDependanciesId.Value);

                if (patientMedicalAidDependancy == null)
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
