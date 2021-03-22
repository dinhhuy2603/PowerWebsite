using OfficeOpenXml;
using OfficeOpenXml.Style;
using PowerWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PowerWebsite.Controllers
{
    public class ExportSteamController : Controller
    {
        // GET: ExportSteam
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ExportSteamPc10NowReport(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_Steam_PC10>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_steam_pc10.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_steam_pc10.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Steam PC 10 Report");
                Sheet.Cells["A1"].Value = "Thời gian";
                Sheet.Cells["B1"].Value = "Lưu lượng hiện tại (m3/h)";
                //Sheet.Cells["C1"].Value = "Lưu lượng tổng (m3)";
                int row = 2;
                foreach (var item in recoders)
                {
                    Sheet.Cells[string.Format("A{0}", row)].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";

                    Sheet.Cells[string.Format("A{0}", row)].Value = item.Thoigian;
                    Sheet.Cells[string.Format("B{0}", row)].Value = float.Parse(item.luu_luong_hien_tai);
                    //Sheet.Cells[string.Format("C{0}", row)].Value = item.luu_luong_tong;

                    row++;
                }
                Sheet.Column(1).Width = 50;
                Sheet.Column(2).Width = 40;
                Sheet.Column(3).Width = 40;
                Sheet.Cells["A1:C1"].Style.Font.Size = 12;
                Sheet.Cells["A1:C1"].Style.Font.Bold = true;
                Sheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Sheet.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportSteamPc10.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("PC10Report", "Steam");
        }

        public ActionResult ExportSteamPc10Report(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_Steam_PC10>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_steam_pc10.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_steam_pc10.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Steam PC 10 Report");
                Sheet.Cells["A1"].Value = "Thời gian";
                Sheet.Cells["B1"].Value = "Lưu lượng hiện tại (m3/h)";
                Sheet.Cells["C1"].Value = "Lưu lượng tổng (m3)";
                int row = 2;
                foreach (var item in recoders)
                {
                    Sheet.Cells[string.Format("A{0}", row)].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";

                    Sheet.Cells[string.Format("A{0}", row)].Value = item.Thoigian;
                    Sheet.Cells[string.Format("B{0}", row)].Value = float.Parse(item.luu_luong_hien_tai);
                    Sheet.Cells[string.Format("C{0}", row)].Value = float.Parse(item.luu_luong_tong);

                    row++;
                }
                Sheet.Column(1).Width = 50;
                Sheet.Column(2).Width = 40;
                Sheet.Column(3).Width = 40;
                Sheet.Cells["A1:C1"].Style.Font.Size = 12;
                Sheet.Cells["A1:C1"].Style.Font.Bold = true;
                Sheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Sheet.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportSteamPc10.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("PC10Report", "Steam");
        }

        public ActionResult ExportSteamPc15NowReport(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_Steam_PC15>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_steam_pc15.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_steam_pc15.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Steam PC 15 Report");
                Sheet.Cells["A1"].Value = "Thời gian";
                Sheet.Cells["B1"].Value = "Lưu lượng hiện tại (m3/h)";
                //Sheet.Cells["C1"].Value = "Lưu lượng tổng (m3)";
                int row = 2;
                foreach (var item in recoders)
                {
                    Sheet.Cells[string.Format("A{0}", row)].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";

                    Sheet.Cells[string.Format("A{0}", row)].Value = item.Thoigian;
                    Sheet.Cells[string.Format("B{0}", row)].Value = float.Parse(item.luu_luong_hien_tai);
                    //Sheet.Cells[string.Format("C{0}", row)].Value = item.luu_luong_tong;

                    row++;
                }
                Sheet.Column(1).Width = 50;
                Sheet.Column(2).Width = 40;
                Sheet.Column(3).Width = 40;
                Sheet.Cells["A1:C1"].Style.Font.Size = 12;
                Sheet.Cells["A1:C1"].Style.Font.Bold = true;
                Sheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Sheet.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportSteamPc15.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("PC15Report", "Steam");
        }

        public ActionResult ExportSteamPc15Report(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_Steam_PC15>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_steam_pc15.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_steam_pc15.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Steam PC 15 Report");
                Sheet.Cells["A1"].Value = "Thời gian";
                Sheet.Cells["B1"].Value = "Lưu lượng hiện tại (m3/h)";
                Sheet.Cells["C1"].Value = "Lưu lượng tổng (m3)";
                int row = 2;
                foreach (var item in recoders)
                {
                    Sheet.Cells[string.Format("A{0}", row)].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";

                    Sheet.Cells[string.Format("A{0}", row)].Value = item.Thoigian;
                    Sheet.Cells[string.Format("B{0}", row)].Value = float.Parse(item.luu_luong_hien_tai);
                    Sheet.Cells[string.Format("C{0}", row)].Value = float.Parse(item.luu_luong_tong);

                    row++;
                }
                Sheet.Column(1).Width = 50;
                Sheet.Column(2).Width = 40;
                Sheet.Column(3).Width = 40;
                Sheet.Cells["A1:C1"].Style.Font.Size = 12;
                Sheet.Cells["A1:C1"].Style.Font.Bold = true;
                Sheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Sheet.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportSteamPc15.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("PC15Report", "Steam");
        }

    }
}