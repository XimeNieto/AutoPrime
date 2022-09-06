using System.ComponentModel.DataAnnotations;

namespace AutoPrime.Models
{
    public class SeguroModelo
    {
        public int IdSeguro {get; set; }
        [Required(ErrorMessage = "La Identificación es obligatoria")]
        public int FkDueno { get; set; }
        [Required(ErrorMessage = "La fecha de Inicio es obligatoria")]
        public DateTime? FechaInicio { get; set; }
        [Required(ErrorMessage = "La fecha de Final es obligatoria")]
        public DateTime? FechaFinal { get; set; }
        [Required(ErrorMessage = "El número de póliza es obligatorio")]
        public string? PolizaNumero { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string? Tipo { get; set; }
    }
}
