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
    public class SecurityUserBusinessRules
    {
        public Response<SecurityUserDto> SaveCheck(SecurityUserDto securityUserDto)
        {
            Response<SecurityUserDto> response = new Response<SecurityUserDto>();

            if (securityUserDto == null)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "The entry you trying to save does not exist." });

                return response;
            }

            switch (securityUserDto.CrudOperation)
            {
                case CrudOperations.Create:
                    return CreateUserCheck(securityUserDto);
                case CrudOperations.Update:
                    return UpdateUserCheck(securityUserDto);
                default:
                    throw new ArgumentException("Invalid crud operation.");
            }
        }

        public Response<SecurityUserDto> LoginCheck(string username, string password)
        {
            Response<SecurityUserDto> response = new Response<SecurityUserDto>();

            if (string.IsNullOrEmpty(username))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "Username", ErrorMessage = "Username is required." });
            }

            if (string.IsNullOrEmpty(password))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "Password", ErrorMessage = "Password is required when you create a patient." });
            }

            return response;
        }

        public Response<SecurityUserDto> ResetPasswordCheck(string username)
        {
            Response<SecurityUserDto> response = new Response<SecurityUserDto>();

            if (string.IsNullOrEmpty(username))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "Username", ErrorMessage = "Username is required." });
            }

            return response;
        }

        public Response<SecurityUserDto> ChangePasswordPasswordCheck(string username, string oldPassword, string newPassword)
        {
            Response<SecurityUserDto> response = new Response<SecurityUserDto>();

            if (string.IsNullOrEmpty(username))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "Username", ErrorMessage = "Username is required." });
            }

            if (string.IsNullOrEmpty(oldPassword))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "OldPassword", ErrorMessage = "Old Password is required." });
            }

            if (string.IsNullOrEmpty(newPassword))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "NewPassword", ErrorMessage = "New Password is required." });
            }

            return response;
        }

        public Response<SecurityUserDto> CreateUserCheck(SecurityUserDto securityUserDto)
        {
            Response<SecurityUserDto> response = new Response<SecurityUserDto>();

            if (securityUserDto == null)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "The entry you trying to create does not exist." });
                return response;
            }

            if (string.IsNullOrEmpty(securityUserDto.UserName))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "Username", ErrorMessage = "Username is required." });
            }
            else
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    SecurityUser securityUser = unitOfWork.SecurityUserRepository.GetEntities(s => s.UserName.ToLower() == securityUserDto.UserName.ToLower()).FirstOrDefault<SecurityUser>();

                    if (securityUser != null)
                    {
                        response.HasErrors = true;
                        response.FieldErrors.Add(new FieldError() { FieldName = "Username", ErrorMessage = "Username is currently being used another user." });
                    }
                }
            }

            if (securityUserDto.Password == null)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "Password", ErrorMessage = "Password is required." });
            }

            if (securityUserDto.PasswordSalt == null)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "Password", ErrorMessage = "Password is required." });
            }

            if (string.IsNullOrEmpty(securityUserDto.FirstName))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "FirstName", ErrorMessage = "FirstName is required." });
            }

            if (string.IsNullOrEmpty(securityUserDto.LastName))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "LastName", ErrorMessage = "LastName is required." });
            }

            if (string.IsNullOrEmpty(securityUserDto.Initials))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "Initials", ErrorMessage = "Initials is required." });
            }

            return response;
        }

        public Response<SecurityUserDto> UpdateUserCheck(SecurityUserDto securityUserDto)
        {
            Response<SecurityUserDto> response = new Response<SecurityUserDto>();

            if (securityUserDto == null || 
                securityUserDto.SecurityUserId == null || 
                securityUserDto.SecurityUserId.Value == int.MinValue)
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { ErrorMessage = "The entry you trying to update does not exist." });
                return response;
            }
            
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                SecurityUser securityUser = unitOfWork.SecurityUserRepository.GetByID(s => s.SecurityUserId == securityUserDto.SecurityUserId.Value);

                if (securityUser == null)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { ErrorMessage = "The entry you trying to update does not exist." });
                    return response;
                }
            }

            if (string.IsNullOrEmpty(securityUserDto.UserName))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "Username", ErrorMessage = "Username is required." });
            }
            else
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    SecurityUser securityUser = unitOfWork.SecurityUserRepository.GetEntities(s => s.SecurityUserId != securityUserDto.SecurityUserId.Value && 
                                                                                                   s.UserName.ToLower() == securityUserDto.UserName.ToLower())
                                                                                  .FirstOrDefault<SecurityUser>();

                    if (securityUser != null)
                    {
                        response.HasErrors = true;
                        response.FieldErrors.Add(new FieldError() { FieldName = "Username", ErrorMessage = "Username is currently being used another user." });
                    }
                }
            }
            
            if (string.IsNullOrEmpty(securityUserDto.FirstName))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "FirstName", ErrorMessage = "FirstName is required." });
            }

            if (string.IsNullOrEmpty(securityUserDto.LastName))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "LastName", ErrorMessage = "LastName is required." });
            }

            if (string.IsNullOrEmpty(securityUserDto.Initials))
            {
                response.HasErrors = true;
                response.FieldErrors.Add(new FieldError() { FieldName = "Initials", ErrorMessage = "Initials is required." });
            }

            return response;
        }

    }
}
