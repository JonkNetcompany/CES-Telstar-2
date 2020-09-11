using System.Web.Http;
using CES_Telstar.Services;
using CES_Telstar.Util;
using CES_Telstar.ViewModels;

namespace CES_Telstar.Controllers
{
    public class BookingController : ApiController
    {
        private readonly ISecurityService _securityService;
        private readonly IBookingService _bookingService;

        public BookingController(ISecurityService securityService, IBookingService bookingService)
        {
            _securityService = securityService;
            _bookingService = bookingService;
        }

        [HttpPost]
        public IHttpActionResult BookDelivery(string apiKey, [FromBody] DeliveryRoute deliveryRoute)
        {
            if (!_securityService.IsAuthenticated(apiKey))
            {
                return Unauthorized();
            }

            var delivery = Mapper.MapFromDeliveryRoute(deliveryRoute);

            var isBooked = _bookingService.BookDelivery(delivery);

            return Ok(isBooked);
        }


    }
}