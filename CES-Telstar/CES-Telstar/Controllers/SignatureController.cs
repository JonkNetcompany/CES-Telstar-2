using System;
using System.Web.Http;
using CES_Telstar.Services;

namespace CES_Telstar.Controllers
{
    public class SignatureController : ApiController
    {
        private readonly ISecurityService _securityService;
        private readonly IPackageService _packageService;

        public SignatureController(ISecurityService securityService, IPackageService packageService)
        {
            _securityService = securityService;
            _packageService = packageService;
        }

        [HttpGet]
        public IHttpActionResult IsSignatureRequired(Guid id, string apiKey)
        {
            if (!_securityService.IsAuthenticated(apiKey))
            {
                return Unauthorized();
            }

            var package = _packageService.GetPackage(id);
            if (package == null)
            {
                return NotFound();
            }

            var levarance = _packageService.GetLevaranceForPackage(id);
            if (levarance == null)
            {
                return NotFound();
            }

            return Ok(levarance.Recommended);
        }

        [HttpPost]
        public IHttpActionResult AddSignature(Guid id, string apiKey, string signature)
        {
            if (!_securityService.IsAuthenticated(apiKey))
            {
                return Unauthorized();
            }

            var package = _packageService.GetPackage(id);
            if (package == null)
            {
                return NotFound();
            }

            var levarance = _packageService.GetLevaranceForPackage(id);
            if (levarance == null)
            {
                return NotFound();
            }

            //TODO: levarance.Tracking

            return Ok(id + "," + signature);
        }
    }
}