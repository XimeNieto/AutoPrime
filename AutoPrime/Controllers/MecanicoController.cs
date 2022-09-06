using AutoPrime.Datos;
using AutoPrime.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoPrime.Controllers
{
    public class MecanicoController : Controller
    {
        MecanicoDatos _MecanicoDatos = new MecanicoDatos();
        public IActionResult Listar()
        {
            //La vista mostrará una lista de personas
            var oLista = _MecanicoDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Sólo devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(MecanicoModelo oMecanico)
        {
            //Recibe el objeto para guardarlo en la Base de Datos
            if (!ModelState.IsValid)
                return View();

            var respuesta = _MecanicoDatos.Guardar(oMecanico);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int IdMecanico)
        {
            var oMecanico = _MecanicoDatos.Obtener(IdMecanico);
            return View(oMecanico);
        }

        [HttpPost]
        public IActionResult Editar(MecanicoModelo oMecanico)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _MecanicoDatos.Editar(oMecanico);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdMecanico)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oMecanico = _MecanicoDatos.Obtener(IdMecanico);
            return View(oMecanico);
        }

        [HttpPost]
        public IActionResult Eliminar(MecanicoModelo oMecanico)
        {

            var respuesta = _MecanicoDatos.Eliminar(oMecanico.IdMecanico);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}