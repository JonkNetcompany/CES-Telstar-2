namespace CES_Telstar.Models
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
    }
}