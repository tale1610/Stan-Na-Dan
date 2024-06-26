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
    public partial class IzmeniDodatnuOpremu : Form
    {
        int IdNekretnine;
        DodatnaOpremaBasic dodatnaOpremaBasic;
        public IzmeniDodatnuOpremu()
        {
            InitializeComponent();
        }

        public IzmeniDodatnuOpremu(int idNekretnine, DodatnaOpremaBasic dodatnaOpremaBasic)
        {
            InitializeComponent();
            this.IdNekretnine = idNekretnine;
            this.dodatnaOpremaBasic = dodatnaOpremaBasic;
        }

        private void btnIzmeniDodatnuOpremu_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da izmenite dodatnu opremu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                this.dodatnaOpremaBasic.TipOpreme = tbTipOpreme.Text;
                this.dodatnaOpremaBasic.BesplatnoKoriscenje = cbBesplatnoKoriscenje.Checked;
                if (cbBesplatnoKoriscenje.Checked == false)
                {
                    this.dodatnaOpremaBasic.CenaKoriscenja = Double.Parse(tbCenaKoriscenja.Text);
                }
                else this.dodatnaOpremaBasic.CenaKoriscenja = null;

                DTOManager.IzmeniDodatnuOpremu(this.dodatnaOpremaBasic, this.IdNekretnine);
                MessageBox.Show($"Uspesno ste izmenili dodatnu opremu!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od menjanja dodatne opreme!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void IzmeniDodatnuOpremu_Load(object sender, EventArgs e)
        {
            tbCenaKoriscenja.Text = this.dodatnaOpremaBasic.CenaKoriscenja.ToString();
            tbTipOpreme.Text = this.dodatnaOpremaBasic.TipOpreme;
            cbBesplatnoKoriscenje.Checked = this.dodatnaOpremaBasic.BesplatnoKoriscenje;
        }
    }
}
