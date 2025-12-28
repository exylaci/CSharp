namespace Vizsgaremek_Szallashelyek
{
    partial class ListViewForm
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
            this.lsv = new System.Windows.Forms.ListView();
            this.btnFilterOn = new System.Windows.Forms.Button();
            this.btnFilterOff = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsv
            // 
            this.lsv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsv.HideSelection = false;
            this.lsv.Location = new System.Drawing.Point(12, 12);
            this.lsv.Name = "lsv";
            this.lsv.Size = new System.Drawing.Size(860, 372);
            this.lsv.TabIndex = 0;
            this.lsv.UseCompatibleStateImageBehavior = false;
            // 
            // btnFilterOn
            // 
            this.btnFilterOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFilterOn.Location = new System.Drawing.Point(12, 395);
            this.btnFilterOn.Name = "btnFilterOn";
            this.btnFilterOn.Size = new System.Drawing.Size(156, 32);
            this.btnFilterOn.TabIndex = 1;
            this.btnFilterOn.Text = "Szűrés beállítása";
            this.btnFilterOn.UseVisualStyleBackColor = true;
            this.btnFilterOn.Click += new System.EventHandler(this.btnFilterOn_Click);
            // 
            // btnFilterOff
            // 
            this.btnFilterOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFilterOff.Location = new System.Drawing.Point(174, 395);
            this.btnFilterOff.Name = "btnFilterOff";
            this.btnFilterOff.Size = new System.Drawing.Size(156, 32);
            this.btnFilterOff.TabIndex = 2;
            this.btnFilterOff.Text = "Minden szűrés törlése";
            this.btnFilterOff.UseVisualStyleBackColor = true;
            this.btnFilterOff.Click += new System.EventHandler(this.btnFilterOff_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(718, 395);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(156, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Vissza";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ListViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 439);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFilterOff);
            this.Controls.Add(this.btnFilterOn);
            this.Controls.Add(this.lsv);
            this.Name = "ListViewForm";
            this.Text = "Szálláshelyek sorbarendezve";
            this.Load += new System.EventHandler(this.ListViewForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsv;
        private System.Windows.Forms.Button btnFilterOn;
        private System.Windows.Forms.Button btnFilterOff;
        private System.Windows.Forms.Button btnCancel;
    }
}