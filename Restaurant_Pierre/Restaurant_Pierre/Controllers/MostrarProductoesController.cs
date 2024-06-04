using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant_Pierre.Models;
using Restaurant_Pierre.Services;

namespace Restaurant_Pierre.Controllers
{
    public class MostrarProductoesController : Controller
    {
        //private readonly ProductoService _productoService;
        //public MostrarProductoesController(ProductoService productoService)
        //{
        //    _productoService = productoService;
        //}
        //public IActionResult Index()
        //{

        //    return View(_productoService.ListaProductos());
        //}
        private readonly PierreRestaurantContext _context;
        //private readonly MostrarProductoesController mostrarProductoesController;

        public MostrarProductoesController()
        {
            _context = new PierreRestaurantContext();
            //mostrarProductoesController = new MostrarProductoesController();
        }


        //public async Task<List<MostrarProducto>> ListaProductos()
        //{
        //    //List<Producto> productos = _context.Productos.Include(p => p.IdSubcategoriaNavigation).Include(p => p.IdSubcategoriaNavigation.IdCategoriaNavigation).ToList();
        //    List<MostrarProducto> productos = await _context.MostrarProductos.ToListAsync();
        //    return productos;
        //}

        //public IActionResult Index()
        //{

        //    return View(mostrarProductoesController.ListaProductos());
        //}
        public async Task<IActionResult> Index()
        {
            return View(await _context.MostrarProductos.ToListAsync());
        }
    }
}
