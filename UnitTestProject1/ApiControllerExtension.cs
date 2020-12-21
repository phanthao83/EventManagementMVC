
using System.Security.Claims;
using System.Security.Principal;
using System.Web.Http;
namespace UnitTestProject1.Extensions
{
    public static class ApiControllerExtension
    {
        public static void MockCurrentUser(ApiController controller, string userName, string userId)
        {
            System.Web.
            var identity = new GenericIdentity(userName);
            identity.AddClaim(
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", userName));
            identity.AddClaim(
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", userId));

            var principal = new GenericPrincipal(identity, null);

            controller.User = principal;
        }


    }
}
