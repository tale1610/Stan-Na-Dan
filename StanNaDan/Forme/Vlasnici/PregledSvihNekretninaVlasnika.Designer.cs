namespace StanNaDan.Forme.Vlasnici
{
    partial class PregledSvihNekretninaVlasnika
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
            btnIzmeniNekretninu = new Button();
            btnObrisiNekretninu = new Button();
            SuspendLayout();
            // 
            // listaNekretnina
            // 
            listaNekretnina.Columns.AddRange(new ColumnHeader[] { ID, Tip, Adresa, Kvadratura, BrSpavacih, brKupatila, brTerasa });
            listaNekretnina.FullRowSelect = true;
            listaNekretnina.GridLines = true;
            listaNekretnina.Location = new Point(12, 12);
            listaNekretnina.Name = "listaNekretnina";
            listaNekretnina.Size = new Size(804, 358);
            listaNekretnina.TabIndex = 7;
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
            btnDodajNekretninu.Location = new Point(831, 12);
            btnDodajNekretninu.Name = "btnDodajNekretninu";
            btnDodajNekretninu.Size = new Size(201, 29);
            btnDodajNekretninu.TabIndex = 8;
            btnDodajNekretninu.Text = "Dodaj Novu Nekretninu";
            btnDodajNekretninu.UseVisualStyleBackColor = true;
            btnDodajNekretninu.Click += btnDodajNekretninu_Click;
            // 
            // btnIzmeniNekretninu
            // 
            btnIzmeniNekretninu.Location = new Point(831, 63);
            btnIzmeniNekretninu.Name = "btnIzmeniNekretninu";
            btnIzmeniNekretninu.Size = new Size(201, 29);
            btnIzmeniNekretninu.TabIndex = 9;
            btnIzmeniNekretninu.Text = "Izmeni Nekretninu";
            btnIzmeniNekretninu.UseVisualStyleBackColor = true;
            // 
            // btnObrisiNekretninu
            // 
            btnObrisiNekretninu.Location = new Point(831, 117);
            btnObrisiNekretninu.Name = "btnObrisiNekretninu";
            btnObrisiNekretninu.Size = new Size(201, 29);
            btnObrisiNekretninu.TabIndex = 10;
            btnObrisiNekretninu.Text = "Obrisi Nekretninu";
            btnObrisiNekretninu.UseVisualStyleBackColor = true;
            // 
            // PregledSvihNekretninaVlasnika
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 391);
            Controls.Add(btnObrisiNekretninu);
            Controls.Add(btnIzmeniNekretninu);
            Controls.Add(btnDodajNekretninu);
            Controls.Add(listaNekretnina);
            Name = "PregledSvihNekretninaVlasnika";
            Text = "PrikaziSveNekretnineVlasnika";
            Load += PrikaziSveNekretnineVlasnika_Load;
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
        private Button btnIzmeniNekretninu;
        private Button btnObrisiNekretninu;
    }
}