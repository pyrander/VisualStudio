using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto {
    class Letter {
        private string symbol = "";

        public Letter (string symbol)
        {
            this.symbol = symbol;
        }

        public string GetSymbol ()
        {
            return symbol;
        }
    }
}
