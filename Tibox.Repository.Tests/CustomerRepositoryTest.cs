using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tibox.Models;
using Tibox.Repository;
using Tibox.Repository.Nortwhind;
using Tibox.UnitOfWork;

namespace Tibox.DataAccess.Tests
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerRepositoryTest()
        {
            _unitOfWork = new TiboxUnitOfWork();
        }

        [TestMethod]
        public void Get_All_Customers()
        {
            var result = _unitOfWork.Customers.GetAll();
            Assert.AreEqual(result.Count() > 0, true);
        }

        [TestMethod]
        public void Insert_Customer()
        {
            var customer = new Customer
            {
                FirstName = "Hugo",
                LastName = "Roca",
                City = "Perú",
                Country = "Lima",
                Phone = "945943857"
            };
            var result = _unitOfWork.Customers.Insert(customer);
            Assert.AreEqual(result > 0, true);
        }

        [TestMethod]
        public void Delete_Customer()
        {
            var result = _unitOfWork.Customers.GetEntityById(95);
            Assert.AreEqual(result != null, true);
            Assert.AreEqual(_unitOfWork.Customers.Delete(result), true);
        }

        [TestMethod]
        public void Update_Customer()
        {
            var result = _unitOfWork.Customers.GetEntityById(89);
            Assert.AreEqual(result != null, true);

            var customer = new Customer
            {
                Id = 89,
                FirstName = "Hugo",
                LastName = "Roca",
                City = "Perú",
                Country = "Lima",
                Phone = "945943857"
            };
            Assert.AreEqual(_unitOfWork.Customers.Update(customer), true);
        }

        [TestMethod]
        public void Get_Customer_Id()
        {
            var result = _unitOfWork.Customers.GetEntityById(91);
            Assert.AreEqual(result != null, true);
        }

        [TestMethod]
        public void Customer_By_Name()
        {
            var customer = _unitOfWork.Customers.SearchByNames("Maria", "Anders");
            Assert.AreEqual(customer != null, true);

            Assert.AreEqual(customer.Id, 1);
            Assert.AreEqual(customer.FirstName, "Maria");
            Assert.AreEqual(customer.LastName, "Anders");
        }

        [TestMethod]
        public void Customer_With_Orders()
        {
            var customer = _unitOfWork.Customers.CustomerWithOrders(1);
            Assert.AreEqual(customer != null, true);

            Assert.AreEqual(customer.Orders.Any(), true);
        }

    }
}
