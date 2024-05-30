using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Nekretnine.Parking
{
    public partial class IzmeniParking : Form
    {
        public ParkingBasic parkingBasic;

        public IzmeniParking()
        {
            InitializeComponent();
        }

        public IzmeniParking(ParkingBasic parkingBasic)
        {
            InitializeComponent();
            this.parkingBasic = parkingBasic;
        }

        private void popuniPodacima()
        {
            chBBesplatan.Checked = parkingBasic.Besplatan;
            textBox1.Text = parkingBasic.Cena.ToString();
            chBUSastavuNekrenine.Checked = parkingBasic.USastavuNekretnine;
            chBUSastavuJavnogParkinga.Checked = parkingBasic.USastavuJavnogParkinga;
        }

        private void IzmeniParking_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnIzmeniParking_Click(object sender, EventArgs e)
        {
            string poruka = "Da li ste sigurni da zelite da izvrsite izmene parkinga?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                parkingBasic.Besplatan = chBBesplatan.Checked;
                parkingBasic.Cena = textBox1.Text == "" ? null : Double.Parse(textBox1.Text);
                parkingBasic.USastavuNekretnine = chBUSastavuNekrenine.Checked;
                parkingBasic.USastavuJavnogParkinga = chBUSastavuJavnogParkinga.Checked;

                DTOManager.IzmeniParking(this.parkingBasic, parkingBasic.Nekretnina.IdNekretnine);
                MessageBox.Show("Azuriranje parkinga je uspesno izvrseno!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od azuriranja parkinga!");
                this.Close();
            }
        }

        private void chBBesplatan_CheckedChanged(object sender, EventArgs e)
        {
            if (chBBesplatan.Checked == true)
            {
                textBox1.Enabled = false;
            }
            else
            {
                textBox1.Enabled = true;
            }
        }
    }
}
