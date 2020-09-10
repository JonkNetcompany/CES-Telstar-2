using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CES_Telstar.ViewModels
{
    public class ViewRoute
    {
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }

        //TODO public IList<Location> Locations { get; set; } = new List<string>();

        public double Time { get; set; }
        public double Price { get; set; }

        public bool HasDriving { get; set; }
        public bool HasShipping { get; set; }
        public bool HasFlight { get; set; }

    }
}