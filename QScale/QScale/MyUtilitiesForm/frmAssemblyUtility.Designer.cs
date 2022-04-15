namespace QScale.MyUtilitiesForm
{
    partial class frmAssemblyUtility
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
            this.cmbObjectName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPropertyNamesAndType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetProperty = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbObjectName
            // 
            this.cmbObjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbObjectName.FormattingEnabled = true;
            this.cmbObjectName.Location = new System.Drawing.Point(113, 35);
            this.cmbObjectName.Name = "cmbObjectName";
            this.cmbObjectName.Size = new System.Drawing.Size(261, 21);
            this.cmbObjectName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Objects/Classes";
            // 
            // txtPropertyNamesAndType
            // 
            this.txtPropertyNamesAndType.Location = new System.Drawing.Point(113, 66);
            this.txtPropertyNamesAndType.Multiline = true;
            this.txtPropertyNamesAndType.Name = "txtPropertyNamesAndType";
            this.txtPropertyNamesAndType.Size = new System.Drawing.Size(260, 227);
            this.txtPropertyNamesAndType.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(23, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Public Property and Type";
            // 
            // btnGetProperty
            // 
            this.btnGetProperty.Location = new System.Drawing.Point(26, 112);
            this.btnGetProperty.Name = "btnGetProperty";
            this.btnGetProperty.Size = new System.Drawing.Size(75, 23);
            this.btnGetProperty.TabIndex = 3;
            this.btnGetProperty.Text = "Get";
            this.btnGetProperty.UseVisualStyleBackColor = true;
            this.btnGetProperty.Click += new System.EventHandler(this.btnGetProperty_Click);
            // 
            // frmAssemblyUtility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 325);
            this.Controls.Add(this.btnGetProperty);
            this.Controls.Add(this.txtPropertyNamesAndType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbObjectName);
            this.Name = "frmAssemblyUtility";
            this.Text = "frmAssemblyUtility";
            this.Load += new System.EventHandler(this.frmAssemblyUtility_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbObjectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPropertyNamesAndType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetProperty;
    }
}