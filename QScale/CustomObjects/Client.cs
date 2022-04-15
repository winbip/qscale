using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using sCommonLib;
using sCommonLib.Exceptions;

namespace CustomObjects
{
    public class Client : ObjectBase
    {

        #region PrivateVariables
        private int pClientId;
        //private string pClientCode;
        //private ClientType pClientTypeDetails=new ClientType();
        private string pClientName;
        private string pCompanyName;
        private string pAddress;
        private string pMobileNo;
        //private string pFaxNo;
        //private string pEmailAddress;
        private string pConnectionString;
        #endregion

        #region PublicProperties
        public int ClientId
        {
            get { return pClientId; }
            set
            {
                if (!value.Equals(pClientId))
                {
                    pClientId = value;
                    PropertyHasChanged("ClientId");
                }
            }
        }

        //public string ClientCode
        //{
        //    get { return pClientCode; }
        //    set
        //    {
        //        if (!value.Equals(pClientCode))
        //        {
        //            pClientCode = value;
        //            PropertyHasChanged("ClientCode");
        //        }
        //    }
        //}

        //public ClientType ClientTypeDetails
        //{
        //    get { return pClientTypeDetails; }
        //    set
        //    {
        //        if (!value.Equals(pClientTypeDetails))
        //        {
        //            pClientTypeDetails = value;
        //            PropertyHasChanged("ClientTypeDetails");
        //        }
        //    }
        //}

        public string ClientName
        {
            get { return pClientName; }
            set
            {
                if (!value.Equals(pClientName))
                {
                    pClientName = value;
                    PropertyHasChanged("ClientName");
                }
            }
        }

        public string CompanyName
        {
            get { return pCompanyName; }
            set
            {
                if (!value.Equals(pCompanyName))
                {
                    pCompanyName = value;
                    PropertyHasChanged("CompanyName");
                }
            }
        }

        public string Address
        {
            get { return pAddress; }
            set
            {
                if (!value.Equals(pAddress))
                {
                    pAddress = value;
                    PropertyHasChanged("Address");
                }
            }
        }

        public string MobileNo
        {
            get { return pMobileNo; }
            set
            {
                if (!value.Equals(pMobileNo))
                {
                    pMobileNo = value;
                    PropertyHasChanged("MobileNo");
                }
            }
        }

        //public string FaxNo
        //{
        //    get { return pFaxNo; }
        //    set
        //    {
        //        if (!value.Equals(pFaxNo))
        //        {
        //            pFaxNo = value;
        //            PropertyHasChanged("FaxNo");
        //        }
        //    }
        //}

        //public string EmailAddress
        //{
        //    get { return pEmailAddress; }
        //    set
        //    {
        //        if (!value.Equals(pEmailAddress))
        //        {
        //            pEmailAddress = value;
        //            PropertyHasChanged("EmailAddress");
        //        }
        //    }
        //}

        #endregion

        #region Constructors
        public Client()
        {
        }

        public Client(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }
        #endregion

        #region Save Entity
        public static Client SaveEntity(Client client)
        {
            if (client.IsNew)
            {
                return Client.CreateEntity(client);
            }
            else
            {
                return Client.UpdateEntity(client);
            }
        }

        private static Client CreateEntity(Client client)
        {
            OleDbConnection Connection = new OleDbConnection(client.pConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand(); cmdCommand.Connection = Connection;
            OleDbTransaction transaction = null;
            try
            {
                ////Client Code can not be empty.
                //if (string.IsNullOrEmpty(client.ClientCode))
                //{
                //    throw new ExceptionWithControl("Client", "Information Invalid", "Enter client code.", "ClientCode");
                //}

                ////ClientTypeId can not be zero. Because ClientTypeId=0 is a default empty ClientType.
                //if (client.ClientTypeDetails.ClientTypeId==0)
                //{
                //    throw new ExceptionWithControl("Client", "Information Invalid", "Enter Client Type.", "ClientType");
                //}

                //ClientName can not be empty. Duplicate allowed.
                if (string.IsNullOrEmpty(client.ClientName))
                {
                    throw new ExceptionWithControl("Client", "Information Invalid", "Enter Client Name.", "ClientName");
                }

                //CompanyName can not be empty. Duplicate allowed.
                if (string.IsNullOrEmpty(client.CompanyName))
                {
                    throw new ExceptionWithControl("Client", "Information Invalid", "Enter Commpany Name.", "CompanyName");
                }

                Connection.Open();
                transaction = Connection.BeginTransaction();
                cmdCommand.Transaction = transaction;
                SqlFunctionUtilityForAccess SqlFunction = new SqlFunctionUtilityForAccess(cmdCommand);
                
                ////ClientCode can not be duplicate.
                //if (SqlFunction.IsFoundStringTypeValue("Select ClientCode from tblClient where ClientCode='"+ client.pClientCode +"'"))
                //{
                //    throw new ExceptionWithControl("Client", "Duplicate Value", "This client code already in use. Try different code.", "ClientCode");
                //}

                SqlFunction.InsertData("INSERT INTO tblClient(ClientName, CompanyName, Address, MobileNo) VALUES('" + client.pClientName + "','" + client.pCompanyName + "','" + client.pAddress + "','" + client.pMobileNo + "')");

                client.pClientId = SqlFunction.GetLastPrimaryKeyValue("SELECT MAX(ClientId) AS LastId FROM tblClient "); 
                transaction.Commit();
                Connection.Close();
                client.MarkOld();
                return client;
            }
            catch (ExceptionWithControl EWC)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw EWC;
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

        /// <summary>
        /// This method is not completed yet.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private static Client UpdateEntity(Client client) //TODO: Complete this method.
        {
            OleDbConnection Connection = new OleDbConnection(client.pConnectionString);
            OleDbCommand cmdUpdate = new OleDbCommand("UPDATE tblClient SET ClientName='" + client.pClientName + "', CompanyName='" + client.pCompanyName + "', Address='" + client.pAddress + "', MobileNo='" + client.pMobileNo + "'  WHERE ClientId=" + client.pClientId + "", Connection);
            OleDbTransaction trans = null;
            try
            {
                Connection.Open();
                trans = Connection.BeginTransaction();
                cmdUpdate.Transaction = trans;
                cmdUpdate.ExecuteNonQuery();
                trans.Commit();
                Connection.Close();
                client.MarkClean();
                return client;
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

        public static Client FillEntity(OleDbDataReader Reader,OleDbConnection Connection)
        {
            Client client = new Client();
            client.pClientId = (int)Reader["ClientId"];
            client.pClientName = Reader["ClientName"].ToString();
            client.pCompanyName = Reader["CompanyName"].ToString();
            client.pAddress = Reader["Address"].ToString();
            client.pMobileNo = Reader["MobileNo"].ToString();
            client.MarkOld();
            return client;
        }

        /// <summary>
        /// Return Client with all fields. It has 2 overloads. ClientId and ConString/Connection
        /// </summary>
        /// <param name="clientid"></param>
        /// <param name="ConnectionString"></param>
        /// <returns>Client</returns>
        public static Client GetEntity(int clientid, string ConnectionString)
        {
            Client client = null;
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                Connection.Open();
                client = Client.GetEntity(clientid, Connection);
                client.pConnectionString = ConnectionString;
                Connection.Close();
            }
            return client;
        }

        public static Client GetEntity(int clientid, OleDbConnection Connection)
        {
            Client client = null;

                string sqlSelect = "SELECT ClientId, ClientName, CompanyName, Address, MobileNo FROM tblClient WHERE ClientId=" + clientid + "";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    
                    OleDbDataReader Reader = cmd.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        Reader.Read();
                        client = FillEntity(Reader, Connection);
                        //Object returned from this method does not require ConnectionString.
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                    
                }
            
            return client;
        }

        public static List<Client> GetEntityList(string ConnectionString)
        {
            List<Client> ClientList = new List<Client>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  ClientId, ClientName, CompanyName, Address, MobileNo FROM tblClient Where ClientId>0 ORDER BY CompanyName asc";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        Client client = FillEntity(Reader,Connection);
                        client.pConnectionString = ConnectionString;
                        ClientList.Add(client);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                    Connection.Close();
                }
            }
            return ClientList;
        }

        #endregion

        #region Delete Entity
        public void DeleteEntity()
        {
            using (OleDbConnection Connection = new OleDbConnection(pConnectionString))
            {
                Connection.Open();
                string sqlDelete = "DELETE ClientId, ClientName, CompanyName, Address, MobileNo FROM tblClient WHERE ClientId=" + this.pClientId + "";
                OleDbCommand cmdDelete = new OleDbCommand(sqlDelete, Connection);
                Connection.Close();
            }
        }

        #endregion

        #region Utility
        public override string ToString()
        {
            return ".......";
        }
        public void SetConnectionString(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }

        #endregion

    }
}