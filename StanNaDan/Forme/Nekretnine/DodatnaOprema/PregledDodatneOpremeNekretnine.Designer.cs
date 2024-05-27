namespace StanNaDan.Forme.Nekretnine.DodatnaOprema
{
    partial class PregledDodatneOpremeNekretnine
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
            listaDodatnihOprema = new ListView();
            IDopreme = new ColumnHeader();
            IDnekretnine = new ColumnHeader();
            TipOpreme = new ColumnHeader();
            Cena = new ColumnHeader();
            btnDodajNovuOpremu = new Button();
            btnIzmeniOpremu = new Button();
            btnObrisiOpremu = new Button();
            SuspendLayout();
            // 
            // listaDodatnihOprema
            // 
            listaDodatnihOprema.Columns.AddRange(new ColumnHeader[] { IDopreme, IDnekretnine, TipOpreme, Cena });
            listaDodatnihOprema.FullRowSelect = true;
            listaDodatnihOprema.GridLines = true;
            listaDodatnihOprema.Location = new Point(12, 12);
            listaDodatnihOprema.Name = "listaDodatnihOprema";
            listaDodatnihOprema.Size = new Size(483, 303);
            listaDodatnihOprema.TabIndex = 6;
            listaDodatnihOprema.UseCompatibleStateImageBehavior = false;
            listaDodatnihOprema.View = View.Details;
            // 
            // IDopreme
            // 
            IDopreme.Text = "IdOpreme";
            IDopreme.Width = 80;
            // 
            // IDnekretnine
            // 
            IDnekretnine.Text = "IdNekretnine";
            IDnekretnine.Width = 100;
            // 
            // TipOpreme
            // 
            TipOpreme.Text = "Tip Opreme";
            TipOpreme.Width = 150;
            // 
            // Cena
            // 
            Cena.Text = "Cena Koriscenja";
            Cena.Width = 150;
            // 
            // btnDodajNovuOpremu
            // 
            btnDodajNovuOpremu.Location = new Point(525, 12);
            btnDodajNovuOpremu.Name = "btnDodajNovuOpremu";
            btnDodajNovuOpremu.Size = new Size(223, 29);
            btnDodajNovuOpremu.TabIndex = 7;
            btnDodajNovuOpremu.Text = "Dodaj Novu Opremu";
            btnDodajNovuOpremu.UseVisualStyleBackColor = true;
            btnDodajNovuOpremu.Click += btnDodajNovuOpremu_Click;
            // 
            // btnIzmeniOpremu
            // 
            btnIzmeniOpremu.Location = new Point(525, 61);
            btnIzmeniOpremu.Name = "btnIzmeniOpremu";
            btnIzmeniOpremu.Size = new Size(223, 29);
            btnIzmeniOpremu.TabIndex = 8;
            btnIzmeniOpremu.Text = "Izmeni Opremu";
            btnIzmeniOpremu.UseVisualStyleBackColor = true;
            btnIzmeniOpremu.Click += btnIzmeniOpremu_Click;
            // 
            // btnObrisiOpremu
            // 
            btnObrisiOpremu.Location = new Point(525, 110);
            btnObrisiOpremu.Name = "btnObrisiOpremu";
            btnObrisiOpremu.Size = new Size(223, 29);
            btnObrisiOpremu.TabIndex = 9;
            btnObrisiOpremu.Text = "Obrisi Opremu";
            btnObrisiOpremu.UseVisualStyleBackColor = true;
            btnObrisiOpremu.Click += btnObrisiOpremu_Click;
            // 
            // PregledDodatneOpremeNekretnine
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 358);
            Controls.Add(btnObrisiOpremu);
            Controls.Add(btnIzmeniOpremu);
            Controls.Add(btnDodajNovuOpremu);
            Controls.Add(listaDodatnihOprema);
            Name = "PregledDodatneOpremeNekretnine";
            Text = "PregledDodatneOpremeNekretnine";
            Load += PregledDodatneOpremeNekretnine_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listaDodatnihOprema;
        private ColumnHeader IDopreme;
        private ColumnHeader IDnekretnine;
        private ColumnHeader TipOpreme;
        private ColumnHeader Cena;
        private Button btnDodajNovuOpremu;
        private Button btnIzmeniOpremu;
        private Button btnObrisiOpremu;
    }
}