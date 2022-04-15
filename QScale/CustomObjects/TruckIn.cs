using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
//using sCommonLib;
using sCommonLib.Exceptions;
using System.ComponentModel;

namespace CustomObjects
{
    public class TruckIn : ObjectBase
    {

        #region PrivateVariables
        private int? pTruckInId;
        private Client pClientDetails = new Client(); //null;
        private DateTime pTruckInDate;
        private DateTime pTruckInTime;
        private decimal pTruckInWeight;
        private decimal pTruckInTare;
        private UserDetails pUserDetail = new UserDetails();
        private string pChallanNo;
        private string pMaterialDescription;
        private string pQuantity;
        private string pDriverName;
        private string pTruckNo;
        private string pProductName;
        private string pConnectionString;
        #endregion

        #region PublicProperties
        public int? TruckInId
        {
            get { return pTruckInId; }
            set
            {
                if (!value.Equals(pTruckInId))
                {
                    pTruckInId = value;
                    PropertyHasChanged("TruckInId");
                }
            }
        }

        public Client ClientDetails
        {
            get { return pClientDetails; }
            set
            {
                if (!value.Equals(pClientDetails))
                {
                    pClientDetails = value;
                    PropertyHasChanged("ClientDetails");
                }
            }
        }

        public DateTime TruckInDate
        {
            get { return pTruckInDate; }
            set
            {
                if (!value.Equals(pTruckInDate))
                {
                    pTruckInDate = value;
                    PropertyHasChanged("TruckInDate");
                }
            }
        }

        public DateTime TruckInTime
        {
            get { return pTruckInTime; }
            set
            {
                if (!value.Equals(pTruckInTime))
                {
                    pTruckInTime = value;
                    PropertyHasChanged("TruckInTime");
                }
            }
        }

        public decimal TruckInWeight
        {
            get { return pTruckInWeight; }
            set
            {
                if (!value.Equals(pTruckInWeight))
                {
                    pTruckInWeight = value;
                    PropertyHasChanged("TruckInWeight");
                }
            }
        }

        public decimal TruckInTare
        {
            get { return pTruckInTare; }
            set
            {
                if (!value.Equals(pTruckInTare))
                {
                    pTruckInTare = value;
                    PropertyHasChanged("TruckInTare");
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

        public string ChallanNo
        {
            get { return pChallanNo; }
            set
            {
                if (!value.Equals(pChallanNo))
                {
                    pChallanNo = value;
                    PropertyHasChanged("ChallanNo");
                }
            }
        }

        public string MaterialDescription
        {
            get { return pMaterialDescription; }
            set
            {
                if (!value.Equals(pMaterialDescription))
                {
                    pMaterialDescription = value;
                    PropertyHasChanged("MaterialDescription");
                }
            }
        }

        public string Quantity
        {
            get { return pQuantity; }
            set
            {
                if (!value.Equals(pQuantity))
                {
                    pQuantity = value;
                    PropertyHasChanged("Quantity");
                }
            }
        }

        public string DriverName
        {
            get { return pDriverName; }
            set
            {
                if (!value.Equals(pDriverName))
                {
                    pDriverName = value;
                    PropertyHasChanged("DriverName");
                }
            }
        }

        public string TruckNo
        {
            get { return pTruckNo; }
            set
            {
                if (!value.Equals(pTruckNo))
                {
                    pTruckNo = value;
                    PropertyHasChanged("TruckNo");
                }
            }
        }

        public string ProductName
        {
            get { return pProductName; }
            set
            {
                if (!value.Equals(pProductName))
                {
                    pProductName = value;
                    PropertyHasChanged("ProductName");
                }
            }
        }
        #endregion

        #region Constructors
        public TruckIn()
        {
        }

        public TruckIn(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }
        #endregion

        #region Save Entity
        public static TruckIn SaveEntity(TruckIn truckin)
        {
            if (truckin.IsNew)
            {
                return TruckIn.CreateEntity(truckin);
            }
            else
            {
                return TruckIn.UpdateEntity(truckin);
            }
        }

        private static TruckIn CreateEntity(TruckIn truckin)
        {
            OleDbConnection Connection = new OleDbConnection(truckin.pConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand();
            cmdCommand.Connection = Connection;

            OleDbTransaction transaction = null;
            try
            {
                if (truckin.pClientDetails==null)
                {
                    throw new ExceptionWithoutControl("Client", "Information Invalid", "Select a client.");
                }

                if (string.IsNullOrEmpty(truckin.pTruckNo))
                {
                    throw new ExceptionWithControl("Truck In", "Information Required", "Enter truck no.", "TruckNo");
                }

                Connection.Open();
                transaction = Connection.BeginTransaction();
                cmdCommand.Transaction = transaction;
                SqlFunctionUtilityForAccess SqlFunction = new SqlFunctionUtilityForAccess(cmdCommand);

                SqlFunction.InsertData("INSERT INTO tblTruckIn(ClientId, TruckInDate, TruckInTime, TruckInWeight, TruckInTare, UserId, ChallanNo, MaterialDescription, Quantity, DriverName, TruckNo, ProductName) VALUES(" + truckin.pClientDetails.ClientId + ",#" + truckin.pTruckInDate.ToString("dd MMM yyyy") + "#,#" + truckin.pTruckInTime.ToString("hh:mm:ss tt") + "#," + truckin.pTruckInWeight + "," + truckin.pTruckInTare + "," + truckin.pUserDetail.UserId + ",'" + truckin.pChallanNo + "','" + truckin.pMaterialDescription + "','" + truckin.pQuantity + "','" + truckin.pDriverName + "','" + truckin.pTruckNo + "','" + truckin.pProductName + "')");
                truckin.TruckInId = SqlFunction.GetLastPrimaryKeyValue("SELECT MAX(TruckInId) AS LastId FROM tblTruckIn ");

                transaction.Commit();
                Connection.Close();
                truckin.MarkOld();
                return truckin;
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

        private static TruckIn UpdateEntity(TruckIn truckin)
        {
            OleDbConnection Connection = new OleDbConnection(truckin.pConnectionString);
            OleDbCommand cmdUpdate = new OleDbCommand("UPDATE tblTruckIn SET ClientId=" + truckin.pClientDetails.ClientId + ", TruckInDate=#" + truckin.pTruckInDate.ToString("dd MMM yyyy") + "#, TruckInTime=#" + truckin.pTruckInTime.ToString("hh:mm:ss tt") + "#, TruckInWeight=" + truckin.pTruckInWeight + ", TruckInTare="+ truckin.pTruckInTare +", UserId=" + truckin.pUserDetail.UserId + ", ChallanNo='" + truckin.pChallanNo + "', MaterialDescription='" + truckin.pMaterialDescription + "', Quantity='" + truckin.pQuantity + "', DriverName='" + truckin.pDriverName + "', TruckNo='" + truckin.pTruckNo + "', ProductName='"+ truckin.pProductName +"'  WHERE TruckInId=" + truckin.pTruckInId + "", Connection);
            OleDbTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                cmdUpdate.Transaction = transaction;
                cmdUpdate.ExecuteNonQuery();
                transaction.Commit();
                Connection.Close();
                truckin.MarkClean();
                return truckin;
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

        #endregion

        #region Read Entity

        public static TruckIn FillEntity(OleDbDataReader Reader,OleDbConnection Connection)
        {
            TruckIn truckin = new TruckIn();
            truckin.pTruckInId = (int)Reader["TruckInId"];
            truckin.pClientDetails =Client.GetEntity( (int)Reader["ClientId"],Connection);
            truckin.pTruckInDate = (DateTime)Reader["TruckInDate"];
            truckin.pTruckInTime = (DateTime)Reader["TruckInTime"];
            truckin.pTruckInWeight = (decimal)Reader["TruckInWeight"];
            truckin.pTruckInTare = (decimal)Reader["TruckInTare"];
            truckin.pUserDetail = UserDetails.GetUserEntityOnly( (int)Reader["UserId"],Connection);
            truckin.pChallanNo = Reader["ChallanNo"].ToString();
            truckin.pMaterialDescription = Reader["MaterialDescription"].ToString();
            truckin.pQuantity = (string)Reader["Quantity"];
            truckin.pDriverName = Reader["DriverName"].ToString();
            truckin.pTruckNo = Reader["TruckNo"].ToString();
            truckin.pProductName = Reader["ProductName"].ToString();

            truckin.MarkOld();
            return truckin;
        }

        public static TruckIn GetEntity(int truckinid, string ConnectionString)
        {
            TruckIn truckin = null;
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                Connection.Open();
                truckin = TruckIn.GetEntity(truckinid, Connection);
                if(truckin != null)
                {
                    truckin.pConnectionString = ConnectionString;
                }
                Connection.Close();
            }
            return truckin;
        }

        public static TruckIn GetEntity(int truckinid, OleDbConnection Connection)
        {
            TruckIn truckin = null;

                string sqlSelect = "SELECT TruckInId, ClientId, TruckInDate, TruckInTime, TruckInWeight, TruckInTare, UserId, ChallanNo, MaterialDescription, Quantity, DriverName, TruckNo, ProductName FROM tblTruckIn WHERE TruckInId=" + truckinid + "";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {                   
                    OleDbDataReader Reader = cmd.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        Reader.Read();
                        truckin = FillEntity(Reader,Connection);
                        //Object returned from this method does not require ConnectionString.
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
           
            return truckin;
        }

        public static List<TruckIn> GetEntityList(string ConnectionString)
        {
            List<TruckIn> TruckInList = new List<TruckIn>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  TruckInId, ClientId, TruckInDate, TruckInTime, TruckInWeight, TruckInTare, UserId, ChallanNo, MaterialDescription, Quantity, DriverName, TruckNo, ProductName FROM tblTruckIn ORDER BY TruckInId";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (Reader.Read())
                    {
                        TruckIn truckin = FillEntity(Reader,Connection);
                        truckin.pConnectionString = ConnectionString;
                        TruckInList.Add(truckin);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return TruckInList;
        }

        /// <summary>
        /// Returns TruckIn list which are waiting for going out.
        /// These have been enlisted in tblTruckIn, but not in tblTruckOut table
        /// </summary>
        /// <param name="ConnectionString">ConnectionString</param>
        /// <returns>BindingList<TruckIn></returns>
        public static BindingList<TruckIn> GetPendingTruckList(string ConnectionString)
        {
            BindingList<TruckIn> TruckInList = new BindingList<TruckIn>();
            TruckIn EmptyRecord = new TruckIn(); EmptyRecord.pTruckNo = string.Empty;
            TruckInList.Add(EmptyRecord);
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  TruckInId, ClientId, TruckInDate, TruckInTime, TruckInWeight, TruckInTare, UserId, ChallanNo, MaterialDescription, Quantity, DriverName, TruckNo, ProductName FROM tblTruckIn WHERE TruckInId NOT IN(SELECT TruckInId from tblTruckOut) ORDER BY TruckInId";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (Reader.Read())
                    {
                        TruckIn truckin = FillEntity(Reader, Connection);
                        truckin.pConnectionString = ConnectionString;
                        TruckInList.Add(truckin);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return TruckInList;
        }
        #endregion

        #region Delete Entity
        public void DeleteEntity()
        {
            using (OleDbConnection Connection = new OleDbConnection(pConnectionString))
            {
                Connection.Open();
                string sqlDelete = "DELETE TruckInId, ClientDetails, TruckInDate, TruckInTime, TruckInWeight, TruckInTare, UserDetail, ChallanNo, MaterialDescription, Quantity, DriverName, TruckNo, ProductName FROM tblTruckIn WHERE TruckInId=" + this.pTruckInId + "";
                OleDbCommand cmdDelete = new OleDbCommand(sqlDelete, Connection);
                Connection.Close();
            }
        }

        #endregion

        #region Utility
        public override string ToString()
        {
            return pTruckInId.ToString();
        }
        public void SetConnectionString(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }


        public static DataSet GetDistinctValues(string ConnectionString)
        {
            DataSet dsValues = new DataSet();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                
                OleDbDataAdapter daDescription = new OleDbDataAdapter("select distinct MaterialDescription from tblTruckIn order by MaterialDescription asc", Connection);
                OleDbDataAdapter daTruckNo = new OleDbDataAdapter("select distinct TruckNo from tblTruckIn order by TruckNo asc", Connection);
                OleDbDataAdapter daDriverName = new OleDbDataAdapter("select distinct DriverName from tblTruckIn order by DriverName asc", Connection);

                Connection.Open();
                daDescription.Fill(dsValues, "Description");
                daTruckNo.Fill(dsValues, "TruckNo");
                daDriverName.Fill(dsValues, "DriverName");
                Connection.Close();
              
            }
            return dsValues;
        }

        #endregion

    }
}
