using System;
using System.Collections.Generic;
using System.Linq;
using CES_Telstar.Util;
using Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CES_Telstar.Tests
{
    [TestClass]
    public class RouteServiceTests
    {
        [TestMethod]
        public void WhenFastestIsSearchedAC_ThenCorrectPathIsFound()
        {
            // Arrange
            var segments = MockSegments();
            var locations = Locations();


            var sut = new ShortestPathUtil(segments, locations);

            var start = locations.Single(l => l.CityName == "A");
            var end = locations.Single(l => l.CityName == "C");

            // Act
            var path = sut.FindFastest(start, end);

            // Assert
            Assert.IsTrue(path.Origin.Id == "A");
            Assert.IsTrue(path.Destination.Id == "C");
            var time = path.Segments.Select(s => s.Weight).Aggregate((s, w) => s + w);
            
            var route = new List<string>();
            foreach (var node in path.Segments)
            {
                if (!route.Contains(node.Origin.Id)) route.Add(node.Origin.Id);
                if (!route.Contains(node.Destination.Id)) route.Add(node.Destination.Id);
            }

            var stringRoute = string.Join(",", route);

            Assert.IsTrue(stringRoute == "A,B,C");
            Assert.IsTrue(time == 3.0);
        }

        [TestMethod]
        public void WhenCheapestIsSearchedAC_ThenCorrectPathIsFound()
        {
            // Arrange
            var segments = MockSegments();
            var locations = Locations();


            var sut = new ShortestPathUtil(segments, locations);

            var start = locations.Single(l => l.CityName == "A");
            var end = locations.Single(l => l.CityName == "C");

            // Act
            var path = sut.FindCheapest(start, end);

            // Assert
            Assert.IsTrue(path.Origin.Id == "A");
            Assert.IsTrue(path.Destination.Id == "C");
            var time = path.Segments.Select(s => s.Weight).Aggregate((s, w) => s + w);

            var route = new List<string>();
            foreach (var node in path.Segments)
            {
                if (!route.Contains(node.Origin.Id)) route.Add(node.Origin.Id);
                if (!route.Contains(node.Destination.Id)) route.Add(node.Destination.Id);
            }

            var stringRoute = string.Join(",", route);

            Assert.IsTrue(stringRoute == "A,E,C");
            Assert.IsTrue(time == 6.0);
        }

        [TestMethod]
        public void WhenFastestIsSearchedBD_ThenCorrectPathIsFound()
        {
            // Arrange
            var segments = MockSegments();
            var locations = Locations();


            var sut = new ShortestPathUtil(segments, locations);

            var start = locations.Single(l => l.CityName == "B");
            var end = locations.Single(l => l.CityName == "D");

            // Act
            var path = sut.FindFastest(start, end);

            // Assert
            Assert.IsTrue(path.Origin.Id == "B");
            Assert.IsTrue(path.Destination.Id == "D");
            var time = path.Segments.Select(s => s.Weight).Aggregate((s, w) => s + w);

            var route = new List<string>();
            foreach (var node in path.Segments)
            {
                if (!route.Contains(node.Origin.Id)) route.Add(node.Origin.Id);
                if (!route.Contains(node.Destination.Id)) route.Add(node.Destination.Id);
            }

            var stringRoute = string.Join(",", route);

            Assert.IsTrue(stringRoute == "B,C,D");
            Assert.IsTrue(time == 3.0);
        }

        [TestMethod]
        public void WhenCheapestIsSearchedBD_ThenCorrectPathIsFound()
        {
            // Arrange
            var segments = MockSegments();
            var locations = Locations();


            var sut = new ShortestPathUtil(segments, locations);

            var start = locations.Single(l => l.CityName == "B");
            var end = locations.Single(l => l.CityName == "D");

            // Act
            var path = sut.FindCheapest(start, end);

            // Assert
            Assert.IsTrue(path.Origin.Id == "B");
            Assert.IsTrue(path.Destination.Id == "D");
            var time = path.Segments.Select(s => s.Weight).Aggregate((s, w) => s + w);

            var route = new List<string>();
            foreach (var node in path.Segments)
            {
                if (!route.Contains(node.Origin.Id)) route.Add(node.Origin.Id);
                if (!route.Contains(node.Destination.Id)) route.Add(node.Destination.Id);
            }

            var stringRoute = string.Join(",", route);

            Assert.IsTrue(stringRoute == "B,D");
            Assert.IsTrue(time == 6.0);
        }



        private List<Segment> MockSegments()
        {
            return new List<Segment>
            {
                NewSegment("A", "B", 1.0, 3.0),
                NewSegment("A", "E", 1.0, 2.0),
                NewSegment("B", "C", 2.0, 5.0),
                NewSegment("B", "D", 5.0, 6.0),
                NewSegment("B", "E", 2.0, 2.0),
                NewSegment("C", "D", 1.0, 2.0),
                NewSegment("C", "E", 3.0, 4.0)
            };
        }

        private List<Location> Locations()
        {
            return new List<Location>
            {
                new Location
                {
                    CityName = "A"
                },
                new Location
                {
                    CityName = "B"
                },
                new Location
                {
                    CityName = "C"
                },
                new Location
                {
                    CityName = "D"
                },
                new Location
                {
                    CityName = "E"
                },
            };
        }

        private Segment NewSegment(string from, string to, double time, double price)
        {
            return new Segment
            {
                Locations = new List<Location>
                {
                    Locations().Single(l => l.CityName == from),
                    Locations().Single(l => l.CityName == to)
                },
                Time = time,
                Price = price
            };
        }
    }
}
