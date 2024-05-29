namespace StanNaDan.Forme.Soba.ZajednickeProstorije
{
    partial class PregledZajednickihProstorijaSobe
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
            listaProstorija = new ListView();
            Prostorija = new ColumnHeader();
            btnDodajZajednickuProstoriju = new Button();
            btnObrisiZajednickuProstoriju = new Button();
            SuspendLayout();
            // 
            // listaProstorija
            // 
            listaProstorija.Columns.AddRange(new ColumnHeader[] { Prostorija });
            listaProstorija.FullRowSelect = true;
            listaProstorija.GridLines = true;
            listaProstorija.Location = new Point(12, 12);
            listaProstorija.Name = "listaProstorija";
            listaProstorija.Size = new Size(213, 411);
            listaProstorija.TabIndex = 6;
            listaProstorija.UseCompatibleStateImageBehavior = false;
            listaProstorija.View = View.Details;
            // 
            // Prostorija
            // 
            Prostorija.Text = "Zajednicka Prostorija";
            Prostorija.Width = 200;
            // 
            // btnDodajZajednickuProstoriju
            // 
            btnDodajZajednickuProstoriju.Location = new Point(231, 12);
            btnDodajZajednickuProstoriju.Name = "btnDodajZajednickuProstoriju";
            btnDodajZajednickuProstoriju.Size = new Size(205, 29);
            btnDodajZajednickuProstoriju.TabIndex = 7;
            btnDodajZajednickuProstoriju.Text = "Dodaj Prostoriju";
            btnDodajZajednickuProstoriju.UseVisualStyleBackColor = true;
            btnDodajZajednickuProstoriju.Click += btnDodajZajednickuProstoriju_Click;
            // 
            // btnObrisiZajednickuProstoriju
            // 
            btnObrisiZajednickuProstoriju.Location = new Point(231, 64);
            btnObrisiZajednickuProstoriju.Name = "btnObrisiZajednickuProstoriju";
            btnObrisiZajednickuProstoriju.Size = new Size(205, 29);
            btnObrisiZajednickuProstoriju.TabIndex = 8;
            btnObrisiZajednickuProstoriju.Text = "Obrisi Prostoriju";
            btnObrisiZajednickuProstoriju.UseVisualStyleBackColor = true;
            // 
            // PregledZajednickihProstorijaSobe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 450);
            Controls.Add(btnObrisiZajednickuProstoriju);
            Controls.Add(btnDodajZajednickuProstoriju);
            Controls.Add(listaProstorija);
            Name = "PregledZajednickihProstorijaSobe";
            Text = "PregledZajednickihProstorija";
            Load += PregledZajednickihProstorijaSobe_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listaProstorija;
        private ColumnHeader Prostorija;
        private Button btnDodajZajednickuProstoriju;
        private Button btnObrisiZajednickuProstoriju;
    }
}