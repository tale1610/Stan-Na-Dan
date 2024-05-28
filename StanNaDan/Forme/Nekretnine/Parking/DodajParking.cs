using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Parking
{
    public partial class DodajParking : Form
    {
        int IdNekretnine;
        ParkingBasic parkingBasic;
        public DodajParking()
        {
            InitializeComponent();
        }
        public DodajParking(int idNekretnine)
        {
            InitializeComponent();
            this.IdNekretnine = idNekretnine;
            this.parkingBasic = new ParkingBasic();
        }

        private void btnDodajParking_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da dodate novo parking mesto?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                this.parkingBasic.IdParkinga = Int32.Parse(tbIdParkinga.Text);
                this.parkingBasic.Besplatan = chBBesplatan.Checked;
                if (chBBesplatan.Checked == false)
                {
                    this.parkingBasic.Cena = Double.Parse(tbCena.Text);
                }
                this.parkingBasic.USastavuJavnogParkinga = chBUSastavuJavnogParkinga.Checked;
                this.parkingBasic.USastavuNekretnine = chBUSastavuNekrenine.Checked;

                DTOManager.DodajParking(this.parkingBasic, this.IdNekretnine);
                MessageBox.Show($"Uspesno ste dodali novo parking mesto nekretnini sa ID: {this.IdNekretnine}!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od dodavanja novog parking mesta!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
