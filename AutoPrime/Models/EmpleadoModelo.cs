using System.ComponentModel.DataAnnotations;

namespace AutoPrime.Models
{
    public class EmpleadoModelo : PersonaModelo
    {
        public int IdEmpleado { get; set; }
        [Required(ErrorMessage = "El Teléfono es obligatorio")]
        public string? Telefono{ get; set; }
        [Required(ErrorMessage = "El Nivel de estudio es obligatorio")]
        public string? NivelEstudio { get; set; }
        [Required(ErrorMessage = "El mail es obligatorio")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "El FkPersona es obligatorio")]
        public int FkPersona { get; set; }
    }
}
