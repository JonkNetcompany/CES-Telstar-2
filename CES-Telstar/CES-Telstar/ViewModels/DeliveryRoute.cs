using System.Collections.Generic;

namespace CES_Telstar.ViewModels
{
    public class DeliveryRoute
    {
        //TODO public List<Route>
        public double Time { get; set; }
        public double Price { get; set; }
        public bool HasShipping { get; set; }
        public bool HasFlight { get; set; }
        public bool IsRecommended { get; set; }
    }
}