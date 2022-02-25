using System;

namespace CsharpSlotMachine // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        /// <summary>
        /// Storing information of which game the user wants to play
        /// </summary>

        /// <summary>
        /// The main program, that continues until player doesnt have any more money, or wants to exit
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // PowerIsOn should run constantly
            bool PowerIsOn = true;
            bool continueToPlay = true;
            //bettingStyle was set to a default value that was not 0-2
            int bettingStyle;

            while (PowerIsOn)
            {
                Console.WriteLine("Welcome to the game, press enter to start");
                Console.ReadLine();

                
                // it resets everytime new user starts the game or there is an error in while loop
                double moneyAvailable = 0;

                Console.WriteLine("How many dollars do you want to play for? Use comma if you want to enter cents"); ;

                //Not sure it right to use while and if here
                bool successEnterAmount = double.TryParse(Console.ReadLine(), out moneyAvailable);
                if (!successEnterAmount)
                {
                    continue;
                }
                    
                

                while (continueToPlay)
                {
                    bool youWon = false;
                    

                    // TO DO make it only play horizontal if moneyAvailable >=3
                    Console.WriteLine("\"0\" = play center, \"1\" = play all horizontal lines, \"2\" = play all vertical and diagonal lines");

                    
                    bool success = int.TryParse(Console.ReadLine(), out bettingStyle);
                    if (success)
                    {
                        Console.WriteLine("Press enter to pull the handle");

                    }
                    else
                    {
                        Console.WriteLine("Please enter a whole number between 0-2");
                        continue;
                    }
                    Console.ReadLine();

                    List<string> listOfSlotSymbols = new List<string>() { "cherrie", "grape", "orange", "melon", "lemons" };

                    var randWord = new Random();
                    string[,] outcomePullHandle2D = new string[3, 3];

                    for (int i = 0; i < outcomePullHandle2D.GetLength(0); i++)
                    {
                        for (int j = 0; j < outcomePullHandle2D.GetLength(1); j++)
                        {
                            outcomePullHandle2D[i, j] = listOfSlotSymbols[randWord.Next(2)];
                            Console.Write(outcomePullHandle2D[i, j] + "  ");
                        }
                        Console.WriteLine("");
                    }

                    


                    switch ((BettingStyle)bettingStyle)
                    {
                        case BettingStyle.PlayCenter:
                            //Checks center line
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
                            break;
                        case BettingStyle.PlayHorizontal:
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
                            break;
                        case BettingStyle.PlayVerticalAndDiagonal:
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
    }
}
