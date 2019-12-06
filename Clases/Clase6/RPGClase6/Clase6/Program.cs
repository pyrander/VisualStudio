using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase6 {
    class Program {
        static void Main (string[] args)
        {
            Console.WriteLine ("Character type:");
            Console.WriteLine ("\t1-Wizard");
            Console.WriteLine ("\t2-Warrior");
            Console.WriteLine ("\t3-Rogue");
            string type = Console.ReadLine ();
            Character myCharacter = null;
            switch (type) {
                case "1":
                    myCharacter = new Wizard ("Rogelio");
                    break;
                case "2":
                    myCharacter = new Warrior ("Jesus");
                    break;
                case "3":
                    myCharacter = new Rogue ("Ivan");
                    break;
                default:
                    break;
            }
            if (myCharacter!=null) {
                myCharacter.ShowActionMenu();
            }

            Console.ReadLine ();
        }
    }
}
