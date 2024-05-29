using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant_Pierre.Models;

namespace Restaurant_Pierre.Controllers
{
    public class PedidoesController : Controller
    {
        private readonly PierreRestaurantContext _context;

        public PedidoesController(PierreRestaurantContext context)
        {
            _context = context;
        }

        // GET: Pedidoes
        public async Task<IActionResult> Index()
        {
            var pierreRestaurantContext = _context.Pedidos.Include(p => p.IdClienteNavigation).Include(p => p.IdProductoNavigation).Include(p => p.IdTurnoNavigation);
            return View(await pierreRestaurantContext.ToListAsync());
        }

        // GET: Pedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.IdClienteNavigation)
                .Include(p => p.IdProductoNavigation)
                .Include(p => p.IdTurnoNavigation)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidoes/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.MostrarClientes, "IdCliente", "NombreApellido");
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "Producto1");
            ViewData["IdTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno");
            return View();
        }

        // POST: Pedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPedido,IdProducto,Peticion,IdCliente,IdTurno,HoraSolicitado,Entregado,Direccion,Referencias")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.MostrarClientes, "IdCliente", "NombreApellido", pedido.IdCliente);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "Producto1", pedido.IdProducto);
            ViewData["IdTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno", pedido.IdTurno);
            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.MostrarClientes, "IdCliente", "NombreApellido", pedido.IdCliente);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "Producto1", pedido.IdProducto);
            ViewData["IdTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno", pedido.IdTurno);
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPedido,IdProducto,Peticion,IdCliente,IdTurno,HoraSolicitado,Entregado,Direccion,Referencias")] Pedido pedido)
        {
            if (id != pedido.IdPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.IdPedido))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.MostrarClientes, "IdCliente", "NombreApellido", pedido.IdCliente);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "Producto1", pedido.IdProducto);
            ViewData["IdTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno", pedido.IdTurno);
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.IdClienteNavigation)
                .Include(p => p.IdProductoNavigation)
                .Include(p => p.IdTurnoNavigation)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.IdPedido == id);
        }
    }
}
