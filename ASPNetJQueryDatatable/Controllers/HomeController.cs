using ASPNetJQueryDatatable.Models;
using ASPNetJQueryDatatable.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNetJQueryDatatable.Controllers
{
    public class HomeController : Controller
    {
        DatatableService _srv;
        public HomeController()
        {
            _srv = new DatatableService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult loadCustomers()
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var model = _srv.GetCustomers();

            recordsTotal = model.Count();


            var data = model.OrderBy(x => x.CUST_CODE).Skip(skip).Take(pageSize);

            return Json(new
            {
                draw = draw,
                recordsFiltered = recordsTotal,
                recordsTotal = recordsTotal,
                data = data
            }, JsonRequestBehavior.AllowGet);
        }
    }
}