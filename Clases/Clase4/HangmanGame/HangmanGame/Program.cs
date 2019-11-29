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
            gameBoard.setBoard (board);
            while (hp>0) {
                if (gameBoard.isVictory ()) {
                    break;
                }else{
                    gameBoard = gameStep (gameBoard);
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
            gameBoard.printBoard();
            string letter = Console.ReadLine ();
            letter = letter.ToUpper ();
            bool score = secretword.Contains (letter);
            gameBoard = updateBoard (gameBoard, letter,secretword);
            return gameBoard;
        }

        static Board updateBoard (Board gameBoard, string letter, string word) {
            StringBuilder sb = new StringBuilder (gameBoard.getBoard ());
            if (isScore (gameBoard, letter)) {
                for (int i = 0; i < word.Length; i++) {
                    sb[i] = Char.Parse (letter);
                    gameBoard.setBoard (sb.ToString ());
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
