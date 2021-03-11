using PowerWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PowerWebsite.Controllers
{
    public class SnackController : Controller
    {
        DateTime today = DateTime.Today.Date;
        DateTime startYesterdayTime = DateTime.Today.AddDays(-1); //Today at 00:00:00
        DateTime endYesterdayTime = DateTime.Today.AddTicks(-1); //Today at 23:59:59

        [HttpGet]
        public JsonResult GetHienThi1Data(string kenh)
        {
            using (DBModel db = new DBModel())
            {
                var obj = db.hienthi1.Where(a => a.Kenh.Equals(kenh)).FirstOrDefault();
                if (obj != null)
                {
                    obj.Vca = ((float)Math.Round(float.Parse(obj.Vca) * 10f) / 10f).ToString();
                    obj.Vbc = ((float)Math.Round(float.Parse(obj.Vbc) * 10f) / 10f).ToString();
                    obj.Vab = ((float)Math.Round(float.Parse(obj.Vab) * 10f) / 10f).ToString();
                    obj.Vun = ((float)Math.Round(float.Parse(obj.Vun) * 10f) / 10f).ToString();
                    obj.VII = ((float)Math.Round(float.Parse(obj.VII) * 10f) / 10f).ToString();
                    obj.Cac = ((float)Math.Round(float.Parse(obj.Cac) * 10f) / 10f).ToString();
                    obj.Cab = ((float)Math.Round(float.Parse(obj.Cab) * 10f) / 10f).ToString();
                    obj.Caa = ((float)Math.Round(float.Parse(obj.Caa) * 10f) / 10f).ToString();
                    obj.Civg = ((float)Math.Round(float.Parse(obj.Civg) * 10f) / 10f).ToString();
                    obj.Pc = ((float)Math.Round(float.Parse(obj.Pc) * 10f) / 10f).ToString();
                    obj.Pb = ((float)Math.Round(float.Parse(obj.Pb) * 10f) / 10f).ToString();
                    obj.Pa = ((float)Math.Round(float.Parse(obj.Pa) * 10f) / 10f).ToString();
                    obj.Ptotal = ((float)Math.Round(float.Parse(obj.Ptotal) * 10f) / 10f).ToString();
                    obj.Pkvar = ((float)Math.Round(float.Parse(obj.Pkvar) * 10f) / 10f).ToString();
                    obj.Pkva = ((float)Math.Round(float.Parse(obj.Pkva) * 10f) / 10f).ToString();
                    obj.Van = ((float)Math.Round(float.Parse(obj.Van) * 10f) / 10f).ToString();
                    obj.Vbn = ((float)Math.Round(float.Parse(obj.Vbn) * 10f) / 10f).ToString();
                    obj.Vcn = ((float)Math.Round(float.Parse(obj.Vcn) * 10f) / 10f).ToString();
                    obj.F = ((float)Math.Round(float.Parse(obj.F) * 10f) / 10f).ToString();
                    obj.PF = (Math.Truncate(100 * float.Parse(obj.PF)) / 100).ToString();
                    obj.Kwh = ((float)Math.Round(float.Parse(obj.Kwh) * 10f) / 10f).ToString();
                    obj.Vin = ((float)Math.Round(float.Parse(obj.Vin) * 10f) / 10f).ToString();
                }
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh4Data()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi1 = db.hienthi1.Where(a => a.Kenh.Equals("4")).FirstOrDefault();
                var recoder_db_pc15_begin = db.recoder1_kenh4.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if (hienthi1 != null)
                {
                    var kenh4_Kwh_last = (recoder_db_pc15_begin != null) ? recoder_db_pc15_begin.Kwh : "0";
                    hienthi1.Ptotal = ((float)Math.Round(float.Parse(hienthi1.Ptotal) * 10f) / 10f).ToString();
                    hienthi1.Kwh = ((float)Math.Round((float.Parse(hienthi1.Kwh) - float.Parse(kenh4_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi1, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh5Data()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi1 = db.hienthi1.Where(a => a.Kenh.Equals("5")).FirstOrDefault();
                var recoder_db_pc10_begin = db.recoder1_kenh5.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if (hienthi1 != null)
                {
                    var kenh5_Kwh_last = (recoder_db_pc10_begin != null) ? recoder_db_pc10_begin.Kwh : "0";
                    hienthi1.Ptotal = ((float)Math.Round(float.Parse(hienthi1.Ptotal) * 10f) / 10f).ToString();
                    hienthi1.Kwh = ((float)Math.Round((float.Parse(hienthi1.Kwh) - float.Parse(kenh5_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi1, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh6Data()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi1 = db.hienthi1.Where(a => a.Kenh.Equals("6")).FirstOrDefault();
                var recoder_db_snack1_begin = db.recoder1_kenh6.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if (hienthi1 != null)
                {
                    var kenh6_Kwh_last = (recoder_db_snack1_begin != null) ? recoder_db_snack1_begin.Kwh : "0";
                    hienthi1.Ptotal = ((float)Math.Round(float.Parse(hienthi1.Ptotal) * 10f) / 10f).ToString();
                    hienthi1.Kwh = ((float)Math.Round((float.Parse(hienthi1.Kwh) - float.Parse(kenh6_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi1, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh7Data()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi1 = db.hienthi1.Where(a => a.Kenh.Equals("7")).FirstOrDefault();
                var recoder_db_snack2_begin = db.recoder1_kenh7.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if (hienthi1 != null)
                {
                    var kenh7_Kwh_last = (recoder_db_snack2_begin != null) ? recoder_db_snack2_begin.Kwh : "0";
                    hienthi1.Ptotal = ((float)Math.Round(float.Parse(hienthi1.Ptotal) * 10f) / 10f).ToString();
                    hienthi1.Kwh = ((float)Math.Round((float.Parse(hienthi1.Kwh) - float.Parse(kenh7_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi1, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh8Data()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi1 = db.hienthi1.Where(a => a.Kenh.Equals("8")).FirstOrDefault();
                var recoder_db_snack3_begin = db.recoder1_kenh8.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if (hienthi1 != null)
                {
                    var kenh8_Kwh_last = (recoder_db_snack3_begin != null) ? recoder_db_snack3_begin.Kwh : "0";
                    hienthi1.Ptotal = ((float)Math.Round(float.Parse(hienthi1.Ptotal) * 10f) / 10f).ToString();
                    hienthi1.Kwh = ((float)Math.Round((float.Parse(hienthi1.Kwh) - float.Parse(kenh8_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi1, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh9Data()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi1 = db.hienthi1.Where(a => a.Kenh.Equals("9")).FirstOrDefault();
                var recoder_db_snack4_begin = db.recoder1_kenh9.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if (hienthi1 != null)
                {
                    var kenh9_Kwh_last = (recoder_db_snack4_begin != null) ? recoder_db_snack4_begin.Kwh : "0";
                    hienthi1.Ptotal = ((float)Math.Round(float.Parse(hienthi1.Ptotal) * 10f) / 10f).ToString();
                    hienthi1.Kwh = ((float)Math.Round((float.Parse(hienthi1.Kwh) - float.Parse(kenh9_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi1, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh10Data()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi1 = db.hienthi1.Where(a => a.Kenh.Equals("10")).FirstOrDefault();
                var recoder_lp_pc15_begin = db.recoder1_kenh10.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if (hienthi1 != null)
                {
                    var kenh10_Kwh_last = (recoder_lp_pc15_begin != null) ? recoder_lp_pc15_begin.Kwh : "0";
                    hienthi1.Ptotal = ((float)Math.Round(float.Parse(hienthi1.Ptotal) * 10f) / 10f).ToString();
                    hienthi1.Kwh = ((float)Math.Round((float.Parse(hienthi1.Kwh) - float.Parse(kenh10_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi1, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh11Data()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi1 = db.hienthi1.Where(a => a.Kenh.Equals("11")).FirstOrDefault();
                var recoder_lp_snack1_begin = db.recoder1_kenh11.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if (hienthi1 != null)
                {
                    var kenh11_Kwh_last = (recoder_lp_snack1_begin != null) ? recoder_lp_snack1_begin.Kwh : "0";
                    hienthi1.Ptotal = ((float)Math.Round(float.Parse(hienthi1.Ptotal) * 10f) / 10f).ToString();
                    hienthi1.Kwh = ((float)Math.Round((float.Parse(hienthi1.Kwh) - float.Parse(kenh11_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi1, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartSolar1Data()
        {
            using (DBModel db = new DBModel())
            {
                var solar1 = db.hienthi1.Where(a => a.Kenh.Equals("1")).FirstOrDefault();
                var recoder_solar1_begin = db.recoder1_db_solar1.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if (solar1 != null)
                {
                    var solar1_Kwh_last = (recoder_solar1_begin != null) ? recoder_solar1_begin.Kwh : "0";
                    solar1.Ptotal = ((float)Math.Round(float.Parse(solar1.Ptotal) * 10f) / 10f).ToString();
                    solar1.Kwh = ((float)Math.Round((float.Parse(solar1.Kwh) - float.Parse(solar1_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(solar1, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartSolar2Data()
        {
            using (DBModel db = new DBModel())
            {
                var solar2 = db.hienthi1.Where(a => a.Kenh.Equals("2")).FirstOrDefault();
                var recoder_solar2_begin = db.recoder1_db_solar2.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if (solar2 != null)
                {
                    var solar2_Kwh_last = (recoder_solar2_begin != null) ? recoder_solar2_begin.Kwh : "0";
                    solar2.Ptotal = ((float)Math.Round(float.Parse(solar2.Ptotal) * 10f) / 10f).ToString();
                    solar2.Kwh = ((float)Math.Round((float.Parse(solar2.Kwh) - float.Parse(solar2_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(solar2, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartLogisticsData()
        {
            using (DBModel db = new DBModel())
            {
                var logistic = db.hienthi1.Where(a => a.Kenh.Equals("3")).FirstOrDefault();
                var recoder_logistic_begin = db.recoder1_db_logistics.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if (logistic != null)
                {
                    var logistic_Kwh_last = (recoder_logistic_begin != null) ? recoder_logistic_begin.Kwh : "0";
                    logistic.Ptotal = ((float)Math.Round(float.Parse(logistic.Ptotal) * 10f) / 10f).ToString();
                    logistic.Kwh = ((float)Math.Round((float.Parse(logistic.Kwh) - float.Parse(logistic_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(logistic, JsonRequestBehavior.AllowGet);
            }
        }

    }
}