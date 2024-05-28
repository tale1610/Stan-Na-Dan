namespace StanNaDan.Forme.Vlasnici.PravnaLica.TelefoniKontaktOsobe
{
    partial class PregledSvihTelefonaKontaktOsoba
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
            btnObrisiTelefonKontaktOsobe = new Button();
            btnDodajTelefonKontaktOsobe = new Button();
            listaTelefona = new ListView();
            TelefonKontaktOsobe = new ColumnHeader();
            SuspendLayout();
            // 
            // btnObrisiTelefonKontaktOsobe
            // 
            btnObrisiTelefonKontaktOsobe.Location = new Point(298, 51);
            btnObrisiTelefonKontaktOsobe.Margin = new Padding(3, 2, 3, 2);
            btnObrisiTelefonKontaktOsobe.Name = "btnObrisiTelefonKontaktOsobe";
            btnObrisiTelefonKontaktOsobe.Size = new Size(183, 22);
            btnObrisiTelefonKontaktOsobe.TabIndex = 17;
            btnObrisiTelefonKontaktOsobe.Text = "Obrisi Telefon Kontakt Osobe";
            btnObrisiTelefonKontaktOsobe.UseVisualStyleBackColor = true;
            btnObrisiTelefonKontaktOsobe.Click += btnObrisiTelefonKontaktOsobe_Click;
            // 
            // btnDodajTelefonKontaktOsobe
            // 
            btnDodajTelefonKontaktOsobe.Location = new Point(298, 11);
            btnDodajTelefonKontaktOsobe.Margin = new Padding(3, 2, 3, 2);
            btnDodajTelefonKontaktOsobe.Name = "btnDodajTelefonKontaktOsobe";
            btnDodajTelefonKontaktOsobe.Size = new Size(183, 22);
            btnDodajTelefonKontaktOsobe.TabIndex = 16;
            btnDodajTelefonKontaktOsobe.Text = "Dodaj Telefon Kontakt Osobe";
            btnDodajTelefonKontaktOsobe.UseVisualStyleBackColor = true;
            btnDodajTelefonKontaktOsobe.Click += btnDodajTelefonKontaktOsobe_Click;
            // 
            // listaTelefona
            // 
            listaTelefona.Columns.AddRange(new ColumnHeader[] { TelefonKontaktOsobe });
            listaTelefona.FullRowSelect = true;
            listaTelefona.GridLines = true;
            listaTelefona.Location = new Point(12, 11);
            listaTelefona.Margin = new Padding(3, 2, 3, 2);
            listaTelefona.Name = "listaTelefona";
            listaTelefona.Size = new Size(256, 307);
            listaTelefona.TabIndex = 15;
            listaTelefona.UseCompatibleStateImageBehavior = false;
            listaTelefona.View = View.Details;
            // 
            // TelefonKontaktOsobe
            // 
            TelefonKontaktOsobe.Text = "Telefon Kontakt Osobe";
            TelefonKontaktOsobe.Width = 250;
            // 
            // PregledSvihTelefonaKontaktOsoba
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(513, 329);
            Controls.Add(btnObrisiTelefonKontaktOsobe);
            Controls.Add(btnDodajTelefonKontaktOsobe);
            Controls.Add(listaTelefona);
            Name = "PregledSvihTelefonaKontaktOsoba";
            Text = "PregledSvihTelefonaKontaktOsoba";
            Load += PregledSvihTelefonaKontaktOsoba_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button btnObrisiTelefonKontaktOsobe;
        private Button btnDodajTelefonKontaktOsobe;
        private ListView listaTelefona;
        private ColumnHeader TelefonKontaktOsobe;
    }
}