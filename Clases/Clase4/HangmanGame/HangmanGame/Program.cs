using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame {


    class Program {

        static GameManager game = new GameManager();

        static void Main (string[] args)
        {
            game.SetSecretWord ("ZAPATO");
            game.SetBoard (new Board ());
            while (game.GetHP()>0) {
                game.GetBoard().Clear ();
                game.GameStep ();
                if (game.GetBoard ().isVictory ()) {
                    break;
                }
            }
           
            if (game.GetBoard ().isVictory ()) {
                game.GetBoard ().Clear ();
               game.GameStep ();
                Console.WriteLine ("VICTORY!!");
            } else {
                game.GetBoard ().Clear ();
                game.GetBoard ().print ();
                int letras = game.GetBoard ().Faltantes ();
                Console.WriteLine ("Te faltaron: " + letras + " letras");
                Console.WriteLine ("Intentos restantes: " + game.GetHP ());
                Console.WriteLine ("GAME OVER :(");
            }

            game.GetBoard ().Close();
        }

    }
}
