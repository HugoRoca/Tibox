using System;
using System.Linq;
using System.Web.Http.Results;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tibox.Models;
using Tibox.UnitOfWork;
using Tibox.WebApi.Controllers;
using Tibox.WebApi.Tests.MockData;
using Xunit;

namespace Tibox.WebApi.Tests
{
    [TestClass]
    public class SupplierControllerTest
    {
        private readonly IUnitOfWork _unit;
        private SupplierController _supplierController;

        public SupplierControllerTest()
        {
            _unit = new MockedUnitOfWork();
            _supplierController = new SupplierController(_unit);
        }

        [Fact]
        public void GetByIdRequest()
        {
            var result = _supplierController.Get(-1) as BadRequestResult;
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(BadRequestResult));
        }

        [Fact]
        public void GetByIdGoodRequest()
        {
            var supplierToValidate = _unit.Suppliers.GetAll().ToList().FirstOrDefault();
            var result = _supplierController.Get(supplierToValidate.Id) as OkNegotiatedContentResult<Supplier>;
            result.Should().NotBeNull();
            result.Content.Id.Should().Be(supplierToValidate.Id);
            result.Content.CompanyName.Should().Be(supplierToValidate.CompanyName);
            result.Content.ContactName.Should().Be(supplierToValidate.ContactName);
            result.Content.ContactTitle.Should().Be(supplierToValidate.ContactTitle);
            result.Content.City.Should().Be(supplierToValidate.City);
            result.Content.Country.Should().Be(supplierToValidate.Country);
        }

        [Fact]
        public void GetByIdNullRequest()
        {
            var result = _supplierController.Get(999) as OkNegotiatedContentResult<Supplier>;
            result.Content.Should().BeNull();
        }

        [Fact]
        public void InsertSupplierBadRequest()
        {
            var supplier = new Supplier();
            supplier.Id = 0;
            supplier.CompanyName = "";
            supplier.ContactName = "";
            supplier.ContactTitle = "";
            supplier.City = "";
            supplier.Country = "";
            supplier.Phone = "";
            supplier.Fax = "";

            _supplierController.ModelState.Clear();
            _supplierController.ModelState.AddModelError("fakeError", "fakeError");

            var result = _supplierController.Post(supplier) as InvalidModelStateResult;
            result.Should().NotBeNull();
            result.ModelState.IsValid.Should().BeFalse();
            result.ModelState.Values.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void InsertsupplierGoodRequest()
        {
            var supplier = new Supplier();
            supplier.Id = 100;
            supplier.CompanyName = "Hugo";
            supplier.ContactName = "Roca";
            supplier.ContactTitle = "Probando";
            supplier.City = "lima";
            supplier.Country = "Perú";
            supplier.Phone = "945943857";
            supplier.Fax = "(31) 123456";

            var result = _supplierController.Post(supplier) as OkNegotiatedContentResult<int>;
            result.Should().NotBeNull();
            result.Content.Should().Be(supplier.Id);
        }

        [Fact]
        public void EditSupplierBadRequest()
        {
            var supplier = new Supplier();
            supplier.Id = 0;
            supplier.CompanyName = "";
            supplier.ContactName = "";
            supplier.ContactTitle = "";
            supplier.City = "";
            supplier.Country = "";
            supplier.Phone = "";
            supplier.Fax = "";
            
            var result = _supplierController.Put(supplier) as InvalidModelStateResult;
            result.Should().BeNull();            
        }

        [Fact]
        public void EditSupplierBadRequestModelState()
        {
            var supplier = new Supplier();
            supplier.Id = 0;
            supplier.CompanyName = "";
            supplier.ContactName = "";
            supplier.ContactTitle = "";
            supplier.City = "";
            supplier.Country = "";
            supplier.Phone = "";
            supplier.Fax = "";

            _supplierController.ModelState.Clear();
            _supplierController.ModelState.AddModelError("fakeError", "fakeError");

            var result = _supplierController.Put(supplier) as InvalidModelStateResult;
            result.Should().NotBeNull();
            result.ModelState.IsValid.Should().BeFalse();
        }

        [Fact]
        public void EditSupplierGoodRequest()
        {
            var supplier = new Supplier();
            supplier.Id = 1;
            supplier.CompanyName = "hugo";
            supplier.ContactName = "roca";
            supplier.ContactTitle = "probando";
            supplier.City = "New York";
            supplier.Country = "EEUU";
            supplier.Phone = "945943857";
            supplier.Fax = "(32)98654";

            var result = _supplierController.Put(supplier) as InvalidModelStateResult;
            result.Should().BeNull();
        }

        [Fact]
        public void DeleteBadRequest()
        {
            var result = _supplierController.Delete(-1) as BadRequestResult;
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(BadRequestResult));
        }

        [Fact]
        public void DeleteGoodRequest()
        {
            var result = _supplierController.Delete(38) as OkNegotiatedContentResult<bool>;
            result.Content.Should().BeTrue();
        }
    }
}
