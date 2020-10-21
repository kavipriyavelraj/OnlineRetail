using Retail.BLL;
using Retail.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Retail.Controllers
{
    public class ProductController : ApiController
    {
        public ProductController() { }

        [HttpGet]
        public List<ProductModel> GetProductDetails()
        {
            try
            {
                List<ProductModel> objProductList = new List<ProductModel>();
                objProductList = new ProductBll().GetProductDetails();
                return objProductList;
            }
            catch(Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Error Request"
                };
                throw new HttpResponseException(resp);
            }
        }
                
        [HttpGet]
        public string AddProduct(ProductModel objProductModel)
        {
            bool RetValue =false;
            string strStatus = string.Empty;            
            try
            {
                RetValue= new ProductBll().AddProduct(objProductModel);
                if (RetValue)
                    strStatus = "Product Added Successfully";                
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Error Request"
                };
                throw new HttpResponseException(resp);                
            }
            return strStatus;
        }
                
        [HttpGet]
        public string EditProduct(ProductModel objProductModel)
        {
            bool RetValue;
            string strStatus = string.Empty;
            try
            {
                RetValue = new ProductBll().UpdateProduct(objProductModel);
                if (RetValue)
                    strStatus = "Product Updated Successfully";
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Error Request"
                };
                throw new HttpResponseException(resp);
            }
            return strStatus;
        }
                
        [HttpGet]
        public string DeleteProduct(int ProductId)
        {
            bool RetValue;
            string strStatus = string.Empty;
            try
            {
                RetValue = new ProductBll().DeleteProduct(ProductId);
                if (RetValue)
                    strStatus = "Product Deleted Successfully";
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Error Request"
                };
                throw new HttpResponseException(resp);
            }
            return strStatus;
        }
    }
}
