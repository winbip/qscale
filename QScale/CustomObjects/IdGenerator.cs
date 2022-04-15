using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace CustomObjects
{
    public class IdGenerator
    {

        public static int CreateNewId(string TableName, string ColumnName, string ConnectionString)
        {
            try
            {
                using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
                {
                    string sqlLastId = "select Max(" + ColumnName + ") as LastId from " + TableName + "";
                    OleDbCommand cmdLastId = new OleDbCommand(sqlLastId, Connection);
                    Connection.Open();
                    object objLastId = cmdLastId.ExecuteScalar();
                    Connection.Close();

                    //If database does not have any row, ExecuteScalar() will return DBNull.Value.
                    if (objLastId == DBNull.Value)
                    {
                        //Set ID=1
                        return 1;
                    }
                    else
                    {
                        //IncreamentId by 1
                        int intLastId = (int)objLastId;
                        return ++intLastId;
                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }


        public static int CreateNewId(string TableName, string ColumnName, OleDbConnection Connection, OleDbTransaction transaction)
        {
            try
            {
                string sqlLastId = "select Max(" + ColumnName + ") as LastId from " + TableName + "";
                OleDbCommand cmdLastId = new OleDbCommand(sqlLastId, Connection);
                cmdLastId.Transaction = transaction;
                object objLastId = cmdLastId.ExecuteScalar();

                //If database does not have any row, ExecuteScalar() will return DBNull.Value.
                if (objLastId == DBNull.Value)
                {
                    //Set ID=1
                    return 1;
                }
                else
                {
                    //IncreamentId by 1
                    int intLastId = (int)objLastId;
                    return ++intLastId;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }
    }
}
