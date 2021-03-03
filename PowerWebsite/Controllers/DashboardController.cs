using PowerWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PowerWebsite.Controllers
{
    public class DashboardController : Controller
    {
        DateTime today = DateTime.Today.Date;
        DateTime startYesterdayTime = DateTime.Today.AddDays(-1); //Today at 00:00:00
        DateTime endYesterdayTime = DateTime.Today.AddTicks(-1); //Today at 23:59:59
        // GET: Dashboard
        public ActionResult Index()
        {
            using (DBModel db = new DBModel())
            {
                //Get Gas table
                var gas = db.gas.FirstOrDefault();
                var gas_recoder_begin = db.recoder_gas.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
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
                var water_recoder_begin = db.recoder_water.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
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
                ViewBag.gas = gas;
                ViewBag.water = water;
            }
            return View();
        }
    }
}