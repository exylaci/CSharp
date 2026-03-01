namespace SQLiteInnerJoinPeldaJegyek
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
            this.lsb = new System.Windows.Forms.ListBox();
            this.btnUjTanulo = new System.Windows.Forms.Button();
            this.btnUjTanar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsb
            // 
            this.lsb.FormattingEnabled = true;
            this.lsb.ItemHeight = 16;
            this.lsb.Location = new System.Drawing.Point(13, 13);
            this.lsb.Name = "lsb";
            this.lsb.Size = new System.Drawing.Size(410, 596);
            this.lsb.TabIndex = 0;
            // 
            // btnUjTanulo
            // 
            this.btnUjTanulo.Location = new System.Drawing.Point(429, 13);
            this.btnUjTanulo.Name = "btnUjTanulo";
            this.btnUjTanulo.Size = new System.Drawing.Size(167, 28);
            this.btnUjTanulo.TabIndex = 1;
            this.btnUjTanulo.Text = "Új tanuló felvitele";
            this.btnUjTanulo.UseVisualStyleBackColor = true;
            this.btnUjTanulo.Click += new System.EventHandler(this.btnUjTanulo_Click);
            // 
            // btnUjTanar
            // 
            this.btnUjTanar.Location = new System.Drawing.Point(429, 47);
            this.btnUjTanar.Name = "btnUjTanar";
            this.btnUjTanar.Size = new System.Drawing.Size(167, 28);
            this.btnUjTanar.TabIndex = 2;
            this.btnUjTanar.Text = "Új tanár felvitele";
            this.btnUjTanar.UseVisualStyleBackColor = true;
            this.btnUjTanar.Click += new System.EventHandler(this.btnUjTanar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 718);
            this.Controls.Add(this.btnUjTanar);
            this.Controls.Add(this.btnUjTanulo);
            this.Controls.Add(this.lsb);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lsb;
        private System.Windows.Forms.Button btnUjTanulo;
        private System.Windows.Forms.Button btnUjTanar;
    }
}

