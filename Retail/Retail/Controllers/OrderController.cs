using Retail.BLL;
using Retail.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Retail.Controllers
{
    public class OrderController : ApiController
    {
        #region Constructor

        public OrderController() { }

        #endregion

        #region Methods

        /// <summary>
        /// Order Products
        /// </summary>
        /// <param name="lstProductModel"></param>
        /// <returns></returns>
        [HttpGet]
        public string OrderProduct(List<ProductModel> lstProductModel)
        {
            bool RetValue = false;
            string strStatus = string.Empty;
            try
            {                
                RetValue = new OrderBll().OrderProduct(lstProductModel);                
                if (RetValue)
                    strStatus = "Products Ordered Successfully";
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
            
        /// <summary>
        /// Cancel Order
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        [HttpGet]
        public string CancelOrder(int OrderId)
        {
            bool RetValue = false;
            string strStatus = string.Empty;
            try
            {
                RetValue = new OrderBll().CancelOrder(OrderId);
                if (RetValue)
                    strStatus = "Order Cancelled Successfully";
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

        #endregion
    }
}
