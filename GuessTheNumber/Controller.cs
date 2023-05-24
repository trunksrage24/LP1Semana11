using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    public class Controller
    {
        private Model model;
        private UglyView view;

        public Controller(Model model, UglyView view)
        { ~
            this.model = model;
            this.view = view;
        }

        public void PlayGame()
        {
            view.DisplayWelcomeMessage();
            model.StartNewGame();

            bool guessedCorrectly = false;

            while (!guessedCorrectly)
            {
                int guess = view.GetPlayerGuess();
                model.MakeGuess(guess);

                if (model.IsGuessCorrect())
                {
                    view.DisplayCorrectGuess(model.GetAttempts());
                    guessedCorrectly = true;
                }

                else if (model.IsGuessTooLow()) {view.DisplayTooLowGuess();}

                else {view.DisplayTooHighGuess();}
            }

            view.DisplayThankYouMessage();
        }
    }
}