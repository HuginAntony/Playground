using System.Web.Http;

namespace OwinSelfHostWebApi.Configurations
{
    public static class WebConfig
    {
        public static HttpConfiguration GetHttpConfiguration()
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            return config;
        }
    }
}
