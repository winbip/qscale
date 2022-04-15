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
    public partial class frmUserDetails : Form
    {

        #region Private Variables

        private UserDetails CurrentEntity;
        #endregion

        #region Constructors

        public frmUserDetails()
        {
            InitializeComponent();
            RedToolTip.OwnerDraw = true;
            RedToolTip.BackColor = System.Drawing.Color.Red;
            RedToolTip.ForeColor = System.Drawing.Color.White; //if option-A is used.
            AddEventHandlers(); AddDataBindings(); AddNewCurrentEntity();
            btnDelete.Visible = false;
        }


        #endregion

        #region Add Event Handlers

        private void AddEventHandlers()
        {
            
             this.Load += FormLoadHandler;
             btnSelectUser.Click += SelectUser;
             btnSave.Click += SaveEntity;
             btnNewEntity.Click += NewEntity;
             btnDelete.Click += DeleteEntity;
             btnClose.Click += CloseForm;

             RedToolTip.Draw += new DrawToolTipEventHandler(RedToolTipDraw); 

             AddCommonEventHandlers();
             
        }
        #endregion

        #region BindingSource

        private void AddNewCurrentEntity()
        {
            CurrentEntity = new UserDetails(GlobalVariables.ConnectionString);
            bsCurrentEntity.Clear();
            bsCurrentEntity.DataSource = CurrentEntity;
            btnDelete.Visible = false;
        }

        private void AddDataBindings()
        {
            bsCurrentEntity.DataSource = typeof(UserDetails);
            txtLogInName.DataBindings.Add("Text", bsCurrentEntity, "LogInName",false,DataSourceUpdateMode.OnPropertyChanged);
            txtLogInPassword.DataBindings.Add("Text", bsCurrentEntity, "LogInPassword", false, DataSourceUpdateMode.OnPropertyChanged);
            txtFullName.DataBindings.Add("Text", bsCurrentEntity, "FullName", false, DataSourceUpdateMode.OnPropertyChanged);
            txtDesignation.DataBindings.Add("Text", bsCurrentEntity, "UserDesignation", false, DataSourceUpdateMode.OnPropertyChanged);
        }
        #endregion

        private void RedToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            //Option A (should be the first choice)
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        

        

        #region FormLoading Event Handler
        
        private void FormLoadHandler(object sender, EventArgs e)
        {
           // CreateFocusOrderTable();
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
                        if (!GlobalVariables.currentUser.FindPermission("1"))
                        {
                            CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Login", "Unauthorized Access", "You are authorized. Contact your admin."));
                            return;
                        }
                    }
              

                    btnSave.Enabled = false;
                    if (CurrentEntity.IsDirty)
                    {
                    UserDetails.SaveEntity(CurrentEntity);
                    CustomMessageBox.ShowSuccessMessage(new SuccessMessage("Success", "Success", "Information successfully saved."));
                    //bsCurrentEntity.AddNew();
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

        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewEntity(object sender, EventArgs e)
        {
            AddNewCurrentEntity();
        }

        private void SelectUser(object sender, EventArgs e)
        {
            frmUserList frm = new frmUserList();
            if (frm.ShowDialog()==DialogResult.OK)
            {
                CurrentEntity = UserDetails.GetEntity(frm.SelectedEntityId, GlobalVariables.ConnectionString);
                bsCurrentEntity.DataSource=CurrentEntity;
            }
        }
        #endregion

        #region Textbox Validating Events

        private void ValidateCompanyName(object sender, CancelEventArgs e)
        {
            //Control control = sender as Control;

            //MyErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            //string controlvalue = control.Text.Trim();

            //string ErrMsg = string.Empty;

            //if (string.IsNullOrEmpty(controlvalue))
            //{
            //    ErrMsg = "Enter Company Name.";
            //    MyErrorProvider.SetError(control, ErrMsg);
            //    UpdateHashTable(control, ErrMsg);
            //    return;
            //}
            //else
            //{
            //    MyErrorProvider.SetError(control, "");
            //    mHashTable.Remove(control);
            //}
        }

        #endregion

        

        #region Commen Enter,Leave, KeyDown EventHandlers
        //These are the common method for all control 

        private void AddCommonEventHandlers()
        {
            //---> MouseDown Events
            // txtBookingNo.MouseDown += HandleMouseDownEvent;
            //<--- MouseDown Events

            //---> Enter Events

            //<--- Enter Events

            //---> Leave Events

            //<--- Leave Events

            //---> KeyDown Events (These controls are not related any type of validation)

            //<--- KeyDown Events
        }

        private void EnterEventHandler(object sender, EventArgs e)
        {
            Control control = sender as Control;
            // control.BackColor = GlobalVariables.GotFocusBackColor;
            //control.ForeColor = GlobalVariables.GotFocusForeColor;
        }

        private void LeaveEventHandler(object sender, EventArgs e)
        {
            Control control = sender as Control;
            //control.BackColor = GlobalVariables.LostFocusBackColor;
            //control.ForeColor = GlobalVariables.LostFocusForeColor;
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

            dtFocusOrder.Rows.Add("txtBookingNo");
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


        private void HandleExceptionWithControl(ExceptionWithControl EWC)
        {
            string strControlName = EWC.ControlName;
            Control control = null;
            switch (strControlName)
            {
                case "LogInName":
                    control = txtLogInName;
                    break;
                default:
                    break;
            }
            CustomMessageBox.ShowGeneralMessage(new GeneralMessage(EWC.TitleBarMessage, EWC.HeadLineMessage, EWC.ErrorDescription));
            MyErrorProvider.SetError(control, EWC.ErrorDescription); control.Focus();
        }
        

    }
}
