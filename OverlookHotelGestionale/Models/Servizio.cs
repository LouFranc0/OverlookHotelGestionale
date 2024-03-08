using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OverlookHotelGestionale.Models
{
    public class Servizio
    {
        [Key]
        public int IdServizio { get; set; }

        [Required(ErrorMessage = "Tipo servizio obbligatorio")]
        public string TipoServizio { get; set; }

        [Required(ErrorMessage = "Data servizio obbligatoria")]
        public DateTime DataDelServizio { get; set; }

        [Required(ErrorMessage = "Quantità obbligatoria")]
        public int Quantita { get; set; }

        [Required(ErrorMessage = "Prezzo servizio obbligatorio")]
        public decimal Prezzo { get; set; }

        [Required(ErrorMessage = "Identificativo prenotazione obbligatorio")]
        public int IdPrenotazione { get; set; }
    }
}