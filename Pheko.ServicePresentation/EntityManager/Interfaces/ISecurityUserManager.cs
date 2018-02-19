using Pheko.Common.DataTransformObjects;

using Pheko.ServicePresentation.ServiceResponses;

namespace Pheko.ServicePresentation.EntityManager.Interfaces
{
    public interface ISecurityUserManager
    {
        Response<SecurityUserDto> Login(string username, string password);
        Response<SecurityUserDto> ResetPassword(string username);
        Response<SecurityUserDto> ChangePassword(string username, string oldPassword, string newPassword);
        Response<SecurityUserDto> SaveUser(SecurityUserDto securityUser);
    }
}
