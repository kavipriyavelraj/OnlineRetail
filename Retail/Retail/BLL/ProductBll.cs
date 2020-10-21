using Retail.DAL;
using Retail.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Retail.BLL
{   
    public class ProductBll
    {
        private ProductDAL _ProductDAL = null;

        #region Constructor
        public ProductBll()
        {
            _ProductDAL = new ProductDAL();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get product details
        /// </summary>
        /// <returns></returns>
        public List<ProductModel> GetProductDetails()
        {
            List<ProductModel> objProductList = new List<ProductModel>();            
            try
            {
                objProductList = _ProductDAL.GetProductDetails();
            }
            catch(Exception ex)
            {                
                throw ex;
            }           
            return objProductList;
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns></returns>
        public bool AddProduct(ProductModel objProduct)
        {
            bool RetValue = false;
            try
            {
                // Check Product Existance
                ProductModel objProductExst = new ProductModel();
                objProductExst = _ProductDAL.GetProductDetailsByName(objProduct.ProductName);

                if (objProductExst == null)                
                    RetValue = _ProductDAL.AddProduct(objProduct);                
                else
                    throw new Exception("Product Name already exist");
            }
            catch (Exception ex)
            {
                throw ex;
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
            bool RetValue = false;
            try
            {
                // Check Product Existance
                ProductModel objProductExst = new ProductModel();
                objProductExst = _ProductDAL.GetProductDetailsByName(objProduct.ProductName);
                if (objProductExst != null && objProductExst.ProductId != objProduct.ProductId)
                    throw new Exception("Product Name already exist");
                else
                    RetValue = _ProductDAL.UpdateProduct(objProduct);
            }
            catch (Exception ex)
            {
                throw ex;
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
            bool RetValue = false;
            try
            {
                // Check Product Existance
                ProductModel objProduct = new ProductModel();
                objProduct = _ProductDAL.GetProductDetailsById(ProductId);
                if (objProduct != null)
                {
                    RetValue = CheckProductItems(ProductId);
                    if (!RetValue)
                        RetValue = _ProductDAL.DeleteProduct(ProductId);
                    else
                        throw new Exception("Product is associated with Order, So couldn't be deleted");
                }
                else
                    throw new Exception("Product doesn't exist");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RetValue;
        }

        /// <summary>
        /// Check whether the product is available or not
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public bool CheckProductItems(int ProductId)
        {
            bool RetValue = false;
            int ProductCount = 0;
            try
            {
                ProductCount = _ProductDAL.CheckProductItems(ProductId);
                if (ProductCount > 0)
                    RetValue = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RetValue;
        }

        /// <summary>
        /// Get product details by Product Id
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public ProductModel GetProductDetailsById(int ProductId)
        {
            ProductModel objProduct = new ProductModel();
            try
            {
                objProduct = _ProductDAL.GetProductDetailsById(ProductId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objProduct;
        }

        /// <summary>
        /// Get product details by Product Name
        /// </summary>
        /// <param name="strProductName"></param>
        /// <returns></returns>
        public ProductModel GetProductDetailsByName(string strProductName)
        {
            ProductModel objProduct = new ProductModel();
            try
            {
                objProduct = _ProductDAL.GetProductDetailsByName(strProductName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objProduct;
        }

        /// <summary>
        /// Update Product Quantity 
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns></returns>
        public bool UpdateProductQuantity(ProductModel objProduct)
        {
            bool RetValue = false;
            try
            {
                RetValue = _ProductDAL.UpdateProductQuantity(objProduct);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RetValue;
        }

        /// <summary>
        /// Get Product Quantity for comparision
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public int GetProductQuantity(int ProductId)
        {
            ProductModel objProductModel = new ProductModel();
            int quantity = 0;
            try
            {
                objProductModel = GetProductDetailsById(ProductId);
                if (objProductModel != null)
                    quantity = objProductModel.Quantity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return quantity;
        }
        #endregion

    }
}