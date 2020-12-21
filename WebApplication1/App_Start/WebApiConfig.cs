using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;


namespace EventsManagementWeb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            /*The api return the result with attribute name as the name declared on the dto class.
             * However, Javascript using Camel notation without the uppercase on the first character
             * . So we need to config to change the attribute name followed Camel notation rule */
            var setting = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            setting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            setting.Formatting = Formatting.Indented;


			config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
