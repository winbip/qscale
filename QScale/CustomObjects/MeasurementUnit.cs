using System;
using System.Data;
using System.Data.OleDb;

namespace CustomObjects
{
    public class MeasurementUnit : ObjectBase
    {

        #region PrivateVariables
        private int pUnitId;
        private string pUnitName;
        private string pConnectionString;
        #endregion

        #region PublicProperties
        public int UnitId
        {
            get { return pUnitId; }
            set
            {
                if (!value.Equals(pUnitId))
                {
                    pUnitId = value;
                    PropertyHasChanged("UnitId");
                }
            }
        }

        public string UnitName
        {
            get { return pUnitName; }
            set
            {
                if (!value.Equals(pUnitName))
                {
                    pUnitName = value;
                    PropertyHasChanged("UnitName");
                }
            }
        }

        #endregion

        #region Constructors
        public MeasurementUnit()
        {
        }

        public MeasurementUnit(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }
        #endregion

        #region Save Entity
        public static MeasurementUnit SaveEntity(MeasurementUnit measurementunitname)
        {

            return MeasurementUnit.UpdateEntity(measurementunitname);
     
        }

        private static MeasurementUnit UpdateEntity(MeasurementUnit measurementunitname)
        {
            OleDbConnection Connection = new OleDbConnection(measurementunitname.pConnectionString);
            OleDbCommand cmdUpdate = new OleDbCommand("UPDATE tblMeasurementUnitName SET UnitName='" + measurementunitname.pUnitName + "'  WHERE UnitId=" + measurementunitname.pUnitId + "", Connection);
            OleDbTransaction trans = null;
            try
            {
                Connection.Open();
                trans = Connection.BeginTransaction();
                cmdUpdate.Transaction = trans;
                cmdUpdate.ExecuteNonQuery();
                trans.Commit();
                Connection.Close();
                measurementunitname.MarkClean();
                return measurementunitname;
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

        public static MeasurementUnit FillEntity(OleDbDataReader Reader)
        {
            MeasurementUnit measurementunitname = new MeasurementUnit();
            measurementunitname.pUnitId = (int)Reader["UnitId"];
            measurementunitname.pUnitName = Reader["UnitName"].ToString();
            measurementunitname.MarkOld();
            return measurementunitname;
        }

        public static MeasurementUnit GetEntity(int unitid, string ConnectionString)
        {
            MeasurementUnit measurementunitname = null;
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT UnitId, UnitName FROM tblMeasurementUnitName WHERE UnitId=" + unitid + "";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (Reader.HasRows)
                    {
                        Reader.Read();
                        measurementunitname = FillEntity(Reader);
                        measurementunitname.pConnectionString = ConnectionString;
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                }
            }
            return measurementunitname;
        }

        #endregion

        

        #region Utility
        public override string ToString()
        {
            return pUnitName;
        }
        public void SetConnectionString(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }

        #endregion

    }
}