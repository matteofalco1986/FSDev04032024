using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Week18_Lezione1_Esercitazione.Models;

namespace Week18_Lezione1_Esercitazione.Controllers
{
    public class LoginFormController : Controller
    {
        // GET: LoginForm
        [HttpGet]
        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(AdminData admin)
        {
            SqlConnection conn = Commands.ConnectToDb();
            var command = new SqlCommand(Queries.AdminData, conn);

            // Injects Csharp data into Db query
            command.Parameters.AddWithValue("@username", admin.Username);
            command.Parameters.AddWithValue("@password", admin.Password);

            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                FormsAuthentication.SetAuthCookie(reader["Id"].ToString(), false);
                return RedirectToAction("Index", "Home");
            }

            TempData["ErrorLogin"] = true;
            return RedirectToAction("Index", "LoginForm");
        }

        [Authorize, HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Username, Password")] AdminData admin)
        {
            if (ModelState.IsValid)
            {
                var conn = Commands.ConnectToDb();
                SqlCommand command = new SqlCommand(Queries.RegisterUser, conn);
                command.Parameters.AddWithValue("@username", admin.Username);
                command.Parameters.AddWithValue("@password", admin.Password);
                command.ExecuteNonQuery();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}