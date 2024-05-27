namespace StanNaDan.Krevet
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
            listaNekretnina = new ListView();
            ID = new ColumnHeader();
            Tip = new ColumnHeader();
            Dimenzije = new ColumnHeader();
            btnDodajKrevet = new Button();
            btnObrisiKrevet = new Button();
            btnIzmeniKrevet = new Button();
            SuspendLayout();
            // 
            // listaNekretnina
            // 
            listaNekretnina.Columns.AddRange(new ColumnHeader[] { ID, Tip, Dimenzije });
            listaNekretnina.FullRowSelect = true;
            listaNekretnina.GridLines = true;
            listaNekretnina.Location = new Point(12, 12);
            listaNekretnina.Name = "listaNekretnina";
            listaNekretnina.Size = new Size(274, 408);
            listaNekretnina.TabIndex = 6;
            listaNekretnina.UseCompatibleStateImageBehavior = false;
            listaNekretnina.View = View.Details;
            // 
            // ID
            // 
            ID.Text = "ID";
            ID.Width = 50;
            // 
            // Tip
            // 
            Tip.Text = "Tip";
            Tip.Width = 100;
            // 
            // Dimenzije
            // 
            Dimenzije.Text = "Dimenzije";
            Dimenzije.Width = 150;
            // 
            // btnDodajKrevet
            // 
            btnDodajKrevet.Location = new Point(363, 12);
            btnDodajKrevet.Name = "btnDodajKrevet";
            btnDodajKrevet.Size = new Size(126, 29);
            btnDodajKrevet.TabIndex = 7;
            btnDodajKrevet.Text = "Dodaj Krevet";
            btnDodajKrevet.UseVisualStyleBackColor = true;
            // 
            // btnObrisiKrevet
            // 
            btnObrisiKrevet.Location = new Point(371, 68);
            btnObrisiKrevet.Name = "btnObrisiKrevet";
            btnObrisiKrevet.Size = new Size(118, 29);
            btnObrisiKrevet.TabIndex = 8;
            btnObrisiKrevet.Text = "Obrisi Krevet";
            btnObrisiKrevet.UseVisualStyleBackColor = true;
            // 
            // btnIzmeniKrevet
            // 
            btnIzmeniKrevet.Location = new Point(363, 125);
            btnIzmeniKrevet.Name = "btnIzmeniKrevet";
            btnIzmeniKrevet.Size = new Size(128, 29);
            btnIzmeniKrevet.TabIndex = 9;
            btnIzmeniKrevet.Text = "Izmeni Krevet";
            btnIzmeniKrevet.UseVisualStyleBackColor = true;
            // 
            // PregledSvihKreveta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(655, 450);
            Controls.Add(btnIzmeniKrevet);
            Controls.Add(btnObrisiKrevet);
            Controls.Add(btnDodajKrevet);
            Controls.Add(listaNekretnina);
            Name = "PregledSvihKreveta";
            Text = "PregledSvihKreveta";
            ResumeLayout(false);
        }

        #endregion

        private ListView listaNekretnina;
        private ColumnHeader ID;
        private ColumnHeader Tip;
        private ColumnHeader Dimenzije;
        private Button btnDodajKrevet;
        private Button btnObrisiKrevet;
        private Button btnIzmeniKrevet;
    }
}