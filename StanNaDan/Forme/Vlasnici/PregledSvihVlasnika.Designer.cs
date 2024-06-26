﻿namespace StanNaDan.Forme.Vlasnici
{
    partial class PregledSvihVlasnika
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
            listaFizickihLica = new ListView();
            jmbg = new ColumnHeader();
            ime = new ColumnHeader();
            prezime = new ColumnHeader();
            mestoStanovanja = new ColumnHeader();
            email = new ColumnHeader();
            idVlasnika = new ColumnHeader();
            listaPravnihLica = new ListView();
            pib = new ColumnHeader();
            naziv = new ColumnHeader();
            adresaSedista = new ColumnHeader();
            kontaktOsoba = new ColumnHeader();
            emailKontaktOsobe = new ColumnHeader();
            idVl = new ColumnHeader();
            groupBox1 = new GroupBox();
            btnIzaberiFizickoLice = new Button();
            btnPrikaziBrojeveTelefona = new Button();
            btnPrikaziNekretnineFizickogLica = new Button();
            btnIzmeniFizickoLice = new Button();
            btnObrisiFizickoLice = new Button();
            btnDodajFizickoLice = new Button();
            groupBox2 = new GroupBox();
            btnIzaberiPravnoLice = new Button();
            btnPrikaziTelefoneKontaktOsoba = new Button();
            btnPrikaziNekretninePravnogLica = new Button();
            btnIzmeniPravnoLice = new Button();
            btnObrisiPravnoLice = new Button();
            btnDodajPravnoLice = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // listaFizickihLica
            // 
            listaFizickihLica.Columns.AddRange(new ColumnHeader[] { jmbg, ime, prezime, mestoStanovanja, email, idVlasnika });
            listaFizickihLica.FullRowSelect = true;
            listaFizickihLica.GridLines = true;
            listaFizickihLica.Location = new Point(5, 20);
            listaFizickihLica.Margin = new Padding(3, 2, 3, 2);
            listaFizickihLica.Name = "listaFizickihLica";
            listaFizickihLica.Size = new Size(682, 222);
            listaFizickihLica.TabIndex = 5;
            listaFizickihLica.UseCompatibleStateImageBehavior = false;
            listaFizickihLica.View = View.Details;
            // 
            // jmbg
            // 
            jmbg.Text = "JMBG";
            jmbg.Width = 150;
            // 
            // ime
            // 
            ime.Text = "Ime";
            ime.Width = 120;
            // 
            // prezime
            // 
            prezime.Text = "Prezime";
            prezime.Width = 150;
            // 
            // mestoStanovanja
            // 
            mestoStanovanja.Text = "Mesto Stanovanja";
            mestoStanovanja.Width = 150;
            // 
            // email
            // 
            email.Text = "Email";
            email.Width = 200;
            // 
            // idVlasnika
            // 
            idVlasnika.Text = "ID Vlasnika";
            idVlasnika.Width = 80;
            // 
            // listaPravnihLica
            // 
            listaPravnihLica.Columns.AddRange(new ColumnHeader[] { pib, naziv, adresaSedista, kontaktOsoba, emailKontaktOsobe, idVl });
            listaPravnihLica.FullRowSelect = true;
            listaPravnihLica.GridLines = true;
            listaPravnihLica.Location = new Point(5, 20);
            listaPravnihLica.Margin = new Padding(3, 2, 3, 2);
            listaPravnihLica.Name = "listaPravnihLica";
            listaPravnihLica.Size = new Size(677, 222);
            listaPravnihLica.TabIndex = 6;
            listaPravnihLica.UseCompatibleStateImageBehavior = false;
            listaPravnihLica.View = View.Details;
            // 
            // pib
            // 
            pib.Text = "PIB";
            pib.Width = 100;
            // 
            // naziv
            // 
            naziv.Text = "Naziv";
            naziv.Width = 100;
            // 
            // adresaSedista
            // 
            adresaSedista.Text = "Adresa Sedista";
            adresaSedista.Width = 250;
            // 
            // kontaktOsoba
            // 
            kontaktOsoba.Text = "Kontakt Osoba";
            kontaktOsoba.Width = 120;
            // 
            // emailKontaktOsobe
            // 
            emailKontaktOsobe.Text = "Email";
            emailKontaktOsobe.Width = 200;
            // 
            // idVl
            // 
            idVl.Text = "ID Vlasnika";
            idVl.Width = 80;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnIzaberiFizickoLice);
            groupBox1.Controls.Add(btnPrikaziBrojeveTelefona);
            groupBox1.Controls.Add(btnPrikaziNekretnineFizickogLica);
            groupBox1.Controls.Add(btnIzmeniFizickoLice);
            groupBox1.Controls.Add(btnObrisiFizickoLice);
            groupBox1.Controls.Add(btnDodajFizickoLice);
            groupBox1.Controls.Add(listaFizickihLica);
            groupBox1.Location = new Point(10, 9);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(900, 249);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Fizicka lica";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // btnIzaberiFizickoLice
            // 
            btnIzaberiFizickoLice.Location = new Point(692, 204);
            btnIzaberiFizickoLice.Name = "btnIzaberiFizickoLice";
            btnIzaberiFizickoLice.Size = new Size(202, 23);
            btnIzaberiFizickoLice.TabIndex = 11;
            btnIzaberiFizickoLice.Text = "Izaberi novog vlasnika nekretnine";
            btnIzaberiFizickoLice.UseVisualStyleBackColor = true;
            btnIzaberiFizickoLice.Click += btnIzaberiFizickoLice_Click;
            // 
            // btnPrikaziBrojeveTelefona
            // 
            btnPrikaziBrojeveTelefona.Location = new Point(692, 159);
            btnPrikaziBrojeveTelefona.Margin = new Padding(3, 2, 3, 2);
            btnPrikaziBrojeveTelefona.Name = "btnPrikaziBrojeveTelefona";
            btnPrikaziBrojeveTelefona.Size = new Size(202, 40);
            btnPrikaziBrojeveTelefona.TabIndex = 10;
            btnPrikaziBrojeveTelefona.Text = "Prikazi Brojeve Telefona Fizickog Lica";
            btnPrikaziBrojeveTelefona.UseVisualStyleBackColor = true;
            btnPrikaziBrojeveTelefona.Click += btnPrikaziBrojeveTelefona_Click;
            // 
            // btnPrikaziNekretnineFizickogLica
            // 
            btnPrikaziNekretnineFizickogLica.Location = new Point(692, 123);
            btnPrikaziNekretnineFizickogLica.Margin = new Padding(3, 2, 3, 2);
            btnPrikaziNekretnineFizickogLica.Name = "btnPrikaziNekretnineFizickogLica";
            btnPrikaziNekretnineFizickogLica.Size = new Size(202, 22);
            btnPrikaziNekretnineFizickogLica.TabIndex = 9;
            btnPrikaziNekretnineFizickogLica.Text = "Prikazi Nekretnine Fizickog Lica";
            btnPrikaziNekretnineFizickogLica.UseVisualStyleBackColor = true;
            btnPrikaziNekretnineFizickogLica.Click += btnPrikaziNekretnineFizickogLica_Click;
            // 
            // btnIzmeniFizickoLice
            // 
            btnIzmeniFizickoLice.Location = new Point(692, 55);
            btnIzmeniFizickoLice.Margin = new Padding(3, 2, 3, 2);
            btnIzmeniFizickoLice.Name = "btnIzmeniFizickoLice";
            btnIzmeniFizickoLice.Size = new Size(202, 22);
            btnIzmeniFizickoLice.TabIndex = 8;
            btnIzmeniFizickoLice.Text = "Izmeni Fizicko Lice";
            btnIzmeniFizickoLice.UseVisualStyleBackColor = true;
            btnIzmeniFizickoLice.Click += btnIzmeniFizickoLice_Click;
            // 
            // btnObrisiFizickoLice
            // 
            btnObrisiFizickoLice.Location = new Point(692, 89);
            btnObrisiFizickoLice.Margin = new Padding(3, 2, 3, 2);
            btnObrisiFizickoLice.Name = "btnObrisiFizickoLice";
            btnObrisiFizickoLice.Size = new Size(202, 22);
            btnObrisiFizickoLice.TabIndex = 7;
            btnObrisiFizickoLice.Text = "Obrisi Fizicko Lice";
            btnObrisiFizickoLice.UseVisualStyleBackColor = true;
            btnObrisiFizickoLice.Click += btnObrisiFizickoLice_Click;
            // 
            // btnDodajFizickoLice
            // 
            btnDodajFizickoLice.Location = new Point(692, 20);
            btnDodajFizickoLice.Margin = new Padding(3, 2, 3, 2);
            btnDodajFizickoLice.Name = "btnDodajFizickoLice";
            btnDodajFizickoLice.Size = new Size(202, 22);
            btnDodajFizickoLice.TabIndex = 6;
            btnDodajFizickoLice.Text = "Dodaj Fizicko Lice";
            btnDodajFizickoLice.UseVisualStyleBackColor = true;
            btnDodajFizickoLice.Click += btnDodajFizickoLice_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnIzaberiPravnoLice);
            groupBox2.Controls.Add(btnPrikaziTelefoneKontaktOsoba);
            groupBox2.Controls.Add(btnPrikaziNekretninePravnogLica);
            groupBox2.Controls.Add(btnIzmeniPravnoLice);
            groupBox2.Controls.Add(btnObrisiPravnoLice);
            groupBox2.Controls.Add(btnDodajPravnoLice);
            groupBox2.Controls.Add(listaPravnihLica);
            groupBox2.Location = new Point(16, 272);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(894, 250);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Pravna lica";
            // 
            // btnIzaberiPravnoLice
            // 
            btnIzaberiPravnoLice.Location = new Point(686, 204);
            btnIzaberiPravnoLice.Name = "btnIzaberiPravnoLice";
            btnIzaberiPravnoLice.Size = new Size(202, 23);
            btnIzaberiPravnoLice.TabIndex = 15;
            btnIzaberiPravnoLice.Text = "Izaberi novog vlasnika nekretnine";
            btnIzaberiPravnoLice.UseVisualStyleBackColor = true;
            btnIzaberiPravnoLice.Click += btnIzaberiPravnoLice_Click;
            // 
            // btnPrikaziTelefoneKontaktOsoba
            // 
            btnPrikaziTelefoneKontaktOsoba.Location = new Point(687, 160);
            btnPrikaziTelefoneKontaktOsoba.Margin = new Padding(3, 2, 3, 2);
            btnPrikaziTelefoneKontaktOsoba.Name = "btnPrikaziTelefoneKontaktOsoba";
            btnPrikaziTelefoneKontaktOsoba.Size = new Size(202, 39);
            btnPrikaziTelefoneKontaktOsoba.TabIndex = 14;
            btnPrikaziTelefoneKontaktOsoba.Text = "Prikazi Telefone Kontakt Osobe Pravnog Lica";
            btnPrikaziTelefoneKontaktOsoba.UseVisualStyleBackColor = true;
            btnPrikaziTelefoneKontaktOsoba.Click += btnPrikaziTelefoneKontaktOsoba_Click;
            // 
            // btnPrikaziNekretninePravnogLica
            // 
            btnPrikaziNekretninePravnogLica.Location = new Point(687, 123);
            btnPrikaziNekretninePravnogLica.Margin = new Padding(3, 2, 3, 2);
            btnPrikaziNekretninePravnogLica.Name = "btnPrikaziNekretninePravnogLica";
            btnPrikaziNekretninePravnogLica.Size = new Size(202, 22);
            btnPrikaziNekretninePravnogLica.TabIndex = 13;
            btnPrikaziNekretninePravnogLica.Text = "Prikazi Nekretnine Pravnog Lica";
            btnPrikaziNekretninePravnogLica.UseVisualStyleBackColor = true;
            btnPrikaziNekretninePravnogLica.Click += btnPrikaziNekretninePravnogLica_Click;
            // 
            // btnIzmeniPravnoLice
            // 
            btnIzmeniPravnoLice.Location = new Point(687, 87);
            btnIzmeniPravnoLice.Margin = new Padding(3, 2, 3, 2);
            btnIzmeniPravnoLice.Name = "btnIzmeniPravnoLice";
            btnIzmeniPravnoLice.Size = new Size(202, 22);
            btnIzmeniPravnoLice.TabIndex = 12;
            btnIzmeniPravnoLice.Text = "Izmeni Pravno Lice";
            btnIzmeniPravnoLice.UseVisualStyleBackColor = true;
            btnIzmeniPravnoLice.Click += btnIzmeniPravnoLice_Click;
            // 
            // btnObrisiPravnoLice
            // 
            btnObrisiPravnoLice.Location = new Point(687, 53);
            btnObrisiPravnoLice.Margin = new Padding(3, 2, 3, 2);
            btnObrisiPravnoLice.Name = "btnObrisiPravnoLice";
            btnObrisiPravnoLice.Size = new Size(202, 22);
            btnObrisiPravnoLice.TabIndex = 11;
            btnObrisiPravnoLice.Text = "Obrisi Pravno Lice";
            btnObrisiPravnoLice.UseVisualStyleBackColor = true;
            btnObrisiPravnoLice.Click += btnObrisiPravnoLice_Click;
            // 
            // btnDodajPravnoLice
            // 
            btnDodajPravnoLice.Location = new Point(687, 20);
            btnDodajPravnoLice.Margin = new Padding(3, 2, 3, 2);
            btnDodajPravnoLice.Name = "btnDodajPravnoLice";
            btnDodajPravnoLice.Size = new Size(202, 22);
            btnDodajPravnoLice.TabIndex = 10;
            btnDodajPravnoLice.Text = "Dodaj Pravno Lice";
            btnDodajPravnoLice.UseVisualStyleBackColor = true;
            btnDodajPravnoLice.Click += btnDodajPravnoLice_Click;
            // 
            // PregledSvihVlasnika
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(919, 544);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PregledSvihVlasnika";
            Text = "PregledSvihVlasnika";
            Load += PregledSvihVlasnika_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListView listaFizickihLica;
        private ColumnHeader jmbg;
        private ColumnHeader ime;
        private ColumnHeader prezime;
        private ColumnHeader mestoStanovanja;
        private ColumnHeader email;
        private ListView listaPravnihLica;
        private ColumnHeader pib;
        private ColumnHeader naziv;
        private ColumnHeader adresaSedista;
        private ColumnHeader kontaktOsoba;
        private ColumnHeader emailKontaktOsobe;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnPrikaziNekretnineFizickogLica;
        private Button btnIzmeniFizickoLice;
        private Button btnObrisiFizickoLice;
        private Button btnDodajFizickoLice;
        private Button btnPrikaziNekretninePravnogLica;
        private Button btnIzmeniPravnoLice;
        private Button btnObrisiPravnoLice;
        private Button btnDodajPravnoLice;
        private ColumnHeader idVlasnika;
        private ColumnHeader idVl;
        private Button btnPrikaziBrojeveTelefona;
        private Button btnPrikaziTelefoneKontaktOsoba;
        private Button btnIzaberiFizickoLice;
        private Button btnIzaberiPravnoLice;
    }
}