using System.Web.Http;

namespace IdentityServer3.WsTrust
{
    public class WebApiConfig
    {
        public static HttpConfiguration Configure()
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            return config;
        }
    }
}