namespace StanNaDan.Forme.SpoljniSaradnici
{
    partial class DodajNovogSpoljnogSaradnika
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
            btnDodajNovogSpoljnogSaradnika = new Button();
            groupBox1 = new GroupBox();
            tbProcenat = new TextBox();
            label6 = new Label();
            dateTimePicker1 = new DateTimePicker();
            tbTelefon = new TextBox();
            tbPrezime = new TextBox();
            tbIme = new TextBox();
            tbID = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnDodajNovogSpoljnogSaradnika
            // 
            btnDodajNovogSpoljnogSaradnika.Location = new Point(84, 361);
            btnDodajNovogSpoljnogSaradnika.Name = "btnDodajNovogSpoljnogSaradnika";
            btnDodajNovogSpoljnogSaradnika.Size = new Size(270, 29);
            btnDodajNovogSpoljnogSaradnika.TabIndex = 3;
            btnDodajNovogSpoljnogSaradnika.Text = "Angazuj Novog Spoljnog Saradnika";
            btnDodajNovogSpoljnogSaradnika.UseVisualStyleBackColor = true;
            btnDodajNovogSpoljnogSaradnika.Click += btnDodajNovogSpoljnogSaradnika_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbProcenat);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(tbTelefon);
            groupBox1.Controls.Add(tbPrezime);
            groupBox1.Controls.Add(tbIme);
            groupBox1.Controls.Add(tbID);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(438, 343);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci o spoljnom saradniku";
            // 
            // tbProcenat
            // 
            tbProcenat.Location = new Point(195, 296);
            tbProcenat.Name = "tbProcenat";
            tbProcenat.Size = new Size(216, 27);
            tbProcenat.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(24, 299);
            label6.Name = "label6";
            label6.Size = new Size(139, 20);
            label6.TabIndex = 11;
            label6.Text = "Procenat Od Najma";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(195, 186);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(216, 27);
            dateTimePicker1.TabIndex = 10;
            // 
            // tbTelefon
            // 
            tbTelefon.Location = new Point(195, 238);
            tbTelefon.Name = "tbTelefon";
            tbTelefon.Size = new Size(216, 27);
            tbTelefon.TabIndex = 9;
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
            // tbID
            // 
            tbID.Location = new Point(195, 43);
            tbID.Name = "tbID";
            tbID.Size = new Size(216, 27);
            tbID.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 245);
            label5.Name = "label5";
            label5.Size = new Size(58, 20);
            label5.TabIndex = 4;
            label5.Text = "Telefon";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 193);
            label4.Name = "label4";
            label4.Size = new Size(144, 20);
            label4.TabIndex = 3;
            label4.Text = "Datum Angazovanja";
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
            label1.Size = new Size(24, 20);
            label1.TabIndex = 0;
            label1.Text = "ID";
            // 
            // DodajNovogSpoljnogSaradnika
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(458, 415);
            Controls.Add(btnDodajNovogSpoljnogSaradnika);
            Controls.Add(groupBox1);
            Name = "DodajNovogSpoljnogSaradnika";
            Text = "DodajNovogSpoljnogSaradnika";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnDodajNovogSpoljnogSaradnika;
        private GroupBox groupBox1;
        private TextBox tbProcenat;
        private Label label6;
        private DateTimePicker dateTimePicker1;
        private TextBox tbTelefon;
        private TextBox tbPrezime;
        private TextBox tbIme;
        private TextBox tbID;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}