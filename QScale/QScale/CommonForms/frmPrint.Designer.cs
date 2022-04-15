namespace QScale.CommonForms
{
    partial class frmPrint
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
            this.crvMyReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvMyReportViewer
            // 
            this.crvMyReportViewer.ActiveViewIndex = -1;
            this.crvMyReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvMyReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvMyReportViewer.Location = new System.Drawing.Point(0, 0);
            this.crvMyReportViewer.Name = "crvMyReportViewer";
            this.crvMyReportViewer.SelectionFormula = "";
            this.crvMyReportViewer.Size = new System.Drawing.Size(606, 353);
            this.crvMyReportViewer.TabIndex = 0;
            this.crvMyReportViewer.ViewTimeSelectionFormula = "";
            // 
            // frmPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 353);
            this.Controls.Add(this.crvMyReportViewer);
            this.Name = "frmPrint";
            this.Text = "frmPrint";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvMyReportViewer;
    }
}