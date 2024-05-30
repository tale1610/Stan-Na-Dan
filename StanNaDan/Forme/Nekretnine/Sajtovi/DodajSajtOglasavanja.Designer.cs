namespace StanNaDan.Forme.Nekretnine.Sajtovi
{
    partial class DodajSajtOglasavanja
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
            groupBox1 = new GroupBox();
            tbSajtOglasavanja = new TextBox();
            tbIdNekretnine = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnDodajSajtOglasavanja = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbSajtOglasavanja);
            groupBox1.Controls.Add(tbIdNekretnine);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(10, 9);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(287, 113);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci O Sajtu";
            // 
            // tbSajtOglasavanja
            // 
            tbSajtOglasavanja.Location = new Point(150, 69);
            tbSajtOglasavanja.Margin = new Padding(3, 2, 3, 2);
            tbSajtOglasavanja.Name = "tbSajtOglasavanja";
            tbSajtOglasavanja.Size = new Size(110, 23);
            tbSajtOglasavanja.TabIndex = 3;
            // 
            // tbIdNekretnine
            // 
            tbIdNekretnine.Enabled = false;
            tbIdNekretnine.Location = new Point(150, 33);
            tbIdNekretnine.Margin = new Padding(3, 2, 3, 2);
            tbIdNekretnine.Name = "tbIdNekretnine";
            tbIdNekretnine.Size = new Size(110, 23);
            tbIdNekretnine.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 71);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 1;
            label2.Text = "Sajt Oglasavanja:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 35);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 0;
            label1.Text = "Id Nekretnine:";
            // 
            // btnDodajSajtOglasavanja
            // 
            btnDodajSajtOglasavanja.Location = new Point(59, 127);
            btnDodajSajtOglasavanja.Margin = new Padding(3, 2, 3, 2);
            btnDodajSajtOglasavanja.Name = "btnDodajSajtOglasavanja";
            btnDodajSajtOglasavanja.Size = new Size(178, 22);
            btnDodajSajtOglasavanja.TabIndex = 1;
            btnDodajSajtOglasavanja.Text = "Dodaj Sajt Oglasavanja";
            btnDodajSajtOglasavanja.UseVisualStyleBackColor = true;
            btnDodajSajtOglasavanja.Click += btnDodajSajtOglasavanja_Click;
            // 
            // DodajSajtOglasavanja
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(310, 165);
            Controls.Add(btnDodajSajtOglasavanja);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DodajSajtOglasavanja";
            Text = "DodajSajtOglasavanja";
            Load += DodajSajtOglasavanja_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private TextBox tbSajtOglasavanja;
        private TextBox tbIdNekretnine;
        private Button btnDodajSajtOglasavanja;
    }
}