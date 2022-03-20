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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textUser.Text == "" || textPass.Text == "")
            {
                MessageBox.Show("Molim Vas popunite oba polja!");
                return;
            }
            else
            {
                try
                {
                    SqlConnection veza = Konekcija.connect();
                    string mail = textUser.Text;
                    string sifra = textPass.Text;
                    string naredba1 = $"select * from osoba where email='{mail}'";
                    SqlCommand komanda = new SqlCommand(naredba1,veza);
                    veza.Open();
                    DataTable tabela = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(komanda);
                    adapter.Fill(tabela);
                    int broj = tabela.Rows.Count;
                    if(broj == 1)
                    {
                        if(string.Compare(sifra,tabela.Rows[0]["pass"].ToString()) == 0)
                        {
                            MessageBox.Show("Logovanje uspesno!");
                            Program.user_ime = tabela.Rows[0]["ime"].ToString();
                            Program.user_prezime = tabela.Rows[0]["prezime"].ToString();
                            Program.user_uloga = Convert.ToInt32(tabela.Rows[0]["uloga"]);
                            this.Hide();
                            MainMenu glavna = new MainMenu();
                            glavna.Show();
                        }
                        else
                        {
                            MessageBox.Show("Netacna lozinka!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Uneti email ne postoji!");
                    }
                    veza.Close();
                }
                catch(Exception greska)
                {
                    MessageBox.Show(greska.Message);
                }
            }
        }

        
    }
}
