using Domain.Models;

namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Persistence.Context.RouteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Persistence.Context.RouteContext context)
        {
            //  This method will be called after migrating to the latest version.

            //context.Routes.Add(new Route {Id = Guid.NewGuid()});
            //context.SaveChanges();
        }
    }
}
