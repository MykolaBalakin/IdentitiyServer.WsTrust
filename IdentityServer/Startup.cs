using System.Collections.Generic;
using System.Linq;
using IdentityServer.MockData;
using IdentityServer3.Core.Configuration;
using IdentityServer3.WsFederation.Configuration;
using IdentityServer3.WsFederation.Models;
using IdentityServer3.WsFederation.Services;
using IdentityServer3.WsTrust;
using Owin;
using Serilog;

namespace IdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.ColoredConsole(outputTemplate: "{Timestamp} [{Level}] ({Name}){NewLine} {Message}{NewLine}{Exception}")
                .CreateLogger();

            var factory = new IdentityServerServiceFactory()
                .UseInMemoryUsers(Users.Get().ToList())
                .UseInMemoryClients(Clients.Get())
                .UseInMemoryScopes(Scopes.Get());

            var options = new IdentityServerOptions
            {
                SiteName = "IdentityServer3 - WsFed",

                SigningCertificate = Certificate.Get(),
                Factory = factory,
                PluginConfiguration = ConfigurePlugins,
            };

            appBuilder.UseIdentityServer(options);
        }

        private void ConfigurePlugins(IAppBuilder pluginApp, IdentityServerOptions options)
        {
            ConfigureWsFederation(pluginApp, options);
            ConfigureWsTrust(pluginApp, options);
        }

        private void ConfigureWsFederation(IAppBuilder pluginApp, IdentityServerOptions options)
        {
            var wsFedOptions = new WsFederationPluginOptions(options);

            // data sources for in-memory services
            wsFedOptions.Factory.Register(new Registration<IEnumerable<RelyingParty>>(RelyingParties.Get()));
            wsFedOptions.Factory.RelyingPartyService = new Registration<IRelyingPartyService>(typeof(InMemoryRelyingPartyService));

            pluginApp.UseWsFederationPlugin(wsFedOptions);
        }

        private void ConfigureWsTrust(IAppBuilder pluginApp, IdentityServerOptions options)
        {
            pluginApp.UseWsTrustPlugin();
        }
    }
}