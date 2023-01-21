using interfaces;
namespace classes{

    class Commande : ISerialisable{
        public string NssClient { get; set; }
        public string NssChauffeur { get; set; }
        public DateTime DateCommande { get; set; }
        public string VilleDepart { get; set; }
        public string VilleArrivee { get; set; }
        public Vehicule Vehicule { get; set; }
        public double Montant { get; set; }
        public Commande(string nssClient, string nssChauffeur, DateTime dateCommande, string villeDepart, string villeArrivee, Vehicule vehicule, double montant)
        {
            NssClient = nssClient;
            NssChauffeur = nssChauffeur;
            DateCommande = dateCommande;
            VilleDepart = villeDepart;
            VilleArrivee = villeArrivee;
            Vehicule = vehicule;
            Montant = montant;
        }
        public override string ToString()
        {
            return $"{NssClient},{NssChauffeur},{DateCommande},{VilleDepart},{VilleArrivee},{Montant}"+ Environment.NewLine + Vehicule.ToString();
        }
    }
}