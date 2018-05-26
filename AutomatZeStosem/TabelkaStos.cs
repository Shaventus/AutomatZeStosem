using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AutomatZeStosem
{
    class TabelkaStos : Tabelka
    {
        public TabelkaStos(int liczbaStanow, int liczbaZnakow, List<char> zbiorZnakow) : base(liczbaStanow, liczbaZnakow, zbiorZnakow)
        {
            this.inicjuj();
        }

        public override void inicjuj()
        {
            tabelka = new int[liczbaZnakow, liczbaStanow];
            if (zbiorZnakow.Count <= 1) throw new Exception("Za mało znaków");
            if (zbiorZnakow.Count <= 1) throw new Exception("Za mało stanów");
        }

        public override void wklejStan(List<int> stan, int numerStanu)
        {
            for (int i = 0; i < stan.Count; i++)
            {
                tabelka[i, numerStanu] = stan[i];
            }
        }
    }
}
