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

namespace StanNaDan.Forme.Kvartovi
{
    public partial class PregledKvartovaPoslovnice : Form
    {
        int IdPoslovnice;
        public PregledKvartovaPoslovnice()
        {
            InitializeComponent();
        }
        public PregledKvartovaPoslovnice(int idPoslovnice)
        {
            InitializeComponent();
            this.IdPoslovnice = idPoslovnice;
        }
        public void popuniPodacima()
        {
            listaKvartova.Items.Clear();
            List<KvartPregled> podaci = DTOManager.vratiSveKvartovePoslovnice(this.IdPoslovnice);

            foreach (KvartPregled k in podaci)
            {
                ListViewItem item;
                item = new ListViewItem(new string[] { k.IdKvarta.ToString(), k.GradskaZona, k.AdresaPoslovnice });
                listaKvartova.Items.Add(item);
            }
            listaKvartova.Refresh();
        }
        private void PregledKvartovaPoslovnice_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnDodajNoviKvart_Click(object sender, EventArgs e)
        {
            DodajKvartPoslovnici formaDodajKvartPoslovnici = new DodajKvartPoslovnici(this.IdPoslovnice);
            formaDodajKvartPoslovnici.ShowDialog();

            this.popuniPodacima();
        }
    }
}
