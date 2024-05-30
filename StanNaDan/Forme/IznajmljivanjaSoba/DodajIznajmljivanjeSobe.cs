using StanNaDan.Forme.Nekretnine;
using StanNaDan.Forme.Soba;
using StanNaDan.Forme.SpoljniSaradnici;
using StanNaDan.Forme.Zaposleni;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.IznajmljivanjaSoba
{
    public partial class DodajIznajmljivanjeSobe : Form
    {
        string mbrAgenta;
        int IdSpoljnog;
        int IdNekretnine;
        List<int> IdSoba;
        NajamBasic najamBasic;
        IznajmljenaSobaBasic izsBasic;
        public DodajIznajmljivanjeSobe()
        {
            InitializeComponent();
            this.najamBasic = new NajamBasic();
            this.izsBasic = new IznajmljenaSobaBasic();
            this.btnIzaberiSpoljnog.Enabled = false;
            this.IdSpoljnog = 0;
            this.IdSoba = [];
            this.IdNekretnine = 0;
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

        private void btnIzaberiNekretninu_Click(object sender, EventArgs e)
        {
            using (var formIzaberiSobu = new PregledSvihSoba("biranje"))
            {
                var result = formIzaberiSobu.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.IdNekretnine = formIzaberiSobu.izabranaNekretninaID;
                    this.IdSoba = formIzaberiSobu.izabraneSobeID;
                    this.lblIzabranaSoba.Text = "Izabrali ste sobe iz nekretnine: " + this.IdNekretnine.ToString() + " sa ID: " + string.Join(", ", this.IdSoba);
                }
            }
        }

        private void btnDodajNajam_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da dodate novo iznajmljivanje sobe?";
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

                this.izsBasic.Najam = this.najamBasic;

                DTOManager.DodajIznajmljenuSobu(this.izsBasic, this.IdNekretnine, this.IdSoba, this.mbrAgenta, this.IdSpoljnog);
                MessageBox.Show($"Uspesno ste dodali novo iznajmljivanje sobe!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od dodavanja novog iznajmljivanja sobe!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
