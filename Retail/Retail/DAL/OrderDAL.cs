using Retail.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Retail.DAL
{
    public class OrderDAL
    {
        string strConnString = ConfigurationManager.ConnectionStrings["RetailDBConnection"].ConnectionString;
        SqlConnection sqlConnection = null;

        /// <summary>
        /// Get Order count by Order Id
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        public int GetOrderCountById(int OrderId)
        {
            SqlCommand sqlCommand = null;
            int OrderCount = 0;
            try
            {
                using (sqlConnection = new SqlConnection(strConnString))
                {
                    using (sqlCommand = new SqlCommand("Sproc_Order_Exist", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@OrderId", OrderId);

                        sqlConnection.Open();

                        OrderCount = (int)sqlCommand.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
            return OrderCount;
        }
        
        /// <summary>
        /// Add items from Order
        /// </summary>
        /// <param name="objOrderItems"></param>
        /// <returns></returns>
        public bool AddOrderItems(OrderItems objOrderItems)
        {
            int _RecordCount = 0;
            bool RetValue = false;
            SqlCommand sqlCommand = null;

            try
            {
                using (sqlConnection = new SqlConnection(strConnString))
                {
                    using (sqlCommand = new SqlCommand("Sproc_Insert_OrderItems", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@OrderId", objOrderItems.OrderId);
                        sqlCommand.Parameters.AddWithValue("@ProductId", objOrderItems.ProductId);
                        sqlCommand.Parameters.AddWithValue("@Quantity", objOrderItems.Quantity);

                        sqlConnection.Open();

                        _RecordCount = sqlCommand.ExecuteNonQuery();
                    }
                    if (_RecordCount > 0)
                        RetValue = true;
                }
            }
            catch (Exception ex)
            {
                RetValue = false;
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
            return RetValue;
        }

        /// <summary>
        /// Add Order Details
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        public bool AddOrderDetails(out int OrderId)
        {            
            bool RetValue = false;
            SqlCommand sqlCommand = null;

            try
            {
                using (sqlConnection = new SqlConnection(strConnString))
                {
                    using (sqlCommand = new SqlCommand("Sproc_Insert_OrderDetails", sqlConnection))
                    {
                        sqlConnection.Open();
                        OrderId = (int) sqlCommand.ExecuteScalar();
                    }
                    if (OrderId > 0)
                        RetValue = true;
                }
            }
            catch (Exception ex)
            {
                RetValue = false;
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
            return RetValue;
        }

        /// <summary>
        /// Cancel Order
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        public bool CancelOrder(int OrderId)
        {
            int _RecordCount = 0;
            bool RetValue = false;
            SqlCommand sqlCommand = null;

            try
            {
                using (sqlConnection = new SqlConnection(strConnString))
                {
                    using (sqlCommand = new SqlCommand("Sproc_Cancel_Order", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@OrderId", OrderId);

                        sqlConnection.Open();

                        _RecordCount = sqlCommand.ExecuteNonQuery();
                    }
                    if (_RecordCount > 0)
                        RetValue = true;
                }
            }
            catch (Exception ex)
            {
                RetValue = false;
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
            return RetValue;
        }        
    }
}