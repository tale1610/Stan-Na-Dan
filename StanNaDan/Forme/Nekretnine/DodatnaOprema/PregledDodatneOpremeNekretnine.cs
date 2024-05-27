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

namespace StanNaDan.Forme.Nekretnine.DodatnaOprema
{
    public partial class PregledDodatneOpremeNekretnine : Form
    {
        int IdNekretnine;
        public PregledDodatneOpremeNekretnine()
        {
            InitializeComponent();
        }
        public PregledDodatneOpremeNekretnine(int idNekretnine)
        {
            InitializeComponent();
            this.IdNekretnine = idNekretnine;
        }
        public void popuniPodacima()
        {
            listaDodatnihOprema.Items.Clear();
            List<DodatnaOpremaPregled> podaci = DTOManager.VratiSvuDodatnuOpremuNekretnine(this.IdNekretnine);

            foreach (DodatnaOpremaPregled dop in podaci)
            {
                ListViewItem item;
                if (dop.BesplatnoKoriscenje)
                {
                    item = new ListViewItem(new string[] { dop.IdOpreme.ToString(), dop.IdNekretnine.ToString(), dop.TipOpreme, "Besplatno koriscenje" });
                }
                else
                {
                    item = new ListViewItem(new string[] { dop.IdOpreme.ToString(), dop.IdNekretnine.ToString(), dop.TipOpreme, dop.CenaKoriscenja.ToString() });
                }
                listaDodatnihOprema.Items.Add(item);
            }
            listaDodatnihOprema.Refresh();
        }
        private void PregledDodatneOpremeNekretnine_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnObrisiOpremu_Click(object sender, EventArgs e)
        {
            if (listaDodatnihOprema.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite opremu koju zelite da obrisete!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaDodatnihOprema.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete obrisati samo jednu opremu jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idOpreme = Int32.Parse(listaDodatnihOprema.SelectedItems[0].SubItems[0].Text);
            DTOManager.ObrisiDodatnuOpremu(idOpreme, this.IdNekretnine);
            this.popuniPodacima();
        }

        private void btnDodajNovuOpremu_Click(object sender, EventArgs e)
        {
            DodajDodatnuOpremu formaDodajDodatnuOpremu = new DodajDodatnuOpremu(this.IdNekretnine);
            formaDodajDodatnuOpremu.ShowDialog();
            this.popuniPodacima();
        }

        private void btnIzmeniOpremu_Click(object sender, EventArgs e)
        {
            if (listaDodatnihOprema.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite dodatnu opremu koju zelite da izmenite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaDodatnihOprema.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete odabrati samo jednu dodatnu opremu za menjanje jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DodatnaOpremaBasic dob = new()
            {
                BesplatnoKoriscenje = listaDodatnihOprema.SelectedItems[0].SubItems[3].Text == "Besplatno koriscenje" ? true : false,
                CenaKoriscenja = listaDodatnihOprema.SelectedItems[0].SubItems[3].Text == "Besplatno koriscenje" ? null : Double.Parse(listaDodatnihOprema.SelectedItems[0].SubItems[3].Text),
                IdOpreme = Int32.Parse(listaDodatnihOprema.SelectedItems[0].SubItems[0].Text),
                TipOpreme = listaDodatnihOprema.SelectedItems[0].SubItems[2].Text
            };

            IzmeniDodatnuOpremu formaIzmeniDodatnuOpremu = new IzmeniDodatnuOpremu(this.IdNekretnine, dob);
            formaIzmeniDodatnuOpremu.ShowDialog();
            this.popuniPodacima();
        }
    }
}
