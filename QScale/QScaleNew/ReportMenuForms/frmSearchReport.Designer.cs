namespace QScaleNew.ReportMenuForms
{
    partial class frmSearchReport
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
            this.bsCurrentEntity = new System.Windows.Forms.BindingSource(this.components);
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.bgwPrimaryWorker = new System.ComponentModel.BackgroundWorker();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.bsProduct = new System.Windows.Forms.BindingSource(this.components);
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbCustomDateRange = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbToYear = new System.Windows.Forms.ComboBox();
            this.cmbToMonth = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbToDay = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbFromYear = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbFromMonth = new System.Windows.Forms.ComboBox();
            this.cmbFromDay = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioCustomDateRange = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.bsCurrentEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProduct)).BeginInit();
            this.gbCustomDateRange.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyErrorProvider
            // 
            this.MyErrorProvider.ContainerControl = this;
            // 
            // bgwPrimaryWorker
            // 
            this.bgwPrimaryWorker.WorkerReportsProgress = true;
            this.bgwPrimaryWorker.WorkerSupportsCancellation = true;
            // 
            // cmbProduct
            // 
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(121, 39);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(253, 21);
            this.cmbProduct.TabIndex = 13;
            // 
            // cmbClient
            // 
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(121, 70);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(253, 21);
            this.cmbClient.TabIndex = 14;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(121, 231);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(115, 33);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "Prepare";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Product/Item";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Customer/Vendor";
            // 
            // gbCustomDateRange
            // 
            this.gbCustomDateRange.Controls.Add(this.label9);
            this.gbCustomDateRange.Controls.Add(this.label8);
            this.gbCustomDateRange.Controls.Add(this.label7);
            this.gbCustomDateRange.Controls.Add(this.cmbToYear);
            this.gbCustomDateRange.Controls.Add(this.cmbToMonth);
            this.gbCustomDateRange.Controls.Add(this.label6);
            this.gbCustomDateRange.Controls.Add(this.cmbToDay);
            this.gbCustomDateRange.Controls.Add(this.label5);
            this.gbCustomDateRange.Controls.Add(this.cmbFromYear);
            this.gbCustomDateRange.Controls.Add(this.label4);
            this.gbCustomDateRange.Controls.Add(this.cmbFromMonth);
            this.gbCustomDateRange.Controls.Add(this.cmbFromDay);
            this.gbCustomDateRange.Location = new System.Drawing.Point(241, 100);
            this.gbCustomDateRange.Name = "gbCustomDateRange";
            this.gbCustomDateRange.Size = new System.Drawing.Size(255, 104);
            this.gbCustomDateRange.TabIndex = 21;
            this.gbCustomDateRange.TabStop = false;
            this.gbCustomDateRange.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(189, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Year";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(113, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Month";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Day";
            // 
            // cmbToYear
            // 
            this.cmbToYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToYear.FormattingEnabled = true;
            this.cmbToYear.Location = new System.Drawing.Point(170, 70);
            this.cmbToYear.Name = "cmbToYear";
            this.cmbToYear.Size = new System.Drawing.Size(72, 21);
            this.cmbToYear.TabIndex = 31;
            // 
            // cmbToMonth
            // 
            this.cmbToMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToMonth.FormattingEnabled = true;
            this.cmbToMonth.Location = new System.Drawing.Point(105, 70);
            this.cmbToMonth.Name = "cmbToMonth";
            this.cmbToMonth.Size = new System.Drawing.Size(59, 21);
            this.cmbToMonth.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(81, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Custom Date Range";
            // 
            // cmbToDay
            // 
            this.cmbToDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToDay.FormattingEnabled = true;
            this.cmbToDay.Location = new System.Drawing.Point(40, 70);
            this.cmbToDay.Name = "cmbToDay";
            this.cmbToDay.Size = new System.Drawing.Size(59, 21);
            this.cmbToDay.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "To";
            // 
            // cmbFromYear
            // 
            this.cmbFromYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromYear.FormattingEnabled = true;
            this.cmbFromYear.Location = new System.Drawing.Point(170, 46);
            this.cmbFromYear.Name = "cmbFromYear";
            this.cmbFromYear.Size = new System.Drawing.Size(72, 21);
            this.cmbFromYear.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "From";
            // 
            // cmbFromMonth
            // 
            this.cmbFromMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromMonth.FormattingEnabled = true;
            this.cmbFromMonth.Location = new System.Drawing.Point(105, 46);
            this.cmbFromMonth.Name = "cmbFromMonth";
            this.cmbFromMonth.Size = new System.Drawing.Size(59, 21);
            this.cmbFromMonth.TabIndex = 27;
            // 
            // cmbFromDay
            // 
            this.cmbFromDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromDay.FormattingEnabled = true;
            this.cmbFromDay.Location = new System.Drawing.Point(40, 46);
            this.cmbFromDay.Name = "cmbFromDay";
            this.cmbFromDay.Size = new System.Drawing.Size(59, 21);
            this.cmbFromDay.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Date";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioCustomDateRange);
            this.groupBox3.Controls.Add(this.radioButton5);
            this.groupBox3.Location = new System.Drawing.Point(120, 100);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(115, 104);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            // 
            // radioCustomDateRange
            // 
            this.radioCustomDateRange.AutoSize = true;
            this.radioCustomDateRange.Location = new System.Drawing.Point(11, 54);
            this.radioCustomDateRange.Name = "radioCustomDateRange";
            this.radioCustomDateRange.Size = new System.Drawing.Size(95, 17);
            this.radioCustomDateRange.TabIndex = 1;
            this.radioCustomDateRange.Text = "Custom Range";
            this.radioCustomDateRange.UseVisualStyleBackColor = true;
            this.radioCustomDateRange.CheckedChanged += new System.EventHandler(this.radioCustomDateRange_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Checked = true;
            this.radioButton5.Location = new System.Drawing.Point(11, 31);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(62, 17);
            this.radioButton5.TabIndex = 0;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "All Date";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // frmSearchReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(521, 277);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gbCustomDateRange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmbClient);
            this.Controls.Add(this.cmbProduct);
            this.MaximumSize = new System.Drawing.Size(537, 316);
            this.MinimumSize = new System.Drawing.Size(537, 316);
            this.Name = "frmSearchReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            ((System.ComponentModel.ISupportInitialize)(this.bsCurrentEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProduct)).EndInit();
            this.gbCustomDateRange.ResumeLayout(false);
            this.gbCustomDateRange.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource bsCurrentEntity;
        private System.Windows.Forms.ToolTip MyToolTip;
        private System.Windows.Forms.ErrorProvider MyErrorProvider;
        private System.ComponentModel.BackgroundWorker bgwPrimaryWorker;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.BindingSource bsProduct;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioCustomDateRange;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbCustomDateRange;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbToYear;
        private System.Windows.Forms.ComboBox cmbToMonth;
        private System.Windows.Forms.ComboBox cmbToDay;
        private System.Windows.Forms.ComboBox cmbFromYear;
        private System.Windows.Forms.ComboBox cmbFromMonth;
        private System.Windows.Forms.ComboBox cmbFromDay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}