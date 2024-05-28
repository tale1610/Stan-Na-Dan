using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Najam
{
    public partial class PregledSvihNajmovaNekretnine : Form
    {
        int IdNekretnine;
        public PregledSvihNajmovaNekretnine()
        {
            InitializeComponent();
        }
        public PregledSvihNajmovaNekretnine(int idNekretnine)
        {
            InitializeComponent();
            this.IdNekretnine = idNekretnine;
        }
        public void popuniPodacima()
        {
            listaNajmova.Items.Clear();
            List<NajamPregled> podaci = DTOManager.VratiSveNajmoveNekretnine(this.IdNekretnine);

            foreach (NajamPregled n in podaci)
            {
                ListViewItem item;
                item = new ListViewItem(new string[] { n.IdNajma.ToString(), n.DatumPocetka.ToString(), n.DatumZavrsetka.ToString(), n.BrojDana.ToString(), n.CenaPoDanu.ToString(), n.CenaSaPopustom > 0 ? n.CenaSaPopustom.ToString() : "Nema popusta", n.ZaradaOdDodatnihUsluga.ToString(), n.UkupnaCena.ToString(), n.ProvizijaAgencije.ToString(), n.ImeAgenta, n.ImeSpoljnogSaradnika });
                listaNajmova.Items.Add(item);
            }
            listaNajmova.Refresh();
        }
        private void PregledSvihNajmovaNekretnine_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }
    }
}
