using System.Web.Http;
using CES_Telstar.Services;
using CES_Telstar.ViewModels;

namespace CES_Telstar.Controllers
{
    public class ExternalController : ApiController
    {
        private readonly ISecurityService _securityService;

        public ExternalController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpGet]
        public IHttpActionResult FindRoutes(string apiKey, string startLocationName, string endLocationName)
        {
            if (!_securityService.IsAuthenticated(apiKey))
            {
                return Unauthorized();
            }

            //TODO: Fix mock and return a 404 on missing route
            var route = new ViewExternalRoute
            {
                StartLocation = startLocationName,
                EndLocation = endLocationName,
                Time = 4,
                Price = 52.2
            };

            return Ok(route);
        }
    }
}