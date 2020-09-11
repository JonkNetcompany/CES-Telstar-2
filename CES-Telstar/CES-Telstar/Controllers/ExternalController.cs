using System;
using System.Collections.Generic;
using System.Web.Http;
using CES_Telstar.Services;
using System.Web.Http.Cors;
using CES_Telstar.Util;
using Domain.Models;

namespace CES_Telstar.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExternalController : ApiController
    {
        private readonly ISecurityService _securityService;
        private readonly IRouteService _routeService;
        private readonly ILocationService _locationService;

        private readonly IList<PackageType> _allowedPackageTypes;

        public ExternalController(ISecurityService securityService, IRouteService routeService, ILocationService locationService)
        {
            _securityService = securityService;
            _routeService = routeService;
            _locationService = locationService;

            _allowedPackageTypes = new List<PackageType>
            {
                PackageType.Normal,
                PackageType.CautiousParcels,
                PackageType.LiveAnimals,
                PackageType.RefrigeratedGoods
            };
        }

        [HttpGet]
        public IHttpActionResult FindRoutes(string apiKey, string startLocationName, string endLocationName, bool recommended, string goods, double weight)
        {
            if (!_securityService.IsAuthenticated(apiKey, true)) return Unauthorized();

            var lowerStart = startLocationName.ToLower();
            var lowerEnd = endLocationName.ToLower();

            var startLocation = _locationService.FindLocation(lowerStart);
            if (startLocation == null) return NotFound();
            
            var endLocation = _locationService.FindLocation(lowerEnd);
            if (endLocation == null) return NotFound();

            if (weight > 40) return BadRequest("Weights over 40 kg are not supported");

            var canParse = Enum.TryParse<PackageType>(goods, true, out var packageType);
            if (!canParse) return BadRequest("Unknown type of goods");
            if (!_allowedPackageTypes.Contains(packageType)) return BadRequest("That type of goods is not allowed");

            var cheapestRoute = _routeService.FindCheapest(startLocation, endLocation, true);
            var fastestRoute = _routeService.FindFastest(startLocation, endLocation, true);

            var viewRoutes = new[]
            {
                RouteMapper.ViewExternalRouteFromRoute(cheapestRoute, startLocationName, endLocationName, packageType, recommended),
                RouteMapper.ViewExternalRouteFromRoute(fastestRoute, startLocationName, endLocationName, packageType, recommended)
            };

            return Ok(viewRoutes);
        }
    }
}