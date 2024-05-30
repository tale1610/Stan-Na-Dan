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
            btnIzmeniParking = new Button();
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
            // btnIzmeniParking
            // 
            btnIzmeniParking.Location = new Point(93, 200);
            btnIzmeniParking.Margin = new Padding(3, 2, 3, 2);
            btnIzmeniParking.Name = "btnIzmeniParking";
            btnIzmeniParking.Size = new Size(160, 30);
            btnIzmeniParking.TabIndex = 3;
            btnIzmeniParking.Text = "Izmeni Parking";
            btnIzmeniParking.UseVisualStyleBackColor = true;
            btnIzmeniParking.Click += btnIzmeniParking_Click;
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
            groupBox1.Location = new Point(10, 13);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(345, 175);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci O Parkingu";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(210, 68);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(101, 23);
            textBox1.TabIndex = 7;
            // 
            // chBUSastavuJavnogParkinga
            // 
            chBUSastavuJavnogParkinga.AutoSize = true;
            chBUSastavuJavnogParkinga.Location = new Point(295, 134);
            chBUSastavuJavnogParkinga.Margin = new Padding(3, 2, 3, 2);
            chBUSastavuJavnogParkinga.Name = "chBUSastavuJavnogParkinga";
            chBUSastavuJavnogParkinga.Size = new Size(15, 14);
            chBUSastavuJavnogParkinga.TabIndex = 6;
            chBUSastavuJavnogParkinga.UseVisualStyleBackColor = true;
            // 
            // chBUSastavuNekrenine
            // 
            chBUSastavuNekrenine.AutoSize = true;
            chBUSastavuNekrenine.Location = new Point(295, 106);
            chBUSastavuNekrenine.Margin = new Padding(3, 2, 3, 2);
            chBUSastavuNekrenine.Name = "chBUSastavuNekrenine";
            chBUSastavuNekrenine.Size = new Size(15, 14);
            chBUSastavuNekrenine.TabIndex = 5;
            chBUSastavuNekrenine.UseVisualStyleBackColor = true;
            // 
            // chBBesplatan
            // 
            chBBesplatan.AutoSize = true;
            chBBesplatan.Location = new Point(295, 40);
            chBBesplatan.Margin = new Padding(3, 2, 3, 2);
            chBBesplatan.Name = "chBBesplatan";
            chBBesplatan.Size = new Size(15, 14);
            chBBesplatan.TabIndex = 4;
            chBBesplatan.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 132);
            label4.Name = "label4";
            label4.Size = new Size(150, 15);
            label4.TabIndex = 3;
            label4.Text = "U Sastavu Javnog Parkinga:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 104);
            label3.Name = "label3";
            label3.Size = new Size(122, 15);
            label3.TabIndex = 2;
            label3.Text = "U Sastavu Nekretnine:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 70);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 1;
            label2.Text = "Cena:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 38);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "Besplatan:";
            // 
            // IzmeniParking
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(368, 240);
            Controls.Add(btnIzmeniParking);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "IzmeniParking";
            Text = "IzmeniParking";
            Load += IzmeniParking_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnIzmeniParking;
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