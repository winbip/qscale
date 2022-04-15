using CustomObjects;
//using Microsoft.Reporting.WebForms;
using sCommonLib;
using sCommonLib.Exceptions;
using sCommonLib.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QScaleNew.WeightMenuForms
{
    public partial class frmTruckOut : Form
    {

        #region Private Variables

        private TruckOut CurrentEntity;
        private frmMain mainForm;
        private Timer timerGetWeight;

        #endregion

        #region Constructors

        public frmTruckOut()
        {

        }

        public frmTruckOut(frmMain MainForm)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.EmptyTruckIco32;
            mainForm = MainForm;
            pbLockUnlock.Image = Properties.Resources.UnlockRed32Png; pbLockUnlock.Tag = "Unlock";

            RedToolTip.OwnerDraw = true;
            RedToolTip.BackColor = System.Drawing.Color.Red;
            RedToolTip.ForeColor = System.Drawing.Color.White; //if option-A is used.

            lblUnitName.Text = "(in " + GlobalVariables.measurementUnit.UnitName + ")";

            if (!GlobalVariables.currentUser.FindPermission("9"))
            {
                txtTruckOutTare.ReadOnly = true;
            }

            AddEventHandlers(); AddDataBindings(); AddNewCurrentEntity();
        }
        #endregion

        #region Add Event Handlers

        private void AddEventHandlers()
        {

            this.Load += FormLoadHandler;
            btnSelectTruckNo.Click += SelectPendingTruck;
            btnSave.Click += SaveEntity;
            btnNewEntity.Click += NewEntity;
            btnPrint.Click += PrintEntity;
            btnClose.Click += CloseForm;
            pbLockUnlock.MouseMove += ShowBigIcon;
            pbLockUnlock.MouseLeave += ShowSmallIcon;
            pbLockUnlock.Click += LockUnlock;

            RedToolTip.Draw += new DrawToolTipEventHandler(RedToolTipDraw);

            AddCommonEventHandlers();
        }
        #endregion

        #region BindingSource

        private void AddNewCurrentEntity()
        {
            CurrentEntity = new TruckOut(GlobalVariables.ConnectionString);
            CurrentEntity.TruckOutDate = DateTime.Today.Date;
            CurrentEntity.TruckOutTime = DateTime.Now;
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
            bsCurrentEntity.DataSource = typeof(TruckOut);
            txtTruckOutId.DataBindings.Add("Text", bsCurrentEntity, "TruckOutId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTruckOutDate.DataBindings.Add("Text", bsCurrentEntity, "TruckOutDate", true, DataSourceUpdateMode.OnPropertyChanged, null, "d", GlobalVariables.CurrentCultureInfo);
            txtTruckOutTime.DataBindings.Add("Text", bsCurrentEntity, "TruckOutTime", true, DataSourceUpdateMode.OnPropertyChanged, null, "h:mm tt", GlobalVariables.CurrentCultureInfo);
            txtTruckOutWeight.DataBindings.Add("Text", bsCurrentEntity, "TruckOutWeight", true, DataSourceUpdateMode.OnPropertyChanged, 0, "N", GlobalVariables.CurrentCultureInfo);
            txtTruckOutTare.DataBindings.Add("Text", bsCurrentEntity, "TruckOutTare", true, DataSourceUpdateMode.OnPropertyChanged, 0, "N", GlobalVariables.CurrentCultureInfo);

            txtTruckNo.DataBindings.Add("Text", bsCurrentEntity, "TruckInDetails.TruckNo", false, DataSourceUpdateMode.OnPropertyChanged);
           
            txtChallanNo.DataBindings.Add("Text", bsCurrentEntity, "TruckInDetails.ChallanNo", false, DataSourceUpdateMode.OnPropertyChanged);
            cmbProduct.DataBindings.Add("Text", bsCurrentEntity, "TruckInDetails.ProductName", false, DataSourceUpdateMode.OnPropertyChanged);
            txtQuantity.DataBindings.Add("Text", bsCurrentEntity, "TruckInDetails.Quantity", false, DataSourceUpdateMode.OnPropertyChanged);
            txtMaterialDescription.DataBindings.Add("Text", bsCurrentEntity, "TruckInDetails.MaterialDescription", false, DataSourceUpdateMode.OnPropertyChanged);
            
            txtClientName.DataBindings.Add("Text", bsCurrentEntity, "TruckInDetails.ClientDetails.ClientName", false);
            txtMobileNo.DataBindings.Add("Text", bsCurrentEntity, "TruckInDetails.ClientDetails.MobileNo", false);
            txtCompanyName.DataBindings.Add("Text", bsCurrentEntity, "TruckInDetails.ClientDetails.CompanyName", false);
            txtAddress.DataBindings.Add("Text", bsCurrentEntity, "TruckInDetails.ClientDetails.Address", false);

        }
        #endregion

        private void RedToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        #region FormLoading Event Handler

        List<Product> ProductList;
        private void FormLoadHandler(object sender, EventArgs e)
        {
            ProductList = Product.GetEntityList(GlobalVariables.ConnectionString);
            foreach (Product product in ProductList)
            {
                cmbProduct.Items.Add(product.ProductName);
            }
        }

        #endregion


        #region Button Click Events

        private void SaveEntity(object sender, EventArgs e)
        {

            try
            {

                if (!GlobalVariables.isRegistered)
                {
                    CurrentEntity.TruckOutWeight = 50;
                    CurrentEntity.TruckOutTare = 40;
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Save Weight", "Unregistered Version", "This unregistered version only shows weight 50 kg and tare 40 kg. Please register this software to have full data."));
                    // return;
                }

                if (GlobalVariables.currentUser == null)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Save Weight", "Unauthorized Access", "You are currently not logged in. Please login first."));
                    return;
                }

                btnSave.Enabled = false;

                TruckIn truckIn = CurrentEntity.TruckInDetails;

                if (CurrentEntity.IsDirty || truckIn.IsDirty)
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

                  
                    if (truckIn.IsDirty)
                    {
                        truckIn.SetConnectionString(GlobalVariables.ConnectionString);
                        TruckIn.SaveEntity(truckIn);
                    }

                    TruckOut.SaveEntity(CurrentEntity);
                    CustomMessageBox.ShowSuccessMessage(new SuccessMessage("Success", "Success", "Information successfully saved."));
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
            txtTruckNo.Enter += EnterEventHandlerForTextBox;
            txtTruckOutTare.Enter += EnterEventHandlerForTextBox;
            //<--- Enter Events

            //---> Leave Events
            txtChallanNo.Leave += LeaveEventHandlerForTextBox;
            txtMaterialDescription.Leave += LeaveEventHandlerForTextBox;
            txtTruckNo.Leave += LeaveEventHandlerForTextBox;
            txtTruckOutTare.Leave += LeaveEventHandlerForTextBox;

            //<--- Leave Events

            //---> KeyDown Events (These controls are not related any type of validation)

            // txtTruckNo.KeyDown += KeyDownEventHandler;
           // txtTruckOutTare.KeyDown += KeyDownEventHandler;
            //<--- KeyDown Events
        }

        private void EnterEventHandlerForTextBox(object sender, EventArgs e)
        {
            Control control = sender as Control;
            //ComponentFactory.Krypton.Toolkit.KryptonTextBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
            control.BackColor = Color.White;
        }

        private void LeaveEventHandlerForTextBox(object sender, EventArgs e)
        {
             Control control = sender as Control;
            //ComponentFactory.Krypton.Toolkit.KryptonTextBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
            control.BackColor = SystemColors.GradientActiveCaption;
            MyErrorProvider.SetError(control, "");
        }

        private void KeyDownEventHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                //ChangeFocusToNextControl(sender);
            }
        }

        private void EnterEventHandlerForComboBox(object sender, EventArgs e)
        {
            Control control = sender as Control;
            //ComponentFactory.Krypton.Toolkit.KryptonComboBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonComboBox;
            control.BackColor = Color.White;

        }

        private void LeaveEventHandlerForComboBox(object sender, EventArgs e)
        {
             Control control = sender as Control;
            //control.BackColor = GlobalVariables.LostFocusBackColor;
            //control.ForeColor = GlobalVariables.LostFocusForeColor;
            //ComponentFactory.Krypton.Toolkit.KryptonComboBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonComboBox;
            control.BackColor = SystemColors.GradientActiveCaption;

            MyErrorProvider.SetError(control, "");
        }



        #endregion


        #region Print Data
        private void PrintData() //(object sender, EventArgs e)
        {
            try
            {

                if (CurrentEntity.IsDirty)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Alert", "Action Required", "Please save the changes before you print."));
                    return;
                }

                TruckIn truckIn = CurrentEntity.TruckInDetails;
                if (truckIn.IsDirty)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Alert", "Action Required", "Please save the changes before you print."));
                    return;
                }

                btnPrint.Enabled = false;
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

                //BindingSource bsBookingInfo = new BindingSource();
                //bsBookingInfo.DataSource = bsBooking.Current as Booking;
                ReportDataSource rdsTruckOut = new ReportDataSource();
                rdsTruckOut.Name = "TruckOut";
                rdsTruckOut.Value = bsCurrentEntity;
                frm.rvReportViewer.LocalReport.DataSources.Add(rdsTruckOut);

                //--> TruckIn Information
                BindingSource bsTruckInInfo = new BindingSource();
                bsTruckInInfo.DataSource = CurrentEntity.TruckInDetails;
                ReportDataSource rdsTruckIn = new ReportDataSource();
                rdsTruckIn.Name = "TruckIn";
                rdsTruckIn.Value = bsTruckInInfo;
                frm.rvReportViewer.LocalReport.DataSources.Add(rdsTruckIn);
                //<-- TruckIn Information


                //-->Client Information
                BindingSource bsClient = new BindingSource();
                bsClient.DataSource = CurrentEntity.TruckInDetails.ClientDetails;
                ReportDataSource rdsClient = new ReportDataSource();
                rdsClient.Name = "Client";
                rdsClient.Value = bsClient;
                frm.rvReportViewer.LocalReport.DataSources.Add(rdsClient);
                //<--Client Information


                //-->Operator Information
                BindingSource bsOperator = new BindingSource();
                bsOperator.DataSource = CurrentEntity.UserDetail;
                ReportDataSource rdsOperator = new ReportDataSource();
                rdsOperator.Name = "Operator";
                rdsOperator.Value = bsOperator;
                frm.rvReportViewer.LocalReport.DataSources.Add(rdsOperator);
                //<--Operator Information


                //ReportParameter[] reportParameters = new ReportParameter[1];
                //reportParameters[0] = new ReportParameter("pMeasurementUnitName", GlobalVariables.measurementUnit.UnitName, true);

                frm.rvReportViewer.LocalReport.ReportEmbeddedResource = "QScaleNew.AllReports.TruckOutReceipt.rdlc";
                //frm.rvReportViewer.LocalReport.SetParameters(reportParameters);
                frm.rvReportViewer.LocalReport.Refresh();
                frm.rvReportViewer.RefreshReport();


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
            if (pbLockUnlock.Tag == "Unlock")
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
            CurrentEntity.TruckOutWeight = mainForm.CurrentWeight;
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
            frmTruckOutHistory frm = new frmTruckOutHistory();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CurrentEntity = TruckOut.GetEntity(frm.SelectedEntityId, GlobalVariables.ConnectionString);
                bsCurrentEntity.DataSource = CurrentEntity;
                btnSave.Enabled = true;
                pbLockUnlock.Image = Properties.Resources.LockGreen48Png;
                pbLockUnlock.Tag = "Lock";
                timerGetWeight.Enabled = false;
                btnPrint.Visible = true;
            }
        }

        private void SelectPendingTruck(object sender, EventArgs e)
        {
            frmPendingTruckList frm = new frmPendingTruckList();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CurrentEntity.TruckInDetails = TruckIn.GetEntity(frm.SelectedEntityId, GlobalVariables.ConnectionString);
            }
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
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //CurrentEntity.ClientDetails = frm.NewlyCreatedClient;
            }
        }

        private void lblSelectCustomer_Click(object sender, EventArgs e)
        {
            MasterSetupForms.frmClientList frm = new QScaleNew.MasterSetupForms.frmClientList();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if(CurrentEntity.TruckInDetails == null)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Information", "Invalid Information", "Please select a Truck-In Weight."));
                    return;
                }
                CurrentEntity.TruckInDetails.ClientDetails = Client.GetEntity(frm.SelectedEntityId, GlobalVariables.ConnectionString);

                // CurrentEntity.ClientDetails = Client.GetEntity(frm.SelectedEntityId, GlobalVariables.ConnectionString);
            }
        }

        private void txtTruckOutId_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                try
                {
                    int id = Convert.ToInt32(txtTruckOutId.Text.Trim());
                    TruckOut temp = TruckOut.GetEntity(id, GlobalVariables.ConnectionString);

                    if (temp == null)
                    {
                        MessageBox.Show("Not found.");
                        return;
                    }

                    CurrentEntity = temp;

                    bsCurrentEntity.DataSource = CurrentEntity;
                    btnSave.Enabled = true;
                    pbLockUnlock.Image = Properties.Resources.LockGreen48Png;
                    pbLockUnlock.Tag = "Lock";
                    timerGetWeight.Enabled = false;
                    btnPrint.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
