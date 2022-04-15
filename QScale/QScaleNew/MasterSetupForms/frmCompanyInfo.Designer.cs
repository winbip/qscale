namespace QScaleNew.MasterSetupForms
{
    partial class frmCompanyInfo
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
            System.Windows.Forms.Label addressLineOneLabel;
            System.Windows.Forms.Label addressLineTwoLabel;
            System.Windows.Forms.Label companyNameLabel;
            this.txtAddressLineOne = new System.Windows.Forms.TextBox();
            this.txtAddressLineTwo = new System.Windows.Forms.TextBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.MyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.bsCurrentEntity = new System.Windows.Forms.BindingSource(this.components);
            addressLineOneLabel = new System.Windows.Forms.Label();
            addressLineTwoLabel = new System.Windows.Forms.Label();
            companyNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCurrentEntity)).BeginInit();
            this.SuspendLayout();
            // 
            // addressLineOneLabel
            // 
            addressLineOneLabel.AutoSize = true;
            addressLineOneLabel.Location = new System.Drawing.Point(40, 111);
            addressLineOneLabel.Name = "addressLineOneLabel";
            addressLineOneLabel.Size = new System.Drawing.Size(94, 13);
            addressLineOneLabel.TabIndex = 7;
            addressLineOneLabel.Text = "Address Line One:";
            // 
            // addressLineTwoLabel
            // 
            addressLineTwoLabel.AutoSize = true;
            addressLineTwoLabel.Location = new System.Drawing.Point(40, 163);
            addressLineTwoLabel.Name = "addressLineTwoLabel";
            addressLineTwoLabel.Size = new System.Drawing.Size(95, 13);
            addressLineTwoLabel.TabIndex = 10;
            addressLineTwoLabel.Text = "Address Line Two:";
            // 
            // companyNameLabel
            // 
            companyNameLabel.AutoSize = true;
            companyNameLabel.Location = new System.Drawing.Point(39, 54);
            companyNameLabel.Name = "companyNameLabel";
            companyNameLabel.Size = new System.Drawing.Size(85, 13);
            companyNameLabel.TabIndex = 12;
            companyNameLabel.Text = "Company Name:";
            // 
            // txtAddressLineOne
            // 
            this.txtAddressLineOne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddressLineOne.Location = new System.Drawing.Point(42, 127);
            this.txtAddressLineOne.Name = "txtAddressLineOne";
            this.txtAddressLineOne.Size = new System.Drawing.Size(437, 20);
            this.txtAddressLineOne.TabIndex = 9;
            // 
            // txtAddressLineTwo
            // 
            this.txtAddressLineTwo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddressLineTwo.Location = new System.Drawing.Point(42, 179);
            this.txtAddressLineTwo.Name = "txtAddressLineTwo";
            this.txtAddressLineTwo.Size = new System.Drawing.Size(437, 20);
            this.txtAddressLineTwo.TabIndex = 11;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyName.Location = new System.Drawing.Point(42, 70);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(437, 20);
            this.txtCompanyName.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(197, 269);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 37);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // MyErrorProvider
            // 
            this.MyErrorProvider.ContainerControl = this;
            // 
            // frmCompanyInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(518, 349);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(addressLineOneLabel);
            this.Controls.Add(this.txtAddressLineOne);
            this.Controls.Add(addressLineTwoLabel);
            this.Controls.Add(this.txtAddressLineTwo);
            this.Controls.Add(companyNameLabel);
            this.Controls.Add(this.txtCompanyName);
            this.Name = "frmCompanyInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Info";
            this.Load += new System.EventHandler(this.frmCompanyInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCurrentEntity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddressLineOne;
        private System.Windows.Forms.TextBox txtAddressLineTwo;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider MyErrorProvider;
        private System.Windows.Forms.BindingSource bsCurrentEntity;
    }
}