namespace DelegateGyakorlasAutokolcsonzo
{
    partial class UjJarmu
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
            this.numKmOra = new System.Windows.Forms.NumericUpDown();
            this.chbKolcsonozheto = new System.Windows.Forms.CheckBox();
            this.grpTipus = new System.Windows.Forms.GroupBox();
            this.rdbMotor = new System.Windows.Forms.RadioButton();
            this.rdbAuto = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.grbAuto = new System.Windows.Forms.GroupBox();
            this.cmbMotorTipusa = new System.Windows.Forms.ComboBox();
            this.grbMotor = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numKobcenti = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txbRendszam = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numKmOra)).BeginInit();
            this.grpTipus.SuspendLayout();
            this.grbAuto.SuspendLayout();
            this.grbMotor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKobcenti)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rendszám:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "km óra állása:";
            // 
            // numKmOra
            // 
            this.numKmOra.Location = new System.Drawing.Point(95, 37);
            this.numKmOra.Name = "numKmOra";
            this.numKmOra.Size = new System.Drawing.Size(120, 20);
            this.numKmOra.TabIndex = 3;
            // 
            // chbKolcsonozheto
            // 
            this.chbKolcsonozheto.AutoSize = true;
            this.chbKolcsonozheto.Location = new System.Drawing.Point(95, 64);
            this.chbKolcsonozheto.Name = "chbKolcsonozheto";
            this.chbKolcsonozheto.Size = new System.Drawing.Size(103, 17);
            this.chbKolcsonozheto.TabIndex = 4;
            this.chbKolcsonozheto.Text = "kikölcsönözhető";
            this.chbKolcsonozheto.UseVisualStyleBackColor = true;
            // 
            // grpTipus
            // 
            this.grpTipus.Controls.Add(this.rdbMotor);
            this.grpTipus.Controls.Add(this.rdbAuto);
            this.grpTipus.Location = new System.Drawing.Point(12, 87);
            this.grpTipus.Name = "grpTipus";
            this.grpTipus.Size = new System.Drawing.Size(93, 70);
            this.grpTipus.TabIndex = 5;
            this.grpTipus.TabStop = false;
            this.grpTipus.Text = "Jármű típusa:";
            // 
            // rdbMotor
            // 
            this.rdbMotor.AutoSize = true;
            this.rdbMotor.Location = new System.Drawing.Point(7, 43);
            this.rdbMotor.Name = "rdbMotor";
            this.rdbMotor.Size = new System.Drawing.Size(51, 17);
            this.rdbMotor.TabIndex = 1;
            this.rdbMotor.TabStop = true;
            this.rdbMotor.Text = "motor";
            this.rdbMotor.UseVisualStyleBackColor = true;
            // 
            // rdbAuto
            // 
            this.rdbAuto.AutoSize = true;
            this.rdbAuto.Location = new System.Drawing.Point(7, 20);
            this.rdbAuto.Name = "rdbAuto";
            this.rdbAuto.Size = new System.Drawing.Size(46, 17);
            this.rdbAuto.TabIndex = 0;
            this.rdbAuto.TabStop = true;
            this.rdbAuto.Text = "autó";
            this.rdbAuto.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "motor típusa:";
            // 
            // grbAuto
            // 
            this.grbAuto.Controls.Add(this.cmbMotorTipusa);
            this.grbAuto.Controls.Add(this.label3);
            this.grbAuto.Location = new System.Drawing.Point(12, 160);
            this.grbAuto.Name = "grbAuto";
            this.grbAuto.Size = new System.Drawing.Size(216, 46);
            this.grbAuto.TabIndex = 7;
            this.grbAuto.TabStop = false;
            // 
            // cmbMotorTipusa
            // 
            this.cmbMotorTipusa.FormattingEnabled = true;
            this.cmbMotorTipusa.Location = new System.Drawing.Point(83, 19);
            this.cmbMotorTipusa.Name = "cmbMotorTipusa";
            this.cmbMotorTipusa.Size = new System.Drawing.Size(120, 21);
            this.cmbMotorTipusa.TabIndex = 7;
            // 
            // grbMotor
            // 
            this.grbMotor.Controls.Add(this.label5);
            this.grbMotor.Controls.Add(this.numKobcenti);
            this.grbMotor.Controls.Add(this.label4);
            this.grbMotor.Location = new System.Drawing.Point(12, 208);
            this.grbMotor.Name = "grbMotor";
            this.grbMotor.Size = new System.Drawing.Size(216, 46);
            this.grbMotor.TabIndex = 8;
            this.grbMotor.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "köbcenti";
            // 
            // numKobcenti
            // 
            this.numKobcenti.Location = new System.Drawing.Point(83, 19);
            this.numKobcenti.Name = "numKobcenti";
            this.numKobcenti.Size = new System.Drawing.Size(66, 20);
            this.numKobcenti.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "motor mérete:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(72, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Hozzáad";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(153, 265);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Mégsem";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // txbRendszam
            // 
            this.txbRendszam.Location = new System.Drawing.Point(94, 9);
            this.txbRendszam.Name = "txbRendszam";
            this.txbRendszam.Size = new System.Drawing.Size(121, 20);
            this.txbRendszam.TabIndex = 11;
            // 
            // UjJarmu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 298);
            this.Controls.Add(this.txbRendszam);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grbMotor);
            this.Controls.Add(this.grbAuto);
            this.Controls.Add(this.grpTipus);
            this.Controls.Add(this.chbKolcsonozheto);
            this.Controls.Add(this.numKmOra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UjJarmu";
            this.Text = "Új jármű felvétele";
            ((System.ComponentModel.ISupportInitialize)(this.numKmOra)).EndInit();
            this.grpTipus.ResumeLayout(false);
            this.grpTipus.PerformLayout();
            this.grbAuto.ResumeLayout(false);
            this.grbAuto.PerformLayout();
            this.grbMotor.ResumeLayout(false);
            this.grbMotor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKobcenti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numKmOra;
        private System.Windows.Forms.CheckBox chbKolcsonozheto;
        private System.Windows.Forms.GroupBox grpTipus;
        private System.Windows.Forms.RadioButton rdbMotor;
        private System.Windows.Forms.RadioButton rdbAuto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grbAuto;
        private System.Windows.Forms.ComboBox cmbMotorTipusa;
        private System.Windows.Forms.GroupBox grbMotor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numKobcenti;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txbRendszam;
    }
}