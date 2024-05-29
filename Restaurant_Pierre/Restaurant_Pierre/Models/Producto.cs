using System;
using System.Collections.Generic;

namespace Restaurant_Pierre.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string Producto1 { get; set; } = null!;

    public decimal Precio { get; set; }

    public bool Promocion { get; set; }

    public decimal? PrecioPromo { get; set; }

    public string? Descripcion { get; set; }

    public string? Image { get; set; }

    public int IdSubcategoria { get; set; }

    public virtual Subcategorium? IdSubcategoriaNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
