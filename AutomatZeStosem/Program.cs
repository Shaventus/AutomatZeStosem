using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace AutomatZeStosem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*ac
            Tabelka tabelka = new Tabelka(4, 4, new List<Char> { '$', 'a', 'b', 'c' });
            tabelka.wklejStan(new List<int> { -1, 1, 0, 2 }, 0);
            tabelka.wklejStan(new List<int> { -1, -1, -1, 3 }, 1);
            tabelka.wklejStan(new List<int> { -1, 3, -1, -1 }, 2);
            tabelka.wklejStan(new List<int> { -2, 1, 3, 2 }, 3);

            Tabelka tabelkaStos = new Tabelka(4, 4, new List<Char> { '$', 'a', 'b', 'c' });
            tabelkaStos.wklejStan(new List<int> { 0, 0, 0, 0 }, 0);
            tabelkaStos.wklejStan(new List<int> { 0, 0, 0, 0 }, 1);
            tabelkaStos.wklejStan(new List<int> { 0, 0, 0, 0 }, 2);
            tabelkaStos.wklejStan(new List<int> { 0, 0, 0, 0 }, 3);

            TabelkaStos stos = new TabelkaStos(4, 4, new List<Char> { '$', 'a', 'b', 'c' });
            tabelkaStos.wklejStan(new List<int> { 0, 0, 0, 0 }, 0);
            tabelkaStos.wklejStan(new List<int> { 1, 1, 1, 1 }, 1);
            tabelkaStos.wklejStan(new List<int> { 2, 2, 2, 2 }, 2);
            tabelkaStos.wklejStan(new List<int> { 3, 3, 3, 3 }, 3);
            */

            // a^n b^n
            TabelkaStanow tabelka = new TabelkaStanow(3, 3, new List<Char> { '$', 'a', 'b'});
            tabelka.wklejStan(new List<int> { -1, 0, 1}, 0);
            tabelka.wklejStan(new List<int> { -1, -1, 1}, 1);
            tabelka.wklejStan(new List<int> { -2, -1, -1}, 2);

            TabelkaStanow tabelkaStos = new TabelkaStanow(3, 3, new List<Char> { '$', 'a', 'b' });
            tabelkaStos.wklejStan(new List<int> { 0, 1, 2 }, 0);
            tabelkaStos.wklejStan(new List<int> { 0, 0, 2 }, 1);
            tabelkaStos.wklejStan(new List<int> { 0, 0, 0 }, 2);

            TabelkaStos stos = new TabelkaStos(3, 3, new List<Char> { '#', 'a', 'b'});
            stos.wklejStan(new List<int> { 0, 0, -1}, 0);
            stos.wklejStan(new List<int> { 2, 1 , -1}, 1);
            stos.wklejStan(new List<int> { -2, -1, -1 }, 2);

            tabelka.wypisz();

            Automat automat = new Automat(tabelka, tabelkaStos, stos);
            String wyraz = "aaabbb";
            Debug.WriteLine(automat.Operacja(wyraz));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
