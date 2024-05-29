using System;
using System.Collections.Generic;

namespace Restaurant_Pierre.Models;

public partial class Turno
{
    public int IdTurno { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFinalizacion { get; set; }

    public int IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
