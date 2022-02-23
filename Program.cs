using System;

namespace CsharpSlotMachine // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        /// <summary>
        /// Storing information of which game the user wants to play
        /// </summary>
        public enum BettingStyle
        {
            PlayCenter = 0,
            PlayHorizontal = 1,
            PlayVerticalAndDiagonal = 2
        }
        /// <summary>
        /// The main program, that continues until player doesnt have any more money, or wants to exit
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            bool continueToPlay = true;
            double moneyAvailable = 0;
            //bettingStyle was set to a default value that was not 0-2
            int bettingStyle = -1;

            //This while loop loops until user inputs double value of 1 or above
            while (moneyAvailable <= 1)
            {
                try
                {
                    Console.WriteLine("Welcome to the game\nHow many dollars do you want to play for? Use comma if you want to enter cents");
                    // TO DO function crashes if user enter a non-integer, so maybe use a catch error method
                    // TO DO: dont except numbers < 1
                    moneyAvailable = Convert.ToDouble(Console.ReadLine());
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            
            while (continueToPlay)
            {
                
                try
                {
                    Console.WriteLine("\"0\" = play center, \"1\" = play all horizontal lines, \"2\" = play all vertical and diagonal lines");
                    
                    bettingStyle = Convert.ToInt32(Console.ReadLine());
                    if (bettingStyle > 2 || bettingStyle < 0)
                    {
                        Console.WriteLine("Please enter a whole number between 0-2");
                        continue;
                    }
                    Console.WriteLine($"You chose {(BettingStyle)bettingStyle}");
                    
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                

                // i doesnt do what it says
                Console.WriteLine("Press enter to pull the handle");
                Console.ReadLine();
                

                List<string> listOfSlotSymbols = new List<string>() { "cherrie", "grape", "orange", "melon", "lemons"};

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

                int centerRow = 0;
                int horizontalRows = 0;
                int verticalRows = 0;
                int diagonalRows = 0;

                //Checks center line
                if (outcomePullHandle2D[1, 0] == outcomePullHandle2D[1, 1] && outcomePullHandle2D[1, 0] == outcomePullHandle2D[1, 2] && (BettingStyle)bettingStyle == BettingStyle.PlayCenter)
                {
                    //adds dollars to moneyAvailable if true, cost of playing is included
                    //adds +1 centerRow count
                    centerRow += 1;
                    moneyAvailable += 6;
                    ////Cost of playing BettingStyle.PlayCenter
                    moneyAvailable -= 1;
                }
                

                for (int i = 0; i < outcomePullHandle2D.GetLength(0); i++)
                {
                    //Checks horizontal rows
                    if (outcomePullHandle2D[i, 0] == outcomePullHandle2D[i, 1] && outcomePullHandle2D[i, 0] == outcomePullHandle2D[i, 2] && (BettingStyle)bettingStyle == BettingStyle.PlayHorizontal)
                    {
                        
                        horizontalRows += 1;
                        moneyAvailable += 6;
                    }
                    if ((BettingStyle)bettingStyle == BettingStyle.PlayHorizontal && i == 0)
                    {
                        //Cost of playing BettingStyle.PlayHorizontal
                        moneyAvailable -= 3;
                    }

                    // checks vertical rows
                    if (outcomePullHandle2D[0, i] == outcomePullHandle2D[1, i] && outcomePullHandle2D[0, i] == outcomePullHandle2D[2, i] && (BettingStyle)bettingStyle == BettingStyle.PlayVerticalAndDiagonal)
                    {
                        
                        verticalRows += 1;
                        moneyAvailable += 6;
                    }
                    if ((BettingStyle) bettingStyle == BettingStyle.PlayVerticalAndDiagonal && i == 0)
                    {
                        //Cost of playing BettingStyle.PlayVerticalAndDiagonal
                        moneyAvailable -= 4;
                    }


                }
                //Checks downward diagonal
                if (outcomePullHandle2D[0, 0] == outcomePullHandle2D[1, 1] && outcomePullHandle2D[0, 0] == outcomePullHandle2D[2, 2] && (BettingStyle)bettingStyle == BettingStyle.PlayVerticalAndDiagonal)
                {
                    
                    diagonalRows += 1;
                    moneyAvailable += 6;
                }
                //Checks upward diagonal
                if (outcomePullHandle2D[0, 2] == outcomePullHandle2D[1, 1] && outcomePullHandle2D[0, 2] == outcomePullHandle2D[2, 0] && (BettingStyle)bettingStyle == BettingStyle.PlayVerticalAndDiagonal)
                {
                    
                    diagonalRows += 1;
                    moneyAvailable += 6;
                }
               
                //TO DO: Make it only mention the relevant rows
                
                Console.WriteLine($"You have {centerRow} center rows, {horizontalRows} horizontal rows and {verticalRows} vertical rows! and {diagonalRows} diagonal rows!");

                
                if (moneyAvailable <= 0)
                {
                    continueToPlay = false;
                    continue;
                }

                Console.WriteLine($"You have {moneyAvailable:0.##} $. Press <Enter> to continue, otherwise you will cash out");
                
                var playAgain = Console.ReadKey();
                if (playAgain.Key != ConsoleKey.Enter)

                {
                    continueToPlay = false;
                }
            }
        }
    }
}
