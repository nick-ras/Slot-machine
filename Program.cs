// See https://aka.ms/new-console-template for more information


using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double moneyAvailable;
            
            Console.WriteLine("Welcome to the game\nHow many dollars do you want to play for? Use comma if you want to enter cents");
            // TO DO function crashes if user enter a non-integer, so maybe use a catch error method
            // TO DO: dont except numbers < 1
            moneyAvailable = Convert.ToDouble(Console.ReadLine()); 

            bool continueToPlay = true;

            while (continueToPlay)
            {
                // Make try statement avaliable outside try statement
                int bettingStyle = -1;
                try
                {
                    Console.WriteLine("\"0\" = play center, \"1\" = play all horizontal lines, \"2\" = play all vertical and diagonal lines");
                    bettingStyle = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
               
                Console.WriteLine("Press any key to pull the handle");
                Console.ReadLine();

                List<string> listOfSlotSymbols = new List<string>() { "cherrie", "grape", "orange", "melon", "lemons"};

                var randWord = new Random();
                string[,] outcomePullHandle2D = new string[3, 3];

                for (int i = 0; i < outcomePullHandle2D.GetLength(0); i++)
                {
                    for (int j = 0; j < outcomePullHandle2D.GetLength(1); j++)
                    {
                        outcomePullHandle2D[i, j] = listOfSlotSymbols[randWord.Next(listOfSlotSymbols.Count)];
                        Console.Write(outcomePullHandle2D[i, j] + "  ");
                    }
                    Console.WriteLine("");
                }

                int centerRow = 0;
                int horizontalRows = 0;
                int verticalRows = 0;
                int diagonalRows = 0;

                foreach (string symbol in listOfSlotSymbols)
                {
                    //Checks center line
                    if (symbol == outcomePullHandle2D[1, 0] && symbol == outcomePullHandle2D[1, 1] && symbol == outcomePullHandle2D[1, 2] && bettingStyle == 0)
                    {
                        centerRow += 1;
                        moneyAvailable += 3;
                    }
                       
                    for (int i = 0; i < outcomePullHandle2D.GetLength(0); i++)
                    {
                        //Checks horizontal rows
                        if (symbol == outcomePullHandle2D[i, 0] && symbol == outcomePullHandle2D[i, 1] && symbol == outcomePullHandle2D[i, 2] && bettingStyle == 1)
                        {
                            //adds 9 dollars to moneyAvailable if true
                            horizontalRows += 1;
                            moneyAvailable += 3;
                        }
                        // checks vertical rows
                        if (symbol == outcomePullHandle2D[0, i] && symbol == outcomePullHandle2D[1, i] && symbol == outcomePullHandle2D[2, i] && bettingStyle == 2)
                        {
                            //adds 9 dollars to moneyAvailable if true 
                            verticalRows += 1;
                            moneyAvailable += 3;
                        }
                        
                        

                    }
                    //Checks downward diagonal
                    if (symbol == outcomePullHandle2D[0, 0] && symbol == outcomePullHandle2D[1, 1] && symbol == outcomePullHandle2D[2, 2] && bettingStyle == 2)
                    {
                        //check vertical rows and adds 9 dollars to moneyAvailable
                        diagonalRows += 1;
                        moneyAvailable += 3;
                    }
                    //Checks upward diagonal
                    if (symbol == outcomePullHandle2D[0, 2] && symbol == outcomePullHandle2D[1, 1] && symbol == outcomePullHandle2D[2, 0] && bettingStyle == 2)
                    {
                        //check vertical rows and adds 9 dollars to moneyAvailable
                        diagonalRows += 1;
                        moneyAvailable += 3;
                    }
                }
                // cost of playing the round
                if (bettingStyle == 0)
                {
                    moneyAvailable -= 1;
                }
                if (bettingStyle == 1)
                {
                    moneyAvailable -= 3;
                }
                if (bettingStyle == 2)
                {
                    moneyAvailable -= 4;
                }

                //TO DO: Make it only mention the relevant rows
                Console.WriteLine($"You have {horizontalRows} horizontal rows and {verticalRows} vertical rows! and {diagonalRows} diagonal rows!");

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
