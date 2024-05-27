namespace StanNaDan.Forme.Soba
{
    partial class DodajSobu
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
            label1 = new Label();
            tbIdSobe = new TextBox();
            btnDodajSobu = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbIdSobe);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(291, 112);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci O Sobi";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 47);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 0;
            label1.Text = "Id Sobe:";
            // 
            // tbIdSobe
            // 
            tbIdSobe.Location = new Point(125, 44);
            tbIdSobe.Name = "tbIdSobe";
            tbIdSobe.Size = new Size(125, 27);
            tbIdSobe.TabIndex = 1;
            // 
            // btnDodajSobu
            // 
            btnDodajSobu.Location = new Point(101, 130);
            btnDodajSobu.Name = "btnDodajSobu";
            btnDodajSobu.Size = new Size(112, 42);
            btnDodajSobu.TabIndex = 1;
            btnDodajSobu.Text = "Dodaj Sobu";
            btnDodajSobu.UseVisualStyleBackColor = true;
            // 
            // DodajSobu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(316, 184);
            Controls.Add(btnDodajSobu);
            Controls.Add(groupBox1);
            Name = "DodajSobu";
            Text = "DodajSobu";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox tbIdSobe;
        private Label label1;
        private Button btnDodajSobu;
    }
}