namespace FormsKiserletezgetes
{
    partial class MainForm
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
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblTarget = new System.Windows.Forms.Label();
            this.txbSource = new System.Windows.Forms.TextBox();
            this.btnTipp = new System.Windows.Forms.Button();
            this.txbTipp = new System.Windows.Forms.TextBox();
            this.lblTippel = new System.Windows.Forms.Label();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.lsbTippek = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.megnyitasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mentesMaskentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.kilepesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.szerkesztesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masolasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kivagasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beillesztesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.betutipusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hatterszinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.betuszinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nevjegyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txbNotepad = new System.Windows.Forms.TextBox();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.dlgColor = new System.Windows.Forms.ColorDialog();
            this.dlgFont = new System.Windows.Forms.FontDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txbLogolt = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(294, 21);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(85, 45);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "Másolás";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Location = new System.Drawing.Point(7, 50);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(37, 16);
            this.lblTarget.TabIndex = 2;
            this.lblTarget.Text = "label";
            this.lblTarget.MouseEnter += new System.EventHandler(this.lblTarget_MouseEnter);
            // 
            // txbSource
            // 
            this.txbSource.Location = new System.Drawing.Point(10, 21);
            this.txbSource.Name = "txbSource";
            this.txbSource.Size = new System.Drawing.Size(278, 22);
            this.txbSource.TabIndex = 3;
            // 
            // btnTipp
            // 
            this.btnTipp.Enabled = false;
            this.btnTipp.Location = new System.Drawing.Point(8, 21);
            this.btnTipp.Name = "btnTipp";
            this.btnTipp.Size = new System.Drawing.Size(87, 32);
            this.btnTipp.TabIndex = 4;
            this.btnTipp.Text = "Tippelés";
            this.btnTipp.UseVisualStyleBackColor = true;
            this.btnTipp.Click += new System.EventHandler(this.btnTipp_Click);
            // 
            // txbTipp
            // 
            this.txbTipp.Location = new System.Drawing.Point(101, 23);
            this.txbTipp.Name = "txbTipp";
            this.txbTipp.Size = new System.Drawing.Size(100, 22);
            this.txbTipp.TabIndex = 5;
            this.txbTipp.TextChanged += new System.EventHandler(this.txbTipp_TextChanged);
            this.txbTipp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbTipp_KeyPress);
            // 
            // lblTippel
            // 
            this.lblTippel.AutoSize = true;
            this.lblTippel.Location = new System.Drawing.Point(8, 56);
            this.lblTippel.Name = "lblTippel";
            this.lblTippel.Size = new System.Drawing.Size(44, 16);
            this.lblTippel.TabIndex = 6;
            this.lblTippel.Text = "label1";
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(293, 23);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(87, 32);
            this.btnNewGame.TabIndex = 7;
            this.btnNewGame.Text = "Új játék";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // lsbTippek
            // 
            this.lsbTippek.FormattingEnabled = true;
            this.lsbTippek.ItemHeight = 16;
            this.lsbTippek.Location = new System.Drawing.Point(11, 80);
            this.lsbTippek.Name = "lsbTippek";
            this.lsbTippek.Size = new System.Drawing.Size(369, 308);
            this.lsbTippek.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txbSource);
            this.groupBox1.Controls.Add(this.btnCopy);
            this.groupBox1.Controls.Add(this.lblTarget);
            this.groupBox1.Location = new System.Drawing.Point(582, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 75);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "szövegmásoló";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnTipp);
            this.groupBox2.Controls.Add(this.txbTipp);
            this.groupBox2.Controls.Add(this.lsbTippek);
            this.groupBox2.Controls.Add(this.lblTippel);
            this.groupBox2.Controls.Add(this.btnNewGame);
            this.groupBox2.Location = new System.Drawing.Point(582, 257);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 400);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "számkitaláló";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.szerkesztesToolStripMenuItem,
            this.formatumToolStripMenuItem,
            this.nevjegyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(978, 28);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.megnyitasToolStripMenuItem,
            this.mentesToolStripMenuItem,
            this.mentesMaskentToolStripMenuItem,
            this.toolStripSeparator1,
            this.kilepesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // megnyitasToolStripMenuItem
            // 
            this.megnyitasToolStripMenuItem.Name = "megnyitasToolStripMenuItem";
            this.megnyitasToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.megnyitasToolStripMenuItem.Size = new System.Drawing.Size(289, 26);
            this.megnyitasToolStripMenuItem.Text = "Megnyitás";
            this.megnyitasToolStripMenuItem.Click += new System.EventHandler(this.megnyitasToolStripMenuItem_Click);
            // 
            // mentesToolStripMenuItem
            // 
            this.mentesToolStripMenuItem.Name = "mentesToolStripMenuItem";
            this.mentesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mentesToolStripMenuItem.Size = new System.Drawing.Size(289, 26);
            this.mentesToolStripMenuItem.Text = "Mentés";
            this.mentesToolStripMenuItem.Click += new System.EventHandler(this.mentesToolStripMenuItem_Click);
            // 
            // mentesMaskentToolStripMenuItem
            // 
            this.mentesMaskentToolStripMenuItem.Name = "mentesMaskentToolStripMenuItem";
            this.mentesMaskentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.mentesMaskentToolStripMenuItem.Size = new System.Drawing.Size(289, 26);
            this.mentesMaskentToolStripMenuItem.Text = "Mentés másként";
            this.mentesMaskentToolStripMenuItem.Click += new System.EventHandler(this.mentesMaskentToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(286, 6);
            // 
            // kilepesToolStripMenuItem
            // 
            this.kilepesToolStripMenuItem.Name = "kilepesToolStripMenuItem";
            this.kilepesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.kilepesToolStripMenuItem.Size = new System.Drawing.Size(289, 26);
            this.kilepesToolStripMenuItem.Text = "Kilépés";
            this.kilepesToolStripMenuItem.Click += new System.EventHandler(this.kilepesToolStripMenuItem_Click);
            // 
            // szerkesztesToolStripMenuItem
            // 
            this.szerkesztesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masolasToolStripMenuItem,
            this.kivagasToolStripMenuItem,
            this.beillesztesToolStripMenuItem});
            this.szerkesztesToolStripMenuItem.Name = "szerkesztesToolStripMenuItem";
            this.szerkesztesToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.szerkesztesToolStripMenuItem.Text = "Szerkesztés";
            // 
            // masolasToolStripMenuItem
            // 
            this.masolasToolStripMenuItem.Name = "masolasToolStripMenuItem";
            this.masolasToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.masolasToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.masolasToolStripMenuItem.Text = "Másolás";
            this.masolasToolStripMenuItem.Click += new System.EventHandler(this.masolasToolStripMenuItem_Click);
            // 
            // kivagasToolStripMenuItem
            // 
            this.kivagasToolStripMenuItem.Name = "kivagasToolStripMenuItem";
            this.kivagasToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.kivagasToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.kivagasToolStripMenuItem.Text = "Kivágás";
            this.kivagasToolStripMenuItem.Click += new System.EventHandler(this.kivagasToolStripMenuItem_Click);
            // 
            // beillesztesToolStripMenuItem
            // 
            this.beillesztesToolStripMenuItem.Name = "beillesztesToolStripMenuItem";
            this.beillesztesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.beillesztesToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.beillesztesToolStripMenuItem.Text = "Beillesztés";
            this.beillesztesToolStripMenuItem.Click += new System.EventHandler(this.beillesztesToolStripMenuItem_Click);
            // 
            // formatumToolStripMenuItem
            // 
            this.formatumToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.betutipusToolStripMenuItem,
            this.hatterszinToolStripMenuItem,
            this.betuszinToolStripMenuItem});
            this.formatumToolStripMenuItem.Name = "formatumToolStripMenuItem";
            this.formatumToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.formatumToolStripMenuItem.Text = "Formátum";
            // 
            // betutipusToolStripMenuItem
            // 
            this.betutipusToolStripMenuItem.Name = "betutipusToolStripMenuItem";
            this.betutipusToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.betutipusToolStripMenuItem.Text = "Betűtípus";
            this.betutipusToolStripMenuItem.Click += new System.EventHandler(this.betutipusToolStripMenuItem_Click);
            // 
            // hatterszinToolStripMenuItem
            // 
            this.hatterszinToolStripMenuItem.Name = "hatterszinToolStripMenuItem";
            this.hatterszinToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.hatterszinToolStripMenuItem.Text = "Háttérszín";
            this.hatterszinToolStripMenuItem.Click += new System.EventHandler(this.hatterszinToolStripMenuItem_Click);
            // 
            // betuszinToolStripMenuItem
            // 
            this.betuszinToolStripMenuItem.Name = "betuszinToolStripMenuItem";
            this.betuszinToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.betuszinToolStripMenuItem.Text = "Betűszín";
            this.betuszinToolStripMenuItem.Click += new System.EventHandler(this.betuszinToolStripMenuItem_Click);
            // 
            // nevjegyToolStripMenuItem
            // 
            this.nevjegyToolStripMenuItem.Name = "nevjegyToolStripMenuItem";
            this.nevjegyToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.nevjegyToolStripMenuItem.Text = "Névjegy";
            this.nevjegyToolStripMenuItem.Click += new System.EventHandler(this.nevjegyToolStripMenuItem_Click);
            // 
            // txbNotepad
            // 
            this.txbNotepad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbNotepad.Location = new System.Drawing.Point(0, 31);
            this.txbNotepad.Multiline = true;
            this.txbNotepad.Name = "txbNotepad";
            this.txbNotepad.Size = new System.Drawing.Size(576, 631);
            this.txbNotepad.TabIndex = 12;
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.FileName = "openFileDialog1";
            this.dlgOpenFile.Filter = "Szöveges|*.txt|Minden|*.*";
            // 
            // dlgSave
            // 
            this.dlgSave.DefaultExt = "*.txt";
            this.dlgSave.Filter = "Szöveges|*.txt|Minden|*.*";
            // 
            // dlgFont
            // 
            this.dlgFont.AllowVerticalFonts = false;
            this.dlgFont.FontMustExist = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnStart);
            this.groupBox3.Controls.Add(this.txbLogolt);
            this.groupBox3.Location = new System.Drawing.Point(583, 110);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(387, 141);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logoló program";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(133, 17);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(245, 22);
            this.textBox2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Path:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(9, 17);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txbLogolt
            // 
            this.txbLogolt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbLogolt.Enabled = false;
            this.txbLogolt.Location = new System.Drawing.Point(10, 46);
            this.txbLogolt.Multiline = true;
            this.txbLogolt.Name = "txbLogolt";
            this.txbLogolt.Size = new System.Drawing.Size(371, 89);
            this.txbLogolt.TabIndex = 0;
            this.txbLogolt.TextChanged += new System.EventHandler(this.txbLogolt_TextChanged);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Kérem, válasszon egy könyvtárat a logoláshoz.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 662);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txbNotepad);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Főablak";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.TextBox txbSource;
        private System.Windows.Forms.Button btnTipp;
        private System.Windows.Forms.TextBox txbTipp;
        private System.Windows.Forms.Label lblTippel;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.ListBox lsbTippek;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem megnyitasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mentesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem szerkesztesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nevjegyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mentesMaskentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem kilepesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masolasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kivagasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beillesztesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem betutipusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hatterszinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem betuszinToolStripMenuItem;
        private System.Windows.Forms.TextBox txbNotepad;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.ColorDialog dlgColor;
        private System.Windows.Forms.FontDialog dlgFont;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txbLogolt;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBox2;
    }
}

