namespace StanNaDan.Forme.Nekretnine.Kreveti
{
    partial class IzmeniKrevet
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
            btnIzmeniKrevet = new Button();
            groupBox1 = new GroupBox();
            tbDimenzije = new TextBox();
            tbTip = new TextBox();
            label3 = new Label();
            label2 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnIzmeniKrevet
            // 
            btnIzmeniKrevet.Location = new Point(101, 140);
            btnIzmeniKrevet.Margin = new Padding(3, 2, 3, 2);
            btnIzmeniKrevet.Name = "btnIzmeniKrevet";
            btnIzmeniKrevet.Size = new Size(105, 29);
            btnIzmeniKrevet.TabIndex = 3;
            btnIzmeniKrevet.Text = "Izmeni Krevet";
            btnIzmeniKrevet.UseVisualStyleBackColor = true;
            btnIzmeniKrevet.Click += btnIzmeniKrevet_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbDimenzije);
            groupBox1.Controls.Add(tbTip);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(10, 9);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(285, 110);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci O Krevetu";
            // 
            // tbDimenzije
            // 
            tbDimenzije.Location = new Point(134, 59);
            tbDimenzije.Margin = new Padding(3, 2, 3, 2);
            tbDimenzije.Name = "tbDimenzije";
            tbDimenzije.Size = new Size(110, 23);
            tbDimenzije.TabIndex = 5;
            // 
            // tbTip
            // 
            tbTip.Location = new Point(134, 26);
            tbTip.Margin = new Padding(3, 2, 3, 2);
            tbTip.Name = "tbTip";
            tbTip.Size = new Size(110, 23);
            tbTip.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 62);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 2;
            label3.Text = "Dimenzije:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 28);
            label2.Name = "label2";
            label2.Size = new Size(26, 15);
            label2.TabIndex = 1;
            label2.Text = "Tip:";
            // 
            // IzmeniKrevet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(305, 178);
            Controls.Add(btnIzmeniKrevet);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "IzmeniKrevet";
            Text = "IzmeniKrevet";
            Load += IzmeniKrevet_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnIzmeniKrevet;
        private GroupBox groupBox1;
        private TextBox tbDimenzije;
        private TextBox tbTip;
        private Label label3;
        private Label label2;
    }
}