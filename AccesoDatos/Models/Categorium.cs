using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Categorium
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<SubCategorium> SubCategoria { get; set; } = new List<SubCategorium>();
}
