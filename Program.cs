using System;

namespace DiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepGoing = true;
            int rollCount = 1;
            Console.WriteLine("Welcome to the Totally Legit Online Casino!");
            //Takes user input for dice sides and validates 
            Console.WriteLine("How many sides do your die have each? ");
            bool isTrue = int.TryParse(Console.ReadLine(), out int dieSides);
            while (!isTrue)
            {
                Console.WriteLine("Please enter a positive number:");
                isTrue = int.TryParse(Console.ReadLine(), out dieSides);
            }

            while (keepGoing)
            {
                //Make an array and call method to pull the numbers from the roll
                int[] diceNum = DiceRoll(dieSides);
                //Calls method to output the dice roll
                RollResults(rollCount, dieSides, diceNum);
                // roll again or no
                Console.WriteLine("Want to try your luck again? Type \"yes\" or \"no\" to continue or end ");
                string goAgain = Console.ReadLine().ToLower();
                if (goAgain == "yes")
                {
                    rollCount++;
                }
                else
                {
                    keepGoing = false;

                    Console.WriteLine("Thanks for playing!");
                }
            }
        }
        //DiceRoll method
        static int[] DiceRoll(int numSides)
        {
            Random roll = new Random();
            int[] rollNum = new int[2];

            rollNum[0] = roll.Next(1, numSides + 1);
            rollNum[1] = roll.Next(1, numSides + 1);

            return rollNum;
        }

        static void RollResults(int count, int sides, int[] values)
        {
            //roll count
            Console.WriteLine($"Roll # {count}:");
            //Value
            Console.WriteLine($"You rolled {values[0]} and {values[1]} for a grand total of {values[0] + values[1]}.");
         }
    }
}
