using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.ComponentModel;
using sCommonLib.Exceptions;

namespace CustomObjects
{
    public class TruckOut : ObjectBase
    {

        #region PrivateVariables
        private int? pTruckOutId;
        private DateTime pTruckOutDate;
        private DateTime pTruckOutTime;
        private decimal pTruckOutWeight;
        private decimal pTruckOutTare;

        private TruckIn pTruckInDetails=null;
        private UserDetails pUserDetail=new UserDetails();
        private string pConnectionString;
        #endregion

        #region PublicProperties
        public int? TruckOutId
        {
            get { return pTruckOutId; }
            set
            {
                if (!value.Equals(pTruckOutId))
                {
                    pTruckOutId = value;
                    PropertyHasChanged("TruckOutId");
                }
            }
        }

        public DateTime TruckOutDate
        {
            get { return pTruckOutDate; }
            set
            {
                if (!value.Equals(pTruckOutDate))
                {
                    pTruckOutDate = value;
                    PropertyHasChanged("TruckOutDate");
                }
            }
        }

        public DateTime TruckOutTime
        {
            get { return pTruckOutTime; }
            set
            {
                if (!value.Equals(pTruckOutTime))
                {
                    pTruckOutTime = value;
                    PropertyHasChanged("TruckOutTime");
                }
            }
        }

        public decimal TruckOutWeight
        {
            get { return pTruckOutWeight; }
            set
            {
                if (!value.Equals(pTruckOutWeight))
                {
                    pTruckOutWeight = value;
                    PropertyHasChanged("TruckOutWeight");
                }
            }
        }

        public decimal TruckOutTare
        {
            get { return pTruckOutTare; }
            set
            {
                if (!value.Equals(pTruckOutTare))
                {
                    pTruckOutTare = value;
                    PropertyHasChanged("TruckOutTare");
                }
            }
        }

        public TruckIn TruckInDetails
        {
            get { return pTruckInDetails; }
            set
            {
                if (!value.Equals(pTruckInDetails))
                {
                    pTruckInDetails = value;
                    PropertyHasChanged("TruckInDetails");
                }
            }
        }

        public UserDetails UserDetail
        {
            get { return pUserDetail; }
            set
            {
                if (!value.Equals(pUserDetail))
                {
                    pUserDetail = value;
                    PropertyHasChanged("UserDetail");
                }
            }
        }


        public decimal NetWeight
        {
            get { return pTruckInDetails.TruckInWeight - pTruckOutWeight; }
        }
        #endregion

        #region Constructors
        public TruckOut()
        {
        }

        public TruckOut(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }
        #endregion

        #region Save Entity
        public static TruckOut SaveEntity(TruckOut truckout)
        {
            if (truckout.IsNew)
            {
                return TruckOut.CreateEntity(truckout);
            }
            else
            {
                return TruckOut.UpdateEntity(truckout);
            }
        }

        private static TruckOut CreateEntity(TruckOut truckout)
        {
            OleDbConnection Connection = new OleDbConnection(truckout.pConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand();
            cmdCommand.Connection = Connection;

            OleDbTransaction transaction = null;
            try
            {
                if (truckout.pTruckInDetails==null)
                {
                    throw new ExceptionWithoutControl("Error", "Information Invalid", "Select Truck No.");
                }

                Connection.Open();
                transaction = Connection.BeginTransaction();
                cmdCommand.Transaction = transaction;
                SqlFunctionUtilityForAccess SqlFunction = new SqlFunctionUtilityForAccess(cmdCommand);

                SqlFunction.InsertData("INSERT INTO tblTruckOut(TruckOutDate, TruckOutTime, TruckOutWeight, TruckOutTare, TruckInId, UserId) VALUES(#" + truckout.pTruckOutDate.ToString("dd MMM yyyy") + "#,#" + truckout.pTruckOutTime.ToString("hh:mm:ss tt") + "#," + truckout.pTruckOutWeight + "," + truckout.pTruckOutTare + "," + truckout.pTruckInDetails.TruckInId + "," + truckout.pUserDetail.UserId + ")");
                truckout.TruckOutId = SqlFunction.GetLastPrimaryKeyValue("SELECT MAX(TruckOutId) AS LastId FROM tblTruckOut");             
               
                transaction.Commit();
                Connection.Close();
                truckout.MarkOld();
                return truckout;
            }
            catch (ExceptionWithoutControl WithoutControlException)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw WithoutControlException;
            }
            catch (ExceptionWithControl WithControlException)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw WithControlException;
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw ex;
            }
        }

        private static TruckOut UpdateEntity(TruckOut truckout)
        {
            OleDbConnection Connection = new OleDbConnection(truckout.pConnectionString);
            OleDbCommand cmdUpdate = new OleDbCommand("UPDATE tblTruckOut SET TruckOutDate=#" + truckout.pTruckOutDate.ToString("dd MMM yyyy") + "#, TruckOutTime=#" + truckout.pTruckOutTime.ToString("dd MMM yyyy") + "#, TruckOutWeight=" + truckout.pTruckOutWeight + ", TruckOutTare= "+ truckout.pTruckOutTare + "  WHERE TruckOutId=" + truckout.pTruckOutId + "", Connection);
            OleDbTransaction trans = null;
            try
            {
                Connection.Open();
                trans = Connection.BeginTransaction();
                cmdUpdate.Transaction = trans;
                cmdUpdate.ExecuteNonQuery();
                trans.Commit();
                Connection.Close();
                truckout.MarkClean();
                return truckout;
            }
            catch (Exception ex)
            {
                if (trans != null)
                {
                    trans.Rollback();
                }
                throw ex;
            }
        }

        #endregion

        #region Read Entity

        public static TruckOut FillEntity(OleDbDataReader Reader,OleDbConnection Connection)
        {
            TruckOut truckout = new TruckOut();
            truckout.pTruckOutId = (int)Reader["TruckOutId"];
            truckout.pTruckOutDate = (DateTime)Reader["TruckOutDate"];
            truckout.pTruckOutTime = (DateTime)Reader["TruckOutTime"];
            truckout.pTruckOutWeight = (decimal)Reader["TruckOutWeight"];
            truckout.pTruckOutTare = (decimal)Reader["TruckOutTare"];
            truckout.pTruckInDetails = TruckIn.GetEntity((int)Reader["TruckInId"], Connection);
            truckout.pUserDetail =UserDetails.GetUserEntityOnly( (int)Reader["UserId"],Connection);
            truckout.MarkOld();
            return truckout;
        }

        public static TruckOut GetEntity(int truckoutid, string ConnectionString)
        {
            TruckOut truckout = null;
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT TruckOutId, TruckOutDate, TruckOutTime, TruckOutWeight, TruckOutTare, TruckInId, UserId FROM tblTruckOut WHERE TruckOutId=" + truckoutid + "";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        Reader.Read();
                        truckout = FillEntity(Reader,Connection);
                        truckout.pConnectionString = ConnectionString;
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                    Connection.Close();
                }
            }
            return truckout;
        }

        public static List<TruckOut> GetEntityList(string ConnectionString)
        {
            List<TruckOut> TruckOutList = new List<TruckOut>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  TruckOutId, TruckOutDate, TruckOutTime, TruckOutWeight, TruckOutTare, TruckInId, UserId FROM tblTruckOut ORDER BY TruckOutId asc";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        TruckOut truckout = FillEntity(Reader,Connection);
                        truckout.pConnectionString = ConnectionString;
                        TruckOutList.Add(truckout);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                    Connection.Close();
                }
            }
            return TruckOutList;
        }

        #endregion

        #region Delete Entity
        public void DeleteEntity()
        {
            using (OleDbConnection Connection = new OleDbConnection(pConnectionString))
            {
                Connection.Open();
                string sqlDelete = "DELETE TruckOutId, TruckOutDate, TruckOutTime, TruckOutWeight, TruckOutTare, TruckInId, UserId FROM tblTruckOut WHERE TruckOutId=" + this.pTruckOutId + "";
                OleDbCommand cmdDelete = new OleDbCommand(sqlDelete, Connection);
                Connection.Close();
            }
        }

        #endregion

        #region Utility
        public override string ToString()
        {
            return pTruckOutId.ToString();
        }
        public void SetConnectionString(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }

        #endregion

    }
}
