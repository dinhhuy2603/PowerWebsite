using PowerWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PowerWebsite.Controllers
{
    public class WaterController : Controller
    {
        DateTime startYesterdayTime = DateTime.Today.AddDays(-1); //Today at 00:00:00
        DateTime endYesterdayTime = DateTime.Today.AddTicks(-1); //Today at 23:59:59
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
        public ActionResult WaterPc15()
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

        [HttpGet]
        public JsonResult GetWaterData()
        {
            using (DBModel db = new DBModel())
            {
                DateTime today = DateTime.Today.Date;
                var water = db.water.FirstOrDefault();
                var water_recoder_begin = db.recoder_water.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var water_view = new WaterView();
                if (water != null)
                {
                    var water_total_last = (water_recoder_begin != null) ? water_recoder_begin.luu_luong_tong : "0";
                    water_view.luu_luong_hien_tai = ((float)Math.Round(float.Parse(water.luu_luong_hien_tai) * 10f) / 10f).ToString();
                    water_view.luu_luong_tong = ((float)Math.Round(float.Parse(water.luu_luong_tong) * 10f) / 10f).ToString();
                    water_view.luu_luong_tong_ngay = ((float)Math.Round((float.Parse(water.luu_luong_tong) - float.Parse(water_total_last)) * 10f) / 10f).ToString();
                    water_view.status = water.status;
                }
                return Json(water_view, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetWaterPc15Data()
        {
            using (DBModel db = new DBModel())
            {
                DateTime today = DateTime.Today.Date;
                var waterPc15 = db.water_pc15.FirstOrDefault();
                var waterPc15_recoder_begin = db.recoder1_water_pc15.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var waterPc15_view = new WaterPC15View();
                if (waterPc15 != null)
                {
                    var water_total_last = (waterPc15_recoder_begin != null) ? waterPc15_recoder_begin.luu_luong_tong : "0";
                    waterPc15_view.luu_luong_hien_tai = ((float)Math.Round(float.Parse(waterPc15.luu_luong_hien_tai) * 10f) / 10f).ToString();
                    waterPc15_view.luu_luong_tong = ((float)Math.Round(float.Parse(waterPc15.luu_luong_tong) * 10f) / 10f).ToString();
                    waterPc15_view.luu_luong_tong_ngay = ((float)Math.Round((float.Parse(waterPc15.luu_luong_tong) - float.Parse(water_total_last)) * 10f) / 10f).ToString();
                    waterPc15_view.status = waterPc15.status;
                }
                return Json(waterPc15_view, JsonRequestBehavior.AllowGet);
            }
        }
    }
}