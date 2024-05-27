using StanNaDan.Forme.Vlasnici.FizickaLica;
using StanNaDan.Forme.Vlasnici.PravnaLica;
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
    public partial class PregledSvihVlasnika : Form
    {
        public PregledSvihVlasnika()
        {
            InitializeComponent();
        }

        public void popuniPodacima()
        {
            listaFizickihLica.Items.Clear();
            listaPravnihLica.Items.Clear();
            List<FizickoLicePregled> podaciFL = DTOManager.vratiSvaFizickaLica();
            List<PravnoLicePregled> podaciPL = DTOManager.vratiSvaPravnaLica();

            foreach (FizickoLicePregled fl in podaciFL)
            {
                ListViewItem item;
                item = new ListViewItem(new string[] { fl.JMBG, fl.Ime, fl.Prezime, fl.MestoStanovanja, fl.Email });
                listaFizickihLica.Items.Add(item);
            }
            listaFizickihLica.Refresh();
            foreach (PravnoLicePregled pl in podaciPL)
            {
                ListViewItem item;
                item = new ListViewItem(new string[] { pl.PIB, pl.Naziv, pl.AdresaSedista, pl.ImeKontaktOsobe, pl.EmailKontaktOsobe });
                listaPravnihLica.Items.Add(item);
            }
            listaPravnihLica.Refresh();
        }

        private void PregledSvihVlasnika_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnDodajFizickoLice_Click(object sender, EventArgs e)
        {
            DodajFizickoLice formaDodajFizickoLice = new DodajFizickoLice();
            formaDodajFizickoLice.ShowDialog();
            this.popuniPodacima();
        }

        private void btnDodajPravnoLice_Click(object sender, EventArgs e)
        {
            DodajPravnoLice formaDodajPravnoLice = new DodajPravnoLice();
            formaDodajPravnoLice.ShowDialog();
            this.popuniPodacima();
        }
    }
}
