using System;
using System.Collections.Generic;

namespace Restaurant_Pierre.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public int IdProducto { get; set; }

    public string? Peticion { get; set; }

    public int IdCliente { get; set; }

    public int IdTurno { get; set; }

    public DateTime HoraSolicitado { get; set; }

    public bool Entregado { get; set; }

    public string Direccion { get; set; } = null!;

    public string? Referencias { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; } = null!;

    public virtual Producto? IdProductoNavigation { get; set; } = null!;

    public virtual Turno? IdTurnoNavigation { get; set; } = null!;
}
