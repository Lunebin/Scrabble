using ScrabbleLibrary;
using System.Diagnostics.Metrics;
using System.Numerics;

namespace ScrabbleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBag bag = new Bag();
            Console.WriteLine("Testing ScrabbleLibrary [" + bag.Author + " - " + DateTime.Today + "]");
            Console.WriteLine("\nBag initialized with the following " + bag.TileCount + " tiles...");
            Console.WriteLine(bag.ToString());

            string input = "";
            int playerCount = 0;
            do
            {
                Console.Write("\nEnter the number of players (1-8): ");
                input = Console.ReadLine() ?? "";

                try
                {
                    playerCount = int.Parse(input);
                    if (playerCount < 2 || playerCount > 8)
                    {
                        Console.WriteLine("Invalid amount of players. Must be between 2-8.");
                    }
                }
                catch (FormatException err)
                {
                    Console.WriteLine(err.Message);
                }

            } while (playerCount > 8 || playerCount < 2);


            // Create Player Racks
            List<IRack> rackArray = new List<IRack>();

            for(int p = 1; p <= playerCount; p++)
            {
                IRack newRack = bag.GenerateRack();
                rackArray.Add(newRack);
            }

            Console.WriteLine();
            Console.WriteLine("Racks for " + playerCount + " players were populated");
            printBag(bag);

            // Take Player Turns
            bool cont = true;
            while (cont == true)
            {
                int player = 1;
                foreach(IRack r in rackArray)
                {
                    Console.WriteLine("-----------------------------------------------------------------------------");
                    Console.WriteLine("Player " + player);
                    Console.WriteLine("-----------------------------------------------------------------------------");
                    Console.WriteLine("Your rack contains: " + r.ToString());
                    Tester(r);
                    printBag(bag);
                    ++player;

                    // if bag is ever empty
                    if (bag.TileCount == 0)
                    {
                        Console.WriteLine("Retiring the game.");
                        Console.WriteLine("The final scores are...");
                        Console.WriteLine("-----------------------------------------------------------------------------");

                        for (int i = 0; i < rackArray.Count; i++)
                        {
                            Console.WriteLine("Player " + (i + 1) + ": " + rackArray[i].TotalPoints);
                            rackArray[i].GameOver();
                        }

                        Environment.Exit(1);
                    }
                }

                Console.Write("Would you like each player to take another turn? (y/n): ");
                string answer = Console.ReadLine() ?? "";
                if (answer == "n")
                {
                    Console.WriteLine("Retiring the game.");
                    Console.WriteLine("The final scores are...");
                    Console.WriteLine("-----------------------------------------------------------------------------");

                    for (int i = 0; i < rackArray.Count; i++)
                    {
                        Console.WriteLine("Player " + (i + 1) + ": " + rackArray[i].TotalPoints);
                        rackArray[i].GameOver();
                    }
                    
                    Console.WriteLine("-----------------------------------------------------------------------------");
                    Environment.Exit(1);
                    cont = false;
                } 

            }

            // Print Bag Function
            void printBag(IBag b)
            {
                if (b.TileCount != 0)
                {
                    Console.WriteLine("Bag now contains the following " + b.TileCount + " tiles..");
                    Console.WriteLine(b.ToString());
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Bag is empty.");
                    Console.WriteLine();
                }
            }

            // Test/Play Word Function
            void Tester(IRack r)
            {
                string answer;
                string answer2;
                string word = "";
                bool wordPlayed = false;

                do
                {
                    Console.Write("Test a word for it's point value? (y/n) : ");
                    answer = Console.ReadLine() ?? "";
                    if (answer.ToLower() == "y")
                    {
                        while(wordPlayed == false)
                        {
                            Console.Write("Enter a word using the letters " + r.ToString() + ": ");
                            word = Console.ReadLine() ?? "";
                            Console.WriteLine("The word [" + word + "] is worth " + r.TestWord(word) + " points.");

                            if (r.TestWord(word) > 0)
                            {
                                Console.Write("Do you want to play the word [" + word + "]? (y/n): ");
                                answer2 = Console.ReadLine() ?? "";
                                if (answer2.ToLower() == "y")
                                {
                                    r.PlayWord(word);
                                    Console.WriteLine("\n\t\t------------------------------");
                                    Console.WriteLine("\t\tWord Played:\t\t" + word);
                                    Console.WriteLine("\t\tTotal Points:\t\t" + r.TotalPoints);
                                    Console.WriteLine("\t\tRack now contains:\t" + r.ToString());
                                    Console.WriteLine("\t\t------------------------------\n");
                                    wordPlayed = true;
                                    answer = "n";
                                }
                            }
                        }
                    }
                } while (answer.ToLower() != "n");
            }
        }
    }
}