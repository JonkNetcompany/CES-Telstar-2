using System.Data.Entity;
using CES_Telstar.Models;

namespace CES_Telstar.DAL
{
    public class StarPlannerContext : DbContext
    {
        public StarPlannerContext() : base("StarPlannerContext")
        {
        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Levarance> Levarances { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Segment> Segments { get; set; }
        public DbSet<Signature> Signatures { get; set; }
        public DbSet<Tracking> Trackings { get; set; }
    }
}