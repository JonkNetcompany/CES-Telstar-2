using System.Web.Configuration;
using System.Web.Http;
using CES_Telstar.Services;

namespace CES_Telstar.Controllers
{
    public class ExternalController : ApiController
    {
        private ISecurityService securityService;

        public ExternalController()
        {
            securityService = new SecurityService();
        }

        [HttpGet]
        public IHttpActionResult FindRoutes(string apiKey, string startLocationName, string endLocationName)
        {
            if (!securityService.IsAuthenticated(apiKey))
            {
                return Unauthorized();
            }
            return Ok(apiKey + "," + startLocationName + "," + endLocationName);
        }
    }
}