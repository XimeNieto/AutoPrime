using System.ComponentModel.DataAnnotations;

namespace AutoPrime.Models
{
    public class VehiculoModelo
    {
        public int IdVehiculo { get; set; }
        [Required(ErrorMessage = "El Id del dueño es obligatorio")]
        public int FkDueno { get; set; }
        [Required(ErrorMessage = "El Id del Seguro obligatorio")]
        public int FkSeguro { get; set; }
        [Required(ErrorMessage = "La Placa es obligatoria")]
        public string? Placa { get; set; }
        [Required(ErrorMessage = "El tipo es obligatorio")]
        public string? Tipo { get; set; }
        [Required(ErrorMessage = "La Marca es obligatoria")]
        public string? Marca { get; set; }
        [Required(ErrorMessage = "El Modelo es obligatorio")]
        public string? Modelo { get; set; }
        [Required(ErrorMessage = "La Capacidad es obligatoria")]
        public string? Capacidad { get; set; }
        [Required(ErrorMessage = "El Cilindraje es obligatorio")]
        public string? Cilindraje { get; set; }
        [Required(ErrorMessage = "La Ciudad  es obligatoria")]
        public string? CiudadOrigen { get; set; }
        [Required(ErrorMessage = "La Descripción es obligatoria")]
        public string? Descripcion { get; set; }
  

    }
}
