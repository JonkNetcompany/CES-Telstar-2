using Domain.Models;
using Persistence.Context;

namespace CES_Telstar.Services
{
    internal class BookingService : IBookingService
    {
        private readonly RouteContext _context;

        public BookingService(RouteContext context)
        {
            _context = context;
        }

        public bool BookDelivery(Levarance delivery)
        {
            throw new System.NotImplementedException();
        }
    }
}