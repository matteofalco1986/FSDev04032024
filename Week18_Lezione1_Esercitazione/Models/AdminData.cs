using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Week18_Lezione1_Esercitazione.Models
{
    public class AdminData
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Min 3, max 20 caratteri")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Campo obbligatorio")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Min 6, max 20 caratteri")]
        public string Password { get; set; }
    }
}