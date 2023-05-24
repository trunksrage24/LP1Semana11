using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    public class UglyView
    {
        public void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to Guess the Number!");
            Console.WriteLine("I have chosen a number between 1 and 100.");
        }

        public int GetPlayerGuess()
        {
            Console.Write("Take a guess: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public void DisplayCorrectGuess(int attempts)
        {
            Console.WriteLine("You guessed the number correctly!");
            Console.WriteLine("Number of attempts: " + attempts);
        }

        public void DisplayTooLowGuess()
        {
            Console.WriteLine("Too low! Try again.");
        }

        public void DisplayTooHighGuess()
        {
            Console.WriteLine("Too high! Try again.");
        }

        public void DisplayThankYouMessage()
        {
            Console.WriteLine("Thank you for playing Guess the Number!");
        }
    }
}
