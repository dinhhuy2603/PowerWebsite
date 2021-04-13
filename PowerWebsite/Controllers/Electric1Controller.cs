using PowerWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PowerWebsite.Controllers
{
    public class Electric1Controller : Controller
    {
        DateTime today = DateTime.Today.Date;
        DateTime startYesterdayTime = DateTime.Today.AddDays(-1); //Today at 00:00:00
        DateTime endYesterdayTime = DateTime.Today.AddTicks(-1); //Today at 23:59:59
        // GET: Kenh


        //public ActionResult Kenh1Online()
        //{
        //    if (Session["UserID"] != null)
        //    {
        //        using (DBModel db = new DBModel())
        //        {
        //            ViewBag.kenh1 = new HienthiView();
        //        }
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }
        //}

        public ActionResult Kenh2Online()
        {
            if (Session["UserID"] != null)
            {
                using (DBModel db = new DBModel())
                {
                    ViewBag.kenh2 = new HienthiView();
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult Kenh3Online()
        {
            if (Session["UserID"] != null)
            {
                using (DBModel db = new DBModel())
                {
                    ViewBag.kenh3 = new HienthiView();
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult Kenh4Online()
        {
            if (Session["UserID"] != null)
            {
                using (DBModel db = new DBModel())
                {
                    ViewBag.kenh4 = new HienthiView();
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
                    ViewBag.kenh5 = new HienthiView();
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
                    ViewBag.kenh6 = new HienthiView();
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        //[HttpGet]
        //public JsonResult GetChartKenh1DataOnline()
        //{
        //    using (DBModel db = new DBModel())
        //    {
        //        var hienthi1 = db.hienthi.Where(a => a.Kenh.Equals("1")).FirstOrDefault();
        //        var recoder_kenh1_begin = db.recoder_kenh1.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
        //                 .Take(1).ToList().FirstOrDefault();
        //        var hienthi1_view = new HienthiView();
        //        if (hienthi1 != null)
        //        {
        //            var kenh1_Kwh_last = (recoder_kenh1_begin != null) ? recoder_kenh1_begin.Kwh : "0";
        //            hienthi1_view.Vca = ((float)Math.Round(float.Parse(hienthi1.Vca) * 10f) / 10f).ToString();
        //            hienthi1_view.Vbc = ((float)Math.Round(float.Parse(hienthi1.Vbc) * 10f) / 10f).ToString();
        //            hienthi1_view.Vab = ((float)Math.Round(float.Parse(hienthi1.Vab) * 10f) / 10f).ToString();
        //            hienthi1_view.Vun = ((float)Math.Round(float.Parse(hienthi1.Vun) * 10f) / 10f).ToString();
        //            hienthi1_view.VII = ((float)Math.Round(float.Parse(hienthi1.VII) * 10f) / 10f).ToString();
        //            hienthi1_view.Cac = ((float)Math.Round(float.Parse(hienthi1.Cac) * 10f) / 10f).ToString();
        //            hienthi1_view.Cab = ((float)Math.Round(float.Parse(hienthi1.Cab) * 10f) / 10f).ToString();
        //            hienthi1_view.Caa = ((float)Math.Round(float.Parse(hienthi1.Caa) * 10f) / 10f).ToString();
        //            hienthi1_view.Civg = ((float)Math.Round(float.Parse(hienthi1.Civg) * 10f) / 10f).ToString();
        //            hienthi1_view.Pc = ((float)Math.Round(float.Parse(hienthi1.Pc) * 10f) / 10f).ToString();
        //            hienthi1_view.Pb = ((float)Math.Round(float.Parse(hienthi1.Pb) * 10f) / 10f).ToString();
        //            hienthi1_view.Pa = ((float)Math.Round(float.Parse(hienthi1.Pa) * 10f) / 10f).ToString();
        //            hienthi1_view.Pkvar = ((float)Math.Round(float.Parse(hienthi1.Pkvar) * 10f) / 10f).ToString();
        //            hienthi1_view.Pkva = ((float)Math.Round(float.Parse(hienthi1.Pkva) * 10f) / 10f).ToString();
        //            hienthi1_view.Van = ((float)Math.Round(float.Parse(hienthi1.Van) * 10f) / 10f).ToString();
        //            hienthi1_view.Vbn = ((float)Math.Round(float.Parse(hienthi1.Vbn) * 10f) / 10f).ToString();
        //            hienthi1_view.Vcn = ((float)Math.Round(float.Parse(hienthi1.Vcn) * 10f) / 10f).ToString();
        //            hienthi1_view.F = ((float)Math.Round(float.Parse(hienthi1.F) * 10f) / 10f).ToString();
        //            hienthi1_view.PF = ((float)Math.Round(float.Parse(hienthi1.PF) * 10f) / 10f).ToString();
        //            hienthi1_view.Vin = ((float)Math.Round(float.Parse(hienthi1.Vin) * 10f) / 10f).ToString();
        //            hienthi1_view.Ptotal = ((float)Math.Round(float.Parse(hienthi1.Ptotal) * 10f) / 10f).ToString();
        //            hienthi1_view.Kwh = ((float)Math.Round(float.Parse(hienthi1.Kwh) * 10f) / 10f).ToString();
        //            hienthi1_view.KwhDay = ((float)Math.Round((float.Parse(hienthi1.Kwh) - float.Parse(kenh1_Kwh_last)) * 10f) / 10f).ToString();
        //        }
        //        return Json(hienthi1_view, JsonRequestBehavior.AllowGet);
        //    }
        //}

        [HttpGet]
        public JsonResult GetChartKenh2DataOnline()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi2 = db.hienthi.Where(a => a.Kenh.Equals("2")).FirstOrDefault();
                var recoder_kenh2_begin = db.recoder_kenh2.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var hienthi2_view = new HienthiView();
                if (hienthi2 != null)
                {
                    var kenh2_Kwh_last = (recoder_kenh2_begin != null) ? recoder_kenh2_begin.Kwh : "0";
                    hienthi2_view.Vca = ((float)Math.Round(float.Parse(hienthi2.Vca) * 10f) / 10f).ToString();
                    hienthi2_view.Vbc = ((float)Math.Round(float.Parse(hienthi2.Vbc) * 10f) / 10f).ToString();
                    hienthi2_view.Vab = ((float)Math.Round(float.Parse(hienthi2.Vab) * 10f) / 10f).ToString();
                    hienthi2_view.Vun = ((float)Math.Round(float.Parse(hienthi2.Vun) * 10f) / 10f).ToString();
                    hienthi2_view.VII = ((float)Math.Round(float.Parse(hienthi2.VII) * 10f) / 10f).ToString();
                    hienthi2_view.Cac = ((float)Math.Round(float.Parse(hienthi2.Cac) * 10f) / 10f).ToString();
                    hienthi2_view.Cab = ((float)Math.Round(float.Parse(hienthi2.Cab) * 10f) / 10f).ToString();
                    hienthi2_view.Caa = ((float)Math.Round(float.Parse(hienthi2.Caa) * 10f) / 10f).ToString();
                    hienthi2_view.Civg = ((float)Math.Round(float.Parse(hienthi2.Civg) * 10f) / 10f).ToString();
                    hienthi2_view.Pc = ((float)Math.Round(float.Parse(hienthi2.Pc) * 10f) / 10f).ToString();
                    hienthi2_view.Pb = ((float)Math.Round(float.Parse(hienthi2.Pb) * 10f) / 10f).ToString();
                    hienthi2_view.Pa = ((float)Math.Round(float.Parse(hienthi2.Pa) * 10f) / 10f).ToString();
                    hienthi2_view.Pkvar = ((float)Math.Round(float.Parse(hienthi2.Pkvar) * 10f) / 10f).ToString();
                    hienthi2_view.Pkva = ((float)Math.Round(float.Parse(hienthi2.Pkva) * 10f) / 10f).ToString();
                    hienthi2_view.Van = ((float)Math.Round(float.Parse(hienthi2.Van) * 10f) / 10f).ToString();
                    hienthi2_view.Vbn = ((float)Math.Round(float.Parse(hienthi2.Vbn) * 10f) / 10f).ToString();
                    hienthi2_view.Vcn = ((float)Math.Round(float.Parse(hienthi2.Vcn) * 10f) / 10f).ToString();
                    hienthi2_view.F = ((float)Math.Round(float.Parse(hienthi2.F) * 10f) / 10f).ToString();
                    hienthi2_view.PF = ((float)Math.Round(float.Parse(hienthi2.PF) * 10f) / 10f).ToString();
                    hienthi2_view.Vin = ((float)Math.Round(float.Parse(hienthi2.Vin) * 10f) / 10f).ToString();
                    hienthi2_view.Ptotal = ((float)Math.Round(float.Parse(hienthi2.Ptotal) * 10f) / 10f).ToString();
                    hienthi2_view.Kwh = ((float)Math.Round(float.Parse(hienthi2.Kwh) * 10f) / 10f).ToString();
                    hienthi2_view.KwhDay = ((float)Math.Round((float.Parse(hienthi2.Kwh) - float.Parse(kenh2_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi2_view, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh3DataOnline()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi3 = db.hienthi.Where(a => a.Kenh.Equals("3")).FirstOrDefault();
                var recoder_kenh3_begin = db.recoder_kenh3.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var hienthi3_view = new HienthiView();
                if (hienthi3 != null)
                {
                    var kenh3_Kwh_last = (recoder_kenh3_begin != null) ? recoder_kenh3_begin.Kwh : "0";
                    hienthi3_view.Vca = ((float)Math.Round(float.Parse(hienthi3.Vca) * 10f) / 10f).ToString();
                    hienthi3_view.Vbc = ((float)Math.Round(float.Parse(hienthi3.Vbc) * 10f) / 10f).ToString();
                    hienthi3_view.Vab = ((float)Math.Round(float.Parse(hienthi3.Vab) * 10f) / 10f).ToString();
                    hienthi3_view.Vun = ((float)Math.Round(float.Parse(hienthi3.Vun) * 10f) / 10f).ToString();
                    hienthi3_view.VII = ((float)Math.Round(float.Parse(hienthi3.VII) * 10f) / 10f).ToString();
                    hienthi3_view.Cac = ((float)Math.Round(float.Parse(hienthi3.Cac) * 10f) / 10f).ToString();
                    hienthi3_view.Cab = ((float)Math.Round(float.Parse(hienthi3.Cab) * 10f) / 10f).ToString();
                    hienthi3_view.Caa = ((float)Math.Round(float.Parse(hienthi3.Caa) * 10f) / 10f).ToString();
                    hienthi3_view.Civg = ((float)Math.Round(float.Parse(hienthi3.Civg) * 10f) / 10f).ToString();
                    hienthi3_view.Pc = ((float)Math.Round(float.Parse(hienthi3.Pc) * 10f) / 10f).ToString();
                    hienthi3_view.Pb = ((float)Math.Round(float.Parse(hienthi3.Pb) * 10f) / 10f).ToString();
                    hienthi3_view.Pa = ((float)Math.Round(float.Parse(hienthi3.Pa) * 10f) / 10f).ToString();
                    hienthi3_view.Pkvar = ((float)Math.Round(float.Parse(hienthi3.Pkvar) * 10f) / 10f).ToString();
                    hienthi3_view.Pkva = ((float)Math.Round(float.Parse(hienthi3.Pkva) * 10f) / 10f).ToString();
                    hienthi3_view.Van = ((float)Math.Round(float.Parse(hienthi3.Van) * 10f) / 10f).ToString();
                    hienthi3_view.Vbn = ((float)Math.Round(float.Parse(hienthi3.Vbn) * 10f) / 10f).ToString();
                    hienthi3_view.Vcn = ((float)Math.Round(float.Parse(hienthi3.Vcn) * 10f) / 10f).ToString();
                    hienthi3_view.F = ((float)Math.Round(float.Parse(hienthi3.F) * 10f) / 10f).ToString();
                    hienthi3_view.PF = ((float)Math.Round(float.Parse(hienthi3.PF) * 10f) / 10f).ToString();
                    hienthi3_view.Vin = ((float)Math.Round(float.Parse(hienthi3.Vin) * 10f) / 10f).ToString();
                    hienthi3_view.Ptotal = ((float)Math.Round(float.Parse(hienthi3.Ptotal) * 10f) / 10f).ToString();
                    hienthi3_view.Kwh = ((float)Math.Round(float.Parse(hienthi3.Kwh) * 10f) / 10f).ToString();
                    hienthi3_view.KwhDay = ((float)Math.Round((float.Parse(hienthi3.Kwh) - float.Parse(kenh3_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi3_view, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh4DataOnline()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi4 = db.hienthi.Where(a => a.Kenh.Equals("4")).FirstOrDefault();
                var recoder_kenh4_begin = db.recoder_kenh4.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var hienthi4_view = new HienthiView();
                if (hienthi4 != null)
                {
                    var kenh4_Kwh_last = (recoder_kenh4_begin != null) ? recoder_kenh4_begin.Kwh : "0";
                    hienthi4_view.Vca = ((float)Math.Round(float.Parse(hienthi4.Vca) * 10f) / 10f).ToString();
                    hienthi4_view.Vbc = ((float)Math.Round(float.Parse(hienthi4.Vbc) * 10f) / 10f).ToString();
                    hienthi4_view.Vab = ((float)Math.Round(float.Parse(hienthi4.Vab) * 10f) / 10f).ToString();
                    hienthi4_view.Vun = ((float)Math.Round(float.Parse(hienthi4.Vun) * 10f) / 10f).ToString();
                    hienthi4_view.VII = ((float)Math.Round(float.Parse(hienthi4.VII) * 10f) / 10f).ToString();
                    hienthi4_view.Cac = ((float)Math.Round(float.Parse(hienthi4.Cac) * 10f) / 10f).ToString();
                    hienthi4_view.Cab = ((float)Math.Round(float.Parse(hienthi4.Cab) * 10f) / 10f).ToString();
                    hienthi4_view.Caa = ((float)Math.Round(float.Parse(hienthi4.Caa) * 10f) / 10f).ToString();
                    hienthi4_view.Civg = ((float)Math.Round(float.Parse(hienthi4.Civg) * 10f) / 10f).ToString();
                    hienthi4_view.Pc = ((float)Math.Round(float.Parse(hienthi4.Pc) * 10f) / 10f).ToString();
                    hienthi4_view.Pb = ((float)Math.Round(float.Parse(hienthi4.Pb) * 10f) / 10f).ToString();
                    hienthi4_view.Pa = ((float)Math.Round(float.Parse(hienthi4.Pa) * 10f) / 10f).ToString();
                    hienthi4_view.Pkvar = ((float)Math.Round(float.Parse(hienthi4.Pkvar) * 10f) / 10f).ToString();
                    hienthi4_view.Pkva = ((float)Math.Round(float.Parse(hienthi4.Pkva) * 10f) / 10f).ToString();
                    hienthi4_view.Van = ((float)Math.Round(float.Parse(hienthi4.Van) * 10f) / 10f).ToString();
                    hienthi4_view.Vbn = ((float)Math.Round(float.Parse(hienthi4.Vbn) * 10f) / 10f).ToString();
                    hienthi4_view.Vcn = ((float)Math.Round(float.Parse(hienthi4.Vcn) * 10f) / 10f).ToString();
                    hienthi4_view.F = ((float)Math.Round(float.Parse(hienthi4.F) * 10f) / 10f).ToString();
                    hienthi4_view.PF = ((float)Math.Round(float.Parse(hienthi4.PF) * 10f) / 10f).ToString();
                    hienthi4_view.Vin = ((float)Math.Round(float.Parse(hienthi4.Vin) * 10f) / 10f).ToString();
                    hienthi4_view.Ptotal = ((float)Math.Round(float.Parse(hienthi4.Ptotal) * 10f) / 10f).ToString();
                    hienthi4_view.Kwh = ((float)Math.Round(float.Parse(hienthi4.Kwh) * 10f) / 10f).ToString();
                    hienthi4_view.KwhDay = ((float)Math.Round((float.Parse(hienthi4.Kwh) - float.Parse(kenh4_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi4_view, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetChartKenh5DataOnline()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi5 = db.hienthi.Where(a => a.Kenh.Equals("5")).FirstOrDefault();
                var recoder_kenh5_begin = db.recoder_kenh5.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var hienthi5_view = new HienthiView();
                if (hienthi5 != null)
                {
                    var kenh5_Kwh_last = (recoder_kenh5_begin != null) ? recoder_kenh5_begin.Kwh : "0";
                    hienthi5_view.Vca = ((float)Math.Round(float.Parse(hienthi5.Vca) * 10f) / 10f).ToString();
                    hienthi5_view.Vbc = ((float)Math.Round(float.Parse(hienthi5.Vbc) * 10f) / 10f).ToString();
                    hienthi5_view.Vab = ((float)Math.Round(float.Parse(hienthi5.Vab) * 10f) / 10f).ToString();
                    hienthi5_view.Vun = ((float)Math.Round(float.Parse(hienthi5.Vun) * 10f) / 10f).ToString();
                    hienthi5_view.VII = ((float)Math.Round(float.Parse(hienthi5.VII) * 10f) / 10f).ToString();
                    hienthi5_view.Cac = ((float)Math.Round(float.Parse(hienthi5.Cac) * 10f) / 10f).ToString();
                    hienthi5_view.Cab = ((float)Math.Round(float.Parse(hienthi5.Cab) * 10f) / 10f).ToString();
                    hienthi5_view.Caa = ((float)Math.Round(float.Parse(hienthi5.Caa) * 10f) / 10f).ToString();
                    hienthi5_view.Civg = ((float)Math.Round(float.Parse(hienthi5.Civg) * 10f) / 10f).ToString();
                    hienthi5_view.Pc = ((float)Math.Round(float.Parse(hienthi5.Pc) * 10f) / 10f).ToString();
                    hienthi5_view.Pb = ((float)Math.Round(float.Parse(hienthi5.Pb) * 10f) / 10f).ToString();
                    hienthi5_view.Pa = ((float)Math.Round(float.Parse(hienthi5.Pa) * 10f) / 10f).ToString();
                    hienthi5_view.Pkvar = ((float)Math.Round(float.Parse(hienthi5.Pkvar) * 10f) / 10f).ToString();
                    hienthi5_view.Pkva = ((float)Math.Round(float.Parse(hienthi5.Pkva) * 10f) / 10f).ToString();
                    hienthi5_view.Van = ((float)Math.Round(float.Parse(hienthi5.Van) * 10f) / 10f).ToString();
                    hienthi5_view.Vbn = ((float)Math.Round(float.Parse(hienthi5.Vbn) * 10f) / 10f).ToString();
                    hienthi5_view.Vcn = ((float)Math.Round(float.Parse(hienthi5.Vcn) * 10f) / 10f).ToString();
                    hienthi5_view.F = ((float)Math.Round(float.Parse(hienthi5.F) * 10f) / 10f).ToString();
                    hienthi5_view.PF = ((float)Math.Round(float.Parse(hienthi5.PF) * 10f) / 10f).ToString();
                    hienthi5_view.Vin = ((float)Math.Round(float.Parse(hienthi5.Vin) * 10f) / 10f).ToString();
                    hienthi5_view.Ptotal = ((float)Math.Round(float.Parse(hienthi5.Ptotal) * 10f) / 10f).ToString();
                    hienthi5_view.Kwh = ((float)Math.Round(float.Parse(hienthi5.Kwh) * 10f) / 10f).ToString();
                    hienthi5_view.KwhDay = ((float)Math.Round((float.Parse(hienthi5.Kwh) - float.Parse(kenh5_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi5_view, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh6DataOnline()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi6 = db.hienthi.Where(a => a.Kenh.Equals("6")).FirstOrDefault();
                var recoder_kenh6_begin = db.recoder_kenh6.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var hienthi6_view = new HienthiView();
                if (hienthi6 != null)
                {
                    var kenh6_Kwh_last = (recoder_kenh6_begin != null) ? recoder_kenh6_begin.Kwh : "0";
                    hienthi6_view.Vca = ((float)Math.Round(float.Parse(hienthi6.Vca) * 10f) / 10f).ToString();
                    hienthi6_view.Vbc = ((float)Math.Round(float.Parse(hienthi6.Vbc) * 10f) / 10f).ToString();
                    hienthi6_view.Vab = ((float)Math.Round(float.Parse(hienthi6.Vab) * 10f) / 10f).ToString();
                    hienthi6_view.Vun = ((float)Math.Round(float.Parse(hienthi6.Vun) * 10f) / 10f).ToString();
                    hienthi6_view.VII = ((float)Math.Round(float.Parse(hienthi6.VII) * 10f) / 10f).ToString();
                    hienthi6_view.Cac = ((float)Math.Round(float.Parse(hienthi6.Cac) * 10f) / 10f).ToString();
                    hienthi6_view.Cab = ((float)Math.Round(float.Parse(hienthi6.Cab) * 10f) / 10f).ToString();
                    hienthi6_view.Caa = ((float)Math.Round(float.Parse(hienthi6.Caa) * 10f) / 10f).ToString();
                    hienthi6_view.Civg = ((float)Math.Round(float.Parse(hienthi6.Civg) * 10f) / 10f).ToString();
                    hienthi6_view.Pc = ((float)Math.Round(float.Parse(hienthi6.Pc) * 10f) / 10f).ToString();
                    hienthi6_view.Pb = ((float)Math.Round(float.Parse(hienthi6.Pb) * 10f) / 10f).ToString();
                    hienthi6_view.Pa = ((float)Math.Round(float.Parse(hienthi6.Pa) * 10f) / 10f).ToString();
                    hienthi6_view.Pkvar = ((float)Math.Round(float.Parse(hienthi6.Pkvar) * 10f) / 10f).ToString();
                    hienthi6_view.Pkva = ((float)Math.Round(float.Parse(hienthi6.Pkva) * 10f) / 10f).ToString();
                    hienthi6_view.Van = ((float)Math.Round(float.Parse(hienthi6.Van) * 10f) / 10f).ToString();
                    hienthi6_view.Vbn = ((float)Math.Round(float.Parse(hienthi6.Vbn) * 10f) / 10f).ToString();
                    hienthi6_view.Vcn = ((float)Math.Round(float.Parse(hienthi6.Vcn) * 10f) / 10f).ToString();
                    hienthi6_view.F = ((float)Math.Round(float.Parse(hienthi6.F) * 10f) / 10f).ToString();
                    hienthi6_view.PF = ((float)Math.Round(float.Parse(hienthi6.PF) * 10f) / 10f).ToString();
                    hienthi6_view.Vin = ((float)Math.Round(float.Parse(hienthi6.Vin) * 10f) / 10f).ToString();
                    hienthi6_view.Ptotal = ((float)Math.Round(float.Parse(hienthi6.Ptotal) * 10f) / 10f).ToString();
                    hienthi6_view.Kwh = ((float)Math.Round(float.Parse(hienthi6.Kwh) * 10f) / 10f).ToString();
                    hienthi6_view.KwhDay = ((float)Math.Round((float.Parse(hienthi6.Kwh) - float.Parse(kenh6_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi6_view, JsonRequestBehavior.AllowGet);
            }
        }
    }
}