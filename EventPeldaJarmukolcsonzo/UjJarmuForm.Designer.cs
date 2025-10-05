namespace EventPeldaJarmukolcsonzo
{
    partial class UjJarmuForm
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
            this.cmbJarmuTipus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txbRendszam = new System.Windows.Forms.TextBox();
            this.numKm = new System.Windows.Forms.NumericUpDown();
            this.cmbMotorTipus = new System.Windows.Forms.ComboBox();
            this.numHenger = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnMegsem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numKm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHenger)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbJarmuTipus
            // 
            this.cmbJarmuTipus.FormattingEnabled = true;
            this.cmbJarmuTipus.Location = new System.Drawing.Point(12, 12);
            this.cmbJarmuTipus.Name = "cmbJarmuTipus";
            this.cmbJarmuTipus.Size = new System.Drawing.Size(229, 24);
            this.cmbJarmuTipus.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rendszám:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Futott km:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Motor típusa:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Hengerürtartalom:";
            // 
            // txbRendszam
            // 
            this.txbRendszam.Location = new System.Drawing.Point(132, 48);
            this.txbRendszam.Name = "txbRendszam";
            this.txbRendszam.Size = new System.Drawing.Size(109, 22);
            this.txbRendszam.TabIndex = 5;
            // 
            // numKm
            // 
            this.numKm.Location = new System.Drawing.Point(132, 85);
            this.numKm.Name = "numKm";
            this.numKm.Size = new System.Drawing.Size(109, 22);
            this.numKm.TabIndex = 6;
            // 
            // cmbMotorTipus
            // 
            this.cmbMotorTipus.FormattingEnabled = true;
            this.cmbMotorTipus.Location = new System.Drawing.Point(132, 119);
            this.cmbMotorTipus.Name = "cmbMotorTipus";
            this.cmbMotorTipus.Size = new System.Drawing.Size(109, 24);
            this.cmbMotorTipus.TabIndex = 7;
            // 
            // numHenger
            // 
            this.numHenger.Location = new System.Drawing.Point(132, 160);
            this.numHenger.Name = "numHenger";
            this.numHenger.Size = new System.Drawing.Size(109, 22);
            this.numHenger.TabIndex = 8;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(61, 205);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 30);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnMegsem
            // 
            this.btnMegsem.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMegsem.Location = new System.Drawing.Point(154, 205);
            this.btnMegsem.Name = "btnMegsem";
            this.btnMegsem.Size = new System.Drawing.Size(87, 30);
            this.btnMegsem.TabIndex = 10;
            this.btnMegsem.Text = "Mégsem";
            this.btnMegsem.UseVisualStyleBackColor = true;
            // 
            // UjJarmuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 250);
            this.Controls.Add(this.btnMegsem);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.numHenger);
            this.Controls.Add(this.cmbMotorTipus);
            this.Controls.Add(this.numKm);
            this.Controls.Add(this.txbRendszam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbJarmuTipus);
            this.Name = "UjJarmuForm";
            this.Text = "UjJarmuForm";
            ((System.ComponentModel.ISupportInitialize)(this.numKm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHenger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbJarmuTipus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbRendszam;
        private System.Windows.Forms.NumericUpDown numKm;
        private System.Windows.Forms.ComboBox cmbMotorTipus;
        private System.Windows.Forms.NumericUpDown numHenger;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnMegsem;
    }
}