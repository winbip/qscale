using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using System.Data.OleDb;

using Microsoft.Reporting.WinForms;

using CustomObjects;
using sCommonLib;
using sCommonLib.Messages;
using sCommonLib.Exceptions;
using System.Collections;


namespace QScale.WeightMenuForms
{
    public partial class frmTruckIn : Form
    {

        #region Private Variables

       private TruckIn CurrentEntity;
       private frmMain mainForm;
       private Timer timerGetWeight;

       private AutoCompleteStringCollection GoodsDescriptionSource = new AutoCompleteStringCollection();
       private AutoCompleteStringCollection TruckNoSource = new AutoCompleteStringCollection();
       private AutoCompleteStringCollection DriverNameSource = new AutoCompleteStringCollection();
        #endregion

        #region Constructors

       public frmTruckIn()
       {

       }

        public frmTruckIn(frmMain MainForm)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.LoadTruckIco48;
            mainForm = MainForm;
            pbLockUnlock.Image = Properties.Resources.UnlockRed32Png; pbLockUnlock.Tag = "Unlock";

            RedToolTip.OwnerDraw = true;
            RedToolTip.BackColor = System.Drawing.Color.Red;
            RedToolTip.ForeColor = System.Drawing.Color.White; //if option-A is used.

            lblUnitName.Text ="(in " + GlobalVariables.measurementUnit.UnitName + ")";

             AddEventHandlers(); AddDataBindings(); AddNewCurrentEntity();
        }
        #endregion

        #region Add Event Handlers

        private void AddEventHandlers()
        {
            
             this.Load += FormLoadHandler;
             btnSave.Click += SaveEntity;
             btnNewEntity.Click += NewEntity;
             btnPrint.Click += PrintEntity;
             btnClose.Click += CloseForm;
             pbLockUnlock.MouseMove += ShowBigIcon;
             pbLockUnlock.MouseLeave += ShowSmallIcon;
             pbLockUnlock.Click += LockUnlock;

             RedToolTip.Draw += new DrawToolTipEventHandler(RedToolTipDraw);

             this.bgwPrimaryWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PrimaryWork);
             this.bgwPrimaryWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.PrimaryWorkCompleted);

             AddCommonEventHandlers();             
        }
        #endregion

        #region BindingSource

        private void AddNewCurrentEntity()
        {
            CurrentEntity = new TruckIn(GlobalVariables.ConnectionString);
            CurrentEntity.TruckInDate = DateTime.Today.Date;
            CurrentEntity.TruckInTime = DateTime.Now;
            CurrentEntity.UserDetail = GlobalVariables.currentUser.UserInformation;
            bsCurrentEntity.Clear();

            bsCurrentEntity.DataSource = CurrentEntity;

            timerGetWeight = new System.Windows.Forms.Timer();
            timerGetWeight.Tick += GetValueFromMainFrom;
            timerGetWeight.Enabled = true;
           
            timerGetWeight.Interval = 2000;

            pbLockUnlock.Tag = "Unlock";
            pbLockUnlock.Image = Properties.Resources.UnlockRed32Png;

            btnSave.Enabled = false;
            btnPrint.Visible = false;
        }

        private void AddDataBindings()
        {
            bsCurrentEntity.DataSource = typeof(TruckIn);
            txtTruckNo.DataBindings.Add("Text", bsCurrentEntity, "TruckNo", false, DataSourceUpdateMode.OnPropertyChanged);
            txtMaterialDescription.DataBindings.Add("Text", bsCurrentEntity, "MaterialDescription", false, DataSourceUpdateMode.OnPropertyChanged);
            txtChallanNo.DataBindings.Add("Text", bsCurrentEntity, "ChallanNo", false, DataSourceUpdateMode.OnPropertyChanged);
            txtQuantity.DataBindings.Add("Text", bsCurrentEntity, "Quantity", false, DataSourceUpdateMode.OnPropertyChanged);
            txtDriverName.DataBindings.Add("Text", bsCurrentEntity, "DriverName", false, DataSourceUpdateMode.OnPropertyChanged);
            txtTruckInDate.DataBindings.Add("Text", bsCurrentEntity, "TruckInDate", true, DataSourceUpdateMode.OnPropertyChanged,null,"d",GlobalVariables.CurrentCultureInfo);
            txtTruckInId.DataBindings.Add("Text", bsCurrentEntity, "TruckInId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTruckInTime.DataBindings.Add("Text", bsCurrentEntity, "TruckInTime", true, DataSourceUpdateMode.OnPropertyChanged,null,"h:mm t",GlobalVariables.CurrentCultureInfo);
            txtTruckInWeight.DataBindings.Add("Text", bsCurrentEntity, "TruckInWeight", true, DataSourceUpdateMode.OnPropertyChanged,0,"N",GlobalVariables.CurrentCultureInfo);
            txtClientType.DataBindings.Add("Text", bsCurrentEntity, "ClientDetails.ClientTypeDetails.ClientTypeName", false);
            txtClientCode.DataBindings.Add("Text", bsCurrentEntity, "ClientDetails.ClientCode", false);
            txtClientName.DataBindings.Add("Text", bsCurrentEntity, "ClientDetails.ClientName", false);
            txtCompanyName.DataBindings.Add("Text", bsCurrentEntity, "ClientDetails.CompanyName", false);
        }
        #endregion

        private void RedToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        #region FormLoading Event Handler
        
        private void FormLoadHandler(object sender, EventArgs e)
        {
            StartPrimaryWorker();
            CreateFocusOrderTable();
        }
        
        #endregion

        #region BackgroundWorker Helper Methods
        
        private void StartPrimaryWorker() 
        {
            bgwPrimaryWorker.RunWorkerAsync();
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
                DataSet ds = TruckIn.GetDistinctValues(GlobalVariables.ConnectionString);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    GoodsDescriptionSource.Add(row[0].ToString());
                }

                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    TruckNoSource.Add(row[0].ToString());
                }

                foreach (DataRow row in ds.Tables[2].Rows)
                {
                    DriverNameSource.Add(row[0].ToString());
                }

                e.Result = true;
            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
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
                    if (e.Result != null)
                    {
                        txtMaterialDescription.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        txtMaterialDescription.AutoCompleteMode = AutoCompleteMode.Suggest;
                        txtMaterialDescription.AutoCompleteCustomSource = GoodsDescriptionSource;

                        txtTruckNo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        txtTruckNo.AutoCompleteMode = AutoCompleteMode.Suggest;
                        txtTruckNo.AutoCompleteCustomSource = TruckNoSource;

                        txtDriverName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        txtDriverName.AutoCompleteMode = AutoCompleteMode.Suggest;
                        txtDriverName.AutoCompleteCustomSource = DriverNameSource;   
                    }
                    else
                    {
                        //Show message if result is empty.
                    }
                }

            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        } 
         
        #endregion

        #region Button Click Events

        private void SaveEntity(object sender, EventArgs e)
        {
            
                try
                {
                    if (GlobalVariables.currentUser == null)
                    {
                        CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Login", "Unauthorized Access", "You are currently not logged in. Please login first."));
                        return;
                    }
              
                    btnSave.Enabled = false;
                    if (CurrentEntity.IsDirty)
                    {
                        if (CurrentEntity.IsNew)
                        {
                            if (!GlobalVariables.currentUser.FindPermission("6"))
                            {
                                CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are not permitted. Contact your admin."));
                                return;
                            }
                        }
                        else
                        {
                            if (!GlobalVariables.currentUser.FindPermission("7"))
                            {
                                CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are not permitted. Contact your admin."));
                                return;
                            }
                        }

                        TruckIn.SaveEntity(CurrentEntity);
                        CustomMessageBox.ShowSuccessMessage(new SuccessMessage("Success", "Success", "Information successfully saved."));

                        if (!DriverNameSource.Contains(CurrentEntity.DriverName))
                        {
                            DriverNameSource.Add(CurrentEntity.DriverName);
                        }

                        if (!TruckNoSource.Contains(CurrentEntity.TruckNo))
                        {
                            TruckNoSource.Add(CurrentEntity.TruckNo);
                        }

                        btnPrint.Visible = true;
                        PrintData();
                    }

                    btnSave.Enabled = true; btnSave.Focus();
                }
                catch (ExceptionWithoutControl EWC)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage(EWC.TitleBarMessage, EWC.HeadLineMessage, EWC.ErrorDescription));
                    btnSave.Enabled = true; btnSave.Focus();
                }
                catch (ExceptionWithControl exceptionWithControl)
                {
                    HandleExceptionWithControl(exceptionWithControl);
                    btnSave.Enabled = true;
                }
                catch (Exception Ex)
                {
                    CustomMessageBox.ShowSystemException(Ex);
                    btnSave.Enabled = true;
                }
            
        }

        private void DeleteEntity(object sender, EventArgs e)
        {

        }

        private void PrintEntity(object sender, EventArgs e)
        {
            PrintData();
        }

        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewEntity(object sender, EventArgs e)
        {
            AddNewCurrentEntity();
        }
        #endregion

        #region Commen Enter,Leave, KeyDown EventHandlers
        //These are the common method for all control 

        private void AddCommonEventHandlers()
        {

            //---> Enter Events
            txtChallanNo.Enter += EnterEventHandlerForTextBox;
            txtMaterialDescription.Enter += EnterEventHandlerForTextBox;
            txtQuantity.Enter += EnterEventHandlerForTextBox;
            txtTruckNo.Enter += EnterEventHandlerForTextBox;
            txtDriverName.Enter += EnterEventHandlerForTextBox;
            //<--- Enter Events

            //---> Leave Events
            txtChallanNo.Leave += LeaveEventHandlerForTextBox;
            txtMaterialDescription.Leave += LeaveEventHandlerForTextBox;
            txtQuantity.Leave += LeaveEventHandlerForTextBox;
            txtTruckNo.Leave += LeaveEventHandlerForTextBox;
            txtDriverName.Leave += LeaveEventHandlerForTextBox;
            //<--- Leave Events

            //---> KeyDown Events (These controls are not related any type of validation)
            txtChallanNo.KeyDown += KeyDownEventHandler;
            txtMaterialDescription.KeyDown += KeyDownEventHandler;
            txtQuantity.KeyDown += KeyDownEventHandler;
            txtTruckNo.KeyDown += KeyDownEventHandler;
            txtDriverName.KeyDown += KeyDownEventHandler;
            //<--- KeyDown Events
        }

        private void EnterEventHandlerForTextBox(object sender, EventArgs e)
        {
            //Control control = sender as Control;
            ComponentFactory.Krypton.Toolkit.KryptonTextBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
            control.StateCommon.Back.Color1 = Color.White;
        }

        private void LeaveEventHandlerForTextBox(object sender, EventArgs e)
        {
            // Control control = sender as Control;
            ComponentFactory.Krypton.Toolkit.KryptonTextBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
            control.StateCommon.Back.Color1 = SystemColors.GradientActiveCaption;
            MyErrorProvider.SetError(control, "");
        }

        private void EnterEventHandlerForComboBox(object sender, EventArgs e)
        {
            //Control control = sender as Control;
            ComponentFactory.Krypton.Toolkit.KryptonComboBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonComboBox;
            control.StateCommon.ComboBox.Back.Color1 = Color.White;
           
        }

        private void LeaveEventHandlerForComboBox(object sender, EventArgs e)
        {
            // Control control = sender as Control;
            //control.BackColor = GlobalVariables.LostFocusBackColor;
            //control.ForeColor = GlobalVariables.LostFocusForeColor;
            ComponentFactory.Krypton.Toolkit.KryptonComboBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonComboBox;
            control.StateCommon.ComboBox.Back.Color1 = SystemColors.GradientActiveCaption;
            
            MyErrorProvider.SetError(control, "");
        }

        private void KeyDownEventHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ChangeFocusToNextControl(sender);
            }
        }

        #endregion

        #region Focus Order and Set Focus Codes

        private DataTable dtFocusOrder;
        private Control DefaultControl;

        private void CreateFocusOrderTable()
        {
            DefaultControl = btnSave;

            dtFocusOrder = new DataTable();
            dtFocusOrder.Columns.Add("ControlName", typeof(string));
            dtFocusOrder.Rows.Add("txtChallanNo");
            dtFocusOrder.Rows.Add("txtMaterialDescription");
            dtFocusOrder.Rows.Add("txtQuantity");
            dtFocusOrder.Rows.Add("txtTruckNo");
            dtFocusOrder.Rows.Add("txtDriverName");
            dtFocusOrder.Rows.Add("btnSave");
        }

        private void ChangeFocusToNextControl(object sender)
        {
            Control control = (Control)sender;

            int i = 0;
            foreach (DataRow row in dtFocusOrder.Rows)
            {
                if (row["ControlName"] == control.Name.ToString())
                {
                    break;
                }
                i++;
            }

            if (i < dtFocusOrder.Rows.Count - 1)
            {
                string NextControlName = dtFocusOrder.Rows[i + 1]["ControlName"].ToString();
                Control[] tb = this.Controls.Find(NextControlName, true);

                tb[0].Focus();
            }
            else
            {
                string NextControlName = dtFocusOrder.Rows[0]["ControlName"].ToString();
                Control[] tb = this.Controls.Find(NextControlName, true);

                tb[0].Focus();

                // DefaultControl.Focus(); //Set default focus to save button
            }
        }
        #endregion

        #region ContextMenu Codes
        private void MouseDownEventHandler(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    Control currentControl = (Control)sender;

                    //Add context menustrip to current conrol
                    currentControl.ContextMenuStrip = contextMenuSetFocusOrder;

                    DataRow[] dr = dtFocusOrder.Select("ControlName='" + currentControl.Name.ToString() + "'");

                    if (dr.Length == 1)
                    {
                        itemAddFocus.Enabled = false;
                        itemRemoveFocus.Enabled = true;
                    }
                    else
                    {
                        itemAddFocus.Enabled = true; itemRemoveFocus.Enabled = false;
                    }

                    contextMenuSetFocusOrder.Show(currentControl, e.Location);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void HandlesitemAddFocusClick(object sender, EventArgs e)
        {
            Control control = contextMenuSetFocusOrder.SourceControl;
            dtFocusOrder.Rows.Add(control.Name.ToString());
        }

        private void HandlesitemRemoveClick(object sender, EventArgs e)
        {
            Control control = contextMenuSetFocusOrder.SourceControl;
            DataRow[] dr = dtFocusOrder.Select("ControlName='" + control.Name.ToString() + "'");
            dtFocusOrder.Rows.Remove(dr[0]);
        }
        #endregion

        #region Print Data
        private void PrintData() //(object sender, EventArgs e)
        {
            try
             {
                 btnPrint.Enabled = false;
                 CommonForms.frmMsReportViewer frm = new CommonForms.frmMsReportViewer();
                 frm.rvReportViewer.ProcessingMode = ProcessingMode.Local;

                //-->Company Information
                 BindingSource bsCompany = new BindingSource();
                 bsCompany.DataSource = GlobalVariables.currentUser.CompanyInformation;
                 ReportDataSource rdsCompanyInfo = new ReportDataSource();
                 rdsCompanyInfo.Name = "CustomObjects_CompanyInfo";
                 rdsCompanyInfo.Value = bsCompany;
                 frm.rvReportViewer.LocalReport.DataSources.Add(rdsCompanyInfo);
                 //<--Company Information

                 //BindingSource bsBookingInfo = new BindingSource();
                 //bsBookingInfo.DataSource = bsBooking.Current as Booking;
                 ReportDataSource rds = new ReportDataSource();
                 rds.Name = "CustomObjects_TruckIn";
                 rds.Value = bsCurrentEntity;
                 frm.rvReportViewer.LocalReport.DataSources.Add(rds);

                 //BindingSource bsBookingInfo = new BindingSource();
                 //bsBookingInfo.DataSource = bsBooking.Current as Booking;
                 //ReportDataSource rds = new ReportDataSource();
                 //rds.Name = "CustomObjects_Booking";
                 //rds.Value = bsBookingInfo;
                 //frm.rvReportViewer.LocalReport.DataSources.Add(rds);

                 ReportParameter[] reportParameters = new ReportParameter[1];
                 reportParameters[0] = new ReportParameter("pMeasurementUnitName", GlobalVariables.measurementUnit.UnitName, true);

                 frm.rvReportViewer.LocalReport.ReportEmbeddedResource = "QScale.AllReports.rptTruckInReceipt.rdlc";
                 frm.rvReportViewer.LocalReport.SetParameters(reportParameters);

               //  btnPrintReceipt.Enabled = true;
                 frm.Text = "Weight Receipt";
                 frm.ShowDialog();
                 btnPrint.Enabled = true;
             }
             catch (Exception Ex)
             {
                 CustomMessageBox.ShowSystemException(Ex);
                 btnPrint.Enabled = true;
             }
             
        }
        #endregion

        private void HandleExceptionWithControl(ExceptionWithControl EWC)
        {
            string strControlName = EWC.ControlName;
            Control control = null;
            switch (strControlName)
            {
                case "TruckNo":
                    control = txtTruckNo;
                    break;
                default:
                    break;
            }
            CustomMessageBox.ShowGeneralMessage(new GeneralMessage(EWC.TitleBarMessage, EWC.HeadLineMessage, EWC.ErrorDescription));
            MyErrorProvider.SetError(control, EWC.ErrorDescription); control.Focus();
        }

        //MouseMode event handler of pbLockUnlock
        private void ShowBigIcon(object sender, MouseEventArgs e)
        {
            if (pbLockUnlock.Tag=="Unlock")
            {
                pbLockUnlock.Image = Properties.Resources.UnlockRed48Png;
            }
            else
            {
                pbLockUnlock.Image = Properties.Resources.LockGreen48Png;
            }
           
        }

        //MouseLeave event handler of pbLockUnlock
        private void ShowSmallIcon(object sender, EventArgs e)
        {
            if (pbLockUnlock.Tag == "Unlock")
            {
                pbLockUnlock.Image = Properties.Resources.UnlockRed32Png;
            }
            else
            {
                pbLockUnlock.Image = Properties.Resources.LockGreen32Png;
            }
        }

        //Click event handler of pbLockUnlock
        private void LockUnlock(object sender, EventArgs e)
        {
            string CurrentState = pbLockUnlock.Tag.ToString();
            switch (CurrentState)
            {
                case "Lock":
                    timerGetWeight.Enabled = true;
                    btnSave.Enabled = false;
                    pbLockUnlock.Tag = "Unlock";
                    pbLockUnlock.Image = Properties.Resources.UnlockRed48Png;
                   
                    break;
                case "Unlock":
                    timerGetWeight.Enabled = false;
                    btnSave.Enabled = true;
                    pbLockUnlock.Image = Properties.Resources.LockGreen48Png;
                    pbLockUnlock.Tag = "Lock";
                    break;
                default:
                    break;
            }
        }

        //Tick event of timerGetWeight
        private void GetValueFromMainFrom(object sender, EventArgs e)
        {
            CurrentEntity.TruckInWeight = mainForm.CurrentWeight;
        }

        private void lblCreateCustomer_MouseEnter(object sender, EventArgs e)
        {
            lblCreateCustomer.Image = Properties.Resources.AddCustomerBlackPng32;
        }

        private void lblCreateCustomer_MouseLeave(object sender, EventArgs e)
        {
            lblCreateCustomer.Image = Properties.Resources.CustomerBlackPng32;
        }

        private void lblSelectCustomer_MouseEnter(object sender, EventArgs e)
        {
            lblSelectCustomer.Image = Properties.Resources.SearchCustomerBlackPng32;
        }

        private void lblSelectCustomer_MouseLeave(object sender, EventArgs e)
        {
            lblSelectCustomer.Image = Properties.Resources.CustomerListBlackPng32;
        }

        private void lblCreateCustomer_Click(object sender, EventArgs e)
        {
            MasterSetupForms.frmClientDetails frm = new MasterSetupForms.frmClientDetails();
            if (frm.ShowDialog()==DialogResult.OK)
            {
                CurrentEntity.ClientDetails = frm.NewlyCreatedClient;
            }
        }

        private void lblSelectCustomer_Click(object sender, EventArgs e)
        {
            MasterSetupForms.frmClientList frm = new QScale.MasterSetupForms.frmClientList();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CurrentEntity.ClientDetails = Client.GetEntity(frm.SelectedEntityId, GlobalVariables.ConnectionString);
            }
        }

        private void pbSearchWeightId_MouseEnter(object sender, EventArgs e)
        {
            pbSearchWeightId.Image = Properties.Resources.Search3Png16;
        }

        private void pbSearchWeightId_MouseLeave(object sender, EventArgs e)
        {
            pbSearchWeightId.Image = Properties.Resources.Search1Png16;
        }

        private void pbSearchWeightId_Click(object sender, EventArgs e)
        {
            frmTruckInHistory frm = new frmTruckInHistory();
            if (frm.ShowDialog()==DialogResult.OK)
            {
                CurrentEntity = TruckIn.GetEntity(frm.SelectedEntityId, GlobalVariables.ConnectionString);
                bsCurrentEntity.DataSource = CurrentEntity;
                btnSave.Enabled = true;
                pbLockUnlock.Image = Properties.Resources.LockGreen48Png;
                pbLockUnlock.Tag = "Lock";
                timerGetWeight.Enabled = false;
                btnPrint.Visible = true;
            }
        }



    }
}
