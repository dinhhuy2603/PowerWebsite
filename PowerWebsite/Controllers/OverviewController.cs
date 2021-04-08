using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PowerWebsite.Models;


namespace PowerWebsite.Controllers
{
    public class OverviewController : Controller
    {
        DateTime today = DateTime.Today.Date;
        DateTime startYesterdayTime = DateTime.Today.AddDays(-1); //Today at 00:00:00
        DateTime endYesterdayTime = DateTime.Today.AddTicks(-1); //Today at 23:59:59
        static DateTime startBeginDate = new DateTime(2021, 4, 5);
        static DateTime endBeginDate = new DateTime(2021, 4, 6).AddTicks(-1);

        float kenh1_2009 = (float)226.72;
        float kenh2_2009 = (float)30813.393;
        float kenh3_2009 = (float)18308.866;
        float kenh4_2009 = (float)83015.867;
        float kenh5_2009 = (float)28150.823;
        float kenh6_2009 = (float)291055.695;

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

        // GET: Overview
        public ActionResult Index()
        {
            return View();
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

                var hienthi = db.hienthi.Select(i => new HienthiOverView { Kenh = i.Kenh, Ptotal = i.Ptotal, Kwh = i.Kwh }).ToList();
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
                // Hienthi1
                var hienthi1 = db.hienthi1.Select(i => new Hienthi1OverView { Kenh = i.Kenh, Ptotal = i.Ptotal, Kwh = i.Kwh }).ToList();
                float count_snack_Ptotal = 0;
                float count_snack_Kwh = 0;
                float count_pc15_Ptotal = 0;
                float count_pc15_Kwh = 0;
                if (hienthi != null)
                {
                    for (var i = 0; i < hienthi1.Count; i++)
                    {
                        switch (hienthi1[i].Kenh)
                        {
                            case "4":
                                hienthi1[i].Kwh = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(snack4_recoder_begin.Kwh)) * 10f) / 10f).ToString();
                                hienthi1[i].Ptotal = ((float)Math.Round(float.Parse(hienthi1[i].Ptotal) * 10f) / 10f).ToString();
                                count_pc15_Kwh += float.Parse(hienthi1[i].Kwh);
                                count_pc15_Ptotal += float.Parse(hienthi1[i].Ptotal);
                                break;
                            case "5":
                                hienthi1[i].Kwh = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(snack5_recoder_begin.Kwh)) * 10f) / 10f).ToString();
                                hienthi1[i].Ptotal = ((float)Math.Round(float.Parse(hienthi1[i].Ptotal) * 10f) / 10f).ToString();
                                count_snack_Kwh += float.Parse(hienthi1[i].Kwh);
                                count_snack_Ptotal += float.Parse(hienthi1[i].Ptotal);
                                break;
                            case "6":
                                hienthi1[i].Kwh = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(snack6_recoder_begin.Kwh)) * 10f) / 10f).ToString();
                                hienthi1[i].Ptotal = ((float)Math.Round(float.Parse(hienthi1[i].Ptotal) * 10f) / 10f).ToString();
                                count_snack_Kwh += float.Parse(hienthi1[i].Kwh);
                                count_snack_Ptotal += float.Parse(hienthi1[i].Ptotal);
                                break;
                            case "7":
                                hienthi1[i].Kwh = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(snack7_recoder_begin.Kwh)) * 10f) / 10f).ToString();
                                hienthi1[i].Ptotal = ((float)Math.Round(float.Parse(hienthi1[i].Ptotal) * 10f) / 10f).ToString();
                                count_snack_Kwh += float.Parse(hienthi1[i].Kwh);
                                count_snack_Ptotal += float.Parse(hienthi1[i].Ptotal);
                                break;
                            case "8":
                                hienthi1[i].Kwh = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(snack8_recoder_begin.Kwh)) * 10f) / 10f).ToString();
                                hienthi1[i].Ptotal = ((float)Math.Round(float.Parse(hienthi1[i].Ptotal) * 10f) / 10f).ToString();
                                count_snack_Kwh += float.Parse(hienthi1[i].Kwh);
                                count_snack_Ptotal += float.Parse(hienthi1[i].Ptotal);
                                break;
                            case "9":
                                hienthi1[i].Kwh = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(snack9_recoder_begin.Kwh)) * 10f) / 10f).ToString();
                                hienthi1[i].Ptotal = ((float)Math.Round(float.Parse(hienthi1[i].Ptotal) * 10f) / 10f).ToString();
                                count_snack_Kwh += float.Parse(hienthi1[i].Kwh);
                                count_snack_Ptotal += float.Parse(hienthi1[i].Ptotal);
                                break;
                            case "10":
                                hienthi1[i].Kwh = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(snack10_recoder_begin.Kwh)) * 10f) / 10f).ToString();
                                hienthi1[i].Ptotal = ((float)Math.Round(float.Parse(hienthi1[i].Ptotal) * 10f) / 10f).ToString();
                                count_pc15_Kwh += float.Parse(hienthi1[i].Kwh);
                                count_pc15_Ptotal += float.Parse(hienthi1[i].Ptotal);
                                break;
                            case "11":
                                hienthi1[i].Kwh = ((float)Math.Round((float.Parse(hienthi1[i].Kwh) - float.Parse(snack11_recoder_begin.Kwh)) * 10f) / 10f).ToString();
                                hienthi1[i].Ptotal = ((float)Math.Round(float.Parse(hienthi1[i].Ptotal) * 10f) / 10f).ToString();
                                count_snack_Kwh += float.Parse(hienthi1[i].Kwh);
                                count_snack_Ptotal += float.Parse(hienthi1[i].Ptotal);
                                break;
                            default:
                                break;

                        }
                        //hienthi1[i].Ptotal = ((float)Math.Round(float.Parse(hienthi1[i].Ptotal) * 10f) / 10f).ToString();
                        //count_snack_Ptotal += float.Parse(hienthi1[i].Ptotal);
                        //count_snack_Kwh += float.Parse(hienthi1[i].Kwh);
                    }
                }


                var data = new List<object>();
                data.Add(gas); // 0
                data.Add(water); // 1
                data.Add(hienthi); // 2
                data.Add(((float)Math.Round(count_Ptotal * 10f) / 10f)); //3
                data.Add(((float)Math.Round(count_Kwh * 10f) / 10f)); // 4
                data.Add(hienthi1); // 5
                data.Add(((float)Math.Round(count_snack_Ptotal * 10f) / 10f)); // 6
                data.Add(((float)Math.Round(count_snack_Kwh * 10f) / 10f)); // 7
                data.Add(((float)Math.Round(count_pc15_Ptotal * 10f) / 10f)); // 8
                data.Add(((float)Math.Round(count_pc15_Kwh * 10f) / 10f)); // 9

                var result = data;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
    }
}