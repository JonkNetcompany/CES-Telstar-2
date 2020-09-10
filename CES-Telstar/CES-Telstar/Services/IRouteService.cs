using Domain.Models;

namespace CES_Telstar.Services
{
    public interface IRouteService
    {
        Route FindFastest(Location start, Location end, bool ownRoute);

        Route FindCheapest(Location start, Location end, bool ownRoute);
    }
}
