namespace StanNaDan.Forme.Zaposleni.Agenti
{
    partial class IzmeniAgenta
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
            btnIzmeniAgenta = new Button();
            groupBox1 = new GroupBox();
            dateTimePicker1 = new DateTimePicker();
            tbStrucnaSprema = new TextBox();
            tbPrezime = new TextBox();
            tbIme = new TextBox();
            tbMBR = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnIzmeniAgenta
            // 
            btnIzmeniAgenta.Location = new Point(73, 237);
            btnIzmeniAgenta.Margin = new Padding(3, 2, 3, 2);
            btnIzmeniAgenta.Name = "btnIzmeniAgenta";
            btnIzmeniAgenta.Size = new Size(236, 22);
            btnIzmeniAgenta.TabIndex = 3;
            btnIzmeniAgenta.Text = "Izmeni Agenta";
            btnIzmeniAgenta.UseVisualStyleBackColor = true;
            btnIzmeniAgenta.Click += btnIzmeniAgenta_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(tbStrucnaSprema);
            groupBox1.Controls.Add(tbPrezime);
            groupBox1.Controls.Add(tbIme);
            groupBox1.Controls.Add(tbMBR);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(10, 9);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(383, 224);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci o agentu";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(171, 140);
            dateTimePicker1.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(190, 23);
            dateTimePicker1.TabIndex = 10;
            // 
            // tbStrucnaSprema
            // 
            tbStrucnaSprema.Location = new Point(171, 178);
            tbStrucnaSprema.Margin = new Padding(3, 2, 3, 2);
            tbStrucnaSprema.Name = "tbStrucnaSprema";
            tbStrucnaSprema.Size = new Size(190, 23);
            tbStrucnaSprema.TabIndex = 9;
            // 
            // tbPrezime
            // 
            tbPrezime.Location = new Point(171, 100);
            tbPrezime.Margin = new Padding(3, 2, 3, 2);
            tbPrezime.Name = "tbPrezime";
            tbPrezime.Size = new Size(190, 23);
            tbPrezime.TabIndex = 7;
            // 
            // tbIme
            // 
            tbIme.Location = new Point(171, 65);
            tbIme.Margin = new Padding(3, 2, 3, 2);
            tbIme.Name = "tbIme";
            tbIme.Size = new Size(190, 23);
            tbIme.TabIndex = 6;
            // 
            // tbMBR
            // 
            tbMBR.Location = new Point(171, 32);
            tbMBR.Margin = new Padding(3, 2, 3, 2);
            tbMBR.Name = "tbMBR";
            tbMBR.Size = new Size(190, 23);
            tbMBR.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 184);
            label5.Name = "label5";
            label5.Size = new Size(90, 15);
            label5.TabIndex = 4;
            label5.Text = "Strucna Sprema";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 145);
            label4.Name = "label4";
            label4.Size = new Size(103, 15);
            label4.TabIndex = 3;
            label4.Text = "Datum Zaposlenja";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 106);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 2;
            label3.Text = "Prezime";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 70);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 1;
            label2.Text = "Ime";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 38);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 0;
            label1.Text = "MBR";
            // 
            // IzmeniAgenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(401, 266);
            Controls.Add(btnIzmeniAgenta);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "IzmeniAgenta";
            Text = "IzmeniAgenta";
            Load += IzmeniAgenta_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnIzmeniAgenta;
        private GroupBox groupBox1;
        private DateTimePicker dateTimePicker1;
        private TextBox tbStrucnaSprema;
        private TextBox tbPrezime;
        private TextBox tbIme;
        private TextBox tbMBR;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}