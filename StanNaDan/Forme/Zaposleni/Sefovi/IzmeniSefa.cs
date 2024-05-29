using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Zaposleni.Sefovi
{
    public partial class IzmeniSefa : Form
    {
        public SefBasic sefBasic;
        public IzmeniSefa()
        {
            InitializeComponent();
        }
        public IzmeniSefa(SefBasic sb)
        {
            InitializeComponent();
            this.sefBasic = sb;
        }

        private void popuniPodacima()
        {
            tbMBR.Text = sefBasic.MBR;
            tbIme.Text = sefBasic.Ime;
            tbPrezime.Text = sefBasic.Prezime;
            dateTimePicker1.Value = sefBasic.DatumZaposlenja;
            dateTimePicker2.Value = sefBasic.DatumPostavljanja ?? DateTime.MinValue;
        }

        private void IzmeniSefa_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnIzmeniSefa_Click(object sender, EventArgs e)
        {
            string poruka = "Da li ste sigurni da zelite da izvrsite izmene sefa?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                sefBasic.MBR = tbMBR.Text;
                sefBasic.Ime = tbIme.Text;
                sefBasic.Prezime = tbPrezime.Text;
                sefBasic.DatumZaposlenja = dateTimePicker1.Value;
                sefBasic.DatumPostavljanja = dateTimePicker2.Value != DateTime.MinValue ? (DateTime?)dateTimePicker2.Value : null;

                DTOManager.IzmeniSefa(this.sefBasic);
                MessageBox.Show("Azuriranje sefa je uspesno izvrseno!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od azuriranja sefa!");
                this.Close();
            }
        }
    }
}
