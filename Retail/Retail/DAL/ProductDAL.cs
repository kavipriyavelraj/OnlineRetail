using Retail.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Retail.DAL
{
    public class ProductDAL
    {        
        string strConnString = ConfigurationManager.ConnectionStrings["RetailDBConnection"].ConnectionString;        
        SqlConnection sqlConnection = null;
        SqlCommand sqlCommand = null;

        /// <summary>
        /// Get Product Details
        /// </summary>
        /// <returns></returns>
        public List<ProductModel> GetProductDetails()
        {
            List<ProductModel> objProductList = null;
            ProductModel objProduct = null;
            try
            {
                using (sqlConnection = new SqlConnection(strConnString))
                {
                    using (sqlCommand = new SqlCommand("Sproc_Product_Details", sqlConnection))
                    {
                        sqlConnection.Open();
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                        objProductList = new List<ProductModel>();
                        while (sqlDataReader.Read())
                        {
                            objProduct = new ProductModel();

                            if (sqlDataReader["ProductId"] != DBNull.Value)
                                objProduct.ProductId = Convert.ToInt32(sqlDataReader["ProductId"]);

                            if (sqlDataReader["ProductName"] != DBNull.Value)
                                objProduct.ProductName = sqlDataReader["ProductName"].ToString();

                            if (sqlDataReader["ProductAmount"] != DBNull.Value)
                                objProduct.ProductAmount = Convert.ToDouble(sqlDataReader["ProductAmount"]);

                            if (sqlDataReader["Quantity"] != DBNull.Value)
                                objProduct.Quantity = Convert.ToInt32(sqlDataReader["Quantity"]);

                            //if (sqlDataReader["CreatedDate"] != DBNull.Value)
                            //    objProduct.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);

                            //if (sqlDataReader["UpdatedDate"] != DBNull.Value)
                            //    objProduct.UpdatedDate = Convert.ToDateTime(sqlDataReader["UpdatedDate"]);

                            objProductList.Add(objProduct);
                        }
                        sqlDataReader.Close();
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
            return objProductList;
        }

        /// <summary>
        /// Check whether the product is available or not
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public int CheckProductItems(int ProductId)
        {
            int _RecordCount = 0;
            SqlCommand sqlCommand = null;

            try
            {
                using (sqlConnection = new SqlConnection(strConnString))
                {
                    using (sqlCommand = new SqlCommand("Sproc_CheckProduct_Items", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@ProductId", ProductId);

                        sqlConnection.Open();

                        _RecordCount = (int)sqlCommand.ExecuteScalar();
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
            return _RecordCount;
        }

        /// <summary>
        /// Get product details by Product Id
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public ProductModel GetProductDetailsById(int ProductId)
        {
            ProductModel objProduct = null;
            SqlCommand sqlCommand = null;

            try
            {
                using (sqlConnection = new SqlConnection(strConnString))
                {
                    using (sqlCommand = new SqlCommand("Sproc_Product_Exist", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@ProductId", ProductId);

                        sqlConnection.Open();

                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();


                        while (sqlDataReader.Read())
                        {
                            objProduct = new ProductModel();

                            if (sqlDataReader["ProductId"] != DBNull.Value)
                                objProduct.ProductId = Convert.ToInt32(sqlDataReader["ProductId"]);

                            if (sqlDataReader["ProductName"] != DBNull.Value)
                                objProduct.ProductName = sqlDataReader["ProductName"].ToString();

                            if (sqlDataReader["ProductAmount"] != DBNull.Value)
                                objProduct.ProductAmount = Convert.ToDouble(sqlDataReader["ProductAmount"]);

                            if (sqlDataReader["Quantity"] != DBNull.Value)
                                objProduct.Quantity = Convert.ToInt32(sqlDataReader["Quantity"]);

                            //if (sqlDataReader["CreatedDate"] != DBNull.Value)
                            //    objProduct.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        }

                        sqlDataReader.Close();
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
            return objProduct;
        }

        /// <summary>
        /// Get product details by Product Name
        /// </summary>
        /// <param name="ProductName"></param>
        /// <returns></returns>
        public ProductModel GetProductDetailsByName(string ProductName)
        {
            ProductModel objProduct = null;
            SqlCommand sqlCommand = null;

            try
            {
                using (sqlConnection = new SqlConnection(strConnString))
                {
                    using (sqlCommand = new SqlCommand("Sproc_ProductName_Exist", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@ProductName", ProductName);

                        sqlConnection.Open();

                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                        while (sqlDataReader.Read())
                        {
                            objProduct = new ProductModel();

                            if (sqlDataReader["ProductId"] != DBNull.Value)
                                objProduct.ProductId = Convert.ToInt32(sqlDataReader["ProductId"]);

                            if (sqlDataReader["ProductName"] != DBNull.Value)
                                objProduct.ProductName = sqlDataReader["ProductName"].ToString();

                            if (sqlDataReader["ProductAmount"] != DBNull.Value)
                                objProduct.ProductAmount = Convert.ToDouble(sqlDataReader["ProductAmount"]);

                            if (sqlDataReader["Quantity"] != DBNull.Value)
                                objProduct.Quantity = Convert.ToInt32(sqlDataReader["Quantity"]);

                            //if (sqlDataReader["CreatedDate"] != DBNull.Value)
                            //    objProduct.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        }

                        sqlDataReader.Close();
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
            return objProduct;
        }

        /// <summary>
        ///  Add Product
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns></returns>
        public bool AddProduct(ProductModel objProduct)
        {
            int _RecordCount = 0;
            bool RetValue = false;
            SqlCommand sqlCommand = null;
            
            try
            {
                using (sqlConnection = new SqlConnection(strConnString))
                {
                    using(sqlCommand = new SqlCommand("Sproc_Insert_Product", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@ProductName", objProduct.ProductName);
                        sqlCommand.Parameters.AddWithValue("@ProductAmount", objProduct.ProductAmount);
                        sqlCommand.Parameters.AddWithValue("@Quantity", objProduct.Quantity);

                        sqlConnection.Open();

                        _RecordCount = sqlCommand.ExecuteNonQuery();
                    }
                    if (_RecordCount > 0)
                        RetValue = true;
                }
            }
            catch(Exception ex)
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
        /// Update existing product
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns></returns>
        public bool UpdateProduct(ProductModel objProduct)
        {
            int _RecordCount = 0;
            bool RetValue = false;
            SqlCommand sqlCommand = null;

            try
            {
                using (sqlConnection = new SqlConnection(strConnString))
                {
                    using (sqlCommand = new SqlCommand("Sproc_Update_Product", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@ProductId", objProduct.ProductId);
                        sqlCommand.Parameters.AddWithValue("@ProductName", objProduct.ProductName);
                        sqlCommand.Parameters.AddWithValue("@ProductAmount", objProduct.ProductAmount);
                        sqlCommand.Parameters.AddWithValue("@Quantity", objProduct.Quantity);

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
        /// Get Product Quantity for comparision
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns></returns>
        public bool UpdateProductQuantity(ProductModel objProduct)
        {
            int _RecordCount = 0;
            bool RetValue = false;
            SqlCommand sqlCommand = null;

            try
            {
                using (sqlConnection = new SqlConnection(strConnString))
                {
                    using (sqlCommand = new SqlCommand("Sproc_Update_ProductQuantity", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@ProductId", objProduct.ProductId);                        
                        sqlCommand.Parameters.AddWithValue("@Quantity", objProduct.Quantity);

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
        /// Delete existing product
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public bool DeleteProduct(int ProductId)
        {
            int _RecordCount = 0;
            bool RetValue = false;
            SqlCommand sqlCommand = null;

            try
            {
                using (sqlConnection = new SqlConnection(strConnString))
                {
                    using (sqlCommand = new SqlCommand("Sproc_Delete_Product", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@ProductId", ProductId);

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