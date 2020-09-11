using System.Collections.Generic;
using System.Linq;
using CES_Telstar.ViewModels;
using Domain.Models;

namespace CES_Telstar.Util
{
    public static class RouteMapper
    {
        public static ViewExternalRoute ViewExternalRouteFromRoute(Route route, string start, string end, PackageType packageType, bool recommended)
        {
            var segmentPrice = route.Segments.Select(s => s.Price).Aggregate((s, price) => s + price);
            double finalPrice = segmentPrice;
            switch (packageType)
            {
                case PackageType.LiveAnimals: finalPrice *= 1.5;
                    break;
                case PackageType.CautiousParcels:
                    finalPrice *= 1.75;
                    break;
                case PackageType.RefrigeratedGoods:
                    finalPrice *= 1.1;
                    break;
            }

            if (recommended) finalPrice += 10;

            return new ViewExternalRoute
            {
                StartLocation = start,
                EndLocation = end,
                Price = finalPrice,
                Time = route.Segments.Select(s => s.Time).Aggregate((s, price) => s + price)
            };
        }

        public static ViewRoute ViewRouteFromRoute(Route route, string start, string end, PackageType packageType, bool recommended)
        {
            var orderedLocations = new List<string>();
            foreach (var segment in route.Segments)
            {
                orderedLocations.Add(segment.Locations.First().CityName);
                orderedLocations.Add(segment.Locations.Last().CityName);
            }

            var segmentPrice = route.Segments.Select(s => s.Price).Aggregate((s, price) => s + price);
            double finalPrice = segmentPrice;
            switch (packageType)
            {
                case PackageType.LiveAnimals:
                    finalPrice *= 1.5;
                    break;
                case PackageType.CautiousParcels:
                    finalPrice *= 1.75;
                    break;
                case PackageType.RefrigeratedGoods:
                    finalPrice *= 1.1;
                    break;
            }

            if (recommended) finalPrice += 10;

            return new ViewRoute
            {
                StartLocation = start,
                EndLocation = end,
                Price = finalPrice,
                Time = route.Segments.Select(s => s.Time).Aggregate((s, time) => s + time),
                Locations = orderedLocations
            };
        }
    }
}