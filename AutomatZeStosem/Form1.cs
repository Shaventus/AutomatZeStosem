using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomatZeStosem
{
    public partial class Form1 : Form
    {
        private String wyraz;
        private Automat automat;

        public Form1()
        {
            // a^n b^n
            TabelkaStanow tabelka = new TabelkaStanow(3, 3, new List<Char> { '$', 'a', 'b' });
            tabelka.wklejStan(new List<int> { -1, 0, 1 }, 0);
            tabelka.wklejStan(new List<int> { -1, -1, 1 }, 1);
            tabelka.wklejStan(new List<int> { -2, -1, -1 }, 2);

            TabelkaStanow tabelkaStos = new TabelkaStanow(3, 3, new List<Char> { '$', 'a', 'b' });
            tabelkaStos.wklejStan(new List<int> { 0, 1, 2 }, 0);
            tabelkaStos.wklejStan(new List<int> { 0, 0, 2 }, 1);
            tabelkaStos.wklejStan(new List<int> { 0, 0, 0 }, 2);

            TabelkaStos stos = new TabelkaStos(3, 3, new List<Char> { '#', 'a', 'b' });
            stos.wklejStan(new List<int> { 0, 0, -1 }, 0);
            stos.wklejStan(new List<int> { 2, 1, -1 }, 1);
            stos.wklejStan(new List<int> { 2, -1, -1 }, 2);

            automat = new Automat(tabelka, tabelkaStos, stos);

            InitializeComponent();
            /*
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = -1;
            row.Cells[1].Value = -1;
            row.Cells[2].Value = -1;

            dataGridView1.Rows.Add(row);
            */
            for (int i = 0; i < tabelka.pobierzliczbaZnakow(); i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i].Clone();
                for (int j = 0;j < tabelka.pobierzliczbaStanow(); j++)
                {
                    row.Cells[j].Value = tabelka.pobierzStan(j,i);
                }
                row.HeaderCell.Value = tabelka.pobierzZnak(i).ToString();
                dataGridView1.Rows.Add(row);
            }

            for (int i = 0; i < tabelkaStos.pobierzliczbaZnakow(); i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView2.Rows[i].Clone();
                for (int j = 0; j < tabelkaStos.pobierzliczbaStanow(); j++)
                {
                    row.Cells[j].Value = tabelkaStos.pobierzStan(j, i);
                }
                row.HeaderCell.Value = tabelkaStos.pobierzZnak(i).ToString();
                dataGridView2.Rows.Add(row);
            }

            for (int i = 0; i < stos.pobierzliczbaZnakow(); i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView3.Rows[i].Clone();
                for (int j = 0; j < stos.pobierzliczbaStanow(); j++)
                {
                    row.Cells[j].Value = stos.pobierzStan(j, i);
                }
                row.HeaderCell.Value = stos.pobierzZnak(i).ToString();
                dataGridView3.Rows.Add(row);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            wyraz = textBox1.Text;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void wynik_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // a^n b^n
            TabelkaStanow tabelka = new TabelkaStanow(dataGridView1.Columns.Count, dataGridView1.Rows.Count - 1, new List<Char> { '$', 'a', 'b' });

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                List<int> list = new List<int>();
                for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                {
                    list.Add(Int32.Parse(this.dataGridView1[j, i].Value.ToString()));
                }
                tabelka.wklejStan(list, i);
            }
            //TabelkaGUI.dodajRzad(dataGridView1, "aaa");
            TabelkaStanow tabelkaStos = new TabelkaStanow(dataGridView2.Columns.Count, dataGridView2.Rows.Count - 1, new List<Char> { '$', 'a', 'b' });

            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                List<int> list = new List<int>();
                for (int j = 0; j < dataGridView2.Rows.Count - 1; j++)
                {
                    list.Add(Int32.Parse(this.dataGridView2[j, i].Value.ToString()));
                }
                tabelkaStos.wklejStan(list, i);
            }

            TabelkaStos stos = new TabelkaStos(dataGridView3.Columns.Count, dataGridView3.Rows.Count - 1, new List<Char> { '#', 'a', 'b' });

            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                List<int> list = new List<int>();
                for (int j = 0; j < dataGridView3.Rows.Count - 1; j++)
                {
                    list.Add(Int32.Parse(this.dataGridView3[j, i].Value.ToString()));
                }
                stos.wklejStan(list, i);
            }

            automat = new Automat(tabelka, tabelkaStos, stos);
            wynik.Text = "Wynik: " + automat.Operacja(wyraz);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
