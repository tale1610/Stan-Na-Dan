using StanNaDan.Forme;
using StanNaDan.Forme.IznajmljivanjaSoba;
using StanNaDan.Forme.Kvartovi;
using StanNaDan.Forme.Najam;
using StanNaDan.Forme.Nekretnine;
using StanNaDan.Forme.Soba;
using StanNaDan.Forme.Vlasnici;
using StanNaDan.Forme.Zaposleni;

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

        private void btnSobe_Click(object sender, EventArgs e)
        {
            PregledSvihSoba formaPregledSvihSoba = new PregledSvihSoba();
            formaPregledSvihSoba.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PregledIznajmljivanjaSoba formaPregledIznajmljivanjaSoba = new PregledIznajmljivanjaSoba();
            formaPregledIznajmljivanjaSoba.ShowDialog();
        }
    }
}
