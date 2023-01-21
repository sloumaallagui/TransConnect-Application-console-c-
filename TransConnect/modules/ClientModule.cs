
using System;
using classes;
namespace ClientModule
{


    static class Clients
    {
        public static void initClients()
        {
            if (!File.Exists("Client.txt"))
            {

                File.Create("Client.txt");

            }
        }


        public static void addClient(Client client)
        {
            File.AppendAllText("Client.txt", client.ToString() + "\n");

        }

        public static void printRemises()
        {
            if (!File.Exists("remises.txt"))
            {
                FileStream f = File.Create("remises.txt");
                f.Close();
            }
            string[] lines = File.ReadAllLines("remises.txt");
            foreach (string line in lines)
            {
                string[] remiseData = line.Split(',');
                Client client = getClientByNSS(remiseData[0]);
                Console.WriteLine("Remise à " + remiseData[1] + "\n" + client);
            }
        }
        public static double getRemiseByNSS(string nss)
        {
            string[] lines = File.ReadAllLines("remises.txt");
            foreach (string line in lines)
            {
                string[] remiseData = line.Split(',');
                if (remiseData[0] == nss)
                {
                    return double.Parse(remiseData[1]);
                }
            }
            return 0;
        }

        public static void removeClient(Client client)
        {
            string[] lines = File.ReadAllLines("Client.txt");
            File.WriteAllText("Client.txt", string.Empty);
            foreach (string line in lines)
            {
                if (line != client.ToString())
                {
                    File.AppendAllText("Client.txt", line);
                }
            }
        }

        public static Client findClientByNomAndPrenom(string nom, string prenom)
        {
            string[] lines = File.ReadAllLines("Client.txt");
            foreach (string line in lines)
            {
                string[] clientData = line.Split(',');
                if (clientData[1] == nom && clientData[2] == prenom)
                {
                    return new Client(clientData[0], clientData[1], clientData[2], DateTime.Parse(clientData[3]), clientData[4], clientData[5], clientData[6], clientData[7], clientData[8]);
                }
            }
            return null;
        }
        public static void updateClient(Client client)
        {
            string[] lines = File.ReadAllLines("Client.txt");
            File.WriteAllText("Client.txt", string.Empty);
            foreach (string line in lines)
            {
                string[] clientData = line.Split(',');
                if (clientData[0] == client.Nss)
                {
                    File.AppendAllText("Client.txt", client.ToString() + "\n");
                }
                else
                {
                    File.AppendAllText("Client.txt", line + "\n");
                }
            }
        }

        public static void deleteClient(string nss)
        {
            string[] lines = File.ReadAllLines("Client.txt");
            File.WriteAllText("Client.txt", string.Empty);
            foreach (string line in lines)
            {
                string[] clientData = line.Split(',');
                if (clientData[0] != nss)
                {
                    File.AppendAllText("Client.txt", line + "\n");
                }
            }
        }

        public static List<Client> getAllClients()
        {
            List<Client> clients = new List<Client>();
            string[] lines = File.ReadAllLines("Client.txt");
            foreach (string line in lines)
            {
                string[] clientData = line.Split(',');
                Client client = new Client(clientData[0], clientData[1], clientData[2], Convert.ToDateTime(clientData[3]), clientData[4], clientData[5], clientData[6], clientData[7], clientData[8]);
                client.montantAchatComule = Double.Parse(clientData[9]);
                clients.Add(client);

            }
            return clients;

        }

        public static string generateNumClient()
        {
            List<Client> clients = getAllClients();
            int max = 0;
            foreach (Client client in clients)
            {
                if (int.Parse(client.NumClient) > max)
                {
                    max = int.Parse(client.NumClient);
                }
            }
            return (max + 1).ToString();
        }


        public static List<Client> getClientsByName()
        {
            List<Client> clients = new List<Client>();
            string[] lines = File.ReadAllLines("Client.txt");
            foreach (string line in lines)
            {
                string[] clientData = line.Split(',');
                Client client = new Client(clientData[0], clientData[1], clientData[2], Convert.ToDateTime(clientData[3]), clientData[4], clientData[5], clientData[6], clientData[7], clientData[8]);
                client.montantAchatComule = Double.Parse(clientData[9]);
                clients.Add(client);

            }
            clients.Sort((x, y) => x.Nom.CompareTo(y.Nom));
            return clients;
        }


        public static List<Client> getClientsByVille()
        {
            List<Client> clients = new List<Client>();
            string[] lines = File.ReadAllLines("Client.txt");
            foreach (string line in lines)
            {
                string[] clientData = line.Split(',');
                Client client = new Client(clientData[0], clientData[1], clientData[2], Convert.ToDateTime(clientData[3]), clientData[4], clientData[5], clientData[6], clientData[7], clientData[8]);
                client.montantAchatComule = Double.Parse(clientData[9]);
                clients.Add(client);

            }
            clients.Sort((x, y) => x.ville.CompareTo(y.ville));
            return clients;

        }

        public static List<Client> getClientsByMontantAchatComule()
        {
            List<Client> clients = new List<Client>();
            string[] lines = File.ReadAllLines("Client.txt");
            foreach (string line in lines)
            {
                string[] clientData = line.Split(',');
                Client client = new Client(clientData[0], clientData[1], clientData[2], Convert.ToDateTime(clientData[3]), clientData[4], clientData[5], clientData[6], clientData[7], clientData[8]);
                client.montantAchatComule = Double.Parse(clientData[9]);
                clients.Add(client);

            }
            clients.Sort((x, y) => y.montantAchatComule.CompareTo(x.montantAchatComule));
            return clients;
        }

        public static List<Client> getClientsByVilleAndMontantAchatComuleAndNom()
        {
            List<Client> clients = new List<Client>();
            string[] lines = File.ReadAllLines("Client.txt");

            foreach (string line in lines)
            {
                string[] clientData = line.Split(',');
                Client client = new Client(clientData[0], clientData[1], clientData[2], Convert.ToDateTime(clientData[3]), clientData[4], clientData[5], clientData[6], clientData[7], clientData[8]);
                client.montantAchatComule = Double.Parse(clientData[9]);
                clients.Add(client);

            }

            clients.Sort((x, y) => x.ville.CompareTo(y.ville));
            clients.Sort((x, y) => x.Nom.CompareTo(y.Nom));
            clients.Sort((x, y) => y.montantAchatComule.CompareTo(y.montantAchatComule));
            return clients;
        }
        public static Client getClientByNSS(string nss)
        {
            string[] lines = File.ReadAllLines("Client.txt");
            foreach (string line in lines)
            {
                string[] clientData = line.Split(',');
                if (clientData[0] == nss)
                {
                    Client client = new Client(clientData[0], clientData[1], clientData[2], DateTime.Parse(clientData[3]), clientData[4], clientData[5], clientData[6], clientData[7], clientData[8]);
                    client.montantAchatComule = Double.Parse(clientData[9]);
                    return client;
                }
            }
            return null;
        }

        public static int getNumberOfClients()
        {
            string[] lines = File.ReadAllLines("Client.txt");
            return lines.Length;
        }
        public static void addRemise(double remise, string nss)
        {
            if (!File.Exists("remises.txt"))
            {
                FileStream f = File.Create("remises.txt");
                f.Close();

            }
            string[] lines = File.ReadAllLines("remises.txt");
            File.WriteAllText("remises.txt", string.Empty);
            foreach (string line in lines)
            {
                string[] remiseData = line.Split(',');
                if (remiseData[0] != nss)
                {
                    File.AppendAllText("remises.txt", line + "\n");
                }
                else
                {
                    remise = remise + double.Parse(remiseData[1]);
                }
            }

            File.AppendAllText("remises.txt", nss + "," + remise.ToString() + "\n");




        }


        public static void getClientWithMaxMontantAchatComule()
        {
            string[] lines = File.ReadAllLines("Client.txt");
            Client client = null;
            double max = 0;
            if(lines.Length > 0)
            foreach (string line in lines)
            {
                string[] clientData = line.Split(',');
                if (Double.Parse(clientData[9]) >= max)
                {   
                    max = Double.Parse(clientData[9]);
                    client = new Client(clientData[0], clientData[1], clientData[2], Convert.ToDateTime(clientData[3]), clientData[4], clientData[5], clientData[6], clientData[7], clientData[8]);
                    client.montantAchatComule = Double.Parse(clientData[9]);
                }
            }
           Console.WriteLine("le client qui a le plus d'achat est : " + client.Nom+ " "+ client.Prenom);
        }

        public static void MoyennePrixCommandeByClient(string nss)
        {
            string[] lines = File.ReadAllLines("Commande.txt");
            double somme = 0;
            int nbrCommande = 0;
            foreach (string line in lines)
            {
                string[] commandeData = line.Split(',');
                if (commandeData[0] == nss)
                {
                    somme += Double.Parse(commandeData[2]);
                    nbrCommande++;
                }
            }
            Console.WriteLine("la moyenne des prix des commandes est : " + somme / nbrCommande);
        }

        public static List<Client> getClientsWithRemise()
        {
            List<Client> clients = new List<Client>();
            string[] lines = File.ReadAllLines("Client.txt");
            foreach (string line in lines)
            {
                string[] clientData = line.Split(',');
                Client client = new Client(clientData[0], clientData[1], clientData[2], Convert.ToDateTime(clientData[3]), clientData[4], clientData[5], clientData[6], clientData[7], clientData[8]);
                client.montantAchatComule = Double.Parse(clientData[9]);
                clients.Add(client);

            }
            List<Client> clientsWithRemise = new List<Client>();
            string[] remises = File.ReadAllLines("remises.txt");
            foreach (string remise in remises)
            {
                string[] remiseData = remise.Split(',');
                foreach (Client client in clients)
                {
                    if (client.Nss == remiseData[0])
                    {
                        clientsWithRemise.Add(client);
                    }
                }
            }
            return clientsWithRemise;
        }





    }

}