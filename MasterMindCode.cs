using System;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mastermind application!");
            Console.WriteLine("Guess the 4-digit number. Each digit should be between 1 and 6.");
            Console.WriteLine("Total 10 attempts provided.");

            // Generate the random 4 digit answer.
            Random random = new Random();
            int[] answer = new int[4];
            for (int i = 0; i < 4; i++)
            {
                answer[i] = random.Next(1, 7); // Generates a random number between 1 and 6
            }

            int Totalattempts = 10;
            while (Totalattempts > 0)
            {
                Console.WriteLine("Enter the number:");
                string input = Console.ReadLine();

                if (input.Length != 4 || !int.TryParse(input, out _))
                {
                    Console.WriteLine("Invalid number. Please try again.");
                    continue;
                }

                int[] guess = Array.ConvertAll(input.ToCharArray(), c => (int)Char.GetNumericValue(c));

                int plusCount = 0;
                int minusCount = 0;

                // Check each digit
                for (int i = 0; i < 4; i++)
                {
                    if (guess[i] == answer[i])
                    {
                        plusCount++;
                    }
                    else if (Array.IndexOf(answer, guess[i]) != -1)
                    {
                        minusCount++;
                    }
                }

                // Print feedback
                for (int i = 0; i < plusCount; i++)
                {
                    Console.Write("+");
                }
                for (int i = 0; i < minusCount; i++)
                {
                    Console.Write("-");
                }

                if (plusCount == 4)
                {
                    Console.WriteLine(" Correct Number");
                    return;
                }
                else
                {
                    Totalattempts--;
                    Console.WriteLine($" Attempts left: {Totalattempts}");
                }
            }

            Console.WriteLine("No more attempts left");
        }
    }
}
