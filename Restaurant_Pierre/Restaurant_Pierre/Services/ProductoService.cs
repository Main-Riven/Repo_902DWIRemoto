using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant_Pierre.Models;

namespace Restaurant_Pierre.Services
{
    public class ProductoService
    {
        private readonly PierreRestaurantContext _context;

        public ProductoService()
        {
            _context = new PierreRestaurantContext();
        }

        //public ProductoService(PierreRestaurantContext context)
        //{
        //    _context = context;
        //}
        public async Task<List<MostrarProducto>> ListaProductos()
        {
            //List<Producto> productos = _context.Productos.Include(p => p.IdSubcategoriaNavigation).Include(p => p.IdSubcategoriaNavigation.IdCategoriaNavigation).ToList();
            List<MostrarProducto> productos = await _context.MostrarProductos.ToListAsync();
            return productos;
        }
    }
}
