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
                Console.WriteLine("Press any key to pull handle");
                
                string pullHandle = Convert.ToString(Console.ReadLine());
               

                List<string> listOfSlotSymbols = new List<string>() { "cherrie", "grape", "orange", "melon", "lemons", "Aces", "King", "Queen", "Jack" };

                var randWord = new Random(listOfSlotSymbols.Count);
                string[,] outcomePullHandle2D = new string[3, 3];
                
                for (int i = 0; i < outcomePullHandle2D.GetLength(0); i++)
                {
                    for (int j = 0; j < outcomePullHandle2D.GetLength(1); j++)
                    {
                        outcomePullHandle2D[i, j] = listOfSlotSymbols[randWord.Next(0, 9)];
                        Console.Write(outcomePullHandle2D[i, j] + "  ");
                    }
                    Console.WriteLine("");
                }

                foreach (string symbol in listOfSlotSymbols)
                {
                    for (int i = 0; i < outcomePullHandle2D.GetLength(0); i++)
                    {
                        if (outcomePullHandle2D[0,i].Distinct().Count() == 1)
                        {
                            Console.WriteLine("You got a straight row");
                        }
                    }
                }


                Console.WriteLine($"Congrats, you have {moneyAvailable} $. Do you wish to play again");
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