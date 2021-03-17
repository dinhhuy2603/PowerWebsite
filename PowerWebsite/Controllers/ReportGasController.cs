using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PowerWebsite.Controllers
{
    public class ReportGasController : Controller
    {
        private object result;
        DateTime startTodayTime = DateTime.Today; //Today at 00:00:00
        DateTime endTodayTime = DateTime.Today.AddDays(1).AddTicks(-1); //Today at 23:59:59

        DateTime startYesterdayTime = DateTime.Today.AddDays(-1); //Today at 00:00:00
        DateTime endYesterdayTime = DateTime.Today.AddTicks(-1); //Today at 23:59:59

        DateTime? fromDate = DateTime.Now.Date;
        DateTime? toDate = DateTime.Now.Date.AddDays(1).AddTicks(-1);
        // GET: ReportGas
        public ActionResult Gas()
        {
            if (Session["UserID"] != null)
            {
                if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                ViewBag.fromDate = fromDate;
                ViewBag.toDate = toDate;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult Gas()
        {
            if (Session["UserID"] != null)
            {
                if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                ViewBag.fromDate = fromDate;
                ViewBag.toDate = toDate;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}