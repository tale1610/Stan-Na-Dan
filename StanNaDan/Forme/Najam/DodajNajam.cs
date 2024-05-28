using StanNaDan.Forme.Nekretnine;
using StanNaDan.Forme.SpoljniSaradnici;
using StanNaDan.Forme.Zaposleni;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Najam
{
    public partial class DodajNajam : Form
    {
        int IdNekretnine;
        string mbrAgenta;
        int IdSpoljnog;
        NajamBasic najamBasic;
        public DodajNajam()
        {
            InitializeComponent();
            this.najamBasic = new NajamBasic();
            this.btnIzaberiSpoljnog.Enabled = false;
            this.IdSpoljnog = 0;
        }

        private void btnDodajNajam_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da dodate novi najam?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                this.najamBasic.DatumPocetka = dtpPocetak.Value;
                this.najamBasic.DatumZavrsetka = dtpZavrsetak.Value;
                this.najamBasic.CenaPoDanu = Double.Parse(tbCenaPoDanu.Text);
                this.najamBasic.Popust = Int32.Parse(tbPopust.Text);
                this.najamBasic.ProvizijaAgencije = Int32.Parse(tbProvizijaAgencije.Text);
                this.najamBasic.BrojDana = (this.najamBasic.DatumPocetka - this.najamBasic.DatumZavrsetka).Days;

                DTOManager.DodajNajam(this.najamBasic, this.IdNekretnine, this.mbrAgenta, this.IdSpoljnog);
                MessageBox.Show($"Uspesno ste dodali novi najam!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od dodavanja novog najma!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnIzaberiNekretninu_Click(object sender, EventArgs e)
        {
            using (var formIzaberiNekretninu = new PregledSvihNekretnina("biranje"))
            {
                var result = formIzaberiNekretninu.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.IdNekretnine = formIzaberiNekretninu.izabaranaNekretninaID;
                    this.lblIzabranaNekretninaID.Text = "Izabrali ste nekretninu sa ID: " + this.IdNekretnine.ToString();
                }
            }
        }

        private void DodajNajam_Load(object sender, EventArgs e)
        {
            this.btnIzaberiSpoljnog.Enabled = false;
        }

        private void btnIzaberiAgenta_Click(object sender, EventArgs e)
        {
            using (var formIzaberiAgenta = new PregledZaposlenih("biranje"))
            {
                var result = formIzaberiAgenta.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.mbrAgenta = formIzaberiAgenta.izabraniAgentMBR;
                    this.lblIzabraniAgentMBR.Text = "Izabrali ste agenta sa MBR: " + this.mbrAgenta;
                }
            }
            btnIzaberiSpoljnog.Enabled = true;
        }

        private void btnIzaberiSpoljnog_Click(object sender, EventArgs e)
        {
            using (var formIzaberiSpoljnog = new PregledSpoljnihSaradnikaAgenta(this.mbrAgenta, "biranje"))
            {
                var result = formIzaberiSpoljnog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.IdSpoljnog = formIzaberiSpoljnog.izabraniSpoljniID;
                    this.lblIzabraniSpoljniID.Text = "Izabrali ste agentovog spoljnog saradnika sa ID: " + this.IdSpoljnog;
                }
            }
        }
    }
}
