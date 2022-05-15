using System.ComponentModel.DataAnnotations;
using Back_end.Validaciones;

namespace Back_end.DTOs
{
    public class GeneroDTO
    {
        public int id { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength:50)]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
    }
}