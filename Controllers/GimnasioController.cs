using DSWI_T1_04.Dtos;
using DSWI_T1_04.Services;
using DSWI_T1_04.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DSWI_T1_04.Controllers
{
    public class GimnasioController : Controller
    {
        private readonly GimnasioService _gimnasioService;

        public GimnasioController(GimnasioService gimnasioService)
        {
            _gimnasioService = gimnasioService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new GimnasioViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind(Prefix = "Datos")] GimnasioDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(new GimnasioViewModel { Datos = dto });
            }

            var resultado = _gimnasioService.CalcularMembresia(dto);
            return View(resultado);
        }
    }
}
