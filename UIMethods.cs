using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Slot_machine
{
    /// <summary>
    /// all userinterface related methods
    /// </summary>
    public static class UIMethods
    {        
        /// <summary>
        /// Welcomes the user and asks the user to press enter in order to start the game
        /// </summary>
        public static void GameWelcome()
        {
            Console.WriteLine("Welcome to the game, press enter to start");
            Console.ReadLine();
        }
        /// <summary>
        /// Asks the user to enter the start amount the user wants to put into machine
        /// </summary>
        /// <returns>the input</returns> 
        public static string GetDollarValueString()
        {
            Console.WriteLine("How many dollars do you want to play for? The game will continue until you have 4$ left");            
            return Console.ReadLine();
        }
        /// <summary>
        /// Asks the user to chose a gamemode, and returns it in string format
        /// </summary>
        /// <returns>the input</returns> 
        public static string GetGameModeString()
        {
            Console.WriteLine("\"0\" = play center, \"1\" = play all horizontal lines, \"2\" = play all vertical and diagonal lines");
            
            return Console.ReadLine();
        }
        /// <summary>
        /// convert string to enum
        /// </summary>
        /// <param name="answerInString"></param>
        /// <returns>The chosen GameMode by user</returns> 
        public static GameModes UserInputToGameMode(string answerInString)
        {
            switch (answerInString)
            {
                case "0":
                    return GameModes.PlayCenter;
                case "1":
                    return GameModes.PlayHorizontal;
                case "2":
                    return GameModes.PlayVerticalAndDiagonal;
                default:
                    return GameModes.Invalid;

            }
        }
        /// <summary>
        /// Uses helper method "UserInputToGameMode" to convert userinput to a gamemode
        /// </summary>
        /// <returns></returns>
        public static GameModes GetGameMode()
        {
            var x = GetGameModeString();
            return UserInputToGameMode(x);
        }
        public static void CashOut()
        {
            Console.WriteLine("You less than 4 $ left, the game stops and gives you the rest of the amount back");
        }
        public static void CashCount(double cash)
        {
            Console.WriteLine($"You have {cash:0.##} $. Press <Enter> to continue, otherwise you will cash out");
        }
        /// <summary>
        /// takes in readkey from user, and only if user presses enter, then it returns true
        /// </summary>
        /// <returns></returns>
        public static bool PlayAgain()
        {
            var playAgain = Console.ReadKey();
            if (playAgain.Key != ConsoleKey.Enter)
            {
                return false;
            }
                return true;
        }
        /// <summary>
        /// takes in an 2D array and prints it
        /// </summary>
        /// <param name="slotValues">writes the randomly generated array</param>
        public static void ShowArray(string[,] slotValues)
        {
            for (int i = 0; i < slotValues.GetLength(0); i++)
            {
                for (int j = 0; j < slotValues.GetLength(1); j++)
                {
                    Console.Write(slotValues[i, j] + "  "); 
                }
                Console.WriteLine("");
            }
        }

    }
}
