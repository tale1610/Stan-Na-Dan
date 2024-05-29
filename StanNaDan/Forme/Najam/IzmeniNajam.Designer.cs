namespace StanNaDan.Forme.Najam
{
    partial class IzmeniNajam
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
            btnIzmeniNajam = new Button();
            groupBox1 = new GroupBox();
            tbProvizijaAgencije = new TextBox();
            tbPopust = new TextBox();
            tbCenaPoDanu = new TextBox();
            dtpZavrsetak = new DateTimePicker();
            dtpPocetak = new DateTimePicker();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnIzmeniNajam
            // 
            btnIzmeniNajam.Location = new Point(134, 251);
            btnIzmeniNajam.Margin = new Padding(3, 2, 3, 2);
            btnIzmeniNajam.Name = "btnIzmeniNajam";
            btnIzmeniNajam.Size = new Size(150, 27);
            btnIzmeniNajam.TabIndex = 4;
            btnIzmeniNajam.Text = "Izmeni Najam";
            btnIzmeniNajam.UseVisualStyleBackColor = true;
            btnIzmeniNajam.Click += btnIzmeniNajam_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbProvizijaAgencije);
            groupBox1.Controls.Add(tbPopust);
            groupBox1.Controls.Add(tbCenaPoDanu);
            groupBox1.Controls.Add(dtpZavrsetak);
            groupBox1.Controls.Add(dtpPocetak);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 11);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(395, 223);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Podaci o najmu";
            // 
            // tbProvizijaAgencije
            // 
            tbProvizijaAgencije.Location = new Point(154, 180);
            tbProvizijaAgencije.Margin = new Padding(3, 2, 3, 2);
            tbProvizijaAgencije.Name = "tbProvizijaAgencije";
            tbProvizijaAgencije.Size = new Size(219, 23);
            tbProvizijaAgencije.TabIndex = 10;
            // 
            // tbPopust
            // 
            tbPopust.Location = new Point(154, 144);
            tbPopust.Margin = new Padding(3, 2, 3, 2);
            tbPopust.Name = "tbPopust";
            tbPopust.Size = new Size(219, 23);
            tbPopust.TabIndex = 9;
            // 
            // tbCenaPoDanu
            // 
            tbCenaPoDanu.Location = new Point(154, 109);
            tbCenaPoDanu.Margin = new Padding(3, 2, 3, 2);
            tbCenaPoDanu.Name = "tbCenaPoDanu";
            tbCenaPoDanu.Size = new Size(219, 23);
            tbCenaPoDanu.TabIndex = 8;
            // 
            // dtpZavrsetak
            // 
            dtpZavrsetak.Location = new Point(154, 71);
            dtpZavrsetak.Margin = new Padding(3, 2, 3, 2);
            dtpZavrsetak.Name = "dtpZavrsetak";
            dtpZavrsetak.Size = new Size(219, 23);
            dtpZavrsetak.TabIndex = 7;
            // 
            // dtpPocetak
            // 
            dtpPocetak.Location = new Point(154, 34);
            dtpPocetak.Margin = new Padding(3, 2, 3, 2);
            dtpPocetak.Name = "dtpPocetak";
            dtpPocetak.Size = new Size(219, 23);
            dtpPocetak.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 181);
            label5.Name = "label5";
            label5.Size = new Size(103, 15);
            label5.TabIndex = 5;
            label5.Text = "Provizija Agencije:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 145);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 4;
            label3.Text = "Popust:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 110);
            label4.Name = "label4";
            label4.Size = new Size(85, 15);
            label4.TabIndex = 3;
            label4.Text = "Cena Po Danu:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 74);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 1;
            label2.Text = "Datum Zavrsetka:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 37);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 0;
            label1.Text = "Datum Pocetka:";
            // 
            // IzmeniNajam
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 289);
            Controls.Add(btnIzmeniNajam);
            Controls.Add(groupBox1);
            Name = "IzmeniNajam";
            Text = "IzmeniNajam";
            Load += IzmeniNajam_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnIzmeniNajam;
        private GroupBox groupBox1;
        private TextBox tbProvizijaAgencije;
        private TextBox tbPopust;
        private TextBox tbCenaPoDanu;
        private DateTimePicker dtpZavrsetak;
        private DateTimePicker dtpPocetak;
        private Label label5;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label label1;
    }
}