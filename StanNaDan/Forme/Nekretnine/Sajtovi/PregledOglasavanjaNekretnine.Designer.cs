namespace StanNaDan.Forme.Nekretnine.Sajtovi
{
    partial class PregledOglasavanjaNekretnine
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
            listaSajtova = new ListView();
            idNekretnin = new ColumnHeader();
            Adresa = new ColumnHeader();
            sajtOglasavanja = new ColumnHeader();
            btnDodajSajt = new Button();
            btnIzmeniSajt = new Button();
            btnObrisiSajt = new Button();
            SuspendLayout();
            // 
            // listaSajtova
            // 
            listaSajtova.Columns.AddRange(new ColumnHeader[] { idNekretnin, Adresa, sajtOglasavanja });
            listaSajtova.FullRowSelect = true;
            listaSajtova.GridLines = true;
            listaSajtova.Location = new Point(10, 9);
            listaSajtova.Margin = new Padding(3, 2, 3, 2);
            listaSajtova.Name = "listaSajtova";
            listaSajtova.Size = new Size(494, 309);
            listaSajtova.TabIndex = 1;
            listaSajtova.UseCompatibleStateImageBehavior = false;
            listaSajtova.View = View.Details;
            // 
            // idNekretnin
            // 
            idNekretnin.Text = "ID Nekretnine";
            idNekretnin.Width = 110;
            // 
            // Adresa
            // 
            Adresa.Text = "Adresa Nekretnine";
            Adresa.Width = 250;
            // 
            // sajtOglasavanja
            // 
            sajtOglasavanja.Text = "Sajt Oglasavanja";
            sajtOglasavanja.Width = 200;
            // 
            // btnDodajSajt
            // 
            btnDodajSajt.Location = new Point(509, 9);
            btnDodajSajt.Margin = new Padding(3, 2, 3, 2);
            btnDodajSajt.Name = "btnDodajSajt";
            btnDodajSajt.Size = new Size(180, 22);
            btnDodajSajt.TabIndex = 2;
            btnDodajSajt.Text = "Dodaj Sajt Oglasavanja";
            btnDodajSajt.UseVisualStyleBackColor = true;
            btnDodajSajt.Click += btnDodajSajt_Click;
            // 
            // btnIzmeniSajt
            // 
            btnIzmeniSajt.Location = new Point(509, 42);
            btnIzmeniSajt.Margin = new Padding(3, 2, 3, 2);
            btnIzmeniSajt.Name = "btnIzmeniSajt";
            btnIzmeniSajt.Size = new Size(180, 22);
            btnIzmeniSajt.TabIndex = 3;
            btnIzmeniSajt.Text = "Izmeni Sajt";
            btnIzmeniSajt.UseVisualStyleBackColor = true;
            btnIzmeniSajt.Click += btnIzmeniSajt_Click;
            // 
            // btnObrisiSajt
            // 
            btnObrisiSajt.Location = new Point(509, 79);
            btnObrisiSajt.Margin = new Padding(3, 2, 3, 2);
            btnObrisiSajt.Name = "btnObrisiSajt";
            btnObrisiSajt.Size = new Size(180, 22);
            btnObrisiSajt.TabIndex = 4;
            btnObrisiSajt.Text = "Obrisi Sajt";
            btnObrisiSajt.UseVisualStyleBackColor = true;
            btnObrisiSajt.Click += btnObrisiSajt_Click;
            // 
            // PregledOglasavanjaNekretnine
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(btnObrisiSajt);
            Controls.Add(btnIzmeniSajt);
            Controls.Add(btnDodajSajt);
            Controls.Add(listaSajtova);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PregledOglasavanjaNekretnine";
            Text = "PregledOglasavanjaNekretnine";
            Load += PregledOglasavanjaNekretnine_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listaSajtova;
        private ColumnHeader idNekretnin;
        private ColumnHeader Adresa;
        private ColumnHeader sajtOglasavanja;
        private Button btnDodajSajt;
        private Button btnIzmeniSajt;
        private Button btnObrisiSajt;
    }
}