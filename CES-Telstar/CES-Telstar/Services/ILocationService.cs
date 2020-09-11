using Domain.Models;

namespace CES_Telstar.Services
{
    public interface ILocationService
    {
        Location FindLocation(string name);
    }
}
