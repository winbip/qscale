using sCommonLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace CustomObjects
{
  
    public class Product : ObjectBase
    {

        #region PrivateVariables
        private int pProductId;
        private string pProductName;
        private string pConnectionString;
        #endregion

        #region PublicProperties
        public int ProductId
        {
            get { return pProductId; }
            set
            {
                if (!value.Equals(pProductId))
                {
                    pProductId = value;
                    PropertyHasChanged("ProductId");
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
        public Product()
        {
        }

        public Product(string ConnectionString)
        {
            pConnectionString = ConnectionString;
        }
        #endregion

        #region Save Entity
        public static Product SaveEntity(Product product)
        {
            if (product.IsNew)
            {
                return Product.CreateEntity(product);
            }
            else
            {
                return Product.UpdateEntity(product);
            }
        }

        private static Product CreateEntity(Product product)
        {
            OleDbConnection Connection = new OleDbConnection(product.pConnectionString);
            OleDbCommand cmdCommand = new OleDbCommand(); cmdCommand.Connection = Connection;
            OleDbTransaction transaction = null;
            try
            {
                //Product Name can not be empty.
                if (string.IsNullOrEmpty(product.ProductName))
                {
                    throw new ExceptionWithControl("Product", "Information Invalid", "Enter product name.", "ProductName");
                }

                Connection.Open();
                transaction = Connection.BeginTransaction();
                cmdCommand.Transaction = transaction;
                SqlFunctionUtilityForAccess SqlFunction = new SqlFunctionUtilityForAccess(cmdCommand);

                //Product can not be duplicate.
                if (SqlFunction.IsFoundStringTypeValue("Select ProductName from tblProducts where ProductName='" + product.pProductName + "'"))
                {
                    throw new ExceptionWithControl("Product", "Duplicate Value", "This product code already in use. Try different code.", "ProductName");
                }

                SqlFunction.InsertData("INSERT INTO tblProducts(ProductName) VALUES('" + product.pProductName + "' )");

                product.pProductId = SqlFunction.GetLastPrimaryKeyValue("SELECT MAX(ProductId) AS LastId FROM tblProducts ");
                transaction.Commit();
                Connection.Close();
                product.MarkOld();
                return product;
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
        /// <param name="product"></param>
        /// <returns></returns>
        private static Product UpdateEntity(Product product) //TODO: Complete this method.
        {
            OleDbConnection Connection = new OleDbConnection(product.pConnectionString);
            OleDbCommand cmdUpdate = new OleDbCommand("UPDATE tblProducts SET ProductName='" + product.pProductName + "' WHERE ProductId=" + product.pProductId + "", Connection);
            OleDbTransaction trans = null;
            try
            {
                Connection.Open();
                trans = Connection.BeginTransaction();
                cmdUpdate.Transaction = trans;
                cmdUpdate.ExecuteNonQuery();
                trans.Commit();
                Connection.Close();
                product.MarkClean();
                return product;
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

        public static Product FillEntity(OleDbDataReader Reader, OleDbConnection Connection)
        {
            Product product = new Product();
            product.pProductId = (int)Reader["ProductId"];
            product.pProductName = Reader["ProductName"].ToString();
            product.MarkOld();
            return product;
        }

        /// <summary>
        /// Return Product with all fields. It has 2 overloads. ProductId and ConString/Connection
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="ConnectionString"></param>
        /// <returns>Product</returns>
        public static Product GetEntity(int ProductId, string ConnectionString)
        {
            Product product = null;
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                Connection.Open();
                product = Product.GetEntity(ProductId, Connection);
                product.pConnectionString = ConnectionString;
                Connection.Close();
            }
            return product;
        }

        public static Product GetEntity(int ProductId, OleDbConnection Connection)
        {
            Product product = null;

            string sqlSelect = "SELECT ProductId, ProductName FROM tblProducts WHERE ProductId=" + ProductId + "";
            using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
            {
                OleDbDataReader Reader = cmd.ExecuteReader();
                if (Reader.HasRows)
                {
                    Reader.Read();
                    product = FillEntity(Reader, Connection);
                    //Object returned from this method does not require ConnectionString.
                }
                if (!Reader.IsClosed)
                {
                    Reader.Close();
                }

            }

            return product;
        }

        public static List<Product> GetEntityList(string ConnectionString)
        {
            List<Product> ClientList = new List<Product>();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionString))
            {
                string sqlSelect = "SELECT  ProductId, ProductName FROM tblProducts ORDER BY ProductName asc";
                using (OleDbCommand cmd = new OleDbCommand(sqlSelect, Connection))
                {
                    Connection.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        Product product = FillEntity(Reader, Connection);
                        product.pConnectionString = ConnectionString;
                        ClientList.Add(product);
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
                string sqlDelete = "DELETE ProductId, ProductName FROM tblProducts WHERE ProductId=" + this.pProductId + "";
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
