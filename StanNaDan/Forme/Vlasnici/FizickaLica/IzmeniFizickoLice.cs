using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Vlasnici.FizickaLica
{
    public partial class IzmeniFizickoLice : Form
    {
        public FizickoLiceBasic fizickoLiceBasic;
        public IzmeniFizickoLice()
        {
            InitializeComponent();
        }

        public IzmeniFizickoLice(FizickoLiceBasic flb)
        {
            InitializeComponent();
            this.fizickoLiceBasic = flb;
        }

        public void popuniPodacima()
        {
            tbBanka.Text = this.fizickoLiceBasic.Vlasnik.Banka;
            tbBrojBankovnogRacuna.Text = this.fizickoLiceBasic.Vlasnik.BrojBankovnogRacuna;
            tbIme.Text = this.fizickoLiceBasic.Ime;
            tbImeRoditelja.Text = this.fizickoLiceBasic.ImeRoditelja;
            tbPrezime.Text = this.fizickoLiceBasic.Prezime;
            tbDrzava.Text = this.fizickoLiceBasic.Drzava;
            tbMestoStanovanja.Text = this.fizickoLiceBasic.MestoStanovanja;
            tbAdresaStanovanja.Text = this.fizickoLiceBasic.AdresaStanovanja;
            dateTimePicker1.Value = this.fizickoLiceBasic.DatumRodjenja;
            tbEmail.Text = this.fizickoLiceBasic.Email;
        }

        private void IzmeniFizickoLice_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnIzmeniFizickoLice_Click(object sender, EventArgs e)
        {
            string poruka = "Da li ste sigurni da zelite da izvrsite izmene fizickog lica?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                this.fizickoLiceBasic.Vlasnik.Banka = tbBanka.Text;
                this.fizickoLiceBasic.Vlasnik.BrojBankovnogRacuna = tbBrojBankovnogRacuna.Text;
                this.fizickoLiceBasic.Ime = tbIme.Text;
                this.fizickoLiceBasic.ImeRoditelja = tbImeRoditelja.Text;
                this.fizickoLiceBasic.Prezime = tbPrezime.Text;
                this.fizickoLiceBasic.Drzava = tbDrzava.Text;
                this.fizickoLiceBasic.MestoStanovanja = tbMestoStanovanja.Text;
                this.fizickoLiceBasic.AdresaStanovanja = tbAdresaStanovanja.Text;
                this.fizickoLiceBasic.DatumRodjenja = dateTimePicker1.Value;
                this.fizickoLiceBasic.Email = tbEmail.Text;

                DTOManager.IzmeniFizickoLice(this.fizickoLiceBasic);
                MessageBox.Show("Azuriranje fizickog lica je uspesno izvrseno!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od azuriranja fizickog lica!");
                this.Close();
            }
        }
    }
}
