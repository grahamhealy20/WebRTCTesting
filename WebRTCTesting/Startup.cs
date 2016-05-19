using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebRTCTesting.Startup))]
namespace WebRTCTesting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
