using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase6 {
    abstract class Character {
        public string name;
        public int hp;
        public Stats stats;

        public Character (string name) {
            this.name = name;
            this.hp = 20;
            this.stats = new Stats ();
        }

        public Character (string name, int hp)
        {
            this.name = name;
            this.hp = hp;
            this.stats = new Stats ();
        }

        public Character (string name, int hp, Stats stats)
        {
            this.name = name;
            this.hp = hp;
            this.stats = stats;
        }
        public void Attack () {
            Console.WriteLine ("el " + this.GetType ().Name + " te ataca");
            Wait ();
        }

        public void Walk ()
        {
            Console.WriteLine ("el " + this.GetType ().Name + " camina");
            Wait ();
        }

        public void Jump ()
        {
            Console.WriteLine ("el " + this.GetType ().Name + " salta");
            Wait ();
        }

        public void Wait () {
            for (int i = 0; i < 5; i++) {
                Console.Write (". ");
                System.Threading.Thread.Sleep (600);
            }
        }

        public void ShowActionMenu ()
        {
            Console.Clear ();
            Console.WriteLine ("ACTIONS");
            Console.WriteLine ("=======");
            Console.WriteLine ("1- Caminar");
            Console.WriteLine ("2- Saltar");
            Console.WriteLine ("3- Atacar");

            string action = Console.ReadLine ();

            switch (action) {
                case "1":
                    Walk ();
                    break;
                case "2":
                    Jump ();
                    break;
                case "3":
                    Attack ();
                    break;
                default:
                    break;
            }
            ShowActionMenu ();
        }
    }
}
