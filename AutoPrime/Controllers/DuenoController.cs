using AutoPrime.Datos;
using AutoPrime.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoPrime.Controllers
{
    public class DuenoController : Controller
    {
        DuenoDatos _DuenoDatos = new DuenoDatos();
        public IActionResult Listar()
        {
            //La vista mostrará una lista de personas
            var oLista = _DuenoDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Sólo devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(DuenoModelo oDueno)
        {
            //Recibe el objeto para guardarlo en la Base de Datos
            if (!ModelState.IsValid)
                return View();

            var respuesta = _DuenoDatos.Guardar(oDueno);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int IdDueno)
        {
            var oDueno = _DuenoDatos.Obtener(IdDueno);
            return View(oDueno);
        }

        [HttpPost]
        public IActionResult Editar(DuenoModelo oDueno)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _DuenoDatos.Editar(oDueno);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdDueno)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oDueno = _DuenoDatos.Obtener(IdDueno);
            return View(oDueno);
        }

        [HttpPost]
        public IActionResult Eliminar(DuenoModelo oDueno)
        {

            var respuesta = _DuenoDatos.Eliminar(oDueno.IdDueno);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}