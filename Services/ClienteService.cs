
using DSWI_T1_04.Dtos;
using DSWI_T1_04.Models;
using DSWI_T1_04.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_04.Services
{
    public class ClienteService : ClienteServiceInterface
    {
        private readonly ClienteRepositoryInterface _clienteRepository;

        public ClienteService(ClienteRepositoryInterface clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task saveCliente(RegistrarClienteDto dto)
        {
            await _clienteRepository.saveCliente(dto);
        }

        public async Task updateCliente(RegistrarClienteDto dto)
        {
            await _clienteRepository.updateCliente(dto);
        }

        public async Task<RegistrarClienteDto?> getClienteById(int id)
        {
            Cliente? cliente = await _clienteRepository.GetClienteById(id);

            if (cliente == null)
            {
                return null;
            }

            RegistrarClienteDto dto = new RegistrarClienteDto();
            dto.clienteid = cliente.ClienteId;
            dto.nombre = cliente.Nombre;
            dto.correoelectronico = cliente.CorreoElectronico;

            return dto;
        }

        public async Task<List<Cliente>> getClientes()
        {
            return await _clienteRepository.getAllClientes()
                .ToListAsync();
        }
    }
}
