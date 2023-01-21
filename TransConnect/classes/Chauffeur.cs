
using System;
using interfaces;

namespace classes
{  
    // make class  implement interface IAffichable


    public class Chauffeur :Salarie ,ISerialisable
    {

        public string Nss { get; set; }
        public Boolean Disponible { get; set; }
        public Chauffeur() { }
        public Chauffeur(string nss, Boolean disponible)
        {
            Nss = nss;
            Disponible = disponible;
        }
        public override string ToString()
        {
            return $"{Nss},{Disponible}";
        }
        public static void initChauffeur()
        {
            if (!File.Exists("chauffeur.txt"))
            {
                File.Create("chauffeur.txt");
            }

            List<Salarie> salaries = new List<Salarie>();

            List<Chauffeur> chauffeurs = new List<Chauffeur>();

            using (StreamReader sr = new StreamReader("salaries.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(',');
                    Salarie salarie = new Salarie(words[0], words[1], words[2], DateTime.Parse(words[3]), words[4], words[5], words[6], DateTime.Parse(words[7]), double.Parse(words[8]), words[9]);
                    salaries.Add(salarie);
                }
            }
            using (StreamReader sr = new StreamReader("chauffeur.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(',');
                    Chauffeur chauffeur = new Chauffeur(words[0], Boolean.Parse(words[1]));
                    chauffeurs.Add(chauffeur);
                }
            }
            List<Chauffeur> chauffeursToAdd = new List<Chauffeur>();
            foreach (Salarie salarie in salaries)
            {
                if (salarie.Poste == "chauffeur")
                {
                    Chauffeur chauffeur = new Chauffeur(salarie.Nss, true);
                    chauffeursToAdd.Add(chauffeur);
                }
            }

            foreach (Chauffeur chauffeur in chauffeursToAdd)
            {
                if (chauffeurs.Find(x => x.Nss == chauffeur.Nss) == null)
                {
                    chauffeurs.Add(chauffeur);
                }

            }
            using (StreamWriter sw = new StreamWriter("chauffeur.txt"))
            {
                foreach (Chauffeur chauffeur in chauffeurs)
                {
                    sw.WriteLine(chauffeur);
                }
            }

        }

        public static void changeDisponible(string nss)
        {

            List<Chauffeur> chauffeurs = new List<Chauffeur>();

            using (StreamReader sr = new StreamReader("chauffeur.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(',');
                    Chauffeur chauffeur = new Chauffeur(words[0], Boolean.Parse(words[1]));
                    chauffeurs.Add(chauffeur);
                }
            }
            foreach (Chauffeur chauffeur in chauffeurs)
            {
                if (chauffeur.Nss == nss)
                {
                    chauffeur.Disponible = false;
                }
            }
            using (StreamWriter sw = new StreamWriter("chauffeur.txt"))
            {
                foreach (Chauffeur chauffeur in chauffeurs)
                {
                    sw.WriteLine(chauffeur);
                }
            }
        }
        public static void Afficher()
        {
            List<Salarie> salaries = new List<Salarie>();
            List<Chauffeur> chauffeurs = new List<Chauffeur>();
            using (StreamReader sr = new StreamReader("salaries.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(',');
                    Salarie salarie = new Salarie(words[0], words[1], words[2], DateTime.Parse(words[3]), words[4], words[5], words[6], DateTime.Parse(words[7]), double.Parse(words[8]), words[9]);
                    salaries.Add(salarie);
                }
            }
            using (StreamReader sr = new StreamReader("chauffeur.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(',');
                    Chauffeur chauffeur = new Chauffeur(words[0], Boolean.Parse(words[1]));
                    chauffeurs.Add(chauffeur);
                }
            }
            foreach (Chauffeur chauffeur in chauffeurs)
            {
                foreach (Salarie salarie in salaries)
                {
                    if (chauffeur.Nss == salarie.Nss)
                    {
                        Console.WriteLine(salarie.Nss + " " + salarie.Nom + " " + salarie.Prenom);
                    }
                }
            }
        }
    }
}







