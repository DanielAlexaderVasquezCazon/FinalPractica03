using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(admPracticaFinal7.Startup))]
namespace admPracticaFinal7
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
