﻿namespace StanNaDan
{
    partial class Pocetna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pocetna));
            btnPoslovnice = new Button();
            pictureBox1 = new PictureBox();
            btnZaposleni = new Button();
            btnTestForma = new Button();
            btnVlasnici = new Button();
            btnNekretnine = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnPoslovnice
            // 
            btnPoslovnice.Location = new Point(12, 261);
            btnPoslovnice.Name = "btnPoslovnice";
            btnPoslovnice.Size = new Size(261, 79);
            btnPoslovnice.TabIndex = 0;
            btnPoslovnice.Text = "Poslovnice";
            btnPoslovnice.UseVisualStyleBackColor = true;
            btnPoslovnice.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(204, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(261, 235);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // btnZaposleni
            // 
            btnZaposleni.Location = new Point(12, 367);
            btnZaposleni.Name = "btnZaposleni";
            btnZaposleni.Size = new Size(261, 79);
            btnZaposleni.TabIndex = 2;
            btnZaposleni.Text = "Zaposleni";
            btnZaposleni.UseVisualStyleBackColor = true;
            btnZaposleni.Click += btnZaposleni_Click;
            // 
            // btnTestForma
            // 
            btnTestForma.Location = new Point(204, 483);
            btnTestForma.Name = "btnTestForma";
            btnTestForma.Size = new Size(261, 82);
            btnTestForma.TabIndex = 3;
            btnTestForma.Text = "Test Forma";
            btnTestForma.UseVisualStyleBackColor = true;
            btnTestForma.Click += btnTestForma_Click;
            // 
            // btnVlasnici
            // 
            btnVlasnici.Location = new Point(371, 367);
            btnVlasnici.Name = "btnVlasnici";
            btnVlasnici.Size = new Size(274, 79);
            btnVlasnici.TabIndex = 4;
            btnVlasnici.Text = "Vlasnici Nekretnina";
            btnVlasnici.UseVisualStyleBackColor = true;
            btnVlasnici.Click += btnVlasnici_Click;
            // 
            // btnNekretnine
            // 
            btnNekretnine.Location = new Point(371, 261);
            btnNekretnine.Name = "btnNekretnine";
            btnNekretnine.Size = new Size(274, 79);
            btnNekretnine.TabIndex = 5;
            btnNekretnine.Text = "Nekretnine";
            btnNekretnine.UseVisualStyleBackColor = true;
            btnNekretnine.Click += btnNekretnine_Click;
            // 
            // Pocetna
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(657, 586);
            Controls.Add(btnNekretnine);
            Controls.Add(btnVlasnici);
            Controls.Add(btnTestForma);
            Controls.Add(btnZaposleni);
            Controls.Add(pictureBox1);
            Controls.Add(btnPoslovnice);
            Name = "Pocetna";
            Text = "Pocetna";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnPoslovnice;
        private PictureBox pictureBox1;
        private Button btnZaposleni;
        private Button btnTestForma;
        private Button btnVlasnici;
        private Button btnNekretnine;
    }
}