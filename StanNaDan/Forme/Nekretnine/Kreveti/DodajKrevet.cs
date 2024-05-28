using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Nekretnine.Kreveti
{
    public partial class DodajKrevet : Form
    {
        int IdNekretnine;
        KrevetBasic krevetBasic;
        public DodajKrevet()
        {
            InitializeComponent();
            this.krevetBasic = new KrevetBasic();
        }
        public DodajKrevet(int idNekretnine)
        {
            InitializeComponent();
            this.krevetBasic = new KrevetBasic();
            this.IdNekretnine = idNekretnine;
        }
        private void btnDodajKrevet_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da dodate novi krevet?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                this.krevetBasic.IdKreveta = Int32.Parse(tbIdKreveta.Text);
                this.krevetBasic.Dimenzije = tbDimenzije.Text;
                this.krevetBasic.Tip = tbTip.Text;

                DTOManager.DodajKrevet(this.IdNekretnine, this.krevetBasic);
                MessageBox.Show($"Uspesno ste dodali novi krevet nekretnini sa ID: {this.IdNekretnine}!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od dodavanja novog kreveta!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
