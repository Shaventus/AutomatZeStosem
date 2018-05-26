using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AutomatZeStosem
{
    class TabelkaStanow : Tabelka
    {
        public TabelkaStanow(int liczbaStanow, int liczbaZnakow, List<char> zbiorZnakow) : base(liczbaStanow, liczbaZnakow, zbiorZnakow)
        {
            base.inicjuj();
        }
    }
}
