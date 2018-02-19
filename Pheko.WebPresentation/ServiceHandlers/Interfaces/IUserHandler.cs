using Pheko.WebPresentation.ViewModels;

namespace Pheko.WebPresentation.ServiceHandlers.Interfaces
{
    public interface IUserHandler
    {
        SecurityUserViewModel Login(string username, string password);
    }
}
