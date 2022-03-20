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
    public partial class Osoba : Form
    {
        int mesto = 0;
        DataTable tabela;

        private void napuni_tabelu()
        {
            SqlConnection veza = Konekcija.connect();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from osoba",veza);
            tabela = new DataTable();
            adapter.Fill(tabela);
        }

        private void osvezi()
        {
            if (tabela.Rows.Count <= 0)
            {
                textID.Text = "";
                textIME.Text = "";
                textPREZIME.Text = "";
                textADRESA.Text = "";
                textPASS.Text = "";
                textULOGA.Text = "";
                textMAIL.Text = "";
                textJMBG.Text = "";
            }
            else
            {
                if (mesto == 0)
                {
                    btLevo.Enabled = false;
                    btLevoSkroz.Enabled = false;
                }
                else
                {
                    btLevo.Enabled = true;
                    btLevoSkroz.Enabled = true;
                }

                if (mesto == tabela.Rows.Count - 1)
                {
                    btDesno.Enabled = false;
                    btDesnoSkroz.Enabled = false;
                }
                else
                {
                    btDesno.Enabled = true;
                    btDesnoSkroz.Enabled = true;
                }
                textID.Text = tabela.Rows[mesto]["id"].ToString();
                textIME.Text = tabela.Rows[mesto]["ime"].ToString();
                textPREZIME.Text = tabela.Rows[mesto]["prezime"].ToString();
                textADRESA.Text = tabela.Rows[mesto]["adresa"].ToString();
                textPASS.Text = tabela.Rows[mesto]["pass"].ToString();
                textULOGA.Text = tabela.Rows[mesto]["uloga"].ToString();
                textMAIL.Text = tabela.Rows[mesto]["email"].ToString();
                textJMBG.Text = tabela.Rows[mesto]["jmbg"].ToString();
            }
        }


        public Osoba()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            napuni_tabelu();
            osvezi();
        }

        private void btLevoSkroz_Click(object sender, EventArgs e)
        {
            mesto = 0;
            osvezi();
        }

        private void btLevo_Click(object sender, EventArgs e)
        {
            mesto--;
            osvezi();
        }

        private void btDesno_Click(object sender, EventArgs e)
        {
            mesto++;
            osvezi();
        }

        private void btDesnoSkroz_Click(object sender, EventArgs e)
        {
            mesto = tabela.Rows.Count - 1;
            osvezi();
        }

        private void btDodaj_Click(object sender, EventArgs e)
        {
            textID.Text = "";
            textIME.Text = "";
            textPREZIME.Text = "";
            textADRESA.Text = "";
            textPASS.Text = "";
            textULOGA.Text = "";
            textMAIL.Text = "";
            textJMBG.Text = "";
            btDodaj.Enabled = false;
            btUbaci.Enabled = true;
            btLevo.Enabled = false;
            btLevoSkroz.Enabled = false;
            btDesno.Enabled = false;
            btDesnoSkroz.Enabled = false;
            btObrisi.Enabled = false;
            btIzmeni.Enabled = false;
            btOtkazi.Visible = true;
            btOtkazi.Enabled = true;
        }

        private void btUbaci_Click(object sender, EventArgs e)
        {
            if(textADRESA.Text=="" || textIME.Text=="" || textJMBG.Text=="" || textMAIL.Text==""
                || textPASS.Text=="" || textPREZIME.Text=="" || textULOGA.Text=="")
            {
                MessageBox.Show("Molim Vas popunite sva polja");
            }
            else
            {
               try
                {
                    string ime = textIME.Text;
                    string prezime = textPREZIME.Text;
                    string email = textMAIL.Text;
                    string lozinka = textPASS.Text;
                    int uloga = Convert.ToInt32(textULOGA.Text);
                    string adresa = textADRESA.Text;
                    string jmbg = textJMBG.Text;
                    string naredba = $"insert into osoba (ime,prezime,adresa,jmbg,email,pass,uloga) VALUES('{ime}'" +
                        $",'{prezime}','{adresa}','{jmbg}','{email}','{lozinka}',{uloga})";
                    SqlConnection veza = Konekcija.connect();
                    SqlCommand komanda = new SqlCommand(naredba, veza);
                    veza.Open();
                    komanda.ExecuteNonQuery();
                    veza.Close();
                    MessageBox.Show("Uspesno dodata osoba!");
                    btUbaci.Enabled = false;
                    btDodaj.Enabled = true;
                    btLevo.Enabled = true;
                    btLevoSkroz.Enabled = true;
                    btDesno.Enabled = true;
                    btDesnoSkroz.Enabled = true;
                    btObrisi.Enabled = true;
                    btIzmeni.Enabled = true;
                    btOtkazi.Visible = false;
                    btOtkazi.Enabled = false;
                    napuni_tabelu();
                    osvezi();
                }
                catch
                {
                    MessageBox.Show("Molim Vas ispravno unesite svako polje!");
                }
            }
        }

        private void btOtkazi_Click(object sender, EventArgs e)
        {
            btOtkazi.Visible = false;
            btOtkazi.Enabled = false;
            btUbaci.Enabled = false;
            btDodaj.Enabled = true;
            btLevo.Enabled = true;
            btLevoSkroz.Enabled = true;
            btDesno.Enabled = true;
            btDesnoSkroz.Enabled = true;
            btObrisi.Enabled = true;
            btIzmeni.Enabled = true;
            osvezi();
        }

        private void btIzmeni_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textID.Text);
                string ime = textIME.Text;
                string prezime = textPREZIME.Text;
                string email = textMAIL.Text;
                string lozinka = textPASS.Text;
                int uloga = Convert.ToInt32(textULOGA.Text);
                string adresa = textADRESA.Text;
                string jmbg = textJMBG.Text;
                string naredba = $"update osoba set ime='{ime}', prezime='{prezime}', adresa='{adresa}', " +
                    $"email='{email}', uloga={uloga}, pass='{lozinka}', jmbg='{jmbg}' where id={id}";
                SqlConnection veza = Konekcija.connect();
                SqlCommand komanda = new SqlCommand(naredba, veza);
                veza.Open();
                komanda.ExecuteNonQuery();
                veza.Close();
                MessageBox.Show("Izmena je uspesna!");
                napuni_tabelu();
                osvezi();
            }
            catch
            {
                MessageBox.Show("Molim Vas ispravno uensite svako polje!");
            }
        }

        private void btObrisi_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textID.Text);
                string naredba1 = $"delete from osoba where id={id}";
                SqlConnection veza = Konekcija.connect();
                SqlCommand komanda1 = new SqlCommand(naredba1, veza);
                veza.Open();
                komanda1.ExecuteNonQuery();
                veza.Close();
                MessageBox.Show("Osoba uspesno obrisana!");
                if (mesto != 0) mesto--;
                else mesto = 0;
                napuni_tabelu();
                osvezi();
            }
            catch
            {
               MessageBox.Show("Nismo mogli da obrisemo dati podatak! Pokusajte ponovo!");
            }
        }
    }
}
