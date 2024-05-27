namespace StanNaDan.Forme.Parking
{
    partial class DodajParking
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
            textBox1 = new TextBox();
            chBUSastavuJavnogParkinga = new CheckBox();
            chBUSastavuNekrenine = new CheckBox();
            chBBesplatan = new CheckBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnDodajParking = new Button();
            label5 = new Label();
            tbIdParkinga = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbIdParkinga);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(chBUSastavuJavnogParkinga);
            groupBox1.Controls.Add(chBUSastavuNekrenine);
            groupBox1.Controls.Add(chBBesplatan);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(394, 243);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci O Parkingu";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(248, 116);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(115, 27);
            textBox1.TabIndex = 7;
            // 
            // chBUSastavuJavnogParkinga
            // 
            chBUSastavuJavnogParkinga.AutoSize = true;
            chBUSastavuJavnogParkinga.Location = new Point(345, 204);
            chBUSastavuJavnogParkinga.Name = "chBUSastavuJavnogParkinga";
            chBUSastavuJavnogParkinga.Size = new Size(18, 17);
            chBUSastavuJavnogParkinga.TabIndex = 6;
            chBUSastavuJavnogParkinga.UseVisualStyleBackColor = true;
            // 
            // chBUSastavuNekrenine
            // 
            chBUSastavuNekrenine.AutoSize = true;
            chBUSastavuNekrenine.Location = new Point(345, 166);
            chBUSastavuNekrenine.Name = "chBUSastavuNekrenine";
            chBUSastavuNekrenine.Size = new Size(18, 17);
            chBUSastavuNekrenine.TabIndex = 5;
            chBUSastavuNekrenine.UseVisualStyleBackColor = true;
            // 
            // chBBesplatan
            // 
            chBBesplatan.AutoSize = true;
            chBBesplatan.Location = new Point(345, 78);
            chBBesplatan.Name = "chBBesplatan";
            chBBesplatan.Size = new Size(18, 17);
            chBBesplatan.TabIndex = 4;
            chBBesplatan.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(41, 201);
            label4.Name = "label4";
            label4.Size = new Size(186, 20);
            label4.TabIndex = 3;
            label4.Text = "U Sastavu Javnog Parkinga:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 163);
            label3.Name = "label3";
            label3.Size = new Size(152, 20);
            label3.TabIndex = 2;
            label3.Text = "U Sastavu Nekretnine:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 119);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 1;
            label2.Text = "Cena:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 75);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 0;
            label1.Text = "Besplatan:";
            // 
            // btnDodajParking
            // 
            btnDodajParking.Location = new Point(107, 261);
            btnDodajParking.Name = "btnDodajParking";
            btnDodajParking.Size = new Size(183, 40);
            btnDodajParking.TabIndex = 1;
            btnDodajParking.Text = "Dodaj Parking";
            btnDodajParking.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(41, 37);
            label5.Name = "label5";
            label5.Size = new Size(85, 20);
            label5.TabIndex = 8;
            label5.Text = "Id Parkinga:";
            // 
            // tbIdParkinga
            // 
            tbIdParkinga.Location = new Point(248, 34);
            tbIdParkinga.Name = "tbIdParkinga";
            tbIdParkinga.Size = new Size(125, 27);
            tbIdParkinga.TabIndex = 9;
            // 
            // DodajParking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(426, 340);
            Controls.Add(btnDodajParking);
            Controls.Add(groupBox1);
            Name = "DodajParking";
            Text = "DodajParking";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox textBox1;
        private CheckBox chBUSastavuJavnogParkinga;
        private CheckBox chBUSastavuNekrenine;
        private CheckBox chBBesplatan;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnDodajParking;
        private Label label5;
        private TextBox tbIdParkinga;
    }
}