using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;

namespace QScale.CommonForms
{
    public partial class frmPrint : Form
    {
        public frmPrint()
        {
            InitializeComponent();
            {// initializing started
                this.StartPosition = FormStartPosition.CenterScreen;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.ShowIcon = false;
                this.ShowInTaskbar = false;
                //.Text = " Cash Book"
                this.BackColor = Color.SlateGray;


                this.crvMyReportViewer.DisplayGroupTree = false;
                this.crvMyReportViewer.ShowExportButton = true;
                this.crvMyReportViewer.ShowGroupTreeButton = false;
                this.crvMyReportViewer.ShowGotoPageButton = false;
                this.crvMyReportViewer.ShowPageNavigateButtons = true;
                this.crvMyReportViewer.ShowRefreshButton = false;
                this.crvMyReportViewer.ShowTextSearchButton = false;
                this.crvMyReportViewer.ShowZoomButton = true;
                this.crvMyReportViewer.ShowCloseButton = false;

            }//initializing finished

        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            try
            {
                Application.DoEvents();
                crvMyReportViewer.Refresh();
                Application.DoEvents();
                //frmProgressBar.lblWaitMessage.Text = "Loading completed."
                //Application.DoEvents()
                //frmProgressBar.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void crvMyReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                Application.DoEvents();
                crvMyReportViewer.Refresh();
                Application.DoEvents();
                frmProgressBar frm = new frmProgressBar();
                frm.lblWaitMessage.Text = "Loading completed.";
                Application.DoEvents();
                frm.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //_________________________________________________________________________________________
        //THE FOLLOWING SUB IS TEMPLATE CODE, DONT DELETE IT. USE THIS CODE ON CALLER FORM
        //=========================================================================================

        /* public dsSalaryStatement dsSalaryStatementDataset;
           public DataTable dtSalaryStatementForPrint;*/


        //btnPrint_Click(System.Object sender, System.EventArgs e)
        //{
        //    try {
        //        dsSalaryStatementDataset = new dsSalaryStatement();

        //        dtSalaryStatementForPrint = new DataTable();
        //        dtSalaryStatementForPrint = dsSalaryStatementDataset.Tables("tblSalaryStatement");

        //        Application.DoEvents();
        //        frmProgressBar.lblWaitMessage.Text = "Loading data...... Please wait.";
        //        frmProgressBar.Show();
        //        Application.DoEvents();

        //        DataRow DR;
        //        for (int i = 0; i <= dgWorkingDays.RowCount - 1; i++) {
        //            DR = dtSalaryStatementForPrint.NewRow();
        //            {
        //                DR("SLNo") = i + 1;
        //                DR("EmployeeName") = dgWorkingDays.Item("EmployeeName", i).FormattedValue;
        //                DR("Designation") = dgWorkingDays.Item("Designation", i).FormattedValue;
        //                DR("MonthlySalary") = dgWorkingDays.Item("MonthlySalary", i).FormattedValue;
        //                DR("WorkingDays") = dgWorkingDays.Item("WorkingDays", i).FormattedValue;
        //                DR("AdjustedSalary") = dgWorkingDays.Item("AdjustedSalary", i).FormattedValue;
        //                DR("MonthlyInstallment") = dgWorkingDays.Item("MonthlyInstallment", i).FormattedValue;
        //                DR("PayableSalary") = dgWorkingDays.Item("PayableSalary", i).FormattedValue;
        //            }
        //            dtSalaryStatementForPrint.Rows.Add(DR);
        //        }

        //        MyReport = new crSalaryStatement();

        //        {
        //            MyReport.SetDataSource(this.dtSalaryStatementForPrint);
        //            MyReport.SetParameterValue("pfMonthName", this.cmbMonth.Text + ", " + this.txtYearName.Text);
        //        }

        //        frmPrint frmSalaryStatementPrint = new frmPrint();

        //        {
        //            frmSalaryStatementPrint.Text = "Salary Statement";
        //            frmSalaryStatementPrint.crvMyReportViewer.ReportSource = MyReport;
        //            frmSalaryStatementPrint.Show();
        //        }

        //    } catch (Exception ex) {
        //        MsgBox(ex.Message);
        //    }

        //}

    }
}
