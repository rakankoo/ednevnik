using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ednevnik
{
    public partial class Raspodela : Form
    {
        DataTable tabela;
        int poz = 0;

        public Raspodela()
        {
            InitializeComponent();
        }

        private void ucitajPodatke()
        {
            SqlConnection veza = Konekcija.connect();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from raspodela", veza);
            tabela = new DataTable();
            adapter.Fill(tabela);
        }

        private void Raspodela_Load(object sender, EventArgs e)
        {
            ucitajPodatke();
            napuni_combo();
        }

        private void napuni_combo()
        {
            SqlConnection veza = Konekcija.connect();
            SqlDataAdapter adapter;
            DataTable dtnastavnik, dtgodina, dtpredmet, dtodeljenje;

            adapter = new SqlDataAdapter("select * from skolska_godina", veza);
            dtgodina = new DataTable();
            adapter.Fill(dtgodina);

            adapter = new SqlDataAdapter("select id,ime +' '+ prezime as naziv from osoba where uloga=2", veza);
            dtnastavnik = new DataTable();
            adapter.Fill(dtnastavnik);

            adapter = new SqlDataAdapter("select id,STR(razred) + '/' +indeks as naziv from odeljenje", veza);
            dtodeljenje = new DataTable();
            adapter.Fill(dtodeljenje);

            adapter = new SqlDataAdapter("select id,naziv from predmet", veza);
            dtpredmet = new DataTable();
            adapter.Fill(dtpredmet);

            cmb_godina.DataSource = dtgodina;
            cmb_godina.ValueMember = "id";
            cmb_godina.DisplayMember = "naziv";
            

            cmb_nastavnik.DataSource = dtnastavnik;
            cmb_nastavnik.ValueMember = "id";
            cmb_nastavnik.DisplayMember = "naziv";
            

            cmb_odeljenje.DataSource = dtodeljenje;
            cmb_odeljenje.ValueMember = "id";
            cmb_odeljenje.DisplayMember = "naziv";
            

            cmb_predmet.DataSource = dtpredmet;
            cmb_predmet.ValueMember = "id";
            cmb_predmet.DisplayMember = "naziv";
            

            textBox1.Text = tabela.Rows[poz]["id"].ToString();

            if (tabela.Rows.Count==0)
            {
                cmb_predmet.SelectedValue = -1;
                cmb_odeljenje.SelectedValue = -1;
                cmb_nastavnik.SelectedValue = -1;
                cmb_godina.SelectedValue = -1;

            }
            else
            {
                cmb_predmet.SelectedValue = tabela.Rows[poz]["predmet_id"];
                cmb_odeljenje.SelectedValue = tabela.Rows[poz]["odeljenje_id"];
                cmb_godina.SelectedValue = tabela.Rows[poz]["godina_id"];
                cmb_nastavnik.SelectedValue = tabela.Rows[poz]["nastavnik_id"];
            }
            if (poz == 0)
            {
                btLevo.Enabled = false;
                btLevoSkroz.Enabled = false;
            }
            else
            {
                btLevo.Enabled = true;
                btLevoSkroz.Enabled = true;
            }

            if (poz == tabela.Rows.Count - 1)
            {
                btDesno.Enabled = false;
                btDesnoSkroz.Enabled = false;
            }
            else
            {
                btDesno.Enabled = true;
                btDesnoSkroz.Enabled = true;
            }
        }

        private void btLevoSkroz_Click(object sender, EventArgs e)
        {
            poz = 0;
            napuni_combo();
        }

        private void btLevo_Click(object sender, EventArgs e)
        {
            poz--;
            napuni_combo();
        }

        private void btDesno_Click(object sender, EventArgs e)
        {
            poz++;
            napuni_combo();
        }

        private void btDesnoSkroz_Click(object sender, EventArgs e)
        {
            poz = tabela.Rows.Count - 1;
            napuni_combo();
        }

        private void btObrisi_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                string naredba1 = $"delete from raspodela where id={id}";
                SqlConnection veza = Konekcija.connect();
                SqlCommand komanda1 = new SqlCommand(naredba1, veza);
                veza.Open();
                komanda1.ExecuteNonQuery();
                veza.Close();
                MessageBox.Show("Podatak uspesno obrisan!");
                if (poz != 0) poz--;
                else poz = 0;
                ucitajPodatke();
                napuni_combo();
            }
            catch
            {
                MessageBox.Show("Nismo mogli da obrisemo dati podatak! Pokusajte ponovo!");
            }
        }     

        private void btUbaci_Click(object sender, EventArgs e)
        {
            if (cmb_predmet.Text == "" || cmb_odeljenje.Text == "" || cmb_nastavnik.Text == ""
                || cmb_godina.Text == "")
            {
                MessageBox.Show("Molim Vas popunite sva polja");
            }
            else
            {
                try
                {
                    int nastavnik = (int)cmb_nastavnik.SelectedValue;
                    int godina = (int)cmb_godina.SelectedValue;
                    int predmet = (int)cmb_predmet.SelectedValue;
                    int odeljenje = (int)cmb_odeljenje.SelectedValue;
                    string naredba = $"insert into raspodela (godina_id,nastavnik_id,predmet_id,odeljenje_id) VALUES({godina}" +
                        $",{nastavnik},{predmet},{odeljenje})";
                    SqlConnection veza = Konekcija.connect();
                    SqlCommand komanda = new SqlCommand(naredba, veza);
                    veza.Open();
                    komanda.ExecuteNonQuery();
                    veza.Close();
                    MessageBox.Show("Uspesno dodat podatak!");
                    ucitajPodatke();
                    poz = tabela.Rows.Count - 1;
                    napuni_combo();
                }
                catch
                {
                    MessageBox.Show("Molim Vas ispravno unesite svako polje!");
                }
            }
        }

        private void btIzmeni_Click(object sender, EventArgs e)
        {
            try
            {
                int nastavnik = (int)cmb_nastavnik.SelectedValue;
                int godina = (int)cmb_godina.SelectedValue;
                int predmet = (int)cmb_predmet.SelectedValue;
                int odeljenje = (int)cmb_odeljenje.SelectedValue;
                int id = Convert.ToInt32(textBox1.Text);
                string naredba = $"update raspodela set nastavnik_id={nastavnik}, predmet_id={predmet}, " +
                    $"godina_id={godina}, odeljenje_id={odeljenje} where id={id}";
                SqlConnection veza = Konekcija.connect();
                SqlCommand komanda = new SqlCommand(naredba, veza);
                veza.Open();
                komanda.ExecuteNonQuery();
                veza.Close();
                MessageBox.Show("Izmena je uspesna!");
                ucitajPodatke();
                napuni_combo();
            }
            catch
            {
                MessageBox.Show("Molim Vas ispravno uensite svako polje!");
            }
        }
    }
}
