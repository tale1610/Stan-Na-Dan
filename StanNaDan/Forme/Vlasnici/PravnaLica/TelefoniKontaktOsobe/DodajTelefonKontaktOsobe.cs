using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Vlasnici.PravnaLica.TelefoniKontaktOsobe
{
    public partial class DodajTelefonKontaktOsobe : Form
    {
        string Pib;
        TelefoniKontaktOsobeBasic telefonBasic;
        public DodajTelefonKontaktOsobe()
        {
            InitializeComponent();
        }

        public DodajTelefonKontaktOsobe(string pib)
        {
            InitializeComponent();
            this.Pib = pib;
            this.telefonBasic = new TelefoniKontaktOsobeBasic();
        }

        private void btnDodajTelefonKontaktOsobe_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da dodate nov broj telefona?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                this.telefonBasic.BrojTelefona = tbTelefonKontaktOsobe.Text;

                DTOManager.DodajTelefonKontaktOsobe(this.telefonBasic, this.Pib);
                MessageBox.Show($"Uspesno ste dodali nov broj telefona: {this.telefonBasic.BrojTelefona}!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
