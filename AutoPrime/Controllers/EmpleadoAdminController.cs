using AutoPrime.Datos;
using AutoPrime.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoPrime.Controllers
{
    public class EmpleadoAdminController : Controller
    {
        EmpleadoAdminDatos _EmpleadoAdminDatos = new EmpleadoAdminDatos();
        public IActionResult Listar()
        {
            //La vista mostrará una lista de personas
            var oLista = _EmpleadoAdminDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Sólo devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(EmpleadoAdminModelo oEmpleadoAdmin)
        {
            //Recibe el objeto para guardarlo en la Base de Datos
            if (!ModelState.IsValid)
                return View();

            var respuesta = _EmpleadoAdminDatos.Guardar(oEmpleadoAdmin);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int IdAdministrativo)
        {
            var oEmpleadoAdmin = _EmpleadoAdminDatos.Obtener(IdAdministrativo);
            return View(oEmpleadoAdmin);
        }

        [HttpPost]
        public IActionResult Editar(EmpleadoAdminModelo oEmpleadoAdmin)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _EmpleadoAdminDatos.Editar(oEmpleadoAdmin);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdAdministrativo)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oEmpleadoAdmin = _EmpleadoAdminDatos.Obtener(IdAdministrativo);
            return View(oEmpleadoAdmin);
        }

        [HttpPost]
        public IActionResult Eliminar(EmpleadoAdminModelo oEmpleadoAdmin)
        {

            var respuesta = _EmpleadoAdminDatos.Eliminar(oEmpleadoAdmin.IdAdministrativo);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}