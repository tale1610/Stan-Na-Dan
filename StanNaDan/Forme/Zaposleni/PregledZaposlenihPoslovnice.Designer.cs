namespace StanNaDan.Forme.Zaposleni
{
    partial class PregledZaposlenihPoslovnice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listaZaposlenih = new ListView();
            MBR = new ColumnHeader();
            Ime = new ColumnHeader();
            Prezime = new ColumnHeader();
            Datum_Zaposlenja = new ColumnHeader();
            AdresaPoslovnice = new ColumnHeader();
            TipPosla = new ColumnHeader();
            btnDodajNovogSefa = new Button();
            btnDodajNovogAgenta = new Button();
            SuspendLayout();
            // 
            // listaZaposlenih
            // 
            listaZaposlenih.Columns.AddRange(new ColumnHeader[] { MBR, Ime, Prezime, Datum_Zaposlenja, AdresaPoslovnice, TipPosla });
            listaZaposlenih.FullRowSelect = true;
            listaZaposlenih.GridLines = true;
            listaZaposlenih.Location = new Point(12, 12);
            listaZaposlenih.Name = "listaZaposlenih";
            listaZaposlenih.Size = new Size(924, 411);
            listaZaposlenih.TabIndex = 5;
            listaZaposlenih.UseCompatibleStateImageBehavior = false;
            listaZaposlenih.View = View.Details;
            // 
            // MBR
            // 
            MBR.Text = "MBR";
            MBR.Width = 150;
            // 
            // Ime
            // 
            Ime.Text = "Ime";
            Ime.Width = 100;
            // 
            // Prezime
            // 
            Prezime.Text = "Prezime";
            Prezime.Width = 150;
            // 
            // Datum_Zaposlenja
            // 
            Datum_Zaposlenja.Text = "Datum Zaposlenja";
            Datum_Zaposlenja.Width = 150;
            // 
            // AdresaPoslovnice
            // 
            AdresaPoslovnice.Text = "Poslovnica";
            AdresaPoslovnice.Width = 300;
            // 
            // TipPosla
            // 
            TipPosla.Text = "Pozicija";
            TipPosla.Width = 70;
            // 
            // btnDodajNovogSefa
            // 
            btnDodajNovogSefa.Location = new Point(942, 12);
            btnDodajNovogSefa.Name = "btnDodajNovogSefa";
            btnDodajNovogSefa.Size = new Size(214, 29);
            btnDodajNovogSefa.TabIndex = 6;
            btnDodajNovogSefa.Text = "Dodaj Novog Sefa";
            btnDodajNovogSefa.UseVisualStyleBackColor = true;
            btnDodajNovogSefa.Click += btnDodajNovogSefa_Click;
            // 
            // btnDodajNovogAgenta
            // 
            btnDodajNovogAgenta.Location = new Point(942, 56);
            btnDodajNovogAgenta.Name = "btnDodajNovogAgenta";
            btnDodajNovogAgenta.Size = new Size(214, 29);
            btnDodajNovogAgenta.TabIndex = 7;
            btnDodajNovogAgenta.Text = "Dodaj Novog Agenta";
            btnDodajNovogAgenta.UseVisualStyleBackColor = true;
            btnDodajNovogAgenta.Click += btnDodajNovogAgenta_Click;
            // 
            // PregledZaposlenihPoslovnice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1164, 497);
            Controls.Add(btnDodajNovogAgenta);
            Controls.Add(btnDodajNovogSefa);
            Controls.Add(listaZaposlenih);
            Name = "PregledZaposlenihPoslovnice";
            Text = "PregledZaposlenihPoslovnice";
            Load += PregledZaposlenihPoslovnice_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listaZaposlenih;
        private ColumnHeader MBR;
        private ColumnHeader Ime;
        private ColumnHeader Prezime;
        private ColumnHeader Datum_Zaposlenja;
        private ColumnHeader AdresaPoslovnice;
        private ColumnHeader TipPosla;
        private Button btnDodajNovogSefa;
        private Button btnDodajNovogAgenta;
    }
}