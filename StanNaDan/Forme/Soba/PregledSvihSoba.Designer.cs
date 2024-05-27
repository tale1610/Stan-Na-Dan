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
            listaPoslovnica = new ListView();
            ID = new ColumnHeader();
            IdNekretnine = new ColumnHeader();
            IdSobe = new ColumnHeader();
            tbDodajSobu = new Button();
            btnIzmeniSobu = new Button();
            btnObrisiSobu = new Button();
            SuspendLayout();
            // 
            // listaPoslovnica
            // 
            listaPoslovnica.Columns.AddRange(new ColumnHeader[] { ID, IdNekretnine, IdSobe });
            listaPoslovnica.FullRowSelect = true;
            listaPoslovnica.GridLines = true;
            listaPoslovnica.Location = new Point(12, 12);
            listaPoslovnica.Name = "listaPoslovnica";
            listaPoslovnica.Size = new Size(264, 411);
            listaPoslovnica.TabIndex = 1;
            listaPoslovnica.UseCompatibleStateImageBehavior = false;
            listaPoslovnica.View = View.Details;
            // 
            // ID
            // 
            ID.Text = "ID";
            ID.Width = 50;
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
            tbDodajSobu.Location = new Point(347, 12);
            tbDodajSobu.Name = "tbDodajSobu";
            tbDodajSobu.Size = new Size(123, 29);
            tbDodajSobu.TabIndex = 2;
            tbDodajSobu.Text = "Dodaj Sobu";
            tbDodajSobu.UseVisualStyleBackColor = true;
            // 
            // btnIzmeniSobu
            // 
            btnIzmeniSobu.Location = new Point(347, 100);
            btnIzmeniSobu.Name = "btnIzmeniSobu";
            btnIzmeniSobu.Size = new Size(123, 29);
            btnIzmeniSobu.TabIndex = 3;
            btnIzmeniSobu.Text = "Izmeni Sobu";
            btnIzmeniSobu.UseVisualStyleBackColor = true;
            // 
            // btnObrisiSobu
            // 
            btnObrisiSobu.Location = new Point(349, 56);
            btnObrisiSobu.Name = "btnObrisiSobu";
            btnObrisiSobu.Size = new Size(121, 29);
            btnObrisiSobu.TabIndex = 4;
            btnObrisiSobu.Text = "Obrisi Sobu";
            btnObrisiSobu.UseVisualStyleBackColor = true;
            // 
            // PregledSvihSoba
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 450);
            Controls.Add(btnObrisiSobu);
            Controls.Add(btnIzmeniSobu);
            Controls.Add(tbDodajSobu);
            Controls.Add(listaPoslovnica);
            Name = "PregledSvihSoba";
            Text = "PregledSvihSoba";
            ResumeLayout(false);
        }

        #endregion

        private ListView listaPoslovnica;
        private ColumnHeader ID;
        private ColumnHeader IdNekretnine;
        private ColumnHeader IdSobe;
        private Button tbDodajSobu;
        private Button btnIzmeniSobu;
        private Button btnObrisiSobu;
    }
}