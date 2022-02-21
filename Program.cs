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
            // function crashes if user enter a non-integer
            // TODO: dont except numbers < 1
            //TODO potentially accept 2 decimals
            moneyAvailable = Convert.ToInt32(Console.ReadLine());

            bool continueToPlay = true;

            while (continueToPlay)
            {
                Console.WriteLine("Press any key to pull handle");

                Console.ReadLine();

                List<string> listOfSlotSymbols = new List<string>() { "cherrie", "grape", "orange", "melon", "lemons", "aces", "king", "queen", "jack" };

                var randWord = new Random();
                string[,] outcomePullHandle2D = new string[3, 3];

                for (int i = 0; i < outcomePullHandle2D.GetLength(0); i++)
                {
                    for (int j = 0; j < outcomePullHandle2D.GetLength(1); j++)
                    {
                        // changed Next(listOfSlotSymbols.Count)] to Next(2)] order to test method
                        outcomePullHandle2D[i, j] = listOfSlotSymbols[randWord.Next(listOfSlotSymbols.Count)];
                        Console.Write(outcomePullHandle2D[i, j] + "  ");
                    }
                    Console.WriteLine("");
                }

                Console.WriteLine($"You have {moneyAvailable} $. Press \"y\" if you wish to play again. Otherwise you will cash out.");
                string answer = Console.ReadLine();
                if (answer != "y")
                {
                    continueToPlay = false;
                }

            }
        }
    }
}
