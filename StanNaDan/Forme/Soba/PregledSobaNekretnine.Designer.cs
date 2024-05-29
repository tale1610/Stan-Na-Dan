namespace StanNaDan.Forme.Soba
{
    partial class PregledSobaNekretnine
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
            btnObrisiSobu = new Button();
            btnIzmeniSobu = new Button();
            tbDodajSobu = new Button();
            listaSoba = new ListView();
            IdNekretnine = new ColumnHeader();
            IdSobe = new ColumnHeader();
            SuspendLayout();
            // 
            // btnObrisiSobu
            // 
            btnObrisiSobu.Location = new Point(349, 56);
            btnObrisiSobu.Name = "btnObrisiSobu";
            btnObrisiSobu.Size = new Size(121, 29);
            btnObrisiSobu.TabIndex = 8;
            btnObrisiSobu.Text = "Obrisi Sobu";
            btnObrisiSobu.UseVisualStyleBackColor = true;
            btnObrisiSobu.Click += btnObrisiSobu_Click;
            // 
            // btnIzmeniSobu
            // 
            btnIzmeniSobu.Location = new Point(347, 100);
            btnIzmeniSobu.Name = "btnIzmeniSobu";
            btnIzmeniSobu.Size = new Size(123, 29);
            btnIzmeniSobu.TabIndex = 7;
            btnIzmeniSobu.Text = "Izmeni Sobu";
            btnIzmeniSobu.UseVisualStyleBackColor = true;
            // 
            // tbDodajSobu
            // 
            tbDodajSobu.Location = new Point(347, 12);
            tbDodajSobu.Name = "tbDodajSobu";
            tbDodajSobu.Size = new Size(123, 29);
            tbDodajSobu.TabIndex = 6;
            tbDodajSobu.Text = "Dodaj Sobu";
            tbDodajSobu.UseVisualStyleBackColor = true;
            tbDodajSobu.Click += tbDodajSobu_Click;
            // 
            // listaSoba
            // 
            listaSoba.Columns.AddRange(new ColumnHeader[] { IdNekretnine, IdSobe });
            listaSoba.FullRowSelect = true;
            listaSoba.GridLines = true;
            listaSoba.Location = new Point(12, 12);
            listaSoba.Name = "listaSoba";
            listaSoba.Size = new Size(264, 411);
            listaSoba.TabIndex = 5;
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
            // PregledSobaNekretnine
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(498, 450);
            Controls.Add(btnObrisiSobu);
            Controls.Add(btnIzmeniSobu);
            Controls.Add(tbDodajSobu);
            Controls.Add(listaSoba);
            Name = "PregledSobaNekretnine";
            Text = "PregledSobaNekretnine";
            Load += PregledSobaNekretnine_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnObrisiSobu;
        private Button btnIzmeniSobu;
        private Button tbDodajSobu;
        private ListView listaSoba;
        private ColumnHeader IdNekretnine;
        private ColumnHeader IdSobe;
    }
}