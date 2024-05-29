namespace StanNaDan.Forme.Nekretnine
{
    partial class PregledSvihNekretnina
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
            Tip = new ColumnHeader();
            Adresa = new ColumnHeader();
            Kvadratura = new ColumnHeader();
            BrSpavacih = new ColumnHeader();
            brKupatila = new ColumnHeader();
            brTerasa = new ColumnHeader();
            btnDodajNekretninu = new Button();
            btnObrisiNekretninu = new Button();
            btnIzmeniNekretninu = new Button();
            btnPrikaziSveNajmove = new Button();
            btnPrikaziParkinge = new Button();
            btnPrikaziDodatnuOpremu = new Button();
            btnPrikaziKrevete = new Button();
            btnPrikaziSajtove = new Button();
            btnPrikaziSveSobe = new Button();
            btnIzaberiNekretninu = new Button();
            SuspendLayout();
            // 
            // listaNekretnina
            // 
            listaNekretnina.Columns.AddRange(new ColumnHeader[] { ID, Tip, Adresa, Kvadratura, BrSpavacih, brKupatila, brTerasa });
            listaNekretnina.FullRowSelect = true;
            listaNekretnina.GridLines = true;
            listaNekretnina.Location = new Point(10, 9);
            listaNekretnina.Margin = new Padding(3, 2, 3, 2);
            listaNekretnina.Name = "listaNekretnina";
            listaNekretnina.Size = new Size(704, 307);
            listaNekretnina.TabIndex = 5;
            listaNekretnina.UseCompatibleStateImageBehavior = false;
            listaNekretnina.View = View.Details;
            // 
            // ID
            // 
            ID.Text = "ID";
            ID.Width = 50;
            // 
            // Tip
            // 
            Tip.Text = "Tip";
            Tip.Width = 100;
            // 
            // Adresa
            // 
            Adresa.Text = "Adresa";
            Adresa.Width = 150;
            // 
            // Kvadratura
            // 
            Kvadratura.Text = "Kvadratura";
            Kvadratura.Width = 150;
            // 
            // BrSpavacih
            // 
            BrSpavacih.Text = "Broj Spavacih Soba";
            BrSpavacih.Width = 150;
            // 
            // brKupatila
            // 
            brKupatila.Text = "Broj Kupatila";
            brKupatila.Width = 100;
            // 
            // brTerasa
            // 
            brTerasa.Text = "Broj Terasa";
            brTerasa.Width = 100;
            // 
            // btnDodajNekretninu
            // 
            btnDodajNekretninu.Location = new Point(729, 9);
            btnDodajNekretninu.Margin = new Padding(3, 2, 3, 2);
            btnDodajNekretninu.Name = "btnDodajNekretninu";
            btnDodajNekretninu.Size = new Size(179, 22);
            btnDodajNekretninu.TabIndex = 6;
            btnDodajNekretninu.Text = "Dodaj Nekretninu";
            btnDodajNekretninu.UseVisualStyleBackColor = true;
            btnDodajNekretninu.Click += btnDodajNekretninu_Click;
            // 
            // btnObrisiNekretninu
            // 
            btnObrisiNekretninu.Location = new Point(729, 81);
            btnObrisiNekretninu.Margin = new Padding(3, 2, 3, 2);
            btnObrisiNekretninu.Name = "btnObrisiNekretninu";
            btnObrisiNekretninu.Size = new Size(179, 22);
            btnObrisiNekretninu.TabIndex = 7;
            btnObrisiNekretninu.Text = "Obrisi Nekretninu";
            btnObrisiNekretninu.UseVisualStyleBackColor = true;
            btnObrisiNekretninu.Click += btnObrisiNekretninu_Click;
            // 
            // btnIzmeniNekretninu
            // 
            btnIzmeniNekretninu.Location = new Point(729, 44);
            btnIzmeniNekretninu.Margin = new Padding(3, 2, 3, 2);
            btnIzmeniNekretninu.Name = "btnIzmeniNekretninu";
            btnIzmeniNekretninu.Size = new Size(179, 22);
            btnIzmeniNekretninu.TabIndex = 8;
            btnIzmeniNekretninu.Text = "Izmeni Nekretninu";
            btnIzmeniNekretninu.UseVisualStyleBackColor = true;
            btnIzmeniNekretninu.Click += btnIzmeniNekretninu_Click;
            // 
            // btnPrikaziSveNajmove
            // 
            btnPrikaziSveNajmove.Location = new Point(729, 135);
            btnPrikaziSveNajmove.Margin = new Padding(3, 2, 3, 2);
            btnPrikaziSveNajmove.Name = "btnPrikaziSveNajmove";
            btnPrikaziSveNajmove.Size = new Size(179, 22);
            btnPrikaziSveNajmove.TabIndex = 9;
            btnPrikaziSveNajmove.Text = "Prikazi Sve Najmove";
            btnPrikaziSveNajmove.UseVisualStyleBackColor = true;
            btnPrikaziSveNajmove.Click += btnPrikaziSveNajmove_Click;
            // 
            // btnPrikaziParkinge
            // 
            btnPrikaziParkinge.Location = new Point(729, 188);
            btnPrikaziParkinge.Margin = new Padding(3, 2, 3, 2);
            btnPrikaziParkinge.Name = "btnPrikaziParkinge";
            btnPrikaziParkinge.Size = new Size(179, 22);
            btnPrikaziParkinge.TabIndex = 10;
            btnPrikaziParkinge.Text = "Prikazi Parking Mesta";
            btnPrikaziParkinge.UseVisualStyleBackColor = true;
            btnPrikaziParkinge.Click += btnPrikaziParkinge_Click;
            // 
            // btnPrikaziDodatnuOpremu
            // 
            btnPrikaziDodatnuOpremu.Location = new Point(729, 214);
            btnPrikaziDodatnuOpremu.Margin = new Padding(3, 2, 3, 2);
            btnPrikaziDodatnuOpremu.Name = "btnPrikaziDodatnuOpremu";
            btnPrikaziDodatnuOpremu.Size = new Size(179, 22);
            btnPrikaziDodatnuOpremu.TabIndex = 11;
            btnPrikaziDodatnuOpremu.Text = "Prikazi Dodatnu Opremu";
            btnPrikaziDodatnuOpremu.UseVisualStyleBackColor = true;
            btnPrikaziDodatnuOpremu.Click += btnPrikaziDodatnuOpremu_Click;
            // 
            // btnPrikaziKrevete
            // 
            btnPrikaziKrevete.Location = new Point(729, 241);
            btnPrikaziKrevete.Margin = new Padding(3, 2, 3, 2);
            btnPrikaziKrevete.Name = "btnPrikaziKrevete";
            btnPrikaziKrevete.Size = new Size(179, 22);
            btnPrikaziKrevete.TabIndex = 12;
            btnPrikaziKrevete.Text = "Prikazi Krevete";
            btnPrikaziKrevete.UseVisualStyleBackColor = true;
            btnPrikaziKrevete.Click += btnPrikaziKrevete_Click;
            // 
            // btnPrikaziSajtove
            // 
            btnPrikaziSajtove.Location = new Point(729, 267);
            btnPrikaziSajtove.Margin = new Padding(3, 2, 3, 2);
            btnPrikaziSajtove.Name = "btnPrikaziSajtove";
            btnPrikaziSajtove.Size = new Size(179, 22);
            btnPrikaziSajtove.TabIndex = 13;
            btnPrikaziSajtove.Text = "Prikazi Sajtove Oglasavanja";
            btnPrikaziSajtove.UseVisualStyleBackColor = true;
            btnPrikaziSajtove.Click += btnPrikaziSajtove_Click;
            // 
            // btnPrikaziSveSobe
            // 
            btnPrikaziSveSobe.Location = new Point(729, 293);
            btnPrikaziSveSobe.Margin = new Padding(3, 2, 3, 2);
            btnPrikaziSveSobe.Name = "btnPrikaziSveSobe";
            btnPrikaziSveSobe.Size = new Size(179, 22);
            btnPrikaziSveSobe.TabIndex = 14;
            btnPrikaziSveSobe.Text = "Prikazi Sobe";
            btnPrikaziSveSobe.UseVisualStyleBackColor = true;
            // 
            // btnIzaberiNekretninu
            // 
            btnIzaberiNekretninu.Location = new Point(262, 323);
            btnIzaberiNekretninu.Margin = new Padding(3, 2, 3, 2);
            btnIzaberiNekretninu.Name = "btnIzaberiNekretninu";
            btnIzaberiNekretninu.Size = new Size(162, 39);
            btnIzaberiNekretninu.TabIndex = 16;
            btnIzaberiNekretninu.Text = "Izaberi Nekretninu";
            btnIzaberiNekretninu.UseVisualStyleBackColor = true;
            btnIzaberiNekretninu.Click += btnIzaberiNekretninu_Click;
            // 
            // PregledSvihNekretnina
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(926, 371);
            Controls.Add(btnIzaberiNekretninu);
            Controls.Add(btnPrikaziSveSobe);
            Controls.Add(btnPrikaziSajtove);
            Controls.Add(btnPrikaziKrevete);
            Controls.Add(btnPrikaziDodatnuOpremu);
            Controls.Add(btnPrikaziParkinge);
            Controls.Add(btnPrikaziSveNajmove);
            Controls.Add(btnIzmeniNekretninu);
            Controls.Add(btnObrisiNekretninu);
            Controls.Add(btnDodajNekretninu);
            Controls.Add(listaNekretnina);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PregledSvihNekretnina";
            Text = "PregledSvihNekretnina";
            Load += PregledSvihNekretnina_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listaNekretnina;
        private ColumnHeader ID;
        private ColumnHeader Tip;
        private ColumnHeader Adresa;
        private ColumnHeader Kvadratura;
        private ColumnHeader BrSpavacih;
        private ColumnHeader brKupatila;
        private ColumnHeader brTerasa;
        private Button btnDodajNekretninu;
        private Button btnObrisiNekretninu;
        private Button btnIzmeniNekretninu;
        private Button btnPrikaziSveNajmove;
        private Button btnPrikaziParkinge;
        private Button btnPrikaziDodatnuOpremu;
        private Button btnPrikaziKrevete;
        private Button btnPrikaziSajtove;
        private Button btnPrikaziSveSobe;
        private Button btnIzaberiNekretninu;
    }
}