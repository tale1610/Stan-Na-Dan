using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Vlasnici.FizickaLica.BrojeviTelefona
{
    public partial class DodajBrojTelefona : Form
    {
        string JMBG;
        BrojeviTelefonaBasic brojeviTelefonaBasic;
        public DodajBrojTelefona()
        {
            InitializeComponent();
        }

        public DodajBrojTelefona(string jmbg)
        {
            InitializeComponent();
            this.JMBG = jmbg;
            this.brojeviTelefonaBasic = new BrojeviTelefonaBasic();
        }

        private void btnDodajBrojTelefona_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da dodate nov broj telefona?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                this.brojeviTelefonaBasic.BrojTelefona = tbBrojTelefona.Text;

                DTOManager.DodajBrojTelefona(this.brojeviTelefonaBasic, this.JMBG);
                MessageBox.Show($"Uspesno ste dodali nov broj telefona: {this.brojeviTelefonaBasic.BrojTelefona}!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od dodavanja novog broja telefona!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
