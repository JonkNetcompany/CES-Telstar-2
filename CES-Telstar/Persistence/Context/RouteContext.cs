using System.Data.Entity;
using Domain.Models;

namespace Persistence.Context
{
    public class RouteContext : DbContext
    {
        public DbSet<Route> Routes { get; set; }
    }
}
