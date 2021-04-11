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
        static DateTime startBeginDate = new DateTime(2021, 4, 5);
        static DateTime endBeginDate = new DateTime(2021, 4, 6).AddTicks(-1);

        //float kenh1_2009 = (float)226.72;
        float kenh2_2009 = (float)30813.393;
        float kenh3_2009 = (float)18308.866;
        float kenh4_2009 = (float)83015.867;
        float kenh5_2009 = (float)28150.823;
        float kenh6_2009 = (float)291055.695;

        Recoder1_DB_Solar1 solar1_recoder_begin = new DBModel().recoder1_db_solar1.Where(c => c.Thoigian >= startBeginDate && c.Thoigian <= endBeginDate).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
        Recoder1_DB_Solar2 solar2_recoder_begin = new DBModel().recoder1_db_solar2.Where(c => c.Thoigian >= startBeginDate && c.Thoigian <= endBeginDate).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
        Recoder1_DB_Logistics logistic_recoder_begin = new DBModel().recoder1_db_logistics.Where(c => c.Thoigian >= startBeginDate && c.Thoigian <= endBeginDate).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
        Recoder1_DB_PC15 snack4_recoder_begin = new DBModel().recoder1_kenh4.Where(c => c.Thoigian >= startBeginDate && c.Thoigian <= endBeginDate).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
        Recoder1_DB_PC10 snack5_recoder_begin = new DBModel().recoder1_kenh5.Where(c => c.Thoigian >= startBeginDate && c.Thoigian <= endBeginDate).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
        Recoder1_DB_Snack1 snack6_recoder_begin = new DBModel().recoder1_kenh6.Where(c => c.Thoigian >= startBeginDate && c.Thoigian <= endBeginDate).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
        Recoder1_DB_Snack2 snack7_recoder_begin = new DBModel().recoder1_kenh7.Where(c => c.Thoigian >= startBeginDate && c.Thoigian <= endBeginDate).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
        Recoder1_DB_Snack3 snack8_recoder_begin = new DBModel().recoder1_kenh8.Where(c => c.Thoigian >= startBeginDate && c.Thoigian <= endBeginDate).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
        Recoder1_DB_Snack4 snack9_recoder_begin = new DBModel().recoder1_kenh9.Where(c => c.Thoigian >= startBeginDate && c.Thoigian <= endBeginDate).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
        Recoder1_LP_PC15 snack10_recoder_begin = new DBModel().recoder1_kenh10.Where(c => c.Thoigian >= startBeginDate && c.Thoigian <= endBeginDate).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
        Recoder1_LP_Snack1 snack11_recoder_begin = new DBModel().recoder1_kenh11.Where(c => c.Thoigian >= startBeginDate && c.Thoigian <= endBeginDate).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
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
                var kenhRiceList = new string[] { "2", "3", "4", "5", "6" };
                var hienthi = db.hienthi.Where(c => kenhRiceList.Contains(c.Kenh)).Select(i => new HienthiOverView { Kenh = i.Kenh, Ptotal = i.Ptotal, Kwh = i.Kwh, KWhDay = "0" }).ToList();
                //var recoder_kenh1_begin = db.recoder_kenh1.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                //            .Take(1).ToList().FirstOrDefault();
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

                //var kenh1 = new HienthiOverView();
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
                    //var kenh1_Kwh_last = (recoder_kenh1_begin != null) ? recoder_kenh1_begin.Kwh : "0";
                    var kenh2_Kwh_last = (recoder_kenh2_begin != null) ? recoder_kenh2_begin.Kwh : "0";
                    var kenh3_Kwh_last = (recoder_kenh3_begin != null) ? recoder_kenh3_begin.Kwh : "0";
                    var kenh4_Kwh_last = (recoder_kenh4_begin != null) ? recoder_kenh4_begin.Kwh : "0";
                    var kenh5_Kwh_last = (recoder_kenh5_begin != null) ? recoder_kenh5_begin.Kwh : "0";
                    var kenh6_Kwh_last = (recoder_kenh6_begin != null) ? recoder_kenh6_begin.Kwh : "0";
                    for (var i = 0; i < hienthi.Count; i++)
                    {
                        switch (hienthi[i].Kenh)
                        {
                            //case "1":
                            //    kenh1.Kenh = hienthi[i].Kenh;
                            //    kenh1.Ptotal = ((float)Math.Round(float.Parse(hienthi[i].Ptotal) * 10f) / 10f).ToString();
                            //    kenh1.Kwh = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - kenh1_2009) * 10f) / 10f).ToString();
                            //    kenh1.KWhDay = ((float)Math.Round((float.Parse(hienthi[i].Kwh) - float.Parse(kenh1_Kwh_last)) * 10f) / 10f).ToString();
                            //    sum_ptotal += float.Parse(kenh1.Ptotal);
                            //    sum_kwh_inday += float.Parse(kenh1.KWhDay);
                            //    sum_kwh += float.Parse(kenh1.Kwh);
                            //    break;
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
                var hienthi1_overview = GetHienThi1Data();
                var cng_pc15 = GetCngPc15Data();
                var water_pc15 = GetWaterPC15Data();
                //Sum snack energy
                var sum_snack = new HienthiOverView();

                float kwhday1 = ((float)Math.Round(float.Parse(hienthi_overview.KWhDay) * 10f) / 10f);
                float kwhday2 = ((float)Math.Round(float.Parse(hienthi1_overview.KWhDay) * 10f) / 10f);
                sum_snack.Ptotal = (((float)Math.Round(float.Parse(hienthi_overview.Ptotal) * 10f) / 10f) + ((float)Math.Round(float.Parse(hienthi1_overview.Ptotal) * 10f) / 10f)).ToString();
                sum_snack.KWhDay = Math.Round(kwhday1 + kwhday2, 1).ToString();
                sum_snack.Kwh = (((float)Math.Round(float.Parse(hienthi_overview.Kwh) * 10f) / 10f) + ((float)Math.Round(float.Parse(hienthi1_overview.Kwh) * 10f) / 10f)).ToString();

                // Sum Gas
                var sum_gas = new GasView();
                sum_gas.luu_luong_hien_tai = (((float)Math.Round(float.Parse(gas_view.luu_luong_hien_tai) * 10f) / 10f) + ((float)Math.Round(float.Parse(cng_pc15.luu_luong_hien_tai) * 10f) / 10f)).ToString();
                sum_gas.luu_luong_tong = (((float)Math.Round(float.Parse(gas_view.luu_luong_tong) * 10f) / 10f) + ((float)Math.Round(float.Parse(cng_pc15.luu_luong_tong) * 10f) / 10f)).ToString();
                sum_gas.luu_luong_tong_ngay = (((float)Math.Round(float.Parse(gas_view.luu_luong_tong_ngay) * 10f) / 10f) + ((float)Math.Round(float.Parse(cng_pc15.luu_luong_tong_ngay) * 10f) / 10f)).ToString();
                // Sum Water
                var sum_water = new WaterView();
                sum_water.luu_luong_hien_tai = (((float)Math.Round(float.Parse(water_view.luu_luong_hien_tai) * 10f) / 10f) + ((float)Math.Round(float.Parse(water_pc15.luu_luong_hien_tai) * 10f) / 10f)).ToString();
                sum_water.luu_luong_tong = (((float)Math.Round(float.Parse(water_view.luu_luong_tong) * 10f) / 10f) + ((float)Math.Round(float.Parse(water_pc15.luu_luong_tong) * 10f) / 10f)).ToString();
                sum_water.luu_luong_tong_ngay = (((float)Math.Round(float.Parse(water_view.luu_luong_tong_ngay) * 10f) / 10f) + ((float)Math.Round(float.Parse(water_pc15.luu_luong_tong_ngay) * 10f) / 10f)).ToString();
                // Sum Pc15 (Kenh 4+10))
                var sum_pc15 = GetTotalPc15Data();
                // Sum Solar
                var sum_solar = GetTotalSolarData();
                //Sum Steam
                var sum_steam = GetTotalSteamData();
                var logistic = GetLogisticData();
                data.Add(gas_view); // 0
                data.Add(water_view); // 1
                data.Add(hienthi_overview); // 2
                data.Add(hienthi1_overview); // 3
                data.Add(cng_pc15); // 4
                data.Add(water_pc15); // 5
                data.Add(sum_snack); // 6
                data.Add(sum_gas); // 7
                data.Add(sum_water); // 8
                data.Add(sum_pc15); // 9
                data.Add(sum_solar); // 10
                data.Add(sum_steam); // 11
                data.Add(logistic); //12
                var result = data;
                
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        // Hienthi1 Data
        public Hienthi1OverView GetHienThi1Data()
        {
            using (DBModel db = new DBModel())
            {
                var kenhList = new string[] { "5", "6", "7", "8", "9", "11" };
                var hienthi1 = db.hienthi1.Where(c => kenhList.Contains(c.Kenh)).Select(i => new Hienthi1OverView { Kenh = i.Kenh, Ptotal = i.Ptotal, Kwh = i.Kwh, KWhDay = "0" }).ToList();
                //var hienthi = db.hienthi.Select(i => new { i.Kenh, i.Ptotal, i.Kwh }).ToList();
                var recoder1_kenh5_begin = db.recoder1_kenh5.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                            .Take(1).ToList().FirstOrDefault();
                var recoder1_kenh6_begin = db.recoder1_kenh6.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                            .Take(1).ToList().FirstOrDefault();
                var recoder1_kenh7_begin = db.recoder1_kenh7.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                            .Take(1).ToList().FirstOrDefault();
                var recoder1_kenh8_begin = db.recoder1_kenh8.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                            .Take(1).ToList().FirstOrDefault();
                var recoder1_kenh9_begin = db.recoder1_kenh9.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                            .Take(1).ToList().FirstOrDefault();
                var recoder1_kenh11_begin = db.recoder1_kenh11.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                            .Take(1).ToList().FirstOrDefault();

                var kenh5 = new Hienthi1OverView();
                var kenh6 = new Hienthi1OverView();
                var kenh7 = new Hienthi1OverView();
                var kenh8 = new Hienthi1OverView();
                var kenh9 = new Hienthi1OverView();
                var kenh11 = new Hienthi1OverView();
                float sum_ptotal = 0;
                float sum_kwh = 0;
                float sum_kwh_inday = 0;
                var hienthi1_overview = new Hienthi1OverView();
                if (hienthi1 != null)
                {
                    var kenh5_Kwh_last = (recoder1_kenh5_begin != null) ? recoder1_kenh5_begin.Kwh : "0";
                    var kenh6_Kwh_last = (recoder1_kenh6_begin != null) ? recoder1_kenh6_begin.Kwh : "0";
                    var kenh7_Kwh_last = (recoder1_kenh7_begin != null) ? recoder1_kenh7_begin.Kwh : "0";
                    var kenh8_Kwh_last = (recoder1_kenh8_begin != null) ? recoder1_kenh8_begin.Kwh : "0";
                    var kenh9_Kwh_last = (recoder1_kenh9_begin != null) ? recoder1_kenh9_begin.Kwh : "0";
                    var kenh11_Kwh_last = (recoder1_kenh11_begin != null) ? recoder1_kenh11_begin.Kwh : "0";
                    for (var i = 0; i < hienthi1.Count; i++)
                    {
                        switch (hienthi1[i].Kenh)
                        {
                            case "5":
                                kenh5.Kenh = hienthi1[i].Kenh;
                                kenh5.Ptotal = ((float)Math.Round(float.Parse(hienthi1[i].Ptotal) * 10f) / 10f).ToString();
                                kenh5.Kwh = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(snack5_recoder_begin.Kwh)) * 10f) / 10f).ToString();
                                kenh5.KWhDay = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(kenh5_Kwh_last)) * 10f) / 10f).ToString();
                                sum_ptotal += float.Parse(kenh5.Ptotal);
                                sum_kwh_inday += float.Parse(kenh5.KWhDay);
                                sum_kwh += float.Parse(kenh5.Kwh);
                                break;
                            case "6":
                                kenh6.Kenh = hienthi1[i].Kenh;
                                kenh6.Ptotal = ((float)Math.Round(float.Parse(hienthi1[i].Ptotal) * 10f) / 10f).ToString();
                                kenh6.Kwh = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(snack6_recoder_begin.Kwh)) * 10f) / 10f).ToString();
                                kenh6.KWhDay = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(kenh6_Kwh_last)) * 10f) / 10f).ToString();
                                sum_ptotal += float.Parse(kenh6.Ptotal);
                                sum_kwh_inday += float.Parse(kenh6.KWhDay);
                                sum_kwh += float.Parse(kenh6.Kwh);
                                break;
                            case "7":
                                kenh7.Kenh = hienthi1[i].Kenh;
                                kenh7.Ptotal = ((float)Math.Round(float.Parse(hienthi1[i].Ptotal) * 10f) / 10f).ToString();
                                kenh7.Kwh = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(snack7_recoder_begin.Kwh)) * 10f) / 10f).ToString();
                                kenh7.KWhDay = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(kenh7_Kwh_last)) * 10f) / 10f).ToString();
                                sum_ptotal += float.Parse(kenh7.Ptotal);
                                sum_kwh_inday += float.Parse(kenh7.KWhDay);
                                sum_kwh += float.Parse(kenh7.Kwh);
                                break;
                            case "8":
                                kenh8.Kenh = hienthi1[i].Kenh;
                                kenh8.Ptotal = ((float)Math.Round(float.Parse(hienthi1[i].Ptotal) * 10f) / 10f).ToString();
                                kenh8.Kwh = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(snack8_recoder_begin.Kwh)) * 10f) / 10f).ToString();
                                kenh8.KWhDay = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(kenh8_Kwh_last)) * 10f) / 10f).ToString();
                                sum_ptotal += float.Parse(kenh8.Ptotal);
                                sum_kwh_inday += float.Parse(kenh8.KWhDay);
                                sum_kwh += float.Parse(kenh8.Kwh);
                                break;
                            case "9":
                                kenh9.Kenh = hienthi1[i].Kenh;
                                kenh9.Ptotal = ((float)Math.Round(float.Parse(hienthi1[i].Ptotal) * 10f) / 10f).ToString();
                               kenh9.Kwh = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(snack9_recoder_begin.Kwh)) * 10f) / 10f).ToString();
                                kenh9.KWhDay = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(kenh9_Kwh_last)) * 10f) / 10f).ToString();
                                sum_ptotal += float.Parse(kenh9.Ptotal);
                                sum_kwh_inday += float.Parse(kenh9.KWhDay);
                                sum_kwh += float.Parse(kenh9.Kwh);
                                break;
                            case "11":
                                kenh11.Kenh = hienthi1[i].Kenh;
                                kenh11.Ptotal = ((float)Math.Round(float.Parse(hienthi1[i].Ptotal) * 10f) / 10f).ToString();
                                kenh11.Kwh = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(snack11_recoder_begin.Kwh)) * 10f) / 10f).ToString();
                                kenh11.KWhDay = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(kenh11_Kwh_last)) * 10f) / 10f).ToString();
                                sum_ptotal += float.Parse(kenh11.Ptotal);
                                sum_kwh_inday += float.Parse(kenh11.KWhDay);
                                sum_kwh += float.Parse(kenh11.Kwh);
                                break;
                            default:
                                break;
                        }
                    }
                }
                hienthi1_overview.Ptotal = ((float)Math.Round(sum_ptotal * 10f) / 10f).ToString();
                hienthi1_overview.KWhDay = ((float)Math.Round(sum_kwh_inday * 10f) / 10f).ToString();
                hienthi1_overview.Kwh = ((float)Math.Round((sum_kwh / 1000) * 10f) / 10f).ToString();

                return hienthi1_overview;
                //return Json(hienthi1_overview, JsonRequestBehavior.AllowGet);
            }
        }

        // Get CngPC15 Data
        public GasCNGView GetCngPc15Data()
        {
            using (DBModel db = new DBModel())
            {
                //Get Gas table
                var cng_pc15 = db.gas_cng.FirstOrDefault();
                var cng_pc15_recoder1_begin = db.recoder1_gas_cng.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var cng_pc15_view = new GasCNGView();
                if (cng_pc15 != null)
                {
                    var cng_pc15_total_last = (cng_pc15_recoder1_begin != null) ? cng_pc15_recoder1_begin.luu_luong_tong : "0";
                    cng_pc15_view.luu_luong_hien_tai = ((float)Math.Round(float.Parse(cng_pc15.luu_luong_hien_tai) * 10f) / 10f).ToString();
                    cng_pc15_view.luu_luong_tong = ((float)Math.Round(float.Parse(cng_pc15.luu_luong_tong) * 10f) / 10f).ToString();
                    cng_pc15_view.luu_luong_tong_ngay = ((float)Math.Round((float.Parse(cng_pc15.luu_luong_tong) - float.Parse(cng_pc15_total_last)) * 10f) / 10f).ToString();
                    cng_pc15_view.status = cng_pc15.status;
                }
                return cng_pc15_view;
            }
        }

        // Get WaterPC15 Data
        public WaterPC15View GetWaterPC15Data()
        {
            using (DBModel db = new DBModel())
            {
                //Get Gas table
                var water_pc15 = db.water_pc15.FirstOrDefault();
                var water_pc15_recoder_begin = db.recoder1_water_pc15.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var water_pc15_view = new WaterPC15View();
                if (water_pc15 != null)
                {
                    var water_pc15_total_last = (water_pc15_recoder_begin != null) ? water_pc15_recoder_begin.luu_luong_tong : "0";
                    water_pc15_view.luu_luong_hien_tai = ((float)Math.Round(float.Parse(water_pc15.luu_luong_hien_tai) * 10f) / 10f).ToString();
                    water_pc15_view.luu_luong_tong = ((float)Math.Round(float.Parse(water_pc15.luu_luong_tong) * 10f) / 10f).ToString();
                    water_pc15_view.luu_luong_tong_ngay = ((float)Math.Round((float.Parse(water_pc15.luu_luong_tong) - float.Parse(water_pc15_total_last)) * 10f) / 10f).ToString();
                    water_pc15_view.status = water_pc15.status;
                }
                return water_pc15_view;
            }
        }

        // Get PC15 Sum
        public Hienthi1OverView GetTotalPc15Data()
        {
            using (DBModel db = new DBModel())
            {
                var kenhList = new string[] { "4", "10" };
                var hienthi1 = db.hienthi1.Where(c => kenhList.Contains(c.Kenh)).Select(i => new Hienthi1OverView { Kenh = i.Kenh, Ptotal = i.Ptotal, Kwh = i.Kwh, KWhDay = "0" }).ToList();
                //var hienthi = db.hienthi.Select(i => new { i.Kenh, i.Ptotal, i.Kwh }).ToList();
                var recoder1_kenh4_begin = db.recoder1_kenh4.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                            .Take(1).ToList().FirstOrDefault();
                var recoder1_kenh10_begin = db.recoder1_kenh10.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                            .Take(1).ToList().FirstOrDefault();

                var kenh4 = new Hienthi1OverView();
                var kenh10 = new Hienthi1OverView();
                float sum_ptotal = 0;
                float sum_kwh = 0;
                float sum_kwh_inday = 0;
                var hienthi1_overview = new Hienthi1OverView();
                if (hienthi1 != null)
                {
                    var kenh4_Kwh_last = (recoder1_kenh4_begin != null) ? recoder1_kenh4_begin.Kwh : "0";
                    var kenh10_Kwh_last = (recoder1_kenh10_begin != null) ? recoder1_kenh10_begin.Kwh : "0";
                    for (var i = 0; i < hienthi1.Count; i++)
                    {
                        switch (hienthi1[i].Kenh)
                        {
                            case "4":
                                kenh4.Kenh = hienthi1[i].Kenh;
                                kenh4.Ptotal = ((float)Math.Round(float.Parse(hienthi1[i].Ptotal) * 10f) / 10f).ToString();
                                kenh4.Kwh = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(snack4_recoder_begin.Kwh)) * 10f) / 10f).ToString();
                                kenh4.KWhDay = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(kenh4_Kwh_last)) * 10f) / 10f).ToString();
                                sum_ptotal += float.Parse(kenh4.Ptotal);
                                sum_kwh_inday += float.Parse(kenh4.KWhDay);
                                sum_kwh += float.Parse(kenh4.Kwh);
                                break;
                            case "10":
                                kenh10.Kenh = hienthi1[i].Kenh;
                                kenh10.Ptotal = ((float)Math.Round(float.Parse(hienthi1[i].Ptotal) * 10f) / 10f).ToString();
                                kenh10.Kwh = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(snack10_recoder_begin.Kwh)) * 10f) / 10f).ToString();
                                kenh10.KWhDay = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(kenh10_Kwh_last)) * 10f) / 10f).ToString();
                                sum_ptotal += float.Parse(kenh10.Ptotal);
                                sum_kwh_inday += float.Parse(kenh10.KWhDay);
                                sum_kwh += float.Parse(kenh10.Kwh);
                                break;
                            default:
                                break;
                        }
                    }
                }
                hienthi1_overview.Ptotal = ((float)Math.Round(sum_ptotal * 10f) / 10f).ToString();
                hienthi1_overview.KWhDay = ((float)Math.Round(sum_kwh_inday * 10f) / 10f).ToString();
                hienthi1_overview.Kwh = ((float)Math.Round((sum_kwh / 1000) * 10f) / 10f).ToString();

                return hienthi1_overview;
                //return Json(hienthi1_overview, JsonRequestBehavior.AllowGet);
            }
        }

        //GET TOTAL SOLAR
        public Hienthi1OverView GetTotalSolarData()
        {
            using (DBModel db = new DBModel())
            {
                var kenhList = new string[] { "1", "2" };
                var hienthi1 = db.hienthi1.Where(c => kenhList.Contains(c.Kenh)).Select(i => new Hienthi1OverView { Kenh = i.Kenh, Ptotal = i.Ptotal, Kwh = i.Kwh, KWhDay = "0" }).ToList();
                //var hienthi = db.hienthi.Select(i => new { i.Kenh, i.Ptotal, i.Kwh }).ToList();
                var recoder1_solar1_begin = db.recoder1_db_solar1.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                            .Take(1).ToList().FirstOrDefault();
                var recoder1_solar2_begin = db.recoder1_db_solar2.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                            .Take(1).ToList().FirstOrDefault();

                var solar1 = new Hienthi1OverView();
                var solar2 = new Hienthi1OverView();
                float sum_ptotal = 0;
                float sum_kwh = 0;
                float sum_kwh_inday = 0;
                var hienthi1_overview = new Hienthi1OverView();
                if (hienthi1 != null)
                {
                    var solar1_Kwh_last = (recoder1_solar1_begin != null) ? recoder1_solar1_begin.Kwh : "0";
                    var solar2_Kwh_last = (recoder1_solar2_begin != null) ? recoder1_solar2_begin.Kwh : "0";
                    for (var i = 0; i < hienthi1.Count; i++)
                    {
                        switch (hienthi1[i].Kenh)
                        {
                            case "1":
                                solar1.Kenh = hienthi1[i].Kenh;
                                solar1.Ptotal = ((float)Math.Round(float.Parse(hienthi1[i].Ptotal) * 10f) / 10f).ToString();
                                solar1.Kwh = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(solar1_recoder_begin.Kwh)) * 10f) / 10f).ToString();
                                solar1.KWhDay = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(solar1_Kwh_last)) * 10f) / 10f).ToString();
                                sum_ptotal += float.Parse(solar1.Ptotal);
                                sum_kwh_inday += float.Parse(solar1.KWhDay);
                                sum_kwh += float.Parse(solar1.Kwh);
                                break;
                            case "2":
                                solar2.Kenh = hienthi1[i].Kenh;
                                solar2.Ptotal = ((float)Math.Round(float.Parse(hienthi1[i].Ptotal) * 10f) / 10f).ToString();
                                solar2.Kwh = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(solar2_recoder_begin.Kwh)) * 10f) / 10f).ToString();
                                solar2.KWhDay = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(solar2_Kwh_last)) * 10f) / 10f).ToString();
                                sum_ptotal += float.Parse(solar2.Ptotal);
                                sum_kwh_inday += float.Parse(solar2.KWhDay);
                                sum_kwh += float.Parse(solar2.Kwh);
                                break;
                            default:
                                break;
                        }
                    }
                }
                hienthi1_overview.Ptotal = ((float)Math.Round(sum_ptotal * 10f) / 10f).ToString();
                hienthi1_overview.KWhDay = ((float)Math.Round(sum_kwh_inday * 10f) / 10f).ToString();
                hienthi1_overview.Kwh = ((float)Math.Round((sum_kwh / 1000) * 10f) / 10f).ToString();

                return hienthi1_overview;
                //return Json(hienthi1_overview, JsonRequestBehavior.AllowGet);
            }
        }

        // Get Total Steam
        public SteamPC10View GetTotalSteamData()
        {
            using (DBModel db = new DBModel())
            {
                //Get Steam PC10 table
                var steam_pc10 = db.steam_pc10.FirstOrDefault();
                var steam_pc10_recoder1_begin = db.recoder1_steam_pc10.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var steam_pc10_view = new SteamPC10View();
                if (steam_pc10 != null)
                {
                    var steam_pc10_total_last = (steam_pc10_recoder1_begin != null) ? steam_pc10_recoder1_begin.luu_luong_tong : "0";
                    steam_pc10_view.luu_luong_hien_tai = ((float)Math.Round(float.Parse(steam_pc10.luu_luong_hien_tai) * 10f) / 10f).ToString();
                    steam_pc10_view.luu_luong_tong = ((float)Math.Round(float.Parse(steam_pc10.luu_luong_tong) * 10f) / 10f).ToString();
                    steam_pc10_view.luu_luong_tong_ngay = ((float)Math.Round((float.Parse(steam_pc10.luu_luong_tong) - float.Parse(steam_pc10_total_last)) * 10f) / 10f).ToString();
                    steam_pc10_view.status = steam_pc10.status;
                }

                //Get Steam PC15 table
                var steam_pc15 = db.steam_pc15.FirstOrDefault();
                var steam_pc15_recoder1_begin = db.recoder1_steam_pc15.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                         .Take(1).ToList().FirstOrDefault();
                var steam_pc15_view = new SteamPC15View();
                if (steam_pc15 != null)
                {
                    var steam_pc15_total_last = (steam_pc15_recoder1_begin != null) ? steam_pc15_recoder1_begin.luu_luong_tong : "0";
                    steam_pc15_view.luu_luong_hien_tai = ((float)Math.Round(float.Parse(steam_pc15.luu_luong_hien_tai) * 10f) / 10f).ToString();
                    steam_pc15_view.luu_luong_tong = ((float)Math.Round(float.Parse(steam_pc15.luu_luong_tong) * 10f) / 10f).ToString();
                    steam_pc15_view.luu_luong_tong_ngay = ((float)Math.Round((float.Parse(steam_pc15.luu_luong_tong) - float.Parse(steam_pc15_total_last)) * 10f) / 10f).ToString();
                    steam_pc15_view.status = steam_pc10.status;
                }

                var sum_steam = new SteamPC10View();
                sum_steam.luu_luong_hien_tai = (((float)Math.Round(float.Parse(steam_pc10_view.luu_luong_hien_tai) * 10f) / 10f) + ((float)Math.Round(float.Parse(steam_pc15_view.luu_luong_hien_tai) * 10f) / 10f)).ToString();
                sum_steam.luu_luong_tong = (((float)Math.Round(float.Parse(steam_pc10_view.luu_luong_tong) * 10f) / 10f) + ((float)Math.Round(float.Parse(steam_pc15_view.luu_luong_tong) * 10f) / 10f)).ToString();
                sum_steam.luu_luong_tong_ngay = (((float)Math.Round(float.Parse(steam_pc10_view.luu_luong_tong_ngay) * 10f) / 10f) + ((float)Math.Round(float.Parse(steam_pc15_view.luu_luong_tong_ngay) * 10f) / 10f)).ToString();
                return sum_steam;
            }
        }

        // Get Logistic Data
        public Hienthi1OverView GetLogisticData()
        {
            using (DBModel db = new DBModel())
            {
                var hienthi1 = db.hienthi1.Where(c => c.Kenh.Equals("3")).Select(i => new Hienthi1OverView { Kenh = i.Kenh, Ptotal = i.Ptotal, Kwh = i.Kwh, KWhDay = "0" }).FirstOrDefault();
                var recoder1_logistic_begin = db.recoder1_db_logistics.Where(c => c.Thoigian >= startYesterdayTime && c.Thoigian <= endYesterdayTime).OrderByDescending(x => x.Thoigian)
                            .Take(1).ToList().FirstOrDefault();
                var logistic_view = new Hienthi1OverView(); 
                if (hienthi1 != null)
                {
                    var logistic_Kwh_last = (recoder1_logistic_begin != null) ? recoder1_logistic_begin.Kwh : "0";

                    logistic_view.Ptotal = ((float)Math.Round(float.Parse(hienthi1.Ptotal) * 10f) / 10f).ToString();
                    logistic_view.Kwh = ((float)Math.Round((float.Parse(hienthi1.Kwh) - float.Parse(logistic_recoder_begin.Kwh)) * 10f) / 10f).ToString();
                    logistic_view.KWhDay = ((float)Math.Round((float.Parse(hienthi1.Kwh) - float.Parse(logistic_Kwh_last)) * 10f) / 10f).ToString();
                 }
                return logistic_view;
            }
        }

        public ActionResult Overview()
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