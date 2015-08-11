using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BelingualAcademy.Startup))]
namespace BelingualAcademy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
