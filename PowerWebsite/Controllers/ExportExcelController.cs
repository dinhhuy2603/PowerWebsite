using PowerWebsite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace PowerWebsite.Controllers
{
    public class ExportExcelController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET: ExportExcel Water Chart 1
        public ActionResult ExportWaterNowReport(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder_Water>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder_water.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder_water.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();
                
                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Water Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportWater.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Water", "Report");
        }

        public ActionResult ExportWaterReport(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder_Water>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder_water.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder_water.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Water Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportWater.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Water", "Report");
        }

        // Export Kenh 1
        public ActionResult ExportLPSNACK3KWReport(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder_DongHo1>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder_kenh1.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder_kenh1.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();
                
                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("LP-SNACK-3 Report");
                Sheet.Cells["A1"].Value = "Thời gian";
                Sheet.Cells["B1"].Value = "Kw";
                int row = 2;
                foreach (var item in recoders)
                {
                    Sheet.Cells[string.Format("A{0}", row)].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";

                    Sheet.Cells[string.Format("A{0}", row)].Value = item.Thoigian;
                    Sheet.Cells[string.Format("B{0}", row)].Value = float.Parse(item.Ptotal);

                    row++;
                }
                Sheet.Column(1).Width = 50;
                Sheet.Column(2).Width = 40;
                Sheet.Cells["A1:B1"].Style.Font.Size = 12;
                Sheet.Cells["A1:B1"].Style.Font.Bold = true;
                Sheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Sheet.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportLPSNACK3.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh1", "Report");
        }

        public ActionResult ExportLPSNACK3Report(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder_DongHo1>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder_kenh1.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder_kenh1.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("LP-SNACK-3 Report");
                Sheet.Cells["A1"].Value = "Thời gian";
                Sheet.Cells["B1"].Value = "Kwh";
                int row = 2;
                foreach (var item in recoders)
                {
                    Sheet.Cells[string.Format("A{0}", row)].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";

                    Sheet.Cells[string.Format("A{0}", row)].Value = item.Thoigian;
                    Sheet.Cells[string.Format("B{0}", row)].Value = float.Parse(item.Kwh);

                    row++;
                }
                Sheet.Column(1).Width = 50;
                Sheet.Column(2).Width = 40;
                Sheet.Cells["A1:B1"].Style.Font.Size = 12;
                Sheet.Cells["A1:B1"].Style.Font.Bold = true;
                Sheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Sheet.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportLPSNACK3.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh1", "Report");
        }

        // Export Kenh 2 KW
        public ActionResult ExportLPSNACK1KWReport(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder_DongHo2>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder_kenh2.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder_kenh2.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("LP-SNACK-1 Report");
                Sheet.Cells["A1"].Value = "Thời gian";
                Sheet.Cells["B1"].Value = "Kw";
                int row = 2;
                foreach (var item in recoders)
                {
                    Sheet.Cells[string.Format("A{0}", row)].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";

                    Sheet.Cells[string.Format("A{0}", row)].Value = item.Thoigian;
                    Sheet.Cells[string.Format("B{0}", row)].Value = float.Parse(item.Ptotal);

                    row++;
                }
                Sheet.Column(1).Width = 50;
                Sheet.Column(2).Width = 40;
                Sheet.Cells["A1:B1"].Style.Font.Size = 12;
                Sheet.Cells["A1:B1"].Style.Font.Bold = true;
                Sheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Sheet.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportLPSNACK1.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh2", "Report");
        }

        // Export Kenh 2
        public ActionResult ExportLPSNACK1Report(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder_DongHo2>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder_kenh2.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder_kenh2.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();
                
                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("LP-SNACK-1 Report");
                Sheet.Cells["A1"].Value = "Thời gian";
                Sheet.Cells["B1"].Value = "Kwh";
                int row = 2;
                foreach (var item in recoders)
                {
                    Sheet.Cells[string.Format("A{0}", row)].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";

                    Sheet.Cells[string.Format("A{0}", row)].Value = item.Thoigian;
                    Sheet.Cells[string.Format("B{0}", row)].Value = float.Parse(item.Kwh);

                    row++;
                }
                Sheet.Column(1).Width = 50;
                Sheet.Column(2).Width = 40;
                Sheet.Cells["A1:B1"].Style.Font.Size = 12;
                Sheet.Cells["A1:B1"].Style.Font.Bold = true;
                Sheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Sheet.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportLPSNACK1.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh2", "Report");
        }

        // Export Kenh 3 KW
        public ActionResult ExportLPSNACK2KWReport(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder_DongHo3>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder_kenh3.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder_kenh3.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("LP-SNACK-2 Report");
                Sheet.Cells["A1"].Value = "Thời gian";
                Sheet.Cells["B1"].Value = "Kw";
                int row = 2;
                foreach (var item in recoders)
                {
                    Sheet.Cells[string.Format("A{0}", row)].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";

                    Sheet.Cells[string.Format("A{0}", row)].Value = item.Thoigian;
                    Sheet.Cells[string.Format("B{0}", row)].Value = float.Parse(item.Ptotal);

                    row++;
                }
                Sheet.Column(1).Width = 50;
                Sheet.Column(2).Width = 40;
                Sheet.Cells["A1:B1"].Style.Font.Size = 12;
                Sheet.Cells["A1:B1"].Style.Font.Bold = true;
                Sheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Sheet.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportLPSNACK2.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh3", "Report");
        }

        // Export Kenh 3
        public ActionResult ExportLPSNACK2Report(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder_DongHo3>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder_kenh3.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder_kenh3.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();
                
                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("LP-SNACK-2 Report");
                Sheet.Cells["A1"].Value = "Thời gian";
                Sheet.Cells["B1"].Value = "Kwh";
                int row = 2;
                foreach (var item in recoders)
                {
                    Sheet.Cells[string.Format("A{0}", row)].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";

                    Sheet.Cells[string.Format("A{0}", row)].Value = item.Thoigian;
                    Sheet.Cells[string.Format("B{0}", row)].Value = float.Parse(item.Kwh);

                    row++;
                }
                Sheet.Column(1).Width = 50;
                Sheet.Column(2).Width = 40;
                Sheet.Cells["A1:B1"].Style.Font.Size = 12;
                Sheet.Cells["A1:B1"].Style.Font.Bold = true;
                Sheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Sheet.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportLPSNACK2.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh3", "Report");
        }

        // Export Kenh 4 KW
        public ActionResult ExportDPSNACK2KWReport(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder_DongHo4>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder_kenh4.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder_kenh4.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DP-SNACK-2 Report");
                Sheet.Cells["A1"].Value = "Thời gian";
                Sheet.Cells["B1"].Value = "Kw";
                int row = 2;
                foreach (var item in recoders)
                {
                    Sheet.Cells[string.Format("A{0}", row)].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";

                    Sheet.Cells[string.Format("A{0}", row)].Value = item.Thoigian;
                    Sheet.Cells[string.Format("B{0}", row)].Value = float.Parse(item.Ptotal);

                    row++;
                }
                Sheet.Column(1).Width = 50;
                Sheet.Column(2).Width = 40;
                Sheet.Cells["A1:B1"].Style.Font.Size = 12;
                Sheet.Cells["A1:B1"].Style.Font.Bold = true;
                Sheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Sheet.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDPSNACK2.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh4", "Report");
        }

        // Export Kenh 4
        public ActionResult ExportDPSNACK2Report(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder_DongHo4>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder_kenh4.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder_kenh4.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();
                
                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DP-SNACK-2 Report");
                Sheet.Cells["A1"].Value = "Thời gian";
                Sheet.Cells["B1"].Value = "Kwh";
                int row = 2;
                foreach (var item in recoders)
                {
                    Sheet.Cells[string.Format("A{0}", row)].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";

                    Sheet.Cells[string.Format("A{0}", row)].Value = item.Thoigian;
                    Sheet.Cells[string.Format("B{0}", row)].Value = float.Parse(item.Kwh);

                    row++;
                }
                Sheet.Column(1).Width = 50;
                Sheet.Column(2).Width = 40;
                Sheet.Cells["A1:B1"].Style.Font.Size = 12;
                Sheet.Cells["A1:B1"].Style.Font.Bold = true;
                Sheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Sheet.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDPSNACK2.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh4", "Report");
        }

        // Export Kenh 5
        public ActionResult ExportDPSNACK1Report(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder_DongHo5>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder_kenh5.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder_kenh5.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();
                
                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DP-SNACK-1 Report");
                Sheet.Cells["A1"].Value = "Thời gian";
                Sheet.Cells["B1"].Value = "Kwh";
                int row = 2;
                foreach (var item in recoders)
                {
                    Sheet.Cells[string.Format("A{0}", row)].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";

                    Sheet.Cells[string.Format("A{0}", row)].Value = item.Thoigian;
                    Sheet.Cells[string.Format("B{0}", row)].Value = float.Parse(item.Kwh);

                    row++;
                }
                Sheet.Column(1).Width = 50;
                Sheet.Column(2).Width = 40;
                Sheet.Cells["A1:B1"].Style.Font.Size = 12;
                Sheet.Cells["A1:B1"].Style.Font.Bold = true;
                Sheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Sheet.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDPSNACK1.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh5", "Report");
        }

        // Export Kenh 5 KW
        public ActionResult ExportDPSNACK1KWReport(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder_DongHo5>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder_kenh5.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder_kenh5.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DP-SNACK-1 Report");
                Sheet.Cells["A1"].Value = "Thời gian";
                Sheet.Cells["B1"].Value = "Kw";
                int row = 2;
                foreach (var item in recoders)
                {
                    Sheet.Cells[string.Format("A{0}", row)].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";

                    Sheet.Cells[string.Format("A{0}", row)].Value = item.Thoigian;
                    Sheet.Cells[string.Format("B{0}", row)].Value = float.Parse(item.Ptotal);

                    row++;
                }
                Sheet.Column(1).Width = 50;
                Sheet.Column(2).Width = 40;
                Sheet.Cells["A1:B1"].Style.Font.Size = 12;
                Sheet.Cells["A1:B1"].Style.Font.Bold = true;
                Sheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Sheet.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDPSNACK1.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh5", "Report");
        }

        // Export Kenh 6 KW
        public ActionResult ExportDPSNACK3KWReport(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder_DongHo6>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder_kenh6.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder_kenh6.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DP-SNACK-3 Report");
                Sheet.Cells["A1"].Value = "Thời gian";
                Sheet.Cells["B1"].Value = "Kw";
                int row = 2;
                foreach (var item in recoders)
                {
                    Sheet.Cells[string.Format("A{0}", row)].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";
                    Sheet.Cells[string.Format("A{0}", row)].Value = item.Thoigian;
                    Sheet.Cells[string.Format("B{0}", row)].Value = float.Parse(item.Ptotal);

                    row++;
                }
                Sheet.Column(1).Width = 50;
                Sheet.Column(2).Width = 40;
                Sheet.Cells["A1:B1"].Style.Font.Size = 12;
                Sheet.Cells["A1:B1"].Style.Font.Bold = true;
                Sheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Sheet.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDPSNACK3.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh6", "Report");
        }

        // Export Kenh 6
        public ActionResult ExportDPSNACK3Report(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder_DongHo6>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder_kenh6.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder_kenh6.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();
                
                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DP-SNACK-3 Report");
                Sheet.Cells["A1"].Value = "Thời gian";
                Sheet.Cells["B1"].Value = "Kwh";
                int row = 2;
                foreach (var item in recoders)
                {
                    Sheet.Cells[string.Format("A{0}", row)].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";
                    Sheet.Cells[string.Format("A{0}", row)].Value = item.Thoigian;
                    Sheet.Cells[string.Format("B{0}", row)].Value = float.Parse(item.Kwh);

                    row++;
                }
                Sheet.Column(1).Width = 50;
                Sheet.Column(2).Width = 40;
                Sheet.Cells["A1:B1"].Style.Font.Size = 12;
                Sheet.Cells["A1:B1"].Style.Font.Bold = true;
                Sheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Sheet.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDPSNACK3.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh6", "Report");
        }
    }
}