using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Nekretnine.Kreveti
{
    public partial class IzmeniKrevet : Form
    {
        public KrevetBasic krevetBasic;

        public IzmeniKrevet(KrevetBasic krevetBasic)
        {
            InitializeComponent();
            this.krevetBasic = krevetBasic;
        }

        public IzmeniKrevet()
        {
            InitializeComponent();
        }

        private void popuniPodacima()
        {
            tbTip.Text = krevetBasic.Tip;
            tbDimenzije.Text = krevetBasic.Dimenzije;
        }

        private void IzmeniKrevet_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnIzmeniKrevet_Click(object sender, EventArgs e)
        {
            string poruka = "Da li ste sigurni da zelite da izvrsite izmene nekretnine?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                krevetBasic.Tip = tbTip.Text;
                krevetBasic.Dimenzije = tbDimenzije.Text;

                DTOManager.IzmeniKrevet(krevetBasic, krevetBasic.Nekretnina.IdNekretnine);
                MessageBox.Show("Azuriranje nekretnine je uspesno izvrseno!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od azuriranja nekretnine!");
                this.Close();
            }
        }
    }
}
