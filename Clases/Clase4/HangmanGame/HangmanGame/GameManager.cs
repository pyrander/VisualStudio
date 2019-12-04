using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame {
    class GameManager {
        string secretword = "";
        Board gameBoard;
        Player player;
        bool playing;

        public GameManager (string secretword) {
            this.secretword = secretword;
            this.gameBoard = new Board (secretword);
            this.player = new Player ();
            this.playing = true;
        }

        public bool IsPlaying () {
            return playing;
        }

        public Player GetPlayer ()
        {
            return player;
        }

        public Board GetBoard () {
            return gameBoard;
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
                Console.Beep ();
                return gameBoard;
            } else {
                Console.Beep (10000, 500);
                player.LoseLife () ;
                if (!player.IsAlive()) {
                    playing = false;
                }
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
            gameBoard.Draw ("Ingrese una Letra");
            gameBoard.Draw (player.Life());
            if (!gameBoard.IsVictory ()) {
                gameBoard = ProcessInput ();
            } else {
                playing = false;
            }
        }


    }
}
