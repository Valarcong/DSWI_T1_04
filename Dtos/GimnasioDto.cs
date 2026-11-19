using System.ComponentModel.DataAnnotations;

namespace DSWI_T1_04.Dtos
{
    public class GimnasioDto
    {
        [Required(ErrorMessage = "Ingrese la edad del cliente.")]
        [Range(0, int.MaxValue, ErrorMessage = "La edad debe ser un número entero mayor o igual a 0.")]
        public int? Edad { get; set; }

        [Required(ErrorMessage = "Ingrese los meses contratados.")]
        [Range(1, int.MaxValue, ErrorMessage = "Los meses deben ser un número entero mayor a 0.")]
        public int? Meses { get; set; }
    }
}
