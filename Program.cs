﻿using System;

namespace Csharp_Slot_machine // Note: actual namespace depends on the project name.
{
    internal class Program

    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // PowerIsOn is set to run all the time, like in casinos
            bool PowerIsOn = true;
            bool continueToPlay = true;


            while (PowerIsOn)
            {
                double cashAvailable;
                GameModes chosenGameMode;

                UIMethods.GameWelcome();

                string answerCashAmount = UIMethods.GetDollarValueString();

                if (!IsDouble(answerCashAmount))
                {
                    continue;
                }
                if (ConvertToDouble(answerCashAmount) < 4)
                {
                    Console.WriteLine("Amount must be 4 or above");
                    continue;
                }

                cashAvailable = ConvertToDouble(answerCashAmount);

                while (continueToPlay)
                {
                    double cashInOutDuringGame = 0;

                    chosenGameMode = UIMethods.GetGameMode();

                    if (chosenGameMode == GameModes.Invalid)
                    {
                        continue;
                    }

                    string[,] slotValues = Random3x3Array();
                    UIMethods.ShowArray(slotValues);

                    cashInOutDuringGame = CashCostAndWin(chosenGameMode, slotValues);

                    cashAvailable = cashAvailable + cashInOutDuringGame;

                    MessageIfUserWins(cashInOutDuringGame);

                    if (cashAvailable <= 4)
                    {
                        UIMethods.CashOut();
                        break;
                    }

                    UIMethods.CashCount(cashAvailable);

                    if (!UIMethods.PlayAgain())
                    {
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// creates 2D array with randomly generated elements from an internal list
        /// </summary>
        /// <returns>2D array with 3 rows and 3 columns</returns> 
        public static string[,] Random3x3Array()
        {
            var randWord = new Random();
            List<string> slotValues = new List<string>() { "cherrie", "grape", "orange" };
            string[,] randomArray = new string[3, 3];


            for (int i = 0; i < randomArray.GetLength(0); i++)
            {
                for (int j = 0; j < randomArray.GetLength(1); j++)
                {
                    randomArray[i, j] = slotValues[randWord.Next(slotValues.Count)];
                }
            }
            return randomArray;
        }
        /// <summary>
        /// check if inputString can be converted to a double
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>true if string can be converted to double</returns>
        public static bool IsDouble(string inputString)
        {
            bool isCorrectInput = double.TryParse(inputString, out _);
            return isCorrectInput;
        }
        /// <summary>
        /// Convert string to double
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>true if user input could be converted to double</returns>
        public static double ConvertToDouble(string inputString)
        {
            return Convert.ToDouble(inputString);
        }
        /// <summary>
        /// Check if the 3 values in second row has the same elements
        /// </summary>
        /// <param name="slotValues">Is the randomly generated slotValues 2D array</param>
        /// <returns>Winnings and costs of round</returns> 
        public static double ChangeInCashCent(string[,] slotValues)
        {
            double costAndWin = 0;
            if (slotValues[1, 0] == slotValues[1, 1] && slotValues[1, 0] == slotValues[1, 2])
            {
                costAndWin += 5;
            }
            costAndWin -= 1;
            return costAndWin;
        }
        /// <summary>
        /// Checks if the 3 values in any of the rows has the same elements
        /// </summary>
        /// <param name="slotValues">Is the randomly generated slotValues 2D array</param>
        /// <returns>Winnings and costs of round</returns> 
        public static double ChangeInCashHori(string[,] slotValues)
        {
            double costAndWin = 0; 
            for (int i = 0; i < slotValues.GetLength(0); i++)
            {
                //Checks horizontal rows
                if (slotValues[i, 0] == slotValues[i, 1] && slotValues[i, 0] == slotValues[i, 2])
                {
                    costAndWin += 6;
                }
            }
            //Cost of playing BettingStyle.PlayHorizontal
            costAndWin -= 3;
            return costAndWin;
        }
        /// <summary>
        /// Check if the 3 values in any of the columns has the same elements
        /// </summary>
        /// <param name="slotValues">Is the randomly generated slotValues 2D array</param>
        /// <returns>Winnings and costs of round</returns> 
        public static double ChangeInCashVertiDiag(string[,] slotValues)
        {
            double costAndWin = 0;
            for (int i = 0; i < slotValues.GetLength(0); i++)
            {
                // checks vertical rows
                if (slotValues[0, i] == slotValues[1, i] && slotValues[0, i] == slotValues[2, i])
                {
                    costAndWin += 6;
                }
            }
            //Checks downward diagonal
            if (slotValues[0, 0] == slotValues[1, 1] && slotValues[0, 0] == slotValues[2, 2])
            {
                costAndWin += 6;
            }
            //Checks upward diagonal
            if (slotValues[0, 2] == slotValues[1, 1] && slotValues[0, 2] == slotValues[2, 0])
            {
                costAndWin += 6;

            }
            //Cost of playing BettingStyle.PlayVerticalAndDiagonal
            costAndWin -= 4;
            return costAndWin;
        }
        /// <summary>
        /// Takes in a GameMode type, and executes the method that handles the winnings and loses related to that enumtype
        /// </summary>
        /// <param name="chosenGameMode"></param>
        /// <param name="slotValues"></param>
        /// <returns>The return values of the method chosen in the switch statement</returns> 
        public static double CashCostAndWin(GameModes chosenGameMode, string[,] slotValues)
        {
            switch (chosenGameMode)
            {
                case GameModes.PlayCenter:
                    return ChangeInCashCent(slotValues);
                case GameModes.PlayHorizontal:
                    return ChangeInCashHori(slotValues);
                case GameModes.PlayVerticalAndDiagonal:
                    return ChangeInCashVertiDiag(slotValues);
                default:
                    return 0;
            }
        }
        /// <summary>
        /// Check if the user has more or less $from when he started the round
        /// </summary>
        /// <param name="cashInOutDuringGame">cost + winnings of round</param>
        public static void MessageIfUserWins(double cashInOutDuringGame)
        {
            if (cashInOutDuringGame > 0)
            {
                Console.WriteLine("You won!!");
            }
        }
    }
}
