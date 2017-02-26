using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tibox.Models;
using Tibox.Repository;

namespace Tibox.DataAccess.Tests
{
    [TestClass]
    public class OrderRepsitoryTest
    {
        private readonly IRepository<Order> _repository;

        public OrderRepsitoryTest()
        {
            _repository = new BaseRepository<Order>();
        }

        
        
    }
}
