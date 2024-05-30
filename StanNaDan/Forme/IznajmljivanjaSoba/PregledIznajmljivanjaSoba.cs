using StanNaDan.Forme.Najam;
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

namespace StanNaDan.Forme.IznajmljivanjaSoba
{
    public partial class PregledIznajmljivanjaSoba : Form
    {
        public PregledIznajmljivanjaSoba()
        {
            InitializeComponent();
        }
        public void popuniPodacima()
        {
            listaNajmova.Items.Clear();
            List<IznajmljenaSobaPregled> podaci = DTOManager.VratiSveIznajmljeneSobe();

            foreach (IznajmljenaSobaPregled izs in podaci)
            {
                ListViewItem item;
                item = new ListViewItem(new string[] { izs.Najam.IdNajma.ToString(), izs.IdNekretnine.ToString(), izs.IdSobe.ToString(), izs.Najam.DatumPocetka.ToString(), izs.Najam.DatumZavrsetka.ToString(), izs.Najam.BrojDana.ToString(), izs.Najam.CenaPoDanu.ToString(), izs.Najam.CenaSaPopustom > 0 ? izs.Najam.CenaSaPopustom.ToString() : "Nema popusta", izs.Najam.ZaradaOdDodatnihUsluga.ToString(), izs.Najam.UkupnaCena.ToString(), izs.Najam.ProvizijaAgencije.ToString(), izs.Najam.ImeAgenta, izs.Najam.ImeSpoljnogSaradnika });
                listaNajmova.Items.Add(item);
            }
            listaNajmova.Refresh();
        }
        private void PregledIznajmljivanjaSoba_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnDodajNajamSobe_Click(object sender, EventArgs e)
        {
            DodajIznajmljivanjeSobe formaDodajNajamSobe = new DodajIznajmljivanjeSobe();
            formaDodajNajamSobe.ShowDialog();
            this.popuniPodacima();
        }

        private void btnObrisiNajamSobe_Click(object sender, EventArgs e)
        {
            if (listaNajmova.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite najam koji zelite da obrisete!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaNajmova.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete obrisati samo jedan najam jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idNajma = Int32.Parse(listaNajmova.SelectedItems[0].SubItems[0].Text);
            int idNekretnine = Int32.Parse(listaNajmova.SelectedItems[0].SubItems[1].Text);
            int idSobe = Int32.Parse(listaNajmova.SelectedItems[0].SubItems[2].Text);
            DTOManager.ObrisiIznajmljenuSobu(idSobe, idNekretnine, idNajma);
            this.popuniPodacima();
        }

        private void btnPrikaziZajednickeProstorije_Click(object sender, EventArgs e)
        {
            if (listaNajmova.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite najam za koji zelite da vidite zajednicke prostorije!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaNajmova.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete izabrati samo jedan najam jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idNajma = Int32.Parse(listaNajmova.SelectedItems[0].SubItems[0].Text);
            PregledZajednickihProstorijaSobe formaPregledZajednickihProstorijaNajma = new PregledZajednickihProstorijaSobe(idNajma);
            formaPregledZajednickihProstorijaNajma.ShowDialog();
            this.popuniPodacima();
        }
    }
}
