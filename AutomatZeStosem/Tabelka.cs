using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AutomatZeStosem
{
    class Tabelka
    {
        private int liczbaStanow;
        private int liczbaZnakow;
        private int[,] tabelka;
        private List<char> zbiorZnakow;

        // -1 = stan nieakceptowalny, -2 = stan akceptowalny
        public Tabelka(int liczbaStanow, int liczbaZnakow, List<char> zbiorZnakow)
        {
            tabelka = new int[liczbaZnakow, liczbaStanow];
            if (zbiorZnakow[0] != '$') throw new Exception("Pierwszy znak nie jest pusty!");
            if (zbiorZnakow.Count <= 1) throw new Exception("Za mało znaków");
            if (zbiorZnakow.Count <= 1) throw new Exception("Za mało stanów");

            this.liczbaStanow = liczbaStanow;
            this.liczbaZnakow = liczbaZnakow;
            this.zbiorZnakow = zbiorZnakow;
        }

        public void wklejStan(List<int> stan, int numerStanu)
        {
            if (stan.Count != liczbaStanow) throw new Exception("Definicja stanu ma niepoprawny rozmiar!");
            for (int i=0; i<stan.Count; i++)
            {
                tabelka[i, numerStanu] = stan[i];
            }
        }

        public void dodajZnak(List<int> znak, int numerZnaku)
        {
            if (znak.Count != liczbaZnakow) throw new Exception("Definicja znaku ma niepoprawny rozmiar!");
            for (int i=0; i<znak.Count; i++)
            {
                tabelka[numerZnaku, i] = znak[i];
            }
        }

        public int pobierzStan(int numerZnaku, int numerStanu)
        {
            return tabelka[numerZnaku, numerStanu];
        }

        public int pobierzNastepnyStan(int numerStanu, char znak)
        {
            int numerZnaku = zbiorZnakow.IndexOf(znak);
            return tabelka[numerZnaku, numerStanu];
        }

        public void validateMe()
        {
            for(int i=0; i<liczbaStanow; i++)
            {
                if (tabelka[i, 0] != -1 || tabelka[i, 0] != -2) throw new Exception("Znak końcowy wskazuje na stan inny niż akceptowalny lub nieakceptowalny!");
            }
        }

        public void wypisz()
        {
            for(int i=0; i<liczbaStanow; i++)
            {
                for (int j=0; j<liczbaZnakow; j++)
                {
                    Debug.Write(tabelka[i, j] + ", ");
                }
                Debug.WriteLine("");
            }
        }

    }
}
