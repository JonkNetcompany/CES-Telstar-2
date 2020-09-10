namespace CES_Telstar.Services
{
    public interface ISecurityService
    {
        bool IsAuthenticated(string apiKey, bool external = false);
    }
}
