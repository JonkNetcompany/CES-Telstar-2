using Domain.Models;
using Persistence.Context;

namespace CES_Telstar.Services
{
    public class BookingService : IBookingService
    {
        private readonly RouteContext _context;

        public BookingService(RouteContext context)
        {
            _context = context;
        }

        public bool BookDelivery(Levarance delivery)
        {
            //TODO
            return true;
        }
    }
}