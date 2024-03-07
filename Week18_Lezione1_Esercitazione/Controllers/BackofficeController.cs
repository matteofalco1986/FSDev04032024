using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Web;
using System.Web.Mvc;
using Week18_Lezione1_Esercitazione.Models;

namespace Week18_Lezione1_Esercitazione.Controllers
{
    [Authorize]
    public class BackofficeController : Controller
    {
        // GET: Backoffice
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ShowCustomers()
        {
            var conn = Commands.ConnectToDb();
            SqlCommand command = new SqlCommand(Queries.CustomersList, conn);
            var reader = command.ExecuteReader();

            List<CodiciFiscali> Customers = new List<CodiciFiscali>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var customer = new CodiciFiscali();
                    customer.Id = (int)reader["Id"];
                    customer.Nome = (string)reader["Nome"];
                    customer.Cognome = (string)reader["Cognome"];
                    customer.CodiceFiscale = (string)reader["CodiceFiscale"];
                    customer.Indirizzo = (string)reader["Indirizzo"];
                    customer.Citta = (string)reader["Citta"];
                    Customers.Add(customer);
                }
            }
            return View(Customers);
        }

        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCustomer([Bind(Exclude = "Id")] CodiciFiscali customer)
        {
            if (ModelState.IsValid)
            {
                var conn = Commands.ConnectToDb();
                SqlCommand command = new SqlCommand(Queries.AddCustomer, conn);
                command.Parameters.AddWithValue("@Nome", customer.Nome);
                command.Parameters.AddWithValue("@Cognome", customer.Cognome);
                command.Parameters.AddWithValue("@CodiceFiscale", customer.CodiceFiscale);
                command.Parameters.AddWithValue("@Indirizzo", customer.Indirizzo);
                command.Parameters.AddWithValue("@Citta", customer.Citta);
                command.ExecuteNonQuery();

                return RedirectToAction("ShowCustomers", "Backoffice");
            }
            return View(customer);
        }

        [HttpGet]
        public ActionResult EditCustomer(int? id)
        {
            if (id == null) return RedirectToAction("ShowCustomers", "Backoffice");

            var conn = Commands.ConnectToDb();
            SqlCommand command = new SqlCommand(Queries.GetCustomerData, conn);
            command.Parameters.AddWithValue("@Id", id);
            var reader = command.ExecuteReader();

            var customer = new CodiciFiscali();

            if (reader.HasRows)
            {
                reader.Read();
                customer.Id = (int)reader["Id"];
                customer.Nome = (string)reader["Nome"];
                customer.Cognome = (string)reader["Cognome"];
                customer.CodiceFiscale = (string)reader["CodiceFiscale"];
                customer.Indirizzo = (string)reader["Indirizzo"];
                customer.Citta = (string)reader["Citta"];
            }

            reader.Close();
            conn.Close();

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer(CodiciFiscali customer)
        {
            if (ModelState.IsValid)
            {
                var conn = Commands.ConnectToDb();
                var command = new SqlCommand(Queries.GetCustomerData, conn);
                command.Parameters.AddWithValue("@Id", customer.Id);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                }
                reader.Close();

                SqlCommand commandUpdate = new SqlCommand(Queries.CustomerDataUpdate, conn);
                commandUpdate.Parameters.AddWithValue("@Id", customer.Id);
                commandUpdate.Parameters.AddWithValue("@Nome", customer.Nome);
                commandUpdate.Parameters.AddWithValue("@Cognome", customer.Cognome);
                commandUpdate.Parameters.AddWithValue("@CodiceFiscale", customer.CodiceFiscale);
                commandUpdate.Parameters.AddWithValue("@Indirizzo", customer.Indirizzo);
                commandUpdate.Parameters.AddWithValue("@Citta", customer.Citta);
                commandUpdate.ExecuteNonQuery();
                conn.Close();
                return RedirectToAction("ShowCustomers", "Backoffice");
            }


            return View(customer);
        }

        [HttpGet]
        public ActionResult ShowShippings()
        {
            var conn = Commands.ConnectToDb();
            SqlCommand command = new SqlCommand(Queries.ShippingsList, conn);
            var reader = command.ExecuteReader();

            List<Spedizioni> Shippings = new List<Spedizioni>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var shipping = new Spedizioni();

                    shipping.StatoSpedizione = new StatoSpedizioni()
                    {
                        Id = (int)reader["StatoSpedizioneId"],
                        StatoSpedizione = (string)reader["StatoSpedizione"],
                    };

                    shipping.CodiceFiscale = new CodiciFiscali()
                    {
                        Id = (int)reader["ClienteId"],
                        Nome = (string)reader["Nome"],
                        Cognome = (string)reader["Cognome"],
                        CodiceFiscale = (string)reader["CodiceFiscale"],
                        Indirizzo = (string)reader["Indirizzo"],
                        Citta = (string)reader["Citta"],
                    };


                    shipping.SpedizioneId = (int)reader["SpedizioneId"];
                    shipping.ClienteId = (int)reader["ClienteId"];
                    // shipping.PartitaIvaId = (int)reader["PartitaIvaId"];
                    shipping.StatoSpedizioneId = (int)reader["StatoSpedizioneId"];
                    shipping.DataSpedizione = (DateTime)reader["DataSpedizione"];
                    shipping.Peso = Convert.ToDouble(reader["Peso"]);
                    shipping.CostoSpedizione = Convert.ToDouble(reader["CostoSpedizione"]);
                    shipping.DataConsegnaPrevista = (DateTime)reader["DataConsegnaPrevista"];

                    Shippings.Add(shipping);
                }
            }
            return View(Shippings);
        }

        [HttpGet]
        public ActionResult AddShipping()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddShipping([Bind(Exclude = "SpedizioneId")] Spedizioni shipping)
        {
            if (ModelState.IsValid)
            {
                var conn = Commands.ConnectToDb();
                SqlCommand command = new SqlCommand(Queries.AddShipping, conn);
                command.Parameters.AddWithValue("@ClienteId", shipping.ClienteId);
                command.Parameters.AddWithValue("@StatoSpedizioneId", shipping.StatoSpedizioneId);
                command.Parameters.AddWithValue("@DataSpedizione", shipping.DataSpedizione);
                command.Parameters.AddWithValue("@Peso", shipping.Peso);
                command.Parameters.AddWithValue("@CostoSpedizione", shipping.CostoSpedizione);
                command.Parameters.AddWithValue("@DataConsegnaPrevista", shipping.DataConsegnaPrevista);
                command.ExecuteNonQuery();
                conn.Close();
                return RedirectToAction("ShowShippings", "Backoffice");
            }
            return View(shipping);
        }
    }
}