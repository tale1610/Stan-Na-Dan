namespace StanNaDan.Forme.Parking
{
    partial class PregledSvihParkinga
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
            listaParkinga = new ListView();
            ID = new ColumnHeader();
            Besplatan = new ColumnHeader();
            Cena = new ColumnHeader();
            USastavuNekretnine = new ColumnHeader();
            USastavuJavnogParkinga = new ColumnHeader();
            btnDodajParking = new Button();
            btnObrisiParking = new Button();
            btnIzmeniParking = new Button();
            SuspendLayout();
            // 
            // listaParkinga
            // 
            listaParkinga.Columns.AddRange(new ColumnHeader[] { ID, Besplatan, Cena, USastavuNekretnine, USastavuJavnogParkinga });
            listaParkinga.FullRowSelect = true;
            listaParkinga.GridLines = true;
            listaParkinga.Location = new Point(10, 9);
            listaParkinga.Margin = new Padding(3, 2, 3, 2);
            listaParkinga.Name = "listaParkinga";
            listaParkinga.Size = new Size(532, 307);
            listaParkinga.TabIndex = 7;
            listaParkinga.UseCompatibleStateImageBehavior = false;
            listaParkinga.View = View.Details;
            // 
            // ID
            // 
            ID.Text = "ID";
            ID.Width = 50;
            // 
            // Besplatan
            // 
            Besplatan.Text = "Besplatan";
            Besplatan.Width = 100;
            // 
            // Cena
            // 
            Cena.Text = "Cena";
            Cena.Width = 100;
            // 
            // USastavuNekretnine
            // 
            USastavuNekretnine.Text = "U Sastavu Nekretnine";
            USastavuNekretnine.Width = 150;
            // 
            // USastavuJavnogParkinga
            // 
            USastavuJavnogParkinga.Text = "U Sastavu Javnog Parkinga";
            USastavuJavnogParkinga.Width = 200;
            // 
            // btnDodajParking
            // 
            btnDodajParking.Location = new Point(547, 9);
            btnDodajParking.Margin = new Padding(3, 2, 3, 2);
            btnDodajParking.Name = "btnDodajParking";
            btnDodajParking.Size = new Size(183, 22);
            btnDodajParking.TabIndex = 8;
            btnDodajParking.Text = "Dodaj Parking";
            btnDodajParking.UseVisualStyleBackColor = true;
            btnDodajParking.Click += btnDodajParking_Click;
            // 
            // btnObrisiParking
            // 
            btnObrisiParking.Location = new Point(547, 49);
            btnObrisiParking.Margin = new Padding(3, 2, 3, 2);
            btnObrisiParking.Name = "btnObrisiParking";
            btnObrisiParking.Size = new Size(183, 22);
            btnObrisiParking.TabIndex = 9;
            btnObrisiParking.Text = "Obrisi Parking";
            btnObrisiParking.UseVisualStyleBackColor = true;
            btnObrisiParking.Click += btnObrisiParking_Click;
            // 
            // btnIzmeniParking
            // 
            btnIzmeniParking.Location = new Point(547, 88);
            btnIzmeniParking.Margin = new Padding(3, 2, 3, 2);
            btnIzmeniParking.Name = "btnIzmeniParking";
            btnIzmeniParking.Size = new Size(183, 23);
            btnIzmeniParking.TabIndex = 10;
            btnIzmeniParking.Text = "Izmeni Parking";
            btnIzmeniParking.UseVisualStyleBackColor = true;
            btnIzmeniParking.Click += btnIzmeniParking_Click;
            // 
            // PregledSvihParkinga
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 338);
            Controls.Add(btnIzmeniParking);
            Controls.Add(btnObrisiParking);
            Controls.Add(btnDodajParking);
            Controls.Add(listaParkinga);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PregledSvihParkinga";
            Text = "PregledSvihParkinga";
            Load += PregledSvihParkinga_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listaParkinga;
        private ColumnHeader ID;
        private ColumnHeader Besplatan;
        private ColumnHeader Cena;
        private ColumnHeader USastavuNekretnine;
        private ColumnHeader USastavuJavnogParkinga;
        private Button btnDodajParking;
        private Button btnObrisiParking;
        private Button btnIzmeniParking;
    }
}