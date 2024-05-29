using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Soba
{
    public partial class DodajSobu : Form
    {
        int IdNekretnine;
        SobaBasic sobaBasic;
        public DodajSobu()
        {
            InitializeComponent();
            this.sobaBasic = new SobaBasic();
        }
        public DodajSobu(int idNekretnine)
        {
            InitializeComponent();
            this.IdNekretnine = idNekretnine;
            this.sobaBasic = new SobaBasic();
        }

        private void btnDodajSobu_Click(object sender, EventArgs e)
        {
            string poruka = "Da li ste sigurni da zelite da dodate novu sobu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                this.sobaBasic.IdSobe = Int32.Parse(tbIdSobe.Text);
                DTOManager.DodajSobu(this.sobaBasic, this.IdNekretnine);
                MessageBox.Show($"Uspesno ste dodali novu dodatnu opremu nekretnini sa ID: {this.IdNekretnine}!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od dodavanja nove sobe!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
