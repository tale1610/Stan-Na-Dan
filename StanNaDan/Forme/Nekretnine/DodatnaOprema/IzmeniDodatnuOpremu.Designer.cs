namespace StanNaDan.Forme.Nekretnine.DodatnaOprema
{
    partial class IzmeniDodatnuOpremu
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
            btnIzmeniDodatnuOpremu = new Button();
            groupBox1 = new GroupBox();
            tbCenaKoriscenja = new TextBox();
            tbTipOpreme = new TextBox();
            cbBesplatnoKoriscenje = new CheckBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnIzmeniDodatnuOpremu
            // 
            btnIzmeniDodatnuOpremu.Location = new Point(81, 233);
            btnIzmeniDodatnuOpremu.Name = "btnIzmeniDodatnuOpremu";
            btnIzmeniDodatnuOpremu.Size = new Size(235, 29);
            btnIzmeniDodatnuOpremu.TabIndex = 3;
            btnIzmeniDodatnuOpremu.Text = "Izmeni Opremu";
            btnIzmeniDodatnuOpremu.UseVisualStyleBackColor = true;
            btnIzmeniDodatnuOpremu.Click += btnIzmeniDodatnuOpremu_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbCenaKoriscenja);
            groupBox1.Controls.Add(tbTipOpreme);
            groupBox1.Controls.Add(cbBesplatnoKoriscenje);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(377, 202);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci o dodatnoj opremi";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // tbCenaKoriscenja
            // 
            tbCenaKoriscenja.Location = new Point(189, 135);
            tbCenaKoriscenja.Name = "tbCenaKoriscenja";
            tbCenaKoriscenja.Size = new Size(182, 27);
            tbCenaKoriscenja.TabIndex = 5;
            // 
            // tbTipOpreme
            // 
            tbTipOpreme.Location = new Point(189, 43);
            tbTipOpreme.Name = "tbTipOpreme";
            tbTipOpreme.Size = new Size(182, 27);
            tbTipOpreme.TabIndex = 4;
            // 
            // cbBesplatnoKoriscenje
            // 
            cbBesplatnoKoriscenje.AutoSize = true;
            cbBesplatnoKoriscenje.Location = new Point(189, 94);
            cbBesplatnoKoriscenje.Name = "cbBesplatnoKoriscenje";
            cbBesplatnoKoriscenje.Size = new Size(18, 17);
            cbBesplatnoKoriscenje.TabIndex = 3;
            cbBesplatnoKoriscenje.UseVisualStyleBackColor = true;
            cbBesplatnoKoriscenje.CheckedChanged += cbBesplatnoKoriscenje_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 138);
            label3.Name = "label3";
            label3.Size = new Size(117, 20);
            label3.TabIndex = 2;
            label3.Text = "Cena Koriscenja:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 91);
            label2.Name = "label2";
            label2.Size = new Size(150, 20);
            label2.TabIndex = 1;
            label2.Text = "Besplatno Koriscenje:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 46);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 0;
            label1.Text = "Tip Opreme:";
            // 
            // IzmeniDodatnuOpremu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 288);
            Controls.Add(btnIzmeniDodatnuOpremu);
            Controls.Add(groupBox1);
            Name = "IzmeniDodatnuOpremu";
            Text = "IzmeniDodatnuOpremu";
            Load += IzmeniDodatnuOpremu_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnIzmeniDodatnuOpremu;
        private GroupBox groupBox1;
        private TextBox tbCenaKoriscenja;
        private TextBox tbTipOpreme;
        private CheckBox cbBesplatnoKoriscenje;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}