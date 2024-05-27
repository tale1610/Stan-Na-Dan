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
            listaSajtova.Location = new Point(12, 12);
            listaSajtova.Name = "listaSajtova";
            listaSajtova.Size = new Size(564, 411);
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
            btnDodajSajt.Location = new Point(582, 12);
            btnDodajSajt.Name = "btnDodajSajt";
            btnDodajSajt.Size = new Size(206, 29);
            btnDodajSajt.TabIndex = 2;
            btnDodajSajt.Text = "Dodaj Sajt Oglasavanja";
            btnDodajSajt.UseVisualStyleBackColor = true;
            // 
            // btnIzmeniSajt
            // 
            btnIzmeniSajt.Location = new Point(582, 56);
            btnIzmeniSajt.Name = "btnIzmeniSajt";
            btnIzmeniSajt.Size = new Size(206, 29);
            btnIzmeniSajt.TabIndex = 3;
            btnIzmeniSajt.Text = "Izmeni Sajt";
            btnIzmeniSajt.UseVisualStyleBackColor = true;
            // 
            // btnObrisiSajt
            // 
            btnObrisiSajt.Location = new Point(582, 105);
            btnObrisiSajt.Name = "btnObrisiSajt";
            btnObrisiSajt.Size = new Size(206, 29);
            btnObrisiSajt.TabIndex = 4;
            btnObrisiSajt.Text = "Obrisi Sajt";
            btnObrisiSajt.UseVisualStyleBackColor = true;
            // 
            // PregledOglasavanjaNekretnine
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnObrisiSajt);
            Controls.Add(btnIzmeniSajt);
            Controls.Add(btnDodajSajt);
            Controls.Add(listaSajtova);
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