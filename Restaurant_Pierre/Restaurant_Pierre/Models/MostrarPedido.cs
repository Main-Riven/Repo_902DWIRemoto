using System;
using System.Collections.Generic;

namespace Restaurant_Pierre.Models;

public partial class MostrarPedido
{
    public int IdPedido { get; set; }

    public string Producto { get; set; } = null!;

    public string? Peticion { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateTime HoraSolicitado { get; set; }

    public bool Entregado { get; set; }

    public string Direccion { get; set; } = null!;

    public string? Referencias { get; set; }

    public string Empleado { get; set; } = null!;
}
