using OverlookHotelGestionale.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OverlookHotelGestionale.Controllers
{
    public class PrenotazioniController : Controller
    {
   
        // GET: Prenotazioni
        public ActionResult NuovaPrenotazione()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OverlookHotel"].ToString();
            var conn = new SqlConnection(connectionString);
            List<Camera> listaCamere = new List<Camera>();
            conn.Open();
            var commandList = new SqlCommand("SELECT * FROM Camera", conn);
            var readerList = commandList.ExecuteReader();

            if (readerList.HasRows)
            {
                while (readerList.Read())
                {
                    var camera = new Camera()
                    {
                        IdCamera = (int)readerList["IdCamera"],
                        NumeroCamera = (int)readerList["NumeroCamera"],
                        Descrizione = (string)readerList["Descrizione"],
                        Tipologia = (string)readerList["Tipologia"]
                    };
                    listaCamere.Add(camera);
                }
                ViewBag.listaCamere = listaCamere;
                conn.Close();
            }
            return View();
        }

        [HttpPost]
        public ActionResult NuovaPrenotazione(Prenotazione nuovaPrenotazione)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OverlookHotel"].ToString();
            var conn = new SqlConnection(connectionString);
            if (ModelState.IsValid)
            {
                try
                {
                    conn.Open();
                    var command = new SqlCommand(@"INSERT INTO Prenotazione 
                    (CodiceFiscale, Cognome, Nome, Citta, Provincia, Email, Telefono, Cellulare, IdCamera, DataPrenotazione, InizioPeriodoSoggiorno, FinePeriodoSoggiorno, Anno, Caparra, Tariffa, TipoDiSoggiorno)
                    VALUES (@codiceFiscale, @cognome, @nome, @citta, @provincia, @email, @telefono, @cellulare, @idCamera, @dataPrenotazione, @inizioPeriodoSoggiorno, @finePeriodoSoggiorno, @anno, @caparra, @tariffa, @tipoDiSoggiorno)", conn);
                    command.Parameters.AddWithValue("@codiceFiscale", nuovaPrenotazione.CodiceFiscale);
                    command.Parameters.AddWithValue("@cognome", nuovaPrenotazione.Cognome);
                    command.Parameters.AddWithValue("@nome", nuovaPrenotazione.Nome);
                    command.Parameters.AddWithValue("@citta", nuovaPrenotazione.Citta);
                    command.Parameters.AddWithValue("@provincia", nuovaPrenotazione.Provincia);
                    command.Parameters.AddWithValue("@email", nuovaPrenotazione.Email);
                    command.Parameters.AddWithValue("@telefono", nuovaPrenotazione.Telefono);
                    command.Parameters.AddWithValue("@cellulare", nuovaPrenotazione.Cellulare);
                    command.Parameters.AddWithValue("@idCamera", nuovaPrenotazione.IdCamera);
                    command.Parameters.AddWithValue("@dataPrenotazione", nuovaPrenotazione.DataPrenotazione);
                    command.Parameters.AddWithValue("@inizioSoggiorno", nuovaPrenotazione.InizioPeriodoSoggiorno);
                    command.Parameters.AddWithValue("@finePeriodoSoggiorno", nuovaPrenotazione.FinePeriodoSoggiorno);
                    command.Parameters.AddWithValue("@anno", nuovaPrenotazione.Anno);
                    command.Parameters.AddWithValue("@caparra", nuovaPrenotazione.Caparra);
                    command.Parameters.AddWithValue("@tariffa", nuovaPrenotazione.Tariffa);
                    command.Parameters.AddWithValue("@tipoDiSoggiorno", nuovaPrenotazione.TipoDiSoggiorno);
                    var nRows = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return View("error");
                }
                finally { conn.Close(); }
                return RedirectToAction("LoggedIn", "Home");
            }
            return View();

        }
    }
}