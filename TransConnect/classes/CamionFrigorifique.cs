using interfaces;
namespace classes{
    class CamionFrigorifique : Camion,ISerialisable
    {   
        public static  double PRIX = 1200;

        public CamionFrigorifique(int nbGroupe, int langeurDistance)
        {
            NbGroupe = nbGroupe;
            LangeurDistance = langeurDistance;
        }
        public int NbGroupe { get; set; }
        public int LangeurDistance { get; set; }
        public override string ToString()
        {
            return $"CamionFrigorifique,{NbGroupe},{LangeurDistance}";
        }
    }
}