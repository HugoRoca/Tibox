using Owin;
using System.Web.Http;
using Tibox.UnitOfWork;

namespace Tibox.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            Register(config);
            configInject(config);
            ConfigurationOAuth(app);
            app.UseWebApi(config);
        }


    }
}