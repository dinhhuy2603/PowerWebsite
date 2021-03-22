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
    public class ExportSolarLogisticController : Controller
    {
        // GET: ExportSolarLogistic
        public ActionResult Index()
        {
            return View();
        }

        // Export Solar 1
        public ActionResult ExportSolar1KWReport(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_DB_Solar1>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_db_solar1.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_db_solar1.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DB-Solar 1 Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDBSolar1.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Solar1Report", "Solar_Logistic");
        }

        public ActionResult ExportSolar1Report(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_DB_Solar1>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_db_solar1.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_db_solar1.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DB-Solar 1 Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDBSolar1.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Solar1Report", "Solar_Logistic");
        }

        // Export Solar 2
        public ActionResult ExportSolar2KWReport(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_DB_Solar2>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_db_solar2.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_db_solar2.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DB-Solar 2 Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDBSolar2.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Solar2Report", "Solar_Logistic");
        }

        public ActionResult ExportSolar2Report(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_DB_Solar2>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_db_solar2.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_db_solar2.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DB-Solar 2 Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDBSolar2.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("Solar2Report", "Solar_Logistic");
        }

        // Export Logistics
        public ActionResult ExportLogisticKWReport(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_DB_Logistics>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_db_logistics.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_db_logistics.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DB-Logistics WH Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDBLogistics.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("LogisticReport", "Solar_Logistic");
        }

        public ActionResult ExportLogisticReport(DateTime? fromDate, DateTime? toDate)
        {
            using (DBModel db = new DBModel())
            {
                var recoders = new List<Recoder1_DB_Logistics>();
                if (fromDate.HasValue && toDate.HasValue)
                {
                    toDate = toDate.GetValueOrDefault(DateTime.Now.Date).Date.AddHours(23).AddMinutes(59);
                    recoders = db.recoder1_db_logistics.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                else
                {
                    if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
                    if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                    recoders = db.recoder1_db_logistics.Where(x => x.Thoigian <= toDate && x.Thoigian >= fromDate).ToList();
                    ViewBag.Recoders = recoders;
                    ViewBag.fromDate = fromDate;
                    ViewBag.toDate = toDate;
                }
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage Ep = new ExcelPackage();

                ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("DB-Logistics WH Report");
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
                Response.AppendHeader("content-disposition", "attachment: filename=\"ReportDBLogistics.xlsx\"");
                Response.BinaryWrite(Ep.GetAsByteArray());
                Response.End();
            }
            return RedirectToAction("LogisticReport", "Solar_Logistic");
        }

    }
}