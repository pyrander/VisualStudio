using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto {
    class Program {
        static String[] directions = { "A", "B", "C", "D","E","F","G","H","I","J" };
        static int[] dificultades = {5,10,15};
        static void Main (string[] args)
        {
            int rounds = 1;
            int dificultad = dificultades[0];
            while (rounds< dificultad) {
                int totalMoves = rounds;
                Console.WriteLine ("Ronda: " + rounds + " de "+ dificultad + " posibles");
                List<Letter> simonMoves = new List<Letter> { };
                simonMoves = GenerateMoves (simonMoves, totalMoves);
                DrawMoves (simonMoves);
                List<Letter> playerMoves = new List<Letter> { };
                playerMoves = InputMoves (playerMoves, totalMoves);
                CompareMoves (simonMoves, playerMoves);
                rounds++;
                Console.Clear ();
            }
            Console.ReadLine ();

        }
        public static void CompareMoves (List<Letter> simonMoves, List<Letter> playerMoves)
        {
            
            int matches = 0;
            for (int i = 0; i < simonMoves.Count; i++) {
                if (simonMoves[i].GetSymbol () == playerMoves[i].GetSymbol ()) {
                    matches++;
                }
            }
            Console.WriteLine ("Aciertos totales: " + matches + " de " + simonMoves.Count + " posibles");
            WaitFor (2);
        }

        public static void DrawMoves (List<Letter> simonMoves)
        {
            Console.WriteLine ("Simon dice: ");
            Console.Write ("Movimientos: ");
            foreach (Letter move in simonMoves) {
                Console.Write (move.GetSymbol () + " ");
                WaitFor (0.4);
            }
            WaitFor (2);
            Console.Clear ();
        }

        public static List<Letter> InputMoves (List<Letter> playerMoves, int totalMoves)
        {
            Console.WriteLine ("Repite: ");
            int keyPressNumber = 0;
            ConsoleKeyInfo keyinfo;
            do {
                keyinfo = Console.ReadKey (true);
                keyPressNumber++;
                string letter = keyinfo.Key.ToString ().ToUpper ();
                Console.Write (letter + " ");
                Letter arrow = new Letter (letter);
                playerMoves.Add (arrow);
            }
            while (keyPressNumber < totalMoves);
            Console.WriteLine (" ");
            return playerMoves;
        }


        public static List<Letter> GenerateMoves (List<Letter> simonMoves, int totalMoves)
        {
            if (simonMoves.Count < totalMoves) {
                simonMoves = GenerateMove (simonMoves);
                return GenerateMoves (simonMoves, totalMoves);
            } else {
                return simonMoves;
            }
        }

        public static List<Letter> GenerateMove (List<Letter> simonMoves)
        {
            Random moveRoll = new Random ();
            WaitFor (0.2);
            int roll = moveRoll.Next (1, directions.Length);
            Letter move = new Letter (directions[roll]);
            simonMoves.Add (move);
            return simonMoves;
        }

        public static void  WaitFor (double seconds) {
            System.Threading.Thread.Sleep (Int16.Parse((seconds*1000).ToString()));
        }

    }

}
