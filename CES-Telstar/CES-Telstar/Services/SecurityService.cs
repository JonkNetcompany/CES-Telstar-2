using System.Collections.Generic;

namespace CES_Telstar.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IList<string> apiKeys;
        
        public SecurityService()
        {
            apiKeys = new[]
            {
                "3964FD89-D20A-4280-8AD5-854F66674CD8",
                "DB93FC07-D34B-46A4-B94B-A0E44CD4A44B"
            };
        }

        public bool IsAuthenticated(string apiKey)
        {
            return apiKeys.Contains(apiKey);
        }
    }
}