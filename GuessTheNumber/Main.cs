using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    public class Program
    {
        private static void Main()
        {
            Model model = new Model();
            UglyView view = new UglyView();
            Controller controller = new Controller(model, view);

            controller.PlayGame();
        }
    }
}
