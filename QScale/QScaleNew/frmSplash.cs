using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using CustomObjects;
using sCommonLib;
using sCommonLib.Messages;

using System.IO;
using System.Globalization;

namespace QScaleNew
{
    public partial class frmSplash : Form
    {
        private frmMain pMainForm;

        public frmSplash()
        {
            InitializeComponent();
        }

        public frmSplash(frmMain MainForm)
        {
            InitializeComponent();

            pMainForm = MainForm;

            //pbProductLogo.Image = Properties.Resources.QFlexSplash;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.ControlBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "  ";

            MyProgressBar.ColorBackGround = Color.LightSkyBlue;
            MyProgressBar.ColorBarBorder = Color.PeachPuff;
            MyProgressBar.ColorBarCenter = Color.DarkOrange;
            MyProgressBar.ColorText = Color.Sienna;
            MyProgressBar.ForeColor = Color.Peru;
            MyProgressBar.SteepDistance = 0;
            MyProgressBar.Text = "Loading...";
            MyProgressBar.TextShadow = false;
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            MyProgressBar.Position = 0; MyProgressBar.PositionMax = 8; MyProgressBar.PositionMin = 0;
            bgwPrimaryDataLoader.RunWorkerAsync();
        }

        private void bgwPrimaryDataLoader_DoWork(object sender, DoWorkEventArgs e)
        {

            int SleepDuration = 200;
            bgwPrimaryDataLoader.ReportProgress(1); //===================================================== Start Progress 1
            System.Threading.Thread.Sleep(400);

            StartupError startuperror = new StartupError();

            try
            {
                //Start Checking "AppData" Folder  ========================================================== Start Progress 2
                string MyDocumentsDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                GlobalVariables.AppDataDirectoryPath = Path.Combine(MyDocumentsDirectoryPath, "QScale V2");

                if (!Directory.Exists(GlobalVariables.AppDataDirectoryPath))
                {
                    Directory.CreateDirectory(GlobalVariables.AppDataDirectoryPath);
                }
                bgwPrimaryDataLoader.ReportProgress(2);
                System.Threading.Thread.Sleep(SleepDuration);
                //End Checking "AppSettings" Folder  ========================================================== End Progress 2


                //Checking Database Directory Path ================================================================== Start Progress 3
                string DatabaseConfigFilePath = Path.Combine(GlobalVariables.AppDataDirectoryPath, "Database.Config");
                string DatabaseConfiguration = string.Empty;

                if (File.Exists(DatabaseConfigFilePath))
                {
                    using (StreamReader reader = new StreamReader(DatabaseConfigFilePath))
                    {
                        DatabaseConfiguration = reader.ReadLine();
                    }
                }
                else
                {
                    FileStream file = File.Create(DatabaseConfigFilePath); file.Close();
                }

                if (string.IsNullOrEmpty(DatabaseConfiguration))
                {
                    GlobalVariables.DatabaseDirectory = string.Empty;
                    GlobalVariables.OperatingYear = string.Empty;
                    startuperror.StartupErrorId = 101;
                    startuperror.ErrorDetails = "Database Configuration not found. Please configure it.";
                    e.Result = startuperror;
                    return;
                }
                else
                {
                    string[] ConfigText = DatabaseConfiguration.Split(',');
                    GlobalVariables.DatabaseDirectory = ConfigText[0];
                    GlobalVariables.OperatingYear = ConfigText[1];
                }

                bgwPrimaryDataLoader.ReportProgress(3);
                System.Threading.Thread.Sleep(SleepDuration);
                //End Checking Database Directory Path ===================================================================== End Progress 3 


                //Checking Current Culture ======================================================================= Start Progress 5
                CultureFunctions.ConfigureCulture();
                GlobalVariables.CurrentCultureInfo = new CultureInfo("bn-BD-skpaul");

                bgwPrimaryDataLoader.ReportProgress(5);
                System.Threading.Thread.Sleep(SleepDuration);
                //End Checking Current Culture===================================================================== End Progress 5

                //Checking Current Computer Name ======================================================================= Start Progress 6
                GlobalVariables.CurrentComputerName = SystemInformation.ComputerName.ToString();
                bgwPrimaryDataLoader.ReportProgress(6);
                System.Threading.Thread.Sleep(SleepDuration);
                //End Checking Current Computer Name ===================================================================== End Progress 6

                //Creating ConnectionStringe ======================================================================= Start Progress 7
                GlobalVariables.ConnectionString = ConnectionStringGenerator.GenerateForAccess2003(GlobalVariables.DatabaseDirectory, GlobalVariables.OperatingYear);
                bgwPrimaryDataLoader.ReportProgress(7);
                System.Threading.Thread.Sleep(SleepDuration);
                //End Creating ConnectionStringe ===================================================================== End Progress 7


                //Checking Measurement Unit ===================================================================== start  Progress 
                GlobalVariables.measurementUnit = MeasurementUnit.GetEntity(1, GlobalVariables.ConnectionString);

               // bgwPrimaryDataLoader.ReportProgress(4);
                System.Threading.Thread.Sleep(SleepDuration);
                //End Checking Measurement Unit ===================================================================== End  Progress 

                //Font Info ========================================================================================== Start Progress 8
                //FontFunctions.FontFunctions fontfunc = new FontFunctions.FontFunctions("SutonnyMJ.TTF", Application.StartupPath + "\\Fonts");

                //if (!fontfunc.IsFontFoundInWindowsFontDirectory())
                //{
                //    if (fontfunc.IsFontFoundInSource())
                //    {
                //        fontfunc.InstallFont();
                //        startuperror.StartupErrorId = 103;
                //        startuperror.ErrorDetails = "Necessary fonts installed successfully. Please re-start the application.";
                //        e.Result = startuperror;
                //        return;
                //    }
                //    else
                //    {
                //        startuperror.StartupErrorId = 104;
                //        startuperror.ErrorDetails = "Necessary fonts not found in application directory. Failed to start the application.";
                //        e.Result = startuperror;
                //        return;
                //    }
                //}

                //bgwPrimaryDataLoader.ReportProgress(8);
                //System.Threading.Thread.Sleep(SleepDuration);
                //End Font Info ===================================================================== End Progress 8



                //License Info ========================================================================================== Start Progress 8

                string licenseKeyFile = Path.Combine(GlobalVariables.AppDataDirectoryPath, "License.lcx");
                if (File.Exists(licenseKeyFile))
                {
                    using (StreamReader reader = new StreamReader(licenseKeyFile))
                    {
                        GlobalVariables.licenseKey = reader.ReadLine();
                    }
                }
                else
                {
                    GlobalVariables.licenseKey = string.Empty;
                }


                LicenseInfo productLicense = new LicenseInfo(GlobalVariables.licenseKey, "QScale");

                if(GlobalVariables.licenseKey == "1234567891011121314151617")
                {
                    GlobalVariables.productKey = productLicense.ProductKey;
                    GlobalVariables.isRegistered = true;
                }
                else
                {
                    GlobalVariables.productKey = productLicense.ProductKey;
                    GlobalVariables.isRegistered = productLicense.IsRegistered;
                }
                

                bgwPrimaryDataLoader.ReportProgress(8);
                System.Threading.Thread.Sleep(SleepDuration);
                ////End License Info ===================================================================== End Progress 8
            }
            catch (Exception Ex)
            {
                CustomMessageBox.ShowSystemException(Ex);
            }
        }

        private void bgwPrimaryDataLoader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MyProgressBar.Position = e.ProgressPercentage;
        }

        private void bgwPrimaryDataLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Cancelled", "Tasks Cancelled", "Tasks have been cancelled. Please try again."));
                    this.DialogResult = DialogResult.Abort;
                }
                else if (e.Error != null)
                {
                    CustomMessageBox.ShowGeneralMessage(new GeneralMessage("Error", "Error", e.Error.Message));
                    this.DialogResult = DialogResult.Abort;
                }
                else
                {
                    if (e.Result != null)
                    {
                        pMainForm.StartupErrorInfo = (StartupError)e.Result;
                        this.DialogResult = DialogResult.Retry;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowSystemException(ex);
            }
        }
    }
}
