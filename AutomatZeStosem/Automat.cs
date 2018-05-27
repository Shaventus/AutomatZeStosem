using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace AutomatZeStosem
{
    class Automat
    {
        TabelkaStanow tabelka;
        TabelkaStanow tabelkaStos;
        TabelkaStos tstos;
        private Stack<char> stos;
        private int stan;
        private List<String> list;
        private String slist;

        public Automat(TabelkaStanow tabelka, TabelkaStanow tabelkaStos, TabelkaStos tstos)
        {
            this.tabelka = tabelka;
            this.tabelkaStos = tabelkaStos;
            this.tstos = tstos;
            stos = new Stack<char>();
        }

        public void PrzypiszList(List<String> list)
        {
            this.list = list;
        }

        public List<String> PobierzList()
        {
            return list;
        }

        private void Działaj(char znak, DataGridView ptabelka, DataGridView ptabelkastos, DataGridView pstos)
        {
            int y = 0;
            Debug.WriteLine(stos.Peek());
            stan = tstos.pobierzNastepnyStan(stan, stos.Peek());

            if (stan != -1 && stan != -2)
            {
                y = TabelkaGUI.pobierzIndeksZnaku(ptabelkastos, znak.ToString());
                TabelkaGUI.zaznaczKomorke(ptabelkastos, stan, y);
                System.Threading.Thread.Sleep(750);
            }

            if (stan != -1 && stan != -2)
            {
                y = TabelkaGUI.pobierzIndeksZnaku(ptabelka, znak.ToString());
                TabelkaGUI.zaznaczKomorke(ptabelka, stan, y);
                //System.Threading.Thread.Sleep(250);
            }

            stan = tabelka.pobierzNastepnyStan(stan, znak);

            slist = String.Concat(slist, " Stos: " + stos.Peek().ToString());
            slist = String.Concat(slist, " Stan: " + stan);
            if (stan != -2 && stan != -1)
            {
                y = TabelkaGUI.pobierzIndeksZnaku(pstos, znak.ToString());
                TabelkaGUI.zaznaczKomorke(pstos, stan, y);

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

            Debug.WriteLine("stan3:" + stan);
        }

        public bool Operacja(String wyraz, DataGridView ptabelka, DataGridView ptabelkastos, DataGridView pstos)
        {
            wyraz = String.Concat(wyraz, "$");
            stos.Push('#');
            stan = 0;
            Debug.WriteLine(stan);
            int i = 0;
            list = new List<String>();
            while (stan != -1 && stan != -2 && stos.Count() != 0)
            {
                slist = "";
                slist = String.Concat(slist, "Krok: " + i);
                slist = String.Concat(slist, " Znak: " + wyraz[i]);

                Działaj(wyraz[i], ptabelka, ptabelkastos, pstos);
                //TabelkaGUI.zaznaczKomorke(tabelka, stan, y);
                //int x = this.tabelka.pobierzNumerZnaku(wyraz[i]);
                //TabelkaGUI.zaznaczKomorke(tabelka, x, y);

                i++;
                list.Add(slist);
               
            }

            if (stan == -2)
            {
                return true;
            }
            return false;
        }

        public void waliduj(string wyraz)
        {
            try
            {
                tabelka.walidacja(wyraz);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
