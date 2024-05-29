using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Najam
{
    public partial class IzmeniNajam : Form
    {
        //int IdNekretnine;
        //string mbrAgenta;
        //int IdSpoljnog;
        public NajamBasic NajamBasic;

        public IzmeniNajam()
        {
            InitializeComponent();
            this.NajamBasic = new NajamBasic();
            //this.btnIzaberiSpoljnog.Enabled = false;
            //this.IdSpoljnog = 0;
        }

        public IzmeniNajam(NajamBasic najamBasic)
        {
            InitializeComponent();
            NajamBasic = najamBasic;
            //this.IdSpoljnog = 0;
            //if (NajamBasic.SpoljniSaradnik == null && NajamBasic.Agent == null)
            //{
            //    this.btnIzaberiSpoljnog.Enabled = false;
            //}
            //else if(NajamBasic.SpoljniSaradnik != null)
            //{
            //    this.btnIzaberiSpoljnog.Enabled = true;
            //    this.IdSpoljnog = NajamBasic.SpoljniSaradnik.IdSaradnika; 
            //}
            //else
            //{
            //    this.btnIzaberiSpoljnog.Enabled = true;
            //}
        }

        private void popuniPodacima()
        {
            dtpPocetak.Value = NajamBasic.DatumPocetka;
            dtpZavrsetak.Value = NajamBasic.DatumZavrsetka;
            tbCenaPoDanu.Text = NajamBasic.CenaPoDanu.ToString();
            tbPopust.Text = NajamBasic.Popust.ToString();
            tbProvizijaAgencije.Text = NajamBasic.ProvizijaAgencije.ToString();
        }

        private void IzmeniNajam_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnIzmeniNajam_Click(object sender, EventArgs e)
        {
            string poruka = "Da li ste sigurni da zelite da izvrsite izmene najma?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                NajamBasic.DatumPocetka = dtpPocetak.Value;
                NajamBasic.DatumZavrsetka = dtpZavrsetak.Value;
                NajamBasic.CenaPoDanu = double.Parse(tbCenaPoDanu.Text);
                NajamBasic.Popust = Int32.Parse(tbPopust.Text);
                NajamBasic.ProvizijaAgencije = double.Parse(tbProvizijaAgencije.Text);

                DTOManager.IzmeniNajam(this.NajamBasic);
                MessageBox.Show("Azuriranje najma je uspesno izvrseno!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od azuriranja najma!");
                this.Close();
            }
        }
    }
}
