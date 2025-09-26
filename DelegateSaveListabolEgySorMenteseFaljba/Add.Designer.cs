namespace DelegateSaveListabolEgySorMenteseFaljba
{
    partial class FrmAdd
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
            this.txbCim = new System.Windows.Forms.TextBox();
            this.txbFeladat = new System.Windows.Forms.TextBox();
            this.txbUtvonal = new System.Windows.Forms.TextBox();
            this.btnKep = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "cím:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "leírás:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "kép:";
            // 
            // txbCim
            // 
            this.txbCim.Location = new System.Drawing.Point(51, 17);
            this.txbCim.Name = "txbCim";
            this.txbCim.Size = new System.Drawing.Size(248, 20);
            this.txbCim.TabIndex = 3;
            // 
            // txbFeladat
            // 
            this.txbFeladat.Location = new System.Drawing.Point(51, 47);
            this.txbFeladat.Multiline = true;
            this.txbFeladat.Name = "txbFeladat";
            this.txbFeladat.Size = new System.Drawing.Size(247, 90);
            this.txbFeladat.TabIndex = 4;
            // 
            // txbUtvonal
            // 
            this.txbUtvonal.Location = new System.Drawing.Point(51, 150);
            this.txbUtvonal.Name = "txbUtvonal";
            this.txbUtvonal.Size = new System.Drawing.Size(247, 20);
            this.txbUtvonal.TabIndex = 5;
            // 
            // btnKep
            // 
            this.btnKep.Location = new System.Drawing.Point(51, 177);
            this.btnKep.Name = "btnKep";
            this.btnKep.Size = new System.Drawing.Size(105, 23);
            this.btnKep.TabIndex = 6;
            this.btnKep.Text = "kép kiválasztása";
            this.btnKep.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(142, 229);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Hozzáadás";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(223, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Elvetés";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 264);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnKep);
            this.Controls.Add(this.txbUtvonal);
            this.Controls.Add(this.txbFeladat);
            this.Controls.Add(this.txbCim);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmAdd";
            this.Text = "Új vizsga hozzáadása";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbCim;
        private System.Windows.Forms.TextBox txbFeladat;
        private System.Windows.Forms.TextBox txbUtvonal;
        private System.Windows.Forms.Button btnKep;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
    }
}