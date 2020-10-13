using PowerWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PowerWebsite.Controllers
{
    public class HomeController : Controller
    {
        DateTime today = DateTime.Today.Date;
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                using (DBModel db = new DBModel())
                {
                    //Get Gas table
                    var gas = db.gas.FirstOrDefault();
                    var gas_recoder_begin = db.recoder_gas.Where(c => c.Thoigian >= today).OrderBy(x => x.Thoigian)
                             .Take(1).ToList().FirstOrDefault();
                    if (gas != null)
                    {
                        var gas_total_last = (gas_recoder_begin != null) ? gas_recoder_begin.luu_luong_tong : "0";
                        gas.luu_luong_hien_tai = ((float)Math.Round(float.Parse(gas.luu_luong_hien_tai) * 10f) / 10f).ToString();
                        gas.luu_luong_tong = ((float)Math.Round((float.Parse(gas.luu_luong_tong) - float.Parse(gas_total_last)) * 10f) / 10f).ToString();
                    }
                    else
                    {
                        gas = new Gas();
                    }
                    //Get Water table
                    var water = db.water.FirstOrDefault();
                    var water_recoder_begin = db.recoder_water.Where(c => c.Thoigian >= today).OrderBy(x => x.Thoigian)
                             .Take(1).ToList().FirstOrDefault();
                    if (water != null)
                    {
                        var water_total_last = (water_recoder_begin != null) ? water_recoder_begin.luu_luong_tong : "0";
                        water.luu_luong_hien_tai = ((float)Math.Round(float.Parse(water.luu_luong_hien_tai) * 10f) / 10f).ToString();
                        water.luu_luong_tong = ((float)Math.Round((float.Parse(water.luu_luong_tong) - float.Parse(water_total_last)) * 10f) / 10f).ToString();
                    }
                    else
                    {
                        water = new Water();
                    }
                    // Get HienThi Table
                    ViewBag.gas = gas;
                    ViewBag.water = water;
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            //return View();
        }

        public ActionResult Trang2()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public JsonResult GetGasData()
        {
            using (DBModel db = new DBModel())
            {
                DateTime today = DateTime.Today.Date;
                var gas = db.gas.FirstOrDefault();
                var gas_recoder_begin = db.recoder_gas.Where(c => c.Thoigian >= today).OrderBy(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if(gas != null)
                {
                    var gas_total_last = (gas_recoder_begin != null) ? gas_recoder_begin.luu_luong_tong : "0";
                    gas.luu_luong_hien_tai = ((float)Math.Round(float.Parse(gas.luu_luong_hien_tai) * 10f) / 10f).ToString();
                    gas.luu_luong_tong = ((float)Math.Round((float.Parse(gas.luu_luong_tong) - float.Parse(gas_total_last)) * 10f) / 10f).ToString();
                }
                var obj = gas;
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetWaterData()
        {
            using (DBModel db = new DBModel())
            {
                DateTime today = DateTime.Today.Date;
                var water = db.water.FirstOrDefault();
                var water_recoder_begin = db.recoder_water.Where(c => c.Thoigian >= today).OrderBy(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if (water != null)
                {
                    var water_total_last = (water_recoder_begin != null) ? water_recoder_begin.luu_luong_tong : "0";
                    water.luu_luong_hien_tai = ((float)Math.Round(float.Parse(water.luu_luong_hien_tai) * 10f) / 10f).ToString();
                    water.luu_luong_tong = ((float)Math.Round((float.Parse(water.luu_luong_tong) - float.Parse(water_total_last)) * 10f) / 10f).ToString();
                }
                var obj = water;
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetHienThiData(string kenh)
        {
            using (DBModel db = new DBModel())
            {
                var obj_list = db.hienthi.Where(a => a.Kenh.Equals(kenh)).FirstOrDefault();
                return Json(obj_list, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh1Data()
        {
            using (DBModel db = new DBModel())
            {
                                var hienthi1 = db.hienthi.Where(a => a.Kenh.Equals("1")).FirstOrDefault();
                var recoder_kenh1_begin = db.recoder_kenh1.Where(c => c.Thoigian >= today).OrderBy(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if (hienthi1 != null)
                {
                    var kenh1_Kwh_last = (recoder_kenh1_begin != null) ? recoder_kenh1_begin.Kwh : "0";
                    hienthi1.Ptotal = ((float)Math.Round(float.Parse(hienthi1.Ptotal) * 10f) / 10f).ToString();
                    hienthi1.Kwh = ((float)Math.Round((float.Parse(hienthi1.Kwh) - float.Parse(kenh1_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi1 , JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh2Data()
        {
            using (DBModel db = new DBModel())
            {
                DateTime yesterday = DateTime.Today.AddDays(-1).Date;
                DateTime yesterdayEnd = DateTime.Today.Date.AddSeconds(-1);
                var hienthi2 = db.hienthi.Where(a => a.Kenh.Equals("2")).FirstOrDefault();
                var recoder_kenh2_begin = db.recoder_kenh2.Where(c => c.Thoigian >= yesterday && c.Thoigian < yesterdayEnd).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if (hienthi2 != null)
                {
                    hienthi2.Kwh = (Convert.ToDecimal(hienthi2.Kwh) - Convert.ToDecimal(recoder_kenh2_begin.Kwh)).ToString("#,##0");
                }
                return Json(hienthi2, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh3Data()
        {
            using (DBModel db = new DBModel())
            {
                DateTime yesterday = DateTime.Today.AddDays(-1).Date;
                DateTime yesterdayEnd = DateTime.Today.Date.AddSeconds(-1);
                var hienthi3 = db.hienthi.Where(a => a.Kenh.Equals("3")).FirstOrDefault();
                var recoder_kenh3_begin = db.recoder_kenh3.Where(c => c.Thoigian >= yesterday && c.Thoigian < yesterdayEnd).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if (hienthi3 != null)
                {
                    hienthi3.Kwh = (Convert.ToDecimal(hienthi3.Kwh) - Convert.ToDecimal(recoder_kenh3_begin.Kwh)).ToString("#,##0");
                }
                return Json(hienthi3, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh4Data()
        {
            using (DBModel db = new DBModel())
            {
                DateTime yesterday = DateTime.Today.AddDays(-1).Date;
                DateTime yesterdayEnd = DateTime.Today.Date.AddSeconds(-1);
                var hienthi4 = db.hienthi.Where(a => a.Kenh.Equals("4")).FirstOrDefault();
                var recoder_kenh4_begin = db.recoder_kenh4.Where(c => c.Thoigian >= yesterday && c.Thoigian < yesterdayEnd).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if (hienthi4 != null)
                {
                    hienthi4.Kwh = (Convert.ToDecimal(hienthi4.Kwh) - Convert.ToDecimal(recoder_kenh4_begin.Kwh)).ToString("#,##0");
                }
                return Json(hienthi4, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetChartKenh5Data()
        {
            using (DBModel db = new DBModel())
            {
                DateTime yesterday = DateTime.Today.AddDays(-1).Date;
                DateTime yesterdayEnd = DateTime.Today.Date.AddSeconds(-1);
                var hienthi5 = db.hienthi.Where(a => a.Kenh.Equals("5")).FirstOrDefault();
                var recoder_kenh5_begin = db.recoder_kenh5.Where(c => c.Thoigian >= yesterday && c.Thoigian < yesterdayEnd).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if (hienthi5 != null)
                {
                    hienthi5.Kwh = (Convert.ToDecimal(hienthi5.Kwh) - Convert.ToDecimal(recoder_kenh5_begin.Kwh)).ToString("#,##0");
                }
                return Json(hienthi5, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh6Data()
        {
            using (DBModel db = new DBModel())
            {
                DateTime yesterday = DateTime.Today.AddDays(-1).Date;
                DateTime yesterdayEnd = DateTime.Today.Date.AddSeconds(-1);
                var hienthi6 = db.hienthi.Where(a => a.Kenh.Equals("6")).FirstOrDefault();
                var recoder_kenh6_begin = db.recoder_kenh6.Where(c => c.Thoigian >= yesterday && c.Thoigian < yesterdayEnd).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if (hienthi6 != null)
                {
                    hienthi6.Kwh = (Convert.ToDecimal(hienthi6.Kwh) - Convert.ToDecimal(recoder_kenh6_begin.Kwh)).ToString("#,##0");
                }
                return Json(hienthi6, JsonRequestBehavior.AllowGet);
            }
        }
    }
}