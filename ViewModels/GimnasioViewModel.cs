using DSWI_T1_04.Dtos;

namespace DSWI_T1_04.ViewModels
{
    public class GimnasioViewModel
    {
        public GimnasioDto Datos { get; set; } = new GimnasioDto();
        public decimal TarifaBase { get; set; }
        public decimal Subtotal { get; set; }
        public decimal PorcentajeDescuento { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public bool Calculado { get; set; }
    }
}
