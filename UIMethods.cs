using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Slot_machine
{
    /// <summary>
    /// The class contains all userinterface related methods
    /// </summary>
    public static class UIMethods
    {        
        /// <summary>
        /// Welcomes the user and continues when user presses enter key
        /// </summary>
        public static void GameWelcome()
        {
            Console.WriteLine("Welcome to the game, press enter to start");
            Console.ReadLine();
        }
        /// <summary>
        /// Asks the user to enter the start amount the user wants to put into machine
        /// </summary>
        /// <returns>the user input as string</returns> 
        public static string EnterAmountString()
        {
            Console.WriteLine("How many dollars do you want to play for? The game will continue until you have 4$ left");            
            return Console.ReadLine();
        }
        /// <summary>
        /// Asks the user to chose a gamemode, and returns it in string format
        /// </summary>
        /// <returns>The answer in string format</returns> 
        public static string ChoiceGameModeString()
        {
            Console.WriteLine("\"0\" = play center, \"1\" = play all horizontal lines, \"2\" = play all vertical and diagonal lines");
            
            return Console.ReadLine();
        }
        /// <summary>
        /// Using a switch statement to convert a string to a gamemode constant
        /// </summary>
        /// <param name="answerInString"></param>
        /// <returns>A constant of the enum GameModes</returns> 
        public static GameModes UserInputToGameMode(string choiceGameModeString)
        {
            switch (choiceGameModeString)
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
        /// Asks user for a gamemode
        /// </summary>
        /// <returns>A constant og the enum GameModes</returns>
        public static GameModes GetGameMode()
        {
            var x = ChoiceGameModeString();
            return UserInputToGameMode(x);
            
        }
        /// <summary>
        /// Writes a gamestop statement
        /// </summary>
        public static void GameStop()
        {
            Console.WriteLine("You less than 4 $ left, the game stops and gives you the rest of the amount back");
        }
        /// <summary>
        /// Writes a statement of how much money user has left
        /// </summary>
        /// <param name="cash"></param>
        public static void CashAmount(double cash)
        {
            Console.Write($"You have {cash:0.##} $");
        }
        /// <summary>
        /// Writes a win statement
        /// </summary>
        public static void WinStatement()
        {
            Console.WriteLine("You won!!");
        }
        /// <summary>
        /// takes in readkey from user, and only if user presses enter, then it returns true
        /// </summary>
        /// <returns></returns>
        public static bool PlayAgain()
        {
            Console.WriteLine("Press <Enter> to continue, otherwise you will cash out");
            var playAgain = Console.ReadKey();
            if (playAgain.Key != ConsoleKey.Enter)
            {
                return false;
            }
                return true;
        }
        /// <summary>
        /// Iterates through each element in array
        /// </summary>
        /// <param name="slotValues"></param>
        /// <returns>Prints each row on a new line</returns> 
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
