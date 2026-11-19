
using DSWI_T1_04.Dtos;
using DSWI_T1_04.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_T1_04.Controllers
{
    public class PedidoController : Controller
    {

        private readonly PedidoServiceInterface _pedidoService;
        private readonly ClienteServiceInterface _clienteService;

        public PedidoController(
            PedidoServiceInterface pedidoService,
            ClienteServiceInterface clienteService)
        {
            _pedidoService = pedidoService;
            _clienteService = clienteService;
        }


        public async Task<IActionResult> Index()
        {
            var pedidos = await _pedidoService.getPedidos();
            return View(pedidos);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Clientes = await _clienteService.getClientes();
            return View(new RegistrarPedidoDto());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var pedido = await _pedidoService.getPedidoById(id);

            if (pedido == null)
            {
                return NotFound();
            }

            ViewBag.Clientes = await _clienteService.getClientes();
            return View(pedido);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegistrarPedidoDto dto)
        {
            if (ModelState.IsValid)
            {
                await _pedidoService.savePedido(dto);
                return RedirectToAction("Index");
            }

            ViewBag.Clientes = await _clienteService.getClientes();
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegistrarPedidoDto dto)
        {
            if (ModelState.IsValid)
            {
                await _pedidoService.updatePedido(dto);
                return RedirectToAction("Index");
            }

            ViewBag.Clientes = await _clienteService.getClientes();
            return View(dto);
        }
    }
}
