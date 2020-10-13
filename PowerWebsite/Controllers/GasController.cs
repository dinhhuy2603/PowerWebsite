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
                var gas_recoder_begin = db.recoder_gas.Where(c => c.Thoigian >= today).OrderBy(x => x.Thoigian)
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
    }
}