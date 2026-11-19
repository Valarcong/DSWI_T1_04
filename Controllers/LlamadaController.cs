
using Microsoft.AspNetCore.Mvc;
using DSWI_T1_04.Models;

namespace DSWI_T1_04.Controllers
{
    public class LlamadaController : Controller
    {
        // Mostrar el formulario
        public IActionResult Index()
        {
            return View(new Llamada());
        }

        // Recibir los datos y calcular
        [HttpPost]
        public IActionResult Index(Llamada modelo)
        {
            if (modelo.Minutos <= 0)
            {
                ModelState.AddModelError(
                    "Minutos",
                    "Ingrese una cantidad de minutos mayor que cero."
                );

                return View(modelo);
            }

            decimal total = modelo.CalcularTotal();

            ViewBag.Total = total;

            return View(modelo);
        }
    }
}

