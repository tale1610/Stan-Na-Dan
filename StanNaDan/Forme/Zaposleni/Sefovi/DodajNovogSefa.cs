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
    public partial class DodajNovogSefa : Form
    {
        SefBasic seftBasic;
        int idPoslovnice;
        public DodajNovogSefa()
        {
            InitializeComponent();
        }
        public DodajNovogSefa(int idPoslovnice)
        {
            InitializeComponent();
            this.idPoslovnice = idPoslovnice;
            this.seftBasic = new SefBasic();
        }

        private void btnDodajNovogSefa_Click(object sender, EventArgs e)
        {
            string poruka = "Da li ste sigurni da zelite da zaposlite novog sefa?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                this.seftBasic.MBR = tbMBR.Text;
                this.seftBasic.Ime = tbIme.Text;
                this.seftBasic.Prezime = tbPrezime.Text;
                this.seftBasic.DatumPostavljanja = dateTimePicker2.Value;
                this.seftBasic.DatumZaposlenja = dateTimePicker1.Value;

                DTOManager.dodajNovogSefa(idPoslovnice, this.seftBasic);
                //MessageBox.Show($"Uspesno ste zaposlili novog sefa!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od dodavanja novog sefa!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
