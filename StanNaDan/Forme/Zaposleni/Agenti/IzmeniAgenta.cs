using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Zaposleni.Agenti
{
    public partial class IzmeniAgenta : Form
    {
        public AgentBasic agentBasic;
        public IzmeniAgenta()
        {
            InitializeComponent();
        }
        public IzmeniAgenta(AgentBasic agentBasic)
        {
            InitializeComponent();
            this.agentBasic = agentBasic;
        }

        private void popuniPodacima()
        {
            tbMBR.Text = agentBasic.MBR;
            tbIme.Text = agentBasic.Ime;
            tbPrezime.Text = agentBasic.Prezime;
            dateTimePicker1.Value = agentBasic.DatumZaposlenja;
            tbStrucnaSprema.Text = agentBasic.StrucnaSprema;
        }

        private void IzmeniAgenta_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btnIzmeniAgenta_Click(object sender, EventArgs e)
        {
            string poruka = "Da li ste sigurni da zelite da izvrsite izmene agenta?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);
            if (result == DialogResult.OK)
            {
                agentBasic.MBR = tbMBR.Text;
                agentBasic.Ime = tbIme.Text;
                agentBasic.Prezime = tbPrezime.Text;
                agentBasic.DatumZaposlenja = dateTimePicker1.Value;
                agentBasic.StrucnaSprema = tbStrucnaSprema.Text;

                DTOManager.IzmeniAgenta(this.agentBasic);
                MessageBox.Show("Azuriranje agenta je uspesno izvrseno!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od azuriranja agenta!");
                this.Close();
            }
        }
    }
}
