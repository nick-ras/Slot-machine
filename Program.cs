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

                UIMethods.SetupGame();
                cashAvailable = UIMethods.UserInputDollars();

                while (continueToPlay)
                {
                    int fullRows;
                    GameModes chosenGameMode;
                    string[,] slotOutput = new string[3, 3];

                    string answerStringFormat = UIMethods.ChooseGameMode();

                    if (CheckCorrectFormat(answerStringFormat))
                    {
                        int answerIntFormat = AnswerConvertToInt32(answerStringFormat);
                        chosenGameMode = (GameModes)answerIntFormat;
                    }
                    else
                    {
                        continue;
                    }

                    slotOutput = Random3x3Array();
                    UIMethods.ShowArray(slotOutput);
                     
                    fullRows = CheckRows(chosenGameMode, slotOutput);

                    UIMethods.DidHeWin(fullRows);

                    cashAvailable = cashAvailable - CostOfGame(chosenGameMode);

                    cashAvailable = cashAvailable + AddCashWinnings(slotOutput, fullRows);

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

        public static string[,] Random3x3Array()
        {
            var randWord = new Random();
            List<string> listOfSlotSymbols = new List<string>() { "cherrie", "grape", "orange" };
            string[,] randomArray = new string[3, 3];


            for (int i = 0; i < randomArray.GetLength(0); i++)
            {
                for (int j = 0; j < randomArray.GetLength(1); j++)
                {
                    randomArray[i, j] = listOfSlotSymbols[randWord.Next(listOfSlotSymbols.Count)];
                }
            }
            return randomArray;
        }
        public static bool CheckCorrectFormat(string answerToCheck)
        {
            int answerInInt;
            bool success = int.TryParse(answerToCheck, out answerInInt);

            if (success && answerInInt >= 0 && answerInInt <= 2)
            {
                return true;
            }
            return false;
        }
        public static int AnswerConvertToInt32(string answerInString)
        {
            int answerToInt = Convert.ToInt32(answerInString);
            return answerToInt;
        }
        public static int CheckRows(GameModes gameMode, string[,] slotOutput)
        {
            int countFullRows = 0;
            switch (gameMode)
            {
                case GameModes.PlayCenter:
                    if (slotOutput[1, 0] == slotOutput[1, 1] && slotOutput[1, 0] == slotOutput[1, 2])
                    {
                        countFullRows += 1;
                    }
                    break;
                case GameModes.PlayHorizontal:
                    for (int i = 0; i < slotOutput.GetLength(0); i++)
                    {
                        //Checks horizontal rows
                        if (slotOutput[i, 0] == slotOutput[i, 1] && slotOutput[i, 0] == slotOutput[i, 2])
                        {
                            countFullRows += 1;
                        }
                    }
                    break;
                case GameModes.PlayVerticalAndDiagonal:
                    for (int i = 0; i < slotOutput.GetLength(0); i++)
                    {
                        // checks vertical rows
                        if (slotOutput[0, i] == slotOutput[1, i] && slotOutput[0, i] == slotOutput[2, i])
                        {
                            countFullRows += 1;
                        }
                    }
                    //Checks downward diagonal
                    if (slotOutput[0, 0] == slotOutput[1, 1] && slotOutput[0, 0] == slotOutput[2, 2])
                    {
                        countFullRows += 1;
                    }
                    //Checks upward diagonal
                    if (slotOutput[0, 2] == slotOutput[1, 1] && slotOutput[0, 2] == slotOutput[2, 0])
                    {
                        countFullRows += 1;
                    }
                    break;
            }
            return countFullRows;
        }
        public static double AddCashWinnings(string[,] slotOutput, int fullRows)
        {
            double cash = fullRows * 6;
            return cash;
        }

        public static double CostOfGame(GameModes chosenGameMode)
        {
            int moneyCost = 0;
            if (chosenGameMode == GameModes.PlayCenter)
            {
                moneyCost += 1;
            }
            if (chosenGameMode == GameModes.PlayHorizontal)
            {
                moneyCost += 3;
            }
            if (chosenGameMode == GameModes.PlayVerticalAndDiagonal)
            {
                moneyCost += 4;
            }
            return moneyCost;
        }
    }
}
