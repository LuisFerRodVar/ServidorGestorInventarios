using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Articulo
{
    public int Id { get; set; }

    public int IdSubCategoria { get; set; }

    public string? Nombre { get; set; }

    public string? Marca { get; set; }

    public string? Detalle { get; set; }

    public int Cantidad { get; set; }

    public int Conversion { get; set; }

    public virtual SubCategorium? IdSubCategoriaNavigation { get; set; }
}
