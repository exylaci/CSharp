namespace Vizsgaremek_Szallashelyek
{
    partial class AccommodationForm
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
            this.txbName = new System.Windows.Forms.TextBox();
            this.grbAddress = new System.Windows.Forms.GroupBox();
            this.txbHouseNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbStreet = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbCity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numZipCode = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProfile = new System.Windows.Forms.ComboBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chbSpeciality = new System.Windows.Forms.CheckBox();
            this.lblBasePrice = new System.Windows.Forms.Label();
            this.numBasePrice = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.txbFinalPrice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label0 = new System.Windows.Forms.Label();
            this.txbID = new System.Windows.Forms.TextBox();
            this.grbStars = new System.Windows.Forms.GroupBox();
            this.btnRenovation = new System.Windows.Forms.Button();
            this.grbAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZipCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBasePrice)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Szálláshely neve:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(169, 39);
            this.txbName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(179, 22);
            this.txbName.TabIndex = 1;
            // 
            // grbAddress
            // 
            this.grbAddress.Controls.Add(this.txbHouseNumber);
            this.grbAddress.Controls.Add(this.label6);
            this.grbAddress.Controls.Add(this.txbStreet);
            this.grbAddress.Controls.Add(this.label5);
            this.grbAddress.Controls.Add(this.txbCity);
            this.grbAddress.Controls.Add(this.label4);
            this.grbAddress.Controls.Add(this.numZipCode);
            this.grbAddress.Controls.Add(this.label3);
            this.grbAddress.Location = new System.Drawing.Point(12, 64);
            this.grbAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbAddress.Name = "grbAddress";
            this.grbAddress.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbAddress.Size = new System.Drawing.Size(336, 124);
            this.grbAddress.TabIndex = 4;
            this.grbAddress.TabStop = false;
            this.grbAddress.Text = "Cím:";
            // 
            // txbHouseNumber
            // 
            this.txbHouseNumber.Location = new System.Drawing.Point(157, 94);
            this.txbHouseNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbHouseNumber.Name = "txbHouseNumber";
            this.txbHouseNumber.Size = new System.Drawing.Size(174, 22);
            this.txbHouseNumber.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(85, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Házszám:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txbStreet
            // 
            this.txbStreet.Location = new System.Drawing.Point(157, 68);
            this.txbStreet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbStreet.Name = "txbStreet";
            this.txbStreet.Size = new System.Drawing.Size(174, 22);
            this.txbStreet.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(113, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Utca:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txbCity
            // 
            this.txbCity.Location = new System.Drawing.Point(157, 43);
            this.txbCity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbCity.Name = "txbCity";
            this.txbCity.Size = new System.Drawing.Size(174, 22);
            this.txbCity.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Város:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numZipCode
            // 
            this.numZipCode.Location = new System.Drawing.Point(157, 17);
            this.numZipCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numZipCode.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numZipCode.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numZipCode.Name = "numZipCode";
            this.numZipCode.Size = new System.Drawing.Size(107, 22);
            this.numZipCode.TabIndex = 6;
            this.numZipCode.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Irányítószám:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Szálláshely profilja:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbProfile
            // 
            this.cmbProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfile.FormattingEnabled = true;
            this.cmbProfile.Location = new System.Drawing.Point(169, 192);
            this.cmbProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbProfile.Name = "cmbProfile";
            this.cmbProfile.Size = new System.Drawing.Size(179, 24);
            this.cmbProfile.TabIndex = 14;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(169, 219);
            this.cmbType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(179, 24);
            this.cmbType.TabIndex = 16;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Szálláshely típusa:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chbSpeciality
            // 
            this.chbSpeciality.AutoSize = true;
            this.chbSpeciality.Location = new System.Drawing.Point(169, 248);
            this.chbSpeciality.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbSpeciality.Name = "chbSpeciality";
            this.chbSpeciality.Size = new System.Drawing.Size(70, 20);
            this.chbSpeciality.TabIndex = 17;
            this.chbSpeciality.Text = "van-e?";
            this.chbSpeciality.UseVisualStyleBackColor = true;
            // 
            // lblBasePrice
            // 
            this.lblBasePrice.AutoSize = true;
            this.lblBasePrice.Location = new System.Drawing.Point(73, 274);
            this.lblBasePrice.Name = "lblBasePrice";
            this.lblBasePrice.Size = new System.Drawing.Size(90, 16);
            this.lblBasePrice.TabIndex = 18;
            this.lblBasePrice.Text = "Alap szobaár:";
            this.lblBasePrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numBasePrice
            // 
            this.numBasePrice.Location = new System.Drawing.Point(169, 272);
            this.numBasePrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numBasePrice.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numBasePrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBasePrice.Name = "numBasePrice";
            this.numBasePrice.Size = new System.Drawing.Size(179, 22);
            this.numBasePrice.TabIndex = 19;
            this.numBasePrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBasePrice.ValueChanged += new System.EventHandler(this.numBasePrice_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(91, 388);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "Aktuális ár:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txbFinalPrice
            // 
            this.txbFinalPrice.Location = new System.Drawing.Point(169, 385);
            this.txbFinalPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbFinalPrice.Name = "txbFinalPrice";
            this.txbFinalPrice.ReadOnly = true;
            this.txbFinalPrice.Size = new System.Drawing.Size(133, 22);
            this.txbFinalPrice.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(308, 388);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "forint";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(123, 425);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(106, 30);
            this.btnOK.TabIndex = 23;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(241, 425);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 30);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Mégsem";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label0
            // 
            this.label0.AutoSize = true;
            this.label0.Location = new System.Drawing.Point(11, 15);
            this.label0.Name = "label0";
            this.label0.Size = new System.Drawing.Size(151, 16);
            this.label0.TabIndex = 25;
            this.label0.Text = "Szálláshely azonosítója:";
            this.label0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txbID
            // 
            this.txbID.Location = new System.Drawing.Point(169, 12);
            this.txbID.Name = "txbID";
            this.txbID.ReadOnly = true;
            this.txbID.Size = new System.Drawing.Size(179, 22);
            this.txbID.TabIndex = 26;
            // 
            // grbStars
            // 
            this.grbStars.Location = new System.Drawing.Point(15, 298);
            this.grbStars.Name = "grbStars";
            this.grbStars.Size = new System.Drawing.Size(333, 83);
            this.grbStars.TabIndex = 27;
            this.grbStars.TabStop = false;
            this.grbStars.Text = "Minősítés:";
            // 
            // btnRenovation
            // 
            this.btnRenovation.Location = new System.Drawing.Point(5, 425);
            this.btnRenovation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRenovation.Name = "btnRenovation";
            this.btnRenovation.Size = new System.Drawing.Size(106, 30);
            this.btnRenovation.TabIndex = 28;
            this.btnRenovation.Text = "Renovation";
            this.btnRenovation.UseVisualStyleBackColor = true;
            this.btnRenovation.Click += new System.EventHandler(this.btnRenovation_Click);
            // 
            // AccommodationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 469);
            this.Controls.Add(this.btnRenovation);
            this.Controls.Add(this.grbStars);
            this.Controls.Add(this.txbID);
            this.Controls.Add(this.label0);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txbFinalPrice);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numBasePrice);
            this.Controls.Add(this.lblBasePrice);
            this.Controls.Add(this.chbSpeciality);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbProfile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grbAddress);
            this.Controls.Add(this.txbName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AccommodationForm";
            this.Text = "Szálláshely kezelése";
            this.grbAddress.ResumeLayout(false);
            this.grbAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZipCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBasePrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.GroupBox grbAddress;
        private System.Windows.Forms.TextBox txbHouseNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbStreet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbCity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numZipCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbProfile;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chbSpeciality;
        private System.Windows.Forms.Label lblBasePrice;
        private System.Windows.Forms.NumericUpDown numBasePrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbFinalPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label0;
        private System.Windows.Forms.TextBox txbID;
        private System.Windows.Forms.GroupBox grbStars;
        private System.Windows.Forms.Button btnRenovation;
    }
}