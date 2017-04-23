using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using System;
using Tibox.WebApi.Provider;

namespace Tibox.WebApi
{
    public partial class Startup
    {
        public void ConfigurationOAuth(IAppBuilder app)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());            
        }
    }
}