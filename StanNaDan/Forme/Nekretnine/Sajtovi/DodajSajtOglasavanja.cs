using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Nekretnine.Sajtovi
{
    public partial class DodajSajtOglasavanja : Form
    {
        public int idNekretnine;
        public SajtoviNekretnineBasic sajtBasic;
        public DodajSajtOglasavanja(int idNekretnine)
        {
            InitializeComponent();
            this.idNekretnine = idNekretnine;
            tbIdNekretnine.Text = idNekretnine.ToString();
            sajtBasic = new SajtoviNekretnineBasic();
        }

        public DodajSajtOglasavanja()
        {
            InitializeComponent();
            sajtBasic = new SajtoviNekretnineBasic();
        }

        private void DodajSajtOglasavanja_Load(object sender, EventArgs e)
        {
        }

        private void btnDodajSajtOglasavanja_Click(object sender, EventArgs e)
        {
            string poruka = "Da li ste sigurni da zelite da dodate novi sajt?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                this.sajtBasic.Sajt = tbSajtOglasavanja.Text;

                DTOManager.DodajSajtNekretnine(this.sajtBasic, this.idNekretnine);
                MessageBox.Show($"Uspesno ste dodali novi sajt sa ID: {this.idNekretnine}!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od dodavanja novog sajta!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
