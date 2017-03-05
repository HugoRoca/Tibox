using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tibox.Models;
using Tibox.Repository;
using Tibox.UnitOfWork;

namespace Tibox.DataAccess.Tests
{
    [TestClass]
    public class OrderRepositoryTest
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderRepositoryTest()
        {
            _unitOfWork = new TiboxUnitOfWork();
        }

        [TestMethod]
        public void Order_By_OrderNumber()
        {
            var order = _unitOfWork.Orders.SearchOrderByOrderNumber(1);
            Assert.AreEqual(order != null, true);
        }

        
        [TestMethod]
        public void Order_With_OrderItems()
        {
            var order = _unitOfWork.Orders.OrderWithOrdersItems(1);
            Assert.AreEqual(order != null, true);

            Assert.AreEqual(order.OrderItems.Any(), true);
        }

    }
}
