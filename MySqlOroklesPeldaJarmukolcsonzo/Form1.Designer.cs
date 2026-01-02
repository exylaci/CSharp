namespace MySqlOroklesPeldaJarmukolcsonzo
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
            this.lsb = new System.Windows.Forms.ListBox();
            this.lsv = new System.Windows.Forms.ListView();
            this.btnKolcsonzoFelvetel = new System.Windows.Forms.Button();
            this.btnKolcsonzoModosit = new System.Windows.Forms.Button();
            this.btnKolcsonzoTorles = new System.Windows.Forms.Button();
            this.btnJarmuFelvetel = new System.Windows.Forms.Button();
            this.btnJarmuModosit = new System.Windows.Forms.Button();
            this.btnJarmuTorles = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lsb
            // 
            this.lsb.FormattingEnabled = true;
            this.lsb.ItemHeight = 16;
            this.lsb.Location = new System.Drawing.Point(13, 13);
            this.lsb.Name = "lsb";
            this.lsb.Size = new System.Drawing.Size(307, 276);
            this.lsb.TabIndex = 0;
            this.lsb.SelectedIndexChanged += new System.EventHandler(this.lsb_SelectedIndexChanged);
            // 
            // lsv
            // 
            this.lsv.HideSelection = false;
            this.lsv.Location = new System.Drawing.Point(341, 13);
            this.lsv.Name = "lsv";
            this.lsv.Size = new System.Drawing.Size(613, 275);
            this.lsv.TabIndex = 1;
            this.lsv.UseCompatibleStateImageBehavior = false;
            // 
            // btnKolcsonzoFelvetel
            // 
            this.btnKolcsonzoFelvetel.Location = new System.Drawing.Point(13, 297);
            this.btnKolcsonzoFelvetel.Name = "btnKolcsonzoFelvetel";
            this.btnKolcsonzoFelvetel.Size = new System.Drawing.Size(307, 33);
            this.btnKolcsonzoFelvetel.TabIndex = 2;
            this.btnKolcsonzoFelvetel.Text = "Új kölcsönző felvitele";
            this.btnKolcsonzoFelvetel.UseVisualStyleBackColor = true;
            this.btnKolcsonzoFelvetel.Click += new System.EventHandler(this.btnKolcsonzoFelvetel_Click);
            // 
            // btnKolcsonzoModosit
            // 
            this.btnKolcsonzoModosit.Location = new System.Drawing.Point(13, 336);
            this.btnKolcsonzoModosit.Name = "btnKolcsonzoModosit";
            this.btnKolcsonzoModosit.Size = new System.Drawing.Size(307, 33);
            this.btnKolcsonzoModosit.TabIndex = 3;
            this.btnKolcsonzoModosit.Text = "Kölcsönző módosítása";
            this.btnKolcsonzoModosit.UseVisualStyleBackColor = true;
            this.btnKolcsonzoModosit.Click += new System.EventHandler(this.btnKolcsonzoModosit_Click);
            // 
            // btnKolcsonzoTorles
            // 
            this.btnKolcsonzoTorles.Location = new System.Drawing.Point(13, 375);
            this.btnKolcsonzoTorles.Name = "btnKolcsonzoTorles";
            this.btnKolcsonzoTorles.Size = new System.Drawing.Size(307, 33);
            this.btnKolcsonzoTorles.TabIndex = 4;
            this.btnKolcsonzoTorles.Text = "Kölcsönző törlése";
            this.btnKolcsonzoTorles.UseVisualStyleBackColor = true;
            this.btnKolcsonzoTorles.Click += new System.EventHandler(this.btnKolcsonzoTorles_Click);
            // 
            // btnJarmuFelvetel
            // 
            this.btnJarmuFelvetel.Location = new System.Drawing.Point(341, 297);
            this.btnJarmuFelvetel.Name = "btnJarmuFelvetel";
            this.btnJarmuFelvetel.Size = new System.Drawing.Size(307, 33);
            this.btnJarmuFelvetel.TabIndex = 5;
            this.btnJarmuFelvetel.Text = "Új jármű felvitele";
            this.btnJarmuFelvetel.UseVisualStyleBackColor = true;
            this.btnJarmuFelvetel.Click += new System.EventHandler(this.btnJarmuFelvetel_Click);
            // 
            // btnJarmuModosit
            // 
            this.btnJarmuModosit.Location = new System.Drawing.Point(341, 336);
            this.btnJarmuModosit.Name = "btnJarmuModosit";
            this.btnJarmuModosit.Size = new System.Drawing.Size(307, 33);
            this.btnJarmuModosit.TabIndex = 6;
            this.btnJarmuModosit.Text = "Jármű módosítása";
            this.btnJarmuModosit.UseVisualStyleBackColor = true;
            this.btnJarmuModosit.Click += new System.EventHandler(this.btnJarmuModosit_Click);
            // 
            // btnJarmuTorles
            // 
            this.btnJarmuTorles.Location = new System.Drawing.Point(341, 375);
            this.btnJarmuTorles.Name = "btnJarmuTorles";
            this.btnJarmuTorles.Size = new System.Drawing.Size(307, 33);
            this.btnJarmuTorles.TabIndex = 7;
            this.btnJarmuTorles.Text = "Jármű törlése";
            this.btnJarmuTorles.UseVisualStyleBackColor = true;
            this.btnJarmuTorles.Click += new System.EventHandler(this.btnJarmuTorles_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(980, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnJarmuTorles);
            this.Controls.Add(this.btnJarmuModosit);
            this.Controls.Add(this.btnJarmuFelvetel);
            this.Controls.Add(this.btnKolcsonzoTorles);
            this.Controls.Add(this.btnKolcsonzoModosit);
            this.Controls.Add(this.btnKolcsonzoFelvetel);
            this.Controls.Add(this.lsv);
            this.Controls.Add(this.lsb);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsb;
        private System.Windows.Forms.ListView lsv;
        private System.Windows.Forms.Button btnKolcsonzoFelvetel;
        private System.Windows.Forms.Button btnKolcsonzoModosit;
        private System.Windows.Forms.Button btnKolcsonzoTorles;
        private System.Windows.Forms.Button btnJarmuFelvetel;
        private System.Windows.Forms.Button btnJarmuModosit;
        private System.Windows.Forms.Button btnJarmuTorles;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timer1;
    }
}

