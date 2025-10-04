namespace InfoTermekekAdmin
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
            this.lsbTermekek = new System.Windows.Forms.ListBox();
            this.btnUj = new System.Windows.Forms.Button();
            this.btnModositas = new System.Windows.Forms.Button();
            this.btnTorles = new System.Windows.Forms.Button();
            this.btnMentes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsbTermekek
            // 
            this.lsbTermekek.FormattingEnabled = true;
            this.lsbTermekek.ItemHeight = 16;
            this.lsbTermekek.Location = new System.Drawing.Point(12, 12);
            this.lsbTermekek.Name = "lsbTermekek";
            this.lsbTermekek.Size = new System.Drawing.Size(266, 228);
            this.lsbTermekek.TabIndex = 0;
            // 
            // btnUj
            // 
            this.btnUj.Location = new System.Drawing.Point(285, 13);
            this.btnUj.Name = "btnUj";
            this.btnUj.Size = new System.Drawing.Size(145, 31);
            this.btnUj.TabIndex = 1;
            this.btnUj.Text = "Új termék felvétele";
            this.btnUj.UseVisualStyleBackColor = true;
            this.btnUj.Click += new System.EventHandler(this.btnUj_Click);
            // 
            // btnModositas
            // 
            this.btnModositas.Location = new System.Drawing.Point(285, 50);
            this.btnModositas.Name = "btnModositas";
            this.btnModositas.Size = new System.Drawing.Size(145, 31);
            this.btnModositas.TabIndex = 2;
            this.btnModositas.Text = "Termék módosítása";
            this.btnModositas.UseVisualStyleBackColor = true;
            this.btnModositas.Click += new System.EventHandler(this.btnModositas_Click);
            // 
            // btnTorles
            // 
            this.btnTorles.Location = new System.Drawing.Point(285, 87);
            this.btnTorles.Name = "btnTorles";
            this.btnTorles.Size = new System.Drawing.Size(145, 31);
            this.btnTorles.TabIndex = 3;
            this.btnTorles.Text = "Termék törlése";
            this.btnTorles.UseVisualStyleBackColor = true;
            this.btnTorles.Click += new System.EventHandler(this.btnTorles_Click);
            // 
            // btnMentes
            // 
            this.btnMentes.Location = new System.Drawing.Point(284, 124);
            this.btnMentes.Name = "btnMentes";
            this.btnMentes.Size = new System.Drawing.Size(145, 31);
            this.btnMentes.TabIndex = 4;
            this.btnMentes.Text = "Mentés";
            this.btnMentes.UseVisualStyleBackColor = true;
            this.btnMentes.Click += new System.EventHandler(this.btnMentes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 252);
            this.Controls.Add(this.btnMentes);
            this.Controls.Add(this.btnTorles);
            this.Controls.Add(this.btnModositas);
            this.Controls.Add(this.btnUj);
            this.Controls.Add(this.lsbTermekek);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lsbTermekek;
        private System.Windows.Forms.Button btnUj;
        private System.Windows.Forms.Button btnModositas;
        private System.Windows.Forms.Button btnTorles;
        private System.Windows.Forms.Button btnMentes;
    }
}

