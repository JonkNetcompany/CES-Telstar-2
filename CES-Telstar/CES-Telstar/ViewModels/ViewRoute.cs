using System.Collections.Generic;

namespace CES_Telstar.ViewModels
{
    public class ViewRoute
    {
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }

        public IList<string> Locations { get; set; } = new List<string>();

        public double Time { get; set; }
        public double Price { get; set; }

        public bool HasDriving { get; set; }
        public bool HasShipping { get; set; }
        public bool HasFlight { get; set; }

    }
}