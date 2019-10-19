using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentMaintainance.Startup))]
namespace StudentMaintainance
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
