using System;
using System.Collections.Generic;

namespace Restaurant_Pierre.Models;

public partial class MostrarProducto
{
    public int Id { get; set; }

    public string Producto { get; set; } = null!;

    public decimal Precio { get; set; }

    public bool Promocion { get; set; }

    public decimal? PrecioPromo { get; set; }

    public string? Descripcion { get; set; }

    public string SubCategoria { get; set; } = null!;

    public string Categoria { get; set; } = null!;
}
