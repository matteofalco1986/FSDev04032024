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

        [Display(Name = "Id Cliente")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        [DataType(DataType.Text)]
        [Range(1, 100000, ErrorMessage = "Il valore deve essere maggiore di 1")]
        public int ClienteId { get; set; }
        public int? PartitaIvaId { get; set; }

        [Display(Name = "Stato Spedizione")]
        [Required(ErrorMessage = "Campo obbligatorio")]

        public int StatoSpedizioneId { get; set; }

        [Display(Name = "Data di spedizione")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        [DataType(DataType.DateTime)]
        public DateTime DataSpedizione {  get; set; }

        [Display(Name = "Peso in Kg")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        [DataType(DataType.Text)]
        [Range(0, 100000, ErrorMessage = "Il valore deve essere maggiore di 0")]

        public double Peso {  get; set; }

        [Display(Name = "Costo")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        [DataType(DataType.Text)]
        [Range(0, 100000, ErrorMessage = "Il valore deve essere maggiore di 0")]
        public double CostoSpedizione {  get; set; }

        [Display(Name = "Data di consegna prevista")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        [DataType(DataType.DateTime)]
        public DateTime DataConsegnaPrevista { get; set; }

        public CodiciFiscali CodiceFiscale { get; set; }
        // public PartiteIva PartitaIva { get; set; }
        public StatoSpedizioni StatoSpedizione { get; set; }
    }
}