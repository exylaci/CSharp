namespace MySqlOroklesPeldaJarmukolcsonzo
{
    partial class KolcsonzoForm
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
            this.txbMegnevezes = new System.Windows.Forms.TextBox();
            this.txbCim = new System.Windows.Forms.TextBox();
            this.txbTulajdonos = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.bznCancel = new System.Windows.Forms.Button();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cím:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tulajdonos:";
            // 
            // txbMegnevezes
            // 
            this.txbMegnevezes.Location = new System.Drawing.Point(106, 12);
            this.txbMegnevezes.Name = "txbMegnevezes";
            this.txbMegnevezes.Size = new System.Drawing.Size(227, 22);
            this.txbMegnevezes.TabIndex = 3;
            // 
            // txbCim
            // 
            this.txbCim.Location = new System.Drawing.Point(106, 40);
            this.txbCim.Name = "txbCim";
            this.txbCim.Size = new System.Drawing.Size(227, 22);
            this.txbCim.TabIndex = 4;
            // 
            // txbTulajdonos
            // 
            this.txbTulajdonos.Location = new System.Drawing.Point(106, 68);
            this.txbTulajdonos.Name = "txbTulajdonos";
            this.txbTulajdonos.Size = new System.Drawing.Size(227, 22);
            this.txbTulajdonos.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(106, 108);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(103, 30);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // bznCancel
            // 
            this.bznCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bznCancel.Location = new System.Drawing.Point(230, 108);
            this.bznCancel.Name = "bznCancel";
            this.bznCancel.Size = new System.Drawing.Size(103, 30);
            this.bznCancel.TabIndex = 7;
            this.bznCancel.Text = "Mégsem";
            this.bznCancel.UseVisualStyleBackColor = true;
            // 
            // KolcsonzoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 147);
            this.Controls.Add(this.bznCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txbTulajdonos);
            this.Controls.Add(this.txbCim);
            this.Controls.Add(this.txbMegnevezes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "KolcsonzoForm";
            this.Text = "Kölcsönző kezelése";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbMegnevezes;
        private System.Windows.Forms.TextBox txbCim;
        private System.Windows.Forms.TextBox txbTulajdonos;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button bznCancel;
    }
}