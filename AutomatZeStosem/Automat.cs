using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AutomatZeStosem
{
    class Automat
    {
        Tabelka tabelka;
        Tabelka tabelkaStos;
        TabelkaStos tstos;
        private Stack<char> stos;
        private int stan;

        public Automat(Tabelka tabelka, Tabelka tabelkaStos, TabelkaStos tstos)
        {
            this.tabelka = tabelka;
            this.tabelkaStos = tabelkaStos;
            this.tstos = tstos;
            stos = new Stack<char>();
        }

        private void Działaj(char znak)
        {
            Debug.WriteLine(stos.Peek());
            stan = tstos.pobierzNastepnyStan(stan, stos.Peek());
            stan = tabelka.pobierzNastepnyStan(stan, znak);

            if(stan != -2 && stan != -1)
            {
                if (tabelkaStos.pobierzNastepnyStan(stan, znak) == 1)
                {
                    stos.Push(znak);
                    Debug.WriteLine("Stos push:" + tabelkaStos.pobierzNastepnyStan(stan, znak));
                }
                else if (tabelkaStos.pobierzNastepnyStan(stan, znak) == 2)
                {
                    Debug.WriteLine("Stos pop:" + stos.Pop());
                }
            }
            Debug.WriteLine(stan);
        }

        public bool Operacja(String wyraz)
        {
            wyraz = String.Concat(wyraz, "$");
            stos.Push('#');
            stan = 0;
            Debug.WriteLine(stan);
            int i = 0;
            while (stan != -1 && stan != -2 && stos.Count() != 0)
            {
                Działaj(wyraz[i]);
                i++;
            }

            if(stan == -2)
            {
                return true;
            }
            return false;
        }
    }
}
