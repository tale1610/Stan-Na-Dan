using StanNaDan.Forme;
using StanNaDan.Forme.Kvartovi;
using StanNaDan.Forme.Najam;
using StanNaDan.Forme.Nekretnine;
using StanNaDan.Forme.Vlasnici;
using StanNaDan.Forme.Zaposleni;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan
{
    public partial class Pocetna : Form
    {
        public Pocetna()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PregledPoslovnica formaPregledPoslovnica = new PregledPoslovnica();
            formaPregledPoslovnica.ShowDialog();
        }

        private void btnZaposleni_Click(object sender, EventArgs e)
        {
            PregledZaposlenih formaPregledZaposlenih = new PregledZaposlenih();
            formaPregledZaposlenih.ShowDialog();
        }

        private void btnTestForma_Click(object sender, EventArgs e)
        {
            Form1 testForma = new Form1();
            testForma.ShowDialog();
        }

        private void btnVlasnici_Click(object sender, EventArgs e)
        {
            PregledSvihVlasnika formaPregledSvihVlasnika = new PregledSvihVlasnika();
            formaPregledSvihVlasnika.ShowDialog();
        }

        private void btnNekretnine_Click(object sender, EventArgs e)
        {
            PregledSvihNekretnina formaPregledSvihNekretnina = new PregledSvihNekretnina();
            formaPregledSvihNekretnina.ShowDialog();
        }

        private void btnNajmovi_Click(object sender, EventArgs e)
        {
            PregledSvihNajmova formaPregledSvihNajmova = new PregledSvihNajmova();
            formaPregledSvihNajmova.ShowDialog();
        }
    }
}
