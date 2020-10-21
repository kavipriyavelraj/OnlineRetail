using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Retail.BLL;
using Retail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private List<ProductModel> SampleProducts()
        {
            var SampleProduct = new List<ProductModel>();
            SampleProduct.Add(new ProductModel { ProductId = 1, ProductName = "Product-1", ProductAmount = 1.05, Quantity = 6 });
            SampleProduct.Add(new ProductModel { ProductId = 2, ProductName = "Product-2", ProductAmount = 10.00, Quantity = 58 });
            SampleProduct.Add(new ProductModel { ProductId = 3, ProductName = "Product-3", ProductAmount = 7.80, Quantity = 21 });

            return SampleProduct;
        }

        private ProductModel SampleProduct()
        {            
            var SampleProduct = new ProductModel { ProductName = "Product-1", ProductAmount = 1.05, Quantity = 6 };
            return SampleProduct;
        }

        private ProductModel SampleProductUpdate()
        {
            var SampleProduct = new ProductModel { ProductId = 1, ProductName = "Product-1", ProductAmount = 1.05, Quantity = 6 };
            return SampleProduct;
        }

        [TestMethod]
        public void AddProduct()
        {
            ProductModel objProductModel = new ProductModel();
            objProductModel = SampleProduct();

            Mock<ProductBll> chk = new Mock<ProductBll>();
            Assert.IsTrue(chk.Object.AddProduct(objProductModel));            
        }

        [TestMethod]
        public void DeleteProduct()
        {
            int productId = 4;

            Mock<ProductBll> chk = new Mock<ProductBll>();
            Assert.IsTrue(chk.Object.DeleteProduct(productId));
        }

        [TestMethod]
        public void UpdateProduct()
        {
            ProductModel objProductModel = new ProductModel();
            objProductModel = SampleProductUpdate();

            Mock<ProductBll> chk = new Mock<ProductBll>();
            Assert.IsTrue(chk.Object.UpdateProduct(objProductModel));
        }

        [TestMethod]
        public void OrderProduct()
        {
            List<ProductModel> objProductModel = new List<ProductModel>();
            objProductModel = SampleProducts();

            Mock<OrderBll> chk = new Mock<OrderBll>();
            Assert.IsTrue(chk.Object.OrderProduct(objProductModel));
        }

        [TestMethod]
        public void CancelOrder()
        {
            int orderId = 11;

            Mock<OrderBll> chk = new Mock<OrderBll>();
            Assert.IsTrue(chk.Object.CancelOrder(orderId));
        }
    }
}
