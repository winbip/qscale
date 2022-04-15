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
using System.Collections;


namespace QScale.MasterSetupForms
{
    public partial class frmClientDetails : Form
    {

        #region Private Variables

        private Client CurrentEntity; private BindingSource bsClientType=new BindingSource();
        #endregion

        #region Public Properties
        /// <summary>
        /// Returns Client that just have created.
        /// </summary>
        public Client NewlyCreatedClient
        {
            get { return CurrentEntity; }
        }
        #endregion

        #region Constructors

        public frmClientDetails()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.CustomerBlackIco32;
            RedToolTip.OwnerDraw = true;
            RedToolTip.BackColor = System.Drawing.Color.Red;
            RedToolTip.ForeColor = System.Drawing.Color.White; //if option-A is used.
            AddEventHandlers(); AddDataBindings(); AddNewCurrentEntity();
        }

        public frmClientDetails(int CurrentEntityId)
        {
            InitializeComponent();

            this.Icon = Properties.Resources.CustomerBlackIco32;

            RedToolTip.OwnerDraw = true;
            RedToolTip.BackColor = System.Drawing.Color.Red;
            RedToolTip.ForeColor = System.Drawing.Color.White; //if option-A is used.

            AddEventHandlers(); AddDataBindings();

            //CurrentEntity = CustomType.GetEntity(CurrentEntityId,GlobalVariables.ConnectionString);
            //bsCurrentEntity.DataSource = CurrentEntity;


        }

        #endregion

        #region Add Event Handlers

        private void AddEventHandlers()
        {
            
             this.Load += FormLoadHandler;
             btnSave.Click += SaveEntity;
             btnNewEntity.Click += NewEntity;
             btnClose.Click += CloseForm;

             RedToolTip.Draw += new DrawToolTipEventHandler(RedToolTipDraw);
             pbAddNewClientType.Click += CreateNewClientType;

             AddCommonEventHandlers();
             
        }
        #endregion

        #region BindingSource

        private void AddNewCurrentEntity()
        {
            CurrentEntity = new Client(GlobalVariables.ConnectionString);
            bsCurrentEntity.Clear();
            bsCurrentEntity.DataSource = CurrentEntity;
            MastHead.Text = "Add New Client";
            txtClientCode.Focus();
        }

        private void AddDataBindings()
        {
            bsCurrentEntity.DataSource = typeof(Client);
            bsClientType.DataSource=ClientType.GetEntityList(GlobalVariables.ConnectionString);
            cmbClientType.DataSource = bsClientType;
            cmbClientType.DisplayMember = "ClientTypeName";
            cmbClientType.ValueMember = "ClientTypeId";

            txtClientCode.DataBindings.Add("Text", bsCurrentEntity, "ClientCode", false);
            cmbClientType.DataBindings.Add("SelectedItem", bsCurrentEntity, "ClientTypeDetails", false);
            txtClientName.DataBindings.Add("Text", bsCurrentEntity, "ClientName");
            txtCompanyName.DataBindings.Add("Text", bsCurrentEntity, "CompanyName");
            txtAddress.DataBindings.Add("Text", bsCurrentEntity, "Address");
            txtTelephone.DataBindings.Add("Text", bsCurrentEntity, "TelephoneNo");
            txtFAX.DataBindings.Add("Text", bsCurrentEntity, "FaxNo");
            txtEmail.DataBindings.Add("Text", bsCurrentEntity, "EmailAddress");
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
            CreateFocusOrderTable();
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
                    else
                    {
                        //if (!GlobalVariables.currentUser.FindPermission("1"))
                        //{
                        //    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Login", "Unauthorized Access", "You are authorized. Contact your admin."));
                        //    return;
                        //}
                    }
              

                    btnSave.Enabled = false;
                    if (CurrentEntity.IsDirty)
                    {
                        Client.SaveEntity(CurrentEntity);
                        MyErrorProvider.Clear();
                        CustomMessageBox.ShowSuccessMessage(new SuccessMessage("Success", "Success", "Information successfully saved."));
                        MastHead.Text = "Update Client Information";
                        this.DialogResult = DialogResult.OK;
                    }
                    btnSave.Enabled = true; btnSave.Focus();
                }
                catch (ExceptionWithoutControl EWC)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage(EWC.TitleBarMessage, EWC.HeadLineMessage, EWC.ErrorDescription));
                    btnSave.Enabled = true;
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
            txtClientCode.Enter += EnterEventHandlerForTextBox;
            cmbClientType.Enter += EnterEventHandlerForComboBox;
            txtClientName.Enter += EnterEventHandlerForTextBox;
            txtCompanyName.Enter += EnterEventHandlerForTextBox;
            txtAddress.Enter += EnterEventHandlerForTextBox;
            txtTelephone.Enter += EnterEventHandlerForTextBox;
            txtFAX.Enter += EnterEventHandlerForTextBox;
            txtEmail.Enter += EnterEventHandlerForTextBox;
            //<--- Enter Events

            //---> Leave Events
            txtClientCode.Leave += LeaveEventHandlerForTextBox;
            cmbClientType.Leave += LeaveEventHandlerForComboBox;
            txtClientName.Leave += LeaveEventHandlerForTextBox;
            txtCompanyName.Leave += LeaveEventHandlerForTextBox;
            txtAddress.Leave += LeaveEventHandlerForTextBox;
            txtTelephone.Leave += LeaveEventHandlerForTextBox;
            txtFAX.Leave += LeaveEventHandlerForTextBox;
            txtEmail.Leave += LeaveEventHandlerForTextBox;
            //<--- Leave Events

            //---> KeyDown Events (These controls are not related any type of validation)
            txtClientCode.KeyDown += KeyDownEventHandler;
            cmbClientType.KeyDown += KeyDownEventHandler;
            txtClientName.KeyDown += KeyDownEventHandler;
            txtCompanyName.KeyDown += KeyDownEventHandler;
            txtAddress.KeyDown += KeyDownEventHandler;
            txtTelephone.KeyDown += KeyDownEventHandler;
            txtFAX.KeyDown += KeyDownEventHandler;
            txtEmail.KeyDown += KeyDownEventHandler;
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
            pbAddNewClientType.Visible = true;
        }

        private void LeaveEventHandlerForComboBox(object sender, EventArgs e)
        {
            // Control control = sender as Control;
            //control.BackColor = GlobalVariables.LostFocusBackColor;
            //control.ForeColor = GlobalVariables.LostFocusForeColor;
            ComponentFactory.Krypton.Toolkit.KryptonComboBox control = sender as ComponentFactory.Krypton.Toolkit.KryptonComboBox;
            control.StateCommon.ComboBox.Back.Color1 = SystemColors.GradientActiveCaption;
            pbAddNewClientType.Visible = false;
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

            dtFocusOrder.Rows.Add("txtClientCode");
            dtFocusOrder.Rows.Add("cmbClientType");
            dtFocusOrder.Rows.Add("txtClientName");
            dtFocusOrder.Rows.Add("txtCompanyName");
            dtFocusOrder.Rows.Add("txtAddress");
            dtFocusOrder.Rows.Add("txtTelephone");
            dtFocusOrder.Rows.Add("txtFAX");
            dtFocusOrder.Rows.Add("txtEmail");
           // dtFocusOrder.Rows.Add("btnNewEntity");
            //dtFocusOrder.Rows.Add("btnDelete");
            dtFocusOrder.Rows.Add("btnSave");
            //dtFocusOrder.Rows.Add("btnClose");
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

        #region Print Data
        private void PrintData(object sender, EventArgs e)
        {
            /* try
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

                 frm.rvReportViewer.LocalReport.ReportEmbeddedResource = "MyProjectTemplate.AllReports.BookingReceipt.rdlc";
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
             */
        }
        #endregion

        private void CreateNewClientType(object sender, EventArgs e)
        {
            frmAddNewClientType frm = new frmAddNewClientType();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ClientType newClientType = frm.CreatedClientType;
                bsClientType.Add(newClientType);
                cmbClientType.SelectedItem = newClientType;

            }
        }

        private void HandleExceptionWithControl(ExceptionWithControl EWC)
        {
            string strControlName = EWC.ControlName;
            Control control=null;
            switch (strControlName)
            {
                case "ClientCode":
                    control = txtClientCode;
                    break;
                case "ClientType":
                    control = cmbClientType; break;
                case "ClientName":
                    control = txtClientName; break;
                case "CompanyName":
                    control = txtCompanyName; break;
                default:
                    break;
            }
            CustomMessageBox.ShowGeneralMessage(new GeneralMessage(EWC.TitleBarMessage, EWC.HeadLineMessage, EWC.ErrorDescription));
            MyErrorProvider.SetError(control, EWC.ErrorDescription);control.Focus();
        }

    }
}
