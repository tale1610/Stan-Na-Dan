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

namespace StanNaDan.Forme.Vlasnici
{
    public partial class PregledSvihNekretninaVlasnika : Form
    {
        int idVlasnika;
        public PregledSvihNekretninaVlasnika()
        {
            InitializeComponent();
        }
        public PregledSvihNekretninaVlasnika(int idVlasnika)
        {
            InitializeComponent();
            this.idVlasnika = idVlasnika;
        }
        public void popuniPodacima()
        {
            listaNekretnina.Items.Clear();
            List<NekretninaPregled> podaci = DTOManager.VratiSveNekretnineVlasnika(this.idVlasnika);

            foreach (NekretninaPregled n in podaci)
            {
                ListViewItem item;
                item = new ListViewItem(new string[] { n.IdNekretnine.ToString(), "nemoguce", n.Ulica + " " + n.Broj, n.Kvadratura.ToString(), n.BrojSpavacihSoba.ToString(), n.BrojKupatila.ToString(), n.BrojTerasa.ToString() });
                listaNekretnina.Items.Add(item);
            }
            listaNekretnina.Refresh();
        }
        private void PrikaziSveNekretnineVlasnika_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnDodajNekretninu_Click(object sender, EventArgs e)
        {
            DodajNekretninu formaDodaj = new DodajNekretninu(this.idVlasnika);
            formaDodaj.ShowDialog();
            popuniPodacima();
        }
    }
}
