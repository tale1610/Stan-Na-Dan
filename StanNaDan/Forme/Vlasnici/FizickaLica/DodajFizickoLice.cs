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
    public partial class DodajFizickoLice : Form
    {
        FizickoLiceBasic flBasic;
        public DodajFizickoLice()
        {
            InitializeComponent();
            this.flBasic = new FizickoLiceBasic();
        }

        private void btnDodajFizickoLice_Click(object sender, EventArgs e)
        {
            string poruka = "Da li ste sigurni da zelite da dodate novo fizicko lice?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                VlasnikBasic vlasnikBasic = new()
                {
                    Banka = tbBanka.Text,
                    BrojBankovnogRacuna = tbBrojBankovnogRacuna.Text
                };
                this.flBasic.JMBG = tbJMBG.Text;
                this.flBasic.Ime = tbIme.Text;
                this.flBasic.ImeRoditelja = tbImeRoditelja.Text;
                this.flBasic.Prezime = tbPrezime.Text;
                this.flBasic.DatumRodjenja = dateTimePicker1.Value;
                this.flBasic.AdresaStanovanja = tbAdresaStanovanja.Text;
                this.flBasic.MestoStanovanja = tbMestoStanovanja.Text;
                this.flBasic.Drzava = tbDrzava.Text;
                this.flBasic.Email = tbEmail.Text;
                this.flBasic.Vlasnik = vlasnikBasic;

                DTOManager.dodajNovoFizickoLice(this.flBasic);
                MessageBox.Show($"Uspesno ste dodali novo fizicko lice!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od dodavanja novog fizickog lica!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
