namespace StanNaDan.Forme.Zaposleni.Sefovi
{
    partial class DodajNovogSefa
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
            btnDodajNovogSefa = new Button();
            groupBox1 = new GroupBox();
            dateTimePicker1 = new DateTimePicker();
            tbPrezime = new TextBox();
            tbIme = new TextBox();
            tbMBR = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dateTimePicker2 = new DateTimePicker();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnDodajNovogSefa
            // 
            btnDodajNovogSefa.Location = new Point(83, 316);
            btnDodajNovogSefa.Name = "btnDodajNovogSefa";
            btnDodajNovogSefa.Size = new Size(270, 29);
            btnDodajNovogSefa.TabIndex = 3;
            btnDodajNovogSefa.Text = "Zaposli Novog Sefa";
            btnDodajNovogSefa.UseVisualStyleBackColor = true;
            btnDodajNovogSefa.Click += btnDodajNovogSefa_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dateTimePicker2);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(tbPrezime);
            groupBox1.Controls.Add(tbIme);
            groupBox1.Controls.Add(tbMBR);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(438, 298);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci o sefu";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(195, 186);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(216, 27);
            dateTimePicker1.TabIndex = 10;
            // 
            // tbPrezime
            // 
            tbPrezime.Location = new Point(195, 134);
            tbPrezime.Name = "tbPrezime";
            tbPrezime.Size = new Size(216, 27);
            tbPrezime.TabIndex = 7;
            // 
            // tbIme
            // 
            tbIme.Location = new Point(195, 87);
            tbIme.Name = "tbIme";
            tbIme.Size = new Size(216, 27);
            tbIme.TabIndex = 6;
            // 
            // tbMBR
            // 
            tbMBR.Location = new Point(195, 43);
            tbMBR.Name = "tbMBR";
            tbMBR.Size = new Size(216, 27);
            tbMBR.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 245);
            label5.Name = "label5";
            label5.Size = new Size(136, 20);
            label5.TabIndex = 4;
            label5.Text = "Datum Postavljanja";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 193);
            label4.Name = "label4";
            label4.Size = new Size(131, 20);
            label4.TabIndex = 3;
            label4.Text = "Datum Zaposlenja";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 141);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 2;
            label3.Text = "Prezime";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 94);
            label2.Name = "label2";
            label2.Size = new Size(34, 20);
            label2.TabIndex = 1;
            label2.Text = "Ime";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 50);
            label1.Name = "label1";
            label1.Size = new Size(40, 20);
            label1.TabIndex = 0;
            label1.Text = "MBR";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(195, 240);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(216, 27);
            dateTimePicker2.TabIndex = 11;
            // 
            // DodajNovogSefa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(469, 378);
            Controls.Add(btnDodajNovogSefa);
            Controls.Add(groupBox1);
            Name = "DodajNovogSefa";
            Text = "DodajNovogSefa";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnDodajNovogSefa;
        private GroupBox groupBox1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private TextBox tbPrezime;
        private TextBox tbIme;
        private TextBox tbMBR;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}