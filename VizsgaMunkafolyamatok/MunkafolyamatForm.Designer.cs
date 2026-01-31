namespace VizsgaMunkafolyamatok
{
    partial class MunkafolyamatForm
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
            this.txbMegnevezes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numAr = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btcCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAr)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Megnevezés:";
            // 
            // txbMegnevezes
            // 
            this.txbMegnevezes.Location = new System.Drawing.Point(106, 12);
            this.txbMegnevezes.Name = "txbMegnevezes";
            this.txbMegnevezes.Size = new System.Drawing.Size(166, 22);
            this.txbMegnevezes.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ár:";
            // 
            // numAr
            // 
            this.numAr.DecimalPlaces = 2;
            this.numAr.Location = new System.Drawing.Point(106, 40);
            this.numAr.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numAr.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAr.Name = "numAr";
            this.numAr.Size = new System.Drawing.Size(125, 22);
            this.numAr.TabIndex = 3;
            this.numAr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numAr.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "forint";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(106, 76);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 29);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btcCancel
            // 
            this.btcCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btcCancel.Location = new System.Drawing.Point(197, 76);
            this.btcCancel.Name = "btcCancel";
            this.btcCancel.Size = new System.Drawing.Size(84, 29);
            this.btcCancel.TabIndex = 6;
            this.btcCancel.Text = "Mégsem";
            this.btcCancel.UseVisualStyleBackColor = true;
            // 
            // MunkafolyamatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 116);
            this.Controls.Add(this.btcCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numAr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbMegnevezes);
            this.Controls.Add(this.label1);
            this.Name = "MunkafolyamatForm";
            this.Text = "Új munkafolyamat";
            ((System.ComponentModel.ISupportInitialize)(this.numAr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbMegnevezes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numAr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btcCancel;
    }
}