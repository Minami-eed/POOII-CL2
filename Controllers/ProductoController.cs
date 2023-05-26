using Microsoft.AspNetCore.Mvc;
using POOII_CL2_QUISPE_EDSON.Models;
using System.Diagnostics;

namespace POOII_CL2_QUISPE_EDSON.Controllers
{
    public class ProductoController : Controller
    {
        // ADD DB 
        BDProducto bdp = new BDProducto();
        List<Producto> listaProductosPaginados;

        // INDEX
        public IActionResult Inicio()
        {
            return View();
        }

        // LISTAR
        public IActionResult Listado()
        {
            // Muestra la lista de Productos de la DB
            List<Producto> listaProductos = bdp.ObtenerTodos();
            return View(listaProductos);
        }

        // BUSCAR
        public IActionResult Buscar()
        {
            return View();
        }

        // BUSCAR POR AÑO
        public IActionResult BuscarPorAño(int año)
        {
            List<Producto> listaProductos = bdp.ProductosPorAño(año);
            ViewBag.AñoIngresado = año;
            ViewBag.mensaje = "Productos encontrados";
            ViewBag.alerta = "No se encontraron productos para el año especificado.";
            return View("BuscarPorAño", listaProductos);
        }


        // CREAR
        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(string Nombre, int idTipo, decimal Precio, DateTime fecha)
        {
            string fechaFormateada = fecha.ToString("yyyy-MM-dd");

            int nroRegistros = bdp.Crear(Nombre, idTipo, Precio, fecha);
            ViewBag.mensaje = "Producto creado correctamente";
            ViewBag.fechaFormateada = fechaFormateada;

            return View();
        }

        // ACTUALIZAR
        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            Producto producto = bdp.ObtenerProductoPorId(id);
            if (producto != null)
            {
                return View(producto);
            }
            else
            {
                return RedirectToAction("Listado");
            }
        }

        [HttpPost]
        public ActionResult Actualizar(Producto productoActualizado)
        {
            if (ModelState.IsValid)
            {
                Producto productoExistente = bdp.ObtenerProductoPorId(productoActualizado.Id);
                if (productoExistente != null)
                {
                    productoExistente.Nombre = productoActualizado.Nombre;
                    productoExistente.IdTipo = productoActualizado.IdTipo;
                    productoExistente.Precio = productoActualizado.Precio;
                    productoExistente.Fecha = productoActualizado.Fecha.Date;

                    bdp.Actualizar(productoExistente);
                    ViewBag.mensaje = "Producto actualizado correctamente";
                    return RedirectToAction("Listado");
                }
                else
                {
                    return RedirectToAction("Listado");
                }
            }
            else
            {
                return View(productoActualizado);
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
