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

        }
    }
}
