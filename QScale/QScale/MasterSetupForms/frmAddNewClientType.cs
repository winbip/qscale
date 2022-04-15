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
    public partial class frmAddNewClientType : Form
    {

        #region Private Variables
            private ClientType CurrentEntity;
        #endregion

        #region Public Properties

            public ClientType CreatedClientType
            {
                get { return CurrentEntity; }
            }

        #endregion

        #region Constructors

            public frmAddNewClientType()
        {
            InitializeComponent();
            RedToolTip.OwnerDraw = true;
            RedToolTip.BackColor = System.Drawing.Color.Red;
            RedToolTip.ForeColor = System.Drawing.Color.White; //if option-A is used.
            AddEventHandlers(); AddDataBindings(); AddNewCurrentEntity();
        }

       #endregion

        #region Add Event Handlers

        private void AddEventHandlers()
        {            
             btnSave.Click += SaveEntity;
             btnClose.Click += CloseForm;

             RedToolTip.Draw += new DrawToolTipEventHandler(RedToolTipDraw); 
        }
        #endregion

        #region BindingSource

        private void AddNewCurrentEntity()
        {
            CurrentEntity = new ClientType(GlobalVariables.ConnectionString);
            bsCurrentEntity.Clear();
            bsCurrentEntity.DataSource = CurrentEntity;
        }

        private void AddDataBindings()
        {
            bsCurrentEntity.DataSource = typeof(ClientType);
            txtClientTypeName.DataBindings.Add("Text", bsCurrentEntity, "ClientTypeName", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        #endregion

        private void RedToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            //Option A (should be the first choice)
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();

            /* Option B
            Font f = new Font("Arial", 10.0f);
            toolTip1.BackColor = System.Drawing.Color.Blue;
           
            e.DrawBackground();
            e.DrawBorder();
            e.Graphics.DrawString(e.ToolTipText, f, Brushes.White, new PointF(2, 2));
            */
        }

        

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
                        ClientType.SaveEntity(CurrentEntity);
                        this.DialogResult = DialogResult.OK;
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
                finally { btnSave.Enabled = true; btnDelete.Visible = true; btnSave.Focus(); } 
            
        }

        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


    }
}
