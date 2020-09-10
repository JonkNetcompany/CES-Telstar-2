using System.Web.Http;
using CES_Telstar.Services;
using System.Web.Http.Cors;

namespace CES_Telstar.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RouteController : ApiController
    {
        private readonly ISecurityService _securityService;

        public RouteController(ISecurityService securityService)
        {
            _securityService = securityService;
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