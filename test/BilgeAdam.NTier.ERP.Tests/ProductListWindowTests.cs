using System;
using System.Collections.Generic;
using System.Linq;
using BilgeAdam.NTier.ERP.App.Products;
using BilgeAdam.NTier.ERP.Dto.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BilgeAdam.NTier.ERP.Tests
{
    [TestClass]
    public class ProductListWindowTests
    {
        public frmProducts Sut { get; set; }
        public ProductListWindowTests()
        {
            Sut = new frmProducts();
        }
        [TestMethod]
        public void GetFirstPageOfProducts_Returns15ProductItems()
        {
            Sut.RunQuery();
            var result = Sut.dgvProducts.DataSource as List<ProductListDto>;
            Assert.IsNotNull(result);
            Assert.AreEqual(15, result.Count);
            Assert.AreEqual(0, Sut.PageIndex);
            Assert.AreEqual(15, Sut.Limit);
            Assert.IsFalse(Sut.btnPrevious.Enabled);
        }

        [TestMethod]
        public void GetSecondPageOfProducts_ReturnsSpecificProductNames()
        {
            Sut.NextPage();
            var result = Sut.dgvProducts.DataSource as List<ProductListDto>;
            Assert.IsNotNull(result);
            Assert.AreEqual(15, result.Count);
            Assert.AreEqual("Geitost", result[0].Name);
            Assert.AreEqual("Jack's New England Clam Chowder", result[14].Name);
            Assert.IsTrue(Sut.btnPrevious.Enabled);
            Assert.IsTrue(Sut.btnNext.Enabled);
        }

        [TestMethod]
        public void GetLastPageOfProducts_ReturnsSpecificProductNames()
        {
            Sut.NextPage();
            Sut.NextPage();
            Sut.NextPage();
            Sut.NextPage();
            Sut.NextPage();
            var result = Sut.dgvProducts.DataSource as List<ProductListDto>;

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Wimmers gute Semmelknödel", result[0].Name);
            Assert.AreEqual("Zaanse koeken", result[1].Name);
            Assert.IsTrue(Sut.btnPrevious.Enabled);
            Assert.IsFalse(Sut.btnNext.Enabled);
        }
    }
}
