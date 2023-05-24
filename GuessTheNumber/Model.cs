using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    public class Model
    {
        private int targetNumber;
        private int guess;
        private int attempts;

        public void StartNewGame() {Random random = new Random(); 
                                    targetNumber = random.Next(1, 101); 
                                    attempts = 0;}

        public void MakeGuess(int guess) {this.guess = guess; attempts++;}

        public bool IsGuessCorrect() {return guess == targetNumber;}

        public bool IsGuessTooLow() {return guess < targetNumber;}

        public bool IsGuessTooHigh() {return guess > targetNumber;}

        public int GetAttempts() {return attempts;}
    }
}