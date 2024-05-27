using StanNaDan.Forme.Nekretnine.DodatnaOprema;
using StanNaDan.Forme.Zaposleni;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Nekretnine
{
    public partial class PregledSvihNekretnina : Form
    {
        public PregledSvihNekretnina()
        {
            InitializeComponent();
        }

        public void popuniPodacima()
        {
            listaNekretnina.Items.Clear();
            List<NekretninaPregled> podaci = DTOManager.VratiSveNekretnine();

            foreach (NekretninaPregled n in podaci)
            {
                ListViewItem item;
                item = new ListViewItem(new string[] { n.IdNekretnine.ToString(), "nemoguce", n.Ulica + " " + n.Broj, n.Kvadratura.ToString(), n.BrojSpavacihSoba.ToString(), n.BrojKupatila.ToString(), n.BrojTerasa.ToString() });
                listaNekretnina.Items.Add(item);
            }
            listaNekretnina.Refresh();
        }

        private void PregledSvihNekretnina_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnPrikaziDodatnuOpremu_Click(object sender, EventArgs e)
        {
            if (listaNekretnina.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite nekretninu ciju dodatnu opremu zelite da vidite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaNekretnina.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete odabrati samo jednu nekretninu za prikaz jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idNekretnine = Int32.Parse(listaNekretnina.SelectedItems[0].SubItems[0].Text);
            PregledDodatneOpremeNekretnine formaPregledDodatneOpremeNekretnine = new PregledDodatneOpremeNekretnine(idNekretnine);
            formaPregledDodatneOpremeNekretnine.ShowDialog();
            this.popuniPodacima();
        }
    }
}
