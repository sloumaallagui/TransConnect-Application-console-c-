namespace AutreModule
{


    static class Autre{
        public static void getClientWithMaxMontantAchatComule(){
            ClientModule.Clients.getClientWithMaxMontantAchatComule();
        }
        public static void StatistiqueTotale(){
            ModuleStatistique.Statistique.StatistiqueTotale();
        }
        public static void printCommandesToday(){
        CommandeModule.Commandes.printCommandesToday();
        }
        public static void getSalarieWithMaxSalary(){
        SalarieModule.Salaries.getSalarieWithMaxSalary();
        }
    }
}