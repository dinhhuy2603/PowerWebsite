using PowerWebsite.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PowerWebsite.Controllers
{
    public class HomeController : Controller
    {
        DateTime today = DateTime.Today.Date;
        DateTime startYesterdayTime = DateTime.Today.AddDays(-1); //Today at 00:00:00
        DateTime endYesterdayTime = DateTime.Today.AddTicks(-1); //Today at 23:59:59

        float kenh1_2009 = (float)226.72;
        float kenh2_2009 = (float)30813.393;
        float kenh3_2009 = (float)18308.866;
        float kenh4_2009 = (float)83015.867;
        float kenh5_2009 = (float)28150.823;
        float kenh6_2009 = (float)291055.695;
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                using (DBModel db = new DBModel())
                {
                    //Get Gas table
                    var gas = db.gas.FirstOrDefault();
                    var gas_recoder_begin = db.recoder_gas.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                             .Take(1).ToList().FirstOrDefault();
                    var gas_view = new GasView();
                    if (gas != null)
                    {
                        var gas_total_last = (gas_recoder_begin != null) ? gas_recoder_begin.luu_luong_tong : "0";
                        gas_view.luu_luong_hien_tai = string.Format("{0:#,##0.##}", ((float)Math.Round(float.Parse(gas.luu_luong_hien_tai) * 10f) / 10f));
                        gas_view.luu_luong_tong = string.Format("{0:#,##0.##}", ((float)Math.Round(float.Parse(gas.luu_luong_tong) * 10f) / 10f));
                        gas_view.luu_luong_tong_ngay = string.Format("{0:#,##0.##}", ((float)Math.Round((float.Parse(gas.luu_luong_tong) - float.Parse(gas_total_last)) * 10f) / 10f));
                        gas_view.status = gas.status;
                    }
                    //Get Water table
                    var water = db.water.FirstOrDefault();
                    var water_recoder_begin = db.recoder_water.Where(c => c.Thoigian >= today).OrderBy(x => x.Thoigian)
                             .Take(1).ToList().FirstOrDefault();
                    var water_view = new WaterView();
                    if (water != null)
                    {
                        var water_total_last = (water_recoder_begin != null) ? water_recoder_begin.luu_luong_tong : "0";
                        water_view.luu_luong_hien_tai = string.Format("{0:#,##0.##}", ((float)Math.Round(float.Parse(water.luu_luong_hien_tai) * 10f) / 10f));
                        water_view.luu_luong_tong = string.Format("{0:#,##0.##}", ((float)Math.Round(float.Parse(water.luu_luong_tong) * 10f) / 10f));
                        water_view.luu_luong_tong_ngay = string.Format("{0:#,##0.##}", ((float)Math.Round((float.Parse(water.luu_luong_tong) - float.Parse(water_total_last)) * 10f) / 10f));
                        water_view.status = water.status;
                    }

                    var hienthi = db.hienthi.Select(i => new HienthiOverView { Kenh = i.Kenh, Ptotal = i.Ptotal, Kwh = i.Kwh, KWhDay = "0" }).ToList();
                    //var hienthi = db.hienthi.Select(i => new { i.Kenh, i.Ptotal, i.Kwh }).ToList();
                    var recoder_kenh1_begin = db.recoder_kenh1.Where(c => c.Thoigian >= today).OrderBy(x => x.Thoigian)
                                .Take(1).ToList().FirstOrDefault();
                    var recoder_kenh2_begin = db.recoder_kenh2.Where(c => c.Thoigian >= today).OrderBy(x => x.Thoigian)
                                .Take(1).ToList().FirstOrDefault();
                    var recoder_kenh3_begin = db.recoder_kenh3.Where(c => c.Thoigian >= today).OrderBy(x => x.Thoigian)
                                .Take(1).ToList().FirstOrDefault();
                    var recoder_kenh4_begin = db.recoder_kenh4.Where(c => c.Thoigian >= today).OrderBy(x => x.Thoigian)
                                .Take(1).ToList().FirstOrDefault();
                    var recoder_kenh5_begin = db.recoder_kenh5.Where(c => c.Thoigian >= today).OrderBy(x => x.Thoigian)
                                .Take(1).ToList().FirstOrDefault();
                    var recoder_kenh6_begin = db.recoder_kenh6.Where(c => c.Thoigian >= today).OrderBy(x => x.Thoigian)
                                .Take(1).ToList().FirstOrDefault();

                    var kenh1 = new HienthiOverView();
                    var kenh2 = new HienthiOverView();
                    var kenh3 = new HienthiOverView();
                    var kenh4 = new HienthiOverView();
                    var kenh5 = new HienthiOverView();
                    var kenh6 = new HienthiOverView();
                    float sum_Ptotal = 0;
                    float sum_Kwh = 0;
                    float sum_Kwh_inday = 0;
                    if (hienthi != null)
                    {
                        var kenh1_Kwh_last = (recoder_kenh1_begin != null) ? recoder_kenh1_begin.Kwh : "0";
                        var kenh2_Kwh_last = (recoder_kenh2_begin != null) ? recoder_kenh2_begin.Kwh : "0";
                        var kenh3_Kwh_last = (recoder_kenh3_begin != null) ? recoder_kenh3_begin.Kwh : "0";
                        var kenh4_Kwh_last = (recoder_kenh4_begin != null) ? recoder_kenh4_begin.Kwh : "0";
                        var kenh5_Kwh_last = (recoder_kenh5_begin != null) ? recoder_kenh5_begin.Kwh : "0";
                        var kenh6_Kwh_last = (recoder_kenh6_begin != null) ? recoder_kenh6_begin.Kwh : "0";
                        for (var i = 0; i < hienthi.Count; i++)
                        {
                            switch (hienthi[i].Kenh)
                            {
                                case "1":
                                    kenh1.Kenh = hienthi[i].Kenh;
                                    kenh1.Ptotal = ((float)Math.Round(float.Parse(hienthi[i].Ptotal) * 10f) / 10f).ToString();
                                    kenh1.Kwh = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh1_2009) * 10f) / 10f).ToString();
                                    kenh1.KWhDay = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - float.Parse(kenh1_Kwh_last)) * 10f) / 10f).ToString();
                                    sum_Kwh_inday += float.Parse(kenh1.KWhDay);
                                    sum_Kwh += float.Parse(kenh1.Kwh);
                                    break;
                                case "2":
                                    kenh2.Kenh = hienthi[i].Kenh;
                                    kenh2.Ptotal = ((float)Math.Round(float.Parse(hienthi[i].Ptotal) * 10f) / 10f).ToString();
                                    kenh2.Kwh = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh2_2009) * 10f) / 10f).ToString();
                                    kenh2.KWhDay = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - float.Parse(kenh2_Kwh_last)) * 10f) / 10f).ToString();
                                    sum_Kwh_inday += float.Parse(kenh2.KWhDay);
                                    sum_Kwh += float.Parse(kenh2.Kwh);
                                    break;
                                case "3":
                                    kenh3.Kenh = hienthi[i].Kenh;
                                    kenh3.Ptotal = ((float)Math.Round(float.Parse(hienthi[i].Ptotal) * 10f) / 10f).ToString();
                                    kenh3.Kwh = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh3_2009) * 10f) / 10f).ToString();
                                    kenh3.KWhDay = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - float.Parse(kenh3_Kwh_last)) * 10f) / 10f).ToString();
                                    sum_Kwh_inday += float.Parse(kenh3.KWhDay);
                                    sum_Kwh += float.Parse(kenh3.Kwh);
                                    break;
                                case "4":
                                    kenh4.Kenh = hienthi[i].Kenh;
                                    kenh4.Ptotal = ((float)Math.Round(float.Parse(hienthi[i].Ptotal) * 10f) / 10f).ToString();
                                    kenh4.Kwh = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh4_2009) * 10f) / 10f).ToString();
                                    kenh4.KWhDay = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - float.Parse(kenh4_Kwh_last)) * 10f) / 10f).ToString();
                                    sum_Kwh_inday += float.Parse(kenh4.KWhDay);
                                    sum_Kwh += float.Parse(kenh4.Kwh);
                                    break;
                                case "5":
                                    kenh5.Kenh = hienthi[i].Kenh;
                                    kenh5.Ptotal = ((float)Math.Round(float.Parse(hienthi[i].Ptotal) * 10f) / 10f).ToString();
                                    kenh5.Kwh = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh5_2009) * 10f) / 10f).ToString();
                                    kenh5.KWhDay = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - float.Parse(kenh5_Kwh_last)) * 10f) / 10f).ToString();
                                    sum_Kwh_inday += float.Parse(kenh5.KWhDay);
                                    sum_Kwh += float.Parse(kenh5.Kwh);
                                    break;
                                case "6":
                                    kenh6.Kenh = hienthi[i].Kenh;
                                    kenh6.Ptotal = ((float)Math.Round(float.Parse(hienthi[i].Ptotal) * 10f) / 10f).ToString();
                                    kenh6.Kwh = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh6_2009) * 10f) / 10f).ToString();
                                    kenh6.KWhDay = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - float.Parse(kenh6_Kwh_last)) * 10f) / 10f).ToString();
                                    sum_Kwh_inday += float.Parse(kenh6.KWhDay);
                                    sum_Kwh += float.Parse(kenh6.Kwh);
                                    break;
                                default:
                                    break;
                            }
                            sum_Ptotal += float.Parse(hienthi[i].Ptotal);
                        }
                    }
                    ViewBag.sumPtotal = string.Format("{0:#,##0.##}", (float)Math.Round(sum_Ptotal * 10f) / 10f);
                    ViewBag.sumKwh = string.Format("{0:#,##0.##}", (float)Math.Round((sum_Kwh / 1000) * 10f) / 10f);
                    ViewBag.sumKwhInday = string.Format("{0:#,##0.##}", (float)Math.Round(sum_Kwh_inday * 10f) / 10f);
                    ViewBag.gas = gas_view;
                    ViewBag.water = water_view;
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // Get Index Realtime Data (Energy Overview)
        [HttpGet]
        public JsonResult GetIndexData()
        {
            using (DBModel db = new DBModel())
            {
                //Get Gas table
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
                //Get Water table
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

                var hienthi = db.hienthi.Select(i => new HienthiOverView { Kenh = i.Kenh, Ptotal = i.Ptotal, Kwh = i.Kwh, KWhDay = "0" }).ToList();
                //var hienthi = db.hienthi.Select(i => new { i.Kenh, i.Ptotal, i.Kwh }).ToList();
                var recoder_kenh1_begin = db.recoder_kenh1.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                            .Take(1).ToList().FirstOrDefault();
                var recoder_kenh2_begin = db.recoder_kenh2.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                            .Take(1).ToList().FirstOrDefault();
                var recoder_kenh3_begin = db.recoder_kenh3.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                            .Take(1).ToList().FirstOrDefault();
                var recoder_kenh4_begin = db.recoder_kenh4.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                            .Take(1).ToList().FirstOrDefault();
                var recoder_kenh5_begin = db.recoder_kenh5.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                            .Take(1).ToList().FirstOrDefault();
                var recoder_kenh6_begin = db.recoder_kenh6.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                            .Take(1).ToList().FirstOrDefault();

                var kenh1 = new HienthiOverView();
                var kenh2 = new HienthiOverView();
                var kenh3 = new HienthiOverView();
                var kenh4 = new HienthiOverView();
                var kenh5 = new HienthiOverView();
                var kenh6 = new HienthiOverView();
                float sum_ptotal = 0;
                float sum_kwh = 0;
                float sum_kwh_inday = 0;
                var hienthi_overview = new HienthiOverView();
                if (hienthi != null)
                {
                    var kenh1_Kwh_last = (recoder_kenh1_begin != null) ? recoder_kenh1_begin.Kwh : "0";
                    var kenh2_Kwh_last = (recoder_kenh2_begin != null) ? recoder_kenh2_begin.Kwh : "0";
                    var kenh3_Kwh_last = (recoder_kenh3_begin != null) ? recoder_kenh3_begin.Kwh : "0";
                    var kenh4_Kwh_last = (recoder_kenh4_begin != null) ? recoder_kenh4_begin.Kwh : "0";
                    var kenh5_Kwh_last = (recoder_kenh5_begin != null) ? recoder_kenh5_begin.Kwh : "0";
                    var kenh6_Kwh_last = (recoder_kenh6_begin != null) ? recoder_kenh6_begin.Kwh : "0";
                    for (var i = 0; i < hienthi.Count; i++)
                    {
                        switch (hienthi[i].Kenh)
                        {
                            case "1":
                                kenh1.Kenh = hienthi[i].Kenh;
                                kenh1.Ptotal = ((float)Math.Round(float.Parse(hienthi[i].Ptotal) * 10f) / 10f).ToString();
                                kenh1.Kwh = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh1_2009) * 10f) / 10f).ToString();
                                kenh1.KWhDay = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - float.Parse(kenh1_Kwh_last)) * 10f) / 10f).ToString();
                                sum_ptotal += float.Parse(kenh1.Ptotal);
                                sum_kwh_inday += float.Parse(kenh1.KWhDay);
                                sum_kwh += float.Parse(kenh1.Kwh);
                                break;
                            case "2":
                                kenh2.Kenh = hienthi[i].Kenh;
                                kenh2.Ptotal = ((float)Math.Round(float.Parse(hienthi[i].Ptotal) * 10f) / 10f).ToString();
                                kenh2.Kwh = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh2_2009) * 10f) / 10f).ToString();
                                kenh2.KWhDay = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - float.Parse(kenh2_Kwh_last)) * 10f) / 10f).ToString();
                                sum_ptotal += float.Parse(kenh2.Ptotal);
                                sum_kwh_inday += float.Parse(kenh2.KWhDay);
                                sum_kwh += float.Parse(kenh2.Kwh);
                                break;
                            case "3":
                                kenh3.Kenh = hienthi[i].Kenh;
                                kenh3.Ptotal = ((float)Math.Round(float.Parse(hienthi[i].Ptotal) * 10f) / 10f).ToString();
                                kenh3.Kwh = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh3_2009) * 10f) / 10f).ToString();
                                kenh3.KWhDay = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - float.Parse(kenh3_Kwh_last)) * 10f) / 10f).ToString();
                                sum_ptotal += float.Parse(kenh3.Ptotal);
                                sum_kwh_inday += float.Parse(kenh3.KWhDay);
                                sum_kwh += float.Parse(kenh3.Kwh);
                                break;
                            case "4":
                                kenh4.Kenh = hienthi[i].Kenh;
                                kenh4.Ptotal = ((float)Math.Round(float.Parse(hienthi[i].Ptotal) * 10f) / 10f).ToString();
                                kenh4.Kwh = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh4_2009) * 10f) / 10f).ToString();
                                kenh4.KWhDay = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - float.Parse(kenh4_Kwh_last)) * 10f) / 10f).ToString();
                                sum_ptotal += float.Parse(kenh4.Ptotal);
                                sum_kwh_inday += float.Parse(kenh4.KWhDay);
                                sum_kwh += float.Parse(kenh4.Kwh);
                                break;
                            case "5":
                                kenh5.Kenh = hienthi[i].Kenh;
                                kenh5.Ptotal = ((float)Math.Round(float.Parse(hienthi[i].Ptotal) * 10f) / 10f).ToString();
                                kenh5.Kwh = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh5_2009) * 10f) / 10f).ToString();
                                kenh5.KWhDay = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - float.Parse(kenh5_Kwh_last)) * 10f) / 10f).ToString();
                                sum_ptotal += float.Parse(kenh5.Ptotal);
                                sum_kwh_inday += float.Parse(kenh5.KWhDay);
                                sum_kwh += float.Parse(kenh5.Kwh);
                                break;
                            case "6":
                                kenh6.Kenh = hienthi[i].Kenh;
                                kenh6.Ptotal = ((float)Math.Round(float.Parse(hienthi[i].Ptotal) * 10f) / 10f).ToString();
                                kenh6.Kwh = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh6_2009) * 10f) / 10f).ToString();
                                kenh6.KWhDay = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - float.Parse(kenh6_Kwh_last)) * 10f) / 10f).ToString();
                                sum_ptotal += float.Parse(kenh6.Ptotal);
                                sum_kwh_inday += float.Parse(kenh6.KWhDay);
                                sum_kwh += float.Parse(kenh6.Kwh);
                                break;
                            default:
                                break;
                        }
                    }
                }
                hienthi_overview.Ptotal = ((float)Math.Round(sum_ptotal * 10f) / 10f).ToString();
                hienthi_overview.KWhDay = ((float)Math.Round(sum_kwh_inday * 10f) / 10f).ToString();
                hienthi_overview.Kwh = ((float)Math.Round((sum_kwh/1000) * 10f) / 10f).ToString();

                var data = new List<object>();
                data.Add(gas_view);
                data.Add(water_view);
                data.Add(hienthi_overview);
            
                var result = data;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Overview()
        {
            if (Session["UserID"] != null)
            {
                using (DBModel db = new DBModel())
                {
                    //Get Gas table
                    var gas = db.gas.FirstOrDefault();
                    if (gas != null)
                    {
                        gas.luu_luong_hien_tai = string.Format("{0:#,##0.##}", ((float)Math.Round(float.Parse(gas.luu_luong_hien_tai) * 10f) / 10f));
                        gas.luu_luong_tong = string.Format("{0:#,##0.##}", ((float)Math.Round(float.Parse(gas.luu_luong_tong) * 10f) / 10f));
                    }
                    else
                    {
                        gas = new Gas();
                    }
                    //Get Water table
                    var water = db.water.FirstOrDefault();
                    if (water != null)
                    {
                        water.luu_luong_hien_tai = string.Format("{0:#,##0.##}", ((float)Math.Round(float.Parse(water.luu_luong_hien_tai) * 10f) / 10f));
                        water.luu_luong_tong = string.Format("{0:#,##0.##}", ((float)Math.Round(float.Parse(water.luu_luong_tong) * 10f) / 10f));
                    }
                    else
                    {
                        water = new Water();
                    }
                    // Get HienThi Table

                    var hienthi = db.hienthi.Select(i => new { i.Kenh, i.Ptotal, i.Kwh }).ToList();
                    var kenh1 = new Hienthi();
                    var kenh2 = new Hienthi();
                    var kenh3 = new Hienthi();
                    var kenh4 = new Hienthi();
                    var kenh5 = new Hienthi();
                    var kenh6 = new Hienthi();
                    float count_Ptotal = 0;
                    float count_Kwh = 0;
                    if (hienthi != null)
                    {
                        for (var i = 0; i < hienthi.Count; i++)
                        {
                            switch (hienthi[i].Kenh)
                            {
                                case "1":
                                    kenh1.Kenh = hienthi[i].Kenh;
                                    kenh1.Ptotal = string.Format("{0:#,##0.##}", ((float)Math.Round(float.Parse(hienthi[i].Ptotal) * 10f) / 10f));
                                    kenh1.Kwh = string.Format("{0:#,##0.##}", ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh1_2009) * 10f) / 10f));
                                    count_Kwh += float.Parse(kenh1.Kwh);
                                    break;
                                case "2":
                                    kenh2.Kenh = hienthi[i].Kenh;
                                    kenh2.Ptotal = string.Format("{0:#,##0.##}", ((float)Math.Round(float.Parse(hienthi[i].Ptotal) * 10f) / 10f));
                                    kenh2.Kwh = string.Format("{0:#,##0.##}", ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh2_2009) * 10f) / 10f));
                                    count_Kwh += float.Parse(kenh2.Kwh);
                                    break;
                                case "3":
                                    kenh3.Kenh = hienthi[i].Kenh;
                                    kenh3.Ptotal = string.Format("{0:#,##0.##}", ((float)Math.Round(float.Parse(hienthi[i].Ptotal) * 10f) / 10f));
                                    kenh3.Kwh = string.Format("{0:#,##0.##}", ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh3_2009) * 10f) / 10f));
                                    count_Kwh += float.Parse(kenh3.Kwh);
                                    break;
                                case "4":
                                    kenh4.Kenh = hienthi[i].Kenh;
                                    kenh4.Ptotal = string.Format("{0:#,##0.##}", ((float)Math.Round(float.Parse(hienthi[i].Ptotal) * 10f) / 10f));
                                    kenh4.Kwh = string.Format("{0:#,##0.##}", ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh4_2009) * 10f) / 10f));
                                    count_Kwh += float.Parse(kenh4.Kwh);
                                    break;
                                case "5":
                                    kenh5.Kenh = hienthi[i].Kenh;
                                    kenh5.Ptotal = string.Format("{0:#,##0.##}", ((float)Math.Round(float.Parse(hienthi[i].Ptotal) * 10f) / 10f));
                                    kenh5.Kwh = string.Format("{0:#,##0.##}", ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh5_2009) * 10f) / 10f));
                                    count_Kwh += float.Parse(kenh5.Kwh);
                                    break;
                                case "6":
                                    kenh6.Kenh = hienthi[i].Kenh;
                                    kenh6.Ptotal = string.Format("{0:#,##0.##}", ((float)Math.Round(float.Parse(hienthi[i].Ptotal) * 10f) / 10f));
                                    kenh6.Kwh = string.Format("{0:#,##0.##}", ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh6_2009) * 10f) / 10f));
                                    count_Kwh += float.Parse(kenh6.Kwh);
                                    break;
                                default:
                                    break;
                            }
                            count_Ptotal += float.Parse(hienthi[i].Ptotal);
                            //count_Kwh += float.Parse(hienthi[i].Kwh);
                        }
                    }
                    // Get HienThi Table
                    ViewBag.water = water;
                    ViewBag.kenh1 = kenh1;
                    ViewBag.kenh2 = kenh2;
                    ViewBag.kenh3 = kenh3;
                    ViewBag.kenh4 = kenh4;
                    ViewBag.kenh5 = kenh5;
                    ViewBag.kenh6 = kenh6;
                    ViewBag.gas = gas;
                    ViewBag.water = water;
                    ViewBag.count_Ptotal = string.Format("{0:#,##0.##}", ((float)Math.Round(count_Ptotal * 10f) / 10f));
                    ViewBag.count_Kwh = string.Format("{0:#,##0.##}", ((float)Math.Round(count_Kwh * 10f) / 10f));
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public JsonResult GetOverViewData()
        {
            using (DBModel db = new DBModel())
            {
                var gas = db.gas.FirstOrDefault();
                if (gas != null)
                {
                    gas.luu_luong_hien_tai = ((float)Math.Round(float.Parse(gas.luu_luong_hien_tai) * 10f) / 10f).ToString();
                    gas.luu_luong_tong = ((float)Math.Round(float.Parse(gas.luu_luong_tong) * 10f) / 10f).ToString();
                }
                else
                {
                    gas = new Gas();
                }
                //Get Water table
                var water = db.water.FirstOrDefault();
                if (water != null)
                {
                    water.luu_luong_hien_tai = ((float)Math.Round(float.Parse(water.luu_luong_hien_tai) * 10f) / 10f).ToString();
                    water.luu_luong_tong = ((float)Math.Round(float.Parse(water.luu_luong_tong) * 10f) / 10f).ToString();
                }
                else
                {
                    water = new Water();
                }

                var hienthi = db.hienthi.Select(i => new HienthiOverView { Kenh = i.Kenh, Ptotal = i.Ptotal, Kwh = i.Kwh}).ToList();
                float count_Ptotal = 0;
                float count_Kwh = 0;
                if (hienthi != null)
                {
                    for (var i = 0; i < hienthi.Count; i++)
                    {
                        switch (hienthi[i].Kenh)
                        {
                            case "1":
                                hienthi[i].Kwh = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh1_2009) * 10f) / 10f).ToString();
                                break;
                            case "2":
                                hienthi[i].Kwh = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh2_2009) * 10f) / 10f).ToString();
                                break;
                            case "3":
                                hienthi[i].Kwh = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh3_2009) * 10f) / 10f).ToString();
                                break;
                            case "4":
                                hienthi[i].Kwh = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh4_2009) * 10f) / 10f).ToString();
                                break;
                            case "5":
                                hienthi[i].Kwh = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh5_2009) * 10f) / 10f).ToString();
                                break;
                            case "6":
                                hienthi[i].Kwh = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh6_2009) * 10f) / 10f).ToString();
                                break;
                            default:
                                break;

                        }
                        hienthi[i].Ptotal = ((float)Math.Round(float.Parse(hienthi[i].Ptotal) * 10f) / 10f).ToString();
                        count_Ptotal += float.Parse(hienthi[i].Ptotal);
                        count_Kwh += float.Parse(hienthi[i].Kwh);
                    }
                }
                var data = new List<object>();
                data.Add(gas);
                data.Add(water);
                data.Add(hienthi);
                data.Add(((float)Math.Round(count_Ptotal * 10f) / 10f));
                data.Add(((float)Math.Round(count_Kwh * 10f) / 10f));
                var result = data;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetHienThiData(string kenh)
        {
            using (DBModel db = new DBModel())
            {
                var obj = db.hienthi.Where(a => a.Kenh.Equals(kenh)).FirstOrDefault();
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
        public JsonResult GetChartKenh1Data()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi1 = db.hienthi.Where(a => a.Kenh.Equals("1")).FirstOrDefault();
                var recoder_kenh1_begin = db.recoder_kenh1.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
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
                var hienthi2 = db.hienthi.Where(a => a.Kenh.Equals("2")).FirstOrDefault();
                var recoder_kenh2_begin = db.recoder_kenh2.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if (hienthi2 != null)
                {
                    var kenh2_Kwh_last = (recoder_kenh2_begin != null) ? recoder_kenh2_begin.Kwh : "0";
                    hienthi2.Ptotal = ((float)Math.Round(float.Parse(hienthi2.Ptotal) * 10f) / 10f).ToString();
                    hienthi2.Kwh = ((float)Math.Round((float.Parse(hienthi2.Kwh) - float.Parse(kenh2_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi2, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh3Data()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi3 = db.hienthi.Where(a => a.Kenh.Equals("3")).FirstOrDefault();
                var recoder_kenh3_begin = db.recoder_kenh3.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if (hienthi3 != null)
                {
                    var kenh3_Kwh_last = (recoder_kenh3_begin != null) ? recoder_kenh3_begin.Kwh : "0";
                    hienthi3.Ptotal = ((float)Math.Round(float.Parse(hienthi3.Ptotal) * 10f) / 10f).ToString();
                    hienthi3.Kwh = ((float)Math.Round((float.Parse(hienthi3.Kwh) - float.Parse(kenh3_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi3, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh4Data()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi4 = db.hienthi.Where(a => a.Kenh.Equals("4")).FirstOrDefault();
                var recoder_kenh4_begin = db.recoder_kenh4.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if (hienthi4 != null)
                {
                    var kenh4_Kwh_last = (recoder_kenh4_begin != null) ? recoder_kenh4_begin.Kwh : "0";
                    hienthi4.Ptotal = ((float)Math.Round(float.Parse(hienthi4.Ptotal) * 10f) / 10f).ToString();
                    hienthi4.Kwh = ((float)Math.Round((float.Parse(hienthi4.Kwh) - float.Parse(kenh4_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi4, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetChartKenh5Data()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi5 = db.hienthi.Where(a => a.Kenh.Equals("5")).FirstOrDefault();
                var recoder_kenh5_begin = db.recoder_kenh5.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if (hienthi5 != null)
                {
                    var kenh5_Kwh_last = (recoder_kenh5_begin != null) ? recoder_kenh5_begin.Kwh : "0";
                    hienthi5.Ptotal = ((float)Math.Round(float.Parse(hienthi5.Ptotal) * 10f) / 10f).ToString();
                    hienthi5.Kwh = ((float)Math.Round((float.Parse(hienthi5.Kwh) - float.Parse(kenh5_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi5, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetChartKenh6Data()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi6 = db.hienthi.Where(a => a.Kenh.Equals("6")).FirstOrDefault();
                var recoder_kenh6_begin = db.recoder_kenh6.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                if (hienthi6 != null)
                {
                    var kenh6_Kwh_last = (recoder_kenh6_begin != null) ? recoder_kenh6_begin.Kwh : "0";
                    hienthi6.Ptotal = ((float)Math.Round(float.Parse(hienthi6.Ptotal) * 10f) / 10f).ToString();
                    hienthi6.Kwh = ((float)Math.Round((float.Parse(hienthi6.Kwh) - float.Parse(kenh6_Kwh_last)) * 10f) / 10f).ToString();
                }
                return Json(hienthi6, JsonRequestBehavior.AllowGet);
            }
        }
    }
}