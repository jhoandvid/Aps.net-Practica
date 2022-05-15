using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Validaciones;

namespace Back_end.Entidades
{
    public class Genero
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength:50)]
        [PrimeraLetraMayuscula]
        public String Nombre { get; set; }


        
    }
}
