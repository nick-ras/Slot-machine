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
                    GameModes chosenGameMode;
                    double cashInOutDuringGame = 0;

                    string answerStringFormat = UIMethods.ChooseGameMode();

                    if (CheckCorrectFormat(answerStringFormat))
                    {
                        chosenGameMode = UserInputToGameMode(answerStringFormat);
                    }
                    else
                    {
                        continue;
                    }

                    string[,] slot3x3Output = Random3x3Array();
                    UIMethods.ShowArray(slot3x3Output);

                    switch (chosenGameMode)
                    {
                        case GameModes.PlayCenter:
                            cashInOutDuringGame = ChangeInCashCent(slot3x3Output, cashAvailable);
                            break;
                        case GameModes.PlayHorizontal:
                            cashInOutDuringGame = ChangeInCashHori(slot3x3Output, cashAvailable);
                            break;
                        case GameModes.PlayVerticalAndDiagonal:
                            cashInOutDuringGame = ChangeInCashVertiDiag(slot3x3Output, cashAvailable);
                            break;
                    }
                   
                    cashAvailable = cashAvailable+cashInOutDuringGame;

                    UIMethods.MessageIfUserWins(cashInOutDuringGame);

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
            List<string> slot3x3Output = new List<string>() { "cherrie", "grape", "orange" };
            string[,] randomArray = new string[3, 3];


            for (int i = 0; i < randomArray.GetLength(0); i++)
            {
                for (int j = 0; j < randomArray.GetLength(1); j++)
                {
                    randomArray[i, j] = slot3x3Output[randWord.Next(slot3x3Output.Count)];
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
        public static GameModes UserInputToGameMode(string answerInString)
        {
            int answerToInt = Convert.ToInt32(answerInString);

            switch ((GameModes)answerToInt)
            {
                case GameModes.PlayCenter:
                    return GameModes.PlayCenter;
                case GameModes.PlayHorizontal:
                    return GameModes.PlayHorizontal;
                case GameModes.PlayVerticalAndDiagonal:
                    return GameModes.PlayVerticalAndDiagonal;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public static double ChangeInCashCent(string[,] slot3x3Output, double cashBeforeGame)
        {
            double costAndWin = 0;
            if (slot3x3Output[1, 0] == slot3x3Output[1, 1] && slot3x3Output[1, 0] == slot3x3Output[1, 2])
            {
                //adds dollars to cashAvailable if true, cost of playing included
                costAndWin += 5;
            }
            ////Cost of playing BettingStyle.PlayCenter
            costAndWin -= 1;
            return costAndWin;
        }
        public static double ChangeInCashHori(string[,] slot3x3Output, double cashAvailable)
        {
            double costAndWin = 0; 
            for (int i = 0; i < slot3x3Output.GetLength(0); i++)
            {
                //Checks horizontal rows
                if (slot3x3Output[i, 0] == slot3x3Output[i, 1] && slot3x3Output[i, 0] == slot3x3Output[i, 2])
                {
                    costAndWin += 6;
                }
            }
            //Cost of playing BettingStyle.PlayHorizontal
            costAndWin -= 3;
            return costAndWin;
        }
        public static double ChangeInCashVertiDiag(string[,] slot3x3Output, double cashAvailable)
        {
            double costAndWin = 0;
            for (int i = 0; i < slot3x3Output.GetLength(0); i++)
            {
                // checks vertical rows
                if (slot3x3Output[0, i] == slot3x3Output[1, i] && slot3x3Output[0, i] == slot3x3Output[2, i])
                {
                    costAndWin += 6;
                }
            }
            //Checks downward diagonal
            if (slot3x3Output[0, 0] == slot3x3Output[1, 1] && slot3x3Output[0, 0] == slot3x3Output[2, 2])
            {
                costAndWin += 6;
            }
            //Checks upward diagonal
            if (slot3x3Output[0, 2] == slot3x3Output[1, 1] && slot3x3Output[0, 2] == slot3x3Output[2, 0])
            {
                costAndWin += 6;

            }
            //Cost of playing BettingStyle.PlayVerticalAndDiagonal
            costAndWin -= 4;
            return costAndWin;
        }
    }
}
