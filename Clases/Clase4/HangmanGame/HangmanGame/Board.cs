using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame {
    class Board {
        private string board;
        private string printableBoard;
        private bool victory;

        public void setBoard (string board) {
            this.board = board;
        }

        public string getBoard (){
            return board;
        }

        public void setPrintableBoard (string printableBoard)
        {
            this.printableBoard = printableBoard;
        }

        public string getPrintableBoard ()
        {
            return printableBoard;
        }

        public void setVictory (bool victory) {
            this.victory = victory;
        }

        public bool isVictory ()
        {
            return victory;
        }
    }
}
