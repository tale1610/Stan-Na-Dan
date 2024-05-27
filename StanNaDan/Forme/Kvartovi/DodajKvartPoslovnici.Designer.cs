namespace StanNaDan.Forme.Kvartovi
{
    partial class DodajKvartPoslovnici
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
            tbGradskaZona = new TextBox();
            label1 = new Label();
            btnDodajKvart = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbGradskaZona);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(386, 109);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci o kvartu";
            // 
            // tbGradskaZona
            // 
            tbGradskaZona.Location = new Point(132, 47);
            tbGradskaZona.Name = "tbGradskaZona";
            tbGradskaZona.Size = new Size(226, 27);
            tbGradskaZona.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 50);
            label1.Name = "label1";
            label1.Size = new Size(103, 20);
            label1.TabIndex = 0;
            label1.Text = "Gradska Zona:";
            // 
            // btnDodajKvart
            // 
            btnDodajKvart.Location = new Point(81, 150);
            btnDodajKvart.Name = "btnDodajKvart";
            btnDodajKvart.Size = new Size(246, 29);
            btnDodajKvart.TabIndex = 1;
            btnDodajKvart.Text = "Zaduzi Poslovnicu Za Novi Kvart";
            btnDodajKvart.UseVisualStyleBackColor = true;
            btnDodajKvart.Click += btnDodajKvart_Click;
            // 
            // DodajKvartPoslovnici
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 213);
            Controls.Add(btnDodajKvart);
            Controls.Add(groupBox1);
            Name = "DodajKvartPoslovnici";
            Text = "DodajKvartPoslovnici";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox tbGradskaZona;
        private Label label1;
        private Button btnDodajKvart;
    }
}