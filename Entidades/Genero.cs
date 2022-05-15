using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Validaciones;

namespace Back_end.Entidades
{
    public class Genero: IValidatableObject
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength:10)]
       // [PrimeraLetraMayuscula]
        public String Nombre { get; set; }

        [Range(18,120)]
        public int Edad { get; set; }
        [CreditCard]
        public String TarjetaDeCredito { get; set; }
        [Url]
        public String URL { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Nombre))
            {
                var primeraLetra = Nombre[0].ToString();
                if (primeraLetra != primeraLetra.ToUpper())
                {
                    yield return new ValidationResult("La primera letra debe se mayúscula", 
                        new string[]{nameof(Nombre)});
                }
            }
        }
    }
}
