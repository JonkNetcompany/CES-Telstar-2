using System;
using System.Web.Http;
using CES_Telstar.Services;

namespace CES_Telstar.Controllers
{
    public class SignatureController : ApiController
    {
        private readonly ISecurityService _securityService;

        public SignatureController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpGet]
        public IHttpActionResult IsSignatureRequired(Guid id, string apiKey)
        {
            if (!_securityService.IsAuthenticated(apiKey))
            {
                return Unauthorized();
            }

            //TODO: check if signature is required

            return Ok(id);
        }

        [HttpPost]
        public IHttpActionResult AddSignature(Guid id, string apiKey, string signature)
        {
            if (!_securityService.IsAuthenticated(apiKey))
            {
                return Unauthorized();
            }

            //TODO: Fix mock

            return Ok(id + "," + signature);
        }
    }
}