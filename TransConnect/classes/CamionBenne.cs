using interfaces;
namespace classes{
    class CamionBenne : Camion , ISerialisable
    {   public static  double PRIX = 1400;
        public CamionBenne(int nbBennes, bool gru)
        {
            NbBennes = nbBennes;
            Gru = gru;
        }
        public int NbBennes { get; set; }
        public bool Gru { get; set; }
        public override string ToString()
        {
            return $"CamionBenne,{NbBennes},{Gru}";
        }
    }
}