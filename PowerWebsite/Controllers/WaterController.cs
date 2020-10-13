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

        [HttpGet]
        public JsonResult GetWaterData()
        {
            using (DBModel db = new DBModel())
            {
                DateTime today = DateTime.Today.Date;
                var water = db.water.FirstOrDefault();
                var water_recoder_begin = db.recoder_water.Where(c => c.Thoigian >= today).OrderBy(x => x.Thoigian)
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
    }
}