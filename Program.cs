// See https://aka.ms/new-console-template for more information


using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfSlotSymbols = new List<string>() {"cherrie", "grape", "orange", "melon", "lemons", "Aces", "King", "Queen", "Jack"};

            var randWord = new Random(listOfSlotSymbols.Count);
            string[,] pullHandle2D = new string[3, 3];

            pullHandle2D[2,2] = "cherry";
            Console.WriteLine(pullHandle2D[2,2]);
            Console.WriteLine(listOfSlotSymbols.Count + "\n\n");
            // i checked that pullHandle had different random generated values than nineRandomSlotSymbols 



            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    pullHandle2D[i, j] = listOfSlotSymbols[randWord.Next(0, 9)];
                    Console.WriteLine(pullHandle2D[i, j]);
                }
            }
            
            /*
            for (int i = 0; i < pullHandle.Length; i++)
            {
                Console.Write($"{pullHandle[i]}  ");
                if (i > 0 && (i+1)%3==0)
                {
                    Console.WriteLine("");
                }

            }*/

           


        }
    }
}