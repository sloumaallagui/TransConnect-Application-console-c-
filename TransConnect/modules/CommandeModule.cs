
using System;
using classes;
namespace CommandeModule
{
    static class Commandes
    {
        public static void addCommande(string nssClient, string nssChauffeur, DateTime dateCommande, string villeDepart, string villeArrivee, Vehicule vehicule, double montant)
        {

            if (nssClient == null || nssChauffeur == null || dateCommande == null || villeDepart == null || villeArrivee == null || vehicule == null || montant == 0)
            {
                throw new Exception("Veuillez remplir tous les champs");
            }
            else
            {
                if (!File.Exists("commandes.txt"))
                {
                    File.Create("commandes.txt");
                }
                Commande commande = new Commande(nssClient, nssChauffeur, dateCommande, villeDepart, villeArrivee, vehicule, montant);
                File.AppendAllText("commandes.txt", commande.ToString());
            }
        }
        public static void deleteCommande(string nssClient)
        {
            if (!File.Exists("commandes.txt"))
            {
                FileStream f = File.Create("commandes.txt");
                f.Close();
            }
            else
            {
                string[] lines = File.ReadAllLines("commandes.txt");

                using (StreamWriter sw = new StreamWriter("commandes.txt"))
                {
                    bool test = false;
                    int i = 0;
                    foreach (string line in lines)
                    {
                        if (i % 2 == 0 )
                        {
                            string[] words = line.Split(',');
                            if (words[0] != nssClient)
                            {
                                sw.WriteLine(line);
                                test = true;
                            }
                        }
                        else if (i % 2 != 0 && !test)
                        {
                            sw.WriteLine(line);
                            test = false;
                        }
                        i++;
                    }

                }
            }


        }

        public static void printCommandesByClient(string nssClient)
        {
            if (!File.Exists("commandes.txt"))
            {
                FileStream f = File.Create("commandes.txt");
                f.Close();
            }
            if (File.Exists("commandes.txt") && new FileInfo("commandes.txt").Length != 0)
            {
                using (StreamReader sr = new StreamReader("commandes.txt"))
                {
                    string line;
                    int i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {   string[] words= line.Split(',');;
                        if (i % 2 == 0 && words.Length >= 6)
                        {
                            
                            if (words[0] == nssClient)
                            {
                                Console.WriteLine($"NssClient: {words[0]}");
                                Console.WriteLine($"NssChauffeur: {words[1]}");
                                Console.WriteLine($"DateCommande: {words[2]}");
                                Console.WriteLine($"VilleDepart: {words[3]}");
                                Console.WriteLine($"VilleArrivee: {words[4]}");
                                Console.WriteLine($"Montant: {words[5]}");
                            }
                            i++;
                        }
                        else
                        {
                            
                            if (words[0] == "CamionCiterne")
                            {
                                Console.WriteLine($" CamionCiterne : Type de camion: {words[1]} ");
                            }
                            else if (words[0] == "CamionBenne")
                            {
                                Console.WriteLine($"CamionBenne : nombre de benne : {words[1]} gru : {words[2]}");
                            }
                            else if (words[0] == "CamionFrigorifique")
                            {
                                Console.WriteLine($"CamionFrigorifique : Nombre de groupe : {words[1]} langeur distance {words[2]}");
                            }
                            else if (words[0] == "Voiture")
                            {
                                Console.WriteLine($"Voiture: Nombre de passages: {words[1]}");
                            }
                            i++;
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Aucune commande");
            }
        }


        public static void printCommandesByDate(DateTime deb, DateTime fin)
        {
            if (!File.Exists("commandes.txt"))
            {
                FileStream f = File.Create("commandes.txt");
                f.Close();
            }
            if (File.Exists("commandes.txt") && new FileInfo("commandes.txt").Length != 0)
            {
                using (StreamReader sr = new StreamReader("commandes.txt"))
                {
                    string line;
                    int i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] words = line.Split(',');
                        if (i % 2 == 0 && words.Length >= 6)
                        {
                            
                            if (DateTime.Parse(words[2]) >= deb && DateTime.Parse(words[2]) <= fin)
                            {
                                Console.WriteLine($"NssClient: {words[0]}");
                                Console.WriteLine($"NssChauffeur: {words[1]}");
                                Console.WriteLine($"DateCommande: {words[2]}");
                                Console.WriteLine($"VilleDepart: {words[3]}");
                                Console.WriteLine($"VilleArrivee: {words[4]}");
                                Console.WriteLine($"Montant: {words[5]}");
                            }
                            i++;
                        }
                        else
                        {
                            
                            if (words[0] == "CamionCiterne")
                            {
                                Console.WriteLine($" CamionCiterne : Type de camion: {words[1]} ");
                            }
                            else if (words[0] == "CamionBenne")
                            {
                                Console.WriteLine($"CamionBenne : nombre de benne : {words[1]} gru : {words[2]}");
                            }
                            else if (words[0] == "CamionFrigorifique")
                            {
                                Console.WriteLine($"CamionFrigorifique : Nombre de groupe : {words[1]} langeur distance {words[2]}");
                            }
                            else if (words[0] == "Voiture")
                            {
                                Console.WriteLine($"Voiture: Nombre de passages: {words[1]}");
                            }
                            i++;
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Aucune commande");
            }
        }

        public static void printCommandesByChauffeur(string nssChauffeur)
        {
            if (!File.Exists("commandes.txt"))
            {
                FileStream f = File.Create("commandes.txt");
                f.Close();
            }
            if (File.Exists("commandes.txt") && new FileInfo("commandes.txt").Length != 0)
            {
                using (StreamReader sr = new StreamReader("commandes.txt"))
                {
                    string line;
                    int i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] words=line.Split(',');;
                        if (i % 2 == 0&& words.Length >= 6)
                        {
                          
                            if (words[1] == nssChauffeur)
                            {
                                Console.WriteLine($"NssClient: {words[0]}");
                                Console.WriteLine($"NssChauffeur: {words[1]}");
                                Console.WriteLine($"DateCommande: {words[2]}");
                                Console.WriteLine($"VilleDepart: {words[3]}");
                                Console.WriteLine($"VilleArrivee: {words[4]}");
                                Console.WriteLine($"Montant: {words[5]}");
                            }
                            i++;
                        }
                        else
                        {
                           
                            if (words[0] == "CamionCiterne")
                            {
                                Console.WriteLine($" CamionCiterne : Type de camion: {words[1]} ");
                            }
                            else if (words[0] == "CamionBenne")
                            {
                                Console.WriteLine($"CamionBenne : nombre de benne : {words[1]} gru : {words[2]}");
                            }
                            else if (words[0] == "CamionFrigorifique")
                            {
                                Console.WriteLine($"CamionFrigorifique : Nombre de groupe : {words[1]} langeur distance {words[2]}");
                            }
                            else if (words[0] == "Voiture")
                            {
                                Console.WriteLine($"Voiture: Nombre de passages: {words[1]}");
                            }
                            i++;
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Aucune commande");
            }
        }
        public static double MoyennePrixCommande()
        {
            double prixMoyenne = 0;
            if (!File.Exists("commandes.txt"))
            {
                FileStream f = File.Create("commandes.txt");
                f.Close();
            }
            if (File.Exists("commandes.txt") && new FileInfo("commandes.txt").Length != 0)
            {
                using (StreamReader sr = new StreamReader("commandes.txt"))
                {
                    string line;
                    int i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] words = line.Split(',');
                        if (i % 2 == 0 && words.Length >= 6)
                        {

                            prixMoyenne = prixMoyenne + double.Parse(words[5]);
                            i++;
                        }

                    }
                }
            }
            return prixMoyenne;
        }


        public static int getNumberOfCommande()
        {
            int numberOfCommande = 0;
            if (!File.Exists("commandes.txt"))
            {
                FileStream f = File.Create("commandes.txt");
                f.Close();
            }
            if (File.Exists("commandes.txt") && new FileInfo("commandes.txt").Length != 0)
            {
                using (StreamReader sr = new StreamReader("commandes.txt"))
                {
                    string line;
                    int i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] words = line.Split(',');;
                        if (i % 2 == 0 && words.Length>=6)
                        {

                            numberOfCommande++;
                            i++;
                        }

                    }
                }
            }
            return numberOfCommande;
        }
        // Afficher les commandes d'ajourd'hui 
        public static void printCommandesToday()
        {   Console.WriteLine("Commandes d'aujourd'hui le : " + DateTime.Now.ToString("dd/MM/yyyy") + " :");
            if (!File.Exists("commandes.txt"))
            {
                FileStream f = File.Create("commandes.txt");
                f.Close();
            }
            if (File.Exists("commandes.txt") && new FileInfo("commandes.txt").Length != 0)
            {
                using (StreamReader sr = new StreamReader("commandes.txt"))
                {
                    string line;
                    int i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] words;
                        if (i % 2 == 0)
                        {   
                            words = line.Split(',');
                            if (words[2].IndexOf(DateTime.Now.ToString("dd/MM/yyyy"))!= -1 && words.Length>=6)
                            {
                                Console.WriteLine($"NssClient: {words[0]}");
                                Console.WriteLine($"NssChauffeur: {words[1]}");
                                Console.WriteLine($"DateCommande: {words[2]}");
                                Console.WriteLine($"VilleDepart: {words[3]}");
                                Console.WriteLine($"VilleArrivee: {words[4]}");
                                Console.WriteLine($"Montant: {words[5]}");
                            }else if (words[2].IndexOf(DateTime.Now.ToString("dd/MM/yyyy")) == -1)
                            {
                                Console.WriteLine("Aucune commande d'aujourd'hui");
                            }
                            i++;
                        }
                        

                    }
                }
            }
            else
            {
                Console.WriteLine("Aucune commande");
            }
        }
        public static void printCommandes()
        {
            if (!File.Exists("commandes.txt"))
            {
                FileStream f = File.Create("commandes.txt");
                f.Close();
            }

            if (File.Exists("commandes.txt") && new FileInfo("commandes.txt").Length != 0)
            {

                using (StreamReader sr = new StreamReader("commandes.txt"))
                {
                    string line;
                    int i = 0;

                    while ((line = sr.ReadLine()) != null)
                    {

                        string[] words = line.Split(',');
                        if (i % 2 == 0 && words.Length>=6)
                        {
                            
                            Console.WriteLine($"NssClient: {words[0]}");
                            Console.WriteLine($"NssChauffeur: {words[1]}");
                            Console.WriteLine($"DateCommande: {words[2]}");
                            Console.WriteLine($"VilleDepart: {words[3]}");
                            Console.WriteLine($"VilleArrivee: {words[4]}");
                            Console.WriteLine($"Montant: {words[5]}");
                            i++;
                        }
                        else
                        {
                            
                            Console.WriteLine($"Type de vehicule: {words[0]}");
                            if (words[0] == "CamionCiterne")
                            {
                                Console.WriteLine($" CamionCiterne : Type de camion: {words[1]} ");
                            }
                            else if (words[0] == "CamionBenne")
                            {
                                Console.WriteLine($"CamionBenne : nombre de benne : {words[1]} gru : {words[2]}");
                            }
                            else if (words[0] == "CamionFrigorifique")
                            {
                                Console.WriteLine($"CamionFrigorifique : Nombre de groupe : {words[1]} langeur distance {words[2]}");
                            }
                            else if (words[0] == "Voiture")
                            {
                                Console.WriteLine($"Voiture: Nombre de passages: {words[1]}");
                            }
                            i++;
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("il n'y a pas de commandes pour le moments");
            }


        }
    }

}
