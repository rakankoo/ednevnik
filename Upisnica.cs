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
    public partial class Upisnica : Form
    {
        public Upisnica()
        {
            InitializeComponent();
        }

        DataTable dtupisnica;

        private void cmb_godina_populate()
        {
            SqlConnection veza = Konekcija.connect();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Skolska_godina", veza);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            cmb_godina.DataSource = tabela;
            cmb_godina.ValueMember = "id";
            cmb_godina.DisplayMember = "naziv";
            cmb_godina.SelectedValue = 2;

        }

        private void cmb_odeljenje_populate()
        {
            string godina = cmb_godina.SelectedValue.ToString();
            SqlConnection veza = Konekcija.connect();
            SqlDataAdapter adapter = new SqlDataAdapter("select id, STR(razred) + ' - ' + indeks as naziv from Odeljenje where godina_id = " + godina, veza);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            cmb_odeljenje.DataSource = tabela;
            cmb_odeljenje.ValueMember = "id";
            cmb_odeljenje.DisplayMember = "naziv";
            cmb_odeljenje.SelectedIndex = -1;
        }

        private void Upisnica_Load(object sender, EventArgs e)
        {
            cmb_godina_populate();
            cmb_odeljenje_populate();
            cmb_ucenik_populate();
            cmb_ucenik.Enabled = false;
            cmb_ucenik.SelectedIndex = -1;
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {

        }

        private void cmb_godina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmb_godina.IsHandleCreated && cmb_godina.Focused)
            {
                cmb_odeljenje_populate();
                cmb_ucenik.SelectedIndex = -1;
                while(dataGridView1.Rows.Count>0)
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[0]);
                }
                txt_upisnica.Text = "";
                cmb_ucenik.SelectedIndex = -1;
                cmb_ucenik.Enabled = false;

            }
        }

        private void cmb_odeljenje_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmb_odeljenje.IsHandleCreated && cmb_odeljenje.Focused)
            {
                
                cmb_ucenik.Enabled = true;
                grid_populate();
            }
        }

        private void cmb_ucenik_populate()
        {
            SqlConnection veza = Konekcija.connect();
            SqlDataAdapter adapter = new SqlDataAdapter("select id, ime + prezime as naziv from osoba where uloga = 1", veza);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            cmb_ucenik.DataSource = tabela;
            cmb_ucenik.ValueMember = "id";
            cmb_ucenik.DisplayMember = "naziv";
        }

        private void grid_populate()
        {
            SqlConnection veza = Konekcija.connect();
            SqlDataAdapter adapter = new SqlDataAdapter("select upisnica.id, ime + prezime as naziv, osoba.id as ucenik from upisnica join osoba on osoba_id=osoba.id where odeljenje_id = " + cmb_odeljenje.SelectedValue.ToString(), veza);
            dtupisnica = new DataTable();
            adapter.Fill(dtupisnica);
            dataGridView1.DataSource = dtupisnica;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns["ucenik"].Visible = false;
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow!=null)
            {
                int broj = dataGridView1.CurrentRow.Index;
                if (dtupisnica.Rows.Count != 0 && broj >= 0)
                {
                    cmb_ucenik.SelectedValue = dataGridView1.Rows[broj].Cells["ucenik"].Value.ToString();
                    txt_upisnica.Text = dataGridView1.Rows[broj].Cells["id"].Value.ToString();
                }
            }
            
        }
    }
}
