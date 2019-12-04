using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame {
    class Player {

        int hp = 3;

        public string Life () {
            return "Intentos restantes: " + hp;
        }

        public void LoseLife () {
            hp--;
        }

        public bool IsAlive () {
            return hp >= 1;
        }
    }
}
