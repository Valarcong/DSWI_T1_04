
using DSWI_T1_04.Dtos;
using DSWI_T1_04.Models;

namespace DSWI_T1_04.Services
{
    public interface ClienteServiceInterface
    {
        Task<RegistrarClienteDto?> getClienteById(int id);
        Task<List<Cliente>> getClientes();
        Task saveCliente(RegistrarClienteDto dto);
        Task updateCliente(RegistrarClienteDto dto);
    }
}
