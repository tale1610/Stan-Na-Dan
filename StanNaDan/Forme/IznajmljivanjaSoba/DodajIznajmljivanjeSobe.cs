using StanNaDan.Forme.SpoljniSaradnici;
using StanNaDan.Forme.Zaposleni;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.IznajmljivanjaSoba
{
    public partial class DodajIznajmljivanjeSobe : Form
    {
        string mbrAgenta;
        int IdSpoljnog;
        public DodajIznajmljivanjeSobe()
        {
            InitializeComponent();
        }

        private void btnIzaberiAgenta_Click(object sender, EventArgs e)
        {
            using (var formIzaberiAgenta = new PregledZaposlenih("biranje"))
            {
                var result = formIzaberiAgenta.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.mbrAgenta = formIzaberiAgenta.izabraniAgentMBR;
                    this.lblIzabraniAgentMBR.Text = "Izabrali ste agenta sa MBR: " + this.mbrAgenta;
                }
            }
            btnIzaberiSpoljnog.Enabled = true;
        }

        private void btnIzaberiSpoljnog_Click(object sender, EventArgs e)
        {
            using (var formIzaberiSpoljnog = new PregledSpoljnihSaradnikaAgenta(this.mbrAgenta, "biranje"))
            {
                var result = formIzaberiSpoljnog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.IdSpoljnog = formIzaberiSpoljnog.izabraniSpoljniID;
                    this.lblIzabraniSpoljniID.Text = "Izabrali ste agentovog spoljnog saradnika sa ID: " + this.IdSpoljnog;
                }
            }
        }
    }
}
