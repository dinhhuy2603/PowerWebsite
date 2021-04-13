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
    public class ExportElectric2Controller : Controller
    {
        // GET: ExportElectric2
        public ActionResult Index()
        {
            return View();
        }
        // Export Kenh 4 (DB-PC 15 - Electric 2)
        public ActionResult ExportKenh4KWReport(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_DB_PC15>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_kenh4.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_kenh4.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DB-PC-15 Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDB_PC15.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh4", "ReportElectric2");
        }

        public ActionResult ExportKenh4Report(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_DB_PC15>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_kenh4.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_kenh4.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DB - PC - 15 Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDB_PC15.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh4", "ReportElectric2");
        }

        // Export Kenh 5 (DB-PC 10 - Electric 2)
        public ActionResult ExportKenh5KWReport(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_DB_PC10>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_kenh5.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_kenh5.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DB-PC-10 Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDB_PC10.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh5", "ReportElectric2");
        }

        public ActionResult ExportKenh5Report(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_DB_PC10>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_kenh5.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_kenh5.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DB-PC-10 Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDB_PC10.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh5", "ReportElectric2");
        }

        // Export Kenh 6 (DB-Snack 1 - Electric 2)
        public ActionResult ExportKenh6KWReport(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_DB_Snack1>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_kenh6.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_kenh6.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DB-Snack 1 Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDB_Snack1.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh6", "ReportElectric2");
        }

        public ActionResult ExportKenh6Report(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_DB_Snack1>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_kenh6.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_kenh6.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DB-Snack 1 Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDB_Snack1.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh6", "ReportElectric2");
        }

        // Export Kenh 7 (DB-Snack 2 - Electric 2)
        public ActionResult ExportKenh7KWReport(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_DB_Snack2>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_kenh7.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_kenh7.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DB-Snack 2 Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDB_Snack2.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh7", "ReportElectric2");
        }

        public ActionResult ExportKenh7Report(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_DB_Snack2>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_kenh7.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_kenh7.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DB-Snack 2 Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDB_Snack2.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh7", "ReportElectric2");
        }

        // Export Kenh 8 (DB-Snack 3 - Electric 2)
        public ActionResult ExportKenh8KWReport(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_DB_Snack3>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_kenh8.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_kenh8.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DB-Snack 3 Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDB_Snack3.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh8", "ReportElectric2");
        }

        public ActionResult ExportKenh8Report(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_DB_Snack3>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_kenh8.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_kenh8.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DB-Snack 3 Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDB_Snack3.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh8", "ReportElectric2");
        }

        // Export Kenh 9 (DB-Snack 4 - Electric 2)
        public ActionResult ExportKenh9KWReport(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_DB_Snack4>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_kenh9.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_kenh9.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DB-Snack 4 Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDB_Snack4.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh9", "ReportElectric2");
        }

        public ActionResult ExportKenh9Report(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_DB_Snack4>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_kenh9.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_kenh9.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DB-Snack 4 Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDB_Snack4.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh9", "ReportElectric2");
        }

        // Export Kenh 10 (LP-PC15 - Electric 2)
        public ActionResult ExportKenh10KWReport(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_LP_PC15>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_kenh10.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_kenh10.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("LP-PC-15 Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportLP_PC15.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh10", "ReportElectric2");
        }

        public ActionResult ExportKenh10Report(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_LP_PC15>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_kenh10.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_kenh10.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("LP-PC-15 Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportLP_PC15.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh10", "ReportElectric2");
        }

        // Export Kenh 11 (LP-Snack 1 - Electric 2)
        public ActionResult ExportKenh11KWReport(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_LP_Snack1>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_kenh11.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_kenh11.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("LP-Snack 1 Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportLP_Snack1.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh11", "ReportElectric2");
        }

        public ActionResult ExportKenh11Report(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_LP_Snack1>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_kenh11.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_kenh11.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("LP-Snack 1 Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportLP_Snack1.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Kenh11", "ReportElectric2");
        }
    }
}