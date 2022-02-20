// See https://aka.ms/new-console-template for more information


using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int moneyAvailable;

            Console.WriteLine("Welcome to the game\nHow much do you want to play for? Enter an integer");
            moneyAvailable = Convert.ToInt32(Console.ReadLine());

            bool continueToPlay = true;

            while (continueToPlay = true)
            {
                Console.WriteLine("Pull the handle by pressing enter");

                List<string> listOfSlotSymbols = new List<string>() { "cherrie", "grape", "orange", "melon", "lemons", "Aces", "King", "Queen", "Jack" };

                var randWord = new Random(listOfSlotSymbols.Count);
                string[,] pullHandle2D = new string[3, 3];

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        pullHandle2D[i, j] = listOfSlotSymbols[randWord.Next(0, 9)];
                        Console.Write(pullHandle2D[i, j] + "  ");
                    }
                    Console.WriteLine("");
                }

                Console.WriteLine("This is the output\nDo you wish to play again");
                string answer = Convert.ToString(Console.ReadLine());
                if (answer == "y")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            
           
        }
    }
}