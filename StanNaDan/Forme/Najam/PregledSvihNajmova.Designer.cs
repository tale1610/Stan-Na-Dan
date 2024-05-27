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
            listaNekretnina = new ListView();
            ID = new ColumnHeader();
            DatumPocetka = new ColumnHeader();
            DatumZavrsetka = new ColumnHeader();
            BrojDana = new ColumnHeader();
            CenaPoDanu = new ColumnHeader();
            CenaSaPopustom = new ColumnHeader();
            ZaradaOdDodatnihUsluga = new ColumnHeader();
            UkupnaCena = new ColumnHeader();
            ProvizijeAgenta = new ColumnHeader();
            btnDodajNoviNajam = new Button();
            btnObrisiNajam = new Button();
            btnIzmeniNajam = new Button();
            SuspendLayout();
            // 
            // listaNekretnina
            // 
            listaNekretnina.Columns.AddRange(new ColumnHeader[] { ID, DatumPocetka, DatumZavrsetka, BrojDana, CenaPoDanu, CenaSaPopustom, ZaradaOdDodatnihUsluga, UkupnaCena, ProvizijeAgenta });
            listaNekretnina.FullRowSelect = true;
            listaNekretnina.GridLines = true;
            listaNekretnina.Location = new Point(12, 12);
            listaNekretnina.Name = "listaNekretnina";
            listaNekretnina.Size = new Size(1188, 408);
            listaNekretnina.TabIndex = 6;
            listaNekretnina.UseCompatibleStateImageBehavior = false;
            listaNekretnina.View = View.Details;
            // 
            // ID
            // 
            ID.Text = "ID";
            ID.Width = 50;
            // 
            // DatumPocetka
            // 
            DatumPocetka.Text = "Datum Pocetka";
            DatumPocetka.Width = 150;
            // 
            // DatumZavrsetka
            // 
            DatumZavrsetka.Text = "DatumZavrsetka";
            DatumZavrsetka.Width = 150;
            // 
            // BrojDana
            // 
            BrojDana.Text = "Broj Dana";
            BrojDana.Width = 150;
            // 
            // CenaPoDanu
            // 
            CenaPoDanu.Text = "Cena Po Danu";
            CenaPoDanu.Width = 110;
            // 
            // CenaSaPopustom
            // 
            CenaSaPopustom.Text = "Cena Sa Popustom";
            CenaSaPopustom.Width = 150;
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
            // ProvizijeAgenta
            // 
            ProvizijeAgenta.Text = "Provizije Agenta";
            ProvizijeAgenta.Width = 120;
            // 
            // btnDodajNoviNajam
            // 
            btnDodajNoviNajam.Location = new Point(1256, 28);
            btnDodajNoviNajam.Name = "btnDodajNoviNajam";
            btnDodajNoviNajam.Size = new Size(163, 29);
            btnDodajNoviNajam.TabIndex = 7;
            btnDodajNoviNajam.Text = "Dodaj Novi Najam";
            btnDodajNoviNajam.UseVisualStyleBackColor = true;
            // 
            // btnObrisiNajam
            // 
            btnObrisiNajam.Location = new Point(1270, 95);
            btnObrisiNajam.Name = "btnObrisiNajam";
            btnObrisiNajam.Size = new Size(149, 30);
            btnObrisiNajam.TabIndex = 8;
            btnObrisiNajam.Text = "Obrisi Najam";
            btnObrisiNajam.UseVisualStyleBackColor = true;
            // 
            // btnIzmeniNajam
            // 
            btnIzmeniNajam.Location = new Point(1273, 154);
            btnIzmeniNajam.Name = "btnIzmeniNajam";
            btnIzmeniNajam.Size = new Size(146, 29);
            btnIzmeniNajam.TabIndex = 9;
            btnIzmeniNajam.Text = "Izmeni Najam";
            btnIzmeniNajam.UseVisualStyleBackColor = true;
            // 
            // PregledSvihNajmova
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1445, 450);
            Controls.Add(btnIzmeniNajam);
            Controls.Add(btnObrisiNajam);
            Controls.Add(btnDodajNoviNajam);
            Controls.Add(listaNekretnina);
            Name = "PregledSvihNajmova";
            Text = "PregledSvihNajmova";
            ResumeLayout(false);
        }

        #endregion

        private ListView listaNekretnina;
        private ColumnHeader ID;
        private ColumnHeader DatumPocetka;
        private ColumnHeader DatumZavrsetka;
        private ColumnHeader BrojDana;
        private ColumnHeader CenaPoDanu;
        private ColumnHeader CenaSaPopustom;
        private ColumnHeader ZaradaOdDodatnihUsluga;
        private ColumnHeader UkupnaCena;
        private ColumnHeader ProvizijeAgenta;
        private Button btnDodajNoviNajam;
        private Button btnObrisiNajam;
        private Button btnIzmeniNajam;
    }
}