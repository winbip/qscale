using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace CustomObjects
{
    public class SqlFunctionUtilityForAccess
    {

        private OleDbCommand cmdCommand;

        public SqlFunctionUtilityForAccess(OleDbCommand CommandObject)
        {
            cmdCommand = CommandObject;
        }


        public bool IsFoundStringTypeValue(string SqlString)
        {
            cmdCommand.CommandText = SqlString;
            object SearchResult = cmdCommand.ExecuteScalar();
            if (SearchResult==null)
            {
                return false; //Not found
            }
            else
            {
                return true; //Found
            }
        }

        /// <summary>
        /// This method will perform "ExecuteScalar" with the supplied SQL string.
        /// Command object already supplied while instantiated this object.
        /// </summary>
        /// <param name="SqlString">Sql String</param>
        /// <returns>int value</returns>
        public int GetLastPrimaryKeyValue(string SqlString)
        {
            cmdCommand.CommandText = SqlString;
            object objLastValue = cmdCommand.ExecuteScalar();
            return (int)objLastValue;
        }

        /// <summary>
        /// This method will perform "ExecuteNonQuery" with the supplied SQL string.
        /// Command object already supplied while instantiated this object.
        /// </summary>
        /// <param name="SqlString">string parameter</param>
        public void InsertData(string SqlString)
        {
            cmdCommand.CommandText = SqlString;
            cmdCommand.ExecuteNonQuery();
        }
    }
}
