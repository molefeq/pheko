using Pheko.Common.UtilityComponent;

using Pheko.WebPresentation.MappingViewModelsToDtos;
using Pheko.WebPresentation.PhekoService;
using Pheko.WebPresentation.ServiceHandlers.Interfaces;
using Pheko.WebPresentation.Utility;
using Pheko.WebPresentation.ViewModels;

using System.Linq;

namespace Pheko.WebPresentation.ServiceHandlers.Classes
{
    public class UserHandler : IUserHandler
    {
        private PhekoServiceClient _PhekoServiceClient = new PhekoServiceClient();
        private SecurityUserViewModelMapper _SecurityUserViewModelMapper = new SecurityUserViewModelMapper();

        public UserHandler() { }

        public SecurityUserViewModel Login(string username, string password)
        {
            SecurityUserDtoResponse response = _PhekoServiceClient.Login(username, password);

            if (response.HasErrors)
            {
                ModelException modelException = new ModelException();

                response.FieldErrors.ToList<FieldError>().ForEach(item => modelException.ModelErrors.Add(new ModelError() { FieldName = item.FieldName, Message = item.ErrorMessage }));

                throw modelException;
            }

            return _SecurityUserViewModelMapper.MapToPatientAddressViewModel(response.Model);
        }
    }
}
