using System;
using System.Collections.Generic;

namespace Restaurant_Pierre.Models;

public partial class Subcategorium
{
    public int IdSubcategoria { get; set; }

    public string Subcategoria { get; set; } = null!;

    public int IdCategoria { get; set; }

    public string? Image { get; set; }

    public virtual Categorium? IdCategoriaNavigation { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
