using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Nekretnine
{
    public partial class DodajNekretninu : Form
    {
        NekretninaBasic nekretnina;
        public DodajNekretninu()
        {
            InitializeComponent();
            nekretnina = new NekretninaBasic();
            cbTip.DropDownStyle = ComboBoxStyle.DropDownList;


            cbTip.Items.Add("Kuca");
            cbTip.Items.Add("Stan");
            cbTip.SelectedItem = cbTip.Items[0];
            cbTip.SelectedIndexChanged += new EventHandler(cbTip_SelectedIndexChanged);

        }
        private void cbTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbTip.SelectedItem.ToString() == "Kuca")
            {
                chbPosedujeDvoriste.Enabled = true;
                tbSpratnostKuce.Enabled = true;
                chbPosedujeLift.Enabled = false;
                tbSprat.Enabled= false;
            }
            if (cbTip.SelectedItem.ToString() == "Stan")
            {
                chbPosedujeDvoriste.Enabled = false;
                tbSpratnostKuce.Enabled = false;
                chbPosedujeLift.Enabled = true;
                tbSprat.Enabled = true;
            }

        }

        private void btnDodajNekretninu_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da dodate novu nekretninu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {

            }

        }
    }
}
