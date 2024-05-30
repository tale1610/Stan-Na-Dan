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
            btnUpravljanje = new Button();
            btnZajednickeProstorije = new Button();
            SuspendLayout();
            // 
            // listaSoba
            // 
            listaSoba.Columns.AddRange(new ColumnHeader[] { IdNekretnine, IdSobe });
            listaSoba.FullRowSelect = true;
            listaSoba.GridLines = true;
            listaSoba.Location = new Point(10, 9);
            listaSoba.Margin = new Padding(3, 2, 3, 2);
            listaSoba.Name = "listaSoba";
            listaSoba.Size = new Size(214, 309);
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
            // btnUpravljanje
            // 
            btnUpravljanje.Location = new Point(245, 11);
            btnUpravljanje.Margin = new Padding(3, 2, 3, 2);
            btnUpravljanje.Name = "btnUpravljanje";
            btnUpravljanje.Size = new Size(164, 41);
            btnUpravljanje.TabIndex = 2;
            btnUpravljanje.Text = "Upravljanje nekretninama i sobama";
            btnUpravljanje.UseVisualStyleBackColor = true;
            btnUpravljanje.Click += btnUpravljanje_Click;
            // 
            // btnZajednickeProstorije
            // 
            btnZajednickeProstorije.Location = new Point(245, 76);
            btnZajednickeProstorije.Margin = new Padding(3, 2, 3, 2);
            btnZajednickeProstorije.Name = "btnZajednickeProstorije";
            btnZajednickeProstorije.Size = new Size(164, 41);
            btnZajednickeProstorije.TabIndex = 5;
            btnZajednickeProstorije.Text = "Prikazi zajednicke prostorije";
            btnZajednickeProstorije.UseVisualStyleBackColor = true;
            btnZajednickeProstorije.Click += btnZajednickeProstorije_Click;
            // 
            // PregledSvihSoba
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(421, 327);
            Controls.Add(btnZajednickeProstorije);
            Controls.Add(btnUpravljanje);
            Controls.Add(listaSoba);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PregledSvihSoba";
            Text = "PregledSvihSoba";
            Load += PregledSvihSoba_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listaSoba;
        private ColumnHeader IdNekretnine;
        private ColumnHeader IdSobe;
        private Button btnUpravljanje;
        private Button btnZajednickeProstorije;
    }
}