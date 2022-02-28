using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Slot_machine
{
    public static class UIMethods
    {        
        public static void SetupGame()
        {
            Console.WriteLine("Welcome to the game, press enter to start");
            Console.ReadLine();
        }
        public static double UserInputDollars()
        {

            Console.WriteLine("How many dollars do you want to play for? The game will continue until you have 4$ left");
            double amountDollars = Convert.ToDouble(Console.ReadLine());
            return amountDollars;
        }
      
        public static string ChooseGameMode()
        {
            Console.WriteLine("\"0\" = play center, \"1\" = play all horizontal lines, \"2\" = play all vertical and diagonal lines");
            
            return Console.ReadLine();
        }           
        public static void MessageIfUserWins(double cashInOutDuringGame)
        {
            if (cashInOutDuringGame > 0)
            {
                Console.WriteLine($"You won!!");
            }
        }
        public static void CashOut()
        {
            Console.WriteLine("You less than 4 $ left, the game stops and gives you the rest of the amount back");
        }
        public static void CashCount(double cash)
        {
            Console.WriteLine($"You have {cash:0.##} $. Press <Enter> to continue, otherwise you will cash out");
        }
        
        public static bool PlayAgain()
        {
            var playAgain = Console.ReadKey();
            if (playAgain.Key != ConsoleKey.Enter)
            {
                return false;
            }
                return true;
        }
        public static void ShowArray(string[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "  "); 
                }
                Console.WriteLine("");
            }
        }

    }
}
