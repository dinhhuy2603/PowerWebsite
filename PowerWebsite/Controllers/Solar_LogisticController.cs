using PowerWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PowerWebsite.Controllers
{
    public class Solar_LogisticController : Controller
    {
        private object result;
        DateTime startTodayTime = DateTime.Today; //Today at 00:00:00
        DateTime endTodayTime = DateTime.Today.AddDays(1).AddTicks(-1); //Today at 23:59:59

        DateTime startYesterdayTime = DateTime.Today.AddDays(-1); //Today at 00:00:00
        DateTime endYesterdayTime = DateTime.Today.AddTicks(-1); //Today at 23:59:59

        DateTime? fromDate = DateTime.Now.Date;
        DateTime? toDate = DateTime.Now.Date.AddDays(1).AddTicks(-1);
        // GET: Solar_Logistic
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Solar1()
        {
            if (Session["UserID"] != null)
            {
                using (DBModel db = new DBModel())
                {
                    ViewBag.solar1 = new Hienthi1View();
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult Solar2()
        {
            if (Session["UserID"] != null)
            {
                using (DBModel db = new DBModel())
                {
                    ViewBag.solar2 = new Hienthi1View();
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult Logistic()
        {
            if (Session["UserID"] != null)
            {
                using (DBModel db = new DBModel())
                {
                    ViewBag.logistic = new Hienthi1View();
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // REPORT VIEW
        [Route("Report/Solar1")]
        public ActionResult Solar1Report()
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

        [Route("Report/Solar2")]
        public ActionResult Solar2Report()
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

        [Route("Report/Logistics")]
        public ActionResult LogisticReport()
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
        public JsonResult GetChartSolar1DataOnline()
        {
            using (DBModel db = new DBModel())
            {
                var solar1 = db.hienthi1.Where(a => a.Kenh.Equals("1")).FirstOrDefault();
                var recoder1_solar1_begin = db.recoder1_db_solar1.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var solar1_view = new Hienthi1View();
                if (solar1 != null)
                {
                    var solar1_Kwh_last = (recoder1_solar1_begin != null) ? recoder1_solar1_begin.Kwh : "0";
                    solar1_view.Vca = ((float)Math.Round(float.Parse(solar1.Vca) * 10f) / 10f).ToString();
                    solar1_view.Vbc = ((float)Math.Round(float.Parse(solar1.Vbc) * 10f) / 10f).ToString();
                    solar1_view.Vab = ((float)Math.Round(float.Parse(solar1.Vab) * 10f) / 10f).ToString();
                    solar1_view.Vun = ((float)Math.Round(float.Parse(solar1.Vun) * 10f) / 10f).ToString();
                    solar1_view.VII = ((float)Math.Round(float.Parse(solar1.VII) * 10f) / 10f).ToString();
                    solar1_view.Cac = ((float)Math.Round(float.Parse(solar1.Cac) * 10f) / 10f).ToString();
                    solar1_view.Cab = ((float)Math.Round(float.Parse(solar1.Cab) * 10f) / 10f).ToString();
                    solar1_view.Caa = ((float)Math.Round(float.Parse(solar1.Caa) * 10f) / 10f).ToString();
                    solar1_view.Civg = ((float)Math.Round(float.Parse(solar1.Civg) * 10f) / 10f).ToString();
                    solar1_view.Pc = ((float)Math.Round(float.Parse(solar1.Pc) * 10f) / 10f).ToString();
                    solar1_view.Pb = ((float)Math.Round(float.Parse(solar1.Pb) * 10f) / 10f).ToString();
                    solar1_view.Pa = ((float)Math.Round(float.Parse(solar1.Pa) * 10f) / 10f).ToString();
                    solar1_view.Pkvar = ((float)Math.Round(float.Parse(solar1.Pkvar) * 10f) / 10f).ToString();
                    solar1_view.Pkva = ((float)Math.Round(float.Parse(solar1.Pkva) * 10f) / 10f).ToString();
                    solar1_view.Van = ((float)Math.Round(float.Parse(solar1.Van) * 10f) / 10f).ToString();
                    solar1_view.Vbn = ((float)Math.Round(float.Parse(solar1.Vbn) * 10f) / 10f).ToString();
                    solar1_view.Vcn = ((float)Math.Round(float.Parse(solar1.Vcn) * 10f) / 10f).ToString();
                    solar1_view.F = ((float)Math.Round(float.Parse(solar1.F) * 10f) / 10f).ToString();
                    solar1_view.PF = ((float)Math.Round(float.Parse(solar1.PF) * 10f) / 10f).ToString();
                    solar1_view.Vin = ((float)Math.Round(float.Parse(solar1.Vin) * 10f) / 10f).ToString();
                    solar1_view.Ptotal = ((float)Math.Round(float.Parse(solar1.Ptotal) * 10f) / 10f).ToString();
                    solar1_view.Kwh = ((float)Math.Round(float.Parse(solar1.Kwh) * 10f) / 10f).ToString();
                    solar1_view.KwhDay = ((float)Math.Round((float.Parse(solar1.Kwh) - float.Parse(solar1_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(solar1_view, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartSolar2DataOnline()
        {
            using (DBModel db = new DBModel())
            {
                var solar2 = db.hienthi1.Where(a => a.Kenh.Equals("2")).FirstOrDefault();
                var recoder1_solar2_begin = db.recoder1_db_solar2.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var solar2_view = new Hienthi1View();
                if (solar2 != null)
                {
                    var solar2_Kwh_last = (recoder1_solar2_begin != null) ? recoder1_solar2_begin.Kwh : "0";
                    solar2_view.Vca = ((float)Math.Round(float.Parse(solar2.Vca) * 10f) / 10f).ToString();
                    solar2_view.Vbc = ((float)Math.Round(float.Parse(solar2.Vbc) * 10f) / 10f).ToString();
                    solar2_view.Vab = ((float)Math.Round(float.Parse(solar2.Vab) * 10f) / 10f).ToString();
                    solar2_view.Vun = ((float)Math.Round(float.Parse(solar2.Vun) * 10f) / 10f).ToString();
                    solar2_view.VII = ((float)Math.Round(float.Parse(solar2.VII) * 10f) / 10f).ToString();
                    solar2_view.Cac = ((float)Math.Round(float.Parse(solar2.Cac) * 10f) / 10f).ToString();
                    solar2_view.Cab = ((float)Math.Round(float.Parse(solar2.Cab) * 10f) / 10f).ToString();
                    solar2_view.Caa = ((float)Math.Round(float.Parse(solar2.Caa) * 10f) / 10f).ToString();
                    solar2_view.Civg = ((float)Math.Round(float.Parse(solar2.Civg) * 10f) / 10f).ToString();
                    solar2_view.Pc = ((float)Math.Round(float.Parse(solar2.Pc) * 10f) / 10f).ToString();
                    solar2_view.Pb = ((float)Math.Round(float.Parse(solar2.Pb) * 10f) / 10f).ToString();
                    solar2_view.Pa = ((float)Math.Round(float.Parse(solar2.Pa) * 10f) / 10f).ToString();
                    solar2_view.Pkvar = ((float)Math.Round(float.Parse(solar2.Pkvar) * 10f) / 10f).ToString();
                    solar2_view.Pkva = ((float)Math.Round(float.Parse(solar2.Pkva) * 10f) / 10f).ToString();
                    solar2_view.Van = ((float)Math.Round(float.Parse(solar2.Van) * 10f) / 10f).ToString();
                    solar2_view.Vbn = ((float)Math.Round(float.Parse(solar2.Vbn) * 10f) / 10f).ToString();
                    solar2_view.Vcn = ((float)Math.Round(float.Parse(solar2.Vcn) * 10f) / 10f).ToString();
                    solar2_view.F = ((float)Math.Round(float.Parse(solar2.F) * 10f) / 10f).ToString();
                    solar2_view.PF = ((float)Math.Round(float.Parse(solar2.PF) * 10f) / 10f).ToString();
                    solar2_view.Vin = ((float)Math.Round(float.Parse(solar2.Vin) * 10f) / 10f).ToString();
                    solar2_view.Ptotal = ((float)Math.Round(float.Parse(solar2.Ptotal) * 10f) / 10f).ToString();
                    solar2_view.Kwh = ((float)Math.Round(float.Parse(solar2.Kwh) * 10f) / 10f).ToString();
                    solar2_view.KwhDay = ((float)Math.Round((float.Parse(solar2.Kwh) - float.Parse(solar2_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(solar2_view, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartLogisticDataOnline()
        {
            using (DBModel db = new DBModel())
            {
                var logistic = db.hienthi1.Where(a => a.Kenh.Equals("3")).FirstOrDefault();
                var recoder1_logistic_begin = db.recoder1_db_logistics.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var logistic_view = new Hienthi1View();
                if (logistic != null)
                {
                    var logistic_Kwh_last = (recoder1_logistic_begin != null) ? recoder1_logistic_begin.Kwh : "0";
                    logistic_view.Vca = ((float)Math.Round(float.Parse(logistic.Vca) * 10f) / 10f).ToString();
                    logistic_view.Vbc = ((float)Math.Round(float.Parse(logistic.Vbc) * 10f) / 10f).ToString();
                    logistic_view.Vab = ((float)Math.Round(float.Parse(logistic.Vab) * 10f) / 10f).ToString();
                    logistic_view.Vun = ((float)Math.Round(float.Parse(logistic.Vun) * 10f) / 10f).ToString();
                    logistic_view.VII = ((float)Math.Round(float.Parse(logistic.VII) * 10f) / 10f).ToString();
                    logistic_view.Cac = ((float)Math.Round(float.Parse(logistic.Cac) * 10f) / 10f).ToString();
                    logistic_view.Cab = ((float)Math.Round(float.Parse(logistic.Cab) * 10f) / 10f).ToString();
                    logistic_view.Caa = ((float)Math.Round(float.Parse(logistic.Caa) * 10f) / 10f).ToString();
                    logistic_view.Civg = ((float)Math.Round(float.Parse(logistic.Civg) * 10f) / 10f).ToString();
                    logistic_view.Pc = ((float)Math.Round(float.Parse(logistic.Pc) * 10f) / 10f).ToString();
                    logistic_view.Pb = ((float)Math.Round(float.Parse(logistic.Pb) * 10f) / 10f).ToString();
                    logistic_view.Pa = ((float)Math.Round(float.Parse(logistic.Pa) * 10f) / 10f).ToString();
                    logistic_view.Pkvar = ((float)Math.Round(float.Parse(logistic.Pkvar) * 10f) / 10f).ToString();
                    logistic_view.Pkva = ((float)Math.Round(float.Parse(logistic.Pkva) * 10f) / 10f).ToString();
                    logistic_view.Van = ((float)Math.Round(float.Parse(logistic.Van) * 10f) / 10f).ToString();
                    logistic_view.Vbn = ((float)Math.Round(float.Parse(logistic.Vbn) * 10f) / 10f).ToString();
                    logistic_view.Vcn = ((float)Math.Round(float.Parse(logistic.Vcn) * 10f) / 10f).ToString();
                    logistic_view.F = ((float)Math.Round(float.Parse(logistic.F) * 10f) / 10f).ToString();
                    logistic_view.PF = ((float)Math.Round(float.Parse(logistic.PF) * 10f) / 10f).ToString();
                    logistic_view.Vin = ((float)Math.Round(float.Parse(logistic.Vin) * 10f) / 10f).ToString();
                    logistic_view.Ptotal = ((float)Math.Round(float.Parse(logistic.Ptotal) * 10f) / 10f).ToString();
                    logistic_view.Kwh = ((float)Math.Round(float.Parse(logistic.Kwh) * 10f) / 10f).ToString();
                    logistic_view.KwhDay = ((float)Math.Round((float.Parse(logistic.Kwh) - float.Parse(logistic_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(logistic_view, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetReportDataSolar1(int year, int month)
        {
            var minDate = DateTime.Now.AddMonths(-3);
            using (DBModel db = new DBModel())
            {
                var data = db.recoder1_db_solar1.Where(p => p.Thoigian > minDate).Select(i => new { i.Thoigian, i.Ptotal })
                             .ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetReportKwhSolar1(int year, int month, string type)
        {
            var data = new List<object>();
            var first_value = new object();
            using (DBModel db = new DBModel())
            {
                //var result = new List<Result>();
                switch (type)
                {
                    case "curr_year":
                        first_value = db.recoder1_db_solar1.Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 1).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_db_solar1
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
                        first_value = db.recoder1_db_solar1.Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 2).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_db_solar1
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
                        first_value = db.recoder1_db_solar1.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_db_solar1
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
                        IQueryable<Recoder1_DB_Solar1> query1 = db.recoder1_db_solar1;
                        IQueryable<Recoder1_DB_Solar1> query2 = db.recoder1_db_solar1;
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

                        first_value = db.recoder1_db_solar1.Where(p => p.Thoigian >= startYesterdayTime && p.Thoigian <= endYesterdayTime).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_db_solar1
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
                        first_value = db.recoder1_db_solar1.Where(p => p.Thoigian >= beforeYesterdayStart && p.Thoigian <= beforeYesterdayEnd).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_db_solar1
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

                        first_value = db.recoder1_db_solar1.Where(p => p.Thoigian >= beforeStartOfWeek && p.Thoigian <= endBeforeStartOfWeek).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();


                        result = db.recoder1_db_solar1
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
                        first_value = db.recoder1_db_solar1.Where(p => p.Thoigian >= startOfBeforeLastWeek && p.Thoigian <= endOfBeforeLastWeek).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_db_solar1
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
        public JsonResult GetReportDataSolar2(int year, int month)
        {
            var minDate = DateTime.Now.AddMonths(-3);
            using (DBModel db = new DBModel())
            {
                var data = db.recoder1_db_solar2.Where(p => p.Thoigian > minDate).Select(i => new { i.Thoigian, i.Ptotal })
                             .ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetReportKwhSolar2(int year, int month, string type)
        {
            var data = new List<object>();
            var first_value = new object();
            using (DBModel db = new DBModel())
            {
                //var result = new List<Result>();
                switch (type)
                {
                    case "curr_year":
                        first_value = db.recoder1_db_solar2.Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 1).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_db_solar2
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
                        first_value = db.recoder1_db_solar2.Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 2).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_db_solar2
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
                        first_value = db.recoder1_db_solar2.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_db_solar2
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
                        IQueryable<Recoder1_DB_Solar2> query1 = db.recoder1_db_solar2;
                        IQueryable<Recoder1_DB_Solar2> query2 = db.recoder1_db_solar2;
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

                        first_value = db.recoder1_db_solar2.Where(p => p.Thoigian >= startYesterdayTime && p.Thoigian <= endYesterdayTime).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_db_solar2
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
                        first_value = db.recoder1_db_solar2.Where(p => p.Thoigian >= beforeYesterdayStart && p.Thoigian <= beforeYesterdayEnd).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_db_solar2
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

                        first_value = db.recoder1_db_solar2.Where(p => p.Thoigian >= beforeStartOfWeek && p.Thoigian <= endBeforeStartOfWeek).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();


                        result = db.recoder1_db_solar2
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
                        first_value = db.recoder1_db_solar2.Where(p => p.Thoigian >= startOfBeforeLastWeek && p.Thoigian <= endOfBeforeLastWeek).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_db_solar2
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
        public JsonResult GetReportDataLogistic(int year, int month)
        {
            var minDate = DateTime.Now.AddMonths(-3);
            using (DBModel db = new DBModel())
            {
                var data = db.recoder1_db_logistics.Where(p => p.Thoigian > minDate).Select(i => new { i.Thoigian, i.Ptotal })
                             .ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetReportKwhLogistic(int year, int month, string type)
        {
            var data = new List<object>();
            var first_value = new object();
            using (DBModel db = new DBModel())
            {
                //var result = new List<Result>();
                switch (type)
                {
                    case "curr_year":
                        first_value = db.recoder1_db_logistics.Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 1).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_db_logistics
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
                        first_value = db.recoder1_db_logistics.Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 2).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_db_logistics
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
                        first_value = db.recoder1_db_logistics.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_db_logistics
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
                        IQueryable<Recoder1_DB_Logistics> query1 = db.recoder1_db_logistics;
                        IQueryable<Recoder1_DB_Logistics> query2 = db.recoder1_db_logistics;
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

                        first_value = db.recoder1_db_logistics.Where(p => p.Thoigian >= startYesterdayTime && p.Thoigian <= endYesterdayTime).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_db_logistics
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
                        first_value = db.recoder1_db_logistics.Where(p => p.Thoigian >= beforeYesterdayStart && p.Thoigian <= beforeYesterdayEnd).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_db_logistics
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

                        first_value = db.recoder1_db_logistics.Where(p => p.Thoigian >= beforeStartOfWeek && p.Thoigian <= endBeforeStartOfWeek).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();


                        result = db.recoder1_db_logistics
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
                        first_value = db.recoder1_db_solar2.Where(p => p.Thoigian >= startOfBeforeLastWeek && p.Thoigian <= endOfBeforeLastWeek).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_db_solar2
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