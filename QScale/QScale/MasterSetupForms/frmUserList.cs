using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;

//using Microsoft.Reporting.WinForms;

using CustomObjects;
using sCommonLib;
using sCommonLib.Messages;
using sCommonLib.Exceptions;

using Guifreaks;
using Guifreaks.Common;
using Guifreaks.NavigationBar;

using System.Collections;

namespace QScale.MasterSetupForms
{
    public partial class frmUserList : Form
    {

        #region Private Variables
        private DataTable dtData;
        private int pSelectedEnttityId;
        #endregion

        #region Public Properties
        public int SelectedEntityId
        {
            get { return pSelectedEnttityId; }
        }
        #endregion

        #region Constructors

        public frmUserList()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.UserGroupBlueGreenIco;
            AddEventHandlers();
        }

        #endregion

        #region Assigning Event Handlers

        private void AddEventHandlers()
        {
            
            this.Load += FormLoadHandler;
            btnClose.Click += CloseForm;
            btnExport.Click += ExportDataToExcel;
             
            txtLogInName.TextChanged += FilterDataGridView; //TextBoxName must be equal to datasource column name
             
            dgData.CellMouseEnter += dgData_CellMouseEnter;
            dgData.CellMouseLeave += dgData_CellMouseLeave;
            dgData.CellDoubleClick += dgData_CellDoubleClick;
            this.bgwPrimaryWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PrimaryWork);
            this.bgwPrimaryWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.PrimaryProgress);
            this.bgwPrimaryWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.PrimaryWorkCompleted);
            
        }
        #endregion

        #region FormatDatagrid

        
        private void FormatdgData()
        {
          dgData.DefaultCellStyle.FormatProvider = GlobalVariables.CurrentCultureInfo;
            dgData.RowHeadersVisible = false;
            dgData.AllowUserToAddRows = false;
            dgData.AllowUserToDeleteRows = false;
            dgData.AllowUserToResizeRows = true;

            dgData.ColumnHeadersVisible = true;
            dgData.AllowUserToOrderColumns = false;
            dgData.AllowUserToResizeColumns = true;

            dgData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgData.ScrollBars = ScrollBars.Vertical;
            dgData.ReadOnly = true;
            dgData.MultiSelect = false;

            dgData.EnableHeadersVisualStyles = false;
            dgData.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            dgData.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgData.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgData.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgData.ColumnHeadersDefaultCellStyle.Font = new Font(MyFontName, MyFontSize, FontStyle.Regular);

            dgData.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            //SingleHorizontal is required to set custom gridcolor

            dgData.GridColor = Color.LightSteelBlue;
            //dgData.BorderStyle = BorderStyle.None;
            //dgData.BackgroundColor = ControlFunctions.FormBackColor;

            dgData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgData.DefaultCellStyle.BackColor = Color.White;
            dgData.DefaultCellStyle.ForeColor = Color.Black;

            dgData.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dgData.DefaultCellStyle.SelectionForeColor = Color.White;

            dgData.Columns[0].Visible = false;

            //dgData.Columns[1].Visible = true;
            //dgData.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgData.Columns[1].Width = 100;
            //dgData.Columns[1].ReadOnly = true;
            //dgData.Columns[1].HeaderText = "Session";
            //dgData.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dgData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgData.Columns[1].HeaderCell.Style.BackColor = Color.Lavender;
            //dgData.Columns[1].HeaderCell.Style.ForeColor = Color.SlateGray;
            //dgData.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgData.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;


            dgData.ClearSelection();

        }
       
        #endregion

        #region FormEventHandlers
        
        private void FormLoadHandler(object sender, EventArgs e)
        {
            MyNavBar.Collapsed = true;
            StartPrimaryWorker();
        }
    
        #endregion

        #region BackgroundWorker Helper Methods
       
        private int ProgressValue;
        private void StartPrimaryWorker() 
        {
            this.Cursor = Cursors.WaitCursor;
            this.MyProgressBar.Maximum = 10;
            this.MyProgressBar.Value = 0;
            this.MyProgressBar.Visible = true;
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
            MyProgressBar.Value += 1;
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
          
                string sqlSelectData="Select UserId,LogInName,FullName,UserDesignation from tblUserDetails Where UserId>1 order by LogInName asc";

                using (OleDbDataAdapter da=new OleDbDataAdapter(sqlSelectData,GlobalVariables.ConnectionString))
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
            MyProgressBar.Value = e.ProgressPercentage;
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
                    DataView dv=new DataView(dtData,"","",DataViewRowState.CurrentRows);
                    dgData.DataSource=dv;FormatdgData();
          
          
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
                this.Cursor = Cursors.Default;MyProgressBar.Visible = false;
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

        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region Datagridview CellMouseEnter,CellMouseLeave, CellDoubleClick Events Handler
       

        private void dgData_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgData.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void dgData_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dgData.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void dgData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           pSelectedEnttityId = (int)dgData.CurrentRow.Cells[0].Value;
           this.DialogResult = DialogResult.OK;
        }
       
        #endregion

        #region Filter DataGridView

        private void FilterDataGridView(object sender, EventArgs e)
        {

            Control control = (Control)sender;

            string ColumnName = control.Name.ToString().Replace("txt", "");
            string FiltereringParameter = control.Text.Trim();

            DataView dvDataSource = (DataView)dgData.DataSource; //Copy existing dataview to new variable

            dvDataSource.RowFilter = ColumnName + " Like '*" + FiltereringParameter + "*'";
            dgData.ClearSelection();

            /* Note- No need the following code for the time being.
            if (FilteredText.Length > 0)
            {
                dvDataSource.RowFilter = controlName + " Like '*" + FilteredText + "*'";

                dgData.ClearSelection();
            }
            else
            {
                DataView dv = new DataView(dtData, "", "", DataViewRowState.CurrentRows);
                dgData.DataSource = dv; dgData.ClearSelection();
            }
            */
        }
        #endregion

    }
}
