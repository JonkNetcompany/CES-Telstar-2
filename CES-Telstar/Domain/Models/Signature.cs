namespace Domain.Models
{
    public class Signature
    {
        public int ID { get; set; }
        public string signature { get; set; }
        public virtual Customer MyProperty { get; set; }
    }
}