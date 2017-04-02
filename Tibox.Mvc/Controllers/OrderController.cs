using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tibox.Mvc.Models;
using Tibox.UnitOfWork;

namespace Tibox.Mvc.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(IUnitOfWork unit): base(unit)
        {
        }

        public ActionResult Create()
        {
            return View();
        }

        public JsonResult Save(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var id = _unit.Orders.Insert(model.Order);
                //model.OrderItems.Select(c => { c.OrderId = id; return c; }).ToList();
                //foreach (var orderItem in model.OrderItems)
                //{
                //    _unit.OrderItems.Insert(orderItem);
                //}
                _unit.Orders.SaverOrderAndOrderItems(model.Order, model.OrderItems);
                return Json("ok");
            }
            return Json("error");
        }
    }
}