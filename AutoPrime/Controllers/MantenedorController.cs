using AutoPrime.Datos;
using AutoPrime.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoPrime.Controllers
{
    public class MantenedorController : Controller
    {
        PersonaDatos _PersonaDatos = new PersonaDatos();
        public IActionResult Listar()
        {
            //La vista mostrará una lista de personas
            var oLista = _PersonaDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Sólo devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(PersonaModelo oPersona)
        {
            //Recibe el objeto para guardarlo en la Base de Datos
            if (!ModelState.IsValid)
                return View();

            var respuesta = _PersonaDatos.Guardar(oPersona);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int IdPersona)
        {
            var oPersona = _PersonaDatos.Obtener(IdPersona);
            return View(oPersona);
        }

        [HttpPost]
        public IActionResult Editar(PersonaModelo oPersona)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _PersonaDatos.Editar(oPersona);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdPersona)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ocontacto = _PersonaDatos.Obtener(IdPersona);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Eliminar(PersonaModelo oPersona)
        {

            var respuesta = _PersonaDatos.Eliminar(oPersona.IdPersona);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}

