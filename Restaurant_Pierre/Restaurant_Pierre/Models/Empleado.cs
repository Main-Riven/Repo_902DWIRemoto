using System;
using System.Collections.Generic;

namespace Restaurant_Pierre.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public DateOnly FechaContratacion { get; set; }

    public string? Contrato { get; set; }

    public int IdPuesto { get; set; }

    public virtual Puesto? IdPuestoNavigation { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
