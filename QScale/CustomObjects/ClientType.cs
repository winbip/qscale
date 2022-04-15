using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace CustomObjects
{
    public class ClientType : ObjectBase
    {

        #region PrivateVariables
        private int pClientTypeId;
        private string pClientTypeName;
        private string pConnectionString;
        #endregion

        #region PublicProperties
        public int ClientTypeId
        {
            get { return pClientTypeId; }
            set
            {
                if (!value.Equals(pClientTypeId))
                {
                    pClientTypeId = value;
                    PropertyHasChanged("ClientTypeId");
                }
            }
        }

        public string ClientTypeName
        {
            get { return pClientTypeName; }
            set
            {
                if (!value.Equals(pClientTypeName))
                {
                    pClientTypeName = value;
                    PropertyHasChanged("ClientTypeName");
                }
            }
        }

        #endregion

        #region Constructors
        public ClientType()
        {
        }

        public ClientType(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }
        #endregion

        #region Save Entity
        public static ClientType SaveEntity(ClientType clienttype)
        {
            if (clienttype.IsNew)
            {
                return ClientType.CreateEntity(clienttype);
            }
            else
            {
                return ClientType.UpdateEntity(clienttype);
            }
        }

        private static ClientType CreateEntity(ClientType clienttype)
        {
            OleDbConnection Connection = new OleDbConnection(clienttype.pConnectionString);
            OleDbCommand cmdInsert = new OleDbCommand("INSERT INTO tblClientType(ClientTypeName) VALUES('" + clienttype.pClientTypeName + "' )", Connection);
            OleDbCommand cmdLastId = new OleDbCommand("SELECT MAX(ClientTypeId) AS LastId FROM tblClientType ", Connection);
            OleDbTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                cmdInsert.Transaction = transaction;
                cmdLastId.Transaction = transaction;
                cmdInsert.ExecuteNonQuery();
                object LastId = cmdLastId.ExecuteScalar();
                clienttype.pClientTypeId = (int)LastId;
                transaction.Commit();
                Connection.Close();
                clienttype.MarkOld();
                return clienttype;
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

        private static ClientType UpdateEntity(ClientType clienttype)
        {
            OleDbConnection Connection = new OleDbConnection(clienttype.pConnectionString);
            OleDbCommand cmdUpdate = new OleDbCommand("UPDATE tblClientType SET ClientTypeName='" + clienttype.pClientTypeName + "'  WHERE ClientTypeId=" + clienttype.pClientTypeId + "", Connection);
            OleDbTransaction trans = null;
            try
            {
                Connection.Open();
                trans = Connection.BeginTransaction();
                cmdUpdate.Transaction = trans;
                cmdUpdate.ExecuteNonQuery();
                trans.Commit();
                Connection.Close();
                clienttype.MarkClean();
                return clienttype;
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

        public static ClientType FillEntity(OleDbDataReader Reader)
        {
            ClientType clienttype = new ClientType();
            clienttype.pClientTypeId = (int)Reader["ClientTypeId"];
            clienttype.pClientTypeName = Reader["ClientTypeName"].ToString();
            clienttype.MarkOld();
            return clienttype;
        }

        public static ClientType GetEntity(int clienttypeid, string ConnectionString)
        {
            ClientType clienttype = null;
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT ClientTypeId, ClientTypeName FROM tblClientType WHERE ClientTypeId=" + clienttypeid + "";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (Reader.HasRows)
                    {
                        Reader.Read();
                        clienttype = FillEntity(Reader);
                        clienttype.pConnectionString = ConnectionString;
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return clienttype;
        }

        //It is used in Client object's "FillEntity" Method.
        public static ClientType GetEntity(int clienttypeid, OleDbConnection Connection)
        {
            ClientType clienttype = null;

                string sqlSelect = "SELECT ClientTypeId, ClientTypeName FROM tblClientType WHERE ClientTypeId=" + clienttypeid + "";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    
                    OleDbDataReader Reader = cmd.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        Reader.Read();
                        clienttype = FillEntity(Reader);
                       
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
        
            return clienttype;
        }

        public static List<ClientType> GetEntityList(string ConnectionString)
        {
            List<ClientType> ClientTypeList = new List<ClientType>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  ClientTypeId, ClientTypeName FROM tblClientType ORDER BY ClientTypeName ASC";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (Reader.Read())
                    {
                        ClientType clienttype = FillEntity(Reader);
                        clienttype.pConnectionString = ConnectionString;
                        ClientTypeList.Add(clienttype);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return ClientTypeList;
        }

        #endregion

        #region Delete Entity
        public void DeleteEntity()
        {
            using (OleDbConnection Connection = new OleDbConnection(pConnectionString))
            {
                Connection.Open();
                string sqlDelete = "DELETE ClientTypeId, ClientTypeName FROM tblClientType WHERE ClientTypeId=" + this.pClientTypeId + "";
                OleDbCommand cmdDelete = new OleDbCommand(sqlDelete, Connection);
                Connection.Close();
            }
        }

        #endregion

        #region Utility
        public override string ToString()
        {
            return pClientTypeName;
        }
        public void SetConnectionString(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }

        #endregion

    }
}
