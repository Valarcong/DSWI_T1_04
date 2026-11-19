
using DSWI_T1_04.Data;
using DSWI_T1_04.Dtos;
using DSWI_T1_04.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_04.Repositories
{
    public class PedidoRepository : PedidoRepositoryInterface
    {
        private readonly AppDbContext _dbContext;

        public PedidoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // LINQ
        public async Task<Pedido?> GetPedidoById(int id)
        {
            return await _dbContext.Pedidos.FindAsync(id);
        }

        public IQueryable<Pedido> getAllPedidos()
        {
            return _dbContext.Pedidos
                .FromSqlRaw("EXEC ListarPedidos")
                .AsNoTracking();
        }

        public async Task savePedido(RegistrarPedidoDto dto)
        {
            var parametros = new[]
            {
                new SqlParameter("@FechaPedido", dto.fechapedido.ToDateTime(TimeOnly.MinValue)),
                new SqlParameter("@Monto", dto.monto),
                new SqlParameter("@Estado", dto.estado),
                new SqlParameter("@ClienteID", dto.clienteid)
            };

            await _dbContext.Database.ExecuteSqlRawAsync(
                "EXEC RegistrarPedido @FechaPedido, @Monto, @Estado, @ClienteID",
                parametros);
        }

        public async Task updatePedido(RegistrarPedidoDto dto)
        {
            var parametros = new[]
            {
                new SqlParameter("@PedidoID", dto.pedidoid),
                new SqlParameter("@FechaPedido", dto.fechapedido.ToDateTime(TimeOnly.MinValue)),
                new SqlParameter("@Monto", dto.monto),
                new SqlParameter("@Estado", dto.estado),
                new SqlParameter("@ClienteID", dto.clienteid)
            };

            await _dbContext.Database.ExecuteSqlRawAsync(
                "EXEC ActualizarPedido @PedidoID, @FechaPedido, @Monto, @Estado, @ClienteID",
                parametros);
        }
    }
}
