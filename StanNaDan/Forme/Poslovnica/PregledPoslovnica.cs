using StanNaDan.Forme.Kvartovi;
using StanNaDan.Forme.Zaposleni;
using StanNaDan.Forme.Zaposleni.Agenti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme
{
    public partial class PregledPoslovnica : Form
    {
        public PregledPoslovnica()
        {
            InitializeComponent();
        }
        public void popuniPodacima()
        {
            listaPoslovnica.Items.Clear();
            List<PoslovnicaPregled> podaci = DTOManager.vratiSvePoslovnice();

            foreach (PoslovnicaPregled p in podaci)
            {
                ListViewItem item;
                if (p.ImeSefa == null)
                {
                    item = new ListViewItem(new string[] { p.ID.ToString(), p.Adresa, p.RadnoVreme, "Nema sefa" });
                }
                else
                {
                    item = new ListViewItem(new string[] { p.ID.ToString(), p.Adresa, p.RadnoVreme, p.ImeSefa });
                }
                listaPoslovnica.Items.Add(item);
            }
            listaPoslovnica.Refresh();
        }
        private void PregledPoslovnica_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnDodajPoslovnicu_Click(object sender, EventArgs e)
        {
            DodajPoslovnicu formaDodaj = new DodajPoslovnicu();
            formaDodaj.ShowDialog();
            this.popuniPodacima();
        }

        private void btnIzmeniPoslovnicu_Click(object sender, EventArgs e)
        {
            if (listaPoslovnica.SelectedItems.Count == 0)
            {
                MessageBox.Show("Morate da izaberete poslovnicu cije podatke zelite da izmenite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (listaPoslovnica.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete izmeniti podatke samo o jednoj poslovnici jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idPoslovnice = Int32.Parse(listaPoslovnica.SelectedItems[0].SubItems[0].Text);
            PoslovnicaBasic poslovnicaBasic = DTOManager.vratiPoslovnicu(idPoslovnice);

            IzmeniPoslovnicu formaIzmeni = new IzmeniPoslovnicu(poslovnicaBasic);
            formaIzmeni.ShowDialog();

            this.popuniPodacima();
        }

        private void btnDodajNovogAgenta_Click(object sender, EventArgs e)
        {
            if (listaPoslovnica.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite poslovnicu u kojoj zelite da zaposlite novog agenta!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaPoslovnica.SelectedItems.Count > 1)
            {
                MessageBox.Show("Novog agenta mozeta zaposliti samo u jednoj poslovnici!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idPoslovnice = Int32.Parse(listaPoslovnica.SelectedItems[0].SubItems[0].Text);
            DodajNovogAgenta formaDodajNovogAgenta = new DodajNovogAgenta(idPoslovnice);
            formaDodajNovogAgenta.ShowDialog();

            this.popuniPodacima();
        }

        private void btnObrisiPoslovnicu_Click(object sender, EventArgs e)
        {
            if (listaPoslovnica.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite poslovnicu koju zelite da obrisete!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaPoslovnica.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete obrisati samo jednu poslovnicu jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idPoslovnice = Int32.Parse(listaPoslovnica.SelectedItems[0].SubItems[0].Text);
            DTOManager.obrisiPoslovnicu(idPoslovnice);
            this.popuniPodacima();
        }

        
        private void btnPrikaziSveZaposlenePoslovnice_Click(object sender, EventArgs e)
        {
            //TODO: Da pozove formu koja ce da prikaze sve zaposlene samo u toj prodavnici, i da ima opcije da se odatle otpusti radnik,
            //da se promotuje u sefa, da se sef demotuje u agenta i ako se setis jos nesto
            if (listaPoslovnica.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite poslovnicu cije zaposlene zelite da vidite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaPoslovnica.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete odabrati samo jednu poslovnicu za prikaz jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idPoslovnice = Int32.Parse(listaPoslovnica.SelectedItems[0].SubItems[0].Text);
            PregledZaposlenihPoslovnice formaPregledZaposlenihPoslovnice = new PregledZaposlenihPoslovnice(idPoslovnice);
            formaPregledZaposlenihPoslovnice.ShowDialog();
            this.popuniPodacima();
        }

        private void btnPrikaziSveKvartove_Click(object sender, EventArgs e)
        {
            if (listaPoslovnica.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite poslovnicu cije kvartove zelite da vidite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaPoslovnica.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete odabrati samo jednu poslovnicu za prikaz jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idPoslovnice = Int32.Parse(listaPoslovnica.SelectedItems[0].SubItems[0].Text);
            PregledKvartovaPoslovnice formaPregledKvartovaPoslovnice = new PregledKvartovaPoslovnice(idPoslovnice);
            formaPregledKvartovaPoslovnice.ShowDialog();
            this.popuniPodacima();
        }
    }
}
