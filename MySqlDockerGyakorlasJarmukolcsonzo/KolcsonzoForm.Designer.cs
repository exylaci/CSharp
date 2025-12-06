namespace MySqlDockerGyakorlasJarmukolcsonzo
{
    partial class KolcsonzoForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.txbId = new System.Windows.Forms.TextBox();
            this.txbNev = new System.Windows.Forms.TextBox();
            this.txbCim = new System.Windows.Forms.TextBox();
            this.txbTulaj = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.listview = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Név:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cím:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tulajdonos:";
            // 
            // txbId
            // 
            this.txbId.Location = new System.Drawing.Point(96, 12);
            this.txbId.Name = "txbId";
            this.txbId.ReadOnly = true;
            this.txbId.Size = new System.Drawing.Size(186, 22);
            this.txbId.TabIndex = 4;
            // 
            // txbNev
            // 
            this.txbNev.Location = new System.Drawing.Point(96, 40);
            this.txbNev.Name = "txbNev";
            this.txbNev.Size = new System.Drawing.Size(186, 22);
            this.txbNev.TabIndex = 5;
            // 
            // txbCim
            // 
            this.txbCim.Location = new System.Drawing.Point(96, 68);
            this.txbCim.Name = "txbCim";
            this.txbCim.Size = new System.Drawing.Size(186, 22);
            this.txbCim.TabIndex = 6;
            // 
            // txbTulaj
            // 
            this.txbTulaj.Location = new System.Drawing.Point(96, 96);
            this.txbTulaj.Name = "txbTulaj";
            this.txbTulaj.Size = new System.Drawing.Size(186, 22);
            this.txbTulaj.TabIndex = 7;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(96, 137);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(86, 26);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(196, 137);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 26);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Mégsem";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // listview
            // 
            this.listview.HideSelection = false;
            this.listview.Location = new System.Drawing.Point(290, 14);
            this.listview.Name = "listview";
            this.listview.Size = new System.Drawing.Size(456, 148);
            this.listview.TabIndex = 10;
            this.listview.UseCompatibleStateImageBehavior = false;
            // 
            // KolcsonzoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 177);
            this.Controls.Add(this.listview);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txbTulaj);
            this.Controls.Add(this.txbCim);
            this.Controls.Add(this.txbNev);
            this.Controls.Add(this.txbId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "KolcsonzoForm";
            this.Text = "Kölcsönző";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbId;
        private System.Windows.Forms.TextBox txbNev;
        private System.Windows.Forms.TextBox txbCim;
        private System.Windows.Forms.TextBox txbTulaj;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView listview;
    }
}