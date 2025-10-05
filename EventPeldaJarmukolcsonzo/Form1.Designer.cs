namespace EventPeldaJarmukolcsonzo
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
            this.lsbJarmuvek = new System.Windows.Forms.ListBox();
            this.btnUj = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbRendszam = new System.Windows.Forms.TextBox();
            this.chbKolcsonzes = new System.Windows.Forms.CheckBox();
            this.btnBeallit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsbJarmuvek
            // 
            this.lsbJarmuvek.FormattingEnabled = true;
            this.lsbJarmuvek.ItemHeight = 16;
            this.lsbJarmuvek.Location = new System.Drawing.Point(13, 13);
            this.lsbJarmuvek.Name = "lsbJarmuvek";
            this.lsbJarmuvek.Size = new System.Drawing.Size(313, 420);
            this.lsbJarmuvek.TabIndex = 0;
            // 
            // btnUj
            // 
            this.btnUj.Location = new System.Drawing.Point(342, 13);
            this.btnUj.Name = "btnUj";
            this.btnUj.Size = new System.Drawing.Size(195, 32);
            this.btnUj.TabIndex = 1;
            this.btnUj.Text = "Új jármű hozzáadása";
            this.btnUj.UseVisualStyleBackColor = true;
            this.btnUj.Click += new System.EventHandler(this.btnUj_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBeallit);
            this.groupBox1.Controls.Add(this.chbKolcsonzes);
            this.groupBox1.Controls.Add(this.txbRendszam);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(342, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 118);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kölcsönzés";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rendszám:";
            // 
            // txbRendszam
            // 
            this.txbRendszam.Location = new System.Drawing.Point(87, 15);
            this.txbRendszam.Name = "txbRendszam";
            this.txbRendszam.Size = new System.Drawing.Size(98, 22);
            this.txbRendszam.TabIndex = 1;
            // 
            // chbKolcsonzes
            // 
            this.chbKolcsonzes.AutoSize = true;
            this.chbKolcsonzes.Location = new System.Drawing.Point(87, 44);
            this.chbKolcsonzes.Name = "chbKolcsonzes";
            this.chbKolcsonzes.Size = new System.Drawing.Size(98, 20);
            this.chbKolcsonzes.TabIndex = 2;
            this.chbKolcsonzes.Text = "Kölcsönzés";
            this.chbKolcsonzes.UseVisualStyleBackColor = true;
            // 
            // btnBeallit
            // 
            this.btnBeallit.Location = new System.Drawing.Point(9, 70);
            this.btnBeallit.Name = "btnBeallit";
            this.btnBeallit.Size = new System.Drawing.Size(176, 32);
            this.btnBeallit.TabIndex = 3;
            this.btnBeallit.Text = "Beállítás";
            this.btnBeallit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUj);
            this.Controls.Add(this.lsbJarmuvek);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lsbJarmuvek;
        private System.Windows.Forms.Button btnUj;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBeallit;
        private System.Windows.Forms.CheckBox chbKolcsonzes;
        private System.Windows.Forms.TextBox txbRendszam;
        private System.Windows.Forms.Label label1;
    }
}

