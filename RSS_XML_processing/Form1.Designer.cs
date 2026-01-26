namespace RSS_XML_processing
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txbSource = new System.Windows.Forms.TextBox();
            this.chbAutomatic = new System.Windows.Forms.CheckBox();
            this.numFrequency = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lsbArticles = new System.Windows.Forms.ListBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.numFrequency)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "RSS forrás:";
            // 
            // txbSource
            // 
            this.txbSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSource.Location = new System.Drawing.Point(93, 12);
            this.txbSource.Name = "txbSource";
            this.txbSource.Size = new System.Drawing.Size(643, 22);
            this.txbSource.TabIndex = 4;
            // 
            // chbAutomatic
            // 
            this.chbAutomatic.AutoSize = true;
            this.chbAutomatic.Location = new System.Drawing.Point(15, 47);
            this.chbAutomatic.Name = "chbAutomatic";
            this.chbAutomatic.Size = new System.Drawing.Size(232, 20);
            this.chbAutomatic.TabIndex = 5;
            this.chbAutomatic.Text = "Automatikus frissítés gyakorisága:";
            this.chbAutomatic.UseVisualStyleBackColor = true;
            this.chbAutomatic.CheckedChanged += new System.EventHandler(this.chbAutomatic_CheckedChanged);
            // 
            // numFrequency
            // 
            this.numFrequency.Location = new System.Drawing.Point(253, 46);
            this.numFrequency.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numFrequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFrequency.Name = "numFrequency";
            this.numFrequency.Size = new System.Drawing.Size(120, 22);
            this.numFrequency.TabIndex = 6;
            this.numFrequency.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numFrequency.ValueChanged += new System.EventHandler(this.numFrequency_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(379, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "perc";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(419, 39);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(126, 34);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Azonnali frissítés";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lsbArticles
            // 
            this.lsbArticles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbArticles.FormattingEnabled = true;
            this.lsbArticles.ItemHeight = 16;
            this.lsbArticles.Location = new System.Drawing.Point(15, 79);
            this.lsbArticles.Name = "lsbArticles";
            this.lsbArticles.Size = new System.Drawing.Size(721, 180);
            this.lsbArticles.TabIndex = 9;
            this.lsbArticles.SelectedIndexChanged += new System.EventHandler(this.lsbArticles_SelectedIndexChanged);
            this.lsbArticles.DoubleClick += new System.EventHandler(this.lsbArticles_DoubleClick);
            // 
            // timer
            // 
            this.timer.Interval = 300000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(15, 265);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(721, 283);
            this.webBrowser1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 553);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.lsbArticles);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numFrequency);
            this.Controls.Add(this.chbAutomatic);
            this.Controls.Add(this.txbSource);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numFrequency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbSource;
        private System.Windows.Forms.CheckBox chbAutomatic;
        private System.Windows.Forms.NumericUpDown numFrequency;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListBox lsbArticles;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}

