using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CES_Telstar.Util;
using DijkstraAlgorithm.Pathing;
using Domain.Models;
using Persistence.Context;

namespace CES_Telstar.Services
{
    public class RouteService : IRouteService
    {
        private readonly RouteContext _context;
        private readonly ShortestPathUtil _pathUtil;

        private readonly IEnumerable<Location> _locations;

        public RouteService(RouteContext context)
        {
            _context = context;

            var segments = context.Segments.Include(s => s.Locations);
            _locations = segments.SelectMany(s => s.Locations).Distinct();
                
            _pathUtil = new ShortestPathUtil(segments, _locations);
        }

        public Route FindFastest(Location start, Location end, bool ownRoute)
        {
            if (ownRoute)
            {
                return FindFastestByCar(start, end);
            }
            else
            {
                return null; //TODO
            }
        }

        public Route FindCheapest(Location start, Location end, bool ownRoute)
        {
            if (ownRoute)
            {
                return FindCheapestByCar(start, end);
            }
            else
            {
                return null; //TODO
            }
        }

        private Route FindFastestByCar(Location start, Location end)
        {
            var path = _pathUtil.FindFastestPath(start, end);
            return RouteFromPath(path);
        }

        private Route FindCheapestByCar(Location start, Location end)
        {
            var path = _pathUtil.FindCheapest(start, end);
            return RouteFromPath(path);
        }

        private Route RouteFromPath(Path path)
        {
            var cityTuples = new List<string[]>();

            foreach (var segment in path.Segments)
            {
                var arr = new []
                {
                    segment.Origin.Id,
                    segment.Destination.Id
                };
                cityTuples.Add(arr);
            }

            var segments = new List<Segment>();

            foreach (var tuple in cityTuples)
            {
                var segment = _context.Segments.SingleOrDefault(s => 
                    s.Locations.Any(l => l.CityName == tuple[0]) && 
                    s.Locations.Any(l => l.CityName == tuple[1]));

                if (segment != null)
                {
                    segments.Add(segment);
                }
            }

            return new Route()
            {
                Segments = segments
            };
        }
    }
}