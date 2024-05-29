namespace StanNaDan.Forme.Najam
{
    partial class PregledSvihNajmova
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
            DatumPocetka = new ColumnHeader();
            DatumZavrsetka = new ColumnHeader();
            BrojDana = new ColumnHeader();
            CenaPoDanu = new ColumnHeader();
            CenaSaPopustom = new ColumnHeader();
            ZaradaOdDodatnihUsluga = new ColumnHeader();
            UkupnaCena = new ColumnHeader();
            ProvizijaAgencije = new ColumnHeader();
            Agent = new ColumnHeader();
            Spoljni = new ColumnHeader();
            btnDodajNoviNajam = new Button();
            btnObrisiNajam = new Button();
            btnIzmeniNajam = new Button();
            SuspendLayout();
            // 
            // listaNajmova
            // 
            listaNajmova.Columns.AddRange(new ColumnHeader[] { ID, DatumPocetka, DatumZavrsetka, BrojDana, CenaPoDanu, CenaSaPopustom, ZaradaOdDodatnihUsluga, UkupnaCena, ProvizijaAgencije, Agent, Spoljni });
            listaNajmova.FullRowSelect = true;
            listaNajmova.GridLines = true;
            listaNajmova.Location = new Point(10, 9);
            listaNajmova.Margin = new Padding(3, 2, 3, 2);
            listaNajmova.Name = "listaNajmova";
            listaNajmova.Size = new Size(1043, 307);
            listaNajmova.TabIndex = 6;
            listaNajmova.UseCompatibleStateImageBehavior = false;
            listaNajmova.View = View.Details;
            // 
            // ID
            // 
            ID.Text = "ID";
            ID.Width = 50;
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
            // ZaradaOdDodatnihUsluga
            // 
            ZaradaOdDodatnihUsluga.Text = "Zarada Od Dodatnih Usluga";
            ZaradaOdDodatnihUsluga.Width = 200;
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
            // btnDodajNoviNajam
            // 
            btnDodajNoviNajam.Location = new Point(1058, 9);
            btnDodajNoviNajam.Margin = new Padding(3, 2, 3, 2);
            btnDodajNoviNajam.Name = "btnDodajNoviNajam";
            btnDodajNoviNajam.Size = new Size(199, 22);
            btnDodajNoviNajam.TabIndex = 7;
            btnDodajNoviNajam.Text = "Dodaj Novi Najam";
            btnDodajNoviNajam.UseVisualStyleBackColor = true;
            btnDodajNoviNajam.Click += btnDodajNoviNajam_Click;
            // 
            // btnObrisiNajam
            // 
            btnObrisiNajam.Location = new Point(1058, 42);
            btnObrisiNajam.Margin = new Padding(3, 2, 3, 2);
            btnObrisiNajam.Name = "btnObrisiNajam";
            btnObrisiNajam.Size = new Size(199, 22);
            btnObrisiNajam.TabIndex = 8;
            btnObrisiNajam.Text = "Obrisi Najam";
            btnObrisiNajam.UseVisualStyleBackColor = true;
            btnObrisiNajam.Click += btnObrisiNajam_Click;
            // 
            // btnIzmeniNajam
            // 
            btnIzmeniNajam.Location = new Point(1058, 76);
            btnIzmeniNajam.Margin = new Padding(3, 2, 3, 2);
            btnIzmeniNajam.Name = "btnIzmeniNajam";
            btnIzmeniNajam.Size = new Size(199, 22);
            btnIzmeniNajam.TabIndex = 9;
            btnIzmeniNajam.Text = "Izmeni Najam";
            btnIzmeniNajam.UseVisualStyleBackColor = true;
            btnIzmeniNajam.Click += btnIzmeniNajam_Click;
            // 
            // PregledSvihNajmova
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 338);
            Controls.Add(btnIzmeniNajam);
            Controls.Add(btnObrisiNajam);
            Controls.Add(btnDodajNoviNajam);
            Controls.Add(listaNajmova);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PregledSvihNajmova";
            Text = "PregledSvihNajmova";
            Load += PregledSvihNajmova_Load;
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
        private ColumnHeader ZaradaOdDodatnihUsluga;
        private ColumnHeader UkupnaCena;
        private ColumnHeader ProvizijaAgencije;
        private Button btnDodajNoviNajam;
        private Button btnObrisiNajam;
        private Button btnIzmeniNajam;
        private ColumnHeader Agent;
        private ColumnHeader Spoljni;
    }
}