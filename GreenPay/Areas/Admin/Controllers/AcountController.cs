using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenPay.Areas.Admin.Controllers
{
    [Authorize]
    public class AcountController : Controller
    {
        // GET: Admin/Acount
        public ActionResult Index()
        {
            return View();
        }
    }
}