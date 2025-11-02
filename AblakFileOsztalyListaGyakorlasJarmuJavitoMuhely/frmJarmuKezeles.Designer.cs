namespace AblakFileOsztalyListaGyakorlasJarmuJavitoMuhely
{
    partial class frmJarmuKezeles
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbValasztas = new System.Windows.Forms.ComboBox();
            this.txbAzonositoszam = new System.Windows.Forms.TextBox();
            this.txbRendszam = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numGyartasiEv = new System.Windows.Forms.NumericUpDown();
            this.cmbJarmuMarka = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSzarmazasiHely = new System.Windows.Forms.ComboBox();
            this.chbHasznalt = new System.Windows.Forms.CheckBox();
            this.numJavitasAra = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.grbSpecialis = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGyartasiEv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJavitasAra)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numJavitasAra);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.chbHasznalt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbSzarmazasiHely);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbJarmuMarka);
            this.groupBox1.Controls.Add(this.numGyartasiEv);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txbRendszam);
            this.groupBox1.Controls.Add(this.txbAzonositoszam);
            this.groupBox1.Controls.Add(this.cmbValasztas);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 236);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Jármű fajta kiválasztása:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Azonosítószám:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rendszám:";
            // 
            // cmbValasztas
            // 
            this.cmbValasztas.FormattingEnabled = true;
            this.cmbValasztas.Location = new System.Drawing.Point(167, 3);
            this.cmbValasztas.Name = "cmbValasztas";
            this.cmbValasztas.Size = new System.Drawing.Size(121, 24);
            this.cmbValasztas.TabIndex = 3;
            this.cmbValasztas.SelectedIndexChanged += new System.EventHandler(this.cmbValasztas_SelectedIndexChanged);
            // 
            // txbAzonositoszam
            // 
            this.txbAzonositoszam.Location = new System.Drawing.Point(167, 34);
            this.txbAzonositoszam.Name = "txbAzonositoszam";
            this.txbAzonositoszam.Size = new System.Drawing.Size(121, 22);
            this.txbAzonositoszam.TabIndex = 4;
            // 
            // txbRendszam
            // 
            this.txbRendszam.Location = new System.Drawing.Point(167, 64);
            this.txbRendszam.Name = "txbRendszam";
            this.txbRendszam.Size = new System.Drawing.Size(121, 22);
            this.txbRendszam.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Gyártási év:";
            // 
            // numGyartasiEv
            // 
            this.numGyartasiEv.Location = new System.Drawing.Point(167, 93);
            this.numGyartasiEv.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numGyartasiEv.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.numGyartasiEv.Name = "numGyartasiEv";
            this.numGyartasiEv.Size = new System.Drawing.Size(120, 22);
            this.numGyartasiEv.TabIndex = 7;
            this.numGyartasiEv.Value = new decimal(new int[] {
            2025,
            0,
            0,
            0});
            // 
            // cmbJarmuMarka
            // 
            this.cmbJarmuMarka.FormattingEnabled = true;
            this.cmbJarmuMarka.Location = new System.Drawing.Point(167, 121);
            this.cmbJarmuMarka.Name = "cmbJarmuMarka";
            this.cmbJarmuMarka.Size = new System.Drawing.Size(121, 24);
            this.cmbJarmuMarka.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(112, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Márka:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Származási hely:";
            // 
            // cmbSzarmazasiHely
            // 
            this.cmbSzarmazasiHely.FormattingEnabled = true;
            this.cmbSzarmazasiHely.Location = new System.Drawing.Point(167, 151);
            this.cmbSzarmazasiHely.Name = "cmbSzarmazasiHely";
            this.cmbSzarmazasiHely.Size = new System.Drawing.Size(121, 24);
            this.cmbSzarmazasiHely.TabIndex = 10;
            // 
            // chbHasznalt
            // 
            this.chbHasznalt.AutoSize = true;
            this.chbHasznalt.Location = new System.Drawing.Point(167, 182);
            this.chbHasznalt.Name = "chbHasznalt";
            this.chbHasznalt.Size = new System.Drawing.Size(81, 20);
            this.chbHasznalt.TabIndex = 12;
            this.chbHasznalt.Text = "Használt";
            this.chbHasznalt.UseVisualStyleBackColor = true;
            // 
            // numJavitasAra
            // 
            this.numJavitasAra.Location = new System.Drawing.Point(167, 208);
            this.numJavitasAra.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numJavitasAra.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numJavitasAra.Name = "numJavitasAra";
            this.numJavitasAra.Size = new System.Drawing.Size(120, 22);
            this.numJavitasAra.TabIndex = 14;
            this.numJavitasAra.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(84, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Javítás ára:";
            // 
            // grbSpecialis
            // 
            this.grbSpecialis.Location = new System.Drawing.Point(11, 251);
            this.grbSpecialis.Name = "grbSpecialis";
            this.grbSpecialis.Size = new System.Drawing.Size(296, 144);
            this.grbSpecialis.TabIndex = 1;
            this.grbSpecialis.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(151, 401);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(232, 401);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Mégsem";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmJarmuKezeles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 527);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grbSpecialis);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmJarmuKezeles";
            this.Text = "Jármű kezelés";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGyartasiEv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJavitasAra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbValasztas;
        private System.Windows.Forms.TextBox txbRendszam;
        private System.Windows.Forms.TextBox txbAzonositoszam;
        private System.Windows.Forms.NumericUpDown numGyartasiEv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbJarmuMarka;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSzarmazasiHely;
        private System.Windows.Forms.NumericUpDown numJavitasAra;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chbHasznalt;
        private System.Windows.Forms.GroupBox grbSpecialis;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}