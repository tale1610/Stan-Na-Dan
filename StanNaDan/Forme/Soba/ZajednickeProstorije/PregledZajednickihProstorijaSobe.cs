using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Soba.ZajednickeProstorije
{
    public partial class PregledZajednickihProstorijaSobe : Form
    {
        int idSobe;
        int idNekretnine;
        int idNajma;
        delegate void DelegatPopunjavanja();
        DelegatPopunjavanja popuniPodacima;
        public PregledZajednickihProstorijaSobe()
        {
            InitializeComponent();
            popuniPodacima = popuniPodacima1;
        }
        public PregledZajednickihProstorijaSobe(int idNajma)
        {
            InitializeComponent();
            this.btnDodajZajednickuProstoriju.Visible = false;
            this.btnObrisiZajednickuProstoriju.Visible = false;
            this.idNajma = idNajma;
            popuniPodacima = popuniPodacima2;

        }
        public PregledZajednickihProstorijaSobe(int idSobe, int idNekretnine)
        {
            InitializeComponent();
            this.idSobe = idSobe;
            this.idNekretnine = idNekretnine;
            popuniPodacima = popuniPodacima1;
        }

        public void popuniPodacima1()
        {
            listaProstorija.Items.Clear();
            List<ZajednickeProstorijePregled> podaci = DTOManager.VratiSveZajednickeProstorijeSobe(this.idSobe, this.idNekretnine);

            foreach (ZajednickeProstorijePregled zp in podaci)
            {
                ListViewItem item;
                item = new ListViewItem(new string[] { zp.ZajednickaProstorija });
                listaProstorija.Items.Add(item);
            }
            listaProstorija.Refresh();
        }
        public void popuniPodacima2()
        {
            listaProstorija.Items.Clear();
            List<ZajednickeProstorijePregled> podaci = DTOManager.VratiSveZajednickeProstorijeNajma(this.idNajma);

            foreach (ZajednickeProstorijePregled zp in podaci)
            {
                ListViewItem item;
                item = new ListViewItem(new string[] { zp.ZajednickaProstorija });
                listaProstorija.Items.Add(item);
            }
            listaProstorija.Refresh();
        }

        private void PregledZajednickihProstorijaSobe_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnDodajZajednickuProstoriju_Click(object sender, EventArgs e)
        {
            DodajZajednickuProstorijuSobi formaDodajZajednickuProstorijuSobi = new DodajZajednickuProstorijuSobi(idNekretnine, idSobe);
            formaDodajZajednickuProstorijuSobi.ShowDialog();
            this.popuniPodacima();
        }

        private void btnObrisiZajednickuProstoriju_Click(object sender, EventArgs e)
        {
            if (listaProstorija.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite prostoriju koji zelite da obrisete!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaProstorija.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete obrisati samo jednu prostoriju jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string prostorija = listaProstorija.SelectedItems[0].SubItems[0].Text;
            DTOManager.ObrisiZajednickuProstoriju(this.idSobe, this.idNekretnine, prostorija);
            this.popuniPodacima();
        }
    }
}
