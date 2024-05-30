using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StanNaDan.Forme.Nekretnine.Sajtovi
{
    public partial class IzmeniSajtOglasavanja : Form
    {
        public SajtoviNekretnineBasic sajtBasic;
        public string stariSajt;
        public IzmeniSajtOglasavanja(SajtoviNekretnineBasic sajtBasic)
        {
            InitializeComponent();
            this.sajtBasic = sajtBasic;
            this.stariSajt = sajtBasic.Sajt;
        }

        public IzmeniSajtOglasavanja()
        {
            InitializeComponent();
        }

        private void popuniPodacima()
        {
            tbIdNekretnine.Text = sajtBasic.Nekretnina.IdNekretnine.ToString();
            tbSajtOglasavanja.Text = sajtBasic.Sajt;
        }

        private void IzmeniSajtOglasavanja_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnIzmeniSajtOglasavanja_Click(object sender, EventArgs e)
        {
            string poruka = "Da li ste sigurni da zelite da izvrsite izmene sajta?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                sajtBasic.Sajt = tbSajtOglasavanja.Text;

                DTOManager.IzmeniSajtNekretnine(this.sajtBasic, stariSajt, sajtBasic.Nekretnina.IdNekretnine);
                MessageBox.Show("Azuriranje sajta je uspesno izvrseno!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od azuriranja sajta!");
                this.Close();
            }
        }
    }
}
