namespace StanNaDan.Forme.Vlasnici.PravnaLica.TelefoniKontaktOsobe
{
    partial class DodajTelefonKontaktOsobe
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
            btnDodajTelefonKontaktOsobe = new Button();
            groupBox1 = new GroupBox();
            tbTelefonKontaktOsobe = new TextBox();
            label5 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnDodajTelefonKontaktOsobe
            // 
            btnDodajTelefonKontaktOsobe.Location = new Point(97, 126);
            btnDodajTelefonKontaktOsobe.Margin = new Padding(3, 2, 3, 2);
            btnDodajTelefonKontaktOsobe.Name = "btnDodajTelefonKontaktOsobe";
            btnDodajTelefonKontaktOsobe.Size = new Size(177, 30);
            btnDodajTelefonKontaktOsobe.TabIndex = 5;
            btnDodajTelefonKontaktOsobe.Text = "Dodaj Telefon Kontakt Osobe";
            btnDodajTelefonKontaktOsobe.UseVisualStyleBackColor = true;
            btnDodajTelefonKontaktOsobe.Click += btnDodajTelefonKontaktOsobe_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbTelefonKontaktOsobe);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(12, 11);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(345, 92);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci O Telefonu Kontakt Osobe";
            // 
            // tbTelefonKontaktOsobe
            // 
            tbTelefonKontaktOsobe.Location = new Point(164, 37);
            tbTelefonKontaktOsobe.Margin = new Padding(3, 2, 3, 2);
            tbTelefonKontaktOsobe.Name = "tbTelefonKontaktOsobe";
            tbTelefonKontaktOsobe.Size = new Size(175, 23);
            tbTelefonKontaktOsobe.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 40);
            label5.Name = "label5";
            label5.Size = new Size(129, 15);
            label5.TabIndex = 8;
            label5.Text = "Telefon Kontakt Osobe:";
            // 
            // DodajTelefonKontaktOsobe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 167);
            Controls.Add(btnDodajTelefonKontaktOsobe);
            Controls.Add(groupBox1);
            Name = "DodajTelefonKontaktOsobe";
            Text = "DodajTelefonKontaktOsobe";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnDodajTelefonKontaktOsobe;
        private GroupBox groupBox1;
        private TextBox tbTelefonKontaktOsobe;
        private Label label5;
    }
}