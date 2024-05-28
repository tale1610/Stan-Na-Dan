using StanNaDan.Forme.Vlasnici.FizickaLica.BrojeviTelefona;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Vlasnici.PravnaLica.TelefoniKontaktOsobe
{
    public partial class PregledSvihTelefonaKontaktOsoba : Form
    {
        string Pib;
        public PregledSvihTelefonaKontaktOsoba()
        {
            InitializeComponent();
        }
        public PregledSvihTelefonaKontaktOsoba(string pib)
        {
            InitializeComponent();
            this.Pib = pib;
        }

        public void popuniPodacima()
        {
            listaTelefona.Items.Clear();
            List<TelefoniKontaktOsobePregled> podaci = DTOManager.VratiSveTelefoneKontaktOsobe(this.Pib);

            foreach (TelefoniKontaktOsobePregled n in podaci)
            {
                ListViewItem item;
                item = new ListViewItem(n.BrojTelefona.ToString());
                listaTelefona.Items.Add(item);
            }
            listaTelefona.Refresh();
        }

        private void PregledSvihTelefonaKontaktOsoba_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnDodajTelefonKontaktOsobe_Click(object sender, EventArgs e)
        {
            DodajTelefonKontaktOsobe formaDodaj = new DodajTelefonKontaktOsobe(this.Pib);
            formaDodaj.ShowDialog();
            popuniPodacima();
        }

        private void btnObrisiTelefonKontaktOsobe_Click(object sender, EventArgs e)
        {
            if (listaTelefona.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite broj telefona koji zelite da obrisete!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaTelefona.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete obrisati samo jedan broj telefona jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string brojTelefona = listaTelefona.SelectedItems[0].SubItems[0].Text;
            DTOManager.ObrisiTelefonKontaktOsobe(brojTelefona, this.Pib);
            this.popuniPodacima();
        }
    }
}
