using System;
using System.Linq;
using BilgeAdam.NTier.ERP.Service.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BilgeAdam.NTier.ERP.Tests
{
    [TestClass]
    public class ProductServiceTests
    {
        public ProductListService Sut { get; set; }
        public ProductServiceTests()
        {
            Sut = new ProductListService();
        }

        [TestMethod]
        public void GetFirstPageOfProducts_Returns15ProductItems()
        {
            var result = Sut.GetPagedProducts(0, 15);
            Assert.AreEqual(15, result.Count());
        }

        [TestMethod]
        public void GetAllProducts_Returns78ProductItems()
        {
            var result = Sut.GetAllProducts();
            Assert.AreEqual(78, result.Count());
        }
    }
}
