using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Week18_Lezione1_Esercitazione.Models
{
    public static class Queries
    {
        public static string AdminData = "SELECT * FROM AdminData where Username = @username AND Password = @password";
        public static string RegisterUser = "INSERT INTO AdminData(Username, Password) VALUES (@username, @password)";
        public static string CustomersList = "SELECT * FROM CodiciFiscali";
        public static string PartiteIvaList = "SELECT * FROM PartiteIva";
        public static string AddCustomer = "INSERT INTO CodiciFiscali (Nome, Cognome, CodiceFiscale, Indirizzo, Citta) VALUES (@Nome, @Cognome, @CodiceFiscale, @Indirizzo, @Citta)";
        public static string GetCustomerData = "SELECT * FROM CodiciFiscali WHERE Id = @Id";
        public static string CustomerDataUpdate = @"UPDATE CodiciFiscali
                                                    SET Nome = @Nome, Cognome = @Cognome, CodiceFiscale = @CodiceFiscale, Indirizzo = @Indirizzo, Citta =                  Citta
                                                    WHERE Id = @Id";
        public static string ShippingsList = @"SELECT * 
                                                FROM Spedizioni as Spedizioni
                                                JOIN CodiciFiscali as Clienti
                                                ON Spedizioni.ClienteId = Clienti.Id
                                                JOIN StatoSpedizioni as Stato
                                                ON Spedizioni.StatoSpedizioneId = Stato.Id";

    }
}