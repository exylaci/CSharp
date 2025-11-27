namespace SQLiteKapcsoltAdattablakGyakorlasJarmuvek
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCm3 = new System.Windows.Forms.Label();
            this.txbRendszam = new System.Windows.Forms.TextBox();
            this.txbMarka = new System.Windows.Forms.TextBox();
            this.txbTipus = new System.Windows.Forms.TextBox();
            this.txbSzin = new System.Windows.Forms.TextBox();
            this.numKm = new System.Windows.Forms.NumericUpDown();
            this.numCm3 = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rdbAuto = new System.Windows.Forms.RadioButton();
            this.rdbMotor = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbAutoTipus = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numKm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCm3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rendszám:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Márka:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Típus:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(88, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Szín:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Futott kilóméter:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCm3
            // 
            this.lblCm3.AutoSize = true;
            this.lblCm3.Location = new System.Drawing.Point(5, 217);
            this.lblCm3.Name = "lblCm3";
            this.lblCm3.Size = new System.Drawing.Size(114, 16);
            this.lblCm3.TabIndex = 5;
            this.lblCm3.Text = "Hengerűrtartalom:";
            this.lblCm3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCm3.Visible = false;
            // 
            // txbRendszam
            // 
            this.txbRendszam.Location = new System.Drawing.Point(129, 12);
            this.txbRendszam.Name = "txbRendszam";
            this.txbRendszam.Size = new System.Drawing.Size(162, 22);
            this.txbRendszam.TabIndex = 6;
            // 
            // txbMarka
            // 
            this.txbMarka.Location = new System.Drawing.Point(129, 40);
            this.txbMarka.Name = "txbMarka";
            this.txbMarka.Size = new System.Drawing.Size(162, 22);
            this.txbMarka.TabIndex = 7;
            // 
            // txbTipus
            // 
            this.txbTipus.Location = new System.Drawing.Point(129, 68);
            this.txbTipus.Name = "txbTipus";
            this.txbTipus.Size = new System.Drawing.Size(162, 22);
            this.txbTipus.TabIndex = 8;
            // 
            // txbSzin
            // 
            this.txbSzin.Location = new System.Drawing.Point(129, 96);
            this.txbSzin.Name = "txbSzin";
            this.txbSzin.Size = new System.Drawing.Size(162, 22);
            this.txbSzin.TabIndex = 9;
            // 
            // numKm
            // 
            this.numKm.Location = new System.Drawing.Point(130, 125);
            this.numKm.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numKm.Name = "numKm";
            this.numKm.Size = new System.Drawing.Size(161, 22);
            this.numKm.TabIndex = 12;
            // 
            // numCm3
            // 
            this.numCm3.Location = new System.Drawing.Point(129, 214);
            this.numCm3.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numCm3.Name = "numCm3";
            this.numCm3.Size = new System.Drawing.Size(161, 22);
            this.numCm3.TabIndex = 13;
            this.numCm3.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(130, 243);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(217, 243);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Mégsem";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // rdbAuto
            // 
            this.rdbAuto.AutoSize = true;
            this.rdbAuto.Location = new System.Drawing.Point(116, 9);
            this.rdbAuto.Name = "rdbAuto";
            this.rdbAuto.Size = new System.Drawing.Size(55, 20);
            this.rdbAuto.TabIndex = 16;
            this.rdbAuto.TabStop = true;
            this.rdbAuto.Text = "Autó";
            this.rdbAuto.UseVisualStyleBackColor = true;
            this.rdbAuto.CheckedChanged += new System.EventHandler(this.rdbAuto_CheckedChanged);
            // 
            // rdbMotor
            // 
            this.rdbMotor.AutoSize = true;
            this.rdbMotor.Location = new System.Drawing.Point(116, 35);
            this.rdbMotor.Name = "rdbMotor";
            this.rdbMotor.Size = new System.Drawing.Size(62, 20);
            this.rdbMotor.TabIndex = 17;
            this.rdbMotor.TabStop = true;
            this.rdbMotor.Text = "Motor";
            this.rdbMotor.UseVisualStyleBackColor = true;
            this.rdbMotor.CheckedChanged += new System.EventHandler(this.rdbMotor_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.rdbAuto);
            this.groupBox1.Controls.Add(this.rdbMotor);
            this.groupBox1.Location = new System.Drawing.Point(13, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 56);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "Jármű fajtája:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbAutoTipus
            // 
            this.cmbAutoTipus.FormattingEnabled = true;
            this.cmbAutoTipus.Location = new System.Drawing.Point(129, 214);
            this.cmbAutoTipus.Name = "cmbAutoTipus";
            this.cmbAutoTipus.Size = new System.Drawing.Size(162, 24);
            this.cmbAutoTipus.TabIndex = 19;
            this.cmbAutoTipus.Visible = false;
            // 
            // JarmuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 276);
            this.Controls.Add(this.cmbAutoTipus);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.numCm3);
            this.Controls.Add(this.numKm);
            this.Controls.Add(this.txbSzin);
            this.Controls.Add(this.txbTipus);
            this.Controls.Add(this.txbMarka);
            this.Controls.Add(this.txbRendszam);
            this.Controls.Add(this.lblCm3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "JarmuForm";
            this.Text = "JarmuForm";
            ((System.ComponentModel.ISupportInitialize)(this.numKm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCm3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCm3;
        private System.Windows.Forms.TextBox txbRendszam;
        private System.Windows.Forms.TextBox txbMarka;
        private System.Windows.Forms.TextBox txbTipus;
        private System.Windows.Forms.TextBox txbSzin;
        private System.Windows.Forms.NumericUpDown numKm;
        private System.Windows.Forms.NumericUpDown numCm3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rdbAuto;
        private System.Windows.Forms.RadioButton rdbMotor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbAutoTipus;
    }
}