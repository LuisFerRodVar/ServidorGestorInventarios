using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class SubCategorium
{
    public int Id { get; set; }

    public int IdCategoria { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();

    public virtual Categorium? IdCategoriaNavigation { get; set; }
}
