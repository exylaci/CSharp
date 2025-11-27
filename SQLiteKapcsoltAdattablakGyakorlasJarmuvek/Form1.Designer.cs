namespace SQLiteKapcsoltAdattablakGyakorlasJarmuvek
{
    partial class Form1
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
            this.lsbJarmuvek = new System.Windows.Forms.ListBox();
            this.btnUj = new System.Windows.Forms.Button();
            this.btnModosit = new System.Windows.Forms.Button();
            this.btnTorol = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // lsbJarmuvek
            // 
            this.lsbJarmuvek.FormattingEnabled = true;
            this.lsbJarmuvek.ItemHeight = 16;
            this.lsbJarmuvek.Location = new System.Drawing.Point(12, 12);
            this.lsbJarmuvek.Name = "lsbJarmuvek";
            this.lsbJarmuvek.Size = new System.Drawing.Size(453, 532);
            this.lsbJarmuvek.TabIndex = 0;
            // 
            // btnUj
            // 
            this.btnUj.Location = new System.Drawing.Point(471, 12);
            this.btnUj.Name = "btnUj";
            this.btnUj.Size = new System.Drawing.Size(158, 33);
            this.btnUj.TabIndex = 1;
            this.btnUj.Text = "Új jármű felvétele";
            this.btnUj.UseVisualStyleBackColor = true;
            this.btnUj.Click += new System.EventHandler(this.btnUj_Click);
            // 
            // btnModosit
            // 
            this.btnModosit.Location = new System.Drawing.Point(471, 51);
            this.btnModosit.Name = "btnModosit";
            this.btnModosit.Size = new System.Drawing.Size(158, 33);
            this.btnModosit.TabIndex = 2;
            this.btnModosit.Text = "Jármű módosítása";
            this.btnModosit.UseVisualStyleBackColor = true;
            this.btnModosit.Click += new System.EventHandler(this.btnModosit_Click);
            // 
            // btnTorol
            // 
            this.btnTorol.Location = new System.Drawing.Point(471, 90);
            this.btnTorol.Name = "btnTorol";
            this.btnTorol.Size = new System.Drawing.Size(158, 33);
            this.btnTorol.TabIndex = 3;
            this.btnTorol.Text = "Jármű törlése";
            this.btnTorol.UseVisualStyleBackColor = true;
            this.btnTorol.Click += new System.EventHandler(this.btnTorol_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(471, 476);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(158, 33);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Járművek importálása";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(471, 515);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(158, 33);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Járműlista exportálása";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 557);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnTorol);
            this.Controls.Add(this.btnModosit);
            this.Controls.Add(this.btnUj);
            this.Controls.Add(this.lsbJarmuvek);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lsbJarmuvek;
        private System.Windows.Forms.Button btnUj;
        private System.Windows.Forms.Button btnModosit;
        private System.Windows.Forms.Button btnTorol;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

