using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace Week18_Lezione1_Esercitazione.Models
{
    public class DatiCliente
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string IndirizzoDestinatario {  get; set; }
        public string CittaDestinataria { get; set; }
        public DatiCliente DatiDelCliente { get; set; }
    }
}