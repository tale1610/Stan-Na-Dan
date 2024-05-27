namespace StanNaDan.Forme.Vlasnici.FizickaLica
{
    partial class PrikaziNekretnineFizickogLica
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
            Adresa = new ColumnHeader();
            Kvadratura = new ColumnHeader();
            BrSpavacih = new ColumnHeader();
            brKupatila = new ColumnHeader();
            brTerasa = new ColumnHeader();
            SuspendLayout();
            // 
            // listaNekretnina
            // 
            listaNekretnina.Columns.AddRange(new ColumnHeader[] { ID, Tip, Adresa, Kvadratura, BrSpavacih, brKupatila, brTerasa });
            listaNekretnina.FullRowSelect = true;
            listaNekretnina.GridLines = true;
            listaNekretnina.Location = new Point(12, 12);
            listaNekretnina.Name = "listaNekretnina";
            listaNekretnina.Size = new Size(804, 408);
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
            // Adresa
            // 
            Adresa.Text = "Adresa";
            Adresa.Width = 150;
            // 
            // Kvadratura
            // 
            Kvadratura.Text = "Kvadratura";
            Kvadratura.Width = 150;
            // 
            // BrSpavacih
            // 
            BrSpavacih.Text = "Broj Spavacih Soba";
            BrSpavacih.Width = 150;
            // 
            // brKupatila
            // 
            brKupatila.Text = "Broj Kupatila";
            brKupatila.Width = 100;
            // 
            // brTerasa
            // 
            brTerasa.Text = "Broj Terasa";
            brTerasa.Width = 100;
            // 
            // PrikaziNekretnineFizickogLica
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 450);
            Controls.Add(listaNekretnina);
            Name = "PrikaziNekretnineFizickogLica";
            Text = "PrikaziNekretnineFizickogLica";
            ResumeLayout(false);
        }

        #endregion

        private ListView listaNekretnina;
        private ColumnHeader ID;
        private ColumnHeader Tip;
        private ColumnHeader Adresa;
        private ColumnHeader Kvadratura;
        private ColumnHeader BrSpavacih;
        private ColumnHeader brKupatila;
        private ColumnHeader brTerasa;
    }
}