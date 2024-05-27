using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Vlasnici.PravnaLica
{
    public partial class DodajPravnoLice : Form
    {
        PravnoLiceBasic plBasic;
        public DodajPravnoLice()
        {
            InitializeComponent();
            this.plBasic = new PravnoLiceBasic();
        }

        private void btnDodajPravnoLice_Click(object sender, EventArgs e)
        {
            string poruka = "Da li ste sigurni da zelite da dodate novo pravno lice?";
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
                this.plBasic.PIB = tbPIB.Text;
                this.plBasic.AdresaSedista = tbAdresa.Text;
                this.plBasic.ImeKontaktOsobe = tbImeKontaktOsobe.Text;
                this.plBasic.EmailKontaktOsobe = tbEmailKontaktOsobe.Text;
                this.plBasic.Naziv = tbNaziv.Text;
                this.plBasic.Vlasnik = vlasnikBasic;

                DTOManager.dodajNovoPravnoLice(this.plBasic);
                MessageBox.Show($"Uspesno ste dodali novo pravno lice!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od dodavanja novog pravnog lica!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
