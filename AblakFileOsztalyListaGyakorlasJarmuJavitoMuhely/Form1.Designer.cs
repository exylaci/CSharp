namespace AblakFileOsztalyListaGyakorlasJarmuJavitoMuhely
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.névjegyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lsbMuhelyek = new System.Windows.Forms.ListBox();
            this.lsbSzemelyAutok = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lsbTeherAutok = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMuhelyTorol = new System.Windows.Forms.Button();
            this.btnMuhelyMegjelenit = new System.Windows.Forms.Button();
            this.btnMuhelyModosit = new System.Windows.Forms.Button();
            this.btnMuhelyUj = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnJarmuTorol = new System.Windows.Forms.Button();
            this.btnJarmuMegjelenit = new System.Windows.Forms.Button();
            this.btnJarmuModosit = new System.Windows.Forms.Button();
            this.btnJarmuUj = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnMuhelyekMegjelenitese = new System.Windows.Forms.Button();
            this.btnJarmuvekMegjelenitese = new System.Windows.Forms.Button();
            this.btnRendezesek = new System.Windows.Forms.Button();
            this.lblJarmuAdatok = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.névjegyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(620, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // névjegyToolStripMenuItem
            // 
            this.névjegyToolStripMenuItem.Name = "névjegyToolStripMenuItem";
            this.névjegyToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.névjegyToolStripMenuItem.Text = "Névjegy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Jarmujavító műhelyek:";
            // 
            // lsbMuhelyek
            // 
            this.lsbMuhelyek.FormattingEnabled = true;
            this.lsbMuhelyek.ItemHeight = 16;
            this.lsbMuhelyek.Location = new System.Drawing.Point(13, 50);
            this.lsbMuhelyek.Name = "lsbMuhelyek";
            this.lsbMuhelyek.Size = new System.Drawing.Size(458, 132);
            this.lsbMuhelyek.TabIndex = 2;
            // 
            // lsbSzemelyAutok
            // 
            this.lsbSzemelyAutok.FormattingEnabled = true;
            this.lsbSzemelyAutok.ItemHeight = 16;
            this.lsbSzemelyAutok.Location = new System.Drawing.Point(13, 205);
            this.lsbSzemelyAutok.Name = "lsbSzemelyAutok";
            this.lsbSzemelyAutok.Size = new System.Drawing.Size(458, 132);
            this.lsbSzemelyAutok.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Személyautók:";
            // 
            // lsbTeherAutok
            // 
            this.lsbTeherAutok.FormattingEnabled = true;
            this.lsbTeherAutok.ItemHeight = 16;
            this.lsbTeherAutok.Location = new System.Drawing.Point(13, 360);
            this.lsbTeherAutok.Name = "lsbTeherAutok";
            this.lsbTeherAutok.Size = new System.Drawing.Size(458, 132);
            this.lsbTeherAutok.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Teherautók:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMuhelyTorol);
            this.groupBox1.Controls.Add(this.btnMuhelyMegjelenit);
            this.groupBox1.Controls.Add(this.btnMuhelyModosit);
            this.groupBox1.Controls.Add(this.btnMuhelyUj);
            this.groupBox1.Location = new System.Drawing.Point(478, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 148);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Javító műhely";
            // 
            // btnMuhelyTorol
            // 
            this.btnMuhelyTorol.Location = new System.Drawing.Point(7, 109);
            this.btnMuhelyTorol.Name = "btnMuhelyTorol";
            this.btnMuhelyTorol.Size = new System.Drawing.Size(114, 23);
            this.btnMuhelyTorol.TabIndex = 3;
            this.btnMuhelyTorol.Text = "Törlés";
            this.btnMuhelyTorol.UseVisualStyleBackColor = true;
            // 
            // btnMuhelyMegjelenit
            // 
            this.btnMuhelyMegjelenit.Location = new System.Drawing.Point(7, 80);
            this.btnMuhelyMegjelenit.Name = "btnMuhelyMegjelenit";
            this.btnMuhelyMegjelenit.Size = new System.Drawing.Size(114, 23);
            this.btnMuhelyMegjelenit.TabIndex = 2;
            this.btnMuhelyMegjelenit.Text = "Megjelenítés";
            this.btnMuhelyMegjelenit.UseVisualStyleBackColor = true;
            // 
            // btnMuhelyModosit
            // 
            this.btnMuhelyModosit.Location = new System.Drawing.Point(7, 51);
            this.btnMuhelyModosit.Name = "btnMuhelyModosit";
            this.btnMuhelyModosit.Size = new System.Drawing.Size(114, 23);
            this.btnMuhelyModosit.TabIndex = 1;
            this.btnMuhelyModosit.Text = "Módosítás";
            this.btnMuhelyModosit.UseVisualStyleBackColor = true;
            // 
            // btnMuhelyUj
            // 
            this.btnMuhelyUj.Location = new System.Drawing.Point(7, 22);
            this.btnMuhelyUj.Name = "btnMuhelyUj";
            this.btnMuhelyUj.Size = new System.Drawing.Size(114, 23);
            this.btnMuhelyUj.TabIndex = 0;
            this.btnMuhelyUj.Text = "Új felvétel";
            this.btnMuhelyUj.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnJarmuTorol);
            this.groupBox2.Controls.Add(this.btnJarmuMegjelenit);
            this.groupBox2.Controls.Add(this.btnJarmuModosit);
            this.groupBox2.Controls.Add(this.btnJarmuUj);
            this.groupBox2.Location = new System.Drawing.Point(478, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(130, 148);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Jármű";
            // 
            // btnJarmuTorol
            // 
            this.btnJarmuTorol.Location = new System.Drawing.Point(7, 109);
            this.btnJarmuTorol.Name = "btnJarmuTorol";
            this.btnJarmuTorol.Size = new System.Drawing.Size(114, 23);
            this.btnJarmuTorol.TabIndex = 3;
            this.btnJarmuTorol.Text = "Törlés";
            this.btnJarmuTorol.UseVisualStyleBackColor = true;
            // 
            // btnJarmuMegjelenit
            // 
            this.btnJarmuMegjelenit.Location = new System.Drawing.Point(7, 80);
            this.btnJarmuMegjelenit.Name = "btnJarmuMegjelenit";
            this.btnJarmuMegjelenit.Size = new System.Drawing.Size(114, 23);
            this.btnJarmuMegjelenit.TabIndex = 2;
            this.btnJarmuMegjelenit.Text = "Megjelenítés";
            this.btnJarmuMegjelenit.UseVisualStyleBackColor = true;
            // 
            // btnJarmuModosit
            // 
            this.btnJarmuModosit.Location = new System.Drawing.Point(7, 51);
            this.btnJarmuModosit.Name = "btnJarmuModosit";
            this.btnJarmuModosit.Size = new System.Drawing.Size(114, 23);
            this.btnJarmuModosit.TabIndex = 1;
            this.btnJarmuModosit.Text = "Módosítás";
            this.btnJarmuModosit.UseVisualStyleBackColor = true;
            // 
            // btnJarmuUj
            // 
            this.btnJarmuUj.Location = new System.Drawing.Point(7, 22);
            this.btnJarmuUj.Name = "btnJarmuUj";
            this.btnJarmuUj.Size = new System.Drawing.Size(114, 23);
            this.btnJarmuUj.TabIndex = 0;
            this.btnJarmuUj.Text = "Új felvétel";
            this.btnJarmuUj.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(485, 507);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(114, 23);
            this.button13.TabIndex = 4;
            this.button13.Text = "Kilépés";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "csv";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "CSV fájlok|*.csv|Minden fájl|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.Filter = "CSV fájlok|*.csv|Minden fájl|*.*";
            // 
            // btnMuhelyekMegjelenitese
            // 
            this.btnMuhelyekMegjelenitese.Location = new System.Drawing.Point(485, 360);
            this.btnMuhelyekMegjelenitese.Name = "btnMuhelyekMegjelenitese";
            this.btnMuhelyekMegjelenitese.Size = new System.Drawing.Size(114, 44);
            this.btnMuhelyekMegjelenitese.TabIndex = 9;
            this.btnMuhelyekMegjelenitese.Text = "Műhelyek megjelenítése";
            this.btnMuhelyekMegjelenitese.UseVisualStyleBackColor = true;
            // 
            // btnJarmuvekMegjelenitese
            // 
            this.btnJarmuvekMegjelenitese.Location = new System.Drawing.Point(485, 410);
            this.btnJarmuvekMegjelenitese.Name = "btnJarmuvekMegjelenitese";
            this.btnJarmuvekMegjelenitese.Size = new System.Drawing.Size(114, 46);
            this.btnJarmuvekMegjelenitese.TabIndex = 10;
            this.btnJarmuvekMegjelenitese.Text = "Járművek megjelenítése";
            this.btnJarmuvekMegjelenitese.UseVisualStyleBackColor = true;
            // 
            // btnRendezesek
            // 
            this.btnRendezesek.Location = new System.Drawing.Point(485, 462);
            this.btnRendezesek.Name = "btnRendezesek";
            this.btnRendezesek.Size = new System.Drawing.Size(114, 30);
            this.btnRendezesek.TabIndex = 11;
            this.btnRendezesek.Text = "Rendezések";
            this.btnRendezesek.UseVisualStyleBackColor = true;
            // 
            // lblJarmuAdatok
            // 
            this.lblJarmuAdatok.AutoSize = true;
            this.lblJarmuAdatok.Location = new System.Drawing.Point(12, 495);
            this.lblJarmuAdatok.MaximumSize = new System.Drawing.Size(456, 40);
            this.lblJarmuAdatok.MinimumSize = new System.Drawing.Size(456, 40);
            this.lblJarmuAdatok.Name = "lblJarmuAdatok";
            this.lblJarmuAdatok.Size = new System.Drawing.Size(456, 40);
            this.lblJarmuAdatok.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 541);
            this.Controls.Add(this.lblJarmuAdatok);
            this.Controls.Add(this.btnRendezesek);
            this.Controls.Add(this.btnJarmuvekMegjelenitese);
            this.Controls.Add(this.btnMuhelyekMegjelenitese);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lsbTeherAutok);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lsbSzemelyAutok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lsbMuhelyek);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem névjegyToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lsbMuhelyek;
        private System.Windows.Forms.ListBox lsbSzemelyAutok;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lsbTeherAutok;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMuhelyUj;
        private System.Windows.Forms.Button btnMuhelyTorol;
        private System.Windows.Forms.Button btnMuhelyMegjelenit;
        private System.Windows.Forms.Button btnMuhelyModosit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnJarmuTorol;
        private System.Windows.Forms.Button btnJarmuMegjelenit;
        private System.Windows.Forms.Button btnJarmuModosit;
        private System.Windows.Forms.Button btnJarmuUj;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnMuhelyekMegjelenitese;
        private System.Windows.Forms.Button btnJarmuvekMegjelenitese;
        private System.Windows.Forms.Button btnRendezesek;
        private System.Windows.Forms.Label lblJarmuAdatok;
    }
}

