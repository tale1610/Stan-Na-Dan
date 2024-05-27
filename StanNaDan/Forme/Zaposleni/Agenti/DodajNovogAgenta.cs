using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StanNaDan.Forme.Zaposleni.Agenti
{
    public partial class DodajNovogAgenta : Form
    {
        AgentBasic agentBasic;
        int idPoslovnice;
        public DodajNovogAgenta()
        {
            InitializeComponent();
            agentBasic = new AgentBasic();
        }

        public DodajNovogAgenta(int idPoslovnice)
        {
            InitializeComponent();
            this.idPoslovnice = idPoslovnice;
            agentBasic = new AgentBasic();
        }

        private void DodajNovogAgenta_Load(object sender, EventArgs e)
        {

        }

        private void btnDodajNovogAgenta_Click(object sender, EventArgs e)
        {
            string poruka = "Da li ste sigurni da zelite da zaposlite novog agenta?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                this.agentBasic.MBR = tbMBR.Text;
                this.agentBasic.Ime = tbIme.Text;
                this.agentBasic.Prezime = tbPrezime.Text;
                this.agentBasic.StrucnaSprema = tbStrucnaSprema.Text;
                this.agentBasic.DatumZaposlenja = dateTimePicker1.Value;

                DTOManager.dodajNovogAgenta(idPoslovnice, this.agentBasic);
                MessageBox.Show($"Uspesno ste zaposlili novog agenta!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Odustali ste od dodavanja nove poslovnice!", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
