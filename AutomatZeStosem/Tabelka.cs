using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatZeStosem
{
    abstract class Tabelka
    {
        protected int liczbaStanow;
        protected int liczbaZnakow;
        protected int[,] tabelka;
        protected List<char> zbiorZnakow;

        // -1 = stan nieakceptowalny, -2 = stan akceptowalny
        protected Tabelka(int liczbaStanow, int liczbaZnakow, List<char> zbiorZnakow)
        {
            this.liczbaStanow = liczbaStanow;
            this.liczbaZnakow = liczbaZnakow;
            this.zbiorZnakow = zbiorZnakow;
        }


        public virtual void inicjuj()
        {
            tabelka = new int[liczbaZnakow, liczbaStanow];
            if (zbiorZnakow[0] != '$') throw new Exception("Pierwszy znak nie jest pusty!");
            if (zbiorZnakow.Count <= 1) throw new Exception("Za mało znaków");
            if (zbiorZnakow.Count <= 1) throw new Exception("Za mało stanów");
        }

        public virtual void wklejStan(List<int> stan, int numerStanu)
        {
            if (stan.Count != liczbaStanow) throw new Exception("Definicja stanu ma niepoprawny rozmiar!");
            for (int i = 0; i < stan.Count; i++)
            {
                tabelka[i, numerStanu] = stan[i];
            }
        }

        public virtual void dodajZnak(List<int> znak, int numerZnaku)
        {
            if (znak.Count != liczbaZnakow) throw new Exception("Definicja znaku ma niepoprawny rozmiar!");
            for (int i = 0; i < znak.Count; i++)
            {
                tabelka[numerZnaku, i] = znak[i];
            }
        }

        public virtual int pobierzStan(int numerZnaku, int numerStanu)
        {
            return tabelka[numerZnaku, numerStanu];
        }

        public virtual char pobierzZnak(int numerZnaku)
        {
            return zbiorZnakow[numerZnaku];
        }

        public virtual int pobierzNastepnyStan(int numerStanu, char znak)
        {
            int numerZnaku = zbiorZnakow.IndexOf(znak);
            return tabelka[numerZnaku, numerStanu];
        }

        public virtual void validateMe()
        {
            for (int i = 0; i < liczbaStanow; i++)
            {
                if (tabelka[i, 0] != -1 || tabelka[i, 0] != -2) throw new Exception("Znak końcowy wskazuje na stan inny niż akceptowalny lub nieakceptowalny!");
            }
        }

        public virtual void wypisz()
        {
            for (int i = 0; i < liczbaStanow; i++)
            {
                for (int j = 0; j < liczbaZnakow; j++)
                {
                    Debug.Write(tabelka[i, j] + ", ");
                }
                Debug.WriteLine("");
            }
        }

        public virtual int pobierzliczbaStanow()
        {
            return liczbaStanow;
        }

        public virtual int pobierzliczbaZnakow()
        {
            return liczbaZnakow;
        }
    }
}
