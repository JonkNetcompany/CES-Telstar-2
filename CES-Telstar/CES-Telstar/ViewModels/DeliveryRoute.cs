namespace CES_Telstar.ViewModels
{
    public class DeliveryRoute
    {
        public string Start { get; set; }
        public string End { get; set; }
        public double Time { get; set; }
        public double Price { get; set; }
        public bool HasShipping { get; set; }
        public bool HasFlight { get; set; }
        public bool IsRecommended { get; set; }
    }
}