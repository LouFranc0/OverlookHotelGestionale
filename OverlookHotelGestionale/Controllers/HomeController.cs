using OverlookHotelGestionale.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OverlookHotelGestionale.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LoggedIn", "Home"); //sei già loggato, torna alla home
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(Dipendente dipendente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OverlookHotel"].ToString();
            var conn = new SqlConnection(connectionString);
            if (ModelState.IsValid)
            {
                try
                {
                    conn.Open();
                    var command = new SqlCommand("SELECT * FROM Dipendente WHERE Username = @username AND Password = @password", conn);
                    command.Parameters.AddWithValue("@username", dipendente.Username);
                    command.Parameters.AddWithValue("@password", dipendente.Password);
                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        FormsAuthentication.SetAuthCookie(reader["IdDipendente"].ToString(), true);
                        return RedirectToAction("LoggedIn", "Home");
                    }
                    else
                    {
                        return View("error");
                    }
                }
                catch (Exception ex)
                {
                    return View("error");
                }
                finally { conn.Close(); }
            }
            return View("LoggedIn");
        }

        //questa è la vera home page
        [Authorize]
        public ActionResult LoggedIn()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}