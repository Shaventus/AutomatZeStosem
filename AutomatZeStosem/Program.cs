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
            Tabelka tabelka = new Tabelka(4, 4, new List<Char> { '$', 'a', 'b', 'c' });
            tabelka.wklejStan(new List<int> { -1, 0, 1, 2 }, 0);
            tabelka.wklejStan(new List<int> { -1, -1, -1, 3 }, 1);
            tabelka.wklejStan(new List<int> { -1, 3, -1, -1 }, 2);
            tabelka.wklejStan(new List<int> { -2, 1, 3, 2 }, 3);

            tabelka.wypisz();

            Automat automat = new Automat(tabelka);
            String wyraz = "aaabbb";
            Debug.WriteLine(automat.Operacja(wyraz));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
