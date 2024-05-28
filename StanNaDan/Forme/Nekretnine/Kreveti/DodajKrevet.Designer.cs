namespace StanNaDan.Forme.Nekretnine.Kreveti
{
    partial class DodajKrevet
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
            tbDimenzije = new TextBox();
            tbTip = new TextBox();
            tbIdKreveta = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnDodajKrevet = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbDimenzije);
            groupBox1.Controls.Add(tbTip);
            groupBox1.Controls.Add(tbIdKreveta);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(326, 183);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci O Krevetu";
            // 
            // tbDimenzije
            // 
            tbDimenzije.Location = new Point(155, 132);
            tbDimenzije.Name = "tbDimenzije";
            tbDimenzije.Size = new Size(125, 27);
            tbDimenzije.TabIndex = 5;
            // 
            // tbTip
            // 
            tbTip.Location = new Point(155, 88);
            tbTip.Name = "tbTip";
            tbTip.Size = new Size(125, 27);
            tbTip.TabIndex = 4;
            // 
            // tbIdKreveta
            // 
            tbIdKreveta.Location = new Point(155, 48);
            tbIdKreveta.Name = "tbIdKreveta";
            tbIdKreveta.Size = new Size(125, 27);
            tbIdKreveta.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 135);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 2;
            label3.Text = "Dimenzije:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 91);
            label2.Name = "label2";
            label2.Size = new Size(33, 20);
            label2.TabIndex = 1;
            label2.Text = "Tip:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 51);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 0;
            label1.Text = "Id Kreveta:";
            // 
            // btnDodajKrevet
            // 
            btnDodajKrevet.Location = new Point(115, 216);
            btnDodajKrevet.Name = "btnDodajKrevet";
            btnDodajKrevet.Size = new Size(120, 39);
            btnDodajKrevet.TabIndex = 1;
            btnDodajKrevet.Text = "Dodaj Krevet";
            btnDodajKrevet.UseVisualStyleBackColor = true;
            btnDodajKrevet.Click += btnDodajKrevet_Click;
            // 
            // DodajKrevet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(353, 267);
            Controls.Add(btnDodajKrevet);
            Controls.Add(groupBox1);
            Name = "DodajKrevet";
            Text = "DodajKrevet";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox tbDimenzije;
        private TextBox tbTip;
        private TextBox tbIdKreveta;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnDodajKrevet;
    }
}