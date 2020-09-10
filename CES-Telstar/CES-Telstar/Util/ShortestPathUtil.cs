using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using DijkstraAlgorithm.Graphing;
using DijkstraAlgorithm.Pathing;

namespace CES_Telstar.Util
{
    public class ShortestPathUtil
    {
        private Graph _fastestGraph;
        private PathFinder _fastestPathFinder;

        private Graph _cheapestGraph;
        private PathFinder _cheapestPathFinder;

        public ShortestPathUtil(IEnumerable<Segment> segments, IEnumerable<Location> locations)
        {
            BuildPathFinder(segments, locations, true);
            BuildPathFinder(segments, locations, false);
        }

        private void BuildPathFinder(IEnumerable<Segment> segments, IEnumerable<Location> locations, bool cheapest)
        {
            var builder = new GraphBuilder();
            foreach (var location in locations.ToList())
            {
                builder.AddNode(location.CityName);
                var otherLocations = segments
                    .Where(s => s.Locations.Contains(location))
                    .Select(s =>
                        new MinSegment
                        {
                            Location = s.Locations.First(l => l != location),
                            Cost = cheapest ? s.Price : s.Time
                        });

                foreach (var otherLocation in otherLocations)
                {
                    builder.AddLink(location.CityName, otherLocation.Location.CityName, otherLocation.Cost);
                }
            }

            if (cheapest)
            {
                _cheapestGraph = builder.Build();
                _cheapestPathFinder = new PathFinder(_cheapestGraph);
            }
            else
            {
                _fastestGraph = builder.Build();
                _fastestPathFinder = new PathFinder(_fastestGraph);
            }
            
        }

        public Path FindCheapest(Location start, Location end)
        {
            var origin = _cheapestGraph.Nodes.Single(n => n.Id == start.CityName);
            var destination = _cheapestGraph.Nodes.Single(n => n.Id == end.CityName);

            return _cheapestPathFinder.FindShortestPath(origin, destination);
        }

        public Path FindFastestPath(Location start, Location end)
        {
            var origin = _fastestGraph.Nodes.Single(n => n.Id == start.CityName);
            var destination = _fastestGraph.Nodes.Single(n => n.Id == end.CityName);

            return _fastestPathFinder.FindShortestPath(origin, destination);
        }
    }
}