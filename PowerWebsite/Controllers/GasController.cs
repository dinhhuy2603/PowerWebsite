using PowerWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PowerWebsite.Controllers
{
    public class GasController : Controller
    {
        DateTime startYesterdayTime = DateTime.Today.AddDays(-1); //Today at 00:00:00
        DateTime endYesterdayTime = DateTime.Today.AddTicks(-1); //Today at 23:59:59
        // GET: Gas
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
        public JsonResult GetGasData()
        {
            using (DBModel db = new DBModel())
            {
                DateTime today = DateTime.Today.Date;
                var gas = db.gas.FirstOrDefault();
                var gas_recoder_begin = db.recoder_gas.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var gas_view = new GasView();
                if (gas != null)
                {
                    var gas_total_last = (gas_recoder_begin != null) ? gas_recoder_begin.luu_luong_tong : "0";
                    gas_view.luu_luong_hien_tai = ((float)Math.Round(float.Parse(gas.luu_luong_hien_tai) * 10f) / 10f).ToString();
                    gas_view.luu_luong_tong = ((float)Math.Round(float.Parse(gas.luu_luong_tong) * 10f) / 10f).ToString();
                    gas_view.luu_luong_tong_ngay = ((float)Math.Round((float.Parse(gas.luu_luong_tong) - float.Parse(gas_total_last)) * 10f) / 10f).ToString();
                    gas_view.status = gas.status;
                }
                return Json(gas_view, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetGasCNGData()
        {
            using (DBModel db = new DBModel())
            {
                DateTime today = DateTime.Today.Date;
                var gas = db.gas_cng.FirstOrDefault();
                var gas_cng_recoder_begin = db.recoder1_gas_cng.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var gas_cng_view = new GasCNGView();
                if (gas != null)
                {
                    var gas_cng_total_last = (gas_cng_recoder_begin != null) ? gas_cng_recoder_begin.luu_luong_tong : "0";
                    gas_cng_view.luu_luong_hien_tai = ((float)Math.Round(float.Parse(gas.luu_luong_hien_tai) * 10f) / 10f).ToString();
                    gas_cng_view.luu_luong_tong = ((float)Math.Round(float.Parse(gas.luu_luong_tong) * 10f) / 10f).ToString();
                    gas_cng_view.luu_luong_tong_ngay = ((float)Math.Round((float.Parse(gas.luu_luong_tong) - float.Parse(gas_cng_total_last)) * 10f) / 10f).ToString();
                    gas_cng_view.status = gas.status;
                }
                return Json(gas_cng_view, JsonRequestBehavior.AllowGet);
            }
        }
    }
}