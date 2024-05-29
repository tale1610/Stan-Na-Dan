namespace StanNaDan.Forme.Soba
{
    partial class PregledSvihSoba
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
            listaSoba = new ListView();
            IdNekretnine = new ColumnHeader();
            IdSobe = new ColumnHeader();
            tbDodajSobu = new Button();
            btnIzmeniSobu = new Button();
            btnObrisiSobu = new Button();
            btnZajednickeProstorije = new Button();
            SuspendLayout();
            // 
            // listaSoba
            // 
            listaSoba.Columns.AddRange(new ColumnHeader[] { IdNekretnine, IdSobe });
            listaSoba.FullRowSelect = true;
            listaSoba.GridLines = true;
            listaSoba.Location = new Point(12, 12);
            listaSoba.Name = "listaSoba";
            listaSoba.Size = new Size(264, 411);
            listaSoba.TabIndex = 1;
            listaSoba.UseCompatibleStateImageBehavior = false;
            listaSoba.View = View.Details;
            // 
            // IdNekretnine
            // 
            IdNekretnine.Text = "Id Nekretnine";
            IdNekretnine.Width = 110;
            // 
            // IdSobe
            // 
            IdSobe.Text = "Id Sobe";
            IdSobe.Width = 100;
            // 
            // tbDodajSobu
            // 
            tbDodajSobu.Location = new Point(282, 12);
            tbDodajSobu.Name = "tbDodajSobu";
            tbDodajSobu.Size = new Size(188, 29);
            tbDodajSobu.TabIndex = 2;
            tbDodajSobu.Text = "Dodaj Sobu";
            tbDodajSobu.UseVisualStyleBackColor = true;
            // 
            // btnIzmeniSobu
            // 
            btnIzmeniSobu.Location = new Point(282, 100);
            btnIzmeniSobu.Name = "btnIzmeniSobu";
            btnIzmeniSobu.Size = new Size(188, 29);
            btnIzmeniSobu.TabIndex = 3;
            btnIzmeniSobu.Text = "Izmeni Sobu";
            btnIzmeniSobu.UseVisualStyleBackColor = true;
            // 
            // btnObrisiSobu
            // 
            btnObrisiSobu.Location = new Point(282, 56);
            btnObrisiSobu.Name = "btnObrisiSobu";
            btnObrisiSobu.Size = new Size(188, 29);
            btnObrisiSobu.TabIndex = 4;
            btnObrisiSobu.Text = "Obrisi Sobu";
            btnObrisiSobu.UseVisualStyleBackColor = true;
            // 
            // btnZajednickeProstorije
            // 
            btnZajednickeProstorije.Location = new Point(282, 151);
            btnZajednickeProstorije.Name = "btnZajednickeProstorije";
            btnZajednickeProstorije.Size = new Size(188, 54);
            btnZajednickeProstorije.TabIndex = 5;
            btnZajednickeProstorije.Text = "Prikazi zajednicke prostorije";
            btnZajednickeProstorije.UseVisualStyleBackColor = true;
            btnZajednickeProstorije.Click += btnZajednickeProstorije_Click;
            // 
            // PregledSvihSoba
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 450);
            Controls.Add(btnZajednickeProstorije);
            Controls.Add(btnObrisiSobu);
            Controls.Add(btnIzmeniSobu);
            Controls.Add(tbDodajSobu);
            Controls.Add(listaSoba);
            Name = "PregledSvihSoba";
            Text = "PregledSvihSoba";
            Load += PregledSvihSoba_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listaSoba;
        private ColumnHeader IdNekretnine;
        private ColumnHeader IdSobe;
        private Button tbDodajSobu;
        private Button btnIzmeniSobu;
        private Button btnObrisiSobu;
        private Button btnZajednickeProstorije;
    }
}