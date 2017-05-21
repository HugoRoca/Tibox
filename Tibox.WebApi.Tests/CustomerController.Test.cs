using System;
using System.Linq;
using System.Web.Http.ModelBinding;
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
    public class CustomerControllerTest
    {
        private readonly IUnitOfWork _unit;
        private CustomerController _customerController;

        public CustomerControllerTest()
        {
            _unit = new MockedUnitOfWork();
            _customerController = new CustomerController(_unit);
        }

        // TEST PARA EL GET
        [Fact]// ESTO SE PONE POR EL XUNIT
        public void GetByIdBadRequest()
        {
            var result = _customerController.Get(-1) as BadRequestResult;
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(BadRequestResult));
        }

        [Fact]
        public void GetByIdGoodRequest() {
            var customerToValidate = _unit.Customers.GetAll().ToList().FirstOrDefault();
            var result = _customerController.Get(customerToValidate.Id) as OkNegotiatedContentResult<Customer>;
            result.Should().NotBeNull();
            result.Content.Id.Should().Be(customerToValidate.Id);
            result.Content.City.Should().Be(customerToValidate.City);
            result.Content.Country.Should().Be(customerToValidate.Country);
            result.Content.FirstName.Should().Be(customerToValidate.FirstName);
            result.Content.LastName.Should().Be(customerToValidate.LastName);
            result.Content.Phone.Should().Be(customerToValidate.Phone);
        } 

        [Fact]
        public void GetByIdNullRequest()
        {
            var result = _customerController.Get(99999999) as OkNegotiatedContentResult<Customer>;
            result.Content.Should().BeNull();
        }

        // TEST PARA EL INSERT
        [Fact]
        public void InsertCustomerBadRequest()
        {
            var customer = new Customer();
            customer.Id = 0;
            customer.FirstName = "";
            customer.LastName = "";
            customer.City = "";
            customer.Country = "";
            customer.Phone = "";

            _customerController.ModelState.Clear();
            _customerController.ModelState.AddModelError("fakeError", "faakeError");

            var result = _customerController.Post(customer) as InvalidModelStateResult; 
            result.Should().NotBeNull();
            result.ModelState.IsValid.Should().BeFalse();
            result.ModelState.Values.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void InsertCustomerGoodRequest()
        {
            var customer = new Customer();
            customer.Id = 666;
            customer.FirstName = "PROBANDO";
            customer.LastName = "WEBAPITEST";
            customer.City = "";
            customer.Country = "";
            customer.Phone = "";
            //{Name = "OkNegotiatedContentResult`1" FullName = "System.Web.Http.Results.OkNegotiatedContentResult`1[[<>f__AnonymousType0`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], Tibox.WebApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]"}
            var result = _customerController.Post(customer) as OkNegotiatedContentResult<int>;
            result.Should().NotBeNull();

            result.Content.Should().Be(customer.Id);

        }


    }
}
