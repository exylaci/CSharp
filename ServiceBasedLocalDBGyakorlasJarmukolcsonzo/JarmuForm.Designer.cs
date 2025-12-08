namespace ServiceBasedLocalDBGyakorlasJarmukolcsonző
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
            this.lblKialakitasKobcenti = new System.Windows.Forms.Label();
            this.cmbNev = new System.Windows.Forms.ComboBox();
            this.cmbCim = new System.Windows.Forms.ComboBox();
            this.txbRendszam = new System.Windows.Forms.TextBox();
            this.cmbKategoria = new System.Windows.Forms.ComboBox();
            this.txbMarka = new System.Windows.Forms.TextBox();
            this.cmbKialakitas = new System.Windows.Forms.ComboBox();
            this.numKobcenti = new System.Windows.Forms.NumericUpDown();
            this.chbFoglalt = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numKobcenti)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kölcsönző:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rendszám:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kategória:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Márka:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblKialakitasKobcenti
            // 
            this.lblKialakitasKobcenti.AutoSize = true;
            this.lblKialakitasKobcenti.Location = new System.Drawing.Point(14, 170);
            this.lblKialakitasKobcenti.Name = "lblKialakitasKobcenti";
            this.lblKialakitasKobcenti.Size = new System.Drawing.Size(68, 16);
            this.lblKialakitasKobcenti.TabIndex = 4;
            this.lblKialakitasKobcenti.Text = "Kialakítás:";
            this.lblKialakitasKobcenti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbNev
            // 
            this.cmbNev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNev.FormattingEnabled = true;
            this.cmbNev.Location = new System.Drawing.Point(88, 12);
            this.cmbNev.Name = "cmbNev";
            this.cmbNev.Size = new System.Drawing.Size(211, 24);
            this.cmbNev.TabIndex = 5;
            this.cmbNev.SelectedIndexChanged += new System.EventHandler(this.cmbNev_SelectedIndexChanged);
            // 
            // cmbCim
            // 
            this.cmbCim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCim.FormattingEnabled = true;
            this.cmbCim.Location = new System.Drawing.Point(88, 42);
            this.cmbCim.Name = "cmbCim";
            this.cmbCim.Size = new System.Drawing.Size(211, 24);
            this.cmbCim.TabIndex = 6;
            this.cmbCim.SelectedIndexChanged += new System.EventHandler(this.cmbCim_SelectedIndexChanged);
            // 
            // txbRendszam
            // 
            this.txbRendszam.Location = new System.Drawing.Point(88, 73);
            this.txbRendszam.Name = "txbRendszam";
            this.txbRendszam.Size = new System.Drawing.Size(100, 22);
            this.txbRendszam.TabIndex = 7;
            // 
            // cmbKategoria
            // 
            this.cmbKategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKategoria.FormattingEnabled = true;
            this.cmbKategoria.Location = new System.Drawing.Point(88, 102);
            this.cmbKategoria.Name = "cmbKategoria";
            this.cmbKategoria.Size = new System.Drawing.Size(100, 24);
            this.cmbKategoria.TabIndex = 8;
            this.cmbKategoria.SelectedValueChanged += new System.EventHandler(this.cmbKategoria_SelectedValueChanged);
            // 
            // txbMarka
            // 
            this.txbMarka.Location = new System.Drawing.Point(88, 134);
            this.txbMarka.Name = "txbMarka";
            this.txbMarka.Size = new System.Drawing.Size(211, 22);
            this.txbMarka.TabIndex = 9;
            // 
            // cmbKialakitas
            // 
            this.cmbKialakitas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKialakitas.FormattingEnabled = true;
            this.cmbKialakitas.Location = new System.Drawing.Point(88, 167);
            this.cmbKialakitas.Name = "cmbKialakitas";
            this.cmbKialakitas.Size = new System.Drawing.Size(211, 24);
            this.cmbKialakitas.TabIndex = 10;
            // 
            // numKobcenti
            // 
            this.numKobcenti.Location = new System.Drawing.Point(88, 170);
            this.numKobcenti.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numKobcenti.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numKobcenti.Name = "numKobcenti";
            this.numKobcenti.Size = new System.Drawing.Size(100, 22);
            this.numKobcenti.TabIndex = 11;
            this.numKobcenti.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // chbFoglalt
            // 
            this.chbFoglalt.AutoSize = true;
            this.chbFoglalt.Location = new System.Drawing.Point(88, 198);
            this.chbFoglalt.Name = "chbFoglalt";
            this.chbFoglalt.Size = new System.Drawing.Size(127, 20);
            this.chbFoglalt.TabIndex = 12;
            this.chbFoglalt.Text = "Kikölcsönözhető";
            this.chbFoglalt.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(96, 225);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(92, 28);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(194, 225);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 28);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Mégsem";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // JarmuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 263);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chbFoglalt);
            this.Controls.Add(this.numKobcenti);
            this.Controls.Add(this.cmbKialakitas);
            this.Controls.Add(this.txbMarka);
            this.Controls.Add(this.cmbKategoria);
            this.Controls.Add(this.txbRendszam);
            this.Controls.Add(this.cmbCim);
            this.Controls.Add(this.cmbNev);
            this.Controls.Add(this.lblKialakitasKobcenti);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "JarmuForm";
            this.Text = "Jármű kezelése";
            ((System.ComponentModel.ISupportInitialize)(this.numKobcenti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblKialakitasKobcenti;
        private System.Windows.Forms.ComboBox cmbNev;
        private System.Windows.Forms.ComboBox cmbCim;
        private System.Windows.Forms.TextBox txbRendszam;
        private System.Windows.Forms.ComboBox cmbKategoria;
        private System.Windows.Forms.TextBox txbMarka;
        private System.Windows.Forms.ComboBox cmbKialakitas;
        private System.Windows.Forms.NumericUpDown numKobcenti;
        private System.Windows.Forms.CheckBox chbFoglalt;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}