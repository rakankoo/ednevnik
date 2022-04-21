using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ednevnik
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        

        private void osobeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Osoba osobe = new Osoba();
            osobe.Show();
            
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            label1.Text = Program.user_ime + " " + Program.user_prezime;
        }

        private void smeroviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnik sif = new Sifarnik("smer");
            sif.Show();
        }

        private void skolskeGodineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnik sif = new Sifarnik("skolska_godina");
            sif.Show();
        }

        private void predmetiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnik sif = new Sifarnik("predmet");
            sif.Show();
        }

        private void osobeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sifarnik sif = new Sifarnik("osoba");
            sif.Show();
        }

        private void raspodelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Raspodela ras = new Raspodela();
            ras.Show();
        }
    }
}
