using PowerWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PowerWebsite.Controllers
{
    public class Electric2Controller : Controller
    {
        DateTime today = DateTime.Today.Date;
        DateTime startYesterdayTime = DateTime.Today.AddDays(-1); //Today at 00:00:00
        DateTime endYesterdayTime = DateTime.Today.AddTicks(-1); //Today at 23:59:59
        // GET: Electric2
        public ActionResult Kenh4Online()
        {
            if (Session["UserID"] != null)
            {
                using (DBModel db = new DBModel())
                {
                    ViewBag.kenh4 = new Hienthi1View();
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Kenh5Online()
        {
            if (Session["UserID"] != null)
            {
                using (DBModel db = new DBModel())
                {
                    ViewBag.kenh5 = new Hienthi1View();
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult Kenh6Online()
        {
            if (Session["UserID"] != null)
            {
                using (DBModel db = new DBModel())
                {
                    ViewBag.kenh6 = new Hienthi1View();
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult Kenh7Online()
        {
            if (Session["UserID"] != null)
            {
                using (DBModel db = new DBModel())
                {
                    ViewBag.kenh7 = new Hienthi1View();
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult Kenh8Online()
        {
            if (Session["UserID"] != null)
            {
                using (DBModel db = new DBModel())
                {
                    ViewBag.kenh8 = new Hienthi1View();
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult Kenh9Online()
        {
            if (Session["UserID"] != null)
            {
                using (DBModel db = new DBModel())
                {
                    ViewBag.kenh9 = new Hienthi1View();
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult Kenh10Online()
        {
            if (Session["UserID"] != null)
            {
                using (DBModel db = new DBModel())
                {
                    ViewBag.kenh10 = new Hienthi1View();
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult Kenh11Online()
        {
            if (Session["UserID"] != null)
            {
                using (DBModel db = new DBModel())
                {
                    ViewBag.kenh11 = new Hienthi1View();
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh4DataOnline()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi1 = db.hienthi1.Where(a => a.Kenh.Equals("4")).FirstOrDefault();
                var recoder1_kenh4_begin = db.recoder1_kenh4.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var hienthi4_view = new Hienthi1View();
                if (hienthi1 != null)
                {
                    var kenh4_Kwh_last = (recoder1_kenh4_begin != null) ? recoder1_kenh4_begin.Kwh : "0";
                    hienthi4_view.Vca = ((float)Math.Round(float.Parse(hienthi1.Vca) * 10f) / 10f).ToString();
                    hienthi4_view.Vbc = ((float)Math.Round(float.Parse(hienthi1.Vbc) * 10f) / 10f).ToString();
                    hienthi4_view.Vab = ((float)Math.Round(float.Parse(hienthi1.Vab) * 10f) / 10f).ToString();
                    hienthi4_view.Vun = ((float)Math.Round(float.Parse(hienthi1.Vun) * 10f) / 10f).ToString();
                    hienthi4_view.VII = ((float)Math.Round(float.Parse(hienthi1.VII) * 10f) / 10f).ToString();
                    hienthi4_view.Cac = ((float)Math.Round(float.Parse(hienthi1.Cac) * 10f) / 10f).ToString();
                    hienthi4_view.Cab = ((float)Math.Round(float.Parse(hienthi1.Cab) * 10f) / 10f).ToString();
                    hienthi4_view.Caa = ((float)Math.Round(float.Parse(hienthi1.Caa) * 10f) / 10f).ToString();
                    hienthi4_view.Civg = ((float)Math.Round(float.Parse(hienthi1.Civg) * 10f) / 10f).ToString();
                    hienthi4_view.Pc = ((float)Math.Round(float.Parse(hienthi1.Pc) * 10f) / 10f).ToString();
                    hienthi4_view.Pb = ((float)Math.Round(float.Parse(hienthi1.Pb) * 10f) / 10f).ToString();
                    hienthi4_view.Pa = ((float)Math.Round(float.Parse(hienthi1.Pa) * 10f) / 10f).ToString();
                    hienthi4_view.Pkvar = ((float)Math.Round(float.Parse(hienthi1.Pkvar) * 10f) / 10f).ToString();
                    hienthi4_view.Pkva = ((float)Math.Round(float.Parse(hienthi1.Pkva) * 10f) / 10f).ToString();
                    hienthi4_view.Van = ((float)Math.Round(float.Parse(hienthi1.Van) * 10f) / 10f).ToString();
                    hienthi4_view.Vbn = ((float)Math.Round(float.Parse(hienthi1.Vbn) * 10f) / 10f).ToString();
                    hienthi4_view.Vcn = ((float)Math.Round(float.Parse(hienthi1.Vcn) * 10f) / 10f).ToString();
                    hienthi4_view.F = ((float)Math.Round(float.Parse(hienthi1.F) * 10f) / 10f).ToString();
                    hienthi4_view.PF = ((float)Math.Round(float.Parse(hienthi1.PF) * 10f) / 10f).ToString();
                    hienthi4_view.Vin = ((float)Math.Round(float.Parse(hienthi1.Vin) * 10f) / 10f).ToString();
                    hienthi4_view.Ptotal = ((float)Math.Round(float.Parse(hienthi1.Ptotal) * 10f) / 10f).ToString();
                    hienthi4_view.Kwh = ((float)Math.Round(float.Parse(hienthi1.Kwh) * 10f) / 10f).ToString();
                    hienthi4_view.KwhDay = ((float)Math.Round((float.Parse(hienthi1.Kwh) - float.Parse(kenh4_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi4_view, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh5DataOnline()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi1 = db.hienthi1.Where(a => a.Kenh.Equals("5")).FirstOrDefault();
                var recoder1_kenh5_begin = db.recoder1_kenh5.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var hienthi5_view = new Hienthi1View();
                if (hienthi1 != null)
                {
                    var kenh5_Kwh_last = (recoder1_kenh5_begin != null) ? recoder1_kenh5_begin.Kwh : "0";
                    hienthi5_view.Vca = ((float)Math.Round(float.Parse(hienthi1.Vca) * 10f) / 10f).ToString();
                    hienthi5_view.Vbc = ((float)Math.Round(float.Parse(hienthi1.Vbc) * 10f) / 10f).ToString();
                    hienthi5_view.Vab = ((float)Math.Round(float.Parse(hienthi1.Vab) * 10f) / 10f).ToString();
                    hienthi5_view.Vun = ((float)Math.Round(float.Parse(hienthi1.Vun) * 10f) / 10f).ToString();
                    hienthi5_view.VII = ((float)Math.Round(float.Parse(hienthi1.VII) * 10f) / 10f).ToString();
                    hienthi5_view.Cac = ((float)Math.Round(float.Parse(hienthi1.Cac) * 10f) / 10f).ToString();
                    hienthi5_view.Cab = ((float)Math.Round(float.Parse(hienthi1.Cab) * 10f) / 10f).ToString();
                    hienthi5_view.Caa = ((float)Math.Round(float.Parse(hienthi1.Caa) * 10f) / 10f).ToString();
                    hienthi5_view.Civg = ((float)Math.Round(float.Parse(hienthi1.Civg) * 10f) / 10f).ToString();
                    hienthi5_view.Pc = ((float)Math.Round(float.Parse(hienthi1.Pc) * 10f) / 10f).ToString();
                    hienthi5_view.Pb = ((float)Math.Round(float.Parse(hienthi1.Pb) * 10f) / 10f).ToString();
                    hienthi5_view.Pa = ((float)Math.Round(float.Parse(hienthi1.Pa) * 10f) / 10f).ToString();
                    hienthi5_view.Pkvar = ((float)Math.Round(float.Parse(hienthi1.Pkvar) * 10f) / 10f).ToString();
                    hienthi5_view.Pkva = ((float)Math.Round(float.Parse(hienthi1.Pkva) * 10f) / 10f).ToString();
                    hienthi5_view.Van = ((float)Math.Round(float.Parse(hienthi1.Van) * 10f) / 10f).ToString();
                    hienthi5_view.Vbn = ((float)Math.Round(float.Parse(hienthi1.Vbn) * 10f) / 10f).ToString();
                    hienthi5_view.Vcn = ((float)Math.Round(float.Parse(hienthi1.Vcn) * 10f) / 10f).ToString();
                    hienthi5_view.F = ((float)Math.Round(float.Parse(hienthi1.F) * 10f) / 10f).ToString();
                    hienthi5_view.PF = ((float)Math.Round(float.Parse(hienthi1.PF) * 10f) / 10f).ToString();
                    hienthi5_view.Vin = ((float)Math.Round(float.Parse(hienthi1.Vin) * 10f) / 10f).ToString();
                    hienthi5_view.Ptotal = ((float)Math.Round(float.Parse(hienthi1.Ptotal) * 10f) / 10f).ToString();
                    hienthi5_view.Kwh = ((float)Math.Round(float.Parse(hienthi1.Kwh) * 10f) / 10f).ToString();
                    hienthi5_view.KwhDay = ((float)Math.Round((float.Parse(hienthi1.Kwh) - float.Parse(kenh5_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi5_view, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh6DataOnline()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi1 = db.hienthi1.Where(a => a.Kenh.Equals("6")).FirstOrDefault();
                var recoder1_kenh6_begin = db.recoder1_kenh6.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var hienthi6_view = new Hienthi1View();
                if (hienthi1 != null)
                {
                    var kenh6_Kwh_last = (recoder1_kenh6_begin != null) ? recoder1_kenh6_begin.Kwh : "0";
                    hienthi6_view.Vca = ((float)Math.Round(float.Parse(hienthi1.Vca) * 10f) / 10f).ToString();
                    hienthi6_view.Vbc = ((float)Math.Round(float.Parse(hienthi1.Vbc) * 10f) / 10f).ToString();
                    hienthi6_view.Vab = ((float)Math.Round(float.Parse(hienthi1.Vab) * 10f) / 10f).ToString();
                    hienthi6_view.Vun = ((float)Math.Round(float.Parse(hienthi1.Vun) * 10f) / 10f).ToString();
                    hienthi6_view.VII = ((float)Math.Round(float.Parse(hienthi1.VII) * 10f) / 10f).ToString();
                    hienthi6_view.Cac = ((float)Math.Round(float.Parse(hienthi1.Cac) * 10f) / 10f).ToString();
                    hienthi6_view.Cab = ((float)Math.Round(float.Parse(hienthi1.Cab) * 10f) / 10f).ToString();
                    hienthi6_view.Caa = ((float)Math.Round(float.Parse(hienthi1.Caa) * 10f) / 10f).ToString();
                    hienthi6_view.Civg = ((float)Math.Round(float.Parse(hienthi1.Civg) * 10f) / 10f).ToString();
                    hienthi6_view.Pc = ((float)Math.Round(float.Parse(hienthi1.Pc) * 10f) / 10f).ToString();
                    hienthi6_view.Pb = ((float)Math.Round(float.Parse(hienthi1.Pb) * 10f) / 10f).ToString();
                    hienthi6_view.Pa = ((float)Math.Round(float.Parse(hienthi1.Pa) * 10f) / 10f).ToString();
                    hienthi6_view.Pkvar = ((float)Math.Round(float.Parse(hienthi1.Pkvar) * 10f) / 10f).ToString();
                    hienthi6_view.Pkva = ((float)Math.Round(float.Parse(hienthi1.Pkva) * 10f) / 10f).ToString();
                    hienthi6_view.Van = ((float)Math.Round(float.Parse(hienthi1.Van) * 10f) / 10f).ToString();
                    hienthi6_view.Vbn = ((float)Math.Round(float.Parse(hienthi1.Vbn) * 10f) / 10f).ToString();
                    hienthi6_view.Vcn = ((float)Math.Round(float.Parse(hienthi1.Vcn) * 10f) / 10f).ToString();
                    hienthi6_view.F = ((float)Math.Round(float.Parse(hienthi1.F) * 10f) / 10f).ToString();
                    hienthi6_view.PF = ((float)Math.Round(float.Parse(hienthi1.PF) * 10f) / 10f).ToString();
                    hienthi6_view.Vin = ((float)Math.Round(float.Parse(hienthi1.Vin) * 10f) / 10f).ToString();
                    hienthi6_view.Ptotal = ((float)Math.Round(float.Parse(hienthi1.Ptotal) * 10f) / 10f).ToString();
                    hienthi6_view.Kwh = ((float)Math.Round(float.Parse(hienthi1.Kwh) * 10f) / 10f).ToString();
                    hienthi6_view.KwhDay = ((float)Math.Round((float.Parse(hienthi1.Kwh) - float.Parse(kenh6_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi6_view, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh7DataOnline()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi1 = db.hienthi1.Where(a => a.Kenh.Equals("7")).FirstOrDefault();
                var recoder1_kenh7_begin = db.recoder1_kenh7.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var hienthi7_view = new Hienthi1View();
                if (hienthi1 != null)
                {
                    var kenh7_Kwh_last = (recoder1_kenh7_begin != null) ? recoder1_kenh7_begin.Kwh : "0";
                    hienthi7_view.Vca = ((float)Math.Round(float.Parse(hienthi1.Vca) * 10f) / 10f).ToString();
                    hienthi7_view.Vbc = ((float)Math.Round(float.Parse(hienthi1.Vbc) * 10f) / 10f).ToString();
                    hienthi7_view.Vab = ((float)Math.Round(float.Parse(hienthi1.Vab) * 10f) / 10f).ToString();
                    hienthi7_view.Vun = ((float)Math.Round(float.Parse(hienthi1.Vun) * 10f) / 10f).ToString();
                    hienthi7_view.VII = ((float)Math.Round(float.Parse(hienthi1.VII) * 10f) / 10f).ToString();
                    hienthi7_view.Cac = ((float)Math.Round(float.Parse(hienthi1.Cac) * 10f) / 10f).ToString();
                    hienthi7_view.Cab = ((float)Math.Round(float.Parse(hienthi1.Cab) * 10f) / 10f).ToString();
                    hienthi7_view.Caa = ((float)Math.Round(float.Parse(hienthi1.Caa) * 10f) / 10f).ToString();
                    hienthi7_view.Civg = ((float)Math.Round(float.Parse(hienthi1.Civg) * 10f) / 10f).ToString();
                    hienthi7_view.Pc = ((float)Math.Round(float.Parse(hienthi1.Pc) * 10f) / 10f).ToString();
                    hienthi7_view.Pb = ((float)Math.Round(float.Parse(hienthi1.Pb) * 10f) / 10f).ToString();
                    hienthi7_view.Pa = ((float)Math.Round(float.Parse(hienthi1.Pa) * 10f) / 10f).ToString();
                    hienthi7_view.Pkvar = ((float)Math.Round(float.Parse(hienthi1.Pkvar) * 10f) / 10f).ToString();
                    hienthi7_view.Pkva = ((float)Math.Round(float.Parse(hienthi1.Pkva) * 10f) / 10f).ToString();
                    hienthi7_view.Van = ((float)Math.Round(float.Parse(hienthi1.Van) * 10f) / 10f).ToString();
                    hienthi7_view.Vbn = ((float)Math.Round(float.Parse(hienthi1.Vbn) * 10f) / 10f).ToString();
                    hienthi7_view.Vcn = ((float)Math.Round(float.Parse(hienthi1.Vcn) * 10f) / 10f).ToString();
                    hienthi7_view.F = ((float)Math.Round(float.Parse(hienthi1.F) * 10f) / 10f).ToString();
                    hienthi7_view.PF = ((float)Math.Round(float.Parse(hienthi1.PF) * 10f) / 10f).ToString();
                    hienthi7_view.Vin = ((float)Math.Round(float.Parse(hienthi1.Vin) * 10f) / 10f).ToString();
                    hienthi7_view.Ptotal = ((float)Math.Round(float.Parse(hienthi1.Ptotal) * 10f) / 10f).ToString();
                    hienthi7_view.Kwh = ((float)Math.Round(float.Parse(hienthi1.Kwh) * 10f) / 10f).ToString();
                    hienthi7_view.KwhDay = ((float)Math.Round((float.Parse(hienthi1.Kwh) - float.Parse(kenh7_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi7_view, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh8DataOnline()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi1 = db.hienthi1.Where(a => a.Kenh.Equals("8")).FirstOrDefault();
                var recoder1_kenh8_begin = db.recoder1_kenh8.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var hienthi8_view = new Hienthi1View();
                if (hienthi1 != null)
                {
                    var kenh8_Kwh_last = (recoder1_kenh8_begin != null) ? recoder1_kenh8_begin.Kwh : "0";
                    hienthi8_view.Vca = ((float)Math.Round(float.Parse(hienthi1.Vca) * 10f) / 10f).ToString();
                    hienthi8_view.Vbc = ((float)Math.Round(float.Parse(hienthi1.Vbc) * 10f) / 10f).ToString();
                    hienthi8_view.Vab = ((float)Math.Round(float.Parse(hienthi1.Vab) * 10f) / 10f).ToString();
                    hienthi8_view.Vun = ((float)Math.Round(float.Parse(hienthi1.Vun) * 10f) / 10f).ToString();
                    hienthi8_view.VII = ((float)Math.Round(float.Parse(hienthi1.VII) * 10f) / 10f).ToString();
                    hienthi8_view.Cac = ((float)Math.Round(float.Parse(hienthi1.Cac) * 10f) / 10f).ToString();
                    hienthi8_view.Cab = ((float)Math.Round(float.Parse(hienthi1.Cab) * 10f) / 10f).ToString();
                    hienthi8_view.Caa = ((float)Math.Round(float.Parse(hienthi1.Caa) * 10f) / 10f).ToString();
                    hienthi8_view.Civg = ((float)Math.Round(float.Parse(hienthi1.Civg) * 10f) / 10f).ToString();
                    hienthi8_view.Pc = ((float)Math.Round(float.Parse(hienthi1.Pc) * 10f) / 10f).ToString();
                    hienthi8_view.Pb = ((float)Math.Round(float.Parse(hienthi1.Pb) * 10f) / 10f).ToString();
                    hienthi8_view.Pa = ((float)Math.Round(float.Parse(hienthi1.Pa) * 10f) / 10f).ToString();
                    hienthi8_view.Pkvar = ((float)Math.Round(float.Parse(hienthi1.Pkvar) * 10f) / 10f).ToString();
                    hienthi8_view.Pkva = ((float)Math.Round(float.Parse(hienthi1.Pkva) * 10f) / 10f).ToString();
                    hienthi8_view.Van = ((float)Math.Round(float.Parse(hienthi1.Van) * 10f) / 10f).ToString();
                    hienthi8_view.Vbn = ((float)Math.Round(float.Parse(hienthi1.Vbn) * 10f) / 10f).ToString();
                    hienthi8_view.Vcn = ((float)Math.Round(float.Parse(hienthi1.Vcn) * 10f) / 10f).ToString();
                    hienthi8_view.F = ((float)Math.Round(float.Parse(hienthi1.F) * 10f) / 10f).ToString();
                    hienthi8_view.PF = ((float)Math.Round(float.Parse(hienthi1.PF) * 10f) / 10f).ToString();
                    hienthi8_view.Vin = ((float)Math.Round(float.Parse(hienthi1.Vin) * 10f) / 10f).ToString();
                    hienthi8_view.Ptotal = ((float)Math.Round(float.Parse(hienthi1.Ptotal) * 10f) / 10f).ToString();
                    hienthi8_view.Kwh = ((float)Math.Round(float.Parse(hienthi1.Kwh) * 10f) / 10f).ToString();
                    hienthi8_view.KwhDay = ((float)Math.Round((float.Parse(hienthi1.Kwh) - float.Parse(kenh8_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi8_view, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh9DataOnline()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi1 = db.hienthi1.Where(a => a.Kenh.Equals("9")).FirstOrDefault();
                var recoder1_kenh9_begin = db.recoder1_kenh9.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var hienthi9_view = new Hienthi1View();
                if (hienthi1 != null)
                {
                    var kenh9_Kwh_last = (recoder1_kenh9_begin != null) ? recoder1_kenh9_begin.Kwh : "0";
                    hienthi9_view.Vca = ((float)Math.Round(float.Parse(hienthi1.Vca) * 10f) / 10f).ToString();
                    hienthi9_view.Vbc = ((float)Math.Round(float.Parse(hienthi1.Vbc) * 10f) / 10f).ToString();
                    hienthi9_view.Vab = ((float)Math.Round(float.Parse(hienthi1.Vab) * 10f) / 10f).ToString();
                    hienthi9_view.Vun = ((float)Math.Round(float.Parse(hienthi1.Vun) * 10f) / 10f).ToString();
                    hienthi9_view.VII = ((float)Math.Round(float.Parse(hienthi1.VII) * 10f) / 10f).ToString();
                    hienthi9_view.Cac = ((float)Math.Round(float.Parse(hienthi1.Cac) * 10f) / 10f).ToString();
                    hienthi9_view.Cab = ((float)Math.Round(float.Parse(hienthi1.Cab) * 10f) / 10f).ToString();
                    hienthi9_view.Caa = ((float)Math.Round(float.Parse(hienthi1.Caa) * 10f) / 10f).ToString();
                    hienthi9_view.Civg = ((float)Math.Round(float.Parse(hienthi1.Civg) * 10f) / 10f).ToString();
                    hienthi9_view.Pc = ((float)Math.Round(float.Parse(hienthi1.Pc) * 10f) / 10f).ToString();
                    hienthi9_view.Pb = ((float)Math.Round(float.Parse(hienthi1.Pb) * 10f) / 10f).ToString();
                    hienthi9_view.Pa = ((float)Math.Round(float.Parse(hienthi1.Pa) * 10f) / 10f).ToString();
                    hienthi9_view.Pkvar = ((float)Math.Round(float.Parse(hienthi1.Pkvar) * 10f) / 10f).ToString();
                    hienthi9_view.Pkva = ((float)Math.Round(float.Parse(hienthi1.Pkva) * 10f) / 10f).ToString();
                    hienthi9_view.Van = ((float)Math.Round(float.Parse(hienthi1.Van) * 10f) / 10f).ToString();
                    hienthi9_view.Vbn = ((float)Math.Round(float.Parse(hienthi1.Vbn) * 10f) / 10f).ToString();
                    hienthi9_view.Vcn = ((float)Math.Round(float.Parse(hienthi1.Vcn) * 10f) / 10f).ToString();
                    hienthi9_view.F = ((float)Math.Round(float.Parse(hienthi1.F) * 10f) / 10f).ToString();
                    hienthi9_view.PF = ((float)Math.Round(float.Parse(hienthi1.PF) * 10f) / 10f).ToString();
                    hienthi9_view.Vin = ((float)Math.Round(float.Parse(hienthi1.Vin) * 10f) / 10f).ToString();
                    hienthi9_view.Ptotal = ((float)Math.Round(float.Parse(hienthi1.Ptotal) * 10f) / 10f).ToString();
                    hienthi9_view.Kwh = ((float)Math.Round(float.Parse(hienthi1.Kwh) * 10f) / 10f).ToString();
                    hienthi9_view.KwhDay = ((float)Math.Round((float.Parse(hienthi1.Kwh) - float.Parse(kenh9_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi9_view, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh10DataOnline()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi1 = db.hienthi1.Where(a => a.Kenh.Equals("10")).FirstOrDefault();
                var recoder1_kenh10_begin = db.recoder1_kenh10.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var hienthi10_view = new Hienthi1View();
                if (hienthi1 != null)
                {
                    var kenh10_Kwh_last = (recoder1_kenh10_begin != null) ? recoder1_kenh10_begin.Kwh : "0";
                    hienthi10_view.Vca = ((float)Math.Round(float.Parse(hienthi1.Vca) * 10f) / 10f).ToString();
                    hienthi10_view.Vbc = ((float)Math.Round(float.Parse(hienthi1.Vbc) * 10f) / 10f).ToString();
                    hienthi10_view.Vab = ((float)Math.Round(float.Parse(hienthi1.Vab) * 10f) / 10f).ToString();
                    hienthi10_view.Vun = ((float)Math.Round(float.Parse(hienthi1.Vun) * 10f) / 10f).ToString();
                    hienthi10_view.VII = ((float)Math.Round(float.Parse(hienthi1.VII) * 10f) / 10f).ToString();
                    hienthi10_view.Cac = ((float)Math.Round(float.Parse(hienthi1.Cac) * 10f) / 10f).ToString();
                    hienthi10_view.Cab = ((float)Math.Round(float.Parse(hienthi1.Cab) * 10f) / 10f).ToString();
                    hienthi10_view.Caa = ((float)Math.Round(float.Parse(hienthi1.Caa) * 10f) / 10f).ToString();
                    hienthi10_view.Civg = ((float)Math.Round(float.Parse(hienthi1.Civg) * 10f) / 10f).ToString();
                    hienthi10_view.Pc = ((float)Math.Round(float.Parse(hienthi1.Pc) * 10f) / 10f).ToString();
                    hienthi10_view.Pb = ((float)Math.Round(float.Parse(hienthi1.Pb) * 10f) / 10f).ToString();
                    hienthi10_view.Pa = ((float)Math.Round(float.Parse(hienthi1.Pa) * 10f) / 10f).ToString();
                    hienthi10_view.Pkvar = ((float)Math.Round(float.Parse(hienthi1.Pkvar) * 10f) / 10f).ToString();
                    hienthi10_view.Pkva = ((float)Math.Round(float.Parse(hienthi1.Pkva) * 10f) / 10f).ToString();
                    hienthi10_view.Van = ((float)Math.Round(float.Parse(hienthi1.Van) * 10f) / 10f).ToString();
                    hienthi10_view.Vbn = ((float)Math.Round(float.Parse(hienthi1.Vbn) * 10f) / 10f).ToString();
                    hienthi10_view.Vcn = ((float)Math.Round(float.Parse(hienthi1.Vcn) * 10f) / 10f).ToString();
                    hienthi10_view.F = ((float)Math.Round(float.Parse(hienthi1.F) * 10f) / 10f).ToString();
                    hienthi10_view.PF = ((float)Math.Round(float.Parse(hienthi1.PF) * 10f) / 10f).ToString();
                    hienthi10_view.Vin = ((float)Math.Round(float.Parse(hienthi1.Vin) * 10f) / 10f).ToString();
                    hienthi10_view.Ptotal = ((float)Math.Round(float.Parse(hienthi1.Ptotal) * 10f) / 10f).ToString();
                    hienthi10_view.Kwh = ((float)Math.Round(float.Parse(hienthi1.Kwh) * 10f) / 10f).ToString();
                    hienthi10_view.KwhDay = ((float)Math.Round((float.Parse(hienthi1.Kwh) - float.Parse(kenh10_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi10_view, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh11DataOnline()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi1 = db.hienthi1.Where(a => a.Kenh.Equals("11")).FirstOrDefault();
                var recoder1_kenh11_begin = db.recoder1_kenh11.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var hienthi11_view = new Hienthi1View();
                if (hienthi1 != null)
                {
                    var kenh11_Kwh_last = (recoder1_kenh11_begin != null) ? recoder1_kenh11_begin.Kwh : "0";
                    hienthi11_view.Vca = ((float)Math.Round(float.Parse(hienthi1.Vca) * 10f) / 10f).ToString();
                    hienthi11_view.Vbc = ((float)Math.Round(float.Parse(hienthi1.Vbc) * 10f) / 10f).ToString();
                    hienthi11_view.Vab = ((float)Math.Round(float.Parse(hienthi1.Vab) * 10f) / 10f).ToString();
                    hienthi11_view.Vun = ((float)Math.Round(float.Parse(hienthi1.Vun) * 10f) / 10f).ToString();
                    hienthi11_view.VII = ((float)Math.Round(float.Parse(hienthi1.VII) * 10f) / 10f).ToString();
                    hienthi11_view.Cac = ((float)Math.Round(float.Parse(hienthi1.Cac) * 10f) / 10f).ToString();
                    hienthi11_view.Cab = ((float)Math.Round(float.Parse(hienthi1.Cab) * 10f) / 10f).ToString();
                    hienthi11_view.Caa = ((float)Math.Round(float.Parse(hienthi1.Caa) * 10f) / 10f).ToString();
                    hienthi11_view.Civg = ((float)Math.Round(float.Parse(hienthi1.Civg) * 10f) / 10f).ToString();
                    hienthi11_view.Pc = ((float)Math.Round(float.Parse(hienthi1.Pc) * 10f) / 10f).ToString();
                    hienthi11_view.Pb = ((float)Math.Round(float.Parse(hienthi1.Pb) * 10f) / 10f).ToString();
                    hienthi11_view.Pa = ((float)Math.Round(float.Parse(hienthi1.Pa) * 10f) / 10f).ToString();
                    hienthi11_view.Pkvar = ((float)Math.Round(float.Parse(hienthi1.Pkvar) * 10f) / 10f).ToString();
                    hienthi11_view.Pkva = ((float)Math.Round(float.Parse(hienthi1.Pkva) * 10f) / 10f).ToString();
                    hienthi11_view.Van = ((float)Math.Round(float.Parse(hienthi1.Van) * 10f) / 10f).ToString();
                    hienthi11_view.Vbn = ((float)Math.Round(float.Parse(hienthi1.Vbn) * 10f) / 10f).ToString();
                    hienthi11_view.Vcn = ((float)Math.Round(float.Parse(hienthi1.Vcn) * 10f) / 10f).ToString();
                    hienthi11_view.F = ((float)Math.Round(float.Parse(hienthi1.F) * 10f) / 10f).ToString();
                    hienthi11_view.PF = ((float)Math.Round(float.Parse(hienthi1.PF) * 10f) / 10f).ToString();
                    hienthi11_view.Vin = ((float)Math.Round(float.Parse(hienthi1.Vin) * 10f) / 10f).ToString();
                    hienthi11_view.Ptotal = ((float)Math.Round(float.Parse(hienthi1.Ptotal) * 10f) / 10f).ToString();
                    hienthi11_view.Kwh = ((float)Math.Round(float.Parse(hienthi1.Kwh) * 10f) / 10f).ToString();
                    hienthi11_view.KwhDay = ((float)Math.Round((float.Parse(hienthi1.Kwh) - float.Parse(kenh11_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi11_view, JsonRequestBehavior.AllowGet);
            }
        }

    }
}