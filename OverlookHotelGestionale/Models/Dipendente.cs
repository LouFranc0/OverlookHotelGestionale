using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OverlookHotelGestionale.Models
{
    public class Dipendente
    {
        [Key]
        public int IdDipendente { get; set; }

        [Required(ErrorMessage = "Username obbligatorio")]
        [StringLength(30, ErrorMessage = "Il nome utente deve essere di massimo 30 caratteri")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password obbligatoria")]
        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "Il nome utente deve essere di massimo 30 caratteri")]
        public string Password { get; set; }
    }
}