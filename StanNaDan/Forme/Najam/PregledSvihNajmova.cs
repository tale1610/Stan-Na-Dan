using StanNaDan.Forme.Zaposleni.Agenti;
using StanNaDan.Forme.Zaposleni.Sefovi;

namespace StanNaDan.Forme.Najam
{
    public partial class PregledSvihNajmova : Form
    {
        public PregledSvihNajmova()
        {
            InitializeComponent();
        }
        public void popuniPodacima()
        {
            listaNajmova.Items.Clear();
            List<NajamPregled> podaci = DTOManager.VratiSveNajmove();

            foreach (NajamPregled n in podaci)
            {
                ListViewItem item;
                item = new ListViewItem(new string[] { n.IdNajma.ToString(), n.DatumPocetka.ToString(), n.DatumZavrsetka.ToString(), n.BrojDana.ToString(), n.CenaPoDanu.ToString(), n.CenaSaPopustom > 0 ? n.CenaSaPopustom.ToString() : "Nema popusta", n.ZaradaOdDodatnihUsluga.ToString(), n.UkupnaCena.ToString(), n.ProvizijaAgencije.ToString(), n.ImeAgenta, n.ImeSpoljnogSaradnika });
                listaNajmova.Items.Add(item);
            }
            listaNajmova.Refresh();
        }
        private void PregledSvihNajmova_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnDodajNoviNajam_Click(object sender, EventArgs e)
        {
            DodajNajam formaDodajNajam = new DodajNajam();
            formaDodajNajam.ShowDialog();
            this.popuniPodacima();
        }

        private void btnObrisiNajam_Click(object sender, EventArgs e)
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
            DTOManager.ObrisiNajam(idNajma);
            this.popuniPodacima();
        }

        private void btnIzmeniNajam_Click(object sender, EventArgs e)
        {
            if (listaNajmova.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite najam koji zelite da izmenite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaNajmova.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete izmeniti samo jedan najam jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Int32.Parse(listaNajmova.SelectedItems[0].SubItems[0].Text);
            NajamBasic najamBasic = DTOManager.VratiNajam(id);
            IzmeniNajam formaIzmeni = new IzmeniNajam(najamBasic);
            formaIzmeni.ShowDialog();

            this.popuniPodacima();
        }
    }
}
