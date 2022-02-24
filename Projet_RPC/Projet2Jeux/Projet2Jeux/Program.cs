using System;

namespace ProjetJEUXJEUX2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();

        }

        private void Start()
        {
            Afficher();
        }

        private void Afficher()
        {
            string numjeu = "";
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("Veuillez choisir le jeu à jouer:");
            Console.WriteLine("1- Roche/papier/ciseau   2- La devinette   3- Quitter");
            Console.WriteLine("-------------------------------------------------------------------------");

            numjeu = Console.ReadLine();
            choixjeu(numjeu);

        }

        private void choixjeu(string choix)
        {
            switch (choix)
            {
                case "1":
                    JouerARochePapierCiseau();
                    break;

                case "2":
                    JouerADevinette();
                    break;

                case "3":
                    System.Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Veuillez entrer un choix valide");
                    Afficher();
                    break;
            }
            GetUserChoice();
        }

        private void JouerARochePapierCiseau()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Bienvenu dans le jeu roche/papier/ciseau");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("J'ai déjà fait mon choix, à votre tour:");
            GetUserChoice();
            rejouerRPC();

        }

        private void QuiGagne()
        {
            GetUserChoice();
        }

        private string GetUserChoice()
        {
            string choixjeu1;
            choixjeu1 = Console.ReadLine();
            if (choixjeu1 != "roche" & choixjeu1 != "papier" & choixjeu1 != "ciseau")
            {
                Console.WriteLine("Veuillez entrer un choix valide:");
                JouerARochePapierCiseau();
            }
            else
            {
                string GetCompute = GetComputerChoice();
                Console.WriteLine("Votre choix est {0} et mon choix est {1}", choixjeu1, GetCompute);
                if (choixjeu1 == "roche" & GetCompute == "roche")
                {
                    Console.WriteLine("Le Match est nul!");
                }
                else if (choixjeu1 == "roche" & GetCompute == "papier")
                {
                    Console.WriteLine("L'ordinateur remporte la partie!");
                }
                else if (choixjeu1 == "roche" & GetCompute == "ciseau")
                {
                    Console.WriteLine("Vous remportez la partie!");
                }
                else if (choixjeu1 == "papier" & GetCompute == "papier")
                {
                    Console.WriteLine("Le Match est nul!");
                }
                else if (choixjeu1 == "papier" & GetCompute == "roche")
                {
                    Console.WriteLine("Vous remportez la partie!");
                }
                else if (choixjeu1 == "papier" & GetCompute == "ciseau")
                {
                    Console.WriteLine("L'ordinateur remporte la partie!");
                }
                else if (choixjeu1 == "ciseau" & GetCompute == "ciseau")
                {
                    Console.WriteLine("Le match est nul!");
                }
                else if (choixjeu1 == "ciseau" & GetCompute == "papier")
                {
                    Console.WriteLine("Vous remportez la partie!");
                }
                else if (choixjeu1 == "ciseau" & GetCompute == "roche")
                {
                    Console.WriteLine("L'ordinateur remporte la partie!");
                }
                
            }

            return null;
        }

        private void rejouerRPC()
        {
            Console.WriteLine("Voulez-vous rejouer une partie? O/N");
            string reponse = Console.ReadLine();

            if(reponse == "o" | reponse == "O")
            {
                JouerARochePapierCiseau();
            }
            else if (reponse == "n" | reponse == "N")
            {
                Afficher();
            }
            else
            {
                Console.WriteLine("SVP veuillez entrer un choix valide :");
                rejouerRPC();
            }
        }
        private string GetComputerChoice()
        {
            string choixordi = "";
            int random_number = new Random().Next(1, 4);

            switch (random_number)
            {
                case 1:
                    choixordi = "roche";
                    break;
                case 2:
                    choixordi = "papier";
                    break;
                case 3:
                    choixordi = "ciseau";
                    break;
            }

            return choixordi;
        }

        private void JouerADevinette()
        {
            string reponsefruit;
            string computefruit = GetRandomFruit();
            string fruitsans3 = GetFruitWithout3Letters(computefruit);
            int decompte = 0;
            Console.WriteLine("Bienvenue dans la devinette");
                do
                {

                 Console.WriteLine("FRUIT À TROUVER: " + fruitsans3);
                 reponsefruit = Console.ReadLine();
                 decompte++;

                if (reponsefruit == computefruit)
                { 
                    Console.WriteLine("Bravo ! Vous avez trouvé le mot!");
                    Afficher();
                }

                } while (decompte != 3 && reponsefruit != computefruit);

                if (decompte == 3)
                {
                  Console.WriteLine("Le mot était {0}",computefruit);
                  Afficher();
                }
        }

        private string GetRandomFruit()
        {
            string fruitatrouver;
            string[] listefruits = new string[] { "Pomme", "Banane", "Poire", "Cerise", "Mangue", "Figue", "Tangerine", "Fraise", "Framboise", "Bleuet" };
            Random rnd = new Random();
            int index = rnd.Next(listefruits.Length);
            fruitatrouver = listefruits[index];
            return listefruits[index];

        }

        private string GetFruitWithout3Letters(string fruit)
        {
            
            char[] chars = fruit.ToCharArray();
            Random r = new Random();
            int i = r.Next(chars.Length);
            char character = chars[i] = '_';
            int compte;
            do
             {
             i = r.Next(chars.Length);
             character = chars[i] = '_';
                compte = 0;
                foreach (var characters in chars)
                {
                    
                    if (characters == '_') compte++;
                }
            } while (compte !=3);
                
            string fruitsanslettre = new string(chars);
            return fruitsanslettre;
        }


    }

}