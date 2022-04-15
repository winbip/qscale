using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CustomObjects;
using sCommonLib;
using sCommonLib.Messages;
using sCommonLib.Exceptions;
using System.Collections;

namespace QScaleNew.MasterSetupForms
{
    public partial class frmMeasurementUnit : Form
    {

        #region Private Variables

        private MeasurementUnit CurrentEntity;
        #endregion

        #region Constructors

        public frmMeasurementUnit()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.TrialBalanceIco48;
            RedToolTip.OwnerDraw = true;
            RedToolTip.BackColor = System.Drawing.Color.Red;
            RedToolTip.ForeColor = System.Drawing.Color.White; //if option-A is used.
            AddEventHandlers(); AddDataBindings();

        }


        #endregion

        #region Add Event Handlers

        private void AddEventHandlers()
        {

            this.Load += FormLoadHandler;
            btnSave.Click += SaveEntity;
            btnClose.Click += CloseForm;

            RedToolTip.Draw += new DrawToolTipEventHandler(RedToolTipDraw);

            AddCommonEventHandlers();

        }
        #endregion

        #region BindingSource

        private void AddDataBindings()
        {
            bsCurrentEntity.DataSource = typeof(MeasurementUnit);
            txtMeasurementUnitName.DataBindings.Add("Text", bsCurrentEntity, "UnitName", false, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
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
            CurrentEntity = GlobalVariables.measurementUnit;
            bsCurrentEntity.DataSource = CurrentEntity;
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
                    if (!GlobalVariables.currentUser.FindPermission("5"))
                    {
                        CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Login", "Unauthorized Access", "You are not authorized. Contact your admin."));
                        return;
                    }
                }

                btnSave.Enabled = false;

                if (CurrentEntity.IsDirty)
                {
                    MeasurementUnit.SaveEntity(CurrentEntity);
                    CustomMessageBox.ShowSuccessMessage(new SuccessMessage("Success", "Success", "Information successfully saved."));
                    //bsCurrentEntity.AddNew();
                }


            }
            catch (UserException UEx)
            {
                CustomMessageBox.ShowUserException(UEx);

            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
            finally { btnSave.Enabled = true; btnSave.Focus(); }

        }

        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
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
            // txt .Enter += TextBoxEnterEventHandler;
            txtMeasurementUnitName.Enter += EnterEventHandler;
            //<--- Enter Events

            //---> Leave Events
            txtMeasurementUnitName.Leave += LeaveEventHandler;
            //<--- Leave Events

            //---> KeyDown Events (These controls are not related any type of validation)

            //<--- KeyDown Events
        }

        private void EnterEventHandler(object sender, EventArgs e)
        {
            Control control = sender as Control;
            control.BackColor = GlobalVariables.GotFocusBackColor;
            control.ForeColor = GlobalVariables.GotFocusForeColor;
        }

        private void LeaveEventHandler(object sender, EventArgs e)
        {
            Control control = sender as Control;
            control.BackColor = GlobalVariables.LostFocusBackColor;
            control.ForeColor = GlobalVariables.LostFocusForeColor;
        }




        #endregion

        private void frmMeasurementUnit_Load(object sender, EventArgs e)
        {

        }
    }
}
