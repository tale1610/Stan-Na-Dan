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
            btnDodajKrevet = new Button();
            groupBox1 = new GroupBox();
            tbDimenzije = new TextBox();
            tbTip = new TextBox();
            label3 = new Label();
            label2 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnDodajKrevet
            // 
            btnDodajKrevet.Location = new Point(115, 187);
            btnDodajKrevet.Name = "btnDodajKrevet";
            btnDodajKrevet.Size = new Size(120, 39);
            btnDodajKrevet.TabIndex = 3;
            btnDodajKrevet.Text = "Dodaj Krevet";
            btnDodajKrevet.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbDimenzije);
            groupBox1.Controls.Add(tbTip);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(11, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(326, 146);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci O Krevetu";
            // 
            // tbDimenzije
            // 
            tbDimenzije.Location = new Point(153, 79);
            tbDimenzije.Name = "tbDimenzije";
            tbDimenzije.Size = new Size(125, 27);
            tbDimenzije.TabIndex = 5;
            // 
            // tbTip
            // 
            tbTip.Location = new Point(153, 35);
            tbTip.Name = "tbTip";
            tbTip.Size = new Size(125, 27);
            tbTip.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 82);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 2;
            label3.Text = "Dimenzije:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 38);
            label2.Name = "label2";
            label2.Size = new Size(33, 20);
            label2.TabIndex = 1;
            label2.Text = "Tip:";
            // 
            // IzmeniKrevet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 238);
            Controls.Add(btnDodajKrevet);
            Controls.Add(groupBox1);
            Name = "IzmeniKrevet";
            Text = "IzmeniKrevet";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnDodajKrevet;
        private GroupBox groupBox1;
        private TextBox tbDimenzije;
        private TextBox tbTip;
        private Label label3;
        private Label label2;
    }
}