namespace InfoTermekekAdmin
{
    partial class UjTermekForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txbGyarto = new System.Windows.Forms.TextBox();
            this.txbMegnevezes = new System.Windows.Forms.TextBox();
            this.txbSzeriaszam = new System.Windows.Forms.TextBox();
            this.numAr = new System.Windows.Forms.NumericUpDown();
            this.cmbTermek = new System.Windows.Forms.ComboBox();
            this.cmbProcesszor = new System.Windows.Forms.ComboBox();
            this.cmbMemoria = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnMegsem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAr)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gyártó:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Megnevezés:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Szériaszám:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ár:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Termék típusa:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Processzor tokozása:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Memória típusa:";
            // 
            // txbGyarto
            // 
            this.txbGyarto.Location = new System.Drawing.Point(154, 12);
            this.txbGyarto.Name = "txbGyarto";
            this.txbGyarto.Size = new System.Drawing.Size(211, 22);
            this.txbGyarto.TabIndex = 7;
            // 
            // txbMegnevezes
            // 
            this.txbMegnevezes.Location = new System.Drawing.Point(154, 40);
            this.txbMegnevezes.Name = "txbMegnevezes";
            this.txbMegnevezes.Size = new System.Drawing.Size(211, 22);
            this.txbMegnevezes.TabIndex = 8;
            // 
            // txbSzeriaszam
            // 
            this.txbSzeriaszam.Location = new System.Drawing.Point(154, 68);
            this.txbSzeriaszam.Name = "txbSzeriaszam";
            this.txbSzeriaszam.Size = new System.Drawing.Size(211, 22);
            this.txbSzeriaszam.TabIndex = 9;
            // 
            // numAr
            // 
            this.numAr.Location = new System.Drawing.Point(154, 97);
            this.numAr.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numAr.Name = "numAr";
            this.numAr.Size = new System.Drawing.Size(211, 22);
            this.numAr.TabIndex = 10;
            // 
            // cmbTermek
            // 
            this.cmbTermek.FormattingEnabled = true;
            this.cmbTermek.Location = new System.Drawing.Point(154, 126);
            this.cmbTermek.Name = "cmbTermek";
            this.cmbTermek.Size = new System.Drawing.Size(211, 24);
            this.cmbTermek.TabIndex = 11;
            this.cmbTermek.SelectedIndexChanged += new System.EventHandler(this.cmbTermek_SelectedIndexChanged);
            // 
            // cmbProcesszor
            // 
            this.cmbProcesszor.FormattingEnabled = true;
            this.cmbProcesszor.Location = new System.Drawing.Point(154, 156);
            this.cmbProcesszor.Name = "cmbProcesszor";
            this.cmbProcesszor.Size = new System.Drawing.Size(211, 24);
            this.cmbProcesszor.TabIndex = 12;
            // 
            // cmbMemoria
            // 
            this.cmbMemoria.FormattingEnabled = true;
            this.cmbMemoria.Location = new System.Drawing.Point(154, 186);
            this.cmbMemoria.Name = "cmbMemoria";
            this.cmbMemoria.Size = new System.Drawing.Size(211, 24);
            this.cmbMemoria.TabIndex = 13;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(177, 228);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(91, 31);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnMegsem
            // 
            this.btnMegsem.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMegsem.Location = new System.Drawing.Point(274, 228);
            this.btnMegsem.Name = "btnMegsem";
            this.btnMegsem.Size = new System.Drawing.Size(91, 31);
            this.btnMegsem.TabIndex = 15;
            this.btnMegsem.Text = "Mégsem";
            this.btnMegsem.UseVisualStyleBackColor = true;
            // 
            // UjTermekForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 269);
            this.Controls.Add(this.btnMegsem);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbMemoria);
            this.Controls.Add(this.cmbProcesszor);
            this.Controls.Add(this.cmbTermek);
            this.Controls.Add(this.numAr);
            this.Controls.Add(this.txbSzeriaszam);
            this.Controls.Add(this.txbMegnevezes);
            this.Controls.Add(this.txbGyarto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UjTermekForm";
            this.Text = "UjTermekForm";
            ((System.ComponentModel.ISupportInitialize)(this.numAr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbGyarto;
        private System.Windows.Forms.TextBox txbMegnevezes;
        private System.Windows.Forms.TextBox txbSzeriaszam;
        private System.Windows.Forms.NumericUpDown numAr;
        private System.Windows.Forms.ComboBox cmbTermek;
        private System.Windows.Forms.ComboBox cmbProcesszor;
        private System.Windows.Forms.ComboBox cmbMemoria;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnMegsem;
    }
}