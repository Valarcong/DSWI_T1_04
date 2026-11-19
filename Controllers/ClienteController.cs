
using DSWI_T1_04.Dtos;
using DSWI_T1_04.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_T1_04.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteServiceInterface _clienteService;

        public ClienteController(ClienteServiceInterface clienteService)
        {
            _clienteService = clienteService;
        }


        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteService.getClientes();
            return View(clientes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new RegistrarClienteDto());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _clienteService.getClienteById(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegistrarClienteDto dto)
        {
            if (ModelState.IsValid)
            {
                await _clienteService.saveCliente(dto);
                return RedirectToAction("Index");
            }

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegistrarClienteDto dto)
        {
            if (ModelState.IsValid)
            {
                await _clienteService.updateCliente(dto);
                return RedirectToAction("Index");
            }

            return View(dto);
        }
    }
}
