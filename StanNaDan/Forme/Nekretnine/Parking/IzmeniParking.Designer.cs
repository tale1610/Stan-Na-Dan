namespace StanNaDan.Forme.Nekretnine.Parking
{
    partial class IzmeniParking
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
            btnDodajParking = new Button();
            groupBox1 = new GroupBox();
            textBox1 = new TextBox();
            chBUSastavuJavnogParkinga = new CheckBox();
            chBUSastavuNekrenine = new CheckBox();
            chBBesplatan = new CheckBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnDodajParking
            // 
            btnDodajParking.Location = new Point(106, 266);
            btnDodajParking.Name = "btnDodajParking";
            btnDodajParking.Size = new Size(183, 40);
            btnDodajParking.TabIndex = 3;
            btnDodajParking.Text = "Dodaj Parking";
            btnDodajParking.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(chBUSastavuJavnogParkinga);
            groupBox1.Controls.Add(chBUSastavuNekrenine);
            groupBox1.Controls.Add(chBBesplatan);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(11, 17);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(394, 233);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci O Parkingu";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(240, 91);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(115, 27);
            textBox1.TabIndex = 7;
            // 
            // chBUSastavuJavnogParkinga
            // 
            chBUSastavuJavnogParkinga.AutoSize = true;
            chBUSastavuJavnogParkinga.Location = new Point(337, 179);
            chBUSastavuJavnogParkinga.Name = "chBUSastavuJavnogParkinga";
            chBUSastavuJavnogParkinga.Size = new Size(18, 17);
            chBUSastavuJavnogParkinga.TabIndex = 6;
            chBUSastavuJavnogParkinga.UseVisualStyleBackColor = true;
            // 
            // chBUSastavuNekrenine
            // 
            chBUSastavuNekrenine.AutoSize = true;
            chBUSastavuNekrenine.Location = new Point(337, 141);
            chBUSastavuNekrenine.Name = "chBUSastavuNekrenine";
            chBUSastavuNekrenine.Size = new Size(18, 17);
            chBUSastavuNekrenine.TabIndex = 5;
            chBUSastavuNekrenine.UseVisualStyleBackColor = true;
            // 
            // chBBesplatan
            // 
            chBBesplatan.AutoSize = true;
            chBBesplatan.Location = new Point(337, 53);
            chBBesplatan.Name = "chBBesplatan";
            chBBesplatan.Size = new Size(18, 17);
            chBBesplatan.TabIndex = 4;
            chBBesplatan.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 176);
            label4.Name = "label4";
            label4.Size = new Size(186, 20);
            label4.TabIndex = 3;
            label4.Text = "U Sastavu Javnog Parkinga:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 138);
            label3.Name = "label3";
            label3.Size = new Size(152, 20);
            label3.TabIndex = 2;
            label3.Text = "U Sastavu Nekretnine:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 94);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 1;
            label2.Text = "Cena:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 50);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 0;
            label1.Text = "Besplatan:";
            // 
            // IzmeniParking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 320);
            Controls.Add(btnDodajParking);
            Controls.Add(groupBox1);
            Name = "IzmeniParking";
            Text = "IzmeniParking";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnDodajParking;
        private GroupBox groupBox1;
        private TextBox textBox1;
        private CheckBox chBUSastavuJavnogParkinga;
        private CheckBox chBUSastavuNekrenine;
        private CheckBox chBBesplatan;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}