using sCommonLib;
using sCommonLib.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace QScaleNew.WeightMenuForms
{
    public partial class frmDeleteWeightHistory : Form
    {
        public frmDeleteWeightHistory()
        {
            InitializeComponent();
            btnDelete.Click += DeleteData;
        }

        private void DeleteData(object sender, EventArgs e)
        {
            try
            {

                string strStartId = txtStartId.Text.Trim();
                if (string.IsNullOrEmpty(strStartId))
                {
                    throw new UserException("Delete History", "Invalid input", "Enter starting ID.", txtStartId);
                }

                int StartId;
                if (!int.TryParse(strStartId, out StartId))
                {
                    throw new UserException("Delete History", "Invalid input", "Starting ID is not valid.", txtStartId);
                }


                string strEndId = txtEndId.Text.Trim();
                if (string.IsNullOrEmpty(strEndId))
                {
                    throw new UserException("Delete History", "Invalid input", "Enter ending ID.", txtStartId);
                }

                int EndId;
                if (!int.TryParse(strEndId, out EndId))
                {
                    throw new UserException("Delete History", "Invalid input", "Ending ID is not valid.", txtEndId);
                }

                var connection = new OleDbConnection(GlobalVariables.ConnectionString);
                string qry = "SELECT COUNT(TruckInId) FROM tblTruckIn Where (TruckInId between "+ StartId +" and "+ EndId +") " +
                    "and (TruckInId IN(select TruckInId from tblTruckOut))";

                string count = "";
                using(OleDbCommand command = new OleDbCommand(qry, connection))
                {
                    connection.Open();
                    count = command.ExecuteScalar().ToString();
                    connection.Close();
                }

                var msg = new sCommonLib.Messages.ConfirmationMessage("Delete Weight History",
                    "Delete Weight History", "Are you sure to delete "+ count +" records?");

                   if (CustomMessageBox.ShowConfirmationMessage(msg) != DialogResult.Yes)
                   {
                       
                        return;
                   }

                using (OleDbCommand command = new OleDbCommand(qry, connection))
                {
                    connection.Open();
                    command.CommandText = "DELETE * FROM tblTruckIn Where (TruckInId between " + StartId + " and " + EndId + ") " +
                    "and (TruckInId IN(select TruckInId from tblTruckOut))";
                    command.ExecuteNonQuery();
                    command.CommandText = "DELETE * FROM tblTruckOut Where (TruckInId between " + StartId + " and " + EndId + ") " + "";
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                MessageBox.Show("Deleted successfully.");


                ////-->Create Database 
                //if (chkCreateNewDatabase.Checked)
                //{

                //    string sourceFileName = Application.StartupPath + "\\MainDatabase.mdb";
                //    string destFileName = databaseDirectory + "\\" + ConnectionStringGenerator.DatabasePrefix + OperatingYear.ToString() + ".mdb";

                //    if (!File.Exists(sourceFileName))
                //    {
                //        MessageBox.Show("Source file not found."); return;
                //    }

                //    if (File.Exists(destFileName))
                //    {
                //        MessageBox.Show("Destination file already exists."); return;
                //    }
                //}
                ////<--Create Database 
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
    }


    
}
