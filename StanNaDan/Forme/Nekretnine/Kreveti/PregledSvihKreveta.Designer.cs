namespace StanNaDan.Forme.Nekretnine.Kreveti
{
    partial class PregledSvihKreveta
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
            listaKreveta = new ListView();
            IdKreveta = new ColumnHeader();
            Tip = new ColumnHeader();
            Dimenzije = new ColumnHeader();
            btnDodajKrevet = new Button();
            btnObrisiKrevet = new Button();
            btnIzmeniKrevet = new Button();
            SuspendLayout();
            // 
            // listaKreveta
            // 
            listaKreveta.Columns.AddRange(new ColumnHeader[] { IdKreveta, Tip, Dimenzije });
            listaKreveta.FullRowSelect = true;
            listaKreveta.GridLines = true;
            listaKreveta.Location = new Point(12, 12);
            listaKreveta.Name = "listaKreveta";
            listaKreveta.Size = new Size(463, 408);
            listaKreveta.TabIndex = 8;
            listaKreveta.UseCompatibleStateImageBehavior = false;
            listaKreveta.View = View.Details;
            // 
            // IdKreveta
            // 
            IdKreveta.Text = "Id Kreveta";
            IdKreveta.Width = 100;
            // 
            // Tip
            // 
            Tip.Text = "Tip";
            Tip.Width = 100;
            // 
            // Dimenzije
            // 
            Dimenzije.Text = "Dimenzije";
            Dimenzije.Width = 100;
            // 
            // btnDodajKrevet
            // 
            btnDodajKrevet.Location = new Point(508, 12);
            btnDodajKrevet.Name = "btnDodajKrevet";
            btnDodajKrevet.Size = new Size(199, 29);
            btnDodajKrevet.TabIndex = 9;
            btnDodajKrevet.Text = "Dodaj Krevet";
            btnDodajKrevet.UseVisualStyleBackColor = true;
            btnDodajKrevet.Click += btnDodajKrevet_Click;
            // 
            // btnObrisiKrevet
            // 
            btnObrisiKrevet.Location = new Point(510, 129);
            btnObrisiKrevet.Name = "btnObrisiKrevet";
            btnObrisiKrevet.Size = new Size(195, 29);
            btnObrisiKrevet.TabIndex = 10;
            btnObrisiKrevet.Text = "Obrisi Krevet";
            btnObrisiKrevet.UseVisualStyleBackColor = true;
            btnObrisiKrevet.Click += btnObrisiKrevet_Click;
            // 
            // btnIzmeniKrevet
            // 
            btnIzmeniKrevet.Location = new Point(508, 69);
            btnIzmeniKrevet.Name = "btnIzmeniKrevet";
            btnIzmeniKrevet.Size = new Size(197, 31);
            btnIzmeniKrevet.TabIndex = 11;
            btnIzmeniKrevet.Text = "Izmeni Krevet";
            btnIzmeniKrevet.UseVisualStyleBackColor = true;
            // 
            // PregledSvihKreveta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(717, 450);
            Controls.Add(btnIzmeniKrevet);
            Controls.Add(btnObrisiKrevet);
            Controls.Add(btnDodajKrevet);
            Controls.Add(listaKreveta);
            Name = "PregledSvihKreveta";
            Text = "PregledSvihKreveta";
            Load += PregledSvihKreveta_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listaKreveta;
        private ColumnHeader IdKreveta;
        private ColumnHeader Tip;
        private ColumnHeader Dimenzije;
        private Button btnDodajKrevet;
        private Button btnObrisiKrevet;
        private Button btnIzmeniKrevet;
    }
}