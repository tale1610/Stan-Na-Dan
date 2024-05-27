using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.SpoljniSaradnici
{
    public partial class DodajNovogSpoljnogSaradnika : Form
    {
        SpoljniSaradnikBasic SpoljniSaradnikBasic;
        string MbrAgenta;
        public DodajNovogSpoljnogSaradnika()
        {
            InitializeComponent();
            this.SpoljniSaradnikBasic = new SpoljniSaradnikBasic();
        }
        public DodajNovogSpoljnogSaradnika(string mbrAgenta)
        {
            InitializeComponent();
            this.SpoljniSaradnikBasic = new SpoljniSaradnikBasic();
            this.MbrAgenta = mbrAgenta;
        }

        private void btnDodajNovogSpoljnogSaradnika_Click(object sender, EventArgs e)
        {
            string poruka = "Da li ste sigurni da zelite da angazujete novog spoljnog saradnika?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                this.SpoljniSaradnikBasic.IdSaradnika = Int32.Parse(tbID.Text);
                this.SpoljniSaradnikBasic.Ime = tbIme.Text;
                this.SpoljniSaradnikBasic.Prezime = tbPrezime.Text;
                this.SpoljniSaradnikBasic.ProcenatOdNajma = Double.Parse(tbProcenat.Text);
                this.SpoljniSaradnikBasic.DatumAngazovanja = dateTimePicker1.Value;
                this.SpoljniSaradnikBasic.Telefon = tbTelefon.Text;

                DTOManager.dodajNovogSpoljnogSaradnika(this.SpoljniSaradnikBasic, this.MbrAgenta);
                MessageBox.Show($"Uspesno ste angazovali novog spoljnog saradnika!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od dodavanja nove poslovnice!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
