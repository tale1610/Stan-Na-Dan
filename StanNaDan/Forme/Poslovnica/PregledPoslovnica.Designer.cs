namespace StanNaDan.Forme
{
    partial class PregledPoslovnica
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
            listaPoslovnica = new ListView();
            ID = new ColumnHeader();
            Adresa = new ColumnHeader();
            RadnoVreme = new ColumnHeader();
            Sef = new ColumnHeader();
            btnDodajPoslovnicu = new Button();
            btnObrisiPoslovnicu = new Button();
            btnIzmeniPoslovnicu = new Button();
            btnDodajNovogAgenta = new Button();
            btnPrikaziSveZaposlenePoslovnice = new Button();
            btnPrikaziSveKvartove = new Button();
            SuspendLayout();
            // 
            // listaPoslovnica
            // 
            listaPoslovnica.Columns.AddRange(new ColumnHeader[] { ID, Adresa, RadnoVreme, Sef });
            listaPoslovnica.FullRowSelect = true;
            listaPoslovnica.GridLines = true;
            listaPoslovnica.Location = new Point(12, 27);
            listaPoslovnica.Name = "listaPoslovnica";
            listaPoslovnica.Size = new Size(664, 411);
            listaPoslovnica.TabIndex = 0;
            listaPoslovnica.UseCompatibleStateImageBehavior = false;
            listaPoslovnica.View = View.Details;
            // 
            // ID
            // 
            ID.Text = "ID";
            ID.Width = 50;
            // 
            // Adresa
            // 
            Adresa.Text = "Adresa";
            Adresa.Width = 300;
            // 
            // RadnoVreme
            // 
            RadnoVreme.Text = "Radno Vreme";
            RadnoVreme.Width = 170;
            // 
            // Sef
            // 
            Sef.Text = "Sef";
            Sef.Width = 200;
            // 
            // btnDodajPoslovnicu
            // 
            btnDodajPoslovnicu.Location = new Point(682, 27);
            btnDodajPoslovnicu.Name = "btnDodajPoslovnicu";
            btnDodajPoslovnicu.Size = new Size(184, 29);
            btnDodajPoslovnicu.TabIndex = 1;
            btnDodajPoslovnicu.Text = "Dodaj Poslovnicu";
            btnDodajPoslovnicu.UseVisualStyleBackColor = true;
            btnDodajPoslovnicu.Click += btnDodajPoslovnicu_Click;
            // 
            // btnObrisiPoslovnicu
            // 
            btnObrisiPoslovnicu.Location = new Point(682, 83);
            btnObrisiPoslovnicu.Name = "btnObrisiPoslovnicu";
            btnObrisiPoslovnicu.Size = new Size(184, 29);
            btnObrisiPoslovnicu.TabIndex = 2;
            btnObrisiPoslovnicu.Text = "Obrisi Poslovnicu";
            btnObrisiPoslovnicu.UseVisualStyleBackColor = true;
            btnObrisiPoslovnicu.Click += btnObrisiPoslovnicu_Click;
            // 
            // btnIzmeniPoslovnicu
            // 
            btnIzmeniPoslovnicu.Location = new Point(682, 140);
            btnIzmeniPoslovnicu.Name = "btnIzmeniPoslovnicu";
            btnIzmeniPoslovnicu.Size = new Size(184, 29);
            btnIzmeniPoslovnicu.TabIndex = 3;
            btnIzmeniPoslovnicu.Text = "Izmeni Poslovnicu";
            btnIzmeniPoslovnicu.UseVisualStyleBackColor = true;
            btnIzmeniPoslovnicu.Click += btnIzmeniPoslovnicu_Click;
            // 
            // btnDodajNovogAgenta
            // 
            btnDodajNovogAgenta.Location = new Point(682, 230);
            btnDodajNovogAgenta.Name = "btnDodajNovogAgenta";
            btnDodajNovogAgenta.Size = new Size(184, 29);
            btnDodajNovogAgenta.TabIndex = 4;
            btnDodajNovogAgenta.Text = "Zaposli Novog Agenta";
            btnDodajNovogAgenta.UseVisualStyleBackColor = true;
            btnDodajNovogAgenta.Click += btnDodajNovogAgenta_Click;
            // 
            // btnPrikaziSveZaposlenePoslovnice
            // 
            btnPrikaziSveZaposlenePoslovnice.Location = new Point(682, 279);
            btnPrikaziSveZaposlenePoslovnice.Name = "btnPrikaziSveZaposlenePoslovnice";
            btnPrikaziSveZaposlenePoslovnice.Size = new Size(184, 29);
            btnPrikaziSveZaposlenePoslovnice.TabIndex = 5;
            btnPrikaziSveZaposlenePoslovnice.Text = "Prikazi Sve Zaposlene";
            btnPrikaziSveZaposlenePoslovnice.UseVisualStyleBackColor = true;
            btnPrikaziSveZaposlenePoslovnice.Click += btnPrikaziSveZaposlenePoslovnice_Click;
            // 
            // btnPrikaziSveKvartove
            // 
            btnPrikaziSveKvartove.Location = new Point(682, 353);
            btnPrikaziSveKvartove.Name = "btnPrikaziSveKvartove";
            btnPrikaziSveKvartove.Size = new Size(184, 29);
            btnPrikaziSveKvartove.TabIndex = 6;
            btnPrikaziSveKvartove.Text = "Prikazi Sve Kvartove";
            btnPrikaziSveKvartove.UseVisualStyleBackColor = true;
            btnPrikaziSveKvartove.Click += btnPrikaziSveKvartove_Click;
            // 
            // PregledPoslovnica
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 450);
            Controls.Add(btnPrikaziSveKvartove);
            Controls.Add(btnPrikaziSveZaposlenePoslovnice);
            Controls.Add(btnDodajNovogAgenta);
            Controls.Add(btnIzmeniPoslovnicu);
            Controls.Add(btnObrisiPoslovnicu);
            Controls.Add(btnDodajPoslovnicu);
            Controls.Add(listaPoslovnica);
            Name = "PregledPoslovnica";
            Text = "PregledPoslovnica";
            Load += PregledPoslovnica_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listaPoslovnica;
        private Button btnDodajPoslovnicu;
        private Button btnObrisiPoslovnicu;
        private Button btnIzmeniPoslovnicu;
        private ColumnHeader ID;
        private ColumnHeader Adresa;
        private ColumnHeader RadnoVreme;
        private ColumnHeader Sef;
        private Button btnDodajNovogAgenta;
        private Button btnPrikaziSveZaposlenePoslovnice;
        private Button btnPrikaziSveKvartove;
    }
}