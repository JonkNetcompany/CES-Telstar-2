namespace Domain.Models
{
    public class Tracking
    {
        public int ID { get; set; }
        // public int SignatureID { get; set; }
        // public int LocationID { get; set; }
        public virtual Signature Signature { get; set; }
        public virtual Location CurrentLocation { get; set; }
    }
}