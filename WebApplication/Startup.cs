using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Data.Entity;
using WebApplication.Features.Authorization;
using WebApplication.Features.SamplePersistentConnection;

[assembly: OwinStartupAttribute(typeof(WebApplication.Startup))]
namespace WebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            ConfigureAuth(app);

            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration();
                app.MapSignalR();
                app.MapSignalR<DemoPersistentConnection>("/demo");
                app.MapSignalR<AuthorizationPersistentConnection>("/authPersistConnection");
                map.MapSignalR(hubConfiguration);
            });
           /*     
            app.MapSignalR();
            app.MapSignalR<DemoPersistentConnection>("/Connections/DemoPersistentConnection");
            app.MapSignalR<AuthorizationPersistentConnection>("/Connections/AuthorizationPersistentConnection");

            app.Map("/EnableDetailedErrors", map =>
            {
                var hubConfiguration = new HubConfiguration
                {
                    EnableDetailedErrors = true
                };

                map.MapSignalR(hubConfiguration);
            });*/
        }
    }
}
