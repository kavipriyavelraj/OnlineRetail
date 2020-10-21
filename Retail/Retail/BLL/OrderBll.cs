using Retail.DAL;
using Retail.Models;
using System;
using System.Collections.Generic;
using static Retail.BLL.OrderBll;

namespace Retail.BLL
{
    public class OrderBll : IOrder
    {
        private OrderDAL _OrderDAL = null;

        #region Constructor
        
        public OrderBll()
        {
            _OrderDAL = new OrderDAL();
        }

        #endregion
        
        #region Methods

        /// <summary>
        /// Order Product
        /// </summary>
        /// <param name="lstProductModel"></param>
        /// <returns></returns>
        public virtual bool OrderProduct(List<ProductModel> lstProductModel)
        {
            bool RetValue = false;
            bool OrderRetValue = false;
            int OrderId = 0;
            OrderItems objOrderItems = null;
            try
            {
                if (lstProductModel != null && lstProductModel.Count > 0)
                {                    
                    RetValue = _OrderDAL.AddOrderDetails(out OrderId);

                    foreach (ProductModel nProductModel in lstProductModel)
                    {
                        // Check Product Quantity
                        ProductModel oProductModel = new ProductBll().GetProductDetailsById(nProductModel.ProductId);

                        if (oProductModel != null)
                        {
                            // Check availability
                            if (oProductModel.Quantity >= nProductModel.Quantity)
                            {
                                objOrderItems = new OrderItems();
                                objOrderItems.OrderId = OrderId;
                                objOrderItems.ProductId = nProductModel.ProductId;
                                objOrderItems.Quantity = nProductModel.Quantity;                                
                                OrderRetValue = _OrderDAL.AddOrderItems(objOrderItems);

                                // Update Quantity
                                if (OrderRetValue)
                                {
                                    nProductModel.Quantity = oProductModel.Quantity - nProductModel.Quantity;
                                    OrderRetValue = new ProductBll().UpdateProductQuantity(nProductModel);
                                }
                            }
                            else
                            {
                                OrderRetValue = CancelOrder(OrderId);
                                throw new Exception("Required Quantity is not available for " + oProductModel.ProductName);
                            }
                        }
                        OrderRetValue = false;
                    }
                }
                else
                    throw new Exception("No Products found in Order");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RetValue;
        }

        /// <summary>
        /// Cancel Order
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        public virtual bool CancelOrder(int OrderId)
        {
            bool RetValue = false;
            int OrderCount = 0;
            try
            {
                // Check Order Existance
                ProductModel objProduct = new ProductModel();
                OrderCount = _OrderDAL.GetOrderCountById(OrderId);
                if (OrderCount > 0)                
                    RetValue = _OrderDAL.CancelOrder(OrderId);                
                else
                    throw new Exception("Order doesn't exist");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RetValue;
        }

        #endregion

        #region Interface

        public interface IOrder
        {
            bool OrderProduct(List<ProductModel> lstProductModel);
            bool CancelOrder(int OrderId);
        }

        #endregion
    }
}