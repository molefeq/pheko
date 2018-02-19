using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;

using System.Collections.Generic;
using System.Linq;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class SecurityUserMapper
    {
        public SecurityUserMapper() { }

        public SecurityUserDto MapToSecurityUserDto(SecurityUser securityUser)
        {
            if (securityUser == null)
            {
                return null;
            }

            SecurityUserDto securityUserDto = new SecurityUserDto();

            SecurityUserRoleMapper securityUserRoleMapper = new SecurityUserRoleMapper();

            securityUserDto.SecurityUserId = securityUser.SecurityUserId;
            securityUserDto.UserName = securityUser.UserName;
            securityUserDto.Title = securityUser.Title;
            securityUserDto.FirstName = securityUser.FirstName;
            securityUserDto.LastName = securityUser.LastName;
            securityUserDto.Initials = securityUser.Initials;
            securityUserDto.IDNumber = securityUser.IDNumber;
            securityUserDto.BirthDate = securityUser.BirthDate;
            securityUserDto.Gender = securityUser.Gender;
            securityUserDto.WorkTelephoneCode = securityUser.WorkTelephoneCode;
            securityUserDto.WorkTelephoneNumber = securityUser.WorkTelephoneNumber;
            securityUserDto.FaxCode = securityUser.FaxCode;
            securityUserDto.FaxNumber = securityUser.FaxNumber;
            securityUserDto.MobileNumber = securityUser.MobileNumber;
            securityUserDto.EmailAddress = securityUser.EmailAddress;
            securityUserDto.EmployeeNumber = securityUser.EmployeeNumber;
            securityUserDto.DisabledDate = securityUser.DisabledDate;
            securityUserDto.PasswordSalt = securityUser.PasswordSalt;
            securityUserDto.Password = securityUser.Password;
            securityUserDto.FirstTimeLogInInd = securityUser.FirstTimeLogInInd;

            if (securityUser.SecurityUserRoles != null && securityUser.SecurityUserRoles.Count > 0)
            {
                securityUserDto.SecurityUserRoles = new List<SecurityUserRoleDto>();
                securityUser.SecurityUserRoles.ToList<SecurityUserRole>().ForEach(item => securityUserDto.SecurityUserRoles.Add(securityUserRoleMapper.MapToSecurityUserRoleDto(item)));
            }

            return securityUserDto;
        }

        public void MapToSecurityUser(SecurityUser securityUser, SecurityUserDto securityUserDto)
        {
            if (securityUserDto == null)
            {
                return;
            }

            securityUser = securityUser ?? new SecurityUser();

            SecurityUserRoleMapper securityUserRoleMapper = new SecurityUserRoleMapper();

            securityUser.UserName = securityUserDto.UserName;
            securityUser.Title = securityUserDto.Title;
            securityUser.FirstName = securityUserDto.FirstName;
            securityUser.LastName = securityUserDto.LastName;
            securityUser.Initials = securityUserDto.Initials;
            securityUser.IDNumber = securityUserDto.IDNumber;
            securityUser.BirthDate = securityUserDto.BirthDate;
            securityUser.Gender = securityUserDto.Gender;
            securityUser.WorkTelephoneCode = securityUserDto.WorkTelephoneCode;
            securityUser.WorkTelephoneNumber = securityUserDto.WorkTelephoneNumber;
            securityUser.FaxCode = securityUserDto.FaxCode;
            securityUser.FaxNumber = securityUserDto.FaxNumber;
            securityUser.MobileNumber = securityUserDto.MobileNumber;
            securityUser.EmailAddress = securityUserDto.EmailAddress;
            securityUser.EmployeeNumber = securityUserDto.EmployeeNumber;
            securityUser.DisabledDate = securityUserDto.DisabledDate;
            securityUser.PasswordSalt = securityUserDto.PasswordSalt;
            securityUser.Password = securityUserDto.Password;
            securityUser.FirstTimeLogInInd = securityUserDto.FirstTimeLogInInd;

            if (securityUserDto.SecurityUserRoles != null && securityUserDto.SecurityUserRoles.Count > 0)
            {
                foreach (SecurityUserRoleDto securityUserRoleDto in securityUserDto.SecurityUserRoles)
                {
                    SecurityUserRole securityUserRole = securityUserRoleDto.SecurityUserRoleId == null ? null : securityUser.SecurityUserRoles.Where(item => item.SecurityUserRoleId == securityUserRoleDto.SecurityUserRoleId).FirstOrDefault<SecurityUserRole>();

                    if (securityUserRole == null)
                    {
                        securityUserRole = new SecurityUserRole();
                    }

                    securityUserRoleMapper.MapToSecurityUserRole(securityUserRole, securityUserRoleDto);

                    securityUser.SecurityUserRoles.Add(securityUserRole);
                }
            }

        }
    }
}
