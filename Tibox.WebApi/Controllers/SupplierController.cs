﻿using System.Web.Http;
using FluentValidation;
using Tibox.Models;
using Tibox.UnitOfWork;

namespace Tibox.WebApi.Controllers
{
    [RoutePrefix("supplier")]
    public class SupplierController : BaseController
    {
        private readonly AbstractValidator<Supplier> _validator;
        public SupplierController(IUnitOfWork unit) : base(unit)
        {
            //_validator = validator;
        }
        
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            if (id <= 0) return BadRequest();
            return Ok(_unit.Suppliers.GetEntityById(id));
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(Supplier supplier)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var id = _unit.Suppliers.Insert(supplier);
            //return Ok(new { id = id });}
            return Ok(id);
        }

        [Route("Put")]
        [HttpPost]
        public IHttpActionResult Put(Supplier supplier)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!_unit.Suppliers.Update(supplier)) return BadRequest("Incorrect id");
            return Ok(true);
        }

        [Route("Delete/{id}")]
        [HttpPost]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();
            var result = _unit.Suppliers.Delete(new Supplier { Id = id });
            return Ok(true);
        }
        
        [Route("list")]
        [HttpGet]
        public IHttpActionResult GetList()
        {
            return Ok(_unit.Suppliers.GetAll());
        }
    }
}