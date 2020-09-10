using System.Web.Http;
using CES_Telstar.Services;
using System.Web.Http.Cors;

namespace CES_Telstar.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RouteController : ApiController
    {
        private readonly ISecurityService _securityService;
        private readonly IRouteService _routeService;

        public RouteController(ISecurityService securityService, IRouteService routeService)
        {
            _securityService = securityService;
            _routeService = routeService;
        }

        [HttpGet]
        public IHttpActionResult FindRoutes(string apiKey, string startLocationName, string endLocationName, bool recommended)
        {
            if (!_securityService.IsAuthenticated(apiKey))
            {
                return Unauthorized();
            }

            //TODO: Fix mock

            return Ok(startLocationName + "," + endLocationName + "," + recommended);
        }
    }
}