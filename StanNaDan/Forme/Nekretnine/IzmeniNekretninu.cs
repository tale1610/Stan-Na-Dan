using StanNaDan.Forme.Vlasnici;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Nekretnine
{
    public partial class IzmeniNekretninu : Form
    {
        public int idVlasnika = -1;
        public StanBasic stanBasic;
        public KucaBasic kucaBasic;

        public IzmeniNekretninu()
        {
            InitializeComponent();
        }
        public IzmeniNekretninu(NekretninaBasic nb)
        {
            InitializeComponent();
            if (nb.Tip == "Stan")
                this.stanBasic = (StanBasic)nb;
            else
                this.kucaBasic = (KucaBasic)nb;
        }

        public void popuniPodacima()
        {
            if (stanBasic != null)
            {
                label13.Visible = false;
                tbSpratnostKuce.Visible = false;
                label14.Visible = false;
                chbPosedujeDvoriste.Visible = false;
                tbKvadratura.Text = this.stanBasic.Kvadratura.ToString();
                tbUlica.Text = this.stanBasic.Ulica;
                tbBroj.Text = this.stanBasic.Broj;
                tbSprat.Text = this.stanBasic.Sprat.ToString();
                tbBrojKupatila.Text = this.stanBasic.BrojKupatila.ToString();
                tbBrojSpavacihSoba.Text = this.stanBasic.BrojSpavacihSoba.ToString();
                tbBrojTerasa.Text = this.stanBasic.BrojTerasa.ToString();
                chbPosedujeTVPrikljucak.Checked = this.stanBasic.PosedujeTV;
                chbPosedujeKuhinju.Checked = this.stanBasic.PosedujeKuhinju;
                chbPosedujeInternet.Checked = this.stanBasic.PosedujeInternet;
                chbPosedujeLift.Checked = this.stanBasic.PosedujeLift;
            }
            else
            {
                label11.Visible = false;
                tbSprat.Visible = false;
                label12.Visible = false;
                chbPosedujeLift.Visible = false;
                tbKvadratura.Text = this.kucaBasic.Kvadratura.ToString();
                tbUlica.Text = this.kucaBasic.Ulica;
                tbBroj.Text = this.kucaBasic.Broj;
                tbSpratnostKuce.Text = this.kucaBasic.Spratnost.ToString();
                tbBrojKupatila.Text = this.kucaBasic.BrojKupatila.ToString();
                tbBrojSpavacihSoba.Text = this.kucaBasic.BrojSpavacihSoba.ToString();
                tbBrojTerasa.Text = this.kucaBasic.BrojTerasa.ToString();
                chbPosedujeTVPrikljucak.Checked = this.kucaBasic.PosedujeTV;
                chbPosedujeKuhinju.Checked = this.kucaBasic.PosedujeKuhinju;
                chbPosedujeInternet.Checked = this.kucaBasic.PosedujeInternet;
                chbPosedujeDvoriste.Checked = this.kucaBasic.PosedujeDvoriste;
            }
        }

        private void IzmeniNekretninu_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnIzmeniNekretninu_Click(object sender, EventArgs e)
        {
            string poruka = "Da li ste sigurni da zelite da izvrsite izmene nekretnine?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                if (stanBasic != null)
                {
                    stanBasic.Kvadratura = double.Parse(tbKvadratura.Text);
                    stanBasic.Ulica = tbUlica.Text;
                    stanBasic.Broj = tbBroj.Text;
                    stanBasic.Sprat = int.Parse(tbSprat.Text);
                    stanBasic.BrojKupatila = int.Parse(tbBrojKupatila.Text);
                    stanBasic.BrojSpavacihSoba = int.Parse(tbBrojSpavacihSoba.Text);
                    stanBasic.BrojTerasa = int.Parse(tbBrojTerasa.Text);
                    stanBasic.PosedujeTV = chbPosedujeTVPrikljucak.Checked;
                    stanBasic.PosedujeKuhinju = chbPosedujeKuhinju.Checked;
                    stanBasic.PosedujeInternet = chbPosedujeInternet.Checked;
                    stanBasic.PosedujeLift = chbPosedujeLift.Checked;
                    DTOManager.IzmeniStan(this.stanBasic, idVlasnika > -1 ? idVlasnika : stanBasic.Vlasnik.IdVlasnika);
                }
                else if (kucaBasic != null)
                {
                    kucaBasic.Kvadratura = double.Parse(tbKvadratura.Text);
                    kucaBasic.Ulica = tbUlica.Text;
                    kucaBasic.Broj = tbBroj.Text;
                    kucaBasic.Spratnost = int.Parse(tbSpratnostKuce.Text);
                    kucaBasic.BrojKupatila = int.Parse(tbBrojKupatila.Text);
                    kucaBasic.BrojSpavacihSoba = int.Parse(tbBrojSpavacihSoba.Text);
                    kucaBasic.BrojTerasa = int.Parse(tbBrojTerasa.Text);
                    kucaBasic.PosedujeTV = chbPosedujeTVPrikljucak.Checked;
                    kucaBasic.PosedujeKuhinju = chbPosedujeKuhinju.Checked;
                    kucaBasic.PosedujeInternet = chbPosedujeInternet.Checked;
                    kucaBasic.PosedujeDvoriste = chbPosedujeDvoriste.Checked;
                    DTOManager.IzmeniKucu(this.kucaBasic, idVlasnika > -1 ? idVlasnika : kucaBasic.Vlasnik.IdVlasnika);
                }

                MessageBox.Show("Azuriranje nekretnine je uspesno izvrseno!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od azuriranja nekretnine!");
                this.Close();
            }
        }

        private void btnPromeniVlasnika_Click(object sender, EventArgs e)
        {
            using (var formIzaberiVlasnika = new PregledSvihVlasnika("biranje"))
            {
                var result = formIzaberiVlasnika.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.idVlasnika = formIzaberiVlasnika.izabraniIdVlasnika;
                    this.lblIzabraniVlasnikID.Text = "Izabrali ste vlasnika sa ID: " + this.idVlasnika.ToString();
                }
            }
        }
    }
}
