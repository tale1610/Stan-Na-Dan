﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Nekretnine.Sajtovi
{
    public partial class PregledOglasavanjaNekretnine : Form
    {
        int IdNekretnine;
        public PregledOglasavanjaNekretnine()
        {
            InitializeComponent();
        }
        public PregledOglasavanjaNekretnine(int idNekretnine)
        {
            InitializeComponent();
            this.IdNekretnine = idNekretnine;
        }

        public void popuniPodacima()
        {
            listaSajtova.Items.Clear();
            List<SajtoviNekretninePregled> podaci = DTOManager.VratiSveSajtoveNekretnine(this.IdNekretnine);

            foreach (SajtoviNekretninePregled s in podaci)
            {
                ListViewItem item;
                item = new ListViewItem(new string[] { s.IdNekretnine.ToString(), s.AdresaNekretnine, s.Sajt });
                listaSajtova.Items.Add(item);
            }
            listaSajtova.Refresh();
        }

        private void PregledOglasavanjaNekretnine_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnObrisiSajt_Click(object sender, EventArgs e)
        {
            if (listaSajtova.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite sajt koji zelite da obrisete!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (listaSajtova.SelectedItems.Count > 1)
            {
                MessageBox.Show("Mozete obrisati samo jedan sajt jednovremeno!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sajt = listaSajtova.SelectedItems[0].SubItems[2].Text;
            DTOManager.ObrisiSajtNekretnine(sajt, this.IdNekretnine);
            this.popuniPodacima();
        }
    }
}
