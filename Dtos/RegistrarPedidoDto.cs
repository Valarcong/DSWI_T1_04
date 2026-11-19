namespace DSWI_T1_04.Dtos
{
    public class RegistrarPedidoDto
    {

        public int pedidoid { get; set; }
        public DateOnly fechapedido { get; set; }
        public decimal monto { get; set; }
        public string estado { get; set; } = string.Empty;
        public int clienteid { get; set; }

    }
}
