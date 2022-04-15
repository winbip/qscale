using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QScale.CommonForms
{
    public partial class frmMsReportViewer : Form
    {
        public frmMsReportViewer()
        {
            InitializeComponent();
        }

        private void frmMsReportViewer_Load(object sender, EventArgs e)
        {

            this.rvReportViewer.RefreshReport();
        }

        /* ADD THIS CODE IN CALLER FORM

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                btnPrintReceipt.Enabled = false;
                CommonForms.frmMsReportViewer frm = new CommonForms.frmMsReportViewer();
                frm.rvReportViewer.ProcessingMode = ProcessingMode.Local;

                //BindingSource bsBookingInfo = new BindingSource();
                //bsBookingInfo.DataSource = bsBooking.Current as Booking;
                //ReportDataSource rds = new ReportDataSource();
                //rds.Name = "CustomObjects_Booking";
                //rds.Value = bsBookingInfo;
                //frm.rvReportViewer.LocalReport.DataSources.Add(rds);

                BindingSource bsCompany = new BindingSource();
                bsCompany.DataSource = GlobalVariables.currentUser.CompanyInformation;
                ReportDataSource rdsCompanyInfo = new ReportDataSource();
                rdsCompanyInfo.Name = "CustomObjects_CompanyInfo";
                rdsCompanyInfo.Value = bsCompany;
                frm.rvReportViewer.LocalReport.DataSources.Add(rdsCompanyInfo);

                BindingSource bsBookingInfo = new BindingSource();
                bsBookingInfo.DataSource = bsBooking.Current as Booking;
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "CustomObjects_Booking";
                rds.Value = bsBookingInfo;
                frm.rvReportViewer.LocalReport.DataSources.Add(rds);

                ReportParameter[] reportParameters = new ReportParameter[1];
                reportParameters[0] = new ReportParameter("pOperatingYear", LocalOperatingYear.ToString(), true);

                frm.rvReportViewer.LocalReport.ReportEmbeddedResource = "QScale.AllReports.BookingReceipt.rdlc";
                frm.rvReportViewer.LocalReport.SetParameters(reportParameters);

                btnPrintReceipt.Enabled = true;
                frm.Text = "Booking Receipt";
                frm.Show();
               
            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
                btnPrintReceipt.Enabled = true;
            }

        }

        */
    }
}
