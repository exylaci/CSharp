namespace AblakFileOsztalyListaGyakorlasJarmuJavitoMuhely
{
    partial class frmMuhelyKezelese
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
            this.cbVasarnap = new System.Windows.Forms.CheckBox();
            this.numJarmuvekMaxSzama = new System.Windows.Forms.NumericUpDown();
            this.tbUtcaHazszam = new System.Windows.Forms.TextBox();
            this.tbHelyseg = new System.Windows.Forms.TextBox();
            this.numIranyitoSzam = new System.Windows.Forms.NumericUpDown();
            this.txtMuhelySzam = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numJarmuvekMaxSzama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIranyitoSzam)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbVasarnap);
            this.groupBox1.Controls.Add(this.numJarmuvekMaxSzama);
            this.groupBox1.Controls.Add(this.tbUtcaHazszam);
            this.groupBox1.Controls.Add(this.tbHelyseg);
            this.groupBox1.Controls.Add(this.numIranyitoSzam);
            this.groupBox1.Controls.Add(this.txtMuhelySzam);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 206);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Műhelyadatok";
            // 
            // cbVasarnap
            // 
            this.cbVasarnap.AutoSize = true;
            this.cbVasarnap.Location = new System.Drawing.Point(138, 172);
            this.cbVasarnap.Name = "cbVasarnap";
            this.cbVasarnap.Size = new System.Drawing.Size(139, 20);
            this.cbVasarnap.TabIndex = 11;
            this.cbVasarnap.Text = "Vasárnap is nyitva";
            this.cbVasarnap.UseVisualStyleBackColor = true;
            // 
            // numJarmuvekMaxSzama
            // 
            this.numJarmuvekMaxSzama.Location = new System.Drawing.Point(140, 143);
            this.numJarmuvekMaxSzama.Name = "numJarmuvekMaxSzama";
            this.numJarmuvekMaxSzama.Size = new System.Drawing.Size(85, 22);
            this.numJarmuvekMaxSzama.TabIndex = 10;
            // 
            // tbUtcaHazszam
            // 
            this.tbUtcaHazszam.Location = new System.Drawing.Point(199, 115);
            this.tbUtcaHazszam.Name = "tbUtcaHazszam";
            this.tbUtcaHazszam.Size = new System.Drawing.Size(229, 22);
            this.tbUtcaHazszam.TabIndex = 9;
            // 
            // tbHelyseg
            // 
            this.tbHelyseg.Location = new System.Drawing.Point(200, 87);
            this.tbHelyseg.Name = "tbHelyseg";
            this.tbHelyseg.Size = new System.Drawing.Size(229, 22);
            this.tbHelyseg.TabIndex = 8;
            // 
            // numIranyitoSzam
            // 
            this.numIranyitoSzam.Location = new System.Drawing.Point(199, 60);
            this.numIranyitoSzam.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numIranyitoSzam.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numIranyitoSzam.Name = "numIranyitoSzam";
            this.numIranyitoSzam.Size = new System.Drawing.Size(85, 22);
            this.numIranyitoSzam.TabIndex = 7;
            this.numIranyitoSzam.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // txtMuhelySzam
            // 
            this.txtMuhelySzam.AutoSize = true;
            this.txtMuhelySzam.Location = new System.Drawing.Point(108, 23);
            this.txtMuhelySzam.Name = "txtMuhelySzam";
            this.txtMuhelySzam.Size = new System.Drawing.Size(89, 16);
            this.txtMuhelySzam.TabIndex = 6;
            this.txtMuhelySzam.Text = "muhely_szam";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Maximális járművek:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "utca, házszám:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "helység:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "irányítószám:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Műhely címe:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Műhely száma:";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(296, 224);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(377, 224);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Mégsem";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmMuhelyKezelese
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 255);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMuhelyKezelese";
            this.Text = "Műhely kezelése";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numJarmuvekMaxSzama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIranyitoSzam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbVasarnap;
        private System.Windows.Forms.NumericUpDown numJarmuvekMaxSzama;
        private System.Windows.Forms.TextBox tbUtcaHazszam;
        private System.Windows.Forms.TextBox tbHelyseg;
        private System.Windows.Forms.NumericUpDown numIranyitoSzam;
        private System.Windows.Forms.Label txtMuhelySzam;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}