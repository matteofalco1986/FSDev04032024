using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Week18_Lezione1_Esercitazione.Models
{
    public class DatiPartitaIva
    {
        [Key]

        public int Id { get; set; }
        public int PartitaIvaId { get; set; }
        public string IndirizzoDestinatario { get; set; }
        public string CittaDestinataria { get; set; }
        public PartiteIva PartitaIva { get; set; }
    }
}