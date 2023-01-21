
using System;
using ClientModule;
using classes;
using SalarieModule;
using static System.ConsoleColor;




internal class Program
{
    private static void Main(string[] args)
    {
    menu_principal:
        Console.WriteLine("Tapez la commande que vous voulez executer");
        Console.WriteLine("1- Module  client:");
        Console.WriteLine("2- Module salarie:");
        Console.WriteLine("3- Module commande");
        Console.WriteLine("4- Module statistique");
        Console.WriteLine("5- Module Autre");
        Console.WriteLine("*********************************************");
        Console.WriteLine("Entrez le numéro de module souhaité :       (Pour quitter Entrez 10 )");

        int choix;
        while (int.TryParse(Console.ReadLine(), out choix) == false)
        {
            Console.Clear();
            Console.WriteLine("Erreur de saisie");
            goto menu_principal;
        }
        if (choix == 1)
        {
        menu_client:
            Console.Clear();
            ClientModule.Clients.initClients();
            Console.WriteLine("1- Ajouter un client");
            Console.WriteLine("2- Modifier un client");
            Console.WriteLine("3- Supprimer un client");
            Console.WriteLine("4- Afficher les clients par ordre alphabétique");
            Console.WriteLine("5- Afficher les clients par ville");
            Console.WriteLine("6- Afficher les clients par Montant Achat commulé");
            Console.WriteLine("7- Afficher les clients par ville et par ordre alphabétique et par Montant Achat commulé simultanément");
            Console.WriteLine("8- Rechercher un client par son nom et son prenom");
            Console.WriteLine("9- Retour");
            int choix1;
            while (int.TryParse(Console.ReadLine(), out choix1) == false)
            {
                Console.Clear();
                Console.WriteLine("Erreur de saisie");
                goto menu_client;
            }
            Console.Clear();
            if (choix1 == 1)
            {
                Console.WriteLine("Tapez le nom du client");
                string nom = Console.ReadLine();
                Console.WriteLine("Tapez le prenom du client");
                string prenom = Console.ReadLine();
                DateTime dateNaissanceClient;
                Console.WriteLine("Tapez la date de naissance du client");
                string dateNaissance = Console.ReadLine();
                while (DateTime.TryParse(dateNaissance, out dateNaissanceClient) == false)
                {
                    Console.WriteLine("Date fausse ,Tapez la date de naissance du salarié");
                    dateNaissance = Console.ReadLine();
                }
                dateNaissanceClient = DateTime.Parse(dateNaissance);
                Console.WriteLine("Tapez l'adresse postale du client");
                string adressePostale = Console.ReadLine();
                Console.WriteLine("Tapez l'email du client");
                string email = Console.ReadLine();
                Console.WriteLine("Tapez le telephone du client");
                string telephone = Console.ReadLine();
                Console.WriteLine("Tapez le ville du client");
                string ville = Console.ReadLine();
                Console.WriteLine("Tapez le numero de securite sociale du client");
                string nss = Console.ReadLine();
                ClientModule.Clients.addClient(new Client(nss, nom, prenom, dateNaissanceClient, adressePostale, email, telephone, numClient: ClientModule.Clients.generateNumClient(), ville));
                Console.WriteLine("Client ajouté");
                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_client;

            }
            else if (choix1 == 2)
            {
                Console.WriteLine("Tapez le numero de securite sociale du client");
                string nss = Console.ReadLine();
                Client oldCClient = ClientModule.Clients.getClientByNSS(nss);
                Console.WriteLine("Tapez le nom du client");
                string nom = Console.ReadLine();


                Console.WriteLine("Tapez l'adresse postale du client");
                string adressePostale = Console.ReadLine();
                Console.WriteLine("Tapez l'email du client");
                string email = Console.ReadLine();
                Console.WriteLine("Tapez le telephone du client");
                string telephone = Console.ReadLine();

                oldCClient.updateClient(nom, adressePostale, email, telephone);
                Console.WriteLine("Client modifié" + oldCClient.ToString());
                ClientModule.Clients.updateClient(oldCClient);
                Console.WriteLine("Client modifié" + oldCClient.ToString());
                Console.WriteLine("Client modifié");
                Console.WriteLine(oldCClient.ToString());
                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_client;

            }
            else if (choix1 == 3)
            {
                Console.WriteLine("Tapez le numero de securite sociale du client");
                string nss = Console.ReadLine();
                ClientModule.Clients.deleteClient(nss);
                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_client;

            }
            else if (choix1 == 4)
            {
                Console.WriteLine("Affichage des clients par ordre alphabétique");
                List<Client> listClient = ClientModule.Clients.getClientsByName();
                foreach (Client client in listClient)
                {
                    Console.WriteLine(client.ToString() + " \n");
                }
                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_client;
            }
            else if (choix1 == 5)
            {
                Console.WriteLine("Affichage des clients par ville");
                string nss = Console.ReadLine();
                List<Client> listClient = ClientModule.Clients.getClientsByVille();
                foreach (Client client in listClient)
                {
                    Console.WriteLine(client.ToString() + "\n");
                }
                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_client;
            }
            else if (choix1 == 6)
            {
                Console.WriteLine("Affichage des clients par Montant Achat commulé");
                List<Client> listClient = ClientModule.Clients.getClientsByMontantAchatComule();
                foreach (Client client in listClient)
                {
                    Console.WriteLine(client.ToString() + " \n");
                }
                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_client;
            }
            else if (choix1 == 7)
            {
                Console.WriteLine("Affichage des clients par ville et par ordre alphabétique et par Montant Achat commulé simultanément");
                List<Client> listClient = ClientModule.Clients.getClientsByVilleAndMontantAchatComuleAndNom();
                foreach (Client client in listClient)
                {
                    Console.WriteLine(client.ToString() + " \n");
                }
                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_client;
            }
            else if (choix1 == 8)
            {
                Console.WriteLine("Rechercher un client par son nom et son prenom");
                Console.WriteLine("Tapez le nom du client");
                string nom = Console.ReadLine();
                Console.WriteLine("Tapez le prenom du client");
                string prenom = Console.ReadLine();
                Client client = ClientModule.Clients.findClientByNomAndPrenom(nom, prenom);
                if (client != null)
                {
                    Console.WriteLine("Client trouvé");
                    Console.WriteLine(client.ToString() + " \n");
                }
                else
                {
                    Console.WriteLine("Client non trouvé");
                }

                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_client;
            }
            else
            {
                Console.Clear();
                goto menu_principal;
            }
        }
        else if (choix == 2)
        {

        menu_salarie:
            Console.Clear();
            SalarieModule.Salaries.initSalaries();
            Console.WriteLine("Gestion des Salariés");
            Console.WriteLine("1- Ajouter un salarié");
            Console.WriteLine("2- Modifier un salarié");
            Console.WriteLine("3- Supprimer un salarié");
            Console.WriteLine("4- Afficher l'arbre des salariés");
            Console.WriteLine("5- Chercher un salarié par nss");
            Console.WriteLine("6- Afficher les salariés par ordre de salaire");
            Console.WriteLine("7- Retour au menu principal");
            int choix2;
            while (int.TryParse(Console.ReadLine(), out choix2) == false)
            {
                Console.Clear();
                Console.WriteLine("Erreur de saisie , Tapez le numero de votre choix");
                goto menu_salarie;

            }
            if (choix2 == 1)
            {
            ajoute_salarie:
                // read salarie 
                Console.Clear();
                Console.WriteLine("Tapez le nom du salarié");
                string nom = Console.ReadLine();
                Console.WriteLine("Tapez le prenom du salarié");
                string prenom = Console.ReadLine();

                Console.WriteLine("Tapez la date de naissance du salarié");
                string dateNaissance = Console.ReadLine();
                DateTime dateNaissanceSalarie;
                while (DateTime.TryParse(dateNaissance, out dateNaissanceSalarie) == false)
                {
                    Console.WriteLine("Date fausse , Tapez la date de naissance du salarié");
                    dateNaissance = Console.ReadLine();
                }
                dateNaissanceSalarie = DateTime.Parse(dateNaissance);
                Console.WriteLine("Tapez l'adresse postale du salarié");
                string adressePostale = Console.ReadLine();
                Console.WriteLine("Tapez l'email du salarié");
                string email = Console.ReadLine();
                Console.WriteLine("Tapez le telephone du salarié");
                string telephone = Console.ReadLine();
                Console.WriteLine("Tapez le salaire du salarié");
                double salaire = double.Parse(Console.ReadLine());
                Console.WriteLine("Tapez le numero de securite sociale du salarié");
                string nss = Console.ReadLine();
                Console.WriteLine("Tapez la poste  du salarié");
                string poste = Console.ReadLine();



                if (SalarieModule.Salaries.findSalarieByNSS(nss) != null)
                {
                    Console.WriteLine("Salarie existe deja");
                    Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                    Console.ReadLine();
                    Console.Clear();
                    goto menu_salarie;
                }
                else
                {
                    Salarie salarie = new Salarie(nss, nom, prenom, dateNaissanceSalarie, adressePostale, email, telephone, DateTime.Now, salaire, poste);
                    // add salarie to list
                    SalarieModule.Salaries.addSalarie(salarie);
                    Console.WriteLine("Salarie ajouté");
                    Console.WriteLine(salarie?.ToString());
                    SalarieModule.Salaries.saveSalaries(SalarieModule.Salaries.getRoot());
                    Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                    Console.ReadLine();
                    Console.Clear();
                    goto menu_salarie;
                }

            }
            else if (choix2 == 2)
            {
                Console.Clear();
                Console.WriteLine("Tapez le numero de securite sociale du salarié");
                string nss = Console.ReadLine();
                Salarie salarie = SalarieModule.Salaries.findSalarieByNSS(nss);
                Console.WriteLine("Tapez le nom du salarié");
                string nom = Console.ReadLine();
                Console.WriteLine("Tapez le prenom du salarié");
                string prenom = Console.ReadLine();
                Console.WriteLine("Tapez l'adresse postale du salarié");
                string adressePostale= Console.ReadLine();
                Console.WriteLine("Tapez l'email du salarié");
                string email = Console.ReadLine();
                Console.WriteLine("Tapez le telephone du salarié");
                string telephone = Console.ReadLine();
                Console.WriteLine(" Tapez poste de salarié");
                string poste = Console.ReadLine();
                Console.WriteLine(" Tapez salaire de salarié");
                string salaire = Console.ReadLine();
             
                salarie.Nom = nom ?? salarie.Nom;
                salarie.Prenom = prenom ?? salarie.Prenom;
                salarie.Telephone = telephone ?? salarie.Telephone;
                salarie.Email = email ?? salarie.Email;
                salarie.AdressePostale = adressePostale ?? salarie.AdressePostale;




                SalarieModule.Salaries.updateSalarie(salarie);
                Console.WriteLine("Salarie modifié");
                Console.WriteLine(salarie.ToString());
                SalarieModule.Salaries.saveSalaries(SalarieModule.Salaries.getRoot());
                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_salarie;
            }
            else if (choix2 == 3)
            {
                Console.Clear();
                Console.WriteLine("Tapez le numéro de securite sociale du salarié NSS");
                string nss = Console.ReadLine();
                Salarie salarie = SalarieModule.Salaries.findSalarieByNSS(nss);
                SalarieModule.Salaries.removeSalarie(nss);
                SalarieModule.Salaries.saveSalaries(SalarieModule.Salaries.getRoot());
                Console.WriteLine("Salarie supprimé : " + salarie?.ToString());
                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_salarie;
            }
            else if (choix2 == 4)
            {
                Console.Clear();
                Console.WriteLine("Affichage de l'arbre des salariés :");
                SalarieModule.Salaries.printSalaries(SalarieModule.Salaries.getRoot(), 0);
                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_salarie;
            }
            else if (choix2 == 5)
            {
                Console.Clear();
                Console.WriteLine("Chercher un salarié par nss :");
                Console.WriteLine("Tapez le numero nss du salarié");
                int nss;
                while (!int.TryParse(Console.ReadLine(), out nss))
                {
                    Console.WriteLine("Veuillez saisir un entier");
                }
                Salarie salarie = SalarieModule.Salaries.findSalarieByNSS(nss.ToString());
                Console.WriteLine("Salarie trouvé : ");
                Console.WriteLine(salarie?.ToString());
                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_salarie;
            }
            else if (choix2 == 6)
            {
                Console.Clear();
                Console.WriteLine("Affichage de l'arbre des salariés par ordre de salaire");
                List<Salarie> list = SalarieModule.Salaries.orderBySalaire(SalarieModule.Salaries.getAllSalaries(SalarieModule.Salaries.getRoot()));
                foreach (Salarie salarie in list)
                {
                    Console.WriteLine(salarie.ToString());
                }
                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_salarie;
            }
            else if (choix2 == 7)
            {
                Console.Clear();
                goto menu_principal;
            }
            else
            {
                Console.WriteLine("Commande non reconnue");
                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu salarié");
                Console.ReadLine();
                Console.Clear();
                goto menu_salarie;
            }
        }
        else if (choix == 3)
        {
        menu_commande:
            Console.Clear();
            Console.WriteLine("Module commandes");
            Console.WriteLine("1 - Ajouter une commande");
            Console.WriteLine("2 - Afficher les commandes");
            Console.WriteLine("3 - Afficher les chauffeur");
            Console.WriteLine("4 - Supprimer une commande");
            Console.WriteLine("5- Afficher les remises des client");
            Console.WriteLine("6- Ajouter un remise à un client");
            Console.WriteLine("7 - Retour au menu principal");

            int choix3;
            while (!int.TryParse(Console.ReadLine(), out choix3))
            {
                Console.WriteLine("Erreur de saisie");
            }

            if (choix3 == 1)
            {
                Console.Clear();
                Chauffeur.initChauffeur();
                Console.WriteLine("Ajouter une commande");
                Console.WriteLine("Tapez le numero nss du client");
                string nss = Console.ReadLine();
                Client client = ClientModule.Clients.getClientByNSS(nss);
                double prix = 0;
                if (client == null)
                {

                    Console.WriteLine("Tapez le nom du client");
                    string nom = Console.ReadLine();
                    Console.WriteLine("Tapez le prenom du client");
                    string prenom = Console.ReadLine();
                    DateTime dateNaissanceClient;
                    Console.WriteLine("Tapez la date de naissance du client");
                    string dateNaissance = Console.ReadLine();
                    while (DateTime.TryParse(dateNaissance, out dateNaissanceClient) == false)
                    {
                        Console.WriteLine("Date fausse ,Tapez la date de naissance du salarié");
                        dateNaissance = Console.ReadLine();
                    }
                    dateNaissanceClient = DateTime.Parse(dateNaissance);
                    Console.WriteLine("Tapez l'adresse postale du client");
                    string adressePostale = Console.ReadLine();
                    Console.WriteLine("Tapez l'email du client");
                    string email = Console.ReadLine();
                    Console.WriteLine("Tapez le telephone du client");
                    string telephone = Console.ReadLine();
                    Console.WriteLine("Tapez le ville du client");
                    string ville = Console.ReadLine();
                    Console.WriteLine("Tapez le numero de securite sociale du client");
                    nss = Console.ReadLine();
                    ClientModule.Clients.addClient(new Client(nss, nom, prenom, dateNaissanceClient, adressePostale, email, telephone, numClient: ClientModule.Clients.generateNumClient(), ville));
                    Console.WriteLine("Client ajouté");
                    Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                    Console.ReadLine();
                    Console.Clear();

                }

                Chauffeur.Afficher();
                Console.WriteLine("Tapez le numero du chauffeur");
                string numeroChauffeur = Console.ReadLine();

                Console.Clear();

                Console.WriteLine("Tapez le numero de la voiture");
                Console.WriteLine("Voiture disponible :");
                Console.WriteLine("1 - Voiture ");
                Console.WriteLine("2 - Camionnette");
                Console.WriteLine("3 - Camion citerne");
                Console.WriteLine("4 - Camion benne");
                Console.WriteLine("5 - Camion Frigorifique");

                Vehicule vehicule;
                int numeroVoiture;
                while (!int.TryParse(Console.ReadLine(), out numeroVoiture))
                {
                    Console.WriteLine("Erreur de saisie");
                    Console.WriteLine("Tapez le numero de la voiture");
                }
                if (numeroVoiture == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Voiture : ");
                    Console.WriteLine("Nomnbre de personnes : ");
                    int nombrePersonnes;
                    while (!int.TryParse(Console.ReadLine(), out nombrePersonnes) || nombrePersonnes < 1 || nombrePersonnes > 5)
                    {
                        Console.WriteLine("Nombre de personnes invalide");
                        Console.WriteLine("Nomnbre de personnes : ");
                    }
                    prix = Voiture.PRIX + nombrePersonnes * 10;
                    vehicule = new Voiture(nombrePersonnes);
                }
                else if (numeroVoiture == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Cammionette : ");
                    Console.WriteLine("usage : ");
                    string usage = Console.ReadLine();
                    vehicule = new Camionnette(usage);
                    prix = Camionnette.PRIX;
                }
                else if (numeroVoiture == 3)
                {
                    int typeCiterne;
                    Console.Clear();
                    Console.WriteLine("Camion citerne : ");
                    Console.WriteLine("Type de citerne : ");
                    while (!int.TryParse(Console.ReadLine(), out typeCiterne))
                    {
                        Console.WriteLine("Erreur de saisie");
                    }
                    vehicule = new CamionCiterne(typeCiterne);
                    prix = CamionCiterne.PRIX + typeCiterne * 10;
                }
                else if (numeroVoiture == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Camion à benne : ");
                    Console.WriteLine("Nombre de la benne : ");
                    int capaciteBenne;
                    while (!int.TryParse(Console.ReadLine(), out capaciteBenne))
                    {
                        Console.WriteLine("Erreur de saisie");
                    }
                    Boolean gru;
                    while (!Boolean.TryParse(Console.ReadLine(), out gru))
                    {
                        Console.WriteLine("Erreur de saisie");
                    }
                    vehicule = new CamionBenne(capaciteBenne, gru);
                    prix = CamionBenne.PRIX + capaciteBenne * 10;
                }
                else if (numeroVoiture == 5)
                {
                    Console.Clear();
                    Console.WriteLine("Camion Frigorifique  : ");
                    int NomnbreGroupe;
                    int langeurDistance;

                    Console.WriteLine("Nomnbre de groupe : ");
                    while (!int.TryParse(Console.ReadLine(), out NomnbreGroupe))
                    {
                        Console.WriteLine("Erreur de saisie");
                    }
                    Console.WriteLine("Langeur de distance : ");
                    while (!int.TryParse(Console.ReadLine(), out langeurDistance))
                    {
                        Console.WriteLine("Erreur de saisie");
                    }
                    prix = CamionFrigorifique.PRIX + NomnbreGroupe * 10 + langeurDistance * 10;
                    vehicule = new CamionFrigorifique(NomnbreGroupe, langeurDistance);
                }
                else
                {
                    Console.WriteLine("Erreur de saisie");
                    vehicule = null;
                }
                Console.WriteLine("Tapez la distination de la ville de depart");
                string villeDepart = Console.ReadLine();
                Console.WriteLine("Tapez la distination  de la ville d'arrivé");
                string villeArrive = Console.ReadLine();



                CommandeModule.Commandes.addCommande(nss, numeroChauffeur, DateTime.Now, villeDepart, villeArrive, vehicule, prix);
                Console.WriteLine("Commande ajouté");
                Console.WriteLine("Tapez n'importe quelle touche pour continuer");
                Console.Clear();
                goto menu_commande;




            }
            else if (choix3 == 2)
            {
                Console.Clear();
                Console.WriteLine("Afficher les commandes");
                CommandeModule.Commandes.printCommandes();
                Console.WriteLine("Tapez n'importe quelle touche pour continuer");
                Console.ReadLine();
                Console.Clear();
                goto menu_commande;
            }
            else if (choix3 == 3)
            {
                Console.Clear();
                Console.WriteLine("liste des chauffeur :");
                SalarieModule.Salaries.initSalaries();
                List<Salarie> list = SalarieModule.Salaries.getAllSalariesByPoste(SalarieModule.Salaries.getRoot(), "chauffeur");
                foreach (Salarie salarie in list)
                {
                    Console.WriteLine(salarie.ToString());
                }
                Console.WriteLine("Tapez n'importe quelle touche pour continuer");
                Console.ReadLine();
                Console.Clear();
                goto menu_commande;

            }
            else if (choix3 == 4)
            {
                Console.Clear();
                Console.WriteLine("Supprimer les commande d'un client");
                Console.WriteLine("Tapez le numero de la client");
                string numeroCommande;
                numeroCommande = Console.ReadLine();
                CommandeModule.Commandes.printCommandes();
                CommandeModule.Commandes.deleteCommande(numeroCommande);
                Console.WriteLine("Commande supprimé");
                Console.WriteLine("Tapez n'importe quelle touche pour continuer");
                Console.ReadLine();
                Console.Clear();
                goto menu_commande;


            }
            else if (choix3 == 5)
            {
                Console.Clear();
                Console.WriteLine("Afficher les remises des client");
                ClientModule.Clients.printRemises();
                Console.WriteLine("Tapez n'importe quelle touche pour continuer");
                Console.ReadLine();
                Console.Clear();
                goto menu_commande;

            }
            else if (choix3 == 6)
            {
                Console.Clear();
                Console.WriteLine("Ajouter un remise à un client");
                Console.WriteLine("Tapez le mantant de la remise");
                double remise = double.Parse(Console.ReadLine());
                Console.WriteLine("Tapez le numero nss de client");
                string nss;
                while ((nss = Console.ReadLine()) == null)
                {
                    Console.WriteLine("Erreur de saisie");
                }
                if (ClientModule.Clients.getClientByNSS(nss) == null)
                {
                    Console.WriteLine("Client n'existe pas");
                    Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                    Console.ReadLine();
                    Console.Clear();
                    goto menu_commande;
                }
                ClientModule.Clients.addRemise(remise, nss);
                Console.WriteLine("Remise ajouté");
                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_commande;
            }
            else if (choix3 == 7)
            {
                Console.Clear();
                goto menu_principal;
            }

        }
        else if (choix == 4)
        {
        menu_statistique:
            Console.Clear();
            Console.WriteLine("Module statistique");
            Console.WriteLine("1- Afficher les statistiques des commandes pour un client");
            Console.WriteLine("2- Afficher les commandes selon une periode de temps");
            Console.WriteLine("3- les commandes par chauffeur  ");
            Console.WriteLine("4- Afficher la moyenne des prix des commandes");
            Console.WriteLine("5- Retour au menu principal");

            Console.WriteLine("Tapez votre choix");
            int choix4 = int.Parse(Console.ReadLine());
            if (choix4 == 1)
            {
                Console.Clear();
                Console.WriteLine("Afficher les statistiques des commandes pour un client");
                Console.WriteLine("Tapez le numero nss du client");
                string nss;
                while ((nss = Console.ReadLine()) == null)
                {
                    Console.WriteLine("Erreur de saisie");
                }
                if (ClientModule.Clients.getClientByNSS(nss) == null)
                {
                    Console.WriteLine("Client n'existe pas");
                    Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                    Console.ReadLine();
                    Console.Clear();
                    goto menu_statistique;
                }
                ModuleStatistique.Statistique.PrintCommandeByClient(nss);
                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_statistique;
            }
            else if (choix4 == 2)
            {
                Console.Clear();
                Console.WriteLine("Afficher les commandes selon une periode de temps");
                Console.WriteLine("Tapez la date de debut");
                DateTime dateDebut = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Tapez la date de fin");
                DateTime dateFin = DateTime.Parse(Console.ReadLine());
                ModuleStatistique.Statistique.printCommandesByDate(dateDebut, dateFin);
                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_statistique;
            }
            else if (choix4 == 3)
            {

                Console.Clear();
                Console.WriteLine("les commandes par chauffeur ");
                string nssChauffeur;
                while ((nssChauffeur = Console.ReadLine()) == null)
                {
                    Console.WriteLine("Erreur de saisie");
                }
                ModuleStatistique.Statistique.printCommandesByChauffeur(nssChauffeur);
                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_statistique;
            }
            else if (choix4 == 4)
            {
                Console.Clear();
                Console.WriteLine("Afficher la moyenne des prix des commandes");
                ModuleStatistique.Statistique.MoyennePrixCommande();
                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_statistique;
            }
            else if (choix4 == 5)
            {

                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_principal;
            }


        }else if(choix == 5){
            menu_autre:
            Console.Clear();
            Console.WriteLine("1- Statistique totale de l'entreprise");
            Console.WriteLine("2- Le Client qui à le plus de montant d'achat cumulé");
            Console.WriteLine("3- Les commandes d'aujourd'hui");
            Console.WriteLine("4- Le Salarié qui à le plus Grand salaire");
            Console.WriteLine("5- Retour au menu principal");

            int choix5;
            while(int.TryParse(Console.ReadLine(),out choix5) == false){
                Console.WriteLine("Erreur de saisie");
            }
            if(choix5 == 1){
                Console.Clear();
                Console.WriteLine("Statistique totale de l'entreprise");
                AutreModule.Autre.StatistiqueTotale();
                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_autre;
            }else if(choix5 == 2){
                Console.Clear();
                Console.WriteLine("Le Client qui à le plus de montant d'achat cumulé");
                AutreModule.Autre.getClientWithMaxMontantAchatComule();
                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_autre;
            }else if(choix5 == 3){
                Console.Clear();
                Console.WriteLine("Les commandes d'aujourd'hui");
                AutreModule.Autre.printCommandesToday();
                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_autre;
            }else if(choix5 == 4){
                Console.Clear();
                Console.WriteLine("Le Salarie qui à le plus Grand salaire");
                AutreModule.Autre.getSalarieWithMaxSalary();
                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_autre;
            }else if(choix5 == 5){
                Console.Clear();
                Console.WriteLine("Tapez n'importe quelle touche pour revenir au menu principal");
                Console.ReadLine();
                Console.Clear();
                goto menu_principal;
            }
            else{
               Console.WriteLine("choix non reconnu");
                Console.ReadLine(); 
                Console.Clear();
                goto menu_autre;
                }



            
        }
        else if (choix == 10)
        {
            Console.WriteLine("Au revoir");
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Commande non reconnue");
        }


    }
}