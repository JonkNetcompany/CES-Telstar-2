using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Domain.Models;

namespace Persistence.Context
{
    public class RouteContext : DbContext
    {
        public RouteContext() : base("RouteContext")
        {
        }

        public DbSet<Route> Routes { get; set; }
        public DbSet<Customer> Costomers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Levarance> Levarances { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Segment> Segments { get; set; }
        public DbSet<Signature> Signatures { get; set; }
        public DbSet<Tracking> Trackings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
