using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EventsManagementWeb
{
    //public static MapperConfiguration MappingCongfiguration = new  MapperConfiguration (); 

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           // Mapper.Initialize(c => c.AddProfile<MappingProfile>()); 
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
/* Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<ApplicationUser, ArtistDto>();
            Mapper.CreateMap<Gig, GigDto>();
            Mapper.CreateMap<Notification, NotificationDto>();
*/