
namespace DSWI_T1_04.Models
{
    public class Llamada
    {
        // Propiedad para ingresar los minutos
        public int Minutos { get; set; }

        // Método para calcular el costo de la llamada
        public decimal CalcularTotal()
        {
            decimal total;

            if (Minutos <= 5)
            {
                total = 10;
            }
            else
            {
                total = 10 + (Minutos - 5) * 2;
            }

            return total;
        }
    }
}
