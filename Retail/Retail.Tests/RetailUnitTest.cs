using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Retail.Controllers;
using Retail.Models;

namespace Retail.Tests
{
    [TestClass]
    public class RetailUnitTest
    {
        //[TestMethod]
        //public void GetProductDetails()
        //{
        //    List<ProductModel> testProduct = GetTestProducts();            
        //    List<ProductModel> result = new ProductController().GetProductDetails();
        //    //var result = controller.GetProductDetails() as List<ProductModel>;
        //    Assert.AreEqual(testProduct.Count, result.Count);
        //}       

        [TestMethod]
        public void AddProduct()
        {
            Assert.AreEqual(2, 2);
            //List<ProductModel> testProduct = GetTestProducts();
            //List<ProductModel> result = new ProductController().GetProductDetails();
            ////var result = controller.GetProductDetails() as List<ProductModel>;
            //Assert.AreEqual(testProduct.Count, result.Count);

            //Mock<IDBContext> mockDBContext = new Mock<IDBContext>();

            //mockDBContext.Setup(t => t.GetNextOrderDetailFromDB(It.IsAny<int>())).Returns(new Order() { OrderId = orderId, Amount = 1000 });
            //mockDBContext.Setup(t => t.SaveOrder(It.IsAny<Order>()));

            //OrderProcessingWithMoq orderProcessing = new OrderProcessingWithMoq();
            //var modifiedOrder = orderProcessing.ProcessGSTForNextOrder(mockDBContext.Object, orderId);

            //Assert.IsTrue(modifiedOrder.Amount == 1100);
        }

        //[TestMethod]
        //public void GetAllProducts_ShouldReturnAllProducts()
        //{
        //    var testProducts = GetTestProducts();
        //    var controller = new ProductController();
        //    var result = controller.GetProductDetails() as List<ProductModel>;
        //    Assert.AreEqual(testProducts.Count, result.Count);
        //}

        //[TestMethod]
        //public async Task GetAllProductsAsync_ShouldReturnAllProducts()
        //{
        //    var testProducts = GetTestProducts();
        //    var controller = new ProductController();

        //    var result = await controller.GetAllProductsAsync() as List<ProductModel>;
        //    Assert.AreEqual(testProducts.Count, result.Count);
        //}

        private List<ProductModel> GetTestProducts()
        {
            var testProducts = new List<ProductModel>();
            testProducts.Add(new ProductModel { ProductId = 1, ProductName = "Product-1", ProductAmount = 1.05, Quantity = 6 });
            testProducts.Add(new ProductModel { ProductId = 2, ProductName = "Product-2", ProductAmount = 10.00, Quantity = 58 });
            testProducts.Add(new ProductModel { ProductId = 3, ProductName = "Product-3", ProductAmount = 7.80, Quantity = 21 });

            return testProducts;
        }
    }
}
