namespace CES_Telstar.Models
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
        public Company Company { get; set; }

    }
}