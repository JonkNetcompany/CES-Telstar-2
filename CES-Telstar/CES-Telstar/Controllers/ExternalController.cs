using System.Web.Http;
using CES_Telstar.Services;
using CES_Telstar.ViewModels;
using System.Web.Http.Cors;

namespace CES_Telstar.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExternalController : ApiController
    {
        private readonly ISecurityService _securityService;
        private readonly IRouteService _routeService;

        public ExternalController(ISecurityService securityService, IRouteService routeService)
        {
            _securityService = securityService;
            _routeService = routeService;
        }

        [HttpGet]
        public IHttpActionResult FindRoutes(string apiKey, string startLocationName, string endLocationName)
        {
            if (!_securityService.IsAuthenticated(apiKey, true))
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