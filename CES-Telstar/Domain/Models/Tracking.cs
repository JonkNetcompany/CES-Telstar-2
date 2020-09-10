namespace Domain.Models
{
    public class Tracking
    {
        public int ID { get; set; }
        public Signature Signature { get; set; }
        public Location CurrentLocation { get; set; }
    }
}