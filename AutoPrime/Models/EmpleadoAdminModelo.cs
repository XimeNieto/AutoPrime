using System.ComponentModel.DataAnnotations;

namespace AutoPrime.Models
{
    public class EmpleadoAdminModelo : EmpleadoModelo
    {
        public int IdAdministrativo { get; set; }
        [Required(ErrorMessage = "FkEmpleado es Obligatoria")]
        public int FkEmpleado { get; set; }
        [Required(ErrorMessage = "El Cargo es obligatorio")]
        public string? Cargo { get; set; }
    }
}
