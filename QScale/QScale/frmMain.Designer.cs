namespace QScale
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MyMenuStrip = new System.Windows.Forms.MenuStrip();
            this.menuProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuLogIn = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.submenuChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.submenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMasterSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuDatabaseConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.submenuCompanyInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.submenuUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuAddOperator = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.submenuOperatorList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.submenuPermissions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.submenuClients = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuAddClient = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.submenuClientList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.submenuMeasurementUnit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWeight = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuTruckInWeight = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuTruckInHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.submenuTruckOutWeight = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuTruckOutHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUtility = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuErrorLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuAboutUs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMyUtilities = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuAssemblyUtility = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.submenuEventMaker = new System.Windows.Forms.ToolStripMenuItem();
            this.MyStatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabelLoginStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabelDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.lblDeviceStatus = new System.Windows.Forms.Label();
            this.pbDeviceStatus = new System.Windows.Forms.PictureBox();
            this.pbConnect = new System.Windows.Forms.PictureBox();
            this.pbDisconnect = new System.Windows.Forms.PictureBox();
            this.ComPort = new System.IO.Ports.SerialPort(this.components);
            this.kryptonHeader1 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pbTruckInWeigh = new System.Windows.Forms.PictureBox();
            this.pbTruckOutWeight = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.MyMenuStrip.SuspendLayout();
            this.MyStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeviceStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDisconnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTruckInWeigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTruckOutWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // MyMenuStrip
            // 
            this.MyMenuStrip.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MyMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MyMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuProgram,
            this.menuMasterSetup,
            this.menuWeight,
            this.menuUtility,
            this.menuAbout,
            this.menuMyUtilities});
            this.MyMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MyMenuStrip.Name = "MyMenuStrip";
            this.MyMenuStrip.Size = new System.Drawing.Size(934, 24);
            this.MyMenuStrip.TabIndex = 0;
            this.MyMenuStrip.Text = "menuStrip1";
            // 
            // menuProgram
            // 
            this.menuProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuLogIn,
            this.submenuLogOut,
            this.toolStripSeparator1,
            this.submenuChangePassword,
            this.toolStripSeparator2,
            this.submenuExit});
            this.menuProgram.Name = "menuProgram";
            this.menuProgram.Size = new System.Drawing.Size(65, 20);
            this.menuProgram.Text = "Program";
            // 
            // submenuLogIn
            // 
            this.submenuLogIn.Image = global::QScale.Properties.Resources.LogInGreenArrow;
            this.submenuLogIn.Name = "submenuLogIn";
            this.submenuLogIn.Size = new System.Drawing.Size(168, 22);
            this.submenuLogIn.Text = "Log &In";
            this.submenuLogIn.Click += new System.EventHandler(this.submenuLogIn_Click);
            // 
            // submenuLogOut
            // 
            this.submenuLogOut.Image = global::QScale.Properties.Resources.LogOutWhiteArrow16;
            this.submenuLogOut.Name = "submenuLogOut";
            this.submenuLogOut.Size = new System.Drawing.Size(168, 22);
            this.submenuLogOut.Text = "Log &Out";
            this.submenuLogOut.Click += new System.EventHandler(this.submenuLogOut_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // submenuChangePassword
            // 
            this.submenuChangePassword.Image = global::QScale.Properties.Resources.KeyNice16;
            this.submenuChangePassword.Name = "submenuChangePassword";
            this.submenuChangePassword.Size = new System.Drawing.Size(168, 22);
            this.submenuChangePassword.Text = "&Change Password";
            this.submenuChangePassword.Click += new System.EventHandler(this.submenuChangePassword_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
            // 
            // submenuExit
            // 
            this.submenuExit.Image = global::QScale.Properties.Resources.ExitProgram16;
            this.submenuExit.Name = "submenuExit";
            this.submenuExit.Size = new System.Drawing.Size(168, 22);
            this.submenuExit.Text = "E&xit";
            this.submenuExit.Click += new System.EventHandler(this.submenuExit_Click);
            // 
            // menuMasterSetup
            // 
            this.menuMasterSetup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuDatabaseConfiguration,
            this.toolStripSeparator4,
            this.submenuCompanyInfo,
            this.toolStripSeparator5,
            this.submenuUsers,
            this.toolStripSeparator6,
            this.submenuPermissions,
            this.toolStripSeparator3,
            this.submenuClients,
            this.toolStripSeparator10,
            this.submenuMeasurementUnit});
            this.menuMasterSetup.Name = "menuMasterSetup";
            this.menuMasterSetup.Size = new System.Drawing.Size(88, 20);
            this.menuMasterSetup.Text = "Master Setup";
            // 
            // submenuDatabaseConfiguration
            // 
            this.submenuDatabaseConfiguration.Image = global::QScale.Properties.Resources.ServerPng16;
            this.submenuDatabaseConfiguration.Name = "submenuDatabaseConfiguration";
            this.submenuDatabaseConfiguration.Size = new System.Drawing.Size(199, 22);
            this.submenuDatabaseConfiguration.Text = "Database Configuration";
            this.submenuDatabaseConfiguration.Click += new System.EventHandler(this.submenuDatabaseConfiguration_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(196, 6);
            // 
            // submenuCompanyInfo
            // 
            this.submenuCompanyInfo.Image = global::QScale.Properties.Resources.OfficeTree16;
            this.submenuCompanyInfo.Name = "submenuCompanyInfo";
            this.submenuCompanyInfo.Size = new System.Drawing.Size(199, 22);
            this.submenuCompanyInfo.Text = "&Company Info";
            this.submenuCompanyInfo.Click += new System.EventHandler(this.submenuCompanyInfo_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(196, 6);
            // 
            // submenuUsers
            // 
            this.submenuUsers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuAddOperator,
            this.toolStripSeparator11,
            this.submenuOperatorList});
            this.submenuUsers.Name = "submenuUsers";
            this.submenuUsers.Size = new System.Drawing.Size(199, 22);
            this.submenuUsers.Text = "&Operators";
            // 
            // submenuAddOperator
            // 
            this.submenuAddOperator.Image = global::QScale.Properties.Resources.UserGreen16;
            this.submenuAddOperator.Name = "submenuAddOperator";
            this.submenuAddOperator.Size = new System.Drawing.Size(146, 22);
            this.submenuAddOperator.Text = "Add Operator";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(143, 6);
            // 
            // submenuOperatorList
            // 
            this.submenuOperatorList.Image = global::QScale.Properties.Resources.UserGroupBlueGreen16;
            this.submenuOperatorList.Name = "submenuOperatorList";
            this.submenuOperatorList.Size = new System.Drawing.Size(146, 22);
            this.submenuOperatorList.Text = "Operator List";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(196, 6);
            // 
            // submenuPermissions
            // 
            this.submenuPermissions.Image = global::QScale.Properties.Resources.PermissionPageKey16;
            this.submenuPermissions.Name = "submenuPermissions";
            this.submenuPermissions.Size = new System.Drawing.Size(199, 22);
            this.submenuPermissions.Text = "&Permissions";
            this.submenuPermissions.Click += new System.EventHandler(this.submenuPermissions_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(196, 6);
            // 
            // submenuClients
            // 
            this.submenuClients.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuAddClient,
            this.toolStripSeparator12,
            this.submenuClientList});
            this.submenuClients.Name = "submenuClients";
            this.submenuClients.Size = new System.Drawing.Size(199, 22);
            this.submenuClients.Text = "Clients";
            // 
            // submenuAddClient
            // 
            this.submenuAddClient.Name = "submenuAddClient";
            this.submenuAddClient.Size = new System.Drawing.Size(130, 22);
            this.submenuAddClient.Text = "Add Client";
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(127, 6);
            // 
            // submenuClientList
            // 
            this.submenuClientList.Name = "submenuClientList";
            this.submenuClientList.Size = new System.Drawing.Size(130, 22);
            this.submenuClientList.Text = "Client List";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(196, 6);
            // 
            // submenuMeasurementUnit
            // 
            this.submenuMeasurementUnit.Image = global::QScale.Properties.Resources.TrialBalancePng16;
            this.submenuMeasurementUnit.Name = "submenuMeasurementUnit";
            this.submenuMeasurementUnit.Size = new System.Drawing.Size(199, 22);
            this.submenuMeasurementUnit.Text = "Measurement Unit";
            // 
            // menuWeight
            // 
            this.menuWeight.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuTruckInWeight,
            this.submenuTruckInHistory,
            this.toolStripSeparator13,
            this.submenuTruckOutWeight,
            this.submenuTruckOutHistory});
            this.menuWeight.Name = "menuWeight";
            this.menuWeight.Size = new System.Drawing.Size(57, 20);
            this.menuWeight.Text = "Weight";
            // 
            // submenuTruckInWeight
            // 
            this.submenuTruckInWeight.Image = global::QScale.Properties.Resources.LoadTruckPng16;
            this.submenuTruckInWeight.Name = "submenuTruckInWeight";
            this.submenuTruckInWeight.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.submenuTruckInWeight.Size = new System.Drawing.Size(211, 22);
            this.submenuTruckInWeight.Text = "Truck-in Weight";
            // 
            // submenuTruckInHistory
            // 
            this.submenuTruckInHistory.Name = "submenuTruckInHistory";
            this.submenuTruckInHistory.Size = new System.Drawing.Size(211, 22);
            this.submenuTruckInHistory.Text = "Truck-in Weight History";
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(208, 6);
            // 
            // submenuTruckOutWeight
            // 
            this.submenuTruckOutWeight.Image = global::QScale.Properties.Resources.EmptyTruckPng16;
            this.submenuTruckOutWeight.Name = "submenuTruckOutWeight";
            this.submenuTruckOutWeight.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.submenuTruckOutWeight.Size = new System.Drawing.Size(211, 22);
            this.submenuTruckOutWeight.Text = "Truck-out Weight";
            // 
            // submenuTruckOutHistory
            // 
            this.submenuTruckOutHistory.Name = "submenuTruckOutHistory";
            this.submenuTruckOutHistory.Size = new System.Drawing.Size(211, 22);
            this.submenuTruckOutHistory.Text = "Truck-out Weight History";
            // 
            // menuUtility
            // 
            this.menuUtility.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuErrorLogs});
            this.menuUtility.Name = "menuUtility";
            this.menuUtility.Size = new System.Drawing.Size(50, 20);
            this.menuUtility.Text = "&Utility";
            // 
            // submenuErrorLogs
            // 
            this.submenuErrorLogs.Image = global::QScale.Properties.Resources.ErrorLogPng16;
            this.submenuErrorLogs.Name = "submenuErrorLogs";
            this.submenuErrorLogs.Size = new System.Drawing.Size(127, 22);
            this.submenuErrorLogs.Text = "&Error Logs";
            this.submenuErrorLogs.Click += new System.EventHandler(this.submenuErrorLogs_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuAboutUs});
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(52, 20);
            this.menuAbout.Text = "&About";
            // 
            // submenuAboutUs
            // 
            this.submenuAboutUs.Name = "submenuAboutUs";
            this.submenuAboutUs.Size = new System.Drawing.Size(123, 22);
            this.submenuAboutUs.Text = "&About Us";
            // 
            // menuMyUtilities
            // 
            this.menuMyUtilities.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuAssemblyUtility,
            this.toolStripSeparator14,
            this.submenuEventMaker});
            this.menuMyUtilities.Name = "menuMyUtilities";
            this.menuMyUtilities.Size = new System.Drawing.Size(78, 20);
            this.menuMyUtilities.Text = "My Utilities";
            this.menuMyUtilities.Visible = false;
            // 
            // submenuAssemblyUtility
            // 
            this.submenuAssemblyUtility.Name = "submenuAssemblyUtility";
            this.submenuAssemblyUtility.Size = new System.Drawing.Size(159, 22);
            this.submenuAssemblyUtility.Text = "Assembly Utility";
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(156, 6);
            // 
            // submenuEventMaker
            // 
            this.submenuEventMaker.Name = "submenuEventMaker";
            this.submenuEventMaker.Size = new System.Drawing.Size(159, 22);
            this.submenuEventMaker.Text = "Event Maker";
            // 
            // MyStatusStrip
            // 
            this.MyStatusStrip.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MyStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabelLoginStatus,
            this.StatusLabelDate});
            this.MyStatusStrip.Location = new System.Drawing.Point(0, 524);
            this.MyStatusStrip.Name = "MyStatusStrip";
            this.MyStatusStrip.Size = new System.Drawing.Size(934, 24);
            this.MyStatusStrip.TabIndex = 1;
            this.MyStatusStrip.Text = "statusStrip1";
            // 
            // StatusLabelLoginStatus
            // 
            this.StatusLabelLoginStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StatusLabelLoginStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.StatusLabelLoginStatus.Name = "StatusLabelLoginStatus";
            this.StatusLabelLoginStatus.Size = new System.Drawing.Size(76, 19);
            this.StatusLabelLoginStatus.Text = "Login Status";
            // 
            // StatusLabelDate
            // 
            this.StatusLabelDate.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StatusLabelDate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.StatusLabelDate.Name = "StatusLabelDate";
            this.StatusLabelDate.Size = new System.Drawing.Size(35, 19);
            this.StatusLabelDate.Text = "Date";
            // 
            // cmbPortName
            // 
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Location = new System.Drawing.Point(30, 65);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(94, 21);
            this.cmbPortName.TabIndex = 2;
            this.MyToolTip.SetToolTip(this.cmbPortName, "Select a port.");
            // 
            // lblDeviceStatus
            // 
            this.lblDeviceStatus.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDeviceStatus.Location = new System.Drawing.Point(32, 224);
            this.lblDeviceStatus.Name = "lblDeviceStatus";
            this.lblDeviceStatus.Size = new System.Drawing.Size(126, 16);
            this.lblDeviceStatus.TabIndex = 7;
            this.lblDeviceStatus.Text = "Disconnected.";
            this.lblDeviceStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbDeviceStatus
            // 
            this.pbDeviceStatus.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbDeviceStatus.Location = new System.Drawing.Point(30, 90);
            this.pbDeviceStatus.Name = "pbDeviceStatus";
            this.pbDeviceStatus.Size = new System.Drawing.Size(128, 128);
            this.pbDeviceStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbDeviceStatus.TabIndex = 5;
            this.pbDeviceStatus.TabStop = false;
            this.MyToolTip.SetToolTip(this.pbDeviceStatus, "Weigh bridge connection status.");
            // 
            // pbConnect
            // 
            this.pbConnect.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbConnect.Image = global::QScale.Properties.Resources.ConnectToPort;
            this.pbConnect.Location = new System.Drawing.Point(130, 68);
            this.pbConnect.Name = "pbConnect";
            this.pbConnect.Size = new System.Drawing.Size(16, 16);
            this.pbConnect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbConnect.TabIndex = 5;
            this.pbConnect.TabStop = false;
            this.MyToolTip.SetToolTip(this.pbConnect, "Click to connect with weigh bridge.");
            // 
            // pbDisconnect
            // 
            this.pbDisconnect.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbDisconnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDisconnect.Enabled = false;
            this.pbDisconnect.Image = global::QScale.Properties.Resources.DisconnectFromPort;
            this.pbDisconnect.Location = new System.Drawing.Point(152, 68);
            this.pbDisconnect.Name = "pbDisconnect";
            this.pbDisconnect.Size = new System.Drawing.Size(16, 16);
            this.pbDisconnect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbDisconnect.TabIndex = 6;
            this.pbDisconnect.TabStop = false;
            this.MyToolTip.SetToolTip(this.pbDisconnect, "Click to disconnect from weigh bridge.");
            // 
            // ComPort
            // 
            this.ComPort.PortName = "COM10";
            // 
            // kryptonHeader1
            // 
            this.kryptonHeader1.AutoSize = false;
            this.kryptonHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonHeader1.Location = new System.Drawing.Point(0, 24);
            this.kryptonHeader1.Name = "kryptonHeader1";
            this.kryptonHeader1.Size = new System.Drawing.Size(934, 30);
            this.kryptonHeader1.TabIndex = 12;
            this.kryptonHeader1.Values.Description = "";
            this.kryptonHeader1.Values.Heading = " ";
            this.kryptonHeader1.Values.Image = null;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 469);
            this.label1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(200, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1, 469);
            this.label2.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(734, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 469);
            this.label3.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(733, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1, 469);
            this.label4.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(201, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(532, 469);
            this.label5.TabIndex = 17;
            this.label5.Text = "gdhgfhgfghfh";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.SteelBlue;
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.Location = new System.Drawing.Point(0, 523);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(934, 1);
            this.label6.TabIndex = 18;
            // 
            // pbTruckInWeigh
            // 
            this.pbTruckInWeigh.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbTruckInWeigh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbTruckInWeigh.Image = global::QScale.Properties.Resources.LoadTruckBig128;
            this.pbTruckInWeigh.Location = new System.Drawing.Point(33, 259);
            this.pbTruckInWeigh.Name = "pbTruckInWeigh";
            this.pbTruckInWeigh.Size = new System.Drawing.Size(128, 128);
            this.pbTruckInWeigh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbTruckInWeigh.TabIndex = 19;
            this.pbTruckInWeigh.TabStop = false;
            this.MyToolTip.SetToolTip(this.pbTruckInWeigh, "Truck-in Weigh [ Ctrl+I ]");
            // 
            // pbTruckOutWeight
            // 
            this.pbTruckOutWeight.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbTruckOutWeight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbTruckOutWeight.Image = global::QScale.Properties.Resources.EmptyTruckBig128;
            this.pbTruckOutWeight.Location = new System.Drawing.Point(33, 393);
            this.pbTruckOutWeight.Name = "pbTruckOutWeight";
            this.pbTruckOutWeight.Size = new System.Drawing.Size(128, 128);
            this.pbTruckOutWeight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbTruckOutWeight.TabIndex = 20;
            this.pbTruckOutWeight.TabStop = false;
            this.MyToolTip.SetToolTip(this.pbTruckOutWeight, "Truck-out Weigh [ Ctrl + O ]");
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(0, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(201, 1);
            this.label7.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Location = new System.Drawing.Point(739, 529);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(177, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Developed By: Comdex Technology";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.Location = new System.Drawing.Point(208, 529);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(328, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "To use with the device imported by BROTHRES INTERNATIONAL.";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 548);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pbTruckOutWeight);
            this.Controls.Add(this.pbTruckInWeigh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDeviceStatus);
            this.Controls.Add(this.pbDeviceStatus);
            this.Controls.Add(this.pbDisconnect);
            this.Controls.Add(this.pbConnect);
            this.Controls.Add(this.cmbPortName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.kryptonHeader1);
            this.Controls.Add(this.MyStatusStrip);
            this.Controls.Add(this.MyMenuStrip);
            this.MainMenuStrip = this.MyMenuStrip;
            this.MinimumSize = new System.Drawing.Size(747, 586);
            this.Name = "frmMain";
            this.Text = "QScale";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MyMenuStrip.ResumeLayout(false);
            this.MyMenuStrip.PerformLayout();
            this.MyStatusStrip.ResumeLayout(false);
            this.MyStatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeviceStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbConnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDisconnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTruckInWeigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTruckOutWeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MyMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuProgram;
        private System.Windows.Forms.ToolStripMenuItem menuMasterSetup;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStripMenuItem submenuLogIn;
        private System.Windows.Forms.ToolStripMenuItem submenuLogOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem submenuChangePassword;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem submenuExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem submenuCompanyInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem submenuUsers;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem submenuPermissions;
        private System.Windows.Forms.ToolStripMenuItem menuUtility;
        private System.Windows.Forms.ToolStripMenuItem submenuErrorLogs;
        private System.Windows.Forms.StatusStrip MyStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabelLoginStatus;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabelDate;
        private System.Windows.Forms.ToolStripMenuItem submenuDatabaseConfiguration;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem submenuClients;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem submenuMeasurementUnit;
        private System.Windows.Forms.ToolStripMenuItem submenuAddOperator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem submenuOperatorList;
        private System.Windows.Forms.ToolStripMenuItem submenuAddClient;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem submenuClientList;
        private System.Windows.Forms.ToolStripMenuItem menuWeight;
        private System.Windows.Forms.ToolStripMenuItem submenuTruckInWeight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem submenuTruckOutWeight;
        private System.Windows.Forms.ComboBox cmbPortName;
        private System.Windows.Forms.PictureBox pbDeviceStatus;
        private System.Windows.Forms.ToolStripMenuItem menuMyUtilities;
        private System.Windows.Forms.ToolStripMenuItem submenuAssemblyUtility;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripMenuItem submenuEventMaker;
        private System.Windows.Forms.ToolStripMenuItem submenuTruckInHistory;
        private System.Windows.Forms.ToolStripMenuItem submenuTruckOutHistory;
        private System.Windows.Forms.PictureBox pbConnect;
        private System.Windows.Forms.PictureBox pbDisconnect;
        private System.Windows.Forms.Label lblDeviceStatus;
        private System.IO.Ports.SerialPort ComPort;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pbTruckInWeigh;
        private System.Windows.Forms.PictureBox pbTruckOutWeight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip MyToolTip;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem submenuAboutUs;
        private System.Windows.Forms.Label label9;
    }
}

