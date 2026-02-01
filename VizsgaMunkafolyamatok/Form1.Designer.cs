namespace VizsgaMunkafolyamatok
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
            this.label1 = new System.Windows.Forms.Label();
            this.lsbSzemelyek = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMunkafolyamatok = new System.Windows.Forms.ComboBox();
            this.btnGeneralas = new System.Windows.Forms.Button();
            this.btnTorles = new System.Windows.Forms.Button();
            this.btnUjMunkafolyamat = new System.Windows.Forms.Button();
            this.btnSzamlazas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Személyek";
            // 
            // lsbSzemelyek
            // 
            this.lsbSzemelyek.FormattingEnabled = true;
            this.lsbSzemelyek.ItemHeight = 16;
            this.lsbSzemelyek.Location = new System.Drawing.Point(15, 28);
            this.lsbSzemelyek.Name = "lsbSzemelyek";
            this.lsbSzemelyek.Size = new System.Drawing.Size(198, 164);
            this.lsbSzemelyek.TabIndex = 1;
            this.lsbSzemelyek.SelectedIndexChanged += new System.EventHandler(this.lsbSzemelyek_SelectedIndexChanged);
            this.lsbSzemelyek.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsbSzemelyek_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Munkafolyamatok:";
            // 
            // cmbMunkafolyamatok
            // 
            this.cmbMunkafolyamatok.FormattingEnabled = true;
            this.cmbMunkafolyamatok.Location = new System.Drawing.Point(237, 28);
            this.cmbMunkafolyamatok.Name = "cmbMunkafolyamatok";
            this.cmbMunkafolyamatok.Size = new System.Drawing.Size(198, 24);
            this.cmbMunkafolyamatok.TabIndex = 3;
            this.cmbMunkafolyamatok.SelectedIndexChanged += new System.EventHandler(this.cmbMunkafolyamatok_SelectedIndexChanged);
            // 
            // btnGeneralas
            // 
            this.btnGeneralas.Location = new System.Drawing.Point(15, 198);
            this.btnGeneralas.Name = "btnGeneralas";
            this.btnGeneralas.Size = new System.Drawing.Size(198, 30);
            this.btnGeneralas.TabIndex = 4;
            this.btnGeneralas.Text = "Személyek generálása";
            this.btnGeneralas.UseVisualStyleBackColor = true;
            this.btnGeneralas.Click += new System.EventHandler(this.btnGeneralas_Click);
            // 
            // btnTorles
            // 
            this.btnTorles.Enabled = false;
            this.btnTorles.Location = new System.Drawing.Point(15, 234);
            this.btnTorles.Name = "btnTorles";
            this.btnTorles.Size = new System.Drawing.Size(198, 30);
            this.btnTorles.TabIndex = 5;
            this.btnTorles.Text = "Személy törlése";
            this.btnTorles.UseVisualStyleBackColor = true;
            this.btnTorles.Click += new System.EventHandler(this.btnTorles_Click);
            // 
            // btnUjMunkafolyamat
            // 
            this.btnUjMunkafolyamat.Location = new System.Drawing.Point(237, 198);
            this.btnUjMunkafolyamat.Name = "btnUjMunkafolyamat";
            this.btnUjMunkafolyamat.Size = new System.Drawing.Size(198, 30);
            this.btnUjMunkafolyamat.TabIndex = 6;
            this.btnUjMunkafolyamat.Text = "Munka felvétele";
            this.btnUjMunkafolyamat.UseVisualStyleBackColor = true;
            this.btnUjMunkafolyamat.Click += new System.EventHandler(this.btnUjMunkafolyamat_Click);
            // 
            // btnSzamlazas
            // 
            this.btnSzamlazas.Enabled = false;
            this.btnSzamlazas.Location = new System.Drawing.Point(237, 234);
            this.btnSzamlazas.Name = "btnSzamlazas";
            this.btnSzamlazas.Size = new System.Drawing.Size(198, 30);
            this.btnSzamlazas.TabIndex = 7;
            this.btnSzamlazas.Text = "Számlázás";
            this.btnSzamlazas.UseVisualStyleBackColor = true;
            this.btnSzamlazas.Click += new System.EventHandler(this.btnSzamlazas_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 277);
            this.Controls.Add(this.btnSzamlazas);
            this.Controls.Add(this.btnUjMunkafolyamat);
            this.Controls.Add(this.btnTorles);
            this.Controls.Add(this.btnGeneralas);
            this.Controls.Add(this.cmbMunkafolyamatok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lsbSzemelyek);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lsbSzemelyek;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMunkafolyamatok;
        private System.Windows.Forms.Button btnGeneralas;
        private System.Windows.Forms.Button btnTorles;
        private System.Windows.Forms.Button btnUjMunkafolyamat;
        private System.Windows.Forms.Button btnSzamlazas;
    }
}

