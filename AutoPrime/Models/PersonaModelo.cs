using System.ComponentModel.DataAnnotations;

namespace AutoPrime.Models
{
    public class PersonaModelo
    {
        public int IdPersona { get; set; }
        [Required(ErrorMessage = "La Identificación es obligatoria")]
        public string? Identificacion { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string? Nombres { get; set; }
        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string? Apellidos { get; set; }
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateTime? FechaNacimiento { get; set; }

    }
}
