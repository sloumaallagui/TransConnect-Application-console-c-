using interfaces;
namespace classes
{
    public class Client : Personne, ISerialisable
    {
        public string NumClient { get; set; }
        public string ville { get; set; }
        public double montantAchatComule { get; set; }

        public Client(string nss, string nom, string prenom, DateTime dateNaissance, string adressePostale, string email, string telephone, string numClient, string ville) : base(nss, nom, prenom, dateNaissance, adressePostale, email, telephone)
        {
            this.NumClient = numClient;
            this.ville = ville;
            this.montantAchatComule = 0;
        }
        public override string ToString()
        {
            return $"{Nss},{Nom},{Prenom},{DateNaissance},{AdressePostale},{Email},{Telephone},{NumClient},{ville},{montantAchatComule}";
        }
        public void incrementMontantAchatComule(double montantAchat)
        {
            montantAchatComule += montantAchat;
        }

        public void updateClient(string nom, string adressePostale, string email, string telephone)
        {
            Console.WriteLine("updateClient");
            if (nom != null && nom != "")
                Nom = nom;
            if (adressePostale != null && adressePostale != "")
                AdressePostale = adressePostale;
            if (email != null && email != "")
                Email = email;
            if (telephone != null && telephone != "")
                Telephone = telephone;
        }



    }
}


