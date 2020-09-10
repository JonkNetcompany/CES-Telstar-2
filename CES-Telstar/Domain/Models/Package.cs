namespace Domain.Models
{
    public enum PackageType
    {
        Normal,
        Weapons,
        LiveAnimals,
        CautiousParcels,
        RefigeratedGoods
    }

    public class Package
    {
        public int ID { get; set; }
        public PackageType PackageType { get; set; }
        public float Weight { get; set; }
        public Location Location { get; set; }
    }
}