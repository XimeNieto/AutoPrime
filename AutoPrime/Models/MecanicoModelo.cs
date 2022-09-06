using System.ComponentModel.DataAnnotations;

namespace AutoPrime.Models
{
    public class MecanicoModelo : EmpleadoModelo
    {
        public int IdMecanico { get; set; }
        [Required(ErrorMessage = "El FKEmpleado es obligatorio")]
        public int FkEmpleado { get; set; }
        [Required(ErrorMessage = "La Dirección es Obligatoria")]
        public string? Direccion{ get; set; }


    }
}
