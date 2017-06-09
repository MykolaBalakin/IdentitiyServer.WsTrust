using Owin;

namespace IdentityServer3.WsTrust
{
    public static class AppBuilderExtensions
    {
        public static IAppBuilder UseWsTrustPlugin(this IAppBuilder app)
        {
            app.Map("/wstrust", a =>
            {
                a.UseWebApi(WebApiConfig.Configure());
            });
            return app;
        }
    }
}