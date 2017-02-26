using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tibox.Models;
using Tibox.Repository;

namespace Tibox.DataAccess.Tests
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        private readonly IRepository<Customer> _repository;

        public CustomerRepositoryTest()
        {
            _repository = new BaseRepository<Customer>();
        }

        [TestMethod]
        public void Get_All_Customers()
        {
            var result = _repository.GetAll();
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
            var result = _repository.Insert(customer);
            Assert.AreEqual(result > 0, true);
        }

        [TestMethod]
        public void Delete_Customer()
        {
            var result = _repository.GetEntityById(95);
            Assert.AreEqual(result != null, true);
            Assert.AreEqual(_repository.Delete(result), true);
        }

        [TestMethod]
        public void Update_Customer()
        {
            var result = _repository.GetEntityById(89);
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
            Assert.AreEqual(_repository.Update(customer), true);
        }

        [TestMethod]
        public void Get_Customer_Id()
        {
            var result = _repository.GetEntityById(91);
            Assert.AreEqual(result != null, true);
        }
    }
}
