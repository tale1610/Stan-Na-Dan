using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Kvartovi
{
    public partial class DodajKvartPoslovnici : Form
    {
        int IdPoslovnice;
        KvartBasic KvartBasic;
        public DodajKvartPoslovnici()
        {
            InitializeComponent();
            this.KvartBasic = new KvartBasic();
        }
        public DodajKvartPoslovnici(int idPoslovnice)
        {
            InitializeComponent();
            this.IdPoslovnice = idPoslovnice;
            this.KvartBasic = new KvartBasic();
        }

        private void btnDodajKvart_Click(object sender, EventArgs e)
        {
            string poruka = "Da li ste sigurni da zelite da dodate novi kvart?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                this.KvartBasic.GradskaZona = tbGradskaZona.Text;

                DTOManager.dodajNoviKvart(this.IdPoslovnice, this.KvartBasic);
                MessageBox.Show($"Uspesno ste dodali novi kvart!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od dodavanja novog kvarta!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
