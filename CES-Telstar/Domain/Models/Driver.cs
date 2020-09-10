namespace Domain.Models
{
    public enum Company
    {
        TelstarLogistics,
        EastIndiaTrading,
        OceanicAirlines
    }

    public class Driver
    {
        public int ID { get; set; }
        public virtual Company Company { get; set; }

    }
}