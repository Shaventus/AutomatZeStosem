using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AutomatZeStosem
{
    class Automat
    {
        Tabelka tabelka;
        private Stack<char> stos;
        private int stan;
        private bool akceptacja;

        public Automat(Tabelka tabelka)
        {
            this.tabelka = tabelka;
            stos = new Stack<char>();
            akceptacja = true;
        }

        private void Działaj(char znak)
        {
            stan = tabelka.pobierzNastepnyStan(stan, znak);
            Debug.WriteLine(stan);
        }

        public bool Operacja(String wyraz)
        {
            wyraz = String.Concat(wyraz, "$");
            stos.Push('#');
            stan = 0;
            Debug.WriteLine(stan);
            int i = 0;
            while (stan != -1 && wyraz[i] != '$' && stan != -2)
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
