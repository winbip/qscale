using CustomObjects;
using Microsoft.Reporting.WinForms;
using sCommonLib;
using sCommonLib.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace QScaleNew.ReportMenuForms
{
    public partial class frmSearchReport : Form
    {
        #region Private Variables
        private DataTable dtData;
        // private frmMain mainForm;
        private int pSelectedEntityId;
        #endregion


        public frmSearchReport()
        {
            InitializeComponent();
            AddEventHandlers();
        }


        #region Assigning Event Handlers

        private void AddEventHandlers()
        {

            this.Load += FormLoadHandler;
            //txtClientCode.TextChanged += FilterDataGridView; //TextBoxName must be equal to datasource column name
            //dgData.CellMouseEnter += dgData_CellMouseEnter;
            //dgData.CellMouseLeave += dgData_CellMouseLeave;
            //dgData.CellDoubleClick += dgData_CellDoubleClick;
            this.bgwPrimaryWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PrimaryWork);
            this.bgwPrimaryWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.PrimaryProgress);
            this.bgwPrimaryWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.PrimaryWorkCompleted);

        }
        #endregion

        #region FormatDatagrid


        //private void FormatdgData()
        //{
        //    dgData.DefaultCellStyle.FormatProvider = GlobalVariables.CurrentCultureInfo;
        //    dgData.RowHeadersVisible = false;
        //    dgData.AllowUserToAddRows = false;
        //    dgData.AllowUserToDeleteRows = false;
        //    dgData.AllowUserToResizeRows = true;

        //    dgData.ColumnHeadersVisible = true;
        //    dgData.AllowUserToOrderColumns = false;
        //    dgData.AllowUserToResizeColumns = true;

        //    dgData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    dgData.ScrollBars = ScrollBars.Vertical;
        //    dgData.ReadOnly = true;
        //    dgData.MultiSelect = false;

        //    dgData.EnableHeadersVisualStyles = false;
        //    dgData.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        //    dgData.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;

        //    dgData.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
        //    dgData.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        //    dgData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    //dgData.ColumnHeadersDefaultCellStyle.Font = new Font(MyFontName, MyFontSize, FontStyle.Regular);

        //    dgData.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        //    //SingleHorizontal is required to set custom gridcolor

        //    dgData.GridColor = Color.LightSteelBlue;
        //    //dgData.BorderStyle = BorderStyle.None;
        //    //dgData.BackgroundColor = ControlFunctions.FormBackColor;

        //    dgData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        //    dgData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        //    dgData.DefaultCellStyle.BackColor = Color.White;
        //    dgData.DefaultCellStyle.ForeColor = Color.Black;

        //    dgData.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
        //    dgData.DefaultCellStyle.SelectionForeColor = Color.White;

        //    // dgData.Columns[0].Visible = false;

        //    //dgData.Columns[1].Visible = true;
        //    //dgData.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //    //dgData.Columns[1].Width = 100;
        //    //dgData.Columns[1].ReadOnly = true;
        //    //dgData.Columns[1].HeaderText = "Session";
        //    //dgData.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        //    //dgData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    //dgData.Columns[1].HeaderCell.Style.BackColor = Color.Lavender;
        //    //dgData.Columns[1].HeaderCell.Style.ForeColor = Color.SlateGray;
        //    //dgData.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    //dgData.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;


        //    dgData.ClearSelection();

        //}

        #endregion

        #region FormEventHandlers

        private void FormLoadHandler(object sender, EventArgs e)
        {
            // MyNavBar.Collapsed = true;
            // StartPrimaryWorker();
          
            List<Product> productList = Product.GetEntityList(GlobalVariables.ConnectionString); ;

            productList.Insert(0, new Product() { ProductId = -1, ProductName = "All" });

            bsProduct.DataSource = typeof(Client);
            bsProduct.DataSource = productList;
            cmbProduct.DataSource = bsProduct;
            cmbProduct.DisplayMember = "ProductName";
            cmbProduct.ValueMember = "ProductId";

            List<Client> clientList = Client.GetEntityList(GlobalVariables.ConnectionString);
            clientList.Insert(0, new Client() { ClientId = -1, ClientName = "All" });
            BindingSource bsClient = new BindingSource();
            bsClient.DataSource = clientList;
            cmbClient.DataSource = bsClient;
            cmbClient.DisplayMember = "ClientName";
            cmbClient.ValueMember = "ClientId";

            for (int i = 1; i <= 31; i++)
            {
                cmbFromDay.Items.Add(i.ToString("00"));
                cmbToDay.Items.Add(i.ToString("00"));
            }

            for (int i = 1; i <= 12; i++)
            {
                cmbFromMonth.Items.Add(i.ToString("00"));
                cmbToMonth.Items.Add(i.ToString("00"));
            }

            int year = DateTime.Now.Year;

            for (int i = year; i > year-10; i--)
            {
                cmbFromYear.Items.Add(i);
                cmbToYear.Items.Add(i);
            }
        }

        #endregion

        #region BackgroundWorker Helper Methods

        private int ProgressValue;
        private void StartPrimaryWorker()
        {
            this.Cursor = Cursors.WaitCursor;
            //this.MyProgressBar.Maximum = 10;
            //this.MyProgressBar.Value = 0;
            //this.MyProgressBar.Visible = true;
            bgwPrimaryWorker.RunWorkerAsync();
        }

        private void ReportPrimaryProgress()
        {
            ProgressValue += 1;
            bgwPrimaryWorker.ReportProgress(ProgressValue);
            System.Threading.Thread.Sleep(100);
        }

        private void ReportPostProgress()
        {
            Application.DoEvents();
            //ProgressValue += 1;
            //MyProgressBar.Value += 1;
            System.Threading.Thread.Sleep(100);
        }

        #endregion

        #region BackGroundWorker Event Handlers

        //=========================================================For Reference
        // private void btnStart_Click(object sender, EventArgs e)
        //{
        //    string ArgId = txtArgId.Text.Trim();
        //    string Name = txtArgName.Text.Trim();
        //    string Age = txtArgAge.Text.Trim();

        //    object[] Args = new object[] { ArgId, Name, Age };
        //   StartPrimaryWorker(Args);
        //}
        //===========================================================


        private void PrimaryWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //object[] Args = (object[])e.Argument;
                //string ArgId = Args[0].ToString();
                //string Name = Args[1].ToString();
                //string Age = Args[2].ToString();

                //e.Result = new object[] { ArgId,Name,Age};

                string sqlSelectData = "select * from qryTruckInHistory";

                using (OleDbDataAdapter da = new OleDbDataAdapter(sqlSelectData, GlobalVariables.ConnectionString))
                {
                    dtData = new DataTable();
                    da.Fill(dtData);
                }
            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
        }


        private void PrimaryProgress(object sender, ProgressChangedEventArgs e)
        {
            //MyProgressBar.Value = e.ProgressPercentage;
        }

        private void PrimaryWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                //For Help
                //DataSet dsData = e.Result as DataSet;


                if (e.Cancelled)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Cancelled", "Tasks Cancelled", "Tasks have been cancelled. Please try again."));
                }
                else if (e.Error != null)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Error", "Error", e.Error.Message));
                }
                else
                {
                    DataView dv = new DataView(dtData, "", "", DataViewRowState.CurrentRows);
                  //  dgData.DataSource = dv; FormatdgData();


                    //if (e.Result != null)
                    //{
                    //    object[] Result;

                    //    Result = (object[])e.Result;
                    //    string ArgId = Result[0].ToString();
                    //    string Name = Result[1].ToString();
                    //    string Age = Result[2].ToString();

                    //    txtResultId.Text = ArgId;
                    //    txtResultName.Text = Name;
                    //    txtResultAge.Text = Age;
                    //}
                    //else
                    //{
                    //    //Show message if result is empty.
                    //}

                }

            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
            finally
            {
               // this.Cursor = Cursors.Default; MyProgressBar.Visible = false;
            }
        }



        #endregion

        #region Button Click Events

        private void DeleteEntity(object sender, EventArgs e)
        {

        }

        private void ExportDataToExcel(object sender, EventArgs e)
        {
            /*  try
              {
                  btnExport.Text = "Wait..";
                  btnExport.Enabled = false;
               
                  DataExporter.ExportToExcel.Export(dgData, MastHead.Text);
                  btnExport.Text = "&Export"; btnExport.Enabled = true;
              }
              catch (Exception Ex)
              {
                  MessageBox.Show(Ex.Message);
                  btnExport.Text = "&Export"; btnExport.Enabled = true;               
              }*/
        }
        #endregion

        #region Datagridview CellMouseEnter,CellMouseLeave, CellDoubleClick Events Handler


        //private void dgData_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex > -1)
        //    {
        //        dgData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.WhiteSmoke;
        //        dgData.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        //    }
        //}

        //private void dgData_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex > -1)
        //    {
        //        dgData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
        //        dgData.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        //    }
        //}

        //private void dgData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    pSelectedEntityId = (int)dgData.CurrentRow.Cells[0].Value;
        //    this.DialogResult = DialogResult.OK;

        //}

        #endregion

        #region Filter DataGridView

        //private void FilterDataGridView(object sender, EventArgs e)
        //{

        //    Control control = (Control)sender;

        //    string ColumnName = control.Name.ToString().Replace("txt", "");
        //    string FiltereringParameter = control.Text.Trim();

        //    DataView dvDataSource = (DataView)dgData.DataSource; //Copy existing dataview to new variable

        //    dvDataSource.RowFilter = ColumnName + " Like '*" + FiltereringParameter + "*'";
        //    dgData.ClearSelection();

        //    /* Note- No need the following code for the time being.
        //    if (FilteredText.Length > 0)
        //    {
        //        dvDataSource.RowFilter = controlName + " Like '*" + FilteredText + "*'";

        //        dgData.ClearSelection();
        //    }
        //    else
        //    {
        //        DataView dv = new DataView(dtData, "", "", DataViewRowState.CurrentRows);
        //        dgData.DataSource = dv; dgData.ClearSelection();
        //    }
        //    */
        //}


        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {


            btnSearch.Enabled = false;

            try
            {

                Product product = (Product)cmbProduct.SelectedItem;
                Client client = (Client)cmbClient.SelectedItem;

                string strFromDate = ""; // txtFromDate.Text.Trim();
                string strToDate = "";   // txtToDate.Text.Trim();

                List<ReportData> reportDataList= new List<ReportData>();
                DateTime fromDate;
                DateTime toDate;
                if(radioCustomDateRange.Checked == true)
                {
                    fromDate = new DateTime(Convert.ToInt32(cmbFromYear.Text), Convert.ToInt32(cmbFromMonth.Text), Convert.ToInt32(cmbFromDay.Text));
                    strFromDate = ""+ cmbFromYear.Text + "/"+ cmbFromMonth.Text + "/"+ cmbFromDay.Text + "";

                    toDate = new DateTime(Convert.ToInt32(cmbToYear.Text), Convert.ToInt32(cmbToMonth.Text), Convert.ToInt32(cmbToDay.Text));
                    strToDate = "" + cmbToYear.Text + "/" + cmbToMonth.Text + "/" + cmbToDay.Text + "";
                    //DateTime.TryParseExact(txtFromDate.Text.Trim(), "dd/MM/yyyy",
                    //    GlobalVariables.CurrentCultureInfo, DateTimeStyles.AllowLeadingWhite, out fromDate);

                    //DateTime.TryParseExact(txtToDate.Text.Trim(), "dd/MM/yyyy",
                    //   GlobalVariables.CurrentCultureInfo, DateTimeStyles.AllowLeadingWhite, out toDate);

                    //DateTime? dt = (DateTime?)fromDate;

                    reportDataList = ReportData.GetEntityList(GlobalVariables.ConnectionString,
                                                                 product, client, strFromDate, strToDate);
                }
                else
                {
                    reportDataList = ReportData.GetEntityList(GlobalVariables.ConnectionString,
                                                               product, client, null, null);
                }


                 

                BindingSource bsReportData = new BindingSource();
                bsReportData.DataSource = reportDataList;
                //dgData.DataSource = bsReportData;

                // btnPrint.Enabled = false;
                CommonForms.frmMsReportViewer frm = new CommonForms.frmMsReportViewer();
                frm.rvReportViewer.ProcessingMode = ProcessingMode.Local;

                //-->Company Information
                BindingSource bsCompany = new BindingSource();
                bsCompany.DataSource = GlobalVariables.currentUser.CompanyInformation;
                ReportDataSource rdsCompanyInfo = new ReportDataSource();
                rdsCompanyInfo.Name = "CompanyInfo";
                rdsCompanyInfo.Value = bsCompany;
                frm.rvReportViewer.LocalReport.DataSources.Add(rdsCompanyInfo);
                //<--Company Information

                ReportDataSource rdsOperator = new ReportDataSource();
                rdsOperator.Name = "ReportData";
                rdsOperator.Value = bsReportData;
                frm.rvReportViewer.LocalReport.DataSources.Add(rdsOperator);
                //<--Operator Information

                frm.rvReportViewer.LocalReport.ReportEmbeddedResource = "QScaleNew.AllReports.Report.rdlc"; //rptTruckInReceipt
                                                                                                                    // frm.rvReportViewer.LocalReport.ReportPath = "AllReports/TruckInReceipt.rdlc";
                frm.rvReportViewer.LocalReport.Refresh();
                frm.rvReportViewer.RefreshReport();

                //ReportParameter p = new ReportParameter("pMeasurementUnitName", GlobalVariables.measurementUnit.UnitName);
                //frm.rvReportViewer.LocalReport.SetParameters(new ReportParameter[] { p });


                //ReportParameter[] reportParameters = new ReportParameter[2];
                //reportParameters[0] = new ReportParameter("pMeasurementUnitName", GlobalVariables.measurementUnit.UnitName);
                //reportParameters[1] = new ReportParameter("pReportCulture", "bn-BD-skpaul");

                //frm.rvReportViewer.LocalReport.SetParameters(reportParameters);
                frm.rvReportViewer.RefreshReport();

                //             at Microsoft.Reporting.WinForms.LocalReport.EnsureExecutionSession()
                //at Microsoft.Reporting.WinForms.LocalReport.SetParameters(IEnumerable`1 parameters)
                //at QScaleNew.WeightMenuForms.frmTruckIn.PrintData() in E:\QScale\QScaleNew\WeightMenuForms\frmTruckIn.cs:line 545


                //  btnPrintReceipt.Enabled = true;
                frm.Text = "Weight Report";
                frm.ShowDialog();
                btnSearch.Enabled = true;
            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
                btnSearch.Enabled = true;
            }
        }

        private void radioCustomDateRange_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton control = sender as RadioButton;
           if(control.Checked == true)
            {
                gbCustomDateRange.Visible = true;
            }
            else
            {
                gbCustomDateRange.Visible = false;

            }
        }

        
    }
}
