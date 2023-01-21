using interfaces;
namespace classes{
    public class Camionnette : Vehicule, ISerialisable
    {   public static  double PRIX = 800;
        public Camionnette(string usage)
        {
        Usage = usage;
        }
        public string Usage { get; set; }
        public override string ToString()
        {
            return $"Comionnette,{Usage}";
        }
    }
}