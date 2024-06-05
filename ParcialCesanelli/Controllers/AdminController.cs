using Microsoft.AspNetCore.Mvc;
using ParcialCesanelli.Datos;
using ParcialCesanelli.Models;

namespace ParcialCesanelli.Controllers
{
    public class AdminController : Controller
    {
        SucursalDatos _SucursalDatos = new SucursalDatos();

        public IActionResult Listar()
        {
            var oLista = _SucursalDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(SucursalModel oSucursal)
        {
            if (!ModelState.IsValid)
                return View();
            var respuesta = _SucursalDatos.Guardar(oSucursal);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int IdSucursal)
        {
            var oSucursal = _SucursalDatos.Obtener(IdSucursal);
            return View(oSucursal);
        }

        [HttpPost]
        public IActionResult Editar(SucursalModel oSucursal)
        {
            if (!ModelState.IsValid)
                return View(oSucursal);
            var respuesta = _SucursalDatos.Editar(oSucursal);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View(oSucursal);
        }

        public IActionResult Eliminar(int IdSucursal)
        {
            var oSucursal = _SucursalDatos.Obtener(IdSucursal);
            return View(oSucursal);
        }

        [HttpPost]
        public IActionResult Eliminar(SucursalModel oSucursal)
        {
            var respuesta = _SucursalDatos.Eliminar(oSucursal.IdSucursal);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}

