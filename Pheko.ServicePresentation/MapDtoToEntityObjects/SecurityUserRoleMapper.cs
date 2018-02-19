using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class SecurityUserRoleMapper
    {
        public SecurityUserRoleMapper() { }

        public SecurityUserRoleDto MapToSecurityUserRoleDto(SecurityUserRole securityUserRole)
        {
            if (securityUserRole == null)
            {
                return null;
            }

            SecurityUserRoleDto securityUserRoleDto = new SecurityUserRoleDto();

            securityUserRoleDto.SecurityUserRoleId = securityUserRole.SecurityUserRoleId;
            securityUserRoleDto.SecurityUserId = securityUserRole.SecurityUserId;
            securityUserRoleDto.SecurityRoleId = securityUserRole.SecurityRoleId;

            return securityUserRoleDto;
        }

        public void MapToSecurityUserRole(SecurityUserRole securityUserRole, SecurityUserRoleDto securityUserRoleDto)
        {
            if (securityUserRoleDto == null)
            {
                return;
            }

            securityUserRole = securityUserRole ?? new SecurityUserRole();
            
            securityUserRole.SecurityRoleId = securityUserRoleDto.SecurityRoleId;
        }
    }
}
