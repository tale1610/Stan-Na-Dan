using StanNaDan.Forme.Najam;
using StanNaDan.Forme.Nekretnine.DodatnaOprema;
using StanNaDan.Forme.Nekretnine.Kreveti;
using StanNaDan.Forme.Nekretnine.Sajtovi;
using StanNaDan.Forme.Parking;
using StanNaDan.Forme.Soba;
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
        public int izabaranaNekretninaID;
        public PregledSvihNekretnina()
        {
            InitializeComponent();
            this.btnIzaberiNekretninu.Visible = false;
        }
        public PregledSvihNekretnina(string biranje)
        {
            InitializeComponent();
            this.btnDodajNekretninu.Visible = false;
            this.btnObrisiNekretninu.Visible = false;
            this.btnIzmeniNekretninu.Visible = false;
            this.btnPrikaziDodatnuOpremu.Visible = false;
            this.btnPrikaziKrevete.Visible = false;
            this.btnPrikaziSajtove.Visible = false;
            this.btnPrikaziSveNajmove.Visible = false;
            this.btnPrikaziSveSobe.Visible = false;
            this.btnPrikaziParkinge.Visible = false;
            this.btnIzaberiNekretninu.Visible = true;
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

        private void btnDodajNekretninu_Click(object sender, EventArgs e)
        {
            DodajNekretninu formaDodaj = new DodajNekretninu();//DODAJ IZBOR VLASNIKA AKO OSTAJE OVO DUGME DA FUNKCIONISE
            formaDodaj.ShowDialog();
            this.popuniPodacima();
        }

        private void btnPrikaziSveNajmove_Click(object sender, EventArgs e)
        {
            if (listaNekretnina.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite nekretninu cije najmove zelite da vidite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaNekretnina.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete odabrati samo jednu nekretninu za prikaz jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int idNekretnine = Int32.Parse(listaNekretnina.SelectedItems[0].SubItems[0].Text);
            PregledSvihNajmovaNekretnine formaPregledSvihNajmovaNekretnine = new PregledSvihNajmovaNekretnine(idNekretnine);
            formaPregledSvihNajmovaNekretnine.ShowDialog();
            this.popuniPodacima();
        }

        private void btnPrikaziSajtove_Click(object sender, EventArgs e)
        {
            if (listaNekretnina.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite nekretninu cije sajtove zelite da vidite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaNekretnina.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete odabrati samo jednu nekretninu za prikaz jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int idNekretnine = Int32.Parse(listaNekretnina.SelectedItems[0].SubItems[0].Text);
            PregledOglasavanjaNekretnine formaPregledOglasavanjaNekretnine = new PregledOglasavanjaNekretnine(idNekretnine);
            formaPregledOglasavanjaNekretnine.ShowDialog();
            this.popuniPodacima();
        }

        private void btnPrikaziParkinge_Click(object sender, EventArgs e)
        {
            if (listaNekretnina.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite nekretninu cija parking mesta zelite da vidite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaNekretnina.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete odabrati samo jednu nekretninu za prikaz jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int idNekretnine = Int32.Parse(listaNekretnina.SelectedItems[0].SubItems[0].Text);
            PregledSvihParkinga formaPregledSvihParkinga = new PregledSvihParkinga(idNekretnine);
            formaPregledSvihParkinga.ShowDialog();
            this.popuniPodacima();
        }

        private void btnPrikaziKrevete_Click(object sender, EventArgs e)
        {
            if (listaNekretnina.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite nekretninu cije krevete zelite da vidite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaNekretnina.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete odabrati samo jednu nekretninu za prikaz jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int idNekretnine = Int32.Parse(listaNekretnina.SelectedItems[0].SubItems[0].Text);
            PregledSvihKreveta formaPregledSvihKreveta = new PregledSvihKreveta(idNekretnine);
            formaPregledSvihKreveta.ShowDialog();
            this.popuniPodacima();
        }

        private void btnObrisiNekretninu_Click(object sender, EventArgs e)
        {
            if (listaNekretnina.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite nekretninu koju zelite da obrisete!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaNekretnina.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete obrisati samo jednu nekretninu jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idNekretnine = Int32.Parse(listaNekretnina.SelectedItems[0].SubItems[0].Text);
            DTOManager.ObrisiNekretninu(idNekretnine);
            this.popuniPodacima();
        }

        private void btnIzaberiNekretninu_Click(object sender, EventArgs e)
        {
            if (listaNekretnina.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite nekretninu koju zelite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaNekretnina.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete izabrati samo jednu nekretninu jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idNekretnine = Int32.Parse(listaNekretnina.SelectedItems[0].SubItems[0].Text);
            this.izabaranaNekretninaID = idNekretnine;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnPrikaziSveSobe_Click(object sender, EventArgs e)
        {
            if (listaNekretnina.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite nekretninu cije sobe zelite da vidite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaNekretnina.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete odabrati samo jednu nekretninu za prikaz jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int idNekretnine = Int32.Parse(listaNekretnina.SelectedItems[0].SubItems[0].Text);
            PregledSobaNekretnine formaPregledSvihSobaNekretnine = new PregledSobaNekretnine(idNekretnine);
            formaPregledSvihSobaNekretnine.ShowDialog();
            this.popuniPodacima();
        }
    }
}
