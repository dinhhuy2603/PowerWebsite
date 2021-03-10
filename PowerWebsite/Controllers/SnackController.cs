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


    }
}