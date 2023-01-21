using System;
using classes;
namespace SalarieModule
{
    static class Salaries
    {
        public class Node
        {
            public List<Node> children = new List<Node>();
            public Salarie value;
            public Node(Salarie value)
            {
                this.value = value;
            }
        }
        public static Node root;
        public static void addSalarie(Salarie value)
        {

            Node node = new Node(value);
            if (root != null)
            {
                if (value.Poste.Contains("Directeur"))
                {
                    root.children.Add(node);
                }
                else if (value.Poste.Contains("Chef") && root.children != null)
                {
                    root.children[0].children.Add(node);
                }
                else
                    root.children.Add(node);

            }
            else
            {
                root = node;
            }

        }
        // get number of Chauffeurs in the heap

        public static int getNumberOfChauffeurs()
        {
            initSalaries();
            int count = 0;
            foreach (Node node in root.children)
            {   
                if (node.value.Poste.Contains("chauffeur")|| node.value.Poste=="chauffeur")
                {   
                    count += 1+getNumberOfSalaries(node);
                }
                
            }
            return count;
        } 
        public static void getSalarieWithMaxSalary()
        {
            initSalaries();
            Salarie maxSalarie = root.value;
            foreach (Node node in root.children)
            {
                if (node.value.Salaire > maxSalarie.Salaire)
                {
                    maxSalarie = node.value;
                }
            }
            System.Console.WriteLine("Salarié avec le plus grand salaire: " + maxSalarie.Nom + " " + maxSalarie.Prenom + " salaire :" + maxSalarie.Salaire);
        }

        public static int getNumberOfSalaries(Node node )
        {
            initSalaries();
            int count = 0;
            if( node.children == null){
                return 1;
            }else if(node.children != null)
            {
                foreach (Node child in node.children)
                {
                    count += 1 + getNumberOfSalaries(child);
                }
            }
            return count;
        }
  


        public static void initSalaries()
        {
            if (File.Exists("salaries.txt") && new FileInfo("salaries.txt").Length != 0)
            {
                string[] lines = File.ReadAllLines("salaries.txt");
                string[] line = lines[0].Split(',');
                root = new Node(new Salarie(line[0], line[1], line[2], DateTime.Parse(line[3]), line[4], line[5], line[6], DateTime.Parse(line[7]), double.Parse(line[8]), line[9]));
                for (int i = 1; i < lines.Length; i++)
                {
                    line = lines[i].Split(',');
                    addSalarie(new Salarie(line[0], line[1], line[2], DateTime.Parse(line[3]), line[4], line[5], line[6], DateTime.Parse(line[7]), double.Parse(line[8]), line[9]));
                }
            }
            else if (File.Exists("salaries.txt") && new FileInfo("salaries.txt").Length == 0)
            {
                root = null;

            }
            else
            {
                File.Create("salaries.txt");
            }

        }
        public static Salarie searchSalarie(string nss)
        {
            initSalaries();
            for (int i = 0; i < root.children.Count; i++)
            {
                if (root.children[i].value.Nss == nss)
                {
                    return root.children[i].value;
                }
            }
            return null;
        }
        public static void removeSalarie(string nss)
        {
            initSalaries();
            for (int i = 0; i < root.children.Count; i++)
            {
                if (root.children[i].value.Nss == nss)
                {
                    root.children.RemoveAt(i);
                    saveSalaries(root);
                    return;
                }
            }
            if (root.value.Nss == nss)
            {
                root = null;
                saveSalaries(root);
            }
        }
        public static List<Salarie> getSalaries()
        {
            if (root == null)
            {
                return null;
            }
            List<Salarie> salaries = new List<Salarie>();
            for (int i = 0; i < root.children.Count; i++)
            {
                salaries.Add(root.children[i].value);
            }
            return salaries;
        }
        public static void printSalaries(Node node, int level)
        {
            if (root != null)
            {   printArbre(node, 1, "Directeur général");
                printArbre(node, 1, "directeur général");
                printArbre(node, 1, "Directeur general");
                printArbre(node, 1, "directeur general");
                printArbre(node, 2, "Directeur");
                printArbre(node, 2, "directeur");
                printArbre(node, 3, "Chef d'équipe");
                printArbre(node, 3, "chef d'équipe");
                printArbre(node, 3, "Chef d'equipe");
                printArbre(node, 3, "chef d'equipe");
                printArbre(node, 4, "*");
                
                
            }
            else
            {
                Console.WriteLine("l'Arbre est vide");
            }
        }
         public static void printArbre(Node node, int level, string poste)
        {    string tabs="" ;
            if (root != null)
            {   if(node.value.Poste.ToString()==poste.ToString()){

                    for(int i=0; i <=level; i++){
                        tabs += "\t";
                    }
                    Console.WriteLine(tabs + node.value.Nom + " " + node.value.Prenom + " " + node.value.Poste + " " + node.value.Nss);
            }



                    foreach (Node n in node.children)
                    {
                        
                        printArbre(n, level ,poste);
                    }
                   
                }
                if(poste.Contains("*") && node != null)
            {
                for (int i = 0; i <= level; i++)
                {
                    tabs += "\t";
                }
                
                // Console.WriteLine(new String('\t', level * 2) + node.value.Nom+" "+node.value.Prenom + " " + node.value.Poste + " " + node.value.Nss);
                if (!node.value.Poste.Contains("directeur général ") 
                    && !node.value.Poste.Contains("directeur") 
                    && !node.value.Poste.Contains("chef d'equipe")
                    && !node.value.Poste.Contains("Chef d'equipe")
                    && !node.value.Poste.Contains("Directeur général")
                     && !node.value.Poste.Contains("directeur general")
                    && !node.value.Poste.Contains("Directeur general")
                    && !node.value.Poste.Contains("Directeur")
                    && !node.value.Poste.Contains("directeur")
                    && !node.value.Poste.Contains("chef d'équipe")
                    && !node.value.Poste.Contains("Chef d'équipe") ){
                    Console.WriteLine(tabs + node.value.Nom + " " + node.value.Prenom + " " + node.value.Poste + " " + node.value.Nss);
                    foreach (Node n in node.children)
                        {
                            printArbre(n, level ,poste);
                        }
                    }
                }
                
                
            }
            
        
        public static string toString(Node node, int level)
        {
            string str = new String(' ', level * 2) + node.value;
            foreach (Node n in node.children)
            {
                str += toString(n, level + 1);
            }
            return str;
        }
        public static void saveSalaries(Node node)
        {
            if (root != null)
            {
                string str = node.value.ToString() + Environment.NewLine;

                foreach (Node n in node.children)
                {
                    str += n.value.ToString() + Environment.NewLine;
                }
                File.WriteAllText("salaries.txt", str);
            }
            else
            {
                File.WriteAllText("salaries.txt", "");
            }
        }
        public static Node getRoot()
        {
            return root;
        }
        public static int getSize()
        {
            return root.children.Count;
        }
        public static Salarie getValue(int position)
        {
            return root.children[position].value;
        }
        public static int searchByPoste(string poste)
        {
            for (int i = 0; i < root.children.Count; i++)
            {
                if (root.children[i].value.Poste == poste)
                {
                    return i;
                }
            }
            return -1;
        }
        public static void updateSalarie(Salarie value)
        {


            for (int i = 0; i < root.children.Count; i++)
            {
                if (root.children[i].value.Nss == value.Nss)
                {
                    root.children[i].value = value;
                    saveSalaries(root);
                    return;
                }
            }
            saveSalaries(root);
        }
        public static Salarie findSalarieByNSS(string NSS)
        {
            initSalaries();

            if (root != null)
            {
                for (int i = 0; i < root.children.Count; i++)
                {
                    if (root.children[i].value.Nss == NSS)
                    {
                        return root.children[i].value;
                    }
                }
                if (root.value.Nss == NSS)
                {
                    return root.value;
                }
            }
            return null;
        }
        public static List<Salarie> getAllSalariesByPoste(Node node, string poste)
        {
            List<Salarie> salaries = new List<Salarie>();
            if (node == null)
            {
                return salaries;
            }
            if (node.value.Poste == poste)
            {
                salaries.Add(node.value);
            }
            foreach (Node n in node.children)
            {
                salaries.AddRange(getAllSalariesByPoste(n, poste));
            }
            return salaries;
        }


        public static List<Salarie> orderBySalaire(List<Salarie> salaries)
        {
            for (int i = 0; i < salaries.Count; i++)
            {
                for (int j = i + 1; j < salaries.Count; j++)
                {
                    if (salaries[i].Salaire < salaries[j].Salaire)
                    {
                        Salarie temp = salaries[i];
                        salaries[i] = salaries[j];
                        salaries[j] = temp;
                    }
                }
            }
            return salaries;
        }
        public static List<Salarie> getAllSalaries(Node node)
        {
            List<Salarie> salaries = new List<Salarie>();
            salaries.Add(node.value);
            foreach (Node n in node.children)
            {
                salaries.AddRange(getAllSalaries(n));
            }
            return salaries;
        }
        public static int getHeight(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            int height = 0;
            foreach (Node n in node.children)
            {
                height = Math.Max(height, getHeight(n));
            }
            return height + 1;
        }

        public static Salarie getMax(Node node)
        {
            Salarie max = node.value;
            foreach (Node n in node.children)
            {
                if (n.value.Salaire > max.Salaire)
                {
                    max = n.value;
                }
            }
            return max;
        }
        public static Salarie getMin(Node node)
        {
            Salarie min = node.value;
            foreach (Node n in node.children)
            {
                if (n.value.Salaire < min.Salaire)
                {
                    min = n.value;
                }
            }
            return min;
        }

        public static double getAverage(Node node)
        {
            double sum = 0;
            foreach (Node n in node.children)
            {
                sum += n.value.Salaire;
            }
            return sum / node.children.Count;
        }
        public static double getSum(Node node)
        {
            double sum = 0;
            foreach (Node n in node.children)
            {
                sum += n.value.Salaire;
            }
            return sum;
        }
        public static int getNumberOfLeaves(Node node)
        {
            if (node.children.Count == 0)
            {
                return 1;
            }
            int count = 0;
            foreach (Node n in node.children)
            {
                count += getNumberOfLeaves(n);
            }
            return count;
        }



    }
}




