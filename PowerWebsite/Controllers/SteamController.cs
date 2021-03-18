using PowerWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PowerWebsite.Controllers
{
    public class SteamController : Controller
    {
        private object result;
        DateTime startTodayTime = DateTime.Today; //Today at 00:00:00
        DateTime endTodayTime = DateTime.Today.AddDays(1).AddTicks(-1); //Today at 23:59:59

        DateTime startYesterdayTime = DateTime.Today.AddDays(-1); //Today at 00:00:00
        DateTime endYesterdayTime = DateTime.Today.AddTicks(-1); //Today at 23:59:59

        DateTime? fromDate = DateTime.Now.Date;
        DateTime? toDate = DateTime.Now.Date.AddDays(1).AddTicks(-1);
        // GET: Water
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult PC10()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult PC15()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [Route("Report/Steam-pc10")]
        public ActionResult PC10Report()
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
        [Route("Report/Steam-pc15")]
        public ActionResult PC15Report()
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
        public JsonResult GetSteamPc10Data()
        {
            using (DBModel db = new DBModel())
            {
                DateTime today = DateTime.Today.Date;
                var steam_pc10 = db.steam_pc10.FirstOrDefault();
                var steamPc10_recoder_begin = db.recoder1_steam_pc10.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var steamPc10_view = new SteamPC10View();
                if (steam_pc10 != null)
                {
                    var steamPc10_total_last = (steamPc10_recoder_begin != null) ? steamPc10_recoder_begin.luu_luong_tong : "0";
                    steamPc10_view.luu_luong_hien_tai = ((float)Math.Round(float.Parse(steam_pc10.luu_luong_hien_tai) * 10f) / 10f).ToString();
                    steamPc10_view.luu_luong_tong = ((float)Math.Round(float.Parse(steam_pc10.luu_luong_tong) * 10f) / 10f).ToString();
                    steamPc10_view.luu_luong_tong_ngay = ((float)Math.Round((float.Parse(steam_pc10.luu_luong_tong) - float.Parse(steamPc10_total_last)) * 10f) / 10f).ToString();
                    steamPc10_view.status = steam_pc10.status;
                }
                return Json(steamPc10_view, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetSteamPc15Data()
        {
            using (DBModel db = new DBModel())
            {
                DateTime today = DateTime.Today.Date;
                var steam_pc15 = db.steam_pc15.FirstOrDefault();
                var steamPc15_recoder_begin = db.recoder1_steam_pc15.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var steamPc15_view = new SteamPC10View();
                if (steam_pc15 != null)
                {
                    var steamPc15_total_last = (steamPc15_recoder_begin != null) ? steamPc15_recoder_begin.luu_luong_tong : "0";
                    steamPc15_view.luu_luong_hien_tai = ((float)Math.Round(float.Parse(steam_pc15.luu_luong_hien_tai) * 10f) / 10f).ToString();
                    steamPc15_view.luu_luong_tong = ((float)Math.Round(float.Parse(steam_pc15.luu_luong_tong) * 10f) / 10f).ToString();
                    steamPc15_view.luu_luong_tong_ngay = ((float)Math.Round((float.Parse(steam_pc15.luu_luong_tong) - float.Parse(steamPc15_total_last)) * 10f) / 10f).ToString();
                    steamPc15_view.status = steam_pc15.status;
                }
                return Json(steamPc15_view, JsonRequestBehavior.AllowGet);
            }
        }
        // GET STEAM PC10
        [HttpGet]
        public JsonResult GetReportDataSteamPC10(int year, int month)
        {
            var minDate = DateTime.Now.AddMonths(-3);
            using (DBModel db = new DBModel())
            {
                var data = db.recoder1_steam_pc10.Where(p => p.Thoigian > minDate).Select(i => new { i.Thoigian, i.luu_luong_hien_tai })
                             .ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetReportTotalSteamPC10(int year, int month, string type)
        {
            var data = new List<object>();
            var first_value = new object();
            using (DBModel db = new DBModel())
            {
                switch (type)
                {
                    case "curr_year":
                        first_value = db.recoder1_steam_pc10.Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 1).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_steam_pc10
                        .Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year)
                        .GroupBy(p => p.Thoigian.Month)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "last_year":
                        first_value = db.recoder1_steam_pc10.Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 2).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_steam_pc10
                        .Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 1)
                        .GroupBy(p => p.Thoigian.Month)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "curr_month":
                        first_value = db.recoder1_steam_pc10.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_steam_pc10
                        .Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= DateTime.Today.Day && p.Thoigian.Month == month)
                        .GroupBy(p => p.Thoigian.Day)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "last_month":
                        IQueryable<Recoder1_Steam_PC10> query1 = db.recoder1_steam_pc10;
                        IQueryable<Recoder1_Steam_PC10> query2 = db.recoder1_steam_pc10;
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
                                firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                                lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                            })
                            .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                            .ToList();
                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "today":
                        first_value = db.recoder1_steam_pc10.Where(p => p.Thoigian >= startYesterdayTime && p.Thoigian <= endYesterdayTime).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_steam_pc10
                        .Where(p => p.Thoigian >= startTodayTime && p.Thoigian <= endTodayTime)
                        .GroupBy(p => p.Thoigian.Hour)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "yesterday":
                        DateTime beforeYesterdayStart = startYesterdayTime.AddDays(-1);
                        DateTime beforeYesterdayEnd = endYesterdayTime.AddDays(-1);
                        first_value = db.recoder1_steam_pc10.Where(p => p.Thoigian >= beforeYesterdayStart && p.Thoigian <= beforeYesterdayEnd).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_steam_pc10
                        .Where(p => p.Thoigian >= startYesterdayTime && p.Thoigian <= endYesterdayTime)
                        .GroupBy(p => p.Thoigian.Hour)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
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
                        first_value = db.recoder1_steam_pc10.Where(p => p.Thoigian >= beforeStartOfWeek && p.Thoigian <= endBeforeStartOfWeek).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_steam_pc10
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

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "last_week":
                        DateTime startOfLastWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek)).AddDays(-7);
                        DateTime endOfLastWeek = startOfLastWeek.AddDays(7);
                        DateTime startOfBeforeLastWeek = startOfLastWeek.AddDays(-1);
                        DateTime endOfBeforeLastWeek = startOfLastWeek.AddTicks(-1);
                        first_value = db.recoder1_steam_pc10.Where(p => p.Thoigian >= startOfBeforeLastWeek && p.Thoigian <= endOfBeforeLastWeek).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_steam_pc10
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

        // GET STEAM PC15
        [HttpGet]
        public JsonResult GetReportDataSteamPC15(int year, int month)
        {
            var minDate = DateTime.Now.AddMonths(-3);
            using (DBModel db = new DBModel())
            {
                var data = db.recoder1_steam_pc15.Where(p => p.Thoigian > minDate).Select(i => new { i.Thoigian, i.luu_luong_hien_tai })
                             .ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetReportTotalSteamPC15(int year, int month, string type)
        {
            var data = new List<object>();
            var first_value = new object();
            using (DBModel db = new DBModel())
            {
                switch (type)
                {
                    case "curr_year":
                        first_value = db.recoder1_steam_pc15.Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 1).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_steam_pc15
                        .Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year)
                        .GroupBy(p => p.Thoigian.Month)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "last_year":
                        first_value = db.recoder1_steam_pc15.Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 2).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_steam_pc15
                        .Where(p => p.Thoigian.Month >= 1 && p.Thoigian.Month <= 12 && p.Thoigian.Year == year - 1)
                        .GroupBy(p => p.Thoigian.Month)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "curr_month":
                        first_value = db.recoder1_steam_pc15.Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= 31 && p.Thoigian.Month == month - 1).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_steam_pc15
                        .Where(p => p.Thoigian.Day >= 1 && p.Thoigian.Day <= DateTime.Today.Day && p.Thoigian.Month == month)
                        .GroupBy(p => p.Thoigian.Day)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "last_month":
                        IQueryable<Recoder1_Steam_PC15> query1 = db.recoder1_steam_pc15;
                        IQueryable<Recoder1_Steam_PC15> query2 = db.recoder1_steam_pc15;
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
                                firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                                lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                            })
                            .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                            .ToList();
                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "today":
                        first_value = db.recoder1_steam_pc15.Where(p => p.Thoigian >= startYesterdayTime && p.Thoigian <= endYesterdayTime).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_steam_pc15
                        .Where(p => p.Thoigian >= startTodayTime && p.Thoigian <= endTodayTime)
                        .GroupBy(p => p.Thoigian.Hour)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
                        })
                        .Select(x => new { x.Thoigian, x.firstValue, x.lastValue })
                        .ToList();

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "yesterday":
                        DateTime beforeYesterdayStart = startYesterdayTime.AddDays(-1);
                        DateTime beforeYesterdayEnd = endYesterdayTime.AddDays(-1);
                        first_value = db.recoder1_steam_pc15.Where(p => p.Thoigian >= beforeYesterdayStart && p.Thoigian <= beforeYesterdayEnd).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_steam_pc15
                        .Where(p => p.Thoigian >= startYesterdayTime && p.Thoigian <= endYesterdayTime)
                        .GroupBy(p => p.Thoigian.Hour)
                        .Select(g => new {
                            Thoigian = g.Key,
                            firstValue = g.OrderBy(p => p.Thoigian).FirstOrDefault().luu_luong_tong,
                            lastValue = g.OrderByDescending(p => p.Thoigian).FirstOrDefault().luu_luong_tong
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
                        first_value = db.recoder1_steam_pc15.Where(p => p.Thoigian >= beforeStartOfWeek && p.Thoigian <= endBeforeStartOfWeek).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_steam_pc15
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

                        data.Add(result);
                        data.Add(first_value);
                        result = data;
                        break;
                    case "last_week":
                        DateTime startOfLastWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek)).AddDays(-7);
                        DateTime endOfLastWeek = startOfLastWeek.AddDays(7);
                        DateTime startOfBeforeLastWeek = startOfLastWeek.AddDays(-1);
                        DateTime endOfBeforeLastWeek = startOfLastWeek.AddTicks(-1);
                        first_value = db.recoder1_steam_pc15.Where(p => p.Thoigian >= startOfBeforeLastWeek && p.Thoigian <= endOfBeforeLastWeek).OrderByDescending(p => p.Thoigian).Take(1).ToList().FirstOrDefault();

                        result = db.recoder1_steam_pc15
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