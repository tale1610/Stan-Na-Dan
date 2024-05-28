namespace StanNaDan.Forme.Vlasnici.FizickaLica.BrojeviTelefona
{
    partial class PregledSvihBrojevaTelefona
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
            btnObrisiBrojTelefona = new Button();
            btnDodajBrojTelefona = new Button();
            listaBrojevaTelefona = new ListView();
            BrojTelefona = new ColumnHeader();
            SuspendLayout();
            // 
            // btnObrisiBrojTelefona
            // 
            btnObrisiBrojTelefona.Location = new Point(298, 51);
            btnObrisiBrojTelefona.Margin = new Padding(3, 2, 3, 2);
            btnObrisiBrojTelefona.Name = "btnObrisiBrojTelefona";
            btnObrisiBrojTelefona.Size = new Size(183, 22);
            btnObrisiBrojTelefona.TabIndex = 13;
            btnObrisiBrojTelefona.Text = "Obrisi Broj Telefona";
            btnObrisiBrojTelefona.UseVisualStyleBackColor = true;
            btnObrisiBrojTelefona.Click += btnObrisiBrojTelefona_Click;
            // 
            // btnDodajBrojTelefona
            // 
            btnDodajBrojTelefona.Location = new Point(298, 11);
            btnDodajBrojTelefona.Margin = new Padding(3, 2, 3, 2);
            btnDodajBrojTelefona.Name = "btnDodajBrojTelefona";
            btnDodajBrojTelefona.Size = new Size(183, 22);
            btnDodajBrojTelefona.TabIndex = 12;
            btnDodajBrojTelefona.Text = "Dodaj Broj Telefona";
            btnDodajBrojTelefona.UseVisualStyleBackColor = true;
            btnDodajBrojTelefona.Click += btnDodajBrojTelefona_Click;
            // 
            // listaBrojevaTelefona
            // 
            listaBrojevaTelefona.Columns.AddRange(new ColumnHeader[] { BrojTelefona });
            listaBrojevaTelefona.FullRowSelect = true;
            listaBrojevaTelefona.GridLines = true;
            listaBrojevaTelefona.Location = new Point(12, 11);
            listaBrojevaTelefona.Margin = new Padding(3, 2, 3, 2);
            listaBrojevaTelefona.Name = "listaBrojevaTelefona";
            listaBrojevaTelefona.Size = new Size(256, 307);
            listaBrojevaTelefona.TabIndex = 11;
            listaBrojevaTelefona.UseCompatibleStateImageBehavior = false;
            listaBrojevaTelefona.View = View.Details;
            // 
            // BrojTelefona
            // 
            BrojTelefona.Text = "Broj Telefona";
            BrojTelefona.Width = 250;
            // 
            // PregledSvihBrojevaTelefona
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 331);
            Controls.Add(btnObrisiBrojTelefona);
            Controls.Add(btnDodajBrojTelefona);
            Controls.Add(listaBrojevaTelefona);
            Name = "PregledSvihBrojevaTelefona";
            Text = "PregledSvihBrojevaTelefona";
            Load += PregledSvihBrojevaTelefona_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button btnObrisiBrojTelefona;
        private Button btnDodajBrojTelefona;
        private ListView listaBrojevaTelefona;
        private ColumnHeader BrojTelefona;
    }
}