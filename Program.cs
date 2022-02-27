using System;

namespace Csharp_Slot_machine // Note: actual namespace depends on the project name.
{

    internal class Program

    {

        static void Main(string[] args)
        {
            // PowerIsOn is made to run all the time, like in casinos
            bool PowerIsOn = true;
            bool continueToPlay = true;

            double cashAvailable;


            while (PowerIsOn)
            {
                UIMethods.SetupGame();

                bool successEnterAmount = double.TryParse(Console.ReadLine(), out cashAvailable);
                if (!successEnterAmount)
                {
                    continue;
                }

                while (continueToPlay)
                {
                    int rows;

                    UIMethods.GameModes chosenGameMode = (UIMethods.GameModes)UIMethods.chooseGameMode();

                    string[,] slotOutput = random3x3Array();
                    UIMethods.ShowArray(slotOutput);
                     
                    rows = CheckRows(chosenGameMode, slotOutput);

                    cashAvailable = cashAvailable + AddCashWinnings(slotOutput, rows);

                    if (chosenGameMode == UIMethods.GameModes.PlayCenter)
                    {
                        cashAvailable -= 1;
                    }
                    if (chosenGameMode == UIMethods.GameModes.PlayHorizontal)
                    {
                        cashAvailable -= 3;
                    }
                    if (chosenGameMode == UIMethods.GameModes.PlayVerticalAndDiagonal)
                    {
                        cashAvailable -= 4;
                    }




                    if (cashAvailable <= 4)
                    {
                        UIMethods.CashOut();
                        break;
                    }

                    UIMethods.CashCount(cashAvailable);

                    var playAgain = Console.ReadKey();
                    if (playAgain.Key != ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            }
        }

        public static string[,] random3x3Array()
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
        public static int CheckRows(UIMethods.GameModes mode, string[,] slotOutput)
        {
            int rowCount = 0;
            switch (mode)
            {
                case UIMethods.GameModes.PlayCenter:
                    if (slotOutput[1, 0] == slotOutput[1, 1] && slotOutput[1, 0] == slotOutput[1, 2])
                    {
                        rowCount += 1;
                    }
                    break;
                case UIMethods.GameModes.PlayHorizontal:
                    for (int i = 0; i < slotOutput.GetLength(0); i++)
                    {
                        //Checks horizontal rows
                        if (slotOutput[i, 0] == slotOutput[i, 1] && slotOutput[i, 0] == slotOutput[i, 2])
                        {
                            rowCount += 1;
                        }
                    }
                    break;
                case UIMethods.GameModes.PlayVerticalAndDiagonal:
                    for (int i = 0; i < slotOutput.GetLength(0); i++)
                    {
                        // checks vertical rows
                        if (slotOutput[0, i] == slotOutput[1, i] && slotOutput[0, i] == slotOutput[2, i])
                        {
                            rowCount += 1;
                        }
                    }
                    //Checks downward diagonal
                    if (slotOutput[0, 0] == slotOutput[1, 1] && slotOutput[0, 0] == slotOutput[2, 2])
                    {
                        rowCount += 1;
                    }
                    //Checks upward diagonal
                    if (slotOutput[0, 2] == slotOutput[1, 1] && slotOutput[0, 2] == slotOutput[2, 0])
                    {
                        rowCount += 1;
                    }
                    break;
            }
            return rowCount;
        }
        public static double AddCashWinnings(string[,] slotOutput, int rows)
        {
            double cash = rows * 6;
            return cash;
        }
    }
}
