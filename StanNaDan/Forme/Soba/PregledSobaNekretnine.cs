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
    public partial class PregledSobaNekretnine : Form
    {
        int idNekretnine;
        public PregledSobaNekretnine()
        {
            InitializeComponent();
        }
        public PregledSobaNekretnine(int idNekretnine)
        {
            InitializeComponent();
            this.idNekretnine = idNekretnine;
        }
        public void popuniPodacima()
        {
            listaSoba.Items.Clear();
            List<SobaPregled> podaci = DTOManager.VratiSveSobeNekretnine(this.idNekretnine);

            foreach (SobaPregled s in podaci)
            {
                ListViewItem item;
                item = new ListViewItem(new string[] { s.IdNekretnine.ToString(), s.IdSobe.ToString() });
                listaSoba.Items.Add(item);
            }
            listaSoba.Refresh();
        }

        private void PregledSobaNekretnine_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void tbDodajSobu_Click(object sender, EventArgs e)
        {
            DodajSobu formaDodajSobu = new DodajSobu(idNekretnine);
            formaDodajSobu.ShowDialog();
            this.popuniPodacima();
        }

        private void btnObrisiSobu_Click(object sender, EventArgs e)
        {
            if (listaSoba.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite sobu koju zelite da obrisete!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaSoba.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete obrisati samo jednu sobu jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idSobe = Int32.Parse(listaSoba.SelectedItems[0].SubItems[1].Text);
            DTOManager.ObrisiSobu(idSobe, this.idNekretnine);
            this.popuniPodacima();
        }
    }
}
