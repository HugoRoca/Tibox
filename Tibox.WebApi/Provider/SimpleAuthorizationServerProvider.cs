using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using Tibox.UnitOfWork;

namespace Tibox.WebApi.Provider
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUnitOfWork _unit;

        public SimpleAuthorizationServerProvider()
        {
            _unit = new TiboxUnitOfWork();
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user = _unit.Users.ValidateUser(context.UserName, context.Password);
            if(user == null)
            {
                context.SetError("invalid_grant","usuario o password incorrecto");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", user.Roles));

            context.Validated(identity);
        }
    }
}