using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CustomObjects;
using sCommonLib;
using sCommonLib.Messages;
using sCommonLib.Exceptions;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace QScale
{
    public partial class frmMain : Form
    {
        private StartupError pStartupError;

        public frmMain()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.QFlexIcon;
           
            pbDeviceStatus.Image = Properties.Resources.DeviceStatusDisconnected128;
            pStartupError = new StartupError();

            this.FormClosing += FormIsClosing;
            submenuAddOperator.Click += OpenAddNewUserForm;
            submenuOperatorList.Click += OpenUserListForm;
            submenuAddClient.Click += OpenClientDetailsForm;
            submenuClientList.Click += OpenClientListForm;
            submenuMeasurementUnit.Click += OpenMeasurementUnitForm;
            submenuTruckInWeight.Click += OpenTruckInForm;
            submenuTruckInHistory.Click += OpenTruckInHistoryForm;
            submenuTruckOutWeight.Click += OpenTruckOutForm;
            submenuTruckOutHistory.Click += OpenTruckOutHistoryForm;

            pbConnect.Click += Connect;
            pbDisconnect.Click += Disconnect;
           
            ComPort.DataReceived += DataReceived;

            submenuAssemblyUtility.Click += OpenAssemblyUtilityForm;

            submenuAboutUs.Click += OpenAboutUsForm;


            pbTruckInWeigh.Click += ShortCutToTruckInForm;
            pbTruckOutWeight.Click += ShortCutToTruckOutForm;
        }

        public StartupError StartupErrorInfo
        {
            get { return pStartupError; }
            set { pStartupError = value; }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            //int FormWidth = this.Width + 173;
            //lblAppName.Top = (this.Height - lblAppName.Height) / 2;
            //lblAppName.Left = (FormWidth - lblAppName.Width) / 2;
        }

        public void StartSplashForm()
        {
            frmSplash SplashForm = new frmSplash(this);
            DialogResult SplashResult = SplashForm.ShowDialog();

            switch (SplashResult)
            {
                case DialogResult.Abort:
                    break;

                case DialogResult.OK:
                    ProgramMenuForms.frmLogIn LogInForm = new ProgramMenuForms.frmLogIn(this);
                    LogInForm.ShowDialog();
                    break;

                case DialogResult.Retry:
                    MessageBox.Show(this.pStartupError.ErrorDetails.ToString());
                    switch (this.pStartupError.StartupErrorId)
                    {
                        case 101: //Database Configuration not found.
                            MasterSetupForms.frmDatabaseConfiguration frm = new MasterSetupForms.frmDatabaseConfiguration(this);
                            frm.Show(this);
                            frm.BringToFront();
                            break;

                        case 102:
                            break;

                        case 103: //Font installed completed.
                            Application.Restart();
                            break;

                        case 104: // Font not found in application directory.
                            Application.Exit();
                            break;

                        default:
                            break;
                    }

                    break;
                default:
                    break;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                //Multiple Instance of this application is turned-off. See Program.cs for details.
                ProcessLogOut();
                StatusLabelDate.Text = DateTime.Today.Date.ToString("dd MMM yyyy");

                string[] PortNames = SerialPort.GetPortNames();
                foreach (string port in PortNames)
                {
                    cmbPortName.Items.Add(port);
                }

                StartSplashForm();
            }
            catch (UserException UEX)
            {
                CustomMessageBox.ShowUserException(UEX);
            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
        }

        private void FormIsClosing(object sender, FormClosingEventArgs e)
        {
            if (ContinueToReadBuffer)
            {
                MessageBox.Show("Connection is currently open. Close the connection from device.");
                e.Cancel = true;
            }
        }

        #region Process Login Logout
        public void ProcessLogIn() //this has been called from frmLogIn.
        {
            this.submenuLogIn.Enabled = false;
            this.submenuLogOut.Enabled = true;
            this.submenuChangePassword.Enabled = true;

            this.StatusLabelLoginStatus.Image = Properties.Resources.LoggedIn;
            this.StatusLabelLoginStatus.ForeColor = Color.Green;
            this.StatusLabelLoginStatus.Text = "User: " + GlobalVariables.currentUser.UserInformation.LogInName;
        }


        private void ProcessLogOut()
        {
            GlobalVariables.currentUser = null;

            submenuLogIn.Enabled = true;
            submenuLogOut.Enabled = false;
            submenuChangePassword.Enabled = false;

            StatusLabelLoginStatus.Image = Properties.Resources.LoggedOut;
            StatusLabelLoginStatus.ForeColor = Color.Red;
            StatusLabelLoginStatus.Text = "User: None";

        }

        #endregion

        #region Program Menu Forms

        private void submenuLogIn_Click(object sender, EventArgs e)
        {
            ProgramMenuForms.frmLogIn LogInForm = new ProgramMenuForms.frmLogIn(this);
            LogInForm.ShowDialog();
        }

        private void submenuLogOut_Click(object sender, EventArgs e)
        {
            ProcessLogOut();
            ProgramMenuForms.frmLogIn LogInForm = new ProgramMenuForms.frmLogIn(this);
            LogInForm.ShowDialog();
        }


        private void submenuChangePassword_Click(object sender, EventArgs e)
        {
            ProgramMenuForms.frmChangePassword frm =
                new ProgramMenuForms.frmChangePassword();
            frm.Show(this);
        }

        private void submenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Master Setup Forms

        private void submenuCompanyInfo_Click(object sender, EventArgs e)
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
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("User Denied", "Unauthorized Access", "You are not permitted . Contact your admin."));
                    return;
                }
            }

            MasterSetupForms.frmCompanyInfo frm = new MasterSetupForms.frmCompanyInfo();
            frm.Show();
        }

        private void OpenAddNewUserForm(object sender, EventArgs e)
        {
            if (GlobalVariables.currentUser == null)
            {
                CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Login", "Access Denied", "You are currently not logged in. Please login first."));
                return;
            }
            else
            {
                if (!GlobalVariables.currentUser.FindPermission("2"))
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are not permitted. Contact your admin."));
                    return;
                }
            }

            MasterSetupForms.frmUserDetails frm = new MasterSetupForms.frmUserDetails();
            frm.Show(this);
        }

        private void OpenUserListForm(object sender, EventArgs e)
        {
            if (GlobalVariables.currentUser == null)
            {
                CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Login", "Access Denied", "You are currently not logged in. Please login first."));
                return;
            }

            MasterSetupForms.frmUserList frm = new MasterSetupForms.frmUserList();
            frm.Show(this);
        }

        private void submenuPermissions_Click(object sender, EventArgs e)
        {
            if (GlobalVariables.currentUser == null)
            {
                CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Login", "Access Denied", "You are currently not logged in. Please login first."));
                return;
            }
            else
            {
                if (!GlobalVariables.currentUser.FindPermission("3"))
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are not permitted. Contact your admin."));
                    return;
                }
            }

            MasterSetupForms.frmPermissions frm = new MasterSetupForms.frmPermissions();
            frm.Show(this);
        }

        private void OpenClientDetailsForm(object sender, EventArgs e)
        {
            if (GlobalVariables.currentUser == null)
            {
                CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Login", "Access Denied", "You are currently not logged in. Please login first."));
                return;
            }

            MasterSetupForms.frmClientDetails frm = new MasterSetupForms.frmClientDetails();
            frm.Show(this);
        }

        private void OpenClientListForm(object sender, EventArgs e)
        {
            if (GlobalVariables.currentUser == null)
            {
                CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Login", "Access Denied", "You are currently not logged in. Please login first."));
                return;
            }

            MasterSetupForms.frmClientList frm = new MasterSetupForms.frmClientList();
            frm.Show(this);
        }

        private void OpenMeasurementUnitForm(object sender, EventArgs e)
        {
            if (GlobalVariables.currentUser == null)
            {
                CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Login", "Access Denied", "You are currently not logged in. Please login first."));
                return;
            }
            else
            {
                if (!GlobalVariables.currentUser.FindPermission("5"))
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Access Denied", "Access Denied", "You are not permitted. Contact your admin."));
                    return;
                }
            }

            MasterSetupForms.frmMeasurementUnit frm = new MasterSetupForms.frmMeasurementUnit();
            frm.Show(this);
        }
        #endregion

        #region Utility Menu Forms

        private void submenuErrorLogs_Click(object sender, EventArgs e)
        {
            string ErrorLogPath = Path.Combine(GlobalVariables.AppDataDirectoryPath, "ErrorLog.log");
            Process.Start(ErrorLogPath);
        }

        #endregion

        private void submenuResetDatabase_Click(object sender, EventArgs e)
        {
            InputDialogBox.InputDialogResult result = InputDialogBox.InputDialog.Show(InputDialogBox.InputType.String, "Enter Password");
            if (result.OK)
            {
                if (result.Value.ToString().Equals("somehowiknow"))
                {
                    frmResetDatabase frm = new frmResetDatabase();
                    frm.Show(this);
                }
                else
                {
                    MessageBox.Show("Wrong Password");
                }
            }

        }

        private void submenuEventMaker_Click(object sender, EventArgs e)
        {
            frmEventMaker frm = new frmEventMaker();
            frm.Show();
        }

        private void submenuDatabaseConfiguration_Click(object sender, EventArgs e)
        {
            MasterSetupForms.frmDatabaseConfiguration frm = new MasterSetupForms.frmDatabaseConfiguration(this);
            frm.Show(this);
        }

        #region WeightMenuLinks

        private void OpenTruckInForm(object sender, EventArgs e)
        {
            if (GlobalVariables.currentUser == null)
            {
                CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Login", "Access Denied", "You are currently not logged in. Please login first."));
                return;
            }

            WeightMenuForms.frmTruckIn frm = new WeightMenuForms.frmTruckIn(this); frm.Show(this);
        }

        private void OpenTruckInHistoryForm(object sender, EventArgs e)
        {
            if (GlobalVariables.currentUser == null)
            {
                CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Login", "Access Denied", "You are currently not logged in. Please login first."));
                return;
            }

            WeightMenuForms.frmTruckInHistory frm = new WeightMenuForms.frmTruckInHistory(); frm.Show(this);
        }

        private void OpenTruckOutForm(object sender, EventArgs e)
        {
            if (GlobalVariables.currentUser == null)
            {
                CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Login", "Access Denied", "You are currently not logged in. Please login first."));
                return;
            }

            WeightMenuForms.frmTruckOut frm = new WeightMenuForms.frmTruckOut(this); frm.Show(this);
        }

        private void OpenTruckOutHistoryForm(object sender, EventArgs e)
        {
            if (GlobalVariables.currentUser == null)
            {
                CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Login", "Access Denied", "You are currently not logged in. Please login first."));
                return;
            }

            WeightMenuForms.frmTruckOutHistory frm = new WeightMenuForms.frmTruckOutHistory(); frm.Show(this);
        }
        #endregion

        #region Device on main Frm

        public decimal CurrentWeight = 0;
        public string bufferString;
        private EventWaitHandle AllowInBuffer = new AutoResetEvent(false);
        private bool ContinueToReadBuffer=false;


        //pbConnect click event
        private void Connect(object sender, EventArgs e)
        {
            if (cmbPortName.SelectedIndex == -1)
            {
                CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Connection", "Port Name required", "Port name not found. Select a port from port list."));
                cmbPortName.Focus(); return;
            }

            try
            {
                pbConnect.Enabled = false;
                
               lblDeviceStatus.Text = "Trying to connect..";
                System.Threading.Thread.Sleep(200);
         
                bufferString = string.Empty;

                ComPort.PortName = cmbPortName.Text;
                ComPort.Open();

                ComPort.DiscardInBuffer(); ComPort.DiscardOutBuffer();
                AllowInBuffer.Set();
                System.Threading.Thread.Sleep(1000);

                if (bufferString.Length > 0)
                {
                    ContinueToReadBuffer = true;
                    pbConnect.Enabled = false;
                    pbDisconnect.Enabled = true;
                    cmbPortName.Enabled = false;
                    lblDeviceStatus.Text = "Connected";
                    pbDeviceStatus.Image = Properties.Resources.DeviceStatusConnected128;
                }
                else
                {
                    ContinueToReadBuffer = false;
                    pbConnect.Enabled = true;
                    pbDisconnect.Enabled = false;
                    cmbPortName.Enabled = true;
                    lblDeviceStatus.Text = "Disconnected";
                    bufferString = string.Empty; 
                    ComPort.Close();
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Connection", "Fail to connect", "Communication with the weight device failed. Make sure the device is switched on."));
                }

            }
            catch (Exception Ex)
            {
                ContinueToReadBuffer = false;
                pbConnect.Enabled = true;
                pbDisconnect.Enabled = false;
                cmbPortName.Enabled = true;
                lblDeviceStatus.Text = "Disconnected";
                MessageBox.Show(Ex.Message);
            }
        }

        private void Disconnect(object sender, EventArgs e)
        {
            lblDeviceStatus.Text = "Wait..";
            pbDisconnect.Enabled = false;
            ContinueToReadBuffer = false;
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            MessageBox.Show(ComPort.ReadExisting());
            //AllowInBuffer.WaitOne();

            ////--> Check whether continue to read buffer
            //if (ContinueToReadBuffer) //If ContinueToReadBuffer=true
            //{
            //    //--> Check Length of Incoming Data
            //    if (ComPort.BytesToRead == 12) //--> if BytesToRead==12
            //    {
            //        bufferString = ComPort.ReadExisting();
            //        try
            //        {
            //            if (bufferString.StartsWith("\x02") && bufferString.EndsWith("\x03"))
            //            {
            //                //ComPort.Close();
            //                CurrentWeight = ProcessBuffer(bufferString);

            //                System.Threading.Thread.Sleep(200);
            //                ComPort.DiscardInBuffer(); ComPort.DiscardOutBuffer();
            //                AllowInBuffer.Set();
            //            }
            //            else
            //            {
            //                System.Threading.Thread.Sleep(200);
            //                ComPort.DiscardInBuffer(); ComPort.DiscardOutBuffer();
            //                AllowInBuffer.Set();
            //            }

            //        }
            //        catch (Exception Ex)
            //        {
            //            MessageBox.Show(Ex.Message);
            //        }
            //    } //<-- if BytesToRead==12
            //    else //--> if BytesToRead != 12
            //    {
            //        System.Threading.Thread.Sleep(200);
            //        ComPort.DiscardInBuffer(); ComPort.DiscardOutBuffer();
            //        AllowInBuffer.Set();
            //    } //<-- if BytesToRead != 12
            //    //<-- Check Length of Incoming Data
            //}
            //else //If ContinueToReadBuffer = false
            //{
            //    try
            //    {
            //        ComPort.Close();
            //        EnableComboBox();
            //        EnableConnectButton();
            //        DisableDisconnectButton();
            //        UpdatePictureBox();
            //        UpdateStatusLable();
            //    }
            //    catch (Exception Ex)
            //    {
            //        MessageBox.Show(Ex.Message);
            //    }
            //}
            ////<-- Check whether continue to read buffer
        }

        private decimal ProcessBuffer(string buffer)
        {
            int StartIndex = 0;
            StartIndex = buffer.IndexOf('\x02');
            string ValidData = buffer.Substring(StartIndex, 10);

            string Sign_Part = "";
            string Integer_Part = "";
            string Fraction_Part = "";
            string Weight = "";
            if (ValidData.Substring(1, 1) == "\x2D") { Sign_Part = "-"; } else { Sign_Part = " "; }
            Integer_Part = ValidData.Substring(2, 6);
            Fraction_Part = ValidData.Substring(8, 1);

            Weight = Sign_Part + Integer_Part + "." + Fraction_Part;
            return decimal.Parse(Weight);
        }

        private void EnableComboBox()
        {

            if (cmbPortName.InvokeRequired)
            {
                MethodInvoker del = delegate { EnableComboBox(); };
                this.Invoke(del);
                return;
            }
            this.cmbPortName.Enabled = true;
        }

        private void EnableConnectButton()
        {
            if (pbConnect.InvokeRequired)
            {
                MethodInvoker del = delegate { EnableConnectButton(); };
                this.Invoke(del);
                return;
            }
           
            this.pbConnect.Enabled = true;           
        }

        private void DisableDisconnectButton()
        {
            if (pbDisconnect.InvokeRequired)
            {
                MethodInvoker del = delegate { DisableDisconnectButton(); };
                this.Invoke(del);
                return;
            }

            this.pbDisconnect.Enabled = false;
        }

        private void UpdatePictureBox()
        {

            if (pbDeviceStatus.InvokeRequired)
            {
                MethodInvoker del = delegate { UpdatePictureBox(); };
                this.Invoke(del);
                return;
            }

            this.pbDeviceStatus.Image = Properties.Resources.DeviceStatusDisconnected128;
        }

        private void UpdateStatusLable()
        {

            if (lblDeviceStatus.InvokeRequired)
            {
                MethodInvoker del = delegate { UpdateStatusLable(); };
                this.Invoke(del);
                return;
            }

            this.lblDeviceStatus.Text = "Disconnected.";
        }
        #endregion

        #region MyUtilities

        private void OpenAssemblyUtilityForm(object sender, EventArgs e)
        {
            MyUtilitiesForm.frmAssemblyUtility frm = new MyUtilitiesForm.frmAssemblyUtility();
            frm.Show(this);
        }

        #endregion

        #region About Us Forms
        private void OpenAboutUsForm(object sender, EventArgs e)
        {
            AboutUsForms.frmAboutUs frm = new AboutUsForms.frmAboutUs();
            frm.Show(this);
        }
        #endregion


        #region Homepage shortcust

        private void ShortCutToTruckInForm(object sender, EventArgs e)
        {
            if (GlobalVariables.currentUser == null)
            {
                CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Login", "Access Denied", "You are currently not logged in. Please login first."));
                return;
            }

            WeightMenuForms.frmTruckIn frm = new WeightMenuForms.frmTruckIn(this); frm.Show(this);
        }

        private void ShortCutToTruckOutForm(object sender, EventArgs e)
        {
            if (GlobalVariables.currentUser == null)
            {
                CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Login", "Access Denied", "You are currently not logged in. Please login first."));
                return;
            }

            WeightMenuForms.frmTruckOut frm = new WeightMenuForms.frmTruckOut(this); frm.Show(this);
        }

        #endregion

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
