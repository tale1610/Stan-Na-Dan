using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Parking
{
    public partial class PregledSvihParkinga : Form
    {
        int IdNekretnine;
        public PregledSvihParkinga()
        {
            InitializeComponent();
        }
        public PregledSvihParkinga(int idNekretnine)
        {
            InitializeComponent();
            this.IdNekretnine = idNekretnine;
        }
        public void popuniPodacima()
        {
            listaParkinga.Items.Clear();
            List<ParkingPregled> podaci = DTOManager.VratiSveParkingeNekretnine(this.IdNekretnine);

            foreach (ParkingPregled p in podaci)
            {
                ListViewItem item;
                item = new ListViewItem(new string[] { p.IdParkinga.ToString(), p.Besplatan?"Besplatan":"Placa se", p.Besplatan?"Besplatan":p.Cena.ToString(), p.USastavuNekretnine?"Da":"Ne", p.USastavuJavnogParkinga?"Da":"Ne" });
                listaParkinga.Items.Add(item);
            }
            listaParkinga.Refresh();
        }
        private void PregledSvihParkinga_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }
    }
}
