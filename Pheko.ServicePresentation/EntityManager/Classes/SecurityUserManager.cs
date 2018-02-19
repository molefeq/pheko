using Pheko.Common.DataTransformObjects;
using Pheko.Common.Enums;
using Pheko.Common.UtilityComponent;

using Pheko.DataAccess;
using Pheko.DataAccess.Repository;

using Pheko.ServicePresentation.BusinessRules;
using Pheko.ServicePresentation.EntityManager.Interfaces;
using Pheko.ServicePresentation.MapDtoToEntityObjects;
using Pheko.ServicePresentation.ServiceResponses;

using System;
using System.Linq;
using System.Transactions;

namespace Pheko.ServicePresentation.EntityManager.Classes
{
    public class SecurityUserManager : ISecurityUserManager
    {
        private SecurityUserMapper _SecurityUserMapper = new SecurityUserMapper();
        private SecurityUserBusinessRules _SecurityUserBusinessRules = new SecurityUserBusinessRules();

        #region Interface Implementation Methods

        public Response<SecurityUserDto> Login(string username, string password)
        {
            Response<SecurityUserDto> response = _SecurityUserBusinessRules.LoginCheck(username, password);

            if (response.HasErrors) return response;

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                SecurityUser securityUser = unitOfWork.SecurityUserRepository.GetEntities(s => s.UserName.ToLower() == username.ToLower(), null, "SecurityUserRoles").FirstOrDefault<SecurityUser>();

                if (securityUser == null)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { FieldName = "UserName", ErrorMessage = "Incorrect username." });
                    return response;
                }

                byte[] hashedPassword = GeneratePassword.HashedPassword(password, securityUser.PasswordSalt);

                securityUser = unitOfWork.SecurityUserRepository.GetEntities(s => s.UserName.ToLower() == username.ToLower() && s.Password == hashedPassword, null, "SecurityUserRoles").FirstOrDefault<SecurityUser>(); ;

                if (securityUser == null)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { FieldName = "Password", ErrorMessage = "Incorrect password." });
                    return response;
                }

                response.Model = _SecurityUserMapper.MapToSecurityUserDto(securityUser);
            }

            return response;
        }

        public Response<SecurityUserDto> ResetPassword(string username)
        {
            Response<SecurityUserDto> response = _SecurityUserBusinessRules.ResetPasswordCheck(username);

            if (response.HasErrors) return response;

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                SecurityUser securityUser = unitOfWork.SecurityUserRepository.GetEntities(s => s.UserName.ToLower() == username.ToLower(), null, "SecurityUserRoles").FirstOrDefault<SecurityUser>();

                if (securityUser == null)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { FieldName = "Username", ErrorMessage = "Incorrect username." });
                    return response;
                }

                string newPassword = GeneratePassword.CreateRandomPassword();
                byte[] newhashedPassword = GeneratePassword.HashedPassword(newPassword, securityUser.PasswordSalt);

                securityUser.Password = newhashedPassword;
                securityUser.FirstTimeLogInInd = true;

                unitOfWork.SecurityUserRepository.Update(securityUser);
                unitOfWork.Save();

                response.Model = _SecurityUserMapper.MapToSecurityUserDto(securityUser);
            }

            return response;
        }

        public Response<SecurityUserDto> ChangePassword(string username, string oldPassword, string newPassword)
        {
            Response<SecurityUserDto> response = _SecurityUserBusinessRules.ChangePasswordPasswordCheck(username, oldPassword, newPassword);

            if (response.HasErrors) return response;

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                SecurityUser securityUser = unitOfWork.SecurityUserRepository.GetEntities(s => s.UserName.ToLower() == username.ToLower(), null, "SecurityUserRoles").FirstOrDefault<SecurityUser>();

                if (securityUser == null)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { FieldName = "Username", ErrorMessage = "Incorrect username." });
                    return response;
                }
                byte[] hashedPassword = GeneratePassword.HashedPassword(oldPassword, securityUser.PasswordSalt);

                securityUser = unitOfWork.SecurityUserRepository.GetEntities(s => s.UserName.ToLower() == username.ToLower() && s.Password == hashedPassword, null, "SecurityUserRoles").FirstOrDefault<SecurityUser>(); ;

                if (securityUser == null)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { FieldName = "Password", ErrorMessage = "Incorrect password." });
                    return response;
                }

                byte[] newHashedPassword = GeneratePassword.HashedPassword(newPassword, securityUser.PasswordSalt);

                securityUser.Password = newHashedPassword;
                securityUser.FirstTimeLogInInd = true;

                unitOfWork.SecurityUserRepository.Update(securityUser);
                unitOfWork.Save();

                response.Model = _SecurityUserMapper.MapToSecurityUserDto(securityUser);
            }

            return response;
        }

        public Response<SecurityUserDto> SaveUser(SecurityUserDto securityUserDto)
        {
            Response<SecurityUserDto> response = _SecurityUserBusinessRules.SaveCheck(securityUserDto);

            if (response.HasErrors) return response;

            switch (securityUserDto.CrudOperation)
            {
                case CrudOperations.Create:
                    response.Model =  Create(securityUserDto);
                    break;
                case CrudOperations.Update:
                    response.Model = Update(securityUserDto);
                    break;
                default:
                    throw new ArgumentException("Invalid crud operation.");
            }

            return response;
        }

        #endregion

        #region Private Methods

        private SecurityUserDto Create(SecurityUserDto securityUserDto)
        {
            SecurityUserDto addedSecurityUserDto = null;
            SecurityUser securityUser = new SecurityUser();

            using (TransactionScope scope = new TransactionScope())
            {
                _SecurityUserMapper.MapToSecurityUser(securityUser, securityUserDto);

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.SecurityUserRepository.Insert(securityUser);
                    unitOfWork.Save();

                    addedSecurityUserDto = _SecurityUserMapper.MapToSecurityUserDto(securityUser);
                }
            }

            return addedSecurityUserDto;
        }

        private SecurityUserDto Update(SecurityUserDto securityUserDto)
        {
            SecurityUserDto updatedSecurityUserDto = null;
            
            using (TransactionScope scope = new TransactionScope())
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    SecurityUser securityUser = unitOfWork.SecurityUserRepository.GetByID(p => p.SecurityUserId == securityUserDto.SecurityUserId);

                    securityUserDto.Password = securityUser.Password;
                    securityUserDto.PasswordSalt = securityUser.PasswordSalt;

                    _SecurityUserMapper.MapToSecurityUser(securityUser, securityUserDto);

                    unitOfWork.SecurityUserRepository.Update(securityUser);
                    unitOfWork.Save();

                    updatedSecurityUserDto = _SecurityUserMapper.MapToSecurityUserDto(unitOfWork.SecurityUserRepository.GetByID(p => p.SecurityUserId == securityUserDto.SecurityUserId));
                }

                scope.Complete();
            }

            return updatedSecurityUserDto;
        }

        #endregion

    }
}
