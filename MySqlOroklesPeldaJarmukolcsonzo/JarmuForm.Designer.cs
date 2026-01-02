namespace MySqlOroklesPeldaJarmukolcsonzo
{
    partial class JarmuForm
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
            this.txbRendszam = new System.Windows.Forms.TextBox();
            this.txbMarka = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbTipus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chbFoglalt = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbJarmuTipus = new System.Windows.Forms.ComboBox();
            this.grbSzemelygepjarmu = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numSzemelyek = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.grbKishaszongepjarmu = new System.Windows.Forms.GroupBox();
            this.numTeher = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbAutoTipus = new System.Windows.Forms.ComboBox();
            this.grbSzemelygepjarmu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSzemelyek)).BeginInit();
            this.grbKishaszongepjarmu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTeher)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rendszám:";
            // 
            // txbRendszam
            // 
            this.txbRendszam.Location = new System.Drawing.Point(109, 15);
            this.txbRendszam.Name = "txbRendszam";
            this.txbRendszam.Size = new System.Drawing.Size(260, 22);
            this.txbRendszam.TabIndex = 1;
            // 
            // txbMarka
            // 
            this.txbMarka.Location = new System.Drawing.Point(109, 43);
            this.txbMarka.Name = "txbMarka";
            this.txbMarka.Size = new System.Drawing.Size(260, 22);
            this.txbMarka.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Márka:";
            // 
            // txbTipus
            // 
            this.txbTipus.Location = new System.Drawing.Point(109, 71);
            this.txbTipus.Name = "txbTipus";
            this.txbTipus.Size = new System.Drawing.Size(260, 22);
            this.txbTipus.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Típus:";
            // 
            // chbFoglalt
            // 
            this.chbFoglalt.AutoSize = true;
            this.chbFoglalt.Location = new System.Drawing.Point(109, 100);
            this.chbFoglalt.Name = "chbFoglalt";
            this.chbFoglalt.Size = new System.Drawing.Size(70, 20);
            this.chbFoglalt.TabIndex = 6;
            this.chbFoglalt.Text = "Foglalt";
            this.chbFoglalt.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Jatmű típusa:";
            // 
            // cmbJarmuTipus
            // 
            this.cmbJarmuTipus.FormattingEnabled = true;
            this.cmbJarmuTipus.Location = new System.Drawing.Point(107, 126);
            this.cmbJarmuTipus.Name = "cmbJarmuTipus";
            this.cmbJarmuTipus.Size = new System.Drawing.Size(262, 24);
            this.cmbJarmuTipus.TabIndex = 8;
            this.cmbJarmuTipus.SelectedIndexChanged += new System.EventHandler(this.cmbJarmuTipus_SelectedIndexChanged);
            // 
            // grbSzemelygepjarmu
            // 
            this.grbSzemelygepjarmu.Controls.Add(this.cmbAutoTipus);
            this.grbSzemelygepjarmu.Controls.Add(this.label6);
            this.grbSzemelygepjarmu.Controls.Add(this.numSzemelyek);
            this.grbSzemelygepjarmu.Controls.Add(this.label5);
            this.grbSzemelygepjarmu.Location = new System.Drawing.Point(12, 162);
            this.grbSzemelygepjarmu.Name = "grbSzemelygepjarmu";
            this.grbSzemelygepjarmu.Size = new System.Drawing.Size(369, 79);
            this.grbSzemelygepjarmu.TabIndex = 9;
            this.grbSzemelygepjarmu.TabStop = false;
            this.grbSzemelygepjarmu.Text = "Személygépjármű";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(258, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Maximálisan szállítható személyek száma:";
            // 
            // numSzemelyek
            // 
            this.numSzemelyek.Location = new System.Drawing.Point(292, 18);
            this.numSzemelyek.Name = "numSzemelyek";
            this.numSzemelyek.Size = new System.Drawing.Size(65, 22);
            this.numSzemelyek.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Személyautó típusa:";
            // 
            // grbKishaszongepjarmu
            // 
            this.grbKishaszongepjarmu.Controls.Add(this.label7);
            this.grbKishaszongepjarmu.Controls.Add(this.numTeher);
            this.grbKishaszongepjarmu.Controls.Add(this.label8);
            this.grbKishaszongepjarmu.Location = new System.Drawing.Point(12, 247);
            this.grbKishaszongepjarmu.Name = "grbKishaszongepjarmu";
            this.grbKishaszongepjarmu.Size = new System.Drawing.Size(369, 55);
            this.grbKishaszongepjarmu.TabIndex = 13;
            this.grbKishaszongepjarmu.TabStop = false;
            this.grbKishaszongepjarmu.Text = "Kishaszongépjármű";
            // 
            // numTeher
            // 
            this.numTeher.Location = new System.Drawing.Point(177, 23);
            this.numTeher.Name = "numTeher";
            this.numTeher.Size = new System.Drawing.Size(152, 22);
            this.numTeher.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Maximális terhelhetőség:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(335, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "kg";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(145, 309);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(104, 27);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(265, 309);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 27);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Mégsem";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cmbAutoTipus
            // 
            this.cmbAutoTipus.FormattingEnabled = true;
            this.cmbAutoTipus.Location = new System.Drawing.Point(149, 46);
            this.cmbAutoTipus.Name = "cmbAutoTipus";
            this.cmbAutoTipus.Size = new System.Drawing.Size(208, 24);
            this.cmbAutoTipus.TabIndex = 16;
            // 
            // JarmuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 345);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grbKishaszongepjarmu);
            this.Controls.Add(this.grbSzemelygepjarmu);
            this.Controls.Add(this.cmbJarmuTipus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chbFoglalt);
            this.Controls.Add(this.txbTipus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbMarka);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbRendszam);
            this.Controls.Add(this.label1);
            this.Name = "JarmuForm";
            this.Text = "JarmuForm";
            this.grbSzemelygepjarmu.ResumeLayout(false);
            this.grbSzemelygepjarmu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSzemelyek)).EndInit();
            this.grbKishaszongepjarmu.ResumeLayout(false);
            this.grbKishaszongepjarmu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTeher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbRendszam;
        private System.Windows.Forms.TextBox txbMarka;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbTipus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbFoglalt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbJarmuTipus;
        private System.Windows.Forms.GroupBox grbSzemelygepjarmu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numSzemelyek;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grbKishaszongepjarmu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numTeher;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbAutoTipus;
    }
}