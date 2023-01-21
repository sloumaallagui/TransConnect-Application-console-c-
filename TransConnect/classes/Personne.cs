
using System;
using interfaces;

namespace classes{
 public class Personne: ISerialisable
    {
         public string Nss { get; set; }
         public string Nom { get; set; }
         public string Prenom { get; set; }
         public DateTime DateNaissance { get; set; }
         public string AdressePostale { get; set; }
         public string Email { get; set; }
         public string Telephone { get; set; }
           public Personne() { }
           public Personne(string nss, string nom, string prenom, DateTime dateNaissance, string adressePostale, string email, string telephone)
           {
                Nss = nss;
                Nom = nom;
                Prenom = prenom;
                DateNaissance = dateNaissance;
                AdressePostale = adressePostale;
                Email = email;
                Telephone = telephone;
           }
       
               public void update(string nom, string adressePostale, string email, string telephone)
              {
       
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