namespace MySqlDockerGyakorlasJarmukolcsonzo
{
    partial class FormMain
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
            this.lsbKolcsonzok = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lsbJarmuvek = new System.Windows.Forms.ListBox();
            this.btnUjKolcsonzo = new System.Windows.Forms.Button();
            this.btnKolcsonzoModositas = new System.Windows.Forms.Button();
            this.btnKolcsonzoTorles = new System.Windows.Forms.Button();
            this.btnUjJarmu = new System.Windows.Forms.Button();
            this.btnJarmuModositas = new System.Windows.Forms.Button();
            this.btnJarmuTorles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsbKolcsonzok
            // 
            this.lsbKolcsonzok.FormattingEnabled = true;
            this.lsbKolcsonzok.ItemHeight = 16;
            this.lsbKolcsonzok.Location = new System.Drawing.Point(15, 28);
            this.lsbKolcsonzok.Name = "lsbKolcsonzok";
            this.lsbKolcsonzok.Size = new System.Drawing.Size(235, 324);
            this.lsbKolcsonzok.TabIndex = 0;
            this.lsbKolcsonzok.SelectedIndexChanged += new System.EventHandler(this.lsbKolcsonzok_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kölcsönzők:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Járművek:";
            // 
            // lsbJarmuvek
            // 
            this.lsbJarmuvek.FormattingEnabled = true;
            this.lsbJarmuvek.ItemHeight = 16;
            this.lsbJarmuvek.Location = new System.Drawing.Point(286, 28);
            this.lsbJarmuvek.Name = "lsbJarmuvek";
            this.lsbJarmuvek.Size = new System.Drawing.Size(235, 324);
            this.lsbJarmuvek.TabIndex = 3;
            // 
            // btnUjKolcsonzo
            // 
            this.btnUjKolcsonzo.Location = new System.Drawing.Point(15, 359);
            this.btnUjKolcsonzo.Name = "btnUjKolcsonzo";
            this.btnUjKolcsonzo.Size = new System.Drawing.Size(235, 30);
            this.btnUjKolcsonzo.TabIndex = 4;
            this.btnUjKolcsonzo.Text = "Új kölcsönző felvétele";
            this.btnUjKolcsonzo.UseVisualStyleBackColor = true;
            this.btnUjKolcsonzo.Click += new System.EventHandler(this.btnUjKolcsonzo_Click);
            // 
            // btnKolcsonzoModositas
            // 
            this.btnKolcsonzoModositas.Location = new System.Drawing.Point(15, 395);
            this.btnKolcsonzoModositas.Name = "btnKolcsonzoModositas";
            this.btnKolcsonzoModositas.Size = new System.Drawing.Size(235, 30);
            this.btnKolcsonzoModositas.TabIndex = 5;
            this.btnKolcsonzoModositas.Text = "Kölcsönző módosítása";
            this.btnKolcsonzoModositas.UseVisualStyleBackColor = true;
            this.btnKolcsonzoModositas.Click += new System.EventHandler(this.btnKolcsonzoModositas_Click);
            // 
            // btnKolcsonzoTorles
            // 
            this.btnKolcsonzoTorles.Location = new System.Drawing.Point(15, 431);
            this.btnKolcsonzoTorles.Name = "btnKolcsonzoTorles";
            this.btnKolcsonzoTorles.Size = new System.Drawing.Size(235, 30);
            this.btnKolcsonzoTorles.TabIndex = 6;
            this.btnKolcsonzoTorles.Text = "Kölcsönző törlése";
            this.btnKolcsonzoTorles.UseVisualStyleBackColor = true;
            this.btnKolcsonzoTorles.Click += new System.EventHandler(this.btnKolcsonzoTorles_Click);
            // 
            // btnUjJarmu
            // 
            this.btnUjJarmu.Location = new System.Drawing.Point(286, 359);
            this.btnUjJarmu.Name = "btnUjJarmu";
            this.btnUjJarmu.Size = new System.Drawing.Size(235, 30);
            this.btnUjJarmu.TabIndex = 7;
            this.btnUjJarmu.Text = "Új jármű felvétele";
            this.btnUjJarmu.UseVisualStyleBackColor = true;
            this.btnUjJarmu.Click += new System.EventHandler(this.btnUjJarmu_Click);
            // 
            // btnJarmuModositas
            // 
            this.btnJarmuModositas.Location = new System.Drawing.Point(286, 395);
            this.btnJarmuModositas.Name = "btnJarmuModositas";
            this.btnJarmuModositas.Size = new System.Drawing.Size(235, 30);
            this.btnJarmuModositas.TabIndex = 8;
            this.btnJarmuModositas.Text = "Jármű módosítása";
            this.btnJarmuModositas.UseVisualStyleBackColor = true;
            this.btnJarmuModositas.Click += new System.EventHandler(this.btnJarmuModositas_Click);
            // 
            // btnJarmuTorles
            // 
            this.btnJarmuTorles.Location = new System.Drawing.Point(286, 431);
            this.btnJarmuTorles.Name = "btnJarmuTorles";
            this.btnJarmuTorles.Size = new System.Drawing.Size(235, 30);
            this.btnJarmuTorles.TabIndex = 9;
            this.btnJarmuTorles.Text = "Jármű törlése";
            this.btnJarmuTorles.UseVisualStyleBackColor = true;
            this.btnJarmuTorles.Click += new System.EventHandler(this.btnJarmuTorles_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 475);
            this.Controls.Add(this.btnJarmuTorles);
            this.Controls.Add(this.btnJarmuModositas);
            this.Controls.Add(this.btnUjJarmu);
            this.Controls.Add(this.btnKolcsonzoTorles);
            this.Controls.Add(this.btnKolcsonzoModositas);
            this.Controls.Add(this.btnUjKolcsonzo);
            this.Controls.Add(this.lsbJarmuvek);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsbKolcsonzok);
            this.Name = "FormMain";
            this.Text = "Járműkölcsönzők";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbKolcsonzok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lsbJarmuvek;
        private System.Windows.Forms.Button btnUjKolcsonzo;
        private System.Windows.Forms.Button btnKolcsonzoModositas;
        private System.Windows.Forms.Button btnKolcsonzoTorles;
        private System.Windows.Forms.Button btnUjJarmu;
        private System.Windows.Forms.Button btnJarmuModositas;
        private System.Windows.Forms.Button btnJarmuTorles;
    }
}

