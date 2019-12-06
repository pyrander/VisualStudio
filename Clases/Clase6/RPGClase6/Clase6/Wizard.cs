using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase6 {
    class Wizard : Character{
        public int mp;

        public Wizard (string name) : base (name)
        {
            Console.WriteLine ("> Creando Wizard");
        }

        public Wizard (string name, int hp, int mp) : base (name, hp)
        {
            this.mp = mp;
        }

        public Wizard (string name, int hp, int mp, Stats stats) : base (name, hp, stats)
        {
            this.mp = mp;
        }
    }
}
