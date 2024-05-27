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
    public partial class IzmeniPoslovnicu : Form
    {
        public PoslovnicaBasic poslovnicaBasic;
        public IzmeniPoslovnicu()
        {
            InitializeComponent();
        }

        public IzmeniPoslovnicu(PoslovnicaBasic pb)
        {
            InitializeComponent();
            this.poslovnicaBasic = pb;
        }

        private void IzmeniPoslovnicu_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            groupBox1.Text = $"Azurirajte podatke o poslovnici {poslovnicaBasic.Adresa}";
        }

        public void popuniPodacima()
        {
            tbAdresa.Text = this.poslovnicaBasic.Adresa;
            tbRadnoVreme.Text = this.poslovnicaBasic.RadnoVreme;
        }

        private void btnDodajPoslovnicu_Click(object sender, EventArgs e)
        {
            string poruka = "Da li ste sigurni da zelite da izvrsite izmene poslovnice?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                this.poslovnicaBasic.Adresa = tbAdresa.Text;
                this.poslovnicaBasic.RadnoVreme = tbRadnoVreme.Text;

                DTOManager.azurirajPoslovnicu(this.poslovnicaBasic);
                MessageBox.Show("Azuriranje prodavnice je uspesno izvrseno!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od azuriranja poslovnice!");
                this.Close();
            }
        }
    }
}
