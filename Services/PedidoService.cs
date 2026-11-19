
using DSWI_T1_04.Dtos;
using DSWI_T1_04.Models;
using DSWI_T1_04.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_04.Services
{
    public class PedidoService : PedidoServiceInterface
    {
        private readonly PedidoRepositoryInterface _pedidoRepository;

        public PedidoService(PedidoRepositoryInterface pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }


        public async Task savePedido(RegistrarPedidoDto dto)
        {
            await _pedidoRepository.savePedido(dto);
        }

        public async Task updatePedido(RegistrarPedidoDto dto)
        {
            await _pedidoRepository.updatePedido(dto);
        }

        public async Task<RegistrarPedidoDto?> getPedidoById(int id)
        {
            Pedido? pedido = await _pedidoRepository.GetPedidoById(id);

            if (pedido == null)
            {
                return null;
            }

            RegistrarPedidoDto dto = new RegistrarPedidoDto();
            dto.pedidoid = pedido.PedidoId;
            dto.fechapedido = pedido.FechaPedido;
            dto.monto = pedido.Monto;
            dto.estado = pedido.Estado;
            dto.clienteid = pedido.ClienteId;

            return dto;
        }

        public async Task<List<Pedido>> getPedidos()
        {
            return await _pedidoRepository.getAllPedidos()
                .ToListAsync();
        }
    }
}
