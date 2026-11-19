
using DSWI_T1_04.Dtos;
using DSWI_T1_04.Models;

namespace DSWI_T1_04.Services
{
    public interface PedidoServiceInterface
    {
        Task<RegistrarPedidoDto?> getPedidoById(int id);
        Task<List<Pedido>> getPedidos();
        Task savePedido(RegistrarPedidoDto dto);
        Task updatePedido(RegistrarPedidoDto dto);
    }
}
