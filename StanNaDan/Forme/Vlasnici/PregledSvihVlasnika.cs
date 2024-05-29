using StanNaDan.Forme.Vlasnici.FizickaLica;
using StanNaDan.Forme.Vlasnici.FizickaLica.BrojeviTelefona;
using StanNaDan.Forme.Vlasnici.PravnaLica;
using StanNaDan.Forme.Vlasnici.PravnaLica.TelefoniKontaktOsobe;
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

namespace StanNaDan.Forme.Vlasnici
{
    public partial class PregledSvihVlasnika : Form
    {
        public int izabraniIdVlasnika;
        public PregledSvihVlasnika()
        {
            InitializeComponent();
            btnIzaberiFizickoLice.Visible = false;
            btnIzaberiPravnoLice.Visible = false;
        }

        public PregledSvihVlasnika(string biranje)
        {
            InitializeComponent();
            btnIzaberiFizickoLice.Visible = true;
            btnIzaberiPravnoLice.Visible = true;
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
                item = new ListViewItem(new string[] { fl.JMBG, fl.Ime, fl.Prezime, fl.MestoStanovanja, fl.Email, fl.Vlasnik.IdVlasnika.ToString() });
                listaFizickihLica.Items.Add(item);
            }
            listaFizickihLica.Refresh();
            foreach (PravnoLicePregled pl in podaciPL)
            {
                ListViewItem item;
                item = new ListViewItem(new string[] { pl.PIB, pl.Naziv, pl.AdresaSedista, pl.ImeKontaktOsobe, pl.EmailKontaktOsobe, pl.Vlasnik.IdVlasnika.ToString() });
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

        private void btnObrisiFizickoLice_Click(object sender, EventArgs e)
        {
            if (listaFizickihLica.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite fizicko lice koje zelite da obrisete!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaFizickihLica.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete obrisati samo jedno fizicko lice jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string JMBG = listaFizickihLica.SelectedItems[0].SubItems[0].Text;
            DTOManager.obrisiVlasnika(JMBG);
            this.popuniPodacima();
        }

        private void btnObrisiPravnoLice_Click(object sender, EventArgs e)
        {
            if (listaFizickihLica.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite pravno lice koje zelite da obrisete!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaFizickihLica.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete obrisati samo jedno pravno lice jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string pib = listaPravnihLica.SelectedItems[0].SubItems[0].Text;
            DTOManager.obrisiVlasnika(pib);
            this.popuniPodacima();
        }

        private void btnPrikaziNekretnineFizickogLica_Click(object sender, EventArgs e)
        {
            if (listaFizickihLica.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite fizicko lice cije nekretnine zelite da vidite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaFizickihLica.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete odabrati samo jedno fizicko lice za prikaz jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idVlasnika = Int32.Parse(listaFizickihLica.SelectedItems[0].SubItems[5].Text);
            PregledSvihNekretninaVlasnika formaPregledSvihNekretninaVlasnika = new PregledSvihNekretninaVlasnika(idVlasnika);
            formaPregledSvihNekretninaVlasnika.ShowDialog();
            this.popuniPodacima();
        }

        private void btnPrikaziNekretninePravnogLica_Click(object sender, EventArgs e)
        {
            if (listaPravnihLica.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite pravno lice cije nekretnine zelite da vidite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaFizickihLica.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete odabrati samo jedno pravno lice za prikaz jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idVlasnika = Int32.Parse(listaPravnihLica.SelectedItems[0].SubItems[5].Text);
            PregledSvihNekretninaVlasnika formaPregledSvihNekretninaVlasnika = new PregledSvihNekretninaVlasnika(idVlasnika);
            formaPregledSvihNekretninaVlasnika.ShowDialog();
            this.popuniPodacima();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnPrikaziBrojeveTelefona_Click(object sender, EventArgs e)
        {
            if (listaFizickihLica.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite fizicko lice cije nekretnine zelite da vidite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaFizickihLica.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete odabrati samo jedno fizicko lice za prikaz jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string jmbg = listaFizickihLica.SelectedItems[0].SubItems[0].Text;
            PregledSvihBrojevaTelefona formaPregledSvihBrojevaTelefona = new PregledSvihBrojevaTelefona(jmbg);
            formaPregledSvihBrojevaTelefona.ShowDialog();
            this.popuniPodacima();
        }

        private void btnPrikaziTelefoneKontaktOsoba_Click(object sender, EventArgs e)
        {
            if (listaPravnihLica.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite pravno lice cije nekretnine zelite da vidite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaFizickihLica.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete odabrati samo jedno pravno lice za prikaz jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string pib = listaPravnihLica.SelectedItems[0].SubItems[0].Text;
            PregledSvihTelefonaKontaktOsoba formaPregledSvihTelefonaKontaktOsoba = new PregledSvihTelefonaKontaktOsoba(pib);
            formaPregledSvihTelefonaKontaktOsoba.ShowDialog();
            this.popuniPodacima();
        }

        private void btnIzmeniFizickoLice_Click(object sender, EventArgs e)
        {
            if (listaFizickihLica.SelectedItems.Count == 0)
            {
                MessageBox.Show("Morate da izaberete fizicko lice cije podatke zelite da izmenite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (listaFizickihLica.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete izmeniti podatke samo o jednom fizickom licu jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string jmbg = listaFizickihLica.SelectedItems[0].SubItems[0].Text;
            FizickoLiceBasic fizickoLiceBasic = DTOManager.VratiFizickoLice(jmbg);

            IzmeniFizickoLice formaIzmeni = new IzmeniFizickoLice(fizickoLiceBasic);
            formaIzmeni.ShowDialog();

            this.popuniPodacima();
        }

        private void btnIzmeniPravnoLice_Click(object sender, EventArgs e)
        {
            if (listaPravnihLica.SelectedItems.Count == 0)
            {
                MessageBox.Show("Morate da izaberete pravno lice cije podatke zelite da izmenite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (listaPravnihLica.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete izmeniti podatke samo o jednom pravnom licu jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string pib = listaPravnihLica.SelectedItems[0].SubItems[0].Text;
            PravnoLiceBasic pravnoLiceBasic = DTOManager.vratiPravnoLice(pib);

            IzmeniPravnoLice formaIzmeni = new IzmeniPravnoLice(pravnoLiceBasic);
            formaIzmeni.ShowDialog();

            this.popuniPodacima();
        }

        private void btnIzaberiFizickoLice_Click(object sender, EventArgs e)
        {
            if (listaFizickihLica.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite vlasnika koga zelite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaFizickihLica.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete izabrati samo jednog vlasnika jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idVlasnika = Int32.Parse(listaFizickihLica.SelectedItems[0].SubItems[5].Text);
            this.izabraniIdVlasnika = idVlasnika;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnIzaberiPravnoLice_Click(object sender, EventArgs e)
        {
            if (listaPravnihLica.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite vlasnika koga zelite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaPravnihLica.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete izabrati samo jednog vlasnika jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idVlasnika = Int32.Parse(listaPravnihLica.SelectedItems[0].SubItems[5].Text);
            this.izabraniIdVlasnika = idVlasnika;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
