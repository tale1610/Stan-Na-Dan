namespace StanNaDan.Forme.PravnoLice
{
    partial class PregledPravnihLica
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
            listaNekretnina = new ListView();
            PIB = new ColumnHeader();
            Naziv = new ColumnHeader();
            AdresaSedista = new ColumnHeader();
            ImeKontaktOsobe = new ColumnHeader();
            EmailKontaktOsobe = new ColumnHeader();
            btnDodajPravnoLice = new Button();
            btnObrisiPravnoLice = new Button();
            btnIzmeniPravnoLice = new Button();
            SuspendLayout();
            // 
            // listaNekretnina
            // 
            listaNekretnina.Columns.AddRange(new ColumnHeader[] { PIB, Naziv, AdresaSedista, ImeKontaktOsobe, EmailKontaktOsobe });
            listaNekretnina.FullRowSelect = true;
            listaNekretnina.GridLines = true;
            listaNekretnina.Location = new Point(12, 12);
            listaNekretnina.Name = "listaNekretnina";
            listaNekretnina.Size = new Size(602, 408);
            listaNekretnina.TabIndex = 8;
            listaNekretnina.UseCompatibleStateImageBehavior = false;
            listaNekretnina.View = View.Details;
            // 
            // PIB
            // 
            PIB.Text = "PIB";
            PIB.Width = 50;
            // 
            // Naziv
            // 
            Naziv.Text = "Naziv";
            Naziv.Width = 100;
            // 
            // AdresaSedista
            // 
            AdresaSedista.Text = "Adresa Sedista";
            AdresaSedista.Width = 100;
            // 
            // ImeKontaktOsobe
            // 
            ImeKontaktOsobe.Text = "Ime Kontakt Osobe";
            ImeKontaktOsobe.Width = 150;
            // 
            // EmailKontaktOsobe
            // 
            EmailKontaktOsobe.Text = "Email Kontakt Osobe";
            EmailKontaktOsobe.Width = 200;
            // 
            // btnDodajPravnoLice
            // 
            btnDodajPravnoLice.Location = new Point(691, 12);
            btnDodajPravnoLice.Name = "btnDodajPravnoLice";
            btnDodajPravnoLice.Size = new Size(151, 29);
            btnDodajPravnoLice.TabIndex = 9;
            btnDodajPravnoLice.Text = "Dodaj Pravno Lice";
            btnDodajPravnoLice.UseVisualStyleBackColor = true;
            // 
            // btnObrisiPravnoLice
            // 
            btnObrisiPravnoLice.Location = new Point(691, 47);
            btnObrisiPravnoLice.Name = "btnObrisiPravnoLice";
            btnObrisiPravnoLice.Size = new Size(155, 29);
            btnObrisiPravnoLice.TabIndex = 10;
            btnObrisiPravnoLice.Text = "Obrisi Pravno Lice";
            btnObrisiPravnoLice.UseVisualStyleBackColor = true;
            // 
            // btnIzmeniPravnoLice
            // 
            btnIzmeniPravnoLice.Location = new Point(690, 82);
            btnIzmeniPravnoLice.Name = "btnIzmeniPravnoLice";
            btnIzmeniPravnoLice.Size = new Size(156, 29);
            btnIzmeniPravnoLice.TabIndex = 11;
            btnIzmeniPravnoLice.Text = "Izmeni Pravno Lice";
            btnIzmeniPravnoLice.UseVisualStyleBackColor = true;
            // 
            // PregledPravnihLica
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 450);
            Controls.Add(btnIzmeniPravnoLice);
            Controls.Add(btnObrisiPravnoLice);
            Controls.Add(btnDodajPravnoLice);
            Controls.Add(listaNekretnina);
            Name = "PregledPravnihLica";
            Text = "PregledPravnihLica";
            ResumeLayout(false);
        }

        #endregion

        private ListView listaNekretnina;
        private ColumnHeader PIB;
        private ColumnHeader Naziv;
        private ColumnHeader AdresaSedista;
        private ColumnHeader ImeKontaktOsobe;
        private ColumnHeader EmailKontaktOsobe;
        private Button btnDodajPravnoLice;
        private Button btnObrisiPravnoLice;
        private Button btnIzmeniPravnoLice;
    }
}