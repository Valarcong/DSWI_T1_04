
using DSWI_T1_04.Dtos;
using DSWI_T1_04.Models;

namespace DSWI_T1_04.Repositories
{
    public interface ClienteRepositoryInterface
    {
        Task<Cliente?> GetClienteById(int id);
        IQueryable<Cliente> getAllClientes();
        Task saveCliente(RegistrarClienteDto dto);
        Task updateCliente(RegistrarClienteDto dto);
    }
}
