using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OverlookHotelGestionale.Models
{
    public class Prenotazione
    {

        [Key]
        public int IdPrenotazione { get; set; }

        [Required(ErrorMessage = "Codice fiscale obbligatorio")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Il codice fiscale inserito non è valido")]
        public string CodiceFiscale { get; set; }

        [Required(ErrorMessage = "Cognome cliente obbligatorio")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Il cognome inserito non è valido, MAX 20 caratteri")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "Nome cliente obbligatorio")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Il nome inserito non è valido, MAX 20 caratteri")]
        public string Nome { get; set; }

        [StringLength(20, MinimumLength = 1, ErrorMessage = "La città inserita non è valida, MAX 20 caratteri")]
        public string Citta { get; set; }

        [StringLength(20, MinimumLength = 1, ErrorMessage = "Il provincia inserita non è valida, MAX 20 caratteri")]
        public string Provincia { get; set; }

        [StringLength(25, MinimumLength = 1, ErrorMessage = "La mail inserita è troppo lunga, MAX 25 caratteri")]
        [EmailAddress(ErrorMessage = "E-mail inserita non valida")]
        public string Email { get; set; }
        public int Telefono { get; set; }

        [Required(ErrorMessage = "Cellulare cliente obbligatorio")]
        public int Cellulare { get; set; }

        [Required(ErrorMessage = "Identificativo camera obbligatorio")]
        public int IdCamera { get; set; }

        [Required(ErrorMessage = "Data prenotazione obbligatoria")]
        public DateTime DataPrenotazione { get; set; }

        [Required(ErrorMessage = "Data inizio soggiorno obbligatoria")]
        public DateTime InizioPeriodoSoggiorno { get; set; }

        [Required(ErrorMessage = "Data fine soggiorno obbligatoria")]
        public DateTime FinePeriodoSoggiorno { get; set; }

        [Required(ErrorMessage = "Anno prenotazione obbligatorio")]
        public int Anno { get; set; }

        [Required(ErrorMessage = "Caparra prenotazione obbligatoria")]
        public decimal Caparra { get; set; }

        [Required(ErrorMessage = "Tariffa prenotazione obbligatoria")]
        public decimal Tariffa { get; set; }

        [Required(ErrorMessage = "Tipo soggiorno obbligatorio")]
        public string TipoDiSoggiorno { get; set; }
    }
}