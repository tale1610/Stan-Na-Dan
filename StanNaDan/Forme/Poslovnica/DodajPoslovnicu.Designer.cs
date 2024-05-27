namespace StanNaDan.Forme
{
    partial class DodajPoslovnicu
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
            label2 = new Label();
            tbAdresa = new TextBox();
            tbRadnoVreme = new TextBox();
            btnDodajPoslovnicu = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbRadnoVreme);
            groupBox1.Controls.Add(tbAdresa);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(28, 15);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(391, 183);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci o poslovnici";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 52);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 0;
            label1.Text = "Adresa:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 112);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 1;
            label2.Text = "Radno vreme:";
            // 
            // tbAdresa
            // 
            tbAdresa.Location = new Point(160, 49);
            tbAdresa.Name = "tbAdresa";
            tbAdresa.Size = new Size(225, 27);
            tbAdresa.TabIndex = 2;
            // 
            // tbRadnoVreme
            // 
            tbRadnoVreme.Location = new Point(160, 109);
            tbRadnoVreme.Name = "tbRadnoVreme";
            tbRadnoVreme.Size = new Size(225, 27);
            tbRadnoVreme.TabIndex = 3;
            // 
            // btnDodajPoslovnicu
            // 
            btnDodajPoslovnicu.Location = new Point(130, 211);
            btnDodajPoslovnicu.Name = "btnDodajPoslovnicu";
            btnDodajPoslovnicu.Size = new Size(205, 29);
            btnDodajPoslovnicu.TabIndex = 1;
            btnDodajPoslovnicu.Text = "Dodaj Poslovnicu";
            btnDodajPoslovnicu.UseVisualStyleBackColor = true;
            btnDodajPoslovnicu.Click += btnDodajPoslovnicu_Click;
            // 
            // DodajPoslovnicu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 252);
            Controls.Add(btnDodajPoslovnicu);
            Controls.Add(groupBox1);
            Name = "DodajPoslovnicu";
            Text = "DodajPoslovnicu";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox tbAdresa;
        private Label label2;
        private Label label1;
        private TextBox tbRadnoVreme;
        private Button btnDodajPoslovnicu;
    }
}