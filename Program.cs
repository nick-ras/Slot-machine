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
            string[] nineRandomSlotSymbols = new string[9];
           
            for (int i = 0; i < nineRandomSlotSymbols.Length; i++)
            {
                nineRandomSlotSymbols[i] = listOfSlotSymbols[randWord.Next(listOfSlotSymbols.Count)];
                Console.WriteLine(nineRandomSlotSymbols[i]);
                if (i > 0 && 3%i==0)
                {
                    Console.WriteLine("\n");
                }

            }
            
            //listOfSlotSymbols[randomIndex]
            //Console.WriteLine($"{nextSlotSymbols} {nextSlotSymbols} {nextSlotSymbols} \n  {nextSlotSymbols} {nextSlotSymbols} {nextSlotSymbols} \n  {nextSlotSymbols} {nextSlotSymbols} {nextSlotSymbols}");
        }
    }
}