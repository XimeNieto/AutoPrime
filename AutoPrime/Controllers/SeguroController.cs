using AutoPrime.Datos;
using AutoPrime.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoPrime.Controllers
{
    public class SeguroController : Controller
    {
        SeguroDatos _SeguroDatos = new SeguroDatos();
        public IActionResult Listar()
        {
            //La vista mostrará una lista de personas
            var oLista = _SeguroDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Sólo devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(SeguroModelo oSeguro)
        {
            //Recibe el objeto para guardarlo en la Base de Datos
            if (!ModelState.IsValid)
                return View();

            var respuesta = _SeguroDatos.Guardar(oSeguro);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int IdSeguro)
        {
            var oSeguro = _SeguroDatos.Obtener(IdSeguro);
            return View(oSeguro);
        }

        [HttpPost]
        public IActionResult Editar(SeguroModelo oSeguro)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _SeguroDatos.Editar(oSeguro);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdSeguro)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oSeguro = _SeguroDatos.Obtener(IdSeguro);
            return View(oSeguro);
        }

        [HttpPost]
        public IActionResult Eliminar(SeguroModelo oSeguro)
        {

            var respuesta = _SeguroDatos.Eliminar(oSeguro.IdSeguro);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}