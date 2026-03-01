namespace Donkeykongdemo
{
    partial class TopAblak
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
            this.exitGomb = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.exitGomb)).BeginInit();
            this.SuspendLayout();
            // 
            // exitGomb
            // 
            this.exitGomb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitGomb.Image = global::Donkeykongdemo.Properties.Resources.cancel;
            this.exitGomb.Location = new System.Drawing.Point(566, 5);
            this.exitGomb.Name = "exitGomb";
            this.exitGomb.Size = new System.Drawing.Size(32, 32);
            this.exitGomb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exitGomb.TabIndex = 7;
            this.exitGomb.TabStop = false;
            this.exitGomb.Click += new System.EventHandler(this.exitGomb_Click);
            this.exitGomb.MouseEnter += new System.EventHandler(this.exitGomb_MouseEnter);
            this.exitGomb.MouseLeave += new System.EventHandler(this.exitGomb_MouseLeave);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.listBox1.ForeColor = System.Drawing.Color.FloralWhite;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(102, 33);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(406, 526);
            this.listBox1.TabIndex = 8;
            // 
            // TopAblak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(604, 615);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.exitGomb);
            this.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.FloralWhite;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TopAblak";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TopAblak";
            ((System.ComponentModel.ISupportInitialize)(this.exitGomb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox exitGomb;
        private System.Windows.Forms.ListBox listBox1;
    }
}