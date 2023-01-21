
using ClientModule;
using classes;
namespace ModuleStatistique
{
    class Statistique{
    
        public static void PrintCommandeByClient(string nssClient){
           Client client = ClientModule.Clients.getClientByNSS(nssClient);
              if(client != null){
                CommandeModule.Commandes.printCommandesByClient(nssClient);
              }else{
                Console.WriteLine("Client n'existe pas");
              }

        }
        public static  void StatistiqueTotale(){
            Console.WriteLine("Statistique Totale :");
            Console.WriteLine("Nombre de clients : " + ClientModule.Clients.getNumberOfClients());
            Console.WriteLine("Nombre de chauffeurs : " + SalarieModule.Salaries.getNumberOfChauffeurs());
            Console.WriteLine("Nombre de commandes : " + CommandeModule.Commandes.getNumberOfCommande());
            Console.WriteLine("Nombre de Salaries : " + SalarieModule.Salaries.getNumberOfSalaries(SalarieModule.Salaries.getRoot()));
            
        }

        public static void printCommandesByDate(DateTime deb,DateTime fin){
             CommandeModule.Commandes.printCommandesByDate(deb,fin);
        }

        public static void MoyennePrixCommande(){
            double prixMoyenne = CommandeModule.Commandes.MoyennePrixCommande();
            Console.WriteLine(" Prix moyenne des commandes :" + prixMoyenne );

        }
        public static void MoyennePrixCommandeByClient(string nssClient){
           ClientModule.Clients.MoyennePrixCommandeByClient(nssClient);
        }

        public static void printCommandesByChauffeur(string nssChauffeur){
            CommandeModule.Commandes.printCommandesByChauffeur(nssChauffeur);
        }


    }
}