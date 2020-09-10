using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CES_Telstar.Util;
using DijkstraAlgorithm.Pathing;
using Domain.Models;
using Persistence.Context;

namespace CES_Telstar.Services
{
    public class LocationService : ILocationService
    {
        private readonly RouteContext _context;

        public LocationService(RouteContext context)
        {
            _context = context;
        }

        public Location FindLocation(string name)
        {
            var location = _context.Segments
                .Include(s => s.Locations)
                .Select(s => s.Locations
                    .FirstOrDefault(l => l.CityName == name));

            return location?.First();
        }
    }
}