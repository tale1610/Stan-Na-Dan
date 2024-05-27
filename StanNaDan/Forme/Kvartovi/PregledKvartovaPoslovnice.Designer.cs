namespace StanNaDan.Forme.Kvartovi
{
    partial class PregledKvartovaPoslovnice
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
            listaKvartova = new ListView();
            ID = new ColumnHeader();
            gradskaZona = new ColumnHeader();
            zaduzenaPoslovnica = new ColumnHeader();
            btnDodajNoviKvart = new Button();
            SuspendLayout();
            // 
            // listaKvartova
            // 
            listaKvartova.Columns.AddRange(new ColumnHeader[] { ID, gradskaZona, zaduzenaPoslovnica });
            listaKvartova.FullRowSelect = true;
            listaKvartova.GridLines = true;
            listaKvartova.Location = new Point(12, 12);
            listaKvartova.Name = "listaKvartova";
            listaKvartova.Size = new Size(508, 315);
            listaKvartova.TabIndex = 1;
            listaKvartova.UseCompatibleStateImageBehavior = false;
            listaKvartova.View = View.Details;
            // 
            // ID
            // 
            ID.Text = "ID";
            ID.Width = 50;
            // 
            // gradskaZona
            // 
            gradskaZona.Text = "Gradska Zona";
            gradskaZona.Width = 150;
            // 
            // zaduzenaPoslovnica
            // 
            zaduzenaPoslovnica.Text = "Zaduzena Poslovnica";
            zaduzenaPoslovnica.Width = 300;
            // 
            // btnDodajNoviKvart
            // 
            btnDodajNoviKvart.Location = new Point(526, 12);
            btnDodajNoviKvart.Name = "btnDodajNoviKvart";
            btnDodajNoviKvart.Size = new Size(232, 29);
            btnDodajNoviKvart.TabIndex = 2;
            btnDodajNoviKvart.Text = "Zaduzi Novi Kvart";
            btnDodajNoviKvart.UseVisualStyleBackColor = true;
            btnDodajNoviKvart.Click += btnDodajNoviKvart_Click;
            // 
            // PregledKvartovaPoslovnice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(770, 450);
            Controls.Add(btnDodajNoviKvart);
            Controls.Add(listaKvartova);
            Name = "PregledKvartovaPoslovnice";
            Text = "PregledKvartovaPoslovnice";
            Load += PregledKvartovaPoslovnice_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listaKvartova;
        private ColumnHeader ID;
        private ColumnHeader gradskaZona;
        private ColumnHeader zaduzenaPoslovnica;
        private Button btnDodajNoviKvart;
    }
}