using StanNaDan.Forme.Nekretnine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Vlasnici.FizickaLica.BrojeviTelefona
{
    public partial class PregledSvihBrojevaTelefona : Form
    {
        string JMBG;
        public PregledSvihBrojevaTelefona()
        {
            InitializeComponent();
        }

        public PregledSvihBrojevaTelefona(string jmbg)
        {
            InitializeComponent();
            this.JMBG = jmbg;
        }

        public void popuniPodacima()
        {
            listaBrojevaTelefona.Items.Clear();
            List<BrojeviTelefonaPregled> podaci = DTOManager.VratiSveBrojeveTelefona(this.JMBG);

            foreach (BrojeviTelefonaPregled n in podaci)
            {
                ListViewItem item;
                item = new ListViewItem(n.BrojTelefona.ToString());
                listaBrojevaTelefona.Items.Add(item);
            }
            listaBrojevaTelefona.Refresh();
        }
        private void PregledSvihBrojevaTelefona_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnDodajBrojTelefona_Click(object sender, EventArgs e)
        {
            DodajBrojTelefona formaDodaj = new DodajBrojTelefona(this.JMBG);
            formaDodaj.ShowDialog();
            popuniPodacima();
        }

        private void btnObrisiBrojTelefona_Click(object sender, EventArgs e)
        {
            if (listaBrojevaTelefona.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite broj telefona koji zelite da obrisete!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaBrojevaTelefona.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete obrisati samo jedan broj telefona jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string brojTelefona = listaBrojevaTelefona.SelectedItems[0].SubItems[0].Text;
            DTOManager.ObrisiBrojTelefona(brojTelefona, this.JMBG);
            this.popuniPodacima();
        }
    }
}
