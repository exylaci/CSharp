namespace Vizsgaremek_Szallashelyek
{
    partial class FilterForm
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
            this.txbId = new System.Windows.Forms.TextBox();
            this.btnIdOff = new System.Windows.Forms.Button();
            this.btnNameOff = new System.Windows.Forms.Button();
            this.txbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbProfile = new System.Windows.Forms.ComboBox();
            this.btnProfileOff = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Szűrési feltételek:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Szálláshely azonosítóban:";
            // 
            // txbId
            // 
            this.txbId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbId.Location = new System.Drawing.Point(205, 33);
            this.txbId.MaxLength = 8;
            this.txbId.Name = "txbId";
            this.txbId.Size = new System.Drawing.Size(152, 22);
            this.txbId.TabIndex = 2;
            // 
            // btnIdOff
            // 
            this.btnIdOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIdOff.Location = new System.Drawing.Point(363, 31);
            this.btnIdOff.Name = "btnIdOff";
            this.btnIdOff.Size = new System.Drawing.Size(92, 26);
            this.btnIdOff.TabIndex = 4;
            this.btnIdOff.Text = "Töröl";
            this.btnIdOff.UseVisualStyleBackColor = true;
            this.btnIdOff.Click += new System.EventHandler(this.btnIdOff_Click);
            // 
            // btnNameOff
            // 
            this.btnNameOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNameOff.Location = new System.Drawing.Point(363, 63);
            this.btnNameOff.Name = "btnNameOff";
            this.btnNameOff.Size = new System.Drawing.Size(92, 26);
            this.btnNameOff.TabIndex = 8;
            this.btnNameOff.Text = "Töröl";
            this.btnNameOff.UseVisualStyleBackColor = true;
            this.btnNameOff.Click += new System.EventHandler(this.btnNameOff_Click);
            // 
            // txbName
            // 
            this.txbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbName.Location = new System.Drawing.Point(205, 65);
            this.txbName.MaxLength = 60;
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(152, 22);
            this.txbName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Szálláshely nevében::";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Szálláshely fajta alapján:";
            // 
            // cmbProfile
            // 
            this.cmbProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProfile.FormattingEnabled = true;
            this.cmbProfile.Location = new System.Drawing.Point(205, 97);
            this.cmbProfile.Name = "cmbProfile";
            this.cmbProfile.Size = new System.Drawing.Size(152, 24);
            this.cmbProfile.TabIndex = 10;
            // 
            // btnProfileOff
            // 
            this.btnProfileOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProfileOff.Location = new System.Drawing.Point(363, 95);
            this.btnProfileOff.Name = "btnProfileOff";
            this.btnProfileOff.Size = new System.Drawing.Size(92, 26);
            this.btnProfileOff.TabIndex = 12;
            this.btnProfileOff.Text = "Töröl";
            this.btnProfileOff.UseVisualStyleBackColor = true;
            this.btnProfileOff.Click += new System.EventHandler(this.btnProfileOff_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(233, 138);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(108, 33);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(347, 138);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 33);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Mégsem";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 182);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnProfileOff);
            this.Controls.Add(this.cmbProfile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnNameOff);
            this.Controls.Add(this.txbName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnIdOff);
            this.Controls.Add(this.txbId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FilterForm";
            this.Text = "Szűrési feltételek beállítása";
            this.Load += new System.EventHandler(this.FilterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbId;
        private System.Windows.Forms.Button btnIdOff;
        private System.Windows.Forms.Button btnNameOff;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbProfile;
        private System.Windows.Forms.Button btnProfileOff;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}