namespace StanNaDan.Forme.Nekretnine.DodatnaOprema
{
    partial class DodajDodatnuOpremu
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
            tbCenaKoriscenja = new TextBox();
            tbTipOpreme = new TextBox();
            cbBesplatnoKoriscenje = new CheckBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnDodajNovuOpremu = new Button();
            label4 = new Label();
            textBox1 = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(tbCenaKoriscenja);
            groupBox1.Controls.Add(tbTipOpreme);
            groupBox1.Controls.Add(cbBesplatnoKoriscenje);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(377, 237);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci o dodatnoj opremi";
            // 
            // tbCenaKoriscenja
            // 
            tbCenaKoriscenja.Location = new Point(179, 189);
            tbCenaKoriscenja.Name = "tbCenaKoriscenja";
            tbCenaKoriscenja.Size = new Size(182, 27);
            tbCenaKoriscenja.TabIndex = 5;
            // 
            // tbTipOpreme
            // 
            tbTipOpreme.Location = new Point(179, 97);
            tbTipOpreme.Name = "tbTipOpreme";
            tbTipOpreme.Size = new Size(182, 27);
            tbTipOpreme.TabIndex = 4;
            // 
            // cbBesplatnoKoriscenje
            // 
            cbBesplatnoKoriscenje.AutoSize = true;
            cbBesplatnoKoriscenje.Location = new Point(179, 148);
            cbBesplatnoKoriscenje.Name = "cbBesplatnoKoriscenje";
            cbBesplatnoKoriscenje.Size = new Size(18, 17);
            cbBesplatnoKoriscenje.TabIndex = 3;
            cbBesplatnoKoriscenje.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 192);
            label3.Name = "label3";
            label3.Size = new Size(117, 20);
            label3.TabIndex = 2;
            label3.Text = "Cena Koriscenja:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 145);
            label2.Name = "label2";
            label2.Size = new Size(150, 20);
            label2.TabIndex = 1;
            label2.Text = "Besplatno Koriscenje:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 100);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 0;
            label1.Text = "Tip Opreme:";
            // 
            // btnDodajNovuOpremu
            // 
            btnDodajNovuOpremu.Location = new Point(79, 255);
            btnDodajNovuOpremu.Name = "btnDodajNovuOpremu";
            btnDodajNovuOpremu.Size = new Size(235, 29);
            btnDodajNovuOpremu.TabIndex = 1;
            btnDodajNovuOpremu.Text = "Dodaj Novu Opremu";
            btnDodajNovuOpremu.UseVisualStyleBackColor = true;
            btnDodajNovuOpremu.Click += btnDodajNovuOpremu_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 44);
            label4.Name = "label4";
            label4.Size = new Size(83, 20);
            label4.TabIndex = 6;
            label4.Text = "Id Opreme:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(179, 41);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(182, 27);
            textBox1.TabIndex = 7;
            // 
            // DodajDodatnuOpremu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(395, 304);
            Controls.Add(btnDodajNovuOpremu);
            Controls.Add(groupBox1);
            Name = "DodajDodatnuOpremu";
            Text = "DodajDodatnuOpremu";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox tbCenaKoriscenja;
        private TextBox tbTipOpreme;
        private CheckBox cbBesplatnoKoriscenje;
        private Button btnDodajNovuOpremu;
        private TextBox textBox1;
        private Label label4;
    }
}