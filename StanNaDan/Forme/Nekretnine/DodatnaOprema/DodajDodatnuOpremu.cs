﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Nekretnine.DodatnaOprema
{
    public partial class DodajDodatnuOpremu : Form
    {
        int IdNekretnine;
        DodatnaOpremaBasic dodatnaOpremaBasic;
        public DodajDodatnuOpremu()
        {
            InitializeComponent();
        }

        public DodajDodatnuOpremu(int idNekretnine)
        {
            InitializeComponent();
            this.IdNekretnine = idNekretnine;
            this.dodatnaOpremaBasic = new DodatnaOpremaBasic();
        }

        private void btnDodajNovuOpremu_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da dodate novu dodatnu opremu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                this.dodatnaOpremaBasic.TipOpreme = tbTipOpreme.Text;
                this.dodatnaOpremaBasic.BesplatnoKoriscenje = cbBesplatnoKoriscenje.Checked;
                this.dodatnaOpremaBasic.IdOpreme = Int32.Parse(tbIdOpreme.Text);
                if (cbBesplatnoKoriscenje.Checked == false)
                {
                    this.dodatnaOpremaBasic.CenaKoriscenja = Double.Parse(tbCenaKoriscenja.Text);
                }
                else this.dodatnaOpremaBasic.CenaKoriscenja = null;

                DTOManager.DodajDodatnuOpremu(this.dodatnaOpremaBasic, this.IdNekretnine);
                MessageBox.Show($"Uspesno ste dodali novu dodatnu opremu nekretnini sa ID: {this.IdNekretnine}!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od dodavanja nove dodatne opreme!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void cbBesplatnoKoriscenje_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBesplatnoKoriscenje.Checked == true)
            {
                tbCenaKoriscenja.Enabled = false;
            }
            else { tbCenaKoriscenja.Enabled = true; }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
