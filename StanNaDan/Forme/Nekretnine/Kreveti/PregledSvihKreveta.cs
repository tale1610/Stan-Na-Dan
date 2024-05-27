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
    }
}
