using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetrolPumpSystem.Startup))]
namespace PetrolPumpSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
