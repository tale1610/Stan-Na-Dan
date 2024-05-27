namespace StanNaDan.Forme.SpoljniSaradnici
{
    partial class PregledSpoljnihSaradnikaAgenta
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
            listaSpoljnihSaradnika = new ListView();
            mbrAgenta = new ColumnHeader();
            ID = new ColumnHeader();
            Ime = new ColumnHeader();
            Prezime = new ColumnHeader();
            datumAngazovanja = new ColumnHeader();
            telefon = new ColumnHeader();
            procenatOdNajma = new ColumnHeader();
            btnDodajNovogSpoljnogSaradnika = new Button();
            btnObrisiSpoljnogSaradnika = new Button();
            SuspendLayout();
            // 
            // listaSpoljnihSaradnika
            // 
            listaSpoljnihSaradnika.Columns.AddRange(new ColumnHeader[] { mbrAgenta, ID, Ime, Prezime, datumAngazovanja, telefon, procenatOdNajma });
            listaSpoljnihSaradnika.FullRowSelect = true;
            listaSpoljnihSaradnika.GridLines = true;
            listaSpoljnihSaradnika.Location = new Point(12, 12);
            listaSpoljnihSaradnika.Name = "listaSpoljnihSaradnika";
            listaSpoljnihSaradnika.Size = new Size(743, 327);
            listaSpoljnihSaradnika.TabIndex = 0;
            listaSpoljnihSaradnika.UseCompatibleStateImageBehavior = false;
            listaSpoljnihSaradnika.View = View.Details;
            // 
            // mbrAgenta
            // 
            mbrAgenta.Text = "MBR Agenta";
            mbrAgenta.Width = 150;
            // 
            // ID
            // 
            ID.Text = "ID";
            // 
            // Ime
            // 
            Ime.Text = "Ime";
            Ime.Width = 80;
            // 
            // Prezime
            // 
            Prezime.Text = "Prezime";
            Prezime.Width = 100;
            // 
            // datumAngazovanja
            // 
            datumAngazovanja.Text = "Datum Angazovanja";
            datumAngazovanja.Width = 100;
            // 
            // telefon
            // 
            telefon.Text = "Telefon";
            telefon.Width = 100;
            // 
            // procenatOdNajma
            // 
            procenatOdNajma.Text = "ProcenatOdNajma";
            procenatOdNajma.Width = 150;
            // 
            // btnDodajNovogSpoljnogSaradnika
            // 
            btnDodajNovogSpoljnogSaradnika.Location = new Point(761, 12);
            btnDodajNovogSpoljnogSaradnika.Name = "btnDodajNovogSpoljnogSaradnika";
            btnDodajNovogSpoljnogSaradnika.Size = new Size(200, 56);
            btnDodajNovogSpoljnogSaradnika.TabIndex = 1;
            btnDodajNovogSpoljnogSaradnika.Text = "Angazuj Novog Spoljnog Saradnika";
            btnDodajNovogSpoljnogSaradnika.UseVisualStyleBackColor = true;
            btnDodajNovogSpoljnogSaradnika.Click += btnDodajNovogSpoljnogSaradnika_Click;
            // 
            // btnObrisiSpoljnogSaradnika
            // 
            btnObrisiSpoljnogSaradnika.Location = new Point(761, 88);
            btnObrisiSpoljnogSaradnika.Name = "btnObrisiSpoljnogSaradnika";
            btnObrisiSpoljnogSaradnika.Size = new Size(200, 54);
            btnObrisiSpoljnogSaradnika.TabIndex = 2;
            btnObrisiSpoljnogSaradnika.Text = "Raspusti Spoljnog Saradnika";
            btnObrisiSpoljnogSaradnika.UseVisualStyleBackColor = true;
            btnObrisiSpoljnogSaradnika.Click += btnObrisiSpoljnogSaradnika_Click;
            // 
            // PregledSpoljnihSaradnikaAgenta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(970, 450);
            Controls.Add(btnObrisiSpoljnogSaradnika);
            Controls.Add(btnDodajNovogSpoljnogSaradnika);
            Controls.Add(listaSpoljnihSaradnika);
            Name = "PregledSpoljnihSaradnikaAgenta";
            Text = "PregledSpoljnihSaradnikaAgenta";
            Load += PregledSpoljnihSaradnikaAgenta_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listaSpoljnihSaradnika;
        private ColumnHeader mbrAgenta;
        private ColumnHeader ID;
        private ColumnHeader Ime;
        private ColumnHeader Prezime;
        private ColumnHeader datumAngazovanja;
        private ColumnHeader telefon;
        private ColumnHeader procenatOdNajma;
        private Button btnDodajNovogSpoljnogSaradnika;
        private Button btnObrisiSpoljnogSaradnika;
    }
}