namespace MySqlDockerGyakorlasJarmukolcsonzo
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
            this.txbKolcsonzo = new System.Windows.Forms.TextBox();
            this.txbId = new System.Windows.Forms.TextBox();
            this.txbRendszam = new System.Windows.Forms.TextBox();
            this.txbMarka = new System.Windows.Forms.TextBox();
            this.cmbTipus = new System.Windows.Forms.ComboBox();
            this.chbFoglalt = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbKialakitas = new System.Windows.Forms.ComboBox();
            this.lblSzallithatoTeherheto = new System.Windows.Forms.Label();
            this.lblKialakitas = new System.Windows.Forms.Label();
            this.lblMertekegyseg = new System.Windows.Forms.Label();
            this.num = new System.Windows.Forms.NumericUpDown();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Jármű ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rendszám:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Márka:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Típus:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Kölcsönző:";
            // 
            // txbKolcsonzo
            // 
            this.txbKolcsonzo.Location = new System.Drawing.Point(93, 12);
            this.txbKolcsonzo.Name = "txbKolcsonzo";
            this.txbKolcsonzo.ReadOnly = true;
            this.txbKolcsonzo.Size = new System.Drawing.Size(269, 22);
            this.txbKolcsonzo.TabIndex = 5;
            // 
            // txbId
            // 
            this.txbId.Location = new System.Drawing.Point(93, 40);
            this.txbId.Name = "txbId";
            this.txbId.ReadOnly = true;
            this.txbId.Size = new System.Drawing.Size(269, 22);
            this.txbId.TabIndex = 6;
            // 
            // txbRendszam
            // 
            this.txbRendszam.Location = new System.Drawing.Point(93, 68);
            this.txbRendszam.Name = "txbRendszam";
            this.txbRendszam.Size = new System.Drawing.Size(269, 22);
            this.txbRendszam.TabIndex = 7;
            // 
            // txbMarka
            // 
            this.txbMarka.Location = new System.Drawing.Point(93, 96);
            this.txbMarka.Name = "txbMarka";
            this.txbMarka.Size = new System.Drawing.Size(269, 22);
            this.txbMarka.TabIndex = 8;
            // 
            // cmbTipus
            // 
            this.cmbTipus.FormattingEnabled = true;
            this.cmbTipus.Location = new System.Drawing.Point(93, 125);
            this.cmbTipus.Name = "cmbTipus";
            this.cmbTipus.Size = new System.Drawing.Size(269, 24);
            this.cmbTipus.TabIndex = 9;
            this.cmbTipus.SelectedIndexChanged += new System.EventHandler(this.cmbTipus_SelectedIndexChanged);
            // 
            // chbFoglalt
            // 
            this.chbFoglalt.AutoSize = true;
            this.chbFoglalt.Location = new System.Drawing.Point(93, 155);
            this.chbFoglalt.Name = "chbFoglalt";
            this.chbFoglalt.Size = new System.Drawing.Size(70, 20);
            this.chbFoglalt.TabIndex = 10;
            this.chbFoglalt.Text = "Foglalt";
            this.chbFoglalt.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbKialakitas);
            this.groupBox1.Controls.Add(this.lblSzallithatoTeherheto);
            this.groupBox1.Controls.Add(this.lblKialakitas);
            this.groupBox1.Controls.Add(this.lblMertekegyseg);
            this.groupBox1.Controls.Add(this.num);
            this.groupBox1.Location = new System.Drawing.Point(4, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 69);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // cmbKialakitas
            // 
            this.cmbKialakitas.FormattingEnabled = true;
            this.cmbKialakitas.Location = new System.Drawing.Point(196, 41);
            this.cmbKialakitas.Name = "cmbKialakitas";
            this.cmbKialakitas.Size = new System.Drawing.Size(121, 24);
            this.cmbKialakitas.TabIndex = 5;
            // 
            // lblSzallithatoTeherheto
            // 
            this.lblSzallithatoTeherheto.AutoSize = true;
            this.lblSzallithatoTeherheto.Location = new System.Drawing.Point(6, 14);
            this.lblSzallithatoTeherheto.Name = "lblSzallithatoTeherheto";
            this.lblSzallithatoTeherheto.Size = new System.Drawing.Size(182, 16);
            this.lblSzallithatoTeherheto.TabIndex = 4;
            this.lblSzallithatoTeherheto.Text = "Szállítható személyek száma:";
            this.lblSzallithatoTeherheto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblKialakitas
            // 
            this.lblKialakitas.AutoSize = true;
            this.lblKialakitas.Location = new System.Drawing.Point(120, 44);
            this.lblKialakitas.Name = "lblKialakitas";
            this.lblKialakitas.Size = new System.Drawing.Size(68, 16);
            this.lblKialakitas.TabIndex = 3;
            this.lblKialakitas.Text = "Kialakítás:";
            // 
            // lblMertekegyseg
            // 
            this.lblMertekegyseg.AutoSize = true;
            this.lblMertekegyseg.Location = new System.Drawing.Point(323, 14);
            this.lblMertekegyseg.Name = "lblMertekegyseg";
            this.lblMertekegyseg.Size = new System.Drawing.Size(22, 16);
            this.lblMertekegyseg.TabIndex = 2;
            this.lblMertekegyseg.Text = "kg";
            this.lblMertekegyseg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // num
            // 
            this.num.Location = new System.Drawing.Point(197, 12);
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(120, 22);
            this.num.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(152, 262);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(102, 31);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(260, 262);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 31);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Mégsem";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // JarmuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 303);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chbFoglalt);
            this.Controls.Add(this.cmbTipus);
            this.Controls.Add(this.txbMarka);
            this.Controls.Add(this.txbRendszam);
            this.Controls.Add(this.txbId);
            this.Controls.Add(this.txbKolcsonzo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "JarmuForm";
            this.Text = "Jármű kezelése";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbKolcsonzo;
        private System.Windows.Forms.TextBox txbId;
        private System.Windows.Forms.TextBox txbRendszam;
        private System.Windows.Forms.TextBox txbMarka;
        private System.Windows.Forms.ComboBox cmbTipus;
        private System.Windows.Forms.CheckBox chbFoglalt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblKialakitas;
        private System.Windows.Forms.Label lblMertekegyseg;
        private System.Windows.Forms.NumericUpDown num;
        private System.Windows.Forms.ComboBox cmbKialakitas;
        private System.Windows.Forms.Label lblSzallithatoTeherheto;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}