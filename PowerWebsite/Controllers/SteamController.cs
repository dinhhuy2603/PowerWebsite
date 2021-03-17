using PowerWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PowerWebsite.Controllers
{
    public class SteamController : Controller
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
        public ActionResult PC10()
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
        public ActionResult PC15()
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
        public JsonResult GetSteamPc10Data()
        {
            using (DBModel db = new DBModel())
            {
                DateTime today = DateTime.Today.Date;
                var steam_pc10 = db.steam_pc10.FirstOrDefault();
                var steamPc10_recoder_begin = db.recoder1_steam_pc10.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var steamPc10_view = new SteamPC10View();
                if (steam_pc10 != null)
                {
                    var steamPc10_total_last = (steamPc10_recoder_begin != null) ? steamPc10_recoder_begin.luu_luong_tong : "0";
                    steamPc10_view.luu_luong_hien_tai = ((float)Math.Round(float.Parse(steam_pc10.luu_luong_hien_tai) * 10f) / 10f).ToString();
                    steamPc10_view.luu_luong_tong = ((float)Math.Round(float.Parse(steam_pc10.luu_luong_tong) * 10f) / 10f).ToString();
                    steamPc10_view.luu_luong_tong_ngay = ((float)Math.Round((float.Parse(steam_pc10.luu_luong_tong) - float.Parse(steamPc10_total_last)) * 10f) / 10f).ToString();
                    steamPc10_view.status = steam_pc10.status;
                }
                return Json(steamPc10_view, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetSteamPc15Data()
        {
            using (DBModel db = new DBModel())
            {
                DateTime today = DateTime.Today.Date;
                var steam_pc15 = db.steam_pc15.FirstOrDefault();
                var steamPc15_recoder_begin = db.recoder1_steam_pc15.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var steamPc15_view = new SteamPC10View();
                if (steam_pc15 != null)
                {
                    var steamPc15_total_last = (steamPc15_recoder_begin != null) ? steamPc15_recoder_begin.luu_luong_tong : "0";
                    steamPc15_view.luu_luong_hien_tai = ((float)Math.Round(float.Parse(steam_pc15.luu_luong_hien_tai) * 10f) / 10f).ToString();
                    steamPc15_view.luu_luong_tong = ((float)Math.Round(float.Parse(steam_pc15.luu_luong_tong) * 10f) / 10f).ToString();
                    steamPc15_view.luu_luong_tong_ngay = ((float)Math.Round((float.Parse(steam_pc15.luu_luong_tong) - float.Parse(steamPc15_total_last)) * 10f) / 10f).ToString();
                    steamPc15_view.status = steam_pc15.status;
                }
                return Json(steamPc15_view, JsonRequestBehavior.AllowGet);
            }
        }
    }
}