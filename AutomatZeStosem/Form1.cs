using Microsoft.VisualBasic;
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
        private int krok;
        private List<String> list;
        private string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
        private string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();

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
            automat.PrzypiszList(list);
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
                    row.Cells[j].Value = tabelka.pobierzStan(i,j);
                }
                row.HeaderCell.Value = tabelka.pobierzZnak(i).ToString();
                dataGridView1.Rows.Add(row);
            }

            for (int i = 0; i < tabelkaStos.pobierzliczbaZnakow(); i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView2.Rows[i].Clone();
                for (int j = 0; j < tabelkaStos.pobierzliczbaStanow(); j++)
                {
                    row.Cells[j].Value = tabelkaStos.pobierzStan(i, j);
                }
                row.HeaderCell.Value = tabelkaStos.pobierzZnak(i).ToString();
                dataGridView2.Rows.Add(row);
            }

            for (int i = 0; i < stos.pobierzliczbaZnakow(); i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView3.Rows[i].Clone();
                for (int j = 0; j < stos.pobierzliczbaStanow(); j++)
                {
                    row.Cells[j].Value = stos.pobierzStan(i, j);
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
            krok = 0;
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
                    list.Add(Int32.Parse(this.dataGridView1[i, j].Value.ToString()));
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
                    list.Add(Int32.Parse(this.dataGridView2[i, j].Value.ToString()));
                }
                tabelkaStos.wklejStan(list, i);
            }

            TabelkaStos stos = new TabelkaStos(dataGridView3.Columns.Count, dataGridView3.Rows.Count - 1, new List<Char> { '#', 'a', 'b' });

            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                List<int> list = new List<int>();
                for (int j = 0; j < dataGridView3.Rows.Count - 1; j++)
                {
                    list.Add(Int32.Parse(this.dataGridView3[i, j].Value.ToString()));
                }
                stos.wklejStan(list, i);
            }

            listView1.Clear();
            automat = new Automat(tabelka, tabelkaStos, stos);
            wynik.Text = "Wynik: " + automat.Operacja(wyraz);
            for(int i = 0; i < automat.PobierzList().Count(); i++)
            {
                listView1.Items.Add(new ListViewItem(automat.PobierzList()[i]));
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            krok++;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (TabelkaGUI.pobierzLiczbeStanow(dataGridView1) == 0)
            {
                MessageBox.Show("Najpierw dodaj stany");
                return;
            }

            string input = String.Empty;
            while (String.IsNullOrEmpty(input))
            {
                try
                {
                    input = Interaction.InputBox("Dozwolone symbole a-z0-9 oraz $ (znak pusty)", "Podaj znak", String.Empty, (Int32.Parse(screenWidth) / 2) - 150, (Int32.Parse(screenHeight) / 2) - 100);
                    if (input == String.Empty) break;
                    char c = Char.Parse(input);
                    if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9') || c == '$')
                    {
                        if (!TabelkaGUI.czyIstniejeRzad(dataGridView1, input)) TabelkaGUI.dodajRzad(dataGridView1, input);
                        else MessageBox.Show("Taki znak już istnieje!");
                    }
                    else
                    {
                        MessageBox.Show("Niedozwolony symbol!");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Możesz podać pojedyńczy symbol!");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TabelkaGUI.dodajKolumne(dataGridView1, "q" + (TabelkaGUI.pobierzLiczbeStanow(dataGridView1)).ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                TabelkaGUI.usunOstatniRzad(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                TabelkaGUI.usunOstatniaKolumne(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
