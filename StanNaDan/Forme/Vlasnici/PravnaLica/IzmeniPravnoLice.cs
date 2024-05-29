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
    public partial class IzmeniPravnoLice : Form
    {
        public PravnoLiceBasic pravnoLiceBasic;
        public IzmeniPravnoLice()
        {
            InitializeComponent();
        }

        public IzmeniPravnoLice(PravnoLiceBasic plb)
        {
            InitializeComponent();
            this.pravnoLiceBasic = plb;
        }

        public void popuniPodacima()
        {
            tbBanka.Text = this.pravnoLiceBasic.Vlasnik.Banka;
            tbBrojBankovnogRacuna.Text = this.pravnoLiceBasic.Vlasnik.BrojBankovnogRacuna;
            tbNaziv.Text = this.pravnoLiceBasic.Naziv;
            tbAdresa.Text = this.pravnoLiceBasic.AdresaSedista;
            tbImeKontaktOsobe.Text = this.pravnoLiceBasic.ImeKontaktOsobe;
            tbEmailKontaktOsobe.Text = this.pravnoLiceBasic.EmailKontaktOsobe;
        }

        private void IzmeniPravnoLice_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnIzmeniPravnoLice_Click(object sender, EventArgs e)
        {
            string poruka = "Da li ste sigurni da zelite da izvrsite izmene pravnog lica?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                this.pravnoLiceBasic.Vlasnik.Banka = tbBanka.Text;
                this.pravnoLiceBasic.Vlasnik.BrojBankovnogRacuna = tbBrojBankovnogRacuna.Text;
                this.pravnoLiceBasic.Naziv = tbNaziv.Text;
                this.pravnoLiceBasic.AdresaSedista = tbAdresa.Text;
                this.pravnoLiceBasic.ImeKontaktOsobe = tbImeKontaktOsobe.Text;
                this.pravnoLiceBasic.EmailKontaktOsobe = tbEmailKontaktOsobe.Text;


                DTOManager.izmeniPravnoLice(this.pravnoLiceBasic);
                MessageBox.Show("Azuriranje pravnog lica je uspesno izvrseno!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od azuriranja pravnog lica!");
                this.Close();
            }
        }
    }
}
