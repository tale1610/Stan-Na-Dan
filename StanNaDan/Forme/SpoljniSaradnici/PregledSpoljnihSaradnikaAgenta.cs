﻿using StanNaDan.Forme.Zaposleni.Agenti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.SpoljniSaradnici
{
    public partial class PregledSpoljnihSaradnikaAgenta : Form
    {
        string MbrAgenta;
        SpoljniSaradnikBasic SpoljniSaradnikBasic;
        public PregledSpoljnihSaradnikaAgenta()
        {
            InitializeComponent();
            this.SpoljniSaradnikBasic = new SpoljniSaradnikBasic();
        }

        public PregledSpoljnihSaradnikaAgenta(string mbrAgenta)
        {
            InitializeComponent();
            this.SpoljniSaradnikBasic = new SpoljniSaradnikBasic();
            this.MbrAgenta = mbrAgenta;
        }

        public void popuniPodacima()
        {
            listaSpoljnihSaradnika.Items.Clear();
            List<SpoljniSaradnikPregled> podaci = DTOManager.vratiSveSpoljneSaradnikeAgenta(this.MbrAgenta);

            foreach (SpoljniSaradnikPregled s in podaci)
            {
                ListViewItem item;
                item = new ListViewItem(new string[] { s.MbrAgenta, s.IdSaradnika.ToString(), s.Ime, s.Prezime, s.DatumAngazovanja.ToString(), s.Telefon, s.ProcenatOdNajma.ToString() });
                listaSpoljnihSaradnika.Items.Add(item);
            }
            listaSpoljnihSaradnika.Refresh();
        }

        private void PregledSpoljnihSaradnikaAgenta_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnDodajNovogSpoljnogSaradnika_Click(object sender, EventArgs e)
        {
            DodajNovogSpoljnogSaradnika formaDodajNovogSpoljnogSaradnika = new DodajNovogSpoljnogSaradnika(this.MbrAgenta);
            formaDodajNovogSpoljnogSaradnika.ShowDialog();

            this.popuniPodacima();
        }
    }
}