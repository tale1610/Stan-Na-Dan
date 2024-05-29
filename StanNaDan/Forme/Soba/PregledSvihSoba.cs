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
        public PregledSvihSoba()
        {
            InitializeComponent();
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

        }
    }
}
