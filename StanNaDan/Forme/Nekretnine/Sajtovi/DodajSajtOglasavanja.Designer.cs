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
            label1 = new Label();
            label2 = new Label();
            tbIdNekretnine = new TextBox();
            tbSajtOglasavanja = new TextBox();
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
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(328, 151);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci O Sajtu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 47);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 0;
            label1.Text = "Id Nekretnine:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 95);
            label2.Name = "label2";
            label2.Size = new Size(122, 20);
            label2.TabIndex = 1;
            label2.Text = "Sajt Oglasavanja:";
            // 
            // tbIdNekretnine
            // 
            tbIdNekretnine.Location = new Point(172, 44);
            tbIdNekretnine.Name = "tbIdNekretnine";
            tbIdNekretnine.Size = new Size(125, 27);
            tbIdNekretnine.TabIndex = 2;
            // 
            // tbSajtOglasavanja
            // 
            tbSajtOglasavanja.Location = new Point(172, 92);
            tbSajtOglasavanja.Name = "tbSajtOglasavanja";
            tbSajtOglasavanja.Size = new Size(125, 27);
            tbSajtOglasavanja.TabIndex = 3;
            // 
            // btnDodajSajtOglasavanja
            // 
            btnDodajSajtOglasavanja.Location = new Point(67, 169);
            btnDodajSajtOglasavanja.Name = "btnDodajSajtOglasavanja";
            btnDodajSajtOglasavanja.Size = new Size(203, 29);
            btnDodajSajtOglasavanja.TabIndex = 1;
            btnDodajSajtOglasavanja.Text = "Dodaj Sajt Oglasavanja";
            btnDodajSajtOglasavanja.UseVisualStyleBackColor = true;
            // 
            // DodajSajtOglasavanja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(354, 220);
            Controls.Add(btnDodajSajtOglasavanja);
            Controls.Add(groupBox1);
            Name = "DodajSajtOglasavanja";
            Text = "DodajSajtOglasavanja";
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