using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OverlookHotelGestionale.Models
{
    public class Camera
    {
        [Key]
        public int IdCamera { get; set; }

        [Required(ErrorMessage = "Numero camera obbligatorio")]
        public int NumeroCamera { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "La descrizione inserita è troppo lunga, max 50 caratteri")]
        public string Descrizione { get; set; }

        [Required(ErrorMessage = "Tipologia camera obbligatoria")]
        public string Tipologia { get; set; }
    }
}