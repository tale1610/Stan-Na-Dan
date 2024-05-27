using StanNaDan.Forme.Zaposleni.Agenti;
using StanNaDan.Forme.Zaposleni.Sefovi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Zaposleni
{
    public partial class PregledZaposlenihPoslovnice : Form
    {
        int idPoslovnice;
        public PregledZaposlenihPoslovnice()
        {
            InitializeComponent();
        }

        public PregledZaposlenihPoslovnice(int idPoslovnice)
        {
            InitializeComponent();
            this.idPoslovnice = idPoslovnice;
        }

        private void btnDodajNovogSefa_Click(object sender, EventArgs e)
        {
            //TODO: Kreira novog sefa u bazii odmah ga vezuje za tu poslovnicu


            DodajNovogSefa formaDodajNovogSefa = new DodajNovogSefa(idPoslovnice);
            formaDodajNovogSefa.ShowDialog();

            this.popuniPodacima();
        }

        private void PregledZaposlenihPoslovnice_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            listaZaposlenih.Items.Clear();
            List<ZaposleniPregled> podaci = DTOManager.vratiSveZaposlenePoslovnice(this.idPoslovnice);

            foreach (ZaposleniPregled z in podaci)
            {
                ListViewItem item;
                item = new ListViewItem(new string[] { z.MBR, z.Ime, z.Prezime, z.DatumZaposlenja.ToString(), z.AdresaPoslovnice, z.Pozicija });
                listaZaposlenih.Items.Add(item);
            }
            listaZaposlenih.Refresh();
        }

        private void btnDodajNovogAgenta_Click(object sender, EventArgs e)
        {
            DodajNovogAgenta formaDodajNovogAgenta = new DodajNovogAgenta(this.idPoslovnice);
            formaDodajNovogAgenta.ShowDialog();

            this.popuniPodacima();
        }
    }
}
