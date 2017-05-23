using System;
using System.Collections.Generic;
using System.Linq;
using Ploeh.AutoFixture;
using Tibox.Models;
using Tibox.Repository;

namespace Tibox.WebApi.Tests.MockData
{
    public class MockedSupplierRepository : IRepository<Supplier>
    {
        private List<Supplier> supplier;

        public MockedSupplierRepository()
        {
            var ficture = new Fixture();
            supplier = ficture.CreateMany<Supplier>(30).ToList();
        }

        public bool Delete(Supplier entity)
        {
            return supplier.Remove(entity);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return supplier;
        }

        public Supplier GetEntityById(int id)
        {
            return supplier.FirstOrDefault(s => s.Id == id);
        }

        public int Insert(Supplier entity)
        {
            supplier.Add(entity);
            return entity.Id;
        }

        public bool Update(Supplier entity)
        {
            var updateEntity = supplier.FirstOrDefault(s => s.Id == entity.Id);
            if (updateEntity == null) return false;
            updateEntity = entity;
            return true;
        }
    }
}
