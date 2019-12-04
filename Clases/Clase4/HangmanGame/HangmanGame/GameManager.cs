using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame {
    class GameManager {
        string secretword = "";
        int hp = 3;
        Board gameBoard;

        public void SetSecretWord (string secretword) {
            this.secretword = secretword;
        }

        public void SetBoard (Board gameBoard) {
            gameBoard.initBoard (secretword.Length, '_');
            this.gameBoard = gameBoard;
        }

        public Board GetBoard () {
            return gameBoard;
        }

        public int GetHP () {
            return hp;
        }


        public bool IsScore (Board gameBoard, string letter)
        {
            bool hasLetter = secretword.Contains (letter);
            bool notPlayed = !gameBoard.GetBoard ().Contains (letter);
            return (hasLetter && notPlayed);
        }


        public Board UpdateBoard (string letter, string word)
        {
            StringBuilder sb = new StringBuilder (gameBoard.GetBoard ());
            if (IsScore (gameBoard, letter)) {
                gameBoard.Fill (letter, word);
                return gameBoard;
            } else {
                hp--;
                return gameBoard;
            }
        }

        public Board ProcessInput ()
        {
            string letter = Console.ReadLine ();
            letter = letter.ToUpper ();
            bool score = secretword.Contains (letter);
            return UpdateBoard (letter, secretword);
        }


        public void GameStep ()
        {
            gameBoard.print ();
            Console.WriteLine ("Ingrese una Letra");
            Console.WriteLine ("Intentos restantes: " + hp);
            if (!gameBoard.isVictory ()) {
                gameBoard = ProcessInput ();
            }
        }


    }
}
