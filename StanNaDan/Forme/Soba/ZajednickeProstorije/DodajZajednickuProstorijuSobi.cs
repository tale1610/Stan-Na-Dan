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
    
    public partial class DodajZajednickuProstorijuSobi : Form
    {
        ZajednickeProstorijeBasic zpBasic;
        int idNekretnine;
        int idSobe;
        public DodajZajednickuProstorijuSobi()
        {
            InitializeComponent();
            zpBasic = new ZajednickeProstorijeBasic();
        }
        public DodajZajednickuProstorijuSobi(int idNekretnine, int idSobe)
        {
            InitializeComponent();
            zpBasic = new ZajednickeProstorijeBasic();
            this.idSobe = idSobe;
            this.idNekretnine = idNekretnine;
        }
        private void btnDodajProstoriju_Click(object sender, EventArgs e)
        {
            string poruka = "Da li ste sigurni da zelite da dodate novu prostoriju?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                this.zpBasic.ZajednickaProstorija = tbProstorija.Text;
                DTOManager.DodajZajednickuProstoriju(zpBasic, this.idSobe, this.idNekretnine);
                MessageBox.Show($"Uspesno ste dodali novu prostoriju sobi!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od dodavanja nove prostorije!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
