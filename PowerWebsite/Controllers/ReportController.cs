using PowerWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PowerWebsite.Controllers
{
    public class ReportController : Controller
    {
        private object result;
        DateTime startTodayTime = DateTime.Today; //Today at 00:00:00
        DateTime endTodayTime = DateTime.Today.AddDays(1).AddTicks(-1); //Today at 23:59:59

        DateTime startYesterdayTime = DateTime.Today.AddDays(-1); //Today at 00:00:00
        DateTime endYesterdayTime = DateTime.Today.AddTicks(-1); //Today at 23:59:59

        DateTime? fromDate = DateTime.Now.Date;
        DateTime? toDate = DateTime.Now.Date.AddDays(1).AddTicks(-1);


        // GET: Report
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
        public ActionResult Water()
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

        // GET: Report
        public ActionResult Kenh1()
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
        public ActionResult Kenh2()
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
        public ActionResult Kenh3()
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
        public ActionResult Kenh4()
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

        public ActionResult Kenh5()
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
                if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                ViewBag.fromDate = fromDate;
                ViewBag.toDate = toDate;
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult Kenh6()
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

        [HttpGet]
        public JsonResult GetReportDataGas(int year, int month)
        {
            using (DBModel db = new DBModel())
            {
                var data = db.recoder_gas.Where(p => (p.Thoigian.Month >= month && p.Thoigian.Year == year - 1) || (p.Thoigian.Month <= month && p.Thoigian.Year == year)).Select(i => new { i.Thoigian, i.luu_luong_hien_tai })
                             .ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetReportDataWater(int year, int month)
        {
            using (DBModel db = new DBModel())
            {
                var data = db.recoder_water.Where(p => (p.Thoigian.Month >= month && p.Thoigian.Year == year - 1) || (p.Thoigian.Month <= month && p.Thoigian.Year == year)).Select(i => new { i.Thoigian, i.luu_luong_hien_tai })
                             .ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetReportDataKenh1(int year, int month)
        {
            using (DBModel db = new DBModel())
            {
                var data = db.recoder_kenh1.Where(p => (p.Thoigian.Month >= month && p.Thoigian.Year == year - 1) || (p.Thoigian.Month <= month && p.Thoigian.Year == year)).Select(i => new { i.Thoigian, i.Ptotal })
                             .ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetReportDataKenh2(int year, int month)
        {
            using (DBModel db = new DBModel())
            {
                var data = db.recoder_kenh2.Where(p => (p.Thoigian.Month >= month && p.Thoigian.Year == year - 1) || (p.Thoigian.Month <= month && p.Thoigian.Year == year)).Select(i => new { i.Thoigian, i.Ptotal })
                             .ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetReportDataKenh3(int year, int month)
        {
            using (DBModel db = new DBModel())
            {
                var data = db.recoder_kenh3.Where(p => (p.Thoigian.Month >= month && p.Thoigian.Year == year - 1) || (p.Thoigian.Month <= month && p.Thoigian.Year == year)).Select(i => new { i.Thoigian, i.Ptotal })
                             .ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetReportDataKenh4(int year, int month)
        {
            using (DBModel db = new DBModel())
            {
                var data = db.recoder_kenh4.Where(p => (p.Thoigian.Month >= month && p.Thoigian.Year == year - 1) || (p.Thoigian.Month <= month && p.Thoigian.Year == year)).Select(i => new { i.Thoigian, i.Ptotal })
                             .ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetReportDataKenh5(int year, int month)
        {
            using (DBModel db = new DBModel())
            {
                var data = db.recoder_kenh5.Where(p => (p.Thoigian.Month >= month && p.Thoigian.Year == year - 1) || (p.Thoigian.Month <= month && p.Thoigian.Year == year)).Select(i => new { i.Thoigian, i.Ptotal })
                             .ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetReportDataKenh6(int year, int month)
        {
            using (DBModel db = new DBModel())
            {
                var data = db.recoder_kenh6.Where(p => (p.Thoigian.Month >= month && p.Thoigian.Year == year - 1) || (p.Thoigian.Month <= month && p.Thoigian.Year == year)).Select(i => new { i.Thoigian, i.Ptotal })
                             .ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetReportTotalGas(int year, int month, string type)
        {
            using (DBModel db = new DBModel())
            {
                switch (type)
                {
                    case "curr_year":
                        result = db.recoder_gas
                        .Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year)
                        .GroupBy(p => p.Thoigian.Month)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "last_year":
                        result = db.recoder_gas
                        .Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 1)
                        .GroupBy(p => p.Thoigian.Month)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "curr_month":
                        result = db.recoder_gas
                        .Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= DateTime.Today.Day && p.Thoigian.Month == month)
                        .GroupBy(p => p.Thoigian.Day)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "last_month":
                        result = db.recoder_gas
                        .Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1)
                        .GroupBy(p => p.Thoigian.Day)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "today":
                        result = db.recoder_gas
                        .Where(p => p.Thoigian >= startTodayTime && p.Thoigian <= endTodayTime)
                        .GroupBy(p => p.Thoigian.Hour)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "yesterday":
                        result = db.recoder_gas
                        .Where(p => p.Thoigian >= startYesterdayTime && p.Thoigian <= endYesterdayTime)
                        .GroupBy(p => p.Thoigian.Hour)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "curr_week":
                        DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));

                        result = db.recoder_gas
                        .Where(p => p.Thoigian >= startOfWeek && p.Thoigian <= endTodayTime && (p.Thoigian.Month == startOfWeek.Month || p.Thoigian.Month == endTodayTime.Month))
                        .GroupBy(p => new { p.Thoigian.Day, p.Thoigian.Month })
                        .Select(g => new {
                            Thoigian = g.Key.Day,
                            Thang = g.Key.Month,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.Thang, x.firstValue, x.lastValue })
                        .ToList();
                        Console.WriteLine(startOfWeek);
                        break;
                    case "last_week":
                        DateTime startOfLastWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek)).AddDays(-7);
                        DateTime endOfLastWeek = startOfLastWeek.AddDays(7);
                        result = db.recoder_gas
                        .Where(p => p.Thoigian >= startOfLastWeek && p.Thoigian <= endOfLastWeek && (p.Thoigian.Month == startOfLastWeek.Month || p.Thoigian.Month == endOfLastWeek.Month))
                        .GroupBy(p => new { p.Thoigian.Day, p.Thoigian.Month })
                        .Select(g => new {
                            Thoigian = g.Key.Day,
                            Thang = g.Key.Month,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.Thang, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    default:
                        break;
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetReportTotalWater(int year, int month, string type)
        {
            using (DBModel db = new DBModel())
            {
                switch (type)
                {
                    case "curr_year":
                        result = db.recoder_water
                        .Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year)
                        .GroupBy(p => p.Thoigian.Month)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "last_year":
                        result = db.recoder_water
                        .Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 1)
                        .GroupBy(p => p.Thoigian.Month)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "curr_month":
                        result = db.recoder_water
                        .Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= DateTime.Today.Day && p.Thoigian.Month == month)
                        .GroupBy(p => p.Thoigian.Day)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "last_month":
                        result = db.recoder_water
                        .Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1)
                        .GroupBy(p => p.Thoigian.Day)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "today":
                        result = db.recoder_water
                        .Where(p => p.Thoigian >= startTodayTime && p.Thoigian <= endTodayTime)
                        .GroupBy(p => p.Thoigian.Hour)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "yesterday":
                        result = db.recoder_water
                        .Where(p => p.Thoigian >= startYesterdayTime && p.Thoigian <= endYesterdayTime)
                        .GroupBy(p => p.Thoigian.Hour)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "curr_week":
                        DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));

                        result = db.recoder_water
                        .Where(p => p.Thoigian >= startOfWeek && p.Thoigian <= endTodayTime && (p.Thoigian.Month == startOfWeek.Month || p.Thoigian.Month == endTodayTime.Month))
                        .GroupBy(p => new { p.Thoigian.Day, p.Thoigian.Month })
                        .Select(g => new {
                            Thoigian = g.Key.Day,
                            Thang = g.Key.Month,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.Thang, x.firstValue, x.lastValue })
                        .ToList();
                        Console.WriteLine(startOfWeek);
                        break;
                    case "last_week":
                        DateTime startOfLastWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek)).AddDays(-7);
                        DateTime endOfLastWeek = startOfLastWeek.AddDays(7);
                        result = db.recoder_water
                        .Where(p => p.Thoigian >= startOfLastWeek && p.Thoigian <= endOfLastWeek && (p.Thoigian.Month == startOfLastWeek.Month || p.Thoigian.Month == endOfLastWeek.Month))
                        .GroupBy(p => new { p.Thoigian.Day, p.Thoigian.Month })
                        .Select(g => new {
                            Thoigian = g.Key.Day,
                            Thang = g.Key.Month,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.Thang, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    default:
                        break;
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetReportKwhKenh1(int year, int month, string type)
        {
            using (DBModel db = new DBModel())
            {
                switch (type)
                {
                    case "curr_year":
                        result = db.recoder_kenh1
                        .Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year)
                        .GroupBy(p => p.Thoigian.Month)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "last_year":
                        result = db.recoder_kenh1
                        .Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 1)
                        .GroupBy(p => p.Thoigian.Month)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "curr_month":
                        result = db.recoder_kenh1
                        .Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= DateTime.Today.Day && p.Thoigian.Month == month)
                        .GroupBy(p => p.Thoigian.Day)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "last_month":
                        result = db.recoder_kenh1
                        .Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1)
                        .GroupBy(p => p.Thoigian.Day)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "today":
                        result = db.recoder_kenh1
                        .Where(p => p.Thoigian >= startTodayTime && p.Thoigian <= endTodayTime)
                        .GroupBy(p => p.Thoigian.Hour)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "yesterday":
                        result = db.recoder_kenh1
                        .Where(p => p.Thoigian >= startYesterdayTime && p.Thoigian <= endYesterdayTime)
                        .GroupBy(p => p.Thoigian.Hour)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "curr_week":
                        DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));

                        result = db.recoder_kenh1
                        .Where(p => p.Thoigian >= startOfWeek && p.Thoigian <= endTodayTime && (p.Thoigian.Month == startOfWeek.Month || p.Thoigian.Month == endTodayTime.Month))
                        .GroupBy(p => new { p.Thoigian.Day, p.Thoigian.Month })
                        .Select(g => new {
                            Thoigian = g.Key.Day,
                            Thang = g.Key.Month,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.Thang, x.firstValue, x.lastValue })
                        .ToList();
                        Console.WriteLine(startOfWeek);
                        break;
                    case "last_week":
                        DateTime startOfLastWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek)).AddDays(-7);
                        DateTime endOfLastWeek = startOfLastWeek.AddDays(7);
                        result = db.recoder_kenh1
                        .Where(p => p.Thoigian >= startOfLastWeek && p.Thoigian <= endOfLastWeek && (p.Thoigian.Month == startOfLastWeek.Month || p.Thoigian.Month == endOfLastWeek.Month))
                        .GroupBy(p => new { p.Thoigian.Day, p.Thoigian.Month })
                        .Select(g => new {
                            Thoigian = g.Key.Day,
                            Thang = g.Key.Month,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.Thang, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    default:
                        break;
                }
                return Json(result, JsonRequestBehavior.AllowGet);
           }
        }

        [HttpGet]
        public JsonResult GetReportKwhKenh2(int year, int month, string type)
        {
            using (DBModel db = new DBModel())
            {
                switch (type)
                {
                    case "curr_year":
                        result = db.recoder_kenh2
                        .Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year)
                        .GroupBy(p => p.Thoigian.Month)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "last_year":
                        result = db.recoder_kenh2
                        .Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 1)
                        .GroupBy(p => p.Thoigian.Month)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "curr_month":
                        result = db.recoder_kenh2
                        .Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= DateTime.Today.Day && p.Thoigian.Month == month)
                        .GroupBy(p => p.Thoigian.Day)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "last_month":
                        result = db.recoder_kenh2
                        .Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1)
                        .GroupBy(p => p.Thoigian.Day)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "today":
                        result = db.recoder_kenh2
                        .Where(p => p.Thoigian >= startTodayTime && p.Thoigian <= endTodayTime)
                        .GroupBy(p => p.Thoigian.Hour)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "yesterday":
                        result = db.recoder_kenh2
                        .Where(p => p.Thoigian >= startYesterdayTime && p.Thoigian <= endYesterdayTime)
                        .GroupBy(p => p.Thoigian.Hour)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "curr_week":
                        DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));

                        result = db.recoder_kenh2
                        .Where(p => p.Thoigian >= startOfWeek && p.Thoigian <= endTodayTime && (p.Thoigian.Month == startOfWeek.Month || p.Thoigian.Month == endTodayTime.Month))
                        .GroupBy(p => new { p.Thoigian.Day, p.Thoigian.Month })
                        .Select(g => new {
                            Thoigian = g.Key.Day,
                            Thang = g.Key.Month,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.Thang, x.firstValue, x.lastValue })
                        .ToList();
                        Console.WriteLine(startOfWeek);
                        break;
                    case "last_week":
                        DateTime startOfLastWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek)).AddDays(-7);
                        DateTime endOfLastWeek = startOfLastWeek.AddDays(7);
                        result = db.recoder_kenh2
                        .Where(p => p.Thoigian >= startOfLastWeek && p.Thoigian <= endOfLastWeek && (p.Thoigian.Month == startOfLastWeek.Month || p.Thoigian.Month == endOfLastWeek.Month))
                        .GroupBy(p => new { p.Thoigian.Day, p.Thoigian.Month })
                        .Select(g => new {
                            Thoigian = g.Key.Day,
                            Thang = g.Key.Month,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.Thang, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    default:
                        break;
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetReportKwhKenh3(int year, int month, string type)
        {
            using (DBModel db = new DBModel())
            {
                switch (type)
                {
                    case "curr_year":
                        result = db.recoder_kenh3
                        .Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year)
                        .GroupBy(p => p.Thoigian.Month)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "last_year":
                        result = db.recoder_kenh3
                        .Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 1)
                        .GroupBy(p => p.Thoigian.Month)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "curr_month":
                        result = db.recoder_kenh3
                        .Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= DateTime.Today.Day && p.Thoigian.Month == month)
                        .GroupBy(p => p.Thoigian.Day)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "last_month":
                        result = db.recoder_kenh3
                        .Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1)
                        .GroupBy(p => p.Thoigian.Day)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "today":
                        result = db.recoder_kenh3
                        .Where(p => p.Thoigian >= startTodayTime && p.Thoigian <= endTodayTime)
                        .GroupBy(p => p.Thoigian.Hour)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "yesterday":
                        result = db.recoder_kenh3
                        .Where(p => p.Thoigian >= startYesterdayTime && p.Thoigian <= endYesterdayTime)
                        .GroupBy(p => p.Thoigian.Hour)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "curr_week":
                        DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));

                        result = db.recoder_kenh3
                        .Where(p => p.Thoigian >= startOfWeek && p.Thoigian <= endTodayTime && (p.Thoigian.Month == startOfWeek.Month || p.Thoigian.Month == endTodayTime.Month))
                        .GroupBy(p => new { p.Thoigian.Day, p.Thoigian.Month })
                        .Select(g => new {
                            Thoigian = g.Key.Day,
                            Thang = g.Key.Month,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.Thang, x.firstValue, x.lastValue })
                        .ToList();
                        Console.WriteLine(startOfWeek);
                        break;
                    case "last_week":
                        DateTime startOfLastWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek)).AddDays(-7);
                        DateTime endOfLastWeek = startOfLastWeek.AddDays(7);
                        result = db.recoder_kenh3
                        .Where(p => p.Thoigian >= startOfLastWeek && p.Thoigian <= endOfLastWeek && (p.Thoigian.Month == startOfLastWeek.Month || p.Thoigian.Month == endOfLastWeek.Month))
                        .GroupBy(p => new { p.Thoigian.Day, p.Thoigian.Month })
                        .Select(g => new {
                            Thoigian = g.Key.Day,
                            Thang = g.Key.Month,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.Thang, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    default:
                        break;
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetReportKwhKenh4(int year, int month, string type)
        {
            using (DBModel db = new DBModel())
            {
                switch (type)
                {
                    case "curr_year":
                        result = db.recoder_kenh4
                        .Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year)
                        .GroupBy(p => p.Thoigian.Month)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "last_year":
                        result = db.recoder_kenh4
                        .Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 1)
                        .GroupBy(p => p.Thoigian.Month)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "curr_month":
                        result = db.recoder_kenh4
                        .Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= DateTime.Today.Day && p.Thoigian.Month == month)
                        .GroupBy(p => p.Thoigian.Day)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "last_month":
                        result = db.recoder_kenh4
                        .Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1)
                        .GroupBy(p => p.Thoigian.Day)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "today":
                        result = db.recoder_kenh4
                        .Where(p => p.Thoigian >= startTodayTime && p.Thoigian <= endTodayTime)
                        .GroupBy(p => p.Thoigian.Hour)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "yesterday":
                        result = db.recoder_kenh4
                        .Where(p => p.Thoigian >= startYesterdayTime && p.Thoigian <= endYesterdayTime)
                        .GroupBy(p => p.Thoigian.Hour)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "curr_week":
                        DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));

                        result = db.recoder_kenh4
                        .Where(p => p.Thoigian >= startOfWeek && p.Thoigian <= endTodayTime && (p.Thoigian.Month == startOfWeek.Month || p.Thoigian.Month == endTodayTime.Month))
                        .GroupBy(p => new { p.Thoigian.Day, p.Thoigian.Month })
                        .Select(g => new {
                            Thoigian = g.Key.Day,
                            Thang = g.Key.Month,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.Thang, x.firstValue, x.lastValue })
                        .ToList();
                        Console.WriteLine(startOfWeek);
                        break;
                    case "last_week":
                        DateTime startOfLastWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek)).AddDays(-7);
                        DateTime endOfLastWeek = startOfLastWeek.AddDays(7);
                        result = db.recoder_kenh4
                        .Where(p => p.Thoigian >= startOfLastWeek && p.Thoigian <= endOfLastWeek && (p.Thoigian.Month == startOfLastWeek.Month || p.Thoigian.Month == endOfLastWeek.Month))
                        .GroupBy(p => new { p.Thoigian.Day, p.Thoigian.Month })
                        .Select(g => new {
                            Thoigian = g.Key.Day,
                            Thang = g.Key.Month,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.Thang, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    default:
                        break;
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetReportKwhKenh5(int year, int month, string type)
        {
            using (DBModel db = new DBModel())
            {
                switch (type)
                {
                    case "curr_year":
                        result = db.recoder_kenh5
                        .Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year)
                        .GroupBy(p => p.Thoigian.Month)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "last_year":
                        result = db.recoder_kenh5
                        .Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 1)
                        .GroupBy(p => p.Thoigian.Month)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "curr_month":
                        result = db.recoder_kenh5
                        .Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= DateTime.Today.Day && p.Thoigian.Month == month)
                        .GroupBy(p => p.Thoigian.Day)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "last_month":
                        result = db.recoder_kenh5
                        .Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1)
                        .GroupBy(p => p.Thoigian.Day)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "today":
                        result = db.recoder_kenh5
                        .Where(p => p.Thoigian >= startTodayTime && p.Thoigian <= endTodayTime)
                        .GroupBy(p => p.Thoigian.Hour)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "yesterday":
                        result = db.recoder_kenh5
                        .Where(p => p.Thoigian >= startYesterdayTime && p.Thoigian <= endYesterdayTime)
                        .GroupBy(p => p.Thoigian.Hour)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "curr_week":
                        DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));

                        result = db.recoder_kenh5
                        .Where(p => p.Thoigian >= startOfWeek && p.Thoigian <= endTodayTime && (p.Thoigian.Month == startOfWeek.Month || p.Thoigian.Month == endTodayTime.Month))
                        .GroupBy(p => new { p.Thoigian.Day, p.Thoigian.Month })
                        .Select(g => new {
                            Thoigian = g.Key.Day,
                            Thang = g.Key.Month,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.Thang, x.firstValue, x.lastValue })
                        .ToList();
                        Console.WriteLine(startOfWeek);
                        break;
                    case "last_week":
                        DateTime startOfLastWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek)).AddDays(-7);
                        DateTime endOfLastWeek = startOfLastWeek.AddDays(7);
                        result = db.recoder_kenh5
                        .Where(p => p.Thoigian >= startOfLastWeek && p.Thoigian <= endOfLastWeek && (p.Thoigian.Month == startOfLastWeek.Month || p.Thoigian.Month == endOfLastWeek.Month))
                        .GroupBy(p => new { p.Thoigian.Day, p.Thoigian.Month })
                        .Select(g => new {
                            Thoigian = g.Key.Day,
                            Thang = g.Key.Month,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.Thang, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    default:
                        break;
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetReportKwhKenh6(int year, int month, string type)
        {
            using (DBModel db = new DBModel())
            {
                switch (type)
                {
                    case "curr_year":
                        result = db.recoder_kenh6
                        .Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year)
                        .GroupBy(p => p.Thoigian.Month)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "last_year":
                        result = db.recoder_kenh6
                        .Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 1)
                        .GroupBy(p => p.Thoigian.Month)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "curr_month":
                        result = db.recoder_kenh6
                        .Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= DateTime.Today.Day && p.Thoigian.Month == month)
                        .GroupBy(p => p.Thoigian.Day)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "last_month":
                        result = db.recoder_kenh6
                        .Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1)
                        .GroupBy(p => p.Thoigian.Day)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "today":
                        result = db.recoder_kenh6
                        .Where(p => p.Thoigian >= startTodayTime && p.Thoigian <= endTodayTime)
                        .GroupBy(p => p.Thoigian.Hour)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "yesterday":
                        result = db.recoder_kenh6
                        .Where(p => p.Thoigian >= startYesterdayTime && p.Thoigian <= endYesterdayTime)
                        .GroupBy(p => p.Thoigian.Hour)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    case "curr_week":
                        DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));

                        result = db.recoder_kenh6
                        .Where(p => p.Thoigian >= startOfWeek && p.Thoigian <= endTodayTime && (p.Thoigian.Month == startOfWeek.Month || p.Thoigian.Month == endTodayTime.Month))
                        .GroupBy(p => new { p.Thoigian.Day, p.Thoigian.Month })
                        .Select(g => new {
                            Thoigian = g.Key.Day,
                            Thang = g.Key.Month,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.Thang, x.firstValue, x.lastValue })
                        .ToList();
                        Console.WriteLine(startOfWeek);
                        break;
                    case "last_week":
                        DateTime startOfLastWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek)).AddDays(-7);
                        DateTime endOfLastWeek = startOfLastWeek.AddDays(7);
                        result = db.recoder_kenh6
                        .Where(p => p.Thoigian >= startOfLastWeek && p.Thoigian <= endOfLastWeek && (p.Thoigian.Month == startOfLastWeek.Month || p.Thoigian.Month == endOfLastWeek.Month))
                        .GroupBy(p => new { p.Thoigian.Day, p.Thoigian.Month })
                        .Select(g => new {
                            Thoigian = g.Key.Day,
                            Thang = g.Key.Month,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                        })
                        .Select(x => new { x.Thoigian, x.Thang, x.firstValue, x.lastValue })
                        .ToList();
                        break;
                    default:
                        break;
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }


    }
}