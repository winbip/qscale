using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace CustomObjects
{
    public class ReportData
    {

        #region PublicProperties

        public string ClientName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public DateTime TruckInDate { get; set; }
        public DateTime TruckInTime { get; set; }
        public decimal TruckInWeight { get; set; }
        public decimal TruckInTare { get; set; }
        public string ChallanNo { get; set; }
        public string MaterialDescription { get; set; }
        public string Quantity { get; set; }
        public string TruckNo { get; set; }
        public string ProductName { get; set; }
        public DateTime TruckOutDate { get; set; }
        public DateTime TruckOutTime { get; set; }
        public decimal TruckOutWeight { get; set; }
        public decimal TruckOutTare { get; set; }
        #endregion


        #region Read Entity

        public static ReportData FillEntity(OleDbDataReader Reader)
        {
            ReportData reportData = new ReportData();

            reportData.ClientName = Reader["ClientName"].ToString();
            reportData.CompanyName = Reader["CompanyName"].ToString();
            reportData.Address = Reader["Address"].ToString();
            reportData.MobileNo = Reader["MobileNo"].ToString();
            reportData.TruckInDate = (DateTime)Reader["TruckInDate"];
            reportData.TruckInTime = (DateTime)Reader["TruckInTime"];
            reportData.TruckInWeight = (decimal)Reader["TruckInWeight"];
            reportData.TruckInTare = (decimal)Reader["TruckInTare"];
            reportData.ChallanNo = Reader["ChallanNo"].ToString();
            reportData.MaterialDescription = Reader["MaterialDescription"].ToString();
            reportData.Quantity = (string)Reader["Quantity"];
            reportData.TruckNo = Reader["TruckNo"].ToString();
            reportData.ProductName = Reader["ProductName"].ToString();
            reportData.TruckOutDate = (DateTime)Reader["TruckOutDate"];
            reportData.TruckOutTime = (DateTime)Reader["TruckOutTime"];
            reportData.TruckOutWeight = (decimal)Reader["TruckOutWeight"];
            reportData.TruckOutTare = (decimal)Reader["TruckOutTare"];
            
            return reportData;
        }

      

        public static List<ReportData> GetEntityList(string ConnectionString,Product product, 
                                                        Client client, string fromDate, string toDate )
        {


            string whereClause = "";

            if(product.ProductId > 0)
            {
                whereClause += " ProductName = '"+ product.ProductName +"'";
            }

            if(client.ClientId > -1)
            {
                if (string.IsNullOrEmpty(whereClause))
                {
                    whereClause += " ClientId = " + client.ClientId + "";
                }
                else
                {
                    whereClause += " AND  ClientId = " + client.ClientId + "";
                }
            }

            if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
            {
                if (string.IsNullOrEmpty(whereClause))
                {
                    whereClause += " TruckOutDate Between #"+ fromDate +"# and #"+ toDate +"#";
                }
                else
                {
                    whereClause += " AND TruckOutDate Between #" + fromDate + "# and #" + toDate + "#";
                }
            }

            List<ReportData> reportDataList = new List<ReportData>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT * FROM qryReport";

                if (string.IsNullOrEmpty(whereClause))
                {
                    sqlSelect = "SELECT * FROM qryReport";
                }
                else
                {
                    sqlSelect = "SELECT * FROM qryReport where " + whereClause;
                }

                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        ReportData truckout = FillEntity(Reader);
                        reportDataList.Add(truckout);
                    }
                    if (!Reader.IsClosed)
                    {
                        Reader.Close();
                    }
                    Connection.Close();
                }
            }
            return reportDataList;
        }

        #endregion
    }
}
