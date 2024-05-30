using StanNaDan.Forme.Nekretnine;
using StanNaDan.Forme.Nekretnine.DodatnaOprema;
using StanNaDan.Forme.Soba.ZajednickeProstorije;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Soba
{
    public partial class PregledSvihSoba : Form
    {
        public int izabranaSobaID;
        public int izabranaNekretninaID;
        public PregledSvihSoba()
        {
            InitializeComponent();
            this.btnIzaberiSobu.Visible = false;
        }
        public PregledSvihSoba(string biranje)
        {
            InitializeComponent();
            this.btnIzaberiSobu.Visible = true;
        }
        public void popuniPodacima()
        {
            listaSoba.Items.Clear();
            List<SobaPregled> podaci = DTOManager.VratiSveSobe();

            foreach (SobaPregled s in podaci)
            {
                ListViewItem item;
                item = new ListViewItem(new string[] { s.IdNekretnine.ToString(), s.IdSobe.ToString() });
                listaSoba.Items.Add(item);
            }
            listaSoba.Refresh();
        }
        private void PregledSvihSoba_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnZajednickeProstorije_Click(object sender, EventArgs e)
        {
            if (listaSoba.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite sobu cije zajednicke prostorije zelite da vidite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaSoba.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete odabrati samo jednu sobu za prikaz jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idNekretnine = Int32.Parse(listaSoba.SelectedItems[0].SubItems[0].Text);
            int idSobe = Int32.Parse(listaSoba.SelectedItems[0].SubItems[1].Text);

            PregledZajednickihProstorijaSobe formaPregledZajednickihProstorijaSobe = new PregledZajednickihProstorijaSobe(idSobe, idNekretnine);
            formaPregledZajednickihProstorijaSobe.ShowDialog();
            this.popuniPodacima();

        }

        private void btnUpravljanje_Click(object sender, EventArgs e)
        {
            PregledSvihNekretnina formaPregledSvihNekretnina = new PregledSvihNekretnina();
            formaPregledSvihNekretnina.ShowDialog();
            this.popuniPodacima();
        }

        private void btnIzaberiSobu_Click(object sender, EventArgs e)
        {
            if (listaSoba.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite sobu koju zelite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaSoba.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete izabrati samo jednu sobu jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idNekretnine = Int32.Parse(listaSoba.SelectedItems[0].SubItems[0].Text);
            int idSobe = Int32.Parse(listaSoba.SelectedItems[0].SubItems[1].Text);
            this.izabranaNekretninaID = idNekretnine;
            this.izabranaSobaID = idSobe;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
