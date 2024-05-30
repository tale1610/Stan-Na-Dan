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
            btnZajednickeProstorije = new Button();
            btnIzaberiSobu = new Button();
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
            // btnZajednickeProstorije
            // 
            btnZajednickeProstorije.Location = new Point(282, 96);
            btnZajednickeProstorije.Name = "btnZajednickeProstorije";
            btnZajednickeProstorije.Size = new Size(188, 54);
            btnZajednickeProstorije.TabIndex = 5;
            btnZajednickeProstorije.Text = "Prikazi zajednicke prostorije";
            btnZajednickeProstorije.UseVisualStyleBackColor = true;
            btnZajednickeProstorije.Click += btnZajednickeProstorije_Click;
            // 
            // btnIzaberiSobu
            // 
            btnIzaberiSobu.Location = new Point(282, 167);
            btnIzaberiSobu.Name = "btnIzaberiSobu";
            btnIzaberiSobu.Size = new Size(188, 29);
            btnIzaberiSobu.TabIndex = 6;
            btnIzaberiSobu.Text = "Izaberi Sobu";
            btnIzaberiSobu.UseVisualStyleBackColor = true;
            btnIzaberiSobu.Click += btnIzaberiSobu_Click;
            // 
            // PregledSvihSoba
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 446);
            Controls.Add(btnIzaberiSobu);
            Controls.Add(btnZajednickeProstorije);
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
        private Button btnZajednickeProstorije;
        private Button btnIzaberiSobu;
    }
}