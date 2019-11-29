using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame {


    class Program {

        static int hp = 3;
        static string secretword = "ZAPATO";

        static void Main (string[] args)
        {
            Board gameBoard = new Board ();
            string board = "";
            for (int i = 0; i < secretword.Length; i++) {
                board = string.Concat (board, "_");
            }
            string printableBoard = prepareBoard (board);
            gameBoard.setBoard (board);
            gameBoard.setPrintableBoard (printableBoard);
            while (hp>0) {
                gameBoard = gameStep (gameBoard);
                if (gameBoard.isVictory ()) {
                    break;
                }
            }
            if (gameBoard.isVictory ()) {
                Console.WriteLine ("VICTORY!!");
            } else {
                Console.WriteLine ("GAME OVER :(");
            }
            

            Console.ReadLine ();
        }

        static Board gameStep (Board gameBoard) {
            Console.WriteLine (gameBoard.getPrintableBoard());
            Console.WriteLine ("Ingrese una Letra");
            string letter = Console.ReadLine ();
            letter = letter.ToUpper ();
            bool score = secretword.Contains (letter);
            gameBoard = updateBoard (gameBoard, letter,secretword);
            return gameBoard;
        }

        static string prepareBoard (string board) {
            Console.WriteLine ("board: " + board);
            StringBuilder printableBoard = new StringBuilder("");
            for (int i = 0; i < board.Length; i++) {
                printableBoard.Append (board.ToCharArray ()[i]);
                printableBoard.Append (" ");
            }
            return printableBoard.ToString();
        }

        static Board updateBoard (Board gameBoard, string letter, string word) {
            StringBuilder sb = new StringBuilder (gameBoard.getBoard ());
            if (isScore (gameBoard, letter)) {
                for (int i = 0; i < word.Length; i++) {
                    sb[i] = Char.Parse (letter);
                    gameBoard.setBoard (sb.ToString ());
                    gameBoard.setPrintableBoard (prepareBoard (gameBoard.getBoard ()));
                    if (gameBoard.getBoard().Equals(word)) {
                        gameBoard.setVictory (true);
                        return gameBoard;
                    }
                }
                return gameBoard;
            } else {
                hp--;
                Console.WriteLine ("Incorrecto, intentos restantes: " + hp);
                return gameBoard;
            }  
        }

        static bool isScore (Board gameBoard, string letter) {
            bool hasLetter = secretword.Contains (letter);
            bool notPlayed = !gameBoard.getBoard().Contains (letter);
            return (hasLetter && notPlayed);  
        }

    }
}
