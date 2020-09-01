using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustmorReportCore.Models.Common;
using CustmorReportCore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class CustmorController : Controller
    {
        private readonly IGetData getData;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetList()
        {
            GetData gd = new GetData();
            List<Report> data = gd.GetReportPay();

            // var data = getData.GetReportPay();
            return Json(new { data = data });
        }
    }
}