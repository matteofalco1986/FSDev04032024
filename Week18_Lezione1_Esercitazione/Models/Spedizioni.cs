using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Week18_Lezione1_Esercitazione.Models
{
    public class Spedizioni
    {
        public int SpedizioniId { get; set; }
        public int? ClienteId { get; set; }
        public int? PartitaIvaId { get; set; }
        public int? StatoSpedizioneId { get; set; }
        public int? DestinazionePrivatoId { get; set; }
        public int? DestinazioneAziendaId { get; set; }
        public DateTime? DataSpedizione {  get; set; }
        public double? Peso {  get; set; }
        public double? CostoSpedizione {  get; set; }
        public CodiciFiscali CodiceFiscale { get; set; }
        public DatiCliente DatiCliente { get; set; }
        public PartiteIva PartitaIva { get; set; }
        public DatiPartitaIva DatiPartitaIva { get; set; }
        public StatoSpedizioni StatoSpedizione { get; set; }
    }
}