using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tibox.UnitOfWork;

namespace Tibox.Mvc.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        public ProductController(IUnitOfWork unit) : base(unit)
        {
        }

        public JsonResult Products()
        {
            var lista = _unit.Products.GetAll();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

    }
}