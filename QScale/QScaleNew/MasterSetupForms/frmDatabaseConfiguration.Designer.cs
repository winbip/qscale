namespace QScaleNew.MasterSetupForms
{
    partial class frmDatabaseConfiguration
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
            this.txtDatabaseDirectory = new System.Windows.Forms.TextBox();
            this.chkCreateNewDatabase = new System.Windows.Forms.CheckBox();
            this.btnSelectDatabaseDirectory = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDatabaseDirectory
            // 
            this.txtDatabaseDirectory.Location = new System.Drawing.Point(53, 84);
            this.txtDatabaseDirectory.Name = "txtDatabaseDirectory";
            this.txtDatabaseDirectory.Size = new System.Drawing.Size(446, 20);
            this.txtDatabaseDirectory.TabIndex = 0;
            // 
            // chkCreateNewDatabase
            // 
            this.chkCreateNewDatabase.AutoSize = true;
            this.chkCreateNewDatabase.Location = new System.Drawing.Point(53, 114);
            this.chkCreateNewDatabase.Name = "chkCreateNewDatabase";
            this.chkCreateNewDatabase.Size = new System.Drawing.Size(131, 17);
            this.chkCreateNewDatabase.TabIndex = 2;
            this.chkCreateNewDatabase.Text = "Create New Database";
            this.chkCreateNewDatabase.UseVisualStyleBackColor = true;
            // 
            // btnSelectDatabaseDirectory
            // 
            this.btnSelectDatabaseDirectory.Location = new System.Drawing.Point(508, 83);
            this.btnSelectDatabaseDirectory.Name = "btnSelectDatabaseDirectory";
            this.btnSelectDatabaseDirectory.Size = new System.Drawing.Size(31, 21);
            this.btnSelectDatabaseDirectory.TabIndex = 9;
            this.btnSelectDatabaseDirectory.Text = "...";
            this.btnSelectDatabaseDirectory.UseVisualStyleBackColor = true;
            this.btnSelectDatabaseDirectory.Click += new System.EventHandler(this.btnSelectDatabaseDirectory_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Database Directory";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(53, 153);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 33);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmDatabaseConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(551, 262);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectDatabaseDirectory);
            this.Controls.Add(this.chkCreateNewDatabase);
            this.Controls.Add(this.txtDatabaseDirectory);
            this.Name = "frmDatabaseConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Configuration";
            this.Load += new System.EventHandler(this.frmOperatingYearSetup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDatabaseDirectory;
        private System.Windows.Forms.CheckBox chkCreateNewDatabase;
        private System.Windows.Forms.Button btnSelectDatabaseDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
    }
}