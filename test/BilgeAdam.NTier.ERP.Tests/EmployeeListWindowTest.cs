using BilgeAdam.NTier.ERP.App.Employees;
using BilgeAdam.NTier.ERP.Tests.FormHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.NTier.ERP.Tests
{
    [TestClass]
    public class EmployeeListWindowTest
    {
        public EmployeeListFormHelper Sut { get; set; }
        public EmployeeListWindowTest()
        {
            Sut = new EmployeeListFormHelper(new frmEmployees());
        }

        [TestMethod]
        public void GetAllEmployees()
        {
            Sut.Load();
            Assert.IsNotNull(Sut.Items);
            Assert.AreEqual(9, Sut.Items.Count);
            Assert.IsTrue(Sut.Items[0].FullName.StartsWith("Andrew"));
        }

        [TestMethod]
        public void GetAllEmployees_PreventsNavigatingNextPage()
        {
            Sut.Load();
            Assert.IsFalse(Sut.NextButtonEnabled);
        }

        [TestMethod]
        public void GetAllEmployees_PreventsNavigatingPreviousPage()
        {
            Sut.Load();
            Assert.IsFalse(Sut.PreviousButtonEnabled);
        }

        [TestMethod]
        public void ClearFilter_ResetTextBoxes_LoadsItems()
        {
            Sut.Load();
            Sut.SetFirstName("Nancy");
            Sut.SetLastName("Davolio");
            Sut.ClearFilter();
            Assert.AreEqual(string.Empty, Sut.FirstName);
            Assert.AreEqual(string.Empty, Sut.LastName);
            Assert.IsNotNull(Sut.Items);
            Assert.AreEqual(9, Sut.Items.Count);
            Assert.IsTrue(Sut.Items[0].FullName.StartsWith("Andrew"));
        }

        [TestMethod]
        public void SearchEmployee_ByName()
        {
            Sut.SetFirstName("M");
            Sut.Search();
            Assert.IsNotNull(Sut.Items);
            Assert.AreEqual(2, Sut.Items.Count);
            Assert.IsTrue(Sut.Items[0].FullName.StartsWith("Margaret"));
        }

        [TestMethod]
        public void SearchEmployee_ByLastname()
        {
            Sut.SetLastName("D");
            Sut.Search();
            Assert.IsNotNull(Sut.Items);
            Assert.AreEqual(2, Sut.Items.Count);
            Assert.IsTrue(Sut.Items[0].FullName.StartsWith("Anne"));
        }

        [TestMethod]
        public void SearchEmployee_ByFirstNameAndLastName()
        {
            Sut.SetFirstName("Nancy");
            Sut.SetLastName("Davolio");
            Sut.Search();
            Assert.IsNotNull(Sut.Items);
            Assert.AreEqual(1, Sut.Items.Count);
            Assert.AreEqual("Nancy Davolio", Sut.Items[0].FullName);
        }
    }
}
