namespace StanNaDan.Forme.Vlasnici.FizickaLica.BrojeviTelefona
{
    partial class DodajBrojTelefona
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
            btnDodajBrojTelefona = new Button();
            groupBox1 = new GroupBox();
            tbBrojTelefona = new TextBox();
            label5 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnDodajBrojTelefona
            // 
            btnDodajBrojTelefona.Location = new Point(103, 121);
            btnDodajBrojTelefona.Margin = new Padding(3, 2, 3, 2);
            btnDodajBrojTelefona.Name = "btnDodajBrojTelefona";
            btnDodajBrojTelefona.Size = new Size(160, 30);
            btnDodajBrojTelefona.TabIndex = 3;
            btnDodajBrojTelefona.Text = "Dodaj Broj Telefona";
            btnDodajBrojTelefona.UseVisualStyleBackColor = true;
            btnDodajBrojTelefona.Click += btnDodajBrojTelefona_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbBrojTelefona);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(12, 11);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(345, 92);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci O Broju Telefona";
            // 
            // tbBrojTelefona
            // 
            tbBrojTelefona.Location = new Point(157, 40);
            tbBrojTelefona.Margin = new Padding(3, 2, 3, 2);
            tbBrojTelefona.Name = "tbBrojTelefona";
            tbBrojTelefona.Size = new Size(170, 23);
            tbBrojTelefona.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 41);
            label5.Name = "label5";
            label5.Size = new Size(78, 15);
            label5.TabIndex = 8;
            label5.Text = "Broj Telefona:";
            // 
            // DodajBrojTelefona
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 162);
            Controls.Add(btnDodajBrojTelefona);
            Controls.Add(groupBox1);
            Name = "DodajBrojTelefona";
            Text = "DodajBrojTelefona";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnDodajBrojTelefona;
        private GroupBox groupBox1;
        private TextBox tbBrojTelefona;
        private Label label5;
    }
}