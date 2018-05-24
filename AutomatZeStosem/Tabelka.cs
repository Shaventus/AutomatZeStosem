using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatZeStosem
{
    class Tabelka
    {
        int liczbaStanow;
        int liczbaZnakow;
        int[,] tabelka;
        List<char> zbiorZnakow;

        // -1 = stan nieakceptowalny, -2 = stan akceptowalny
        public Tabelka(int liczbaStanow, int liczbaZnakow, List<char> zbiorZnakow)
        {
            tabelka = new int[liczbaStanow, liczbaZnakow];
            if (zbiorZnakow[0] != '$') throw new Exception("Pierwszy znak nie jest pusty!");
            if (zbiorZnakow.Count <= 1) throw new Exception("Za mało znaków");

            this.liczbaStanow = liczbaStanow;
            this.liczbaZnakow = liczbaZnakow;
            this.zbiorZnakow = zbiorZnakow;
        }

        public void wklejStan(List<int> stan, int numerStanu)
        {
            if (stan.Count != liczbaZnakow) throw new Exception("Definicja stanu ma niepoprawny rozmiar!");
            for (int i=0; i<stan.Count; i++)
            {
                tabelka[numerStanu, i] = stan[i];
            }
        }

        public void dodajZnak(List<int> znak, int numerZnaku)
        {
            if (znak.Count != liczbaStanow) throw new Exception("Definicja znaku ma niepoprawny rozmiar!");
            for (int i=0; i<znak.Count; i++)
            {
                tabelka[i, numerZnaku] = znak[i];
            }
        }

        public int pobierzNastepnyStan(int numerStanu, char znak)
        {
            int numerZnaku = zbiorZnakow.IndexOf(znak);
            return tabelka[numerStanu, numerZnaku];
        }

        public void validateMe()
        {
            for(int i=0; i<liczbaStanow; i++)
            {
                if (tabelka[0, i] != -1 || tabelka[0, i] != -2) throw new Exception("Znak końcowy wskazuje na stan inny niż akceptowalny lub nieakceptowalny!");
            }
        }
    }
}
