using System;

namespace Csharp_Slot_machine // Note: actual namespace depends on the project name.
{
    internal class Program

    {
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
        /// creates 2D array with randomly generated picked elements from slotValues list
        /// </summary>
        /// <returns></returns>
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
        /// <returns></returns>
        public static bool IsDouble(string inputString)
        {
            bool isCorrectInput = double.TryParse(inputString, out _);
            return isCorrectInput;
        }
        public static double ConvertToDouble(string inputString)
        {
            return Convert.ToDouble(inputString);
        }        
        /// <summary>
        ///  check if the 3 values in second row has the same elements
        /// </summary>
        /// <param name="slotValues"></param>Is the randomly generated slotValues 2D array
        /// <returns></returns> The result of cost of game + added $ of winning
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
        ///  check if the 3 values in any of the rows has the same elements
        /// </summary>
        /// <param name="slotValues"></param>Is the randomly generated slotValues 2D array
        /// <returns></returns> The result of cost of game + added $ of winning
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
        ///  check if the 3 values in any of the columns has the same elements
        /// </summary>
        /// <param name="slotValues"></param>Is the randomly generated slotValues 2D array
        /// <returns></returns> The result of cost of game + added $ of winning
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
        /// Return a string if parameter value is above 0
        /// </summary>
        /// <param name="cashInOutDuringGame"></param>The result of cost of game + added $ of winning
        public static void MessageIfUserWins(double cashInOutDuringGame)
        {
            if (cashInOutDuringGame > 0)
            {
                Console.WriteLine("You won!!");
            }
        }
    }
}
