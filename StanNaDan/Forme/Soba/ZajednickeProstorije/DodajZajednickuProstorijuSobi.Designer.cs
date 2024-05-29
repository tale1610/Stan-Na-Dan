namespace StanNaDan.Forme.Soba.ZajednickeProstorije
{
    partial class DodajZajednickuProstorijuSobi
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
            btnDodajProstoriju = new Button();
            groupBox1 = new GroupBox();
            tbProstorija = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnDodajProstoriju
            // 
            btnDodajProstoriju.Location = new Point(101, 130);
            btnDodajProstoriju.Name = "btnDodajProstoriju";
            btnDodajProstoriju.Size = new Size(112, 31);
            btnDodajProstoriju.TabIndex = 3;
            btnDodajProstoriju.Text = "Dodaj Prostoriju";
            btnDodajProstoriju.UseVisualStyleBackColor = true;
            btnDodajProstoriju.Click += btnDodajProstoriju_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbProstorija);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(291, 112);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci o prostoriji";
            // 
            // tbProstorija
            // 
            tbProstorija.Location = new Point(125, 44);
            tbProstorija.Name = "tbProstorija";
            tbProstorija.Size = new Size(125, 27);
            tbProstorija.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 47);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Naziv:";
            // 
            // DodajZajednickuProstorijuSobi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(316, 197);
            Controls.Add(btnDodajProstoriju);
            Controls.Add(groupBox1);
            Name = "DodajZajednickuProstorijuSobi";
            Text = "DodajZajednickuProstorijuSobi";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnDodajProstoriju;
        private GroupBox groupBox1;
        private TextBox tbProstorija;
        private Label label1;
    }
}