namespace StanNaDan.Forme.Vlasnici
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
            listaPravnihLica = new ListView();
            pib = new ColumnHeader();
            naziv = new ColumnHeader();
            adresaSedista = new ColumnHeader();
            kontaktOsoba = new ColumnHeader();
            emailKontaktOsobe = new ColumnHeader();
            groupBox1 = new GroupBox();
            btnPrikaziNekretnineFizickogLica = new Button();
            btnIzmeniFizickoLice = new Button();
            btnObrisiFizickoLice = new Button();
            btnDodajFizickoLice = new Button();
            groupBox2 = new GroupBox();
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
            listaFizickihLica.Columns.AddRange(new ColumnHeader[] { jmbg, ime, prezime, mestoStanovanja, email });
            listaFizickihLica.FullRowSelect = true;
            listaFizickihLica.GridLines = true;
            listaFizickihLica.Location = new Point(6, 26);
            listaFizickihLica.Name = "listaFizickihLica";
            listaFizickihLica.Size = new Size(779, 294);
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
            // listaPravnihLica
            // 
            listaPravnihLica.Columns.AddRange(new ColumnHeader[] { pib, naziv, adresaSedista, kontaktOsoba, emailKontaktOsobe });
            listaPravnihLica.FullRowSelect = true;
            listaPravnihLica.GridLines = true;
            listaPravnihLica.Location = new Point(6, 26);
            listaPravnihLica.Name = "listaPravnihLica";
            listaPravnihLica.Size = new Size(773, 294);
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
            // groupBox1
            // 
            groupBox1.Controls.Add(btnPrikaziNekretnineFizickogLica);
            groupBox1.Controls.Add(btnIzmeniFizickoLice);
            groupBox1.Controls.Add(btnObrisiFizickoLice);
            groupBox1.Controls.Add(btnDodajFizickoLice);
            groupBox1.Controls.Add(listaFizickihLica);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1028, 332);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Fizicka lica";
            // 
            // btnPrikaziNekretnineFizickogLica
            // 
            btnPrikaziNekretnineFizickogLica.Location = new Point(791, 186);
            btnPrikaziNekretnineFizickogLica.Name = "btnPrikaziNekretnineFizickogLica";
            btnPrikaziNekretnineFizickogLica.Size = new Size(231, 29);
            btnPrikaziNekretnineFizickogLica.TabIndex = 9;
            btnPrikaziNekretnineFizickogLica.Text = "Prikazi Nekretnine Fizickog Lica";
            btnPrikaziNekretnineFizickogLica.UseVisualStyleBackColor = true;
            // 
            // btnIzmeniFizickoLice
            // 
            btnIzmeniFizickoLice.Location = new Point(791, 116);
            btnIzmeniFizickoLice.Name = "btnIzmeniFizickoLice";
            btnIzmeniFizickoLice.Size = new Size(231, 29);
            btnIzmeniFizickoLice.TabIndex = 8;
            btnIzmeniFizickoLice.Text = "Izmeni Fizicko Lice";
            btnIzmeniFizickoLice.UseVisualStyleBackColor = true;
            // 
            // btnObrisiFizickoLice
            // 
            btnObrisiFizickoLice.Location = new Point(791, 71);
            btnObrisiFizickoLice.Name = "btnObrisiFizickoLice";
            btnObrisiFizickoLice.Size = new Size(231, 29);
            btnObrisiFizickoLice.TabIndex = 7;
            btnObrisiFizickoLice.Text = "Obrisi Fizicko Lice";
            btnObrisiFizickoLice.UseVisualStyleBackColor = true;
            btnObrisiFizickoLice.Click += btnObrisiFizickoLice_Click;
            // 
            // btnDodajFizickoLice
            // 
            btnDodajFizickoLice.Location = new Point(791, 26);
            btnDodajFizickoLice.Name = "btnDodajFizickoLice";
            btnDodajFizickoLice.Size = new Size(231, 29);
            btnDodajFizickoLice.TabIndex = 6;
            btnDodajFizickoLice.Text = "Dodaj Fizicko Lice";
            btnDodajFizickoLice.UseVisualStyleBackColor = true;
            btnDodajFizickoLice.Click += btnDodajFizickoLice_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnPrikaziNekretninePravnogLica);
            groupBox2.Controls.Add(btnIzmeniPravnoLice);
            groupBox2.Controls.Add(btnObrisiPravnoLice);
            groupBox2.Controls.Add(btnDodajPravnoLice);
            groupBox2.Controls.Add(listaPravnihLica);
            groupBox2.Location = new Point(18, 362);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1022, 333);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Pravna lica";
            // 
            // btnPrikaziNekretninePravnogLica
            // 
            btnPrikaziNekretninePravnogLica.Location = new Point(785, 186);
            btnPrikaziNekretninePravnogLica.Name = "btnPrikaziNekretninePravnogLica";
            btnPrikaziNekretninePravnogLica.Size = new Size(231, 29);
            btnPrikaziNekretninePravnogLica.TabIndex = 13;
            btnPrikaziNekretninePravnogLica.Text = "Prikazi Nekretnine Pravnog Lica";
            btnPrikaziNekretninePravnogLica.UseVisualStyleBackColor = true;
            // 
            // btnIzmeniPravnoLice
            // 
            btnIzmeniPravnoLice.Location = new Point(785, 116);
            btnIzmeniPravnoLice.Name = "btnIzmeniPravnoLice";
            btnIzmeniPravnoLice.Size = new Size(231, 29);
            btnIzmeniPravnoLice.TabIndex = 12;
            btnIzmeniPravnoLice.Text = "Izmeni Pravno Lice";
            btnIzmeniPravnoLice.UseVisualStyleBackColor = true;
            // 
            // btnObrisiPravnoLice
            // 
            btnObrisiPravnoLice.Location = new Point(785, 71);
            btnObrisiPravnoLice.Name = "btnObrisiPravnoLice";
            btnObrisiPravnoLice.Size = new Size(231, 29);
            btnObrisiPravnoLice.TabIndex = 11;
            btnObrisiPravnoLice.Text = "Obrisi Pravno Lice";
            btnObrisiPravnoLice.UseVisualStyleBackColor = true;
            btnObrisiPravnoLice.Click += btnObrisiPravnoLice_Click;
            // 
            // btnDodajPravnoLice
            // 
            btnDodajPravnoLice.Location = new Point(785, 26);
            btnDodajPravnoLice.Name = "btnDodajPravnoLice";
            btnDodajPravnoLice.Size = new Size(231, 29);
            btnDodajPravnoLice.TabIndex = 10;
            btnDodajPravnoLice.Text = "Dodaj Pravno Lice";
            btnDodajPravnoLice.UseVisualStyleBackColor = true;
            btnDodajPravnoLice.Click += btnDodajPravnoLice_Click;
            // 
            // PregledSvihVlasnika
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 726);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
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
    }
}