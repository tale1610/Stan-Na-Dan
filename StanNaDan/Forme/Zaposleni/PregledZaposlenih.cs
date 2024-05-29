using StanNaDan.Forme.SpoljniSaradnici;
using StanNaDan.Forme.Vlasnici.FizickaLica;
using StanNaDan.Forme.Zaposleni.Agenti;
using StanNaDan.Forme.Zaposleni.Sefovi;
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
        public string izabraniAgentMBR;
        public PregledZaposlenih()
        {
            InitializeComponent();
            btnIzaberiAgenta.Visible = false;
        }
        public PregledZaposlenih(string izbor)
        {
            InitializeComponent();
            btnDodajZaposlenog.Visible = false;
            btnObrisiRadnika.Visible = false;
            btnIzmeniRadnika.Visible = false;
            btnPrikaziSveSpoljneSaradnikeAgenta.Visible = false;
            btnIzaberiAgenta.Visible = true;
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
            PregledPoslovnica formaPregledPoslovnica = new PregledPoslovnica();
            formaPregledPoslovnica.ShowDialog();
            this.popuniPodacima();
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
            if (listaZaposlenih.SelectedItems.Count == 0)
            {
                MessageBox.Show("Morate da izaberete zaposlenog cije podatke zelite da izmenite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (listaZaposlenih.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete izmeniti podatke samo o jednom zaposlenom jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string mbr = listaZaposlenih.SelectedItems[0].SubItems[0].Text;
            string tipPosla = listaZaposlenih.SelectedItems[0].SubItems[5].Text;
            if (tipPosla == "Sef")
            {
                SefBasic sefBasic = DTOManager.vratiSefa(mbr);
                IzmeniSefa formaIzmeni = new IzmeniSefa(sefBasic);
                formaIzmeni.ShowDialog();
            }
            else
            {
                AgentBasic agentBasic = DTOManager.vratiAgenta(mbr);
                IzmeniAgenta formaIzmeni = new IzmeniAgenta(agentBasic);
                formaIzmeni.ShowDialog();
            }

            this.popuniPodacima();
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

        private void btnIzaberiAgenta_Click(object sender, EventArgs e)
        {
            if (listaZaposlenih.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite agenta kojeg zelite!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaZaposlenih.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete izabrati samo jednog zaposlenog jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaZaposlenih.SelectedItems[0].SubItems[5].Text == "Sef")
            {
                MessageBox.Show("Morate izabrati agenta!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.izabraniAgentMBR = listaZaposlenih.SelectedItems[0].SubItems[0].Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
