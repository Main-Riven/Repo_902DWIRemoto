using System;
using System.Collections.Generic;

namespace Restaurant_Pierre.Models;

public partial class MostrarCliente
{
    public string NombreApellido { get; set; } = null!;

    public int IdCliente { get; set; }

    public string Email { get; set; } = null!;

    public string Telefono { get; set; } = null!;
}
