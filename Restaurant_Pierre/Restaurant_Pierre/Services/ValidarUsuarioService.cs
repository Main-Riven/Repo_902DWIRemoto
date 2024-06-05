using Microsoft.EntityFrameworkCore;
using Restaurant_Pierre.Models;

namespace Restaurant_Pierre.Services
{
    public class ValidarUsuarioService
    {
        private readonly PierreRestaurantContext _context;

        public ValidarUsuarioService()
        {
            _context = new PierreRestaurantContext();
        }

        public ValidarUsuarioService(PierreRestaurantContext context)
        {
            _context = context;
        }

        public Usuario ValidarUsuario(string _correo, string _clave)
        {
            Usuario usuario = _context.Usuarios.Include(u => u.IdEmpleadoNavigation)
                .Include(u => u.IdRolNavigation)
                .Where(x => x.Usuario1 == _correo)
                .Where(x => x.Password == _clave)
                .FirstOrDefault();
            Usuario user = usuario;
            //if (user == null) { 
                
            //}
            
            return user;

        }
    }
}
