
using DSWI_T1_04.Dtos;
using DSWI_T1_04.Models;

namespace DSWI_T1_04.Repositories
{
    public interface PedidoRepositoryInterface
    {
        Task<Pedido?> GetPedidoById(int id);
        IQueryable<Pedido> getAllPedidos();
        Task savePedido(RegistrarPedidoDto dto);
        Task updatePedido(RegistrarPedidoDto dto);
    }
}
