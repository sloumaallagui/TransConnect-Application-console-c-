using interfaces;
namespace classes{
    public class CamionCiterne : Camion, ISerialisable
    {   public static  double PRIX = 1800;
        public CamionCiterne(int type)
        {
            Type = type;
        }
        public int Type { get; set; }
        public override string ToString()
        {
            return $"CamionCiterne,{Type}";
        }
    }
}