using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Week18_Lezione1_Esercitazione.Models
{
    public class Spedizioni
    {
        [Key]
        public int SpedizioneId { get; set; }
        public int? ClienteId { get; set; }
        public int? PartitaIvaId { get; set; }
        public int? StatoSpedizioneId { get; set; }
        public DateTime? DataSpedizione {  get; set; }
        public double? Peso {  get; set; }
        public double? CostoSpedizione {  get; set; }
        public DateTime? DataConsegnaPrevista { get; set; }

        public CodiciFiscali CodiceFiscale { get; set; }
        // public PartiteIva PartitaIva { get; set; }
        public StatoSpedizioni StatoSpedizione { get; set; }
    }
}