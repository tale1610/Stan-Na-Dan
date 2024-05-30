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
            tbDodajSobu = new Button();
            listaSoba = new ListView();
            IdNekretnine = new ColumnHeader();
            IdSobe = new ColumnHeader();
            SuspendLayout();
            // 
            // btnObrisiSobu
            // 
            btnObrisiSobu.Location = new Point(305, 42);
            btnObrisiSobu.Margin = new Padding(3, 2, 3, 2);
            btnObrisiSobu.Name = "btnObrisiSobu";
            btnObrisiSobu.Size = new Size(106, 22);
            btnObrisiSobu.TabIndex = 8;
            btnObrisiSobu.Text = "Obrisi Sobu";
            btnObrisiSobu.UseVisualStyleBackColor = true;
            btnObrisiSobu.Click += btnObrisiSobu_Click;
            // 
            // tbDodajSobu
            // 
            tbDodajSobu.Location = new Point(304, 9);
            tbDodajSobu.Margin = new Padding(3, 2, 3, 2);
            tbDodajSobu.Name = "tbDodajSobu";
            tbDodajSobu.Size = new Size(108, 22);
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
            listaSoba.Location = new Point(10, 9);
            listaSoba.Margin = new Padding(3, 2, 3, 2);
            listaSoba.Name = "listaSoba";
            listaSoba.Size = new Size(232, 309);
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
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(436, 338);
            Controls.Add(btnObrisiSobu);
            Controls.Add(tbDodajSobu);
            Controls.Add(listaSoba);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PregledSobaNekretnine";
            Text = "PregledSobaNekretnine";
            Load += PregledSobaNekretnine_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnObrisiSobu;
        private Button tbDodajSobu;
        private ListView listaSoba;
        private ColumnHeader IdNekretnine;
        private ColumnHeader IdSobe;
    }
}