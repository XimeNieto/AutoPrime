using System.ComponentModel.DataAnnotations;

namespace AutoPrime.Models
{
    public class DuenoModelo : PersonaModelo
    {
        public int IdDueno { get; set; }
        [Required(ErrorMessage = "La Identificación es obligatoria")]
        public string? Ciudad { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "El apellido es obligatorio")]
        public int FkPersona { get; set; }

    }
}
