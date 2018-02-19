using System.Collections.Generic;
using System.Security.Principal;

namespace Pheko.WebPresentation.Library
{
    public class CustomPrincipal : IPrincipal
    {
        private IIdentity _Identity;
        private List<string> _Roles;
        private string _UserDisplayName;
        private string _UserName;
        private string _UserSugery;

        public CustomPrincipal(IIdentity ident, List<string> roles, string userName, string userDisplayName, string userSugery)
        {
            this._Identity = ident;
            this._Roles = roles;
            this._UserName = userName;
            this._UserDisplayName = userDisplayName;
            this._UserSugery = userSugery;
        }

        public IIdentity Identity
        {
            get { return _Identity; }
        }

        public string UserName
        {
            get { return _UserName; }
        }

        public string UserDisplayName
        {
            get { return _UserDisplayName; }
        }

        public string UserSugery
        {
            get { return _UserSugery; }
        }

        public bool IsInRole(string role)
        {
            return _Roles.Contains(role);
        }
    }
}
