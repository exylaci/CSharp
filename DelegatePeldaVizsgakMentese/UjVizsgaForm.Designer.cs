namespace DelegatePeldaVizsgakMentese
{
    partial class UjVizsgaForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbCim = new System.Windows.Forms.TextBox();
            this.txbFeladat = new System.Windows.Forms.TextBox();
            this.txbKep = new System.Windows.Forms.TextBox();
            this.btnTallozas = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cím:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Feladat:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kép:";
            // 
            // txbCim
            // 
            this.txbCim.Location = new System.Drawing.Point(63, 6);
            this.txbCim.Name = "txbCim";
            this.txbCim.Size = new System.Drawing.Size(389, 20);
            this.txbCim.TabIndex = 3;
            // 
            // txbFeladat
            // 
            this.txbFeladat.Location = new System.Drawing.Point(63, 32);
            this.txbFeladat.Multiline = true;
            this.txbFeladat.Name = "txbFeladat";
            this.txbFeladat.Size = new System.Drawing.Size(389, 165);
            this.txbFeladat.TabIndex = 4;
            // 
            // txbKep
            // 
            this.txbKep.Enabled = false;
            this.txbKep.Location = new System.Drawing.Point(63, 203);
            this.txbKep.Name = "txbKep";
            this.txbKep.Size = new System.Drawing.Size(389, 20);
            this.txbKep.TabIndex = 5;
            // 
            // btnTallozas
            // 
            this.btnTallozas.Location = new System.Drawing.Point(458, 201);
            this.btnTallozas.Name = "btnTallozas";
            this.btnTallozas.Size = new System.Drawing.Size(75, 23);
            this.btnTallozas.TabIndex = 6;
            this.btnTallozas.Text = "Tallózás";
            this.btnTallozas.UseVisualStyleBackColor = true;
            this.btnTallozas.Click += new System.EventHandler(this.btnTallozas_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(377, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(458, 242);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Mégsem";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "JPEG képek|*.jpg";
            // 
            // UjVizsgaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 270);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTallozas);
            this.Controls.Add(this.txbKep);
            this.Controls.Add(this.txbFeladat);
            this.Controls.Add(this.txbCim);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UjVizsgaForm";
            this.Text = "Új vizsga létrehozása";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbCim;
        private System.Windows.Forms.TextBox txbFeladat;
        private System.Windows.Forms.TextBox txbKep;
        private System.Windows.Forms.Button btnTallozas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}