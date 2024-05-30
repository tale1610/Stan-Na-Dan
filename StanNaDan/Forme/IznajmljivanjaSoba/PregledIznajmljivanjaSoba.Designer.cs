namespace StanNaDan.Forme.IznajmljivanjaSoba
{
    partial class PregledIznajmljivanjaSoba
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
            listaNajmova = new ListView();
            ID = new ColumnHeader();
            NekretninaID = new ColumnHeader();
            SobaID = new ColumnHeader();
            DatumPocetka = new ColumnHeader();
            DatumZavrsetka = new ColumnHeader();
            BrojDana = new ColumnHeader();
            CenaPoDanu = new ColumnHeader();
            CenaSaPopustom = new ColumnHeader();
            zarada = new ColumnHeader();
            UkupnaCena = new ColumnHeader();
            ProvizijaAgencije = new ColumnHeader();
            Agent = new ColumnHeader();
            Spoljni = new ColumnHeader();
            btnDodajNajamSobe = new Button();
            btnObrisiNajamSobe = new Button();
            btnPrikaziZajednickeProstorije = new Button();
            SuspendLayout();
            // 
            // listaNajmova
            // 
            listaNajmova.Columns.AddRange(new ColumnHeader[] { ID, NekretninaID, SobaID, DatumPocetka, DatumZavrsetka, BrojDana, CenaPoDanu, CenaSaPopustom, zarada, UkupnaCena, ProvizijaAgencije, Agent, Spoljni });
            listaNajmova.FullRowSelect = true;
            listaNajmova.GridLines = true;
            listaNajmova.Location = new Point(10, 9);
            listaNajmova.Margin = new Padding(3, 2, 3, 2);
            listaNajmova.Name = "listaNajmova";
            listaNajmova.Size = new Size(1191, 307);
            listaNajmova.TabIndex = 7;
            listaNajmova.UseCompatibleStateImageBehavior = false;
            listaNajmova.View = View.Details;
            // 
            // ID
            // 
            ID.Text = "Id Najma";
            ID.Width = 80;
            // 
            // NekretninaID
            // 
            NekretninaID.Text = "Id Nekretnine";
            NekretninaID.Width = 110;
            // 
            // SobaID
            // 
            SobaID.Text = "Id Sobe";
            SobaID.Width = 80;
            // 
            // DatumPocetka
            // 
            DatumPocetka.Text = "Pocetak";
            DatumPocetka.Width = 90;
            // 
            // DatumZavrsetka
            // 
            DatumZavrsetka.Text = "Zavrsetak";
            DatumZavrsetka.Width = 90;
            // 
            // BrojDana
            // 
            BrojDana.Text = "Broj Dana";
            BrojDana.Width = 80;
            // 
            // CenaPoDanu
            // 
            CenaPoDanu.Text = "Cena Po Danu";
            CenaPoDanu.Width = 110;
            // 
            // CenaSaPopustom
            // 
            CenaSaPopustom.Text = "Cena Sa Popustom";
            CenaSaPopustom.Width = 135;
            // 
            // zarada
            // 
            zarada.Text = "Zarada od dodatnih usluga";
            zarada.Width = 150;
            // 
            // UkupnaCena
            // 
            UkupnaCena.Text = "Ukupna Cena";
            UkupnaCena.Width = 100;
            // 
            // ProvizijaAgencije
            // 
            ProvizijaAgencije.Text = "Provizija Agencije";
            ProvizijaAgencije.Width = 130;
            // 
            // Agent
            // 
            Agent.Text = "Agent";
            Agent.Width = 80;
            // 
            // Spoljni
            // 
            Spoljni.Text = "Spoljni Saradnik";
            Spoljni.Width = 120;
            // 
            // btnDodajNajamSobe
            // 
            btnDodajNajamSobe.Location = new Point(1207, 9);
            btnDodajNajamSobe.Margin = new Padding(3, 2, 3, 2);
            btnDodajNajamSobe.Name = "btnDodajNajamSobe";
            btnDodajNajamSobe.Size = new Size(144, 40);
            btnDodajNajamSobe.TabIndex = 8;
            btnDodajNajamSobe.Text = "Dodaj Novo Iznajmljivanje Soba";
            btnDodajNajamSobe.UseVisualStyleBackColor = true;
            btnDodajNajamSobe.Click += btnDodajNajamSobe_Click;
            // 
            // btnObrisiNajamSobe
            // 
            btnObrisiNajamSobe.Location = new Point(1207, 67);
            btnObrisiNajamSobe.Margin = new Padding(3, 2, 3, 2);
            btnObrisiNajamSobe.Name = "btnObrisiNajamSobe";
            btnObrisiNajamSobe.Size = new Size(144, 38);
            btnObrisiNajamSobe.TabIndex = 10;
            btnObrisiNajamSobe.Text = "Obrisi Najam Soba";
            btnObrisiNajamSobe.UseVisualStyleBackColor = true;
            btnObrisiNajamSobe.Click += btnObrisiNajamSobe_Click;
            // 
            // btnPrikaziZajednickeProstorije
            // 
            btnPrikaziZajednickeProstorije.Location = new Point(1207, 125);
            btnPrikaziZajednickeProstorije.Margin = new Padding(3, 2, 3, 2);
            btnPrikaziZajednickeProstorije.Name = "btnPrikaziZajednickeProstorije";
            btnPrikaziZajednickeProstorije.Size = new Size(144, 44);
            btnPrikaziZajednickeProstorije.TabIndex = 11;
            btnPrikaziZajednickeProstorije.Text = "Prikazi Zajednicke Prostorije";
            btnPrikaziZajednickeProstorije.UseVisualStyleBackColor = true;
            btnPrikaziZajednickeProstorije.Click += btnPrikaziZajednickeProstorije_Click;
            // 
            // PregledIznajmljivanjaSoba
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1362, 338);
            Controls.Add(btnPrikaziZajednickeProstorije);
            Controls.Add(btnObrisiNajamSobe);
            Controls.Add(btnDodajNajamSobe);
            Controls.Add(listaNajmova);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PregledIznajmljivanjaSoba";
            Text = "PregledIznajmljivanjaSoba";
            Load += PregledIznajmljivanjaSoba_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listaNajmova;
        private ColumnHeader ID;
        private ColumnHeader DatumPocetka;
        private ColumnHeader DatumZavrsetka;
        private ColumnHeader BrojDana;
        private ColumnHeader CenaPoDanu;
        private ColumnHeader CenaSaPopustom;
        private ColumnHeader UkupnaCena;
        private ColumnHeader ProvizijaAgencije;
        private ColumnHeader Agent;
        private ColumnHeader Spoljni;
        private ColumnHeader NekretninaID;
        private ColumnHeader SobaID;
        private ColumnHeader zarada;
        private Button btnDodajNajamSobe;
        private Button btnObrisiNajamSobe;
        private Button btnPrikaziZajednickeProstorije;
    }
}