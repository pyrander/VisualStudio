using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame {
    class Board {
        private string board="";
        private bool victory=false;

        public string GetBoard () {
            return board;
        }

        public bool isVictory ()
        {
            return victory;
        }

        public void initBoard (int length, char fillChar)
        {
            for (int i = 0; i < length; i++) {
                this.board = string.Concat (board, fillChar);
            }
        }

        public void print ()
        {
            StringBuilder printableBoard = new StringBuilder ("");
            for (int i = 0; i < board.Length; i++) {
                printableBoard.Append (board.ToCharArray ()[i]);
                printableBoard.Append (" ");
            }
            Draw(printableBoard.ToString ());
        }

        public void Fill (string letter, string word)
        {
            StringBuilder newBoard = new StringBuilder (board);
            for (int i = 0; i < word.Length; i++) {
                if (letter[0] == word[i]) {
                    newBoard[i] = word[i];
                }
            }
            board = newBoard.ToString ();
            if (board == word) {
                victory = true;
            }
        }

        public int Faltantes () {
            int faltantes = 0;
            for (int i = 0; i < board.Length; i++) {
                if ('_' == board[i]) {
                    faltantes++;
                }
            }
            return faltantes;
        }

        public void Clear () {
            Console.Clear ();
        }

        public void Draw (string line) {
            Console.WriteLine (line);
        }

        public void Close () {
            Console.WriteLine ("Presione Enter para Cerrar");
            Console.ReadLine ();
        }

    }
}
