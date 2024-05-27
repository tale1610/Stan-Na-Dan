using StanNaDan.Forme.SpoljniSaradnici;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Zaposleni
{
    public partial class PregledZaposlenih : Form
    {
        public PregledZaposlenih()
        {
            InitializeComponent();
        }
        public void popuniPodacima()
        {
            listaZaposlenih.Items.Clear();
            List<ZaposleniPregled> podaci = DTOManager.vratiSveZaposlene();

            foreach (ZaposleniPregled z in podaci)
            {
                ListViewItem item;
                item = new ListViewItem(new string[] { z.MBR, z.Ime, z.Prezime, z.DatumZaposlenja.ToString(), z.AdresaPoslovnice, z.Pozicija });
                listaZaposlenih.Items.Add(item);
            }
            listaZaposlenih.Refresh();
        }
        private void PregledZaposlenih_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnDodajZaposlenog_Click(object sender, EventArgs e)
        {
            //TODO: Ostavi za kraj jer vec imas dodavanje radnika iz PregledPoslovnica i radi kako treba, ovde kad se klikne na dugme 
            //prikazi samo formu sa svim poslovnicama, izaberi poslovnicu na formi, pa se vrati ovde i kreiraj radnika
        }

        private void btnObrisiRadnika_Click(object sender, EventArgs e)
        {
            if (listaZaposlenih.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite zaposlenog kojeg zelite da obrisete!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaZaposlenih.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete obrisati samo jednog zaposlenog jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string _mbr = listaZaposlenih.SelectedItems[0].SubItems[0].Text;
            DTOManager.obrisiZaposlenog(_mbr);
            this.popuniPodacima();
        }

        private void btnIzmeniRadnika_Click(object sender, EventArgs e)
        {

        }

        private void btnPrikaziSveSpoljneSaradnikeAgenta_Click(object sender, EventArgs e)
        {
            if (listaZaposlenih.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite zaposlenog cije spoljne saradnike zelite da vidite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaZaposlenih.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete odabrati samo jednog zaposlenog za prikaz jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaZaposlenih.SelectedItems[0].SubItems[5].Text == "Sef")
            {
                MessageBox.Show("Izabrani zaposleni mora biti agent!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string mbrAgenta = listaZaposlenih.SelectedItems[0].SubItems[0].Text;
            PregledSpoljnihSaradnikaAgenta formaPregledSpoljnihSaradnikaAgenta = new PregledSpoljnihSaradnikaAgenta(mbrAgenta);
            formaPregledSpoljnihSaradnikaAgenta.ShowDialog();
            this.popuniPodacima();
        }
    }
}
