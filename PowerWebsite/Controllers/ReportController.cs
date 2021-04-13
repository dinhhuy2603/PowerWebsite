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
        public JsonResult GetReportDataKenh1(int year, int month)
        {
            var minDate = DateTime.Now.AddMonths(-3);
            using (DBModel db = new DBModel())
            {
                var data = db.recoder_kenh1.Where(p => p.Thoigian > minDate).Select(i => new { i.Thoigian, i.Ptotal })
                             .ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetReportDataKenh2(int year, int month)
        {
            var minDate = DateTime.Now.AddMonths(-3);
            using (DBModel db = new DBModel())
            {
                var data = db.recoder_kenh2.Where(p => p.Thoigian > minDate).Select(i => new { i.Thoigian, i.Ptotal })
                             .ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetReportDataKenh3(int year, int month)
        {
            var minDate = DateTime.Now.AddMonths(-3);
            using (DBModel db = new DBModel())
            {
                var data = db.recoder_kenh3.Where(p => p.Thoigian > minDate).Select(i => new { i.Thoigian, i.Ptotal })
                             .ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetReportDataKenh4(int year, int month)
        {
            var minDate = DateTime.Now.AddMonths(-3);
            using (DBModel db = new DBModel())
            {
                var data = db.recoder_kenh4.Where(p => p.Thoigian > minDate).Select(i => new { i.Thoigian, i.Ptotal })
                             .ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetReportDataKenh5(int year, int month)
        {
            var minDate = DateTime.Now.AddMonths(-3);
            using (DBModel db = new DBModel())
            {
                var data = db.recoder_kenh5.Where(p => p.Thoigian > minDate).Select(i => new { i.Thoigian, i.Ptotal })
                             .ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetReportDataKenh6(int year, int month)
        {
            var minDate = DateTime.Now.AddMonths(-3);
            using (DBModel db = new DBModel())
            {
                var data = db.recoder_kenh6.Where(p => p.Thoigian > minDate).Select(i => new { i.Thoigian, i.Ptotal })
                             .ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }        

        [HttpGet]
        public JsonResult GetReportKwhKenh1(int year, int month, string type)
        {
            var data = new List<object>();
            var first_value = new object();
            using (DBModel db = new DBModel())
            {
                //var result = new List<Result>();
                switch (type)
                {
                    case "curr_year":
                        first_value = db.recoder_kenh1.Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 1).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "last_year":
                        first_value = db.recoder_kenh1.Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 2).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "curr_month":
                        first_value = db.recoder_kenh1.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "last_month":
                        IQueryable<Recoder_DongHo1> query1 = db.recoder_kenh1;
                        IQueryable<Recoder_DongHo1> query2 = db.recoder_kenh1;
                        int last_2_month;
                        if (month > 2)
                        {
                            query1 = query1.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 2 && p.Thoigian.Year == year);
                        }
                        else
                        {
                            if (month == 2)
                            {
                                last_2_month = 12;
                            }
                            else
                            {
                                last_2_month = 11;
                            }
                            query1 = query1.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == last_2_month && p.Thoigian.Year == year - 1);
                        }
                        first_value = query1.OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        if (month == 1)
                        {
                            query2 = query2.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == 12 && p.Thoigian.Year == year - 1);
                        }
                        else
                        {
                            query2 = query2.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1 && p.Thoigian.Year == year);
                        }
                        result = query2.GroupBy(p => p.Thoigian.Day)
                            .Select(g => new
                            {
                                Thoigian = g.Key,
                                firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                                lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                            })
                            .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                            .ToList();
                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "today":

                        first_value = db.recoder_kenh1.Where(p => p.Thoigian >= startYesterdayTime && p.Thoigian <= endYesterdayTime).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        //var data = new List<object>();
                        data.Add(result);
                        data.Add(first_value);

                        result = data;
                        break;
                    case "yesterday":
                        DateTime beforeYesterdayStart = startYesterdayTime.AddDays(-1);
                        DateTime beforeYesterdayEnd = endYesterdayTime.AddDays(-1);
                        first_value = db.recoder_kenh1.Where(p => p.Thoigian >= beforeYesterdayStart && p.Thoigian <= beforeYesterdayEnd).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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


                        data.Add(result);
                        data.Add(first_value);

                        result = data;
                        break;
                    case "curr_week":
                        DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));
                        DateTime beforeStartOfWeek = startOfWeek.AddDays(-1);
                        DateTime endBeforeStartOfWeek = startOfWeek.AddTicks(-1);

                        first_value = db.recoder_kenh1.Where(p => p.Thoigian >= beforeStartOfWeek && p.Thoigian <= endBeforeStartOfWeek).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();


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

                        data.Add(result);
                        data.Add(first_value);

                        result = data;
                        break;
                    case "last_week":
                        DateTime startOfLastWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek)).AddDays(-7);
                        DateTime endOfLastWeek = startOfLastWeek.AddDays(7);
                        DateTime startOfBeforeLastWeek = startOfLastWeek.AddDays(-1);
                        DateTime endOfBeforeLastWeek = startOfLastWeek.AddTicks(-1);
                        first_value = db.recoder_kenh1.Where(p => p.Thoigian >= startOfBeforeLastWeek && p.Thoigian <= endOfBeforeLastWeek).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);

                        result = data;

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
            var data = new List<object>();
            var first_value = new object();
            using (DBModel db = new DBModel())
            {
                //var result = new List<Result>();
                switch (type)
                {
                    case "curr_year":
                        first_value = db.recoder_kenh2.Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 1).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "last_year":
                        first_value = db.recoder_kenh2.Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 2).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "curr_month":
                        first_value = db.recoder_kenh2.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "last_month":
                        IQueryable<Recoder_DongHo2> query1 = db.recoder_kenh2;
                        IQueryable<Recoder_DongHo2> query2 = db.recoder_kenh2;
                        int last_2_month;
                        if (month > 2)
                        {
                            query1 = query1.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 2 && p.Thoigian.Year == year);
                        }
                        else
                        {
                            if (month == 2)
                            {
                                last_2_month = 12;
                            }
                            else
                            {
                                last_2_month = 11;
                            }
                            query1 = query1.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == last_2_month && p.Thoigian.Year == year - 1);
                        }
                        first_value = query1.OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        if (month == 1)
                        {
                            query2 = query2.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == 12 && p.Thoigian.Year == year - 1);
                        }
                        else
                        {
                            query2 = query2.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1 && p.Thoigian.Year == year);
                        }
                        result = query2.GroupBy(p => p.Thoigian.Day)
                            .Select(g => new
                            {
                                Thoigian = g.Key,
                                firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                                lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                            })
                            .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                            .ToList();
                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "today":

                        first_value = db.recoder_kenh2.Where(p => p.Thoigian >= startYesterdayTime && p.Thoigian <= endYesterdayTime).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        //var data = new List<object>();
                        data.Add(result);
                        data.Add(first_value);

                        result = data;
                        break;
                    case "yesterday":
                        DateTime beforeYesterdayStart = startYesterdayTime.AddDays(-1);
                        DateTime beforeYesterdayEnd = endYesterdayTime.AddDays(-1);
                        first_value = db.recoder_kenh2.Where(p => p.Thoigian >= beforeYesterdayStart && p.Thoigian <= beforeYesterdayEnd).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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


                        data.Add(result);
                        data.Add(first_value);

                        result = data;
                        break;
                    case "curr_week":
                        DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));
                        DateTime beforeStartOfWeek = startOfWeek.AddDays(-1);
                        DateTime endBeforeStartOfWeek = startOfWeek.AddTicks(-1);

                        first_value = db.recoder_kenh2.Where(p => p.Thoigian >= beforeStartOfWeek && p.Thoigian <= endBeforeStartOfWeek).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();


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

                        data.Add(result);
                        data.Add(first_value);

                        result = data;
                        break;
                    case "last_week":
                        DateTime startOfLastWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek)).AddDays(-7);
                        DateTime endOfLastWeek = startOfLastWeek.AddDays(7);
                        DateTime startOfBeforeLastWeek = startOfLastWeek.AddDays(-1);
                        DateTime endOfBeforeLastWeek = startOfLastWeek.AddTicks(-1);
                        first_value = db.recoder_kenh2.Where(p => p.Thoigian >= startOfBeforeLastWeek && p.Thoigian <= endOfBeforeLastWeek).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);

                        result = data;

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
            var data = new List<object>();
            var first_value = new object();
            using (DBModel db = new DBModel())
            {
                //var result = new List<Result>();
                switch (type)
                {
                    case "curr_year":
                        first_value = db.recoder_kenh3.Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 1).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "last_year":
                        first_value = db.recoder_kenh3.Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 2).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "curr_month":
                        first_value = db.recoder_kenh3.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "last_month":
                        IQueryable<Recoder_DongHo3> query1 = db.recoder_kenh3;
                        IQueryable<Recoder_DongHo3> query2 = db.recoder_kenh3;
                        int last_2_month;
                        if (month > 2)
                        {
                            query1 = query1.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 2 && p.Thoigian.Year == year);
                        }
                        else
                        {
                            if (month == 2)
                            {
                                last_2_month = 12;
                            }
                            else
                            {
                                last_2_month = 11;
                            }
                            query1 = query1.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == last_2_month && p.Thoigian.Year == year - 1);
                        }
                        first_value = query1.OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        if (month == 1)
                        {
                            query2 = query2.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == 12 && p.Thoigian.Year == year - 1);
                        }
                        else
                        {
                            query2 = query2.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1 && p.Thoigian.Year == year);
                        }
                        result = query2.GroupBy(p => p.Thoigian.Day)
                            .Select(g => new
                            {
                                Thoigian = g.Key,
                                firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                                lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                            })
                            .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                            .ToList();
                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "today":

                        first_value = db.recoder_kenh3.Where(p => p.Thoigian >= startYesterdayTime && p.Thoigian <= endYesterdayTime).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        //var data = new List<object>();
                        data.Add(result);
                        data.Add(first_value);

                        result = data;
                        break;
                    case "yesterday":
                        DateTime beforeYesterdayStart = startYesterdayTime.AddDays(-1);
                        DateTime beforeYesterdayEnd = endYesterdayTime.AddDays(-1);
                        first_value = db.recoder_kenh3.Where(p => p.Thoigian >= beforeYesterdayStart && p.Thoigian <= beforeYesterdayEnd).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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


                        data.Add(result);
                        data.Add(first_value);

                        result = data;
                        break;
                    case "curr_week":
                        DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));
                        DateTime beforeStartOfWeek = startOfWeek.AddDays(-1);
                        DateTime endBeforeStartOfWeek = startOfWeek.AddTicks(-1);

                        first_value = db.recoder_kenh3.Where(p => p.Thoigian >= beforeStartOfWeek && p.Thoigian <= endBeforeStartOfWeek).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();


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

                        data.Add(result);
                        data.Add(first_value);

                        result = data;
                        break;
                    case "last_week":
                        DateTime startOfLastWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek)).AddDays(-7);
                        DateTime endOfLastWeek = startOfLastWeek.AddDays(7);
                        DateTime startOfBeforeLastWeek = startOfLastWeek.AddDays(-1);
                        DateTime endOfBeforeLastWeek = startOfLastWeek.AddTicks(-1);
                        first_value = db.recoder_kenh3.Where(p => p.Thoigian >= startOfBeforeLastWeek && p.Thoigian <= endOfBeforeLastWeek).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);

                        result = data;

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
            var data = new List<object>();
            var first_value = new object();
            using (DBModel db = new DBModel())
            {
                switch (type)
                {
                    case "curr_year":
                        first_value = db.recoder_kenh4.Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 1).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "last_year":
                        first_value = db.recoder_kenh4.Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 2).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "curr_month":
                        first_value = db.recoder_kenh4.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "last_month":
                        IQueryable<Recoder_DongHo4> query1 = db.recoder_kenh4;
                        IQueryable<Recoder_DongHo4> query2 = db.recoder_kenh4;
                        int last_2_month;
                        if (month > 2)
                        {
                            query1 = query1.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 2 && p.Thoigian.Year == year);
                        }
                        else
                        {
                            if (month == 2)
                            {
                                last_2_month = 12;
                            }
                            else
                            {
                                last_2_month = 11;
                            }
                            query1 = query1.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == last_2_month && p.Thoigian.Year == year - 1);
                        }
                        first_value = query1.OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        if (month == 1)
                        {
                            query2 = query2.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == 12 && p.Thoigian.Year == year - 1);
                        }
                        else
                        {
                            query2 = query2.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1 && p.Thoigian.Year == year);
                        }
                        result = query2.GroupBy(p => p.Thoigian.Day)
                            .Select(g => new
                            {
                                Thoigian = g.Key,
                                firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                                lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                            })
                            .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                            .ToList();
                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "today":

                        first_value = db.recoder_kenh4.Where(p => p.Thoigian >= startYesterdayTime && p.Thoigian <= endYesterdayTime).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        //var data = new List<object>();
                        data.Add(result);
                        data.Add(first_value);

                        result = data;
                        break;
                    case "yesterday":
                        DateTime beforeYesterdayStart = startYesterdayTime.AddDays(-1);
                        DateTime beforeYesterdayEnd = endYesterdayTime.AddDays(-1);
                        first_value = db.recoder_kenh4.Where(p => p.Thoigian >= beforeYesterdayStart && p.Thoigian <= beforeYesterdayEnd).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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


                        data.Add(result);
                        data.Add(first_value);

                        result = data;
                        break;
                    case "curr_week":
                        DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));
                        DateTime beforeStartOfWeek = startOfWeek.AddDays(-1);
                        DateTime endBeforeStartOfWeek = startOfWeek.AddTicks(-1);

                        first_value = db.recoder_kenh4.Where(p => p.Thoigian >= beforeStartOfWeek && p.Thoigian <= endBeforeStartOfWeek).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();


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

                        data.Add(result);
                        data.Add(first_value);

                        result = data;
                        break;
                    case "last_week":
                        DateTime startOfLastWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek)).AddDays(-7);
                        DateTime endOfLastWeek = startOfLastWeek.AddDays(7);
                        DateTime startOfBeforeLastWeek = startOfLastWeek.AddDays(-1);
                        DateTime endOfBeforeLastWeek = startOfLastWeek.AddTicks(-1);
                        first_value = db.recoder_kenh4.Where(p => p.Thoigian >= startOfBeforeLastWeek && p.Thoigian <= endOfBeforeLastWeek).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);

                        result = data;

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
            var data = new List<object>();
            var first_value = new object();
            using (DBModel db = new DBModel())
            {
                //var result = new List<Result>();
                switch (type)
                {
                    case "curr_year":
                        first_value = db.recoder_kenh5.Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 1).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "last_year":
                        first_value = db.recoder_kenh5.Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 2).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "curr_month":
                        first_value = db.recoder_kenh5.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "last_month":
                        IQueryable<Recoder_DongHo5> query1 = db.recoder_kenh5;
                        IQueryable<Recoder_DongHo5> query2 = db.recoder_kenh5;
                        int last_2_month;
                        if (month > 2)
                        {
                            query1 = query1.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 2 && p.Thoigian.Year == year);
                        }
                        else
                        {
                            if (month == 2)
                            {
                                last_2_month = 12;
                            }
                            else
                            {
                                last_2_month = 11;
                            }
                            query1 = query1.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == last_2_month && p.Thoigian.Year == year - 1);
                        }
                        first_value = query1.OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        if (month == 1)
                        {
                            query2 = query2.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == 12 && p.Thoigian.Year == year - 1);
                        }
                        else
                        {
                            query2 = query2.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1 && p.Thoigian.Year == year);
                        }
                        result = query2.GroupBy(p => p.Thoigian.Day)
                            .Select(g => new
                            {
                                Thoigian = g.Key,
                                firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                                lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                            })
                            .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                            .ToList();
                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "today":

                        first_value = db.recoder_kenh5.Where(p => p.Thoigian >= startYesterdayTime && p.Thoigian <= endYesterdayTime).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        //var data = new List<object>();
                        data.Add(result);
                        data.Add(first_value);

                        result = data;
                        break;
                    case "yesterday":
                        DateTime beforeYesterdayStart = startYesterdayTime.AddDays(-1);
                        DateTime beforeYesterdayEnd = endYesterdayTime.AddDays(-1);
                        first_value = db.recoder_kenh1.Where(p => p.Thoigian >= beforeYesterdayStart && p.Thoigian <= beforeYesterdayEnd).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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


                        data.Add(result);
                        data.Add(first_value);

                        result = data;
                        break;
                    case "curr_week":
                        DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));
                        DateTime beforeStartOfWeek = startOfWeek.AddDays(-1);
                        DateTime endBeforeStartOfWeek = startOfWeek.AddTicks(-1);

                        first_value = db.recoder_kenh5.Where(p => p.Thoigian >= beforeStartOfWeek && p.Thoigian <= endBeforeStartOfWeek).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();


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

                        data.Add(result);
                        data.Add(first_value);

                        result = data;
                        break;
                    case "last_week":
                        DateTime startOfLastWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek)).AddDays(-7);
                        DateTime endOfLastWeek = startOfLastWeek.AddDays(7);
                        DateTime startOfBeforeLastWeek = startOfLastWeek.AddDays(-1);
                        DateTime endOfBeforeLastWeek = startOfLastWeek.AddTicks(-1);
                        first_value = db.recoder_kenh5.Where(p => p.Thoigian >= startOfBeforeLastWeek && p.Thoigian <= endOfBeforeLastWeek).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);

                        result = data;

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
            var data = new List<object>();
            var first_value = new object();
            using (DBModel db = new DBModel())
            {
                //var result = new List<Result>();
                switch (type)
                {
                    case "curr_year":
                        first_value = db.recoder_kenh6.Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 1).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "last_year":
                        first_value = db.recoder_kenh6.Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 2).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "curr_month":
                        first_value = db.recoder_kenh6.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "last_month":
                        IQueryable<Recoder_DongHo6> query1 = db.recoder_kenh6;
                        IQueryable<Recoder_DongHo6> query2 = db.recoder_kenh6;
                        int last_2_month;
                        if (month > 2)
                        {
                            query1 = query1.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 2 && p.Thoigian.Year == year);
                        }
                        else
                        {
                            if (month == 2)
                            {
                                last_2_month = 12;
                            }
                            else
                            {
                                last_2_month = 11;
                            }
                            query1 = query1.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == last_2_month && p.Thoigian.Year == year - 1);
                        }
                        first_value = query1.OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        if (month == 1)
                        {
                            query2 = query2.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == 12 && p.Thoigian.Year == year - 1);
                        }
                        else
                        {
                            query2 = query2.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1 && p.Thoigian.Year == year);
                        }
                        result = query2.GroupBy(p => p.Thoigian.Day)
                            .Select(g => new
                            {
                                Thoigian = g.Key,
                                firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().Kwh,
                                lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().Kwh
                            })
                            .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                            .ToList();
                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "today":

                        first_value = db.recoder_kenh6.Where(p => p.Thoigian >= startYesterdayTime && p.Thoigian <= endYesterdayTime).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        //var data = new List<object>();
                        data.Add(result);
                        data.Add(first_value);

                        result = data;
                        break;
                    case "yesterday":
                        DateTime beforeYesterdayStart = startYesterdayTime.AddDays(-1);
                        DateTime beforeYesterdayEnd = endYesterdayTime.AddDays(-1);
                        first_value = db.recoder_kenh6.Where(p => p.Thoigian >= beforeYesterdayStart && p.Thoigian <= beforeYesterdayEnd).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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


                        data.Add(result);
                        data.Add(first_value);

                        result = data;
                        break;
                    case "curr_week":
                        DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));
                        DateTime beforeStartOfWeek = startOfWeek.AddDays(-1);
                        DateTime endBeforeStartOfWeek = startOfWeek.AddTicks(-1);

                        first_value = db.recoder_kenh6.Where(p => p.Thoigian >= beforeStartOfWeek && p.Thoigian <= endBeforeStartOfWeek).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();


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

                        data.Add(result);
                        data.Add(first_value);

                        result = data;
                        break;
                    case "last_week":
                        DateTime startOfLastWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek)).AddDays(-7);
                        DateTime endOfLastWeek = startOfLastWeek.AddDays(7);
                        DateTime startOfBeforeLastWeek = startOfLastWeek.AddDays(-1);
                        DateTime endOfBeforeLastWeek = startOfLastWeek.AddTicks(-1);
                        first_value = db.recoder_kenh6.Where(p => p.Thoigian >= startOfBeforeLastWeek && p.Thoigian <= endOfBeforeLastWeek).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

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

                        data.Add(result);
                        data.Add(first_value);

                        result = data;

                        break;
                    default:
                        break;
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
    }
}