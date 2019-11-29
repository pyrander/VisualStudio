using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame {
    class Board {
        private string board;
        private bool victory=false;

        public void setBoard (string board) {
            this.board = board;
        }

        public string getBoard (){
            return board;
        }

        public void setVictory (bool victory) {
            this.victory = victory;
        }

        public bool isVictory ()
        {
            return victory;
        }


        static string printBoard () {
            StringBuilder printableBoard = new StringBuilder("");
            for (int i = 0; i < board.Length; i++) {
                printableBoard.Append (board.ToCharArray ()[i]);
                printableBoard.Append (" ");
            }
            Console.WriteLine(printableBoard.ToString());
            Console.WriteLine("Ingrese una letra: ");
        }
    }
}
