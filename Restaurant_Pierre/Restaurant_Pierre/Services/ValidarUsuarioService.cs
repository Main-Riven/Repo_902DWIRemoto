using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant_Pierre.Models;

namespace Restaurant_Pierre.Services
{
    public class ValidarUsuarioService 
    {
        private readonly PierreRestaurantContext _context;
        public string? Horror { get; private set; }
        public SelectList Datos1 { get; private set; }
        public SelectList Datos2 { get; private set; }

        public ValidarUsuarioService() 
        {
            _context = new PierreRestaurantContext();
        }

        public ValidarUsuarioService(PierreRestaurantContext context)
        {
            _context = context;
        }

        

        public Usuario ValidarUsuario(string _correo, string _usuario, string _clave)
        {
            Usuario usuario = _context.Usuarios.Include(u => u.IdEmpleadoNavigation)
                .Include(u => u.IdRolNavigation)
                .Where(x => x.IdEmpleadoNavigation.Email == _correo)
                .FirstOrDefault();
            if (usuario !=null)
            {
                usuario = _context.Usuarios.Include(u => u.IdEmpleadoNavigation)
                .Include(u => u.IdRolNavigation)
                .Where(x => x.Usuario1 == _usuario)
                .Where(x => x.Password == _clave)
                .FirstOrDefault();
                if(usuario == null)
                {
                    Horror = "Problema al autentificar Usuario y/o contraseña" ;
                }

            }else
            {
                Horror = "No se encontró el correo proporcionado";
            }
            Usuario user = usuario;
            //if (user == null) { 

            //}

            return user;

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async void CrearUsuario( Usuario usuario)
        {
            
                _context.Add(usuario);
                await _context.SaveChangesAsync();

            Datos1 = new SelectList(_context.Empleados, "IdEmpleado", "Nombre", usuario.IdEmpleado);
            Datos2 = new SelectList(_context.Rols, "IdRol", "Rol1", usuario.IdRol);


        }
        public async void CrearUsuario(Usuario usuario, string Hola)
        {


            Datos1 = new SelectList(_context.Empleados, "IdEmpleado", "Nombre", usuario.IdEmpleado);
            Datos2 = new SelectList(_context.Rols, "IdRol", "Rol1", usuario.IdRol);


        }

    }
}
