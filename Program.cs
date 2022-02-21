// See https://aka.ms/new-console-template for more information


using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            float moneyAvailable;
            
            Console.WriteLine("Welcome to the game\nHow much do you want to play for? Enter an number, and use comma if you want to enter cents");
            // TO DO function crashes if user enter a non-integer, so maybe use a catch error method
            // TO DO: dont except numbers < 1
            moneyAvailable = Convert.ToSingle(Console.ReadLine()); 

            bool continueToPlay = true;

            while (continueToPlay)
            {
                Console.WriteLine("Press any key to pull the handle");
                // CHANGE THIS 
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

                Console.WriteLine($"You have {moneyAvailable:0.##} $. Press <Enter> to continue, otherwise you will cash out");
                
                var playAgain = Console.ReadKey();
                if (playAgain.Key != ConsoleKey.Enter)

                {
                    continueToPlay = false;
                }
            }
        }
    }
}
