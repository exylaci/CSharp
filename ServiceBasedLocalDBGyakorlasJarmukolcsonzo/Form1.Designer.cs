namespace ServiceBasedLocalDBGyakorlasJarmukolcsonző
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
            this.lsvTeljes = new System.Windows.Forms.ListView();
            this.btnUjKolcsonzo = new System.Windows.Forms.Button();
            this.btnKolcsonzoModositas = new System.Windows.Forms.Button();
            this.btnKolcsonzoTorles = new System.Windows.Forms.Button();
            this.grbKolcsonzo = new System.Windows.Forms.GroupBox();
            this.grbJarmu = new System.Windows.Forms.GroupBox();
            this.BtnUjJarmu = new System.Windows.Forms.Button();
            this.btnJarmuTorles = new System.Windows.Forms.Button();
            this.btnJarmuModositas = new System.Windows.Forms.Button();
            this.grbKolcsonzes = new System.Windows.Forms.GroupBox();
            this.btnVisszahoztak = new System.Windows.Forms.Button();
            this.btnKikolcsonzik = new System.Windows.Forms.Button();
            this.txbRendszam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chbKikolcsonozheto = new System.Windows.Forms.CheckBox();
            this.grbKolcsonzo.SuspendLayout();
            this.grbJarmu.SuspendLayout();
            this.grbKolcsonzes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvTeljes
            // 
            this.lsvTeljes.FullRowSelect = true;
            this.lsvTeljes.HideSelection = false;
            this.lsvTeljes.Location = new System.Drawing.Point(12, 12);
            this.lsvTeljes.MultiSelect = false;
            this.lsvTeljes.Name = "lsvTeljes";
            this.lsvTeljes.Size = new System.Drawing.Size(683, 416);
            this.lsvTeljes.TabIndex = 0;
            this.lsvTeljes.UseCompatibleStateImageBehavior = false;
            this.lsvTeljes.SelectedIndexChanged += new System.EventHandler(this.lsvTeljes_SelectedIndexChanged);
            // 
            // btnUjKolcsonzo
            // 
            this.btnUjKolcsonzo.Location = new System.Drawing.Point(6, 21);
            this.btnUjKolcsonzo.Name = "btnUjKolcsonzo";
            this.btnUjKolcsonzo.Size = new System.Drawing.Size(214, 29);
            this.btnUjKolcsonzo.TabIndex = 1;
            this.btnUjKolcsonzo.Text = "Új kölcsönző hozzáadása";
            this.btnUjKolcsonzo.UseVisualStyleBackColor = true;
            this.btnUjKolcsonzo.Click += new System.EventHandler(this.btnUjKolcsonzo_Click);
            // 
            // btnKolcsonzoModositas
            // 
            this.btnKolcsonzoModositas.Location = new System.Drawing.Point(6, 56);
            this.btnKolcsonzoModositas.Name = "btnKolcsonzoModositas";
            this.btnKolcsonzoModositas.Size = new System.Drawing.Size(214, 29);
            this.btnKolcsonzoModositas.TabIndex = 2;
            this.btnKolcsonzoModositas.Text = "Kölcsönző módosítása";
            this.btnKolcsonzoModositas.UseVisualStyleBackColor = true;
            this.btnKolcsonzoModositas.Click += new System.EventHandler(this.btnKolcsonzoModositas_Click);
            // 
            // btnKolcsonzoTorles
            // 
            this.btnKolcsonzoTorles.Location = new System.Drawing.Point(6, 91);
            this.btnKolcsonzoTorles.Name = "btnKolcsonzoTorles";
            this.btnKolcsonzoTorles.Size = new System.Drawing.Size(214, 29);
            this.btnKolcsonzoTorles.TabIndex = 3;
            this.btnKolcsonzoTorles.Text = "Kölcsönző törlése";
            this.btnKolcsonzoTorles.UseVisualStyleBackColor = true;
            this.btnKolcsonzoTorles.Click += new System.EventHandler(this.btnKolcsonzoTorles_Click);
            // 
            // grbKolcsonzo
            // 
            this.grbKolcsonzo.Controls.Add(this.btnUjKolcsonzo);
            this.grbKolcsonzo.Controls.Add(this.btnKolcsonzoTorles);
            this.grbKolcsonzo.Controls.Add(this.btnKolcsonzoModositas);
            this.grbKolcsonzo.Location = new System.Drawing.Point(701, 12);
            this.grbKolcsonzo.Name = "grbKolcsonzo";
            this.grbKolcsonzo.Size = new System.Drawing.Size(234, 132);
            this.grbKolcsonzo.TabIndex = 4;
            this.grbKolcsonzo.TabStop = false;
            this.grbKolcsonzo.Text = "Kölcsönzők: ";
            // 
            // grbJarmu
            // 
            this.grbJarmu.Controls.Add(this.BtnUjJarmu);
            this.grbJarmu.Controls.Add(this.btnJarmuTorles);
            this.grbJarmu.Controls.Add(this.btnJarmuModositas);
            this.grbJarmu.Location = new System.Drawing.Point(701, 150);
            this.grbJarmu.Name = "grbJarmu";
            this.grbJarmu.Size = new System.Drawing.Size(234, 139);
            this.grbJarmu.TabIndex = 5;
            this.grbJarmu.TabStop = false;
            this.grbJarmu.Text = "Járművek: ";
            // 
            // BtnUjJarmu
            // 
            this.BtnUjJarmu.Location = new System.Drawing.Point(6, 21);
            this.BtnUjJarmu.Name = "BtnUjJarmu";
            this.BtnUjJarmu.Size = new System.Drawing.Size(214, 29);
            this.BtnUjJarmu.TabIndex = 1;
            this.BtnUjJarmu.Text = "Új jármű hozzáadása";
            this.BtnUjJarmu.UseVisualStyleBackColor = true;
            this.BtnUjJarmu.Click += new System.EventHandler(this.BtnUjJarmu_Click);
            // 
            // btnJarmuTorles
            // 
            this.btnJarmuTorles.Location = new System.Drawing.Point(6, 91);
            this.btnJarmuTorles.Name = "btnJarmuTorles";
            this.btnJarmuTorles.Size = new System.Drawing.Size(214, 29);
            this.btnJarmuTorles.TabIndex = 3;
            this.btnJarmuTorles.Text = "Jármű törlése";
            this.btnJarmuTorles.UseVisualStyleBackColor = true;
            this.btnJarmuTorles.Click += new System.EventHandler(this.btnJarmuTorles_Click);
            // 
            // btnJarmuModositas
            // 
            this.btnJarmuModositas.Location = new System.Drawing.Point(6, 56);
            this.btnJarmuModositas.Name = "btnJarmuModositas";
            this.btnJarmuModositas.Size = new System.Drawing.Size(214, 29);
            this.btnJarmuModositas.TabIndex = 2;
            this.btnJarmuModositas.Text = "Jármű módosítása";
            this.btnJarmuModositas.UseVisualStyleBackColor = true;
            this.btnJarmuModositas.Click += new System.EventHandler(this.btnJarmuModositas_Click);
            // 
            // grbKolcsonzes
            // 
            this.grbKolcsonzes.Controls.Add(this.btnVisszahoztak);
            this.grbKolcsonzes.Controls.Add(this.btnKikolcsonzik);
            this.grbKolcsonzes.Controls.Add(this.txbRendszam);
            this.grbKolcsonzes.Controls.Add(this.label1);
            this.grbKolcsonzes.Controls.Add(this.chbKikolcsonozheto);
            this.grbKolcsonzes.Location = new System.Drawing.Point(701, 295);
            this.grbKolcsonzes.Name = "grbKolcsonzes";
            this.grbKolcsonzes.Size = new System.Drawing.Size(234, 144);
            this.grbKolcsonzes.TabIndex = 6;
            this.grbKolcsonzes.TabStop = false;
            // 
            // btnVisszahoztak
            // 
            this.btnVisszahoztak.Location = new System.Drawing.Point(9, 104);
            this.btnVisszahoztak.Name = "btnVisszahoztak";
            this.btnVisszahoztak.Size = new System.Drawing.Size(214, 29);
            this.btnVisszahoztak.TabIndex = 5;
            this.btnVisszahoztak.Text = "Visszahozták";
            this.btnVisszahoztak.UseVisualStyleBackColor = true;
            this.btnVisszahoztak.Click += new System.EventHandler(this.btnVisszahoztak_Click);
            // 
            // btnKikolcsonzik
            // 
            this.btnKikolcsonzik.Location = new System.Drawing.Point(9, 69);
            this.btnKikolcsonzik.Name = "btnKikolcsonzik";
            this.btnKikolcsonzik.Size = new System.Drawing.Size(214, 29);
            this.btnKikolcsonzik.TabIndex = 4;
            this.btnKikolcsonzik.Text = "Kikölcsönzik";
            this.btnKikolcsonzik.UseVisualStyleBackColor = true;
            this.btnKikolcsonzik.Click += new System.EventHandler(this.btnKikolcsonzik_Click);
            // 
            // txbRendszam
            // 
            this.txbRendszam.Location = new System.Drawing.Point(87, 15);
            this.txbRendszam.Name = "txbRendszam";
            this.txbRendszam.Size = new System.Drawing.Size(133, 22);
            this.txbRendszam.TabIndex = 2;
            this.txbRendszam.Leave += new System.EventHandler(this.txbRendszam_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rendszám:";
            // 
            // chbKikolcsonozheto
            // 
            this.chbKikolcsonozheto.AutoSize = true;
            this.chbKikolcsonozheto.Location = new System.Drawing.Point(87, 43);
            this.chbKikolcsonozheto.Name = "chbKikolcsonozheto";
            this.chbKikolcsonozheto.Size = new System.Drawing.Size(127, 20);
            this.chbKikolcsonozheto.TabIndex = 0;
            this.chbKikolcsonozheto.Text = "Kikölcsönözhető";
            this.chbKikolcsonozheto.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 437);
            this.Controls.Add(this.grbKolcsonzes);
            this.Controls.Add(this.grbJarmu);
            this.Controls.Add(this.grbKolcsonzo);
            this.Controls.Add(this.lsvTeljes);
            this.Name = "Form1";
            this.Text = "Járműkölcsönzők";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grbKolcsonzo.ResumeLayout(false);
            this.grbJarmu.ResumeLayout(false);
            this.grbKolcsonzes.ResumeLayout(false);
            this.grbKolcsonzes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvTeljes;
        private System.Windows.Forms.Button btnUjKolcsonzo;
        private System.Windows.Forms.Button btnKolcsonzoModositas;
        private System.Windows.Forms.Button btnKolcsonzoTorles;
        private System.Windows.Forms.GroupBox grbKolcsonzo;
        private System.Windows.Forms.GroupBox grbJarmu;
        private System.Windows.Forms.Button BtnUjJarmu;
        private System.Windows.Forms.Button btnJarmuTorles;
        private System.Windows.Forms.Button btnJarmuModositas;
        private System.Windows.Forms.GroupBox grbKolcsonzes;
        private System.Windows.Forms.Button btnKikolcsonzik;
        private System.Windows.Forms.TextBox txbRendszam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbKikolcsonozheto;
        private System.Windows.Forms.Button btnVisszahoztak;
    }
}

