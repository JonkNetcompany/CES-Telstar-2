namespace CES_Telstar.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly string _internalKey = "3964FD89-D20A-4280-8AD5-854F66674CD8";
        private readonly string _externalKey = "DB93FC07-D34B-46A4-B94B-A0E44CD4A44B";

        public bool IsAuthenticated(string apiKey, bool external = false)
        {
            if (external)
            {
                return apiKey == _externalKey;
            }
            else
            {
                return apiKey == _internalKey;
            }
        }
    }
}