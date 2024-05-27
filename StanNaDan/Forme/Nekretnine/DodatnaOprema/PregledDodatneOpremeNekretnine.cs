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

                }
                item = new ListViewItem(new string[] { dop.IdOpreme.ToString(), dop.IdNekretnine.ToString(), dop.TipOpreme, dop.CenaKoriscenja.ToString() });
                listaDodatnihOprema.Items.Add(item);
            }
            listaDodatnihOprema.Refresh();
        }
        private void PregledDodatneOpremeNekretnine_Load(object sender, EventArgs e)
        {

        }
    }
}
