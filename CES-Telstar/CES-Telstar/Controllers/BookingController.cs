using System.Web.Http;
using CES_Telstar.Services;
using CES_Telstar.ViewModels;

namespace CES_Telstar.Controllers
{
    public class BookingController : ApiController
    {
        private readonly ISecurityService _securityService;

        public BookingController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpPost]
        public IHttpActionResult BookDelivery(string apiKey, [FromBody] DeliveryRoute deliveryRoute)
        {
            if (!_securityService.IsAuthenticated(apiKey))
            {
                return Unauthorized();
            }

            //TODO: Fix mock

            return Ok(deliveryRoute);
        }
    }
}