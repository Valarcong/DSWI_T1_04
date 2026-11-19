
using DSWI_T1_04.Data;
using DSWI_T1_04.Dtos;
using DSWI_T1_04.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_04.Repositories
{
    public class ClienteRepository : ClienteRepositoryInterface
    {
        private readonly AppDbContext _dbContext;

        public ClienteRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // LINQ
        public async Task<Cliente?> GetClienteById(int id)
        {
            return await _dbContext.Clientes.FindAsync(id);
        }

        public IQueryable<Cliente> getAllClientes()
        {
            return _dbContext.Clientes
                .FromSqlRaw("EXEC ListarClientes")
                .AsNoTracking();
        }

        public async Task saveCliente(RegistrarClienteDto dto)
        {
            var parametros = new[]
            {
                new SqlParameter("@Nombre", dto.nombre),
                new SqlParameter("@CorreoElectronico", dto.correoelectronico)
            };

            await _dbContext.Database.ExecuteSqlRawAsync(
                "EXEC RegistrarCliente @Nombre, @CorreoElectronico",
                parametros);
        }

        public async Task updateCliente(RegistrarClienteDto dto)
        {
            var parametros = new[]
            {
                new SqlParameter("@ClienteID", dto.clienteid),
                new SqlParameter("@Nombre", dto.nombre),
                new SqlParameter("@CorreoElectronico", dto.correoelectronico)
            };

            await _dbContext.Database.ExecuteSqlRawAsync(
                "EXEC ActualizarCliente @ClienteID, @Nombre, @CorreoElectronico",
                parametros);
        }
    }
}
