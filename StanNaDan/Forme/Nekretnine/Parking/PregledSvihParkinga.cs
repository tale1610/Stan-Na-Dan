using StanNaDan.Forme.Nekretnine.DodatnaOprema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Parking
{
    public partial class PregledSvihParkinga : Form
    {
        int IdNekretnine;
        public PregledSvihParkinga()
        {
            InitializeComponent();
        }
        public PregledSvihParkinga(int idNekretnine)
        {
            InitializeComponent();
            this.IdNekretnine = idNekretnine;
        }
        public void popuniPodacima()
        {
            listaParkinga.Items.Clear();
            List<ParkingPregled> podaci = DTOManager.VratiSveParkingeNekretnine(this.IdNekretnine);

            foreach (ParkingPregled p in podaci)
            {
                ListViewItem item;
                item = new ListViewItem(new string[] { p.IdParkinga.ToString(), p.Besplatan ? "Besplatan" : "Placa se", p.Besplatan ? "Besplatan" : p.Cena.ToString(), p.USastavuNekretnine ? "Da" : "Ne", p.USastavuJavnogParkinga ? "Da" : "Ne" });
                listaParkinga.Items.Add(item);
            }
            listaParkinga.Refresh();
        }
        private void PregledSvihParkinga_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnDodajParking_Click(object sender, EventArgs e)
        {
            DodajParking formaDodajParking = new DodajParking(this.IdNekretnine);
            formaDodajParking.ShowDialog();
            this.popuniPodacima();
        }

        private void btnObrisiParking_Click(object sender, EventArgs e)
        {
            if (listaParkinga.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite parking koji zelite da obrisete!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaParkinga.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete obrisati samo jedan parking jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idParkinga = Int32.Parse(listaParkinga.SelectedItems[0].SubItems[0].Text);
            DTOManager.ObrisiParking(idParkinga, this.IdNekretnine);
            this.popuniPodacima();
        }
    }
}
