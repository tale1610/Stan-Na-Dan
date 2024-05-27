using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Nekretnine.Sajtovi
{
    public partial class PregledOglasavanjaNekretnine : Form
    {
        int IdNekretnine;
        public PregledOglasavanjaNekretnine()
        {
            InitializeComponent();
        }
        public PregledOglasavanjaNekretnine(int idNekretnine)
        {
            InitializeComponent();
            this.IdNekretnine = idNekretnine;
        }

        public void popuniPodacima()
        {
            listaSajtova.Items.Clear();
            List<SajtoviNekretninePregled> podaci = DTOManager.VratiSveSajtoveNekretnine(this.IdNekretnine);

            foreach (SajtoviNekretninePregled s in podaci)
            {
                ListViewItem item;
                item = new ListViewItem(new string[] { s.IdNekretnine.ToString(), s.AdresaNekretnine, s.Sajt });
                listaSajtova.Items.Add(item);
            }
            listaSajtova.Refresh();
        }

        private void PregledOglasavanjaNekretnine_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }
    }
}
