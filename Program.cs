using System;

namespace CsharpSlotMachine // Note: actual namespace depends on the project name.
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            // PowerIsOn is made to run all the time, like in casinos
            bool PowerIsOn = true;
            bool continueToPlay = true;
            int bettingStyle;
            double moneyAvailable = 0;
            bool youWon;

            while (PowerIsOn)
            {
                Console.WriteLine("Welcome to the game, press enter to start");
                Console.ReadLine();
                Console.WriteLine("How many dollars do you want to play for? Use comma if you want to enter cents"); ;

                bool successEnterAmount = double.TryParse(Console.ReadLine(), out moneyAvailable);
                if (!successEnterAmount)
                {
                    continue;
                }

                while (continueToPlay)
                {
                    youWon = false;

                    // TO DO make it only play horizontal if moneyAvailable >=3
                    Console.WriteLine("\"0\" = play center, \"1\" = play all horizontal lines, \"2\" = play all vertical and diagonal lines");

                    bool success = int.TryParse(Console.ReadLine(), out bettingStyle);

                    if (success && 0 <= bettingStyle && bettingStyle <= 2)
                    {
                        Console.WriteLine("Press enter to pull the handle");

                    }
                    else
                    {
                        continue;
                    }

                    Console.ReadLine();

                    string[,] outcomePullHandle2D = new string[3, 3];

                    random3x3Array(outcomePullHandle2D);


                    switch ((BettingStyle)bettingStyle)
                    {
                        case BettingStyle.PlayCenter:
                            CheckCenter(outcomePullHandle2D, moneyAvailable, youWon);
                            break;
                        case BettingStyle.PlayHorizontal:
                            CheckHorizontal(outcomePullHandle2D, moneyAvailable, youWon);
                            break;
                        case BettingStyle.PlayVerticalAndDiagonal:
                            CheckVerticalAndDiagonal(outcomePullHandle2D, moneyAvailable, youWon);
                            break;
                    }

                    if (youWon == true)
                    {
                        Console.WriteLine("You won on one or more rows!");
                    }

                    if (moneyAvailable <= 0)
                    {
                        break;
                    }

                    Console.WriteLine($"You have {moneyAvailable:0.##} $. Press <Enter> to continue, otherwise you will cash out");

                    var playAgain = Console.ReadKey();
                    if (playAgain.Key != ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            }
        }
        public static void random3x3Array(string[,] outcomePullHandle2D)
        {
            var randWord = new Random();
            List<string> listOfSlotSymbols = new List<string>() { "cherrie", "grape", "orange"};

            for (int i = 0; i < outcomePullHandle2D.GetLength(0); i++)
            {
                for (int j = 0; j < outcomePullHandle2D.GetLength(1); j++)
                {
                    outcomePullHandle2D[i, j] = listOfSlotSymbols[randWord.Next(listOfSlotSymbols.Count)];
                    Console.Write(outcomePullHandle2D[i, j] + "  ");
                }
                Console.WriteLine("");
            }
        }
        public static void CheckCenter(string[,] outcomePullHandle2D, double moneyAvailable, bool youWon)
        {
            if (outcomePullHandle2D[1, 0] == outcomePullHandle2D[1, 1] && outcomePullHandle2D[1, 0] == outcomePullHandle2D[1, 2])
            {
                //adds dollars to moneyAvailable if true, cost of playing included
                moneyAvailable += 5;
                youWon = true;

            }
            else
            {
                ////Cost of playing BettingStyle.PlayCenter
                moneyAvailable -= 1;
            }
        }
        public static void CheckVerticalAndDiagonal(string[,] outcomePullHandle2D, double moneyAvailable, bool youWon)
        {
            for (int i = 0; i < outcomePullHandle2D.GetLength(0); i++)
            {
                // checks vertical rows
                if (outcomePullHandle2D[0, i] == outcomePullHandle2D[1, i] && outcomePullHandle2D[0, i] == outcomePullHandle2D[2, i])
                {


                    moneyAvailable += 6;
                    youWon = true;
                }
                if (i == 0)
                {
                    //Cost of playing BettingStyle.PlayVerticalAndDiagonal
                    moneyAvailable -= 4;
                }

            }
            //Checks downward diagonal
            if (outcomePullHandle2D[0, 0] == outcomePullHandle2D[1, 1] && outcomePullHandle2D[0, 0] == outcomePullHandle2D[2, 2])
            {

                moneyAvailable += 6;
                Console.WriteLine("You won!");
            }
            //Checks upward diagonal
            if (outcomePullHandle2D[0, 2] == outcomePullHandle2D[1, 1] && outcomePullHandle2D[0, 2] == outcomePullHandle2D[2, 0])
            {

                moneyAvailable += 6;
                Console.WriteLine("You won!");
            }
        }

        public static void CheckHorizontal(string[,] outcomePullHandle2D, double moneyAvailable, bool youWon)
        {
            for (int i = 0; i < outcomePullHandle2D.GetLength(0); i++)
            {
                //Checks horizontal rows
                if (outcomePullHandle2D[i, 0] == outcomePullHandle2D[i, 1] && outcomePullHandle2D[i, 0] == outcomePullHandle2D[i, 2])
                {
                    moneyAvailable += 6;
                    youWon = true;
                }
                if (i == 0)
                {
                    //Cost of playing BettingStyle.PlayHorizontal
                    moneyAvailable -= 3;
                }
            }
        }
    }
}
