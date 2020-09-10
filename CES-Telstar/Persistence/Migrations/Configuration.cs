using System.Collections.Generic;
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
            var locations = new List<Location>
            {
                new Location { CityName = "kapstaden"},
                new Location { CityName = "cairo"},
                new Location { CityName = "hvalbugten"},
                new Location { CityName = "victoriafaldene"},
                new Location { CityName = "dragebjerget"},
                new Location { CityName = "mocambique"},
                new Location { CityName = "luanda"},
                new Location { CityName = "congo"},
                new Location { CityName = "kabalo"},
                new Location { CityName = "victoriasøen"},
                new Location { CityName = "addis abeba"},
                new Location { CityName = "zanzibar"},
                new Location { CityName = "kap guardafui"},
                new Location { CityName = "tanger"},
                new Location { CityName = "tunis"},
                new Location { CityName = "tripoli"},
                new Location { CityName = "marrakesh"},
                new Location { CityName = "sahara"},
                new Location { CityName = "dakar"},
                new Location { CityName = "sierra leone"},
                new Location { CityName = "omdurman"},
                new Location { CityName = "darfur"},
                new Location { CityName = "timbuktu"},
                new Location { CityName = "slave-kysten"},
                new Location { CityName = "wadai"},
                new Location { CityName = "suakin"},
                new Location { CityName = "guldkysten"},
                new Location { CityName = "bahr el ghazal"}
            };


            var leverances = new List<Levarance>
            {
                new Levarance
                {
                    Route = new Route
                    {
                        Id = Guid.NewGuid(),
                        Segments = new List<Segment>
                        {
                            new Segment
                            {
                                Locations = new List<Location>
                                {
                                    locations.First(l => l.CityName == "cairo"),
                                    locations.First(l => l.CityName == "omdurman"),
                                },
                                Time = 16,
                                Price = 12
                            },
                            new Segment
                            {
                                Locations = new List<Location>
                                {
                                    locations.First(l => l.CityName == "omdurman"),
                                    locations.First(l => l.CityName == "darfur")
                                },
                                Time = 12,
                                Price = 9
                            }
                        }
                    },
                    Package = new Package
                    {
                        PackageType = PackageType.Normal,
                        Weight = 5,
                        Location = locations.First(l => l.CityName == "darfur")
                    },
                    Recommended = false,
                    Time = 28,
                    Price = 21,
                    Tracking = null,
                    Drivers = new List<Driver>
                    {
                        new Driver
                        {
                            Company = Company.TelstarLogistics
                        }
                    }
                }
            };

            var segments = new List<Segment>
            {
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "kapstaden"),
                        locations.First(l => l.CityName == "hvalbugten")
                    },
                    Time = 16,
                    Price = 12
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "hvalbugten"),
                        locations.First(l => l.CityName == "victoriafaldene")
                    },
                    Time = 16,
                    Price = 12
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "victoriafaldene"),
                        locations.First(l => l.CityName == "dragebjerget")
                    },
                    Time = 12,
                    Price = 9
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "dragebjerget"),
                        locations.First(l => l.CityName == "mocambique")
                    },
                    Time = 16,
                    Price = 12
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "victoriafaldene"),
                        locations.First(l => l.CityName == "mocambique")
                    },
                    Time = 20,
                    Price = 15
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "mocambique"),
                        locations.First(l => l.CityName == "luanda")
                    },
                    Time = 40,
                    Price = 30
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "victoriafaldene"),
                        locations.First(l => l.CityName == "luanda")
                    },
                    Time = 44,
                    Price = 33
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "dragebjerget"),
                        locations.First(l => l.CityName == "luanda")
                    },
                    Time = 44,
                    Price = 33
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "luanda"),
                        locations.First(l => l.CityName == "congo")
                    },
                    Time = 12,
                    Price = 9
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "luanda"),
                        locations.First(l => l.CityName == "kabalo")
                    },
                    Time = 16,
                    Price = 12
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "kabalo"),
                        locations.First(l => l.CityName == "victoriasøen")
                    },
                    Time = 16,
                    Price = 12
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "victoriasøen"),
                        locations.First(l => l.CityName == "addis abeba")
                    },
                    Time = 12,
                    Price = 9
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "victoriasøen"),
                        locations.First(l => l.CityName == "mocambique")
                    },
                    Time = 24,
                    Price = 18
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "victoriasøen"),
                        locations.First(l => l.CityName == "zanzibar")
                    },
                    Time = 20,
                    Price = 15
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "mocambique"),
                        locations.First(l => l.CityName == "zanzibar")
                    },
                    Time = 12,
                    Price = 9
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "kap guardafui"),
                        locations.First(l => l.CityName == "zanzibar")
                    },
                    Time = 24,
                    Price = 18
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "tanger"),
                        locations.First(l => l.CityName == "tunis")
                    },
                    Time = 20,
                    Price = 15
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "tunis"),
                        locations.First(l => l.CityName == "tripoli")
                    },
                    Time = 12,
                    Price = 9
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "tanger"),
                        locations.First(l => l.CityName == "marrakesh")
                    },
                    Time = 8,
                    Price = 6
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "tanger"),
                        locations.First(l => l.CityName == "sahara")
                    },
                    Time = 20,
                    Price = 15
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "marrakesh"),
                        locations.First(l => l.CityName == "dakar")
                    },
                    Time = 32,
                    Price = 24
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "dakar"),
                        locations.First(l => l.CityName == "sierra leone")
                    },
                    Time = 16,
                    Price = 12
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "tripoli"),
                        locations.First(l => l.CityName == "omdurman")
                    },
                    Time = 24,
                    Price = 18
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "sahara"),
                        locations.First(l => l.CityName == "darfur")
                    },
                    Time = 32,
                    Price = 24
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "omdurman"),
                        locations.First(l => l.CityName == "darfur")
                    },
                    Time = 16,
                    Price = 12
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "sierra leone"),
                        locations.First(l => l.CityName == "timbuktu")
                    },
                    Time = 20,
                    Price = 15
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "timbuktu"),
                        locations.First(l => l.CityName == "slave-kysten")
                    },
                    Time = 24,
                    Price = 18
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "wadai"),
                        locations.First(l => l.CityName == "slave-kysten")
                    },
                    Time = 28,
                    Price = 21
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "darfur"),
                        locations.First(l => l.CityName == "slave-kysten")
                    },
                    Time = 28,
                    Price = 21
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "darfur"),
                        locations.First(l => l.CityName == "wadai")
                    },
                    Time = 16,
                    Price = 12
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "darfur"),
                        locations.First(l => l.CityName == "suakin")
                    },
                    Time = 16,
                    Price = 12
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "addis abeba"),
                        locations.First(l => l.CityName == "suakin")
                    },
                    Time = 12,
                    Price = 9
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "addis abeba"),
                        locations.First(l => l.CityName == "kap guardafui")
                    },
                    Time = 12,
                    Price = 9
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "congo"),
                        locations.First(l => l.CityName == "wadai")
                    },
                    Time = 24,
                    Price = 18
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "cairo"),
                        locations.First(l => l.CityName == "omdurman")
                    },
                    Time = 16,
                    Price = 12
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "sierra leone"),
                        locations.First(l => l.CityName == "guldkysten")
                    },
                    Time = 20,
                    Price = 15
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "timbuktu"),
                        locations.First(l => l.CityName == "guldkysten")
                    },
                    Time = 20,
                    Price = 15
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "darfur"),
                        locations.First(l => l.CityName == "bahr el ghazal")
                    },
                    Time = 8,
                    Price = 6
                },
                new Segment
                {
                    Locations = new List<Location>
                    {
                        locations.First(l => l.CityName == "bahr el ghazal"),
                        locations.First(l => l.CityName == "victoriasøen")
                    },
                    Time = 8,
                    Price = 6
                }
            };

            // leverances.ForEach(l => context.Levarances.Add(l));
            segments.ForEach(s => context.Segments.Add(s));
            context.SaveChanges();
        }
    }
}
