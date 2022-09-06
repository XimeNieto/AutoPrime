using AutoPrime.Datos;
using AutoPrime.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoPrime.Controllers
{
    public class VehiculoController : Controller
    {

        VehiculoDatos _VehiculoDatos = new VehiculoDatos();
        public IActionResult Listar()
        {
            //La vista mostrará una lista de personas
            var oLista = _VehiculoDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Sólo devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(VehiculoModelo oVehiculo)
        {
            List<SelectListItem> Propietarios = new()
            {
                new SelectListItem { Value = "1", Text = "Victor Quintero" },
                new SelectListItem { Value = "2", Text = "Alejandro Rincón" },
                new SelectListItem { Value = "3", Text = "Carlos Slim" }
            };

            //assigning SelectListItem to view Bag
            ViewBag.Propietarios = Propietarios;

            //Recibe el objeto para guardarlo en la Base de Datos
            if (!ModelState.IsValid)
                return View();

            var respuesta = _VehiculoDatos.Guardar(oVehiculo);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int IdVehiculo)
        {
            var oVehiculo = _VehiculoDatos.Obtener(IdVehiculo);
            return View(oVehiculo);
        }

        [HttpPost]
        public IActionResult Editar(VehiculoModelo oVehiculo)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _VehiculoDatos.Editar(oVehiculo);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdVehiculo)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oVehiculo = _VehiculoDatos.Obtener(IdVehiculo);
            return View(oVehiculo);
        }

        [HttpPost]
        public IActionResult Eliminar(VehiculoModelo oVehiculo)
        {

            var respuesta = _VehiculoDatos.Eliminar(oVehiculo.IdVehiculo);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        [HttpPost]
        public IActionResult Buscar(string Placa)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oVehiculo = _VehiculoDatos.Buscar(Placa);
            return View(oVehiculo);
        }

        /*
        public IActionResult Buscar(VehiculoModelo oVehiculo)
        {

            var respuesta = _VehiculoDatos.Buscar(oVehiculo.Placa);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }*/

    }
}