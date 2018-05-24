using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatZeStosem
{
    class Automat
    {
        private List<char> zst;//zbiór_symboli_terminalnych
        private List<char> szs;//skończony_zbiór_stanów
        private Stack<char> stos;
        private char stan;
        private bool akceptacja;

        public Automat(List<char> zst, List<char> szs)
        {
            this.zst = zst;
            this.szs = szs;
            stos = new Stack<char>();
            akceptacja = true;
        }

        private void Działaj(char znak)
        {
            for(int i = 0; i < zst.Count(); i++)
            {
                if(znak == zst[i])
                {
                    for (int j = 0; ij < szs.Count(); j++)
                    {
                        if (stan == szs[j);
                        stos.Push(znak);
                        stan = szs[i];
                    }
                }
            }
        }

        public bool Operacja(String wyraz)
        {
            wyraz = String.Concat(wyraz, "$");
            stos.Push('#');
            for (int i = 0;i < wyraz.Length; i++)
            {
                Działaj(wyraz[i]);
            }
            return akceptacja;
        }
    }
}
