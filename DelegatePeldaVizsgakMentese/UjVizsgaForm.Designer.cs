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
            this.btnOK = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cím:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Feladat:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 254);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kép:";
            // 
            // txbCim
            // 
            this.txbCim.Location = new System.Drawing.Point(84, 7);
            this.txbCim.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbCim.Name = "txbCim";
            this.txbCim.Size = new System.Drawing.Size(517, 22);
            this.txbCim.TabIndex = 3;
            // 
            // txbFeladat
            // 
            this.txbFeladat.Location = new System.Drawing.Point(84, 39);
            this.txbFeladat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbFeladat.Multiline = true;
            this.txbFeladat.Name = "txbFeladat";
            this.txbFeladat.Size = new System.Drawing.Size(517, 202);
            this.txbFeladat.TabIndex = 4;
            // 
            // txbKep
            // 
            this.txbKep.Enabled = false;
            this.txbKep.Location = new System.Drawing.Point(84, 250);
            this.txbKep.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbKep.Name = "txbKep";
            this.txbKep.Size = new System.Drawing.Size(517, 22);
            this.txbKep.TabIndex = 5;
            // 
            // btnTallozas
            // 
            this.btnTallozas.Location = new System.Drawing.Point(611, 247);
            this.btnTallozas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTallozas.Name = "btnTallozas";
            this.btnTallozas.Size = new System.Drawing.Size(100, 28);
            this.btnTallozas.TabIndex = 6;
            this.btnTallozas.Text = "Tallózás";
            this.btnTallozas.UseVisualStyleBackColor = true;
            this.btnTallozas.Click += new System.EventHandler(this.btnTallozas_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(503, 298);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(611, 298);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 332);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnTallozas);
            this.Controls.Add(this.txbKep);
            this.Controls.Add(this.txbFeladat);
            this.Controls.Add(this.txbCim);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}