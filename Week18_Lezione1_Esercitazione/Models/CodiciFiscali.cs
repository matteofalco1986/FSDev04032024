using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Week18_Lezione1_Esercitazione.Models
{
    public class CodiciFiscali
    {
        private static int _length = 16;
        public static int Length { get { return _length; } }
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Nome { get; set; }

        [Display(Name = "Cognome")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Cognome { get; set; }

        [Display(Name = "Codice Fiscale")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string CodiceFiscale { get; set; }

        [Display(Name = "Indirizzo e numero civico")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Indirizzo { get; set; }

        [Display(Name = "Citta")]
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Citta { get; set; }

    }
}