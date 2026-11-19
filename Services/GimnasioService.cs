using DSWI_T1_04.Dtos;
using DSWI_T1_04.ViewModels;

namespace DSWI_T1_04.Services
{
    public class GimnasioService
    {
        public GimnasioViewModel CalcularMembresia(GimnasioDto dto)
        {
            decimal tarifaBase;
            if (dto.Edad < 18)
            {
                tarifaBase = 20m;
            }
            else if (dto.Edad < 60)
            {
                tarifaBase = 35m;
            }
            else
            {
                tarifaBase = 25m;
            }

            decimal porcentajeDescuento = 0m;
            if (dto.Meses == 3)
            {
                porcentajeDescuento = 5m;
            }
            else if (dto.Meses == 6)
            {
                porcentajeDescuento = 10m;
            }
            else if (dto.Meses == 12)
            {
                porcentajeDescuento = 20m;
            }

            decimal subtotal = tarifaBase * dto.Meses!.Value;
            decimal descuento = subtotal * porcentajeDescuento / 100m;

            return new GimnasioViewModel
            {
                Datos = dto,
                TarifaBase = tarifaBase,
                Subtotal = subtotal,
                PorcentajeDescuento = porcentajeDescuento,
                Descuento = descuento,
                Total = subtotal - descuento,
                Calculado = true
            };
        }
    }
}
