using System;
using System.Collections.Generic;

namespace Restaurant_Pierre.Models;

public partial class Categorium
{
    public int IdCategoria { get; set; }

    public string Categoria { get; set; } = null!;

    public string? Image { get; set; }

    public virtual ICollection<Subcategorium> Subcategoria { get; set; } = new List<Subcategorium>();
}
