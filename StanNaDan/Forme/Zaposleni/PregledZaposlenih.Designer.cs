namespace StanNaDan.Forme.Zaposleni
{
    partial class PregledZaposlenih
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
            btnIzmeniRadnika = new Button();
            btnObrisiRadnika = new Button();
            btnDodajZaposlenog = new Button();
            listaZaposlenih = new ListView();
            MBR = new ColumnHeader();
            Ime = new ColumnHeader();
            Prezime = new ColumnHeader();
            Datum_Zaposlenja = new ColumnHeader();
            AdresaPoslovnice = new ColumnHeader();
            TipPosla = new ColumnHeader();
            btnPrikaziSveSpoljneSaradnikeAgenta = new Button();
            SuspendLayout();
            // 
            // btnIzmeniRadnika
            // 
            btnIzmeniRadnika.Location = new Point(944, 133);
            btnIzmeniRadnika.Name = "btnIzmeniRadnika";
            btnIzmeniRadnika.Size = new Size(184, 29);
            btnIzmeniRadnika.TabIndex = 7;
            btnIzmeniRadnika.Text = "Izmeni Radnika";
            btnIzmeniRadnika.UseVisualStyleBackColor = true;
            btnIzmeniRadnika.Click += btnIzmeniRadnika_Click;
            // 
            // btnObrisiRadnika
            // 
            btnObrisiRadnika.Location = new Point(944, 76);
            btnObrisiRadnika.Name = "btnObrisiRadnika";
            btnObrisiRadnika.Size = new Size(184, 29);
            btnObrisiRadnika.TabIndex = 6;
            btnObrisiRadnika.Text = "Otpusti Radnika";
            btnObrisiRadnika.UseVisualStyleBackColor = true;
            btnObrisiRadnika.Click += btnObrisiRadnika_Click;
            // 
            // btnDodajZaposlenog
            // 
            btnDodajZaposlenog.Location = new Point(944, 20);
            btnDodajZaposlenog.Name = "btnDodajZaposlenog";
            btnDodajZaposlenog.Size = new Size(184, 29);
            btnDodajZaposlenog.TabIndex = 5;
            btnDodajZaposlenog.Text = "Zaposli Novog Radnika";
            btnDodajZaposlenog.UseVisualStyleBackColor = true;
            btnDodajZaposlenog.Click += btnDodajZaposlenog_Click;
            // 
            // listaZaposlenih
            // 
            listaZaposlenih.Columns.AddRange(new ColumnHeader[] { MBR, Ime, Prezime, Datum_Zaposlenja, AdresaPoslovnice, TipPosla });
            listaZaposlenih.FullRowSelect = true;
            listaZaposlenih.GridLines = true;
            listaZaposlenih.Location = new Point(12, 20);
            listaZaposlenih.Name = "listaZaposlenih";
            listaZaposlenih.Size = new Size(926, 411);
            listaZaposlenih.TabIndex = 4;
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
            // btnPrikaziSveSpoljneSaradnikeAgenta
            // 
            btnPrikaziSveSpoljneSaradnikeAgenta.Location = new Point(944, 186);
            btnPrikaziSveSpoljneSaradnikeAgenta.Name = "btnPrikaziSveSpoljneSaradnikeAgenta";
            btnPrikaziSveSpoljneSaradnikeAgenta.Size = new Size(184, 53);
            btnPrikaziSveSpoljneSaradnikeAgenta.TabIndex = 8;
            btnPrikaziSveSpoljneSaradnikeAgenta.Text = "Prikazi Sve Spoljne Saradnike Agenta";
            btnPrikaziSveSpoljneSaradnikeAgenta.UseVisualStyleBackColor = true;
            btnPrikaziSveSpoljneSaradnikeAgenta.Click += btnPrikaziSveSpoljneSaradnikeAgenta_Click;
            // 
            // PregledZaposlenih
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1141, 507);
            Controls.Add(btnPrikaziSveSpoljneSaradnikeAgenta);
            Controls.Add(btnIzmeniRadnika);
            Controls.Add(btnObrisiRadnika);
            Controls.Add(btnDodajZaposlenog);
            Controls.Add(listaZaposlenih);
            Name = "PregledZaposlenih";
            Text = "PregledZaposlenih";
            Load += PregledZaposlenih_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnIzmeniRadnika;
        private Button btnObrisiRadnika;
        private Button btnDodajZaposlenog;
        private ListView listaZaposlenih;
        private ColumnHeader MBR;
        private ColumnHeader Ime;
        private ColumnHeader Prezime;
        private ColumnHeader Datum_Zaposlenja;
        private ColumnHeader AdresaPoslovnice;
        private ColumnHeader TipPosla;
        private Button btnPrikaziSveSpoljneSaradnikeAgenta;
    }
}