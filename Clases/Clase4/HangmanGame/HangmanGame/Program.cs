using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame {


    class Program {

        static GameManager game = new GameManager("ZAPATO");

        static void Main (string[] args)
        {
            while (game.IsPlaying()) {
                game.GetBoard().Clear ();
                game.GameStep ();
            }
           
            if (game.GetBoard ().IsVictory ()) {
                game.GetBoard ().Clear ();
                game.GameStep ();
                game.GetBoard ().Draw ("VICTORY!!");
            } else {
                game.GetBoard ().Clear ();
                game.GetBoard ().print ();
                game.GetBoard ().Draw ("Te faltaron: " + game.GetBoard ().Faltantes () + " letras");
                game.GetBoard ().Draw (game.GetPlayer().Life());
                game.GetBoard ().Draw ("GAME OVER :(");
            }

            game.GetBoard ().Close();
        }

    }
}
