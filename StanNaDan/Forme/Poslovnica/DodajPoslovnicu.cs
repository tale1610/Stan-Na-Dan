using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme
{
    public partial class DodajPoslovnicu : Form
    {
        PoslovnicaBasic poslovnica;
        public DodajPoslovnicu()
        {
            InitializeComponent();
            poslovnica = new PoslovnicaBasic();
        }

        private void btnDodajPoslovnicu_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da dodate novu poslovnicu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                this.poslovnica.Adresa = tbAdresa.Text;
                this.poslovnica.RadnoVreme = tbRadnoVreme.Text;

                DTOManager.dodajPoslovnicu(this.poslovnica);
                MessageBox.Show($"Uspesno ste dodali novu poslovnicu na adresi {this.poslovnica.Adresa}!","Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od dodavanja nove poslovnice!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
