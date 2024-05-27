namespace StanNaDan.Forme.Nekretnine.Sajtovi
{
    partial class PregledIzdavanjaNekretnine
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
            idNekretnine = new ColumnHeader();
            adresaNekretnine = new ColumnHeader();
            sajtIzdavanja = new ColumnHeader();
            SuspendLayout();
            // 
            // listaPoslovnica
            // 
            listaPoslovnica.Columns.AddRange(new ColumnHeader[] { idNekretnine, adresaNekretnine, sajtIzdavanja });
            listaPoslovnica.FullRowSelect = true;
            listaPoslovnica.GridLines = true;
            listaPoslovnica.Location = new Point(12, 12);
            listaPoslovnica.Name = "listaPoslovnica";
            listaPoslovnica.Size = new Size(615, 352);
            listaPoslovnica.TabIndex = 1;
            listaPoslovnica.UseCompatibleStateImageBehavior = false;
            listaPoslovnica.View = View.Details;
            // 
            // idNekretnine
            // 
            idNekretnine.Text = "ID Nekretnine";
            idNekretnine.Width = 110;
            // 
            // adresaNekretnine
            // 
            adresaNekretnine.Text = "Adresa Nekretnine";
            adresaNekretnine.Width = 250;
            // 
            // sajtIzdavanja
            // 
            sajtIzdavanja.Text = "Sajt Izdavanja";
            sajtIzdavanja.Width = 250;
            // 
            // PregledIzdavanjaNekretnine
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(842, 450);
            Controls.Add(listaPoslovnica);
            Name = "PregledIzdavanjaNekretnine";
            Text = "PregledIzdavanjaNekretnine";
            ResumeLayout(false);
        }

        #endregion

        private ListView listaPoslovnica;
        private ColumnHeader idNekretnine;
        private ColumnHeader adresaNekretnine;
        private ColumnHeader sajtIzdavanja;
    }
}