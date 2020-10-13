using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PowerWebsite.Models;
using System.Data.Entity;
using System.Net;
using System.Web.Hosting;
using System.Net.Mail;
using System.Collections.Generic;
using PagedList;
using System.Text;

namespace PowerWebsite.Controllers
{
    public class AccountController : Controller
    {
        DBModel db = new DBModel();
        public ActionResult Index(int? page)
        {
            if (Session["UserID"] != null && Session["role"].Equals("admin"))
            {
                using (DBModel db = new DBModel())
                {
                    var users = new List<UserAccount>();
                    users = db.useraccount.OrderByDescending(x => x.user_name)
                             .ToList();
                    ViewBag.UserList = users;
                    if (page == null)
                    {
                        page = 1;
                    }
                    int pageSize = 20;
                    int pageNumber = (page ?? 1);
                    Session["users"] = users;
                    return View(users.ToPagedList(pageNumber, pageSize));
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserAccLogin objUser)
        {
            if (ModelState.IsValid)
            {
                using (DBModel db = new DBModel())
                {
                    var obj = db.useraccount.Where(a => a.user_name.Equals(objUser.user_name) && a.password.Equals(objUser.password) && a.isValid.Equals(1)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.id;
                        Session["Name"] = obj.full_name.ToString();
                        Session["user_name"] = obj.user_name.ToString();
                        Session["Role"] = obj.role.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Message = "Email hoặc mật khẩu không chính xác.";
                        return View();
                    }
                }
            }

            return View(objUser);
        }

        public ActionResult Create()
        {
            if (Session["UserID"] != null && Session["role"].Equals("admin"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Logout", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserAccountCreate objUser)
        {
            if (ModelState.IsValid)
            {
                using (DBModel db = new DBModel())
                {
                    var obj = db.useraccount.Where(a => a.user_name.Equals(objUser.user_name)).FirstOrDefault();
                    if (obj != null)
                    {
                        ViewBag.Message = "Tài khoản đã tồn tại.";
                        return View();
                    }
                    else
                    {
                        try
                        {
                            UserAccount user = new UserAccount();
                            user.user_name = objUser.user_name;
                            user.full_name = objUser.full_name;
                            user.password = objUser.password;
                            user.phone = objUser.phone;
                            user.email = objUser.email;
                            user.role = objUser.role;
                            user.isValid = 1;
                            db.useraccount.Add(user);
                            db.SaveChanges();
                            return RedirectToAction("Index", "Account");
                        }
                        catch (Exception exception)
                        {
                            ViewBag.Message = exception;
                            return View();
                        }
                    }
                }
            }
            return View(objUser);
        }
        public ActionResult Edit(int? id)
        {
            if (Session["UserID"] != null && Session["role"].Equals("admin"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                using (DBModel db = new DBModel())
                {
                    var obj = db.useraccount.Find(id);
                    if (obj != null)
                    {
                        UserAccountUpdate user = new UserAccountUpdate();
                        user.id = obj.id;
                        user.user_name = obj.user_name;
                        user.full_name = obj.full_name;
                        user.password = obj.password;
                        user.email = obj.email;
                        user.phone = obj.phone;
                        user.role = obj.role;
                        user.isValid = obj.isValid;
                        return View(user);
                    }
                    else
                    {
                        return HttpNotFound();
                    }
                }
            }
            else
            {
                return RedirectToAction("Logout", "Account");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind]UserAccountUpdate user)
        {
            if (ModelState.IsValid)
            {
                using (DBModel db = new DBModel())
                {
                    UserAccount user_current = db.useraccount.Find(user.id);
                    user_current.user_name = user.user_name;
                    user_current.full_name = user.full_name;
                    user_current.email = user.email;
                    user_current.phone = user.phone;
                    user_current.role = user.role;
                    if (!String.IsNullOrEmpty(user.password))
                    {
                        user_current.password = user.password;
                    }
                    db.Entry(user_current).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(user);
        }

        public ActionResult ChangePassword(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (DBModel db = new DBModel())
            {
                var obj = db.useraccount.Find(id);
                if (obj != null)
                {
                    ViewBag.user = obj;
                    return View();
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(UserAccChangePass model)
        {
            if (ModelState.IsValid)
            {
                using (DBModel db = new DBModel())
                {
                    if (Session["UserID"] == null)
                    {
                        ViewBag.Message = "Tài khoản không tồn tại.";
                        return View();
                    }
                    else
                    {
                        try
                        {
                            UserAccount user_current = db.useraccount.Find((int)Session["UserID"]);
                            var oldPassword = user_current.password;
                            if (model.OldPassword.Equals(oldPassword))
                            {
                                user_current.password = model.NewPassword;
                                user_current.isValid = 0;
                                db.Entry(user_current).State = EntityState.Modified;
                                db.SaveChanges();
                                BuildEmailTemplate(user_current.id);
                                ViewBag.MessageSuccess = "Kiểm tra email để xác nhận thay đổi mật khẩu.";
                                return View();
                            }
                            else
                            {
                                ViewBag.Message = "Tài khoản không tồn tại.";
                                return View();
                                //return RedirectToAction("Login", "Account");
                            }

                        }
                        catch (Exception exception)
                        {
                            ViewBag.Message = exception;
                            return View();
                        }
                    }
                }
            }
            return View(model);
        }

        public ActionResult Confirm(int regId)
        {
            ViewBag.regID = regId;
            return View();
        }
        public JsonResult ChangePasswordConfirm(int regId)
        {
            UserAccount Data = db.useraccount.Where(x => x.id == regId).FirstOrDefault();
            Data.isValid = 1;
            db.SaveChanges();
            var msg = "Your Email Is Verified!";
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public void BuildEmailTemplate(int regID)
        {
            string body = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/EmailTemplate/") + "Text" + ".cshtml");
            var regInfo = db.useraccount.Where(x => x.id == regID).FirstOrDefault();
            var url = "http://localhost:56689/" + "Account/Confirm?regId=" + regID;
            body = body.Replace("@ViewBag.Name", regInfo.full_name);
            body = body.Replace("@ViewBag.ConfirmationLink", url);
            body = body.ToString();
            BuildEmailTemplate("Your Password Is Successfully Changed", body, regInfo.email);
        }

        public static void BuildEmailTemplate(string subjectText, string bodyText, string sendTo)
        {
            string from, to, bcc, cc, subject, body;
            from = "doandinhhuy1990@gmail.com";
            to = sendTo.Trim();
            bcc = "";
            cc = "";
            subject = subjectText;
            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            body = sb.ToString();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(to));
            if (!string.IsNullOrEmpty(bcc))
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }
            if (!string.IsNullOrEmpty(cc))
            {
                mail.CC.Add(new MailAddress(cc));
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SendEmail(mail);
        }

        public static void SendEmail(MailMessage mail)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential("doandinhhuy1990@gmail.com", "Huy26031990");
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login");
        }

        public JsonResult Delete(int id)
        {
            UserAccount user = db.useraccount.Find(id);
            db.useraccount.Remove(user);
            db.SaveChanges();
            var msg = "Xóa thành công " + user.full_name + " !";
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
    }
}