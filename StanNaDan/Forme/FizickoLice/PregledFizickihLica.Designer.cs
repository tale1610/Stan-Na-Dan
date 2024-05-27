namespace StanNaDan.Forme.FizickoLice
{
    partial class PregledFizickihLica
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
            Ime = new ColumnHeader();
            ImeRoditelja = new ColumnHeader();
            Prezime = new ColumnHeader();
            Drzava = new ColumnHeader();
            MestoStanovanja = new ColumnHeader();
            AdresaStanovanja = new ColumnHeader();
            DatumRodjenja = new ColumnHeader();
            Email = new ColumnHeader();
            btnDodajFizickoLice = new Button();
            btnObrisiFizickoLice = new Button();
            btnIzmeniFizickoLice = new Button();
            SuspendLayout();
            // 
            // listaNekretnina
            // 
            listaNekretnina.Columns.AddRange(new ColumnHeader[] { ID, Ime, ImeRoditelja, Prezime, Drzava, MestoStanovanja, AdresaStanovanja, DatumRodjenja, Email });
            listaNekretnina.FullRowSelect = true;
            listaNekretnina.GridLines = true;
            listaNekretnina.Location = new Point(12, 12);
            listaNekretnina.Name = "listaNekretnina";
            listaNekretnina.Size = new Size(956, 408);
            listaNekretnina.TabIndex = 7;
            listaNekretnina.UseCompatibleStateImageBehavior = false;
            listaNekretnina.View = View.Details;
            // 
            // ID
            // 
            ID.Text = "ID";
            ID.Width = 50;
            // 
            // Ime
            // 
            Ime.Text = "Ime";
            Ime.Width = 100;
            // 
            // ImeRoditelja
            // 
            ImeRoditelja.Text = "ImeRoditelja";
            ImeRoditelja.Width = 150;
            // 
            // Prezime
            // 
            Prezime.Text = "Prezime";
            Prezime.Width = 100;
            // 
            // Drzava
            // 
            Drzava.Text = "Drzava";
            Drzava.Width = 80;
            // 
            // MestoStanovanja
            // 
            MestoStanovanja.Text = "MestoStanovanja";
            MestoStanovanja.Width = 150;
            // 
            // AdresaStanovanja
            // 
            AdresaStanovanja.Text = "AdresaStanovanja";
            AdresaStanovanja.Width = 150;
            // 
            // DatumRodjenja
            // 
            DatumRodjenja.Text = "Datum Rodjenja";
            DatumRodjenja.Width = 120;
            // 
            // Email
            // 
            Email.Text = "Email";
            // 
            // btnDodajFizickoLice
            // 
            btnDodajFizickoLice.Location = new Point(1017, 12);
            btnDodajFizickoLice.Name = "btnDodajFizickoLice";
            btnDodajFizickoLice.Size = new Size(153, 29);
            btnDodajFizickoLice.TabIndex = 8;
            btnDodajFizickoLice.Text = "Dodaj Fizicko Lice";
            btnDodajFizickoLice.UseVisualStyleBackColor = true;
            // 
            // btnObrisiFizickoLice
            // 
            btnObrisiFizickoLice.Location = new Point(1017, 68);
            btnObrisiFizickoLice.Name = "btnObrisiFizickoLice";
            btnObrisiFizickoLice.Size = new Size(142, 29);
            btnObrisiFizickoLice.TabIndex = 9;
            btnObrisiFizickoLice.Text = "Obrisi Fizicko Lice";
            btnObrisiFizickoLice.UseVisualStyleBackColor = true;
            // 
            // btnIzmeniFizickoLice
            // 
            btnIzmeniFizickoLice.Location = new Point(1020, 130);
            btnIzmeniFizickoLice.Name = "btnIzmeniFizickoLice";
            btnIzmeniFizickoLice.Size = new Size(150, 29);
            btnIzmeniFizickoLice.TabIndex = 10;
            btnIzmeniFizickoLice.Text = "Izmeni Fizicko Lice";
            btnIzmeniFizickoLice.UseVisualStyleBackColor = true;
            // 
            // PregledFizickihLica
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1246, 450);
            Controls.Add(btnIzmeniFizickoLice);
            Controls.Add(btnObrisiFizickoLice);
            Controls.Add(btnDodajFizickoLice);
            Controls.Add(listaNekretnina);
            Name = "PregledFizickihLica";
            Text = "PregledFizickihLica";
            ResumeLayout(false);
        }

        #endregion

        private ListView listaNekretnina;
        private ColumnHeader ID;
        private ColumnHeader Ime;
        private ColumnHeader ImeRoditelja;
        private ColumnHeader Prezime;
        private ColumnHeader Drzava;
        private ColumnHeader MestoStanovanja;
        private ColumnHeader AdresaStanovanja;
        private ColumnHeader DatumRodjenja;
        private ColumnHeader Email;
        private Button btnDodajFizickoLice;
        private Button btnObrisiFizickoLice;
        private Button btnIzmeniFizickoLice;
    }
}