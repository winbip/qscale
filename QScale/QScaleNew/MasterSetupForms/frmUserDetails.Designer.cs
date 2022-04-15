namespace QScaleNew.MasterSetupForms
{
    partial class frmUserDetails
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
            System.Windows.Forms.Label fullNameLabel;
            System.Windows.Forms.Label logInNameLabel;
            System.Windows.Forms.Label logInPasswordLabel;
            System.Windows.Forms.Label userDesignationLabel;
            this.btnSelectUser = new System.Windows.Forms.Button();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtLogInName = new System.Windows.Forms.TextBox();
            this.txtLogInPassword = new System.Windows.Forms.TextBox();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.MyProgressBar = new System.Windows.Forms.ProgressBar();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNewEntity = new System.Windows.Forms.Button();
            this.MyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bsCurrentEntity = new System.Windows.Forms.BindingSource(this.components);
            this.RedToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            fullNameLabel = new System.Windows.Forms.Label();
            logInNameLabel = new System.Windows.Forms.Label();
            logInPasswordLabel = new System.Windows.Forms.Label();
            userDesignationLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCurrentEntity)).BeginInit();
            this.SuspendLayout();
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(54, 123);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(57, 13);
            fullNameLabel.TabIndex = 50;
            fullNameLabel.Text = "Full Name:";
            // 
            // logInNameLabel
            // 
            logInNameLabel.AutoSize = true;
            logInNameLabel.Location = new System.Drawing.Point(54, 69);
            logInNameLabel.Name = "logInNameLabel";
            logInNameLabel.Size = new System.Drawing.Size(71, 13);
            logInNameLabel.TabIndex = 51;
            logInNameLabel.Text = "Log In Name:";
            // 
            // logInPasswordLabel
            // 
            logInPasswordLabel.AutoSize = true;
            logInPasswordLabel.Location = new System.Drawing.Point(54, 96);
            logInPasswordLabel.Name = "logInPasswordLabel";
            logInPasswordLabel.Size = new System.Drawing.Size(89, 13);
            logInPasswordLabel.TabIndex = 52;
            logInPasswordLabel.Text = "Log In Password:";
            // 
            // userDesignationLabel
            // 
            userDesignationLabel.AutoSize = true;
            userDesignationLabel.Location = new System.Drawing.Point(54, 150);
            userDesignationLabel.Name = "userDesignationLabel";
            userDesignationLabel.Size = new System.Drawing.Size(91, 13);
            userDesignationLabel.TabIndex = 53;
            userDesignationLabel.Text = "User Designation:";
            // 
            // btnSelectUser
            // 
            this.btnSelectUser.Image = global::QScaleNew.Properties.Resources.SelectEmptyTruckPng32;
            this.btnSelectUser.Location = new System.Drawing.Point(314, 65);
            this.btnSelectUser.Name = "btnSelectUser";
            this.btnSelectUser.Size = new System.Drawing.Size(94, 48);
            this.btnSelectUser.TabIndex = 49;
            this.btnSelectUser.Text = "Select";
            this.btnSelectUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelectUser.UseVisualStyleBackColor = true;
            // 
            // txtFullName
            // 
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFullName.Location = new System.Drawing.Point(151, 120);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(257, 20);
            this.txtFullName.TabIndex = 47;
            // 
            // txtLogInName
            // 
            this.txtLogInName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogInName.Location = new System.Drawing.Point(151, 66);
            this.txtLogInName.Name = "txtLogInName";
            this.txtLogInName.Size = new System.Drawing.Size(100, 20);
            this.txtLogInName.TabIndex = 45;
            // 
            // txtLogInPassword
            // 
            this.txtLogInPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogInPassword.Location = new System.Drawing.Point(151, 93);
            this.txtLogInPassword.Name = "txtLogInPassword";
            this.txtLogInPassword.PasswordChar = '*';
            this.txtLogInPassword.Size = new System.Drawing.Size(100, 20);
            this.txtLogInPassword.TabIndex = 46;
            // 
            // txtDesignation
            // 
            this.txtDesignation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesignation.Location = new System.Drawing.Point(151, 147);
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.Size = new System.Drawing.Size(257, 20);
            this.txtDesignation.TabIndex = 48;
            // 
            // MyProgressBar
            // 
            this.MyProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyProgressBar.Location = new System.Drawing.Point(36, 258);
            this.MyProgressBar.Name = "MyProgressBar";
            this.MyProgressBar.Size = new System.Drawing.Size(436, 11);
            this.MyProgressBar.TabIndex = 54;
            this.MyProgressBar.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(397, 279);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 37);
            this.btnClose.TabIndex = 56;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(36, 279);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 37);
            this.btnSave.TabIndex = 57;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnNewEntity
            // 
            this.btnNewEntity.Location = new System.Drawing.Point(117, 279);
            this.btnNewEntity.Name = "btnNewEntity";
            this.btnNewEntity.Size = new System.Drawing.Size(75, 37);
            this.btnNewEntity.TabIndex = 58;
            this.btnNewEntity.Text = "&New";
            this.btnNewEntity.UseVisualStyleBackColor = true;
            // 
            // MyErrorProvider
            // 
            this.MyErrorProvider.ContainerControl = this;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(198, 279);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 37);
            this.btnDelete.TabIndex = 59;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // frmUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(484, 328);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNewEntity);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.MyProgressBar);
            this.Controls.Add(this.btnSelectUser);
            this.Controls.Add(fullNameLabel);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(logInNameLabel);
            this.Controls.Add(this.txtLogInName);
            this.Controls.Add(logInPasswordLabel);
            this.Controls.Add(this.txtLogInPassword);
            this.Controls.Add(userDesignationLabel);
            this.Controls.Add(this.txtDesignation);
            this.Name = "frmUserDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Details";
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCurrentEntity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectUser;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtLogInName;
        private System.Windows.Forms.TextBox txtLogInPassword;
        private System.Windows.Forms.TextBox txtDesignation;
        private System.Windows.Forms.ProgressBar MyProgressBar;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNewEntity;
        private System.Windows.Forms.ErrorProvider MyErrorProvider;
        private System.Windows.Forms.ToolTip MyToolTip;
        private System.Windows.Forms.BindingSource bsCurrentEntity;
        private System.Windows.Forms.ToolTip RedToolTip;
        private System.Windows.Forms.Button btnDelete;
    }
}