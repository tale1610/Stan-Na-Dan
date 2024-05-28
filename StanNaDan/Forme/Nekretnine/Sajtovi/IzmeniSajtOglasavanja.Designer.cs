namespace StanNaDan.Forme.Nekretnine.Sajtovi
{
    partial class tbIzmeniSajtOglasavanja
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
            btnDodajSajtOglasavanja = new Button();
            groupBox1 = new GroupBox();
            tbSajtOglasavanja = new TextBox();
            tbIdNekretnine = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnDodajSajtOglasavanja
            // 
            btnDodajSajtOglasavanja.Location = new Point(67, 169);
            btnDodajSajtOglasavanja.Name = "btnDodajSajtOglasavanja";
            btnDodajSajtOglasavanja.Size = new Size(203, 29);
            btnDodajSajtOglasavanja.TabIndex = 3;
            btnDodajSajtOglasavanja.Text = "Izmeni Sajt Oglasavanja";
            btnDodajSajtOglasavanja.UseVisualStyleBackColor = true;
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
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci O Sajtu";
            // 
            // tbSajtOglasavanja
            // 
            tbSajtOglasavanja.Location = new Point(172, 92);
            tbSajtOglasavanja.Name = "tbSajtOglasavanja";
            tbSajtOglasavanja.Size = new Size(125, 27);
            tbSajtOglasavanja.TabIndex = 3;
            // 
            // tbIdNekretnine
            // 
            tbIdNekretnine.Location = new Point(172, 44);
            tbIdNekretnine.Name = "tbIdNekretnine";
            tbIdNekretnine.Size = new Size(125, 27);
            tbIdNekretnine.TabIndex = 2;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 47);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 0;
            label1.Text = "Id Nekretnine:";
            // 
            // tbIzmeniSajtOglasavanja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 215);
            Controls.Add(btnDodajSajtOglasavanja);
            Controls.Add(groupBox1);
            Name = "tbIzmeniSajtOglasavanja";
            Text = "IzmeniSajtOglasavanja";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnDodajSajtOglasavanja;
        private GroupBox groupBox1;
        private TextBox tbSajtOglasavanja;
        private TextBox tbIdNekretnine;
        private Label label2;
        private Label label1;
    }
}