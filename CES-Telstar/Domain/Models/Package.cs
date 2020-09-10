namespace Domain.Models
{
    public enum PackageType
    {
        Normal,
        Weapons,
        LiveAnimals,
        CautiousParcels,
        RefrigeratedGoods
    }

    public class Package
    {
        public int ID { get; set; }
        public virtual PackageType PackageType { get; set; }
        public double Weight { get; set; }
        public virtual Location Location { get; set; }
    }
}