using interfaces;
namespace classes
{    
    public class Salarie : Personne, ISerialisable
    {   public DateTime DateEmbauche { get; set; }
        
        public Salarie() { 
        }

        public double Salaire { get; set; }
        public string Poste { get; set; }
        public Salarie(string nss, string nom, string prenom, DateTime dateNaissance, string adressePostale, string email, string telephone, DateTime dateEmbauche, double salaire, string poste) : base(nss, nom, prenom, dateNaissance, adressePostale, email, telephone)
        {
            DateEmbauche = dateEmbauche;
            Salaire = salaire;
            Poste = poste;

        }
        public override string ToString()
        {
            return $"{Nss},{Nom},{Prenom},{DateNaissance},{AdressePostale},{Email},{Telephone},{DateEmbauche},{Salaire},{Poste}";
        }
    }
}