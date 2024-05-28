using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Nekretnine
{
    public partial class DodajNekretninu : Form
    {
        KucaBasic kucaBasic;
        StanBasic stanBasic;
        int IdVlasnika;
        public DodajNekretninu()
        {
            InitializeComponent();
            cbTip.DropDownStyle = ComboBoxStyle.DropDownList;
            this.kucaBasic = new KucaBasic();
            this.stanBasic = new StanBasic();

            cbTip.Items.Add("Kuca");
            cbTip.Items.Add("Stan");
            cbTip.SelectedItem = cbTip.Items[0];
            cbTip.SelectedIndexChanged += new EventHandler(cbTip_SelectedIndexChanged);

        }
        public DodajNekretninu(int idVlasnika)
        {
            InitializeComponent();
            cbTip.DropDownStyle = ComboBoxStyle.DropDownList;
            this.IdVlasnika = idVlasnika;
            this.kucaBasic = new KucaBasic();
            this.stanBasic = new StanBasic();

            cbTip.Items.Add("Kuca");
            cbTip.Items.Add("Stan");
            cbTip.SelectedItem = cbTip.Items[0];
            chbPosedujeLift.Enabled = false;
            tbSprat.Enabled = false;
            cbTip.SelectedIndexChanged += new EventHandler(cbTip_SelectedIndexChanged);

        }
        private void cbTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTip.SelectedItem.ToString() == "Kuca")
            {
                chbPosedujeDvoriste.Enabled = true;
                tbSpratnostKuce.Enabled = true;
                chbPosedujeLift.Enabled = false;
                tbSprat.Enabled = false;
            }
            if (cbTip.SelectedItem.ToString() == "Stan")
            {
                chbPosedujeDvoriste.Enabled = false;
                tbSpratnostKuce.Enabled = false;
                chbPosedujeLift.Enabled = true;
                tbSprat.Enabled = true;
            }

        }

        private void btnDodajNekretninu_Click(object sender, EventArgs e)
        {
            if (cbTip.SelectedItem == null)
            {
                MessageBox.Show($"Morate da izaberete tip nekretnine!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string poruka = "Da li ste sigurni da zelite da dodate novu nekretninu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                
                int idKvarta = GetSelectedKvartId();
                if (cbTip.SelectedItem.ToString() == "Kuca")
                {
                    kucaBasic.Ulica = tbUlica.Text;
                    kucaBasic.Broj = tbBroj.Text;
                    kucaBasic.Kvadratura = Int32.Parse(tbKvadratura.Text);
                    kucaBasic.BrojKupatila = Int32.Parse(tbBrojKupatila.Text);
                    kucaBasic.BrojSpavacihSoba = Int32.Parse(tbBrojSpavacihSoba.Text);
                    kucaBasic.BrojTerasa = Int32.Parse(tbBrojTerasa.Text);
                    kucaBasic.Spratnost = Int32.Parse(tbSpratnostKuce.Text);
                    kucaBasic.PosedujeDvoriste = chbPosedujeDvoriste.Checked;
                    kucaBasic.PosedujeKuhinju = chbPosedujeKuhinju.Checked;
                    kucaBasic.PosedujeTV = chbPosedujeTVPrikljucak.Checked;
                    kucaBasic.PosedujeInternet = chbPosedujeInternet.Checked;
                    DTOManager.DodajNekretninu(idKvarta, this.IdVlasnika, kucaBasic, null);
                    MessageBox.Show($"Uspesno ste dodali novu kucu!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();
                }
                else if(cbTip.SelectedItem.ToString() == "Stan")
                {
                    stanBasic.Ulica = tbUlica.Text;
                    stanBasic.Broj = tbBroj.Text;
                    stanBasic.Kvadratura = Int32.Parse(tbKvadratura.Text);
                    stanBasic.BrojKupatila = Int32.Parse(tbBrojKupatila.Text);
                    stanBasic.BrojSpavacihSoba = Int32.Parse(tbBrojSpavacihSoba.Text);
                    stanBasic.BrojTerasa = Int32.Parse(tbBrojTerasa.Text);
                    stanBasic.Sprat = Int32.Parse(tbSprat.Text);
                    stanBasic.PosedujeLift = chbPosedujeLift.Checked;
                    stanBasic.PosedujeKuhinju = chbPosedujeKuhinju.Checked;
                    stanBasic.PosedujeTV = chbPosedujeTVPrikljucak.Checked;
                    stanBasic.PosedujeInternet = chbPosedujeInternet.Checked;
                    DTOManager.DodajNekretninu(idKvarta, this.IdVlasnika, null, stanBasic);
                    MessageBox.Show($"Uspesno ste dodali novi stan!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();
                }

            }
            else
            {
                MessageBox.Show("Odustali ste od dodavanja nove nekretnine!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }

        public void popuniPodacima()
        {
            cbKvartovi.Items.Clear();
            List<KvartPregled> podaci = DTOManager.vratiSveKvartove();
            foreach (KvartPregled k in podaci)
            {
                KvartComboBoxItem item = new KvartComboBoxItem(k.IdKvarta, k.GradskaZona);
                cbKvartovi.Items.Add(item);
            }
            cbKvartovi.Refresh();
        }
        public int GetSelectedKvartId()
        {
            if (cbKvartovi.SelectedItem is KvartComboBoxItem selectedKvart)
            {
                return selectedKvart.IdKvarta;
            }
            throw new InvalidOperationException("Nijedan kvart nije izabran.");
        }

        private void DodajNekretninu_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }
    }
}

public class KvartComboBoxItem
{
    public int IdKvarta { get; set; }
    public string GradskaZona { get; set; }

    public KvartComboBoxItem(int idKvarta, string gradskaZona)
    {
        IdKvarta = idKvarta;
        GradskaZona = gradskaZona;
    }
    public override string ToString()
    {
        return GradskaZona;
    }
}