using StanNaDan.Forme.Nekretnine.DodatnaOprema;

namespace StanNaDan.Forme.Nekretnine.Kreveti
{
    public partial class PregledSvihKreveta : Form
    {
        int idNekretnine;
        public PregledSvihKreveta()
        {
            InitializeComponent();
        }
        public PregledSvihKreveta(int idNekretnine)
        {
            InitializeComponent();
            this.idNekretnine = idNekretnine;
        }

        public void popuniPodacima()
        {
            listaKreveta.Items.Clear();
            List<KrevetPregled> podaci = DTOManager.VratiSveKreveteNekretnine(this.idNekretnine);

            foreach (KrevetPregled k in podaci)
            {
                ListViewItem item;
                item = new ListViewItem(new string[] { k.IdKreveta.ToString(), k.Tip, k.Dimenzije }); ;
                listaKreveta.Items.Add(item);
            }
            listaKreveta.Refresh();
        }

        private void PregledSvihKreveta_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnObrisiKrevet_Click(object sender, EventArgs e)
        {
            if (listaKreveta.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite krevet koji zelite da obrisete!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaKreveta.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete obrisati samo jedan krevet jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idKreveta = Int32.Parse(listaKreveta.SelectedItems[0].SubItems[0].Text);
            DTOManager.ObrisiKrevet(idKreveta, this.idNekretnine);
            this.popuniPodacima();
        }

        private void btnDodajKrevet_Click(object sender, EventArgs e)
        {
            DodajKrevet formaDodajKrevet = new DodajKrevet(this.idNekretnine);
            formaDodajKrevet.ShowDialog();
            this.popuniPodacima();
        }
    }
}
