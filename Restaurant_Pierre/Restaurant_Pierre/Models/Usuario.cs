using System;
using System.Collections.Generic;

namespace Restaurant_Pierre.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int IdRol { get; set; }

    public int IdEmpleado { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; } = null!;

    public virtual Rol? IdRolNavigation { get; set; } = null!;

    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
