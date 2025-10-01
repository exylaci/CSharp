namespace DelegateGyakorlasAutokolcsonzo
{
    partial class Form1
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
            this.lsbAutok = new System.Windows.Forms.ListBox();
            this.btnUjAuto = new System.Windows.Forms.Button();
            this.btnJarmuTorlese = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbRendszam = new System.Windows.Forms.TextBox();
            this.btnAllapotMegvaltoztatasa = new System.Windows.Forms.Button();
            this.chbKolcsonozheto = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btnUgyfelTorles = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsbAutok
            // 
            this.lsbAutok.FormattingEnabled = true;
            this.lsbAutok.Location = new System.Drawing.Point(13, 13);
            this.lsbAutok.Name = "lsbAutok";
            this.lsbAutok.Size = new System.Drawing.Size(237, 277);
            this.lsbAutok.TabIndex = 0;
            // 
            // btnUjAuto
            // 
            this.btnUjAuto.Location = new System.Drawing.Point(257, 13);
            this.btnUjAuto.Name = "btnUjAuto";
            this.btnUjAuto.Size = new System.Drawing.Size(162, 23);
            this.btnUjAuto.TabIndex = 1;
            this.btnUjAuto.Text = "Új jármű hozzáadása";
            this.btnUjAuto.UseVisualStyleBackColor = true;
            this.btnUjAuto.Click += new System.EventHandler(this.btnUjAuto_Click);
            // 
            // btnJarmuTorlese
            // 
            this.btnJarmuTorlese.Location = new System.Drawing.Point(257, 42);
            this.btnJarmuTorlese.Name = "btnJarmuTorlese";
            this.btnJarmuTorlese.Size = new System.Drawing.Size(162, 23);
            this.btnJarmuTorlese.TabIndex = 2;
            this.btnJarmuTorlese.Text = "Meglévő jármű törlése";
            this.btnJarmuTorlese.UseVisualStyleBackColor = true;
            this.btnJarmuTorlese.Click += new System.EventHandler(this.btnJarmuTorlese_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(256, 238);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(162, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Kölcsönzési igény bejelentése";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(256, 267);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(162, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Kölcsönzési igény lemondása";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Rendszám:";
            // 
            // txbRendszam
            // 
            this.txbRendszam.Location = new System.Drawing.Point(65, 13);
            this.txbRendszam.Name = "txbRendszam";
            this.txbRendszam.Size = new System.Drawing.Size(91, 20);
            this.txbRendszam.TabIndex = 6;
            this.txbRendszam.TextChanged += new System.EventHandler(this.txbRendszam_TextChanged);
            // 
            // btnAllapotMegvaltoztatasa
            // 
            this.btnAllapotMegvaltoztatasa.Enabled = false;
            this.btnAllapotMegvaltoztatasa.Location = new System.Drawing.Point(8, 62);
            this.btnAllapotMegvaltoztatasa.Name = "btnAllapotMegvaltoztatasa";
            this.btnAllapotMegvaltoztatasa.Size = new System.Drawing.Size(148, 23);
            this.btnAllapotMegvaltoztatasa.TabIndex = 7;
            this.btnAllapotMegvaltoztatasa.Text = "Állapot meváltoztatása";
            this.btnAllapotMegvaltoztatasa.UseVisualStyleBackColor = true;
            this.btnAllapotMegvaltoztatasa.Click += new System.EventHandler(this.btnAllapotMegvaltoztatasa_Click);
            // 
            // chbKolcsonozheto
            // 
            this.chbKolcsonozheto.AutoSize = true;
            this.chbKolcsonozheto.Enabled = false;
            this.chbKolcsonozheto.Location = new System.Drawing.Point(8, 39);
            this.chbKolcsonozheto.Name = "chbKolcsonozheto";
            this.chbKolcsonozheto.Size = new System.Drawing.Size(155, 17);
            this.chbKolcsonozheto.TabIndex = 8;
            this.chbKolcsonozheto.Text = "Kikölcsönezhető, bent van.";
            this.chbKolcsonozheto.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAllapotMegvaltoztatasa);
            this.groupBox1.Controls.Add(this.chbKolcsonozheto);
            this.groupBox1.Controls.Add(this.txbRendszam);
            this.groupBox1.Location = new System.Drawing.Point(257, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 100);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 294);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(426, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btnUgyfelTorles
            // 
            this.btnUgyfelTorles.Location = new System.Drawing.Point(256, 209);
            this.btnUgyfelTorles.Name = "btnUgyfelTorles";
            this.btnUgyfelTorles.Size = new System.Drawing.Size(162, 23);
            this.btnUgyfelTorles.TabIndex = 11;
            this.btnUgyfelTorles.Text = "Meglévő ügyfél törlése";
            this.btnUgyfelTorles.UseVisualStyleBackColor = true;
            this.btnUgyfelTorles.Click += new System.EventHandler(this.btnUgyfelTorles_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(256, 180);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(162, 23);
            this.button6.TabIndex = 10;
            this.button6.Text = "Új ügyfél felvétele";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 316);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnUgyfelTorles);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnJarmuTorlese);
            this.Controls.Add(this.btnUjAuto);
            this.Controls.Add(this.lsbAutok);
            this.Name = "Form1";
            this.Text = "Autókölcsönző";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbAutok;
        private System.Windows.Forms.Button btnUjAuto;
        private System.Windows.Forms.Button btnJarmuTorlese;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbRendszam;
        private System.Windows.Forms.Button btnAllapotMegvaltoztatasa;
        private System.Windows.Forms.CheckBox chbKolcsonozheto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btnUgyfelTorles;
        private System.Windows.Forms.Button button6;
    }
}

