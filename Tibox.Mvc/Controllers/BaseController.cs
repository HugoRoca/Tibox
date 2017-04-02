using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tibox.UnitOfWork;

namespace Tibox.Mvc.Controllers
{
    [HandleError]
    public class BaseController : Controller
    {
        // GET: Base

        protected readonly IUnitOfWork _unit;

        public BaseController(IUnitOfWork unit)
        {
            _unit = unit;
        }

    }
}