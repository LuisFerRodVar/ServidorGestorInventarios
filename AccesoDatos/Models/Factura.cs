using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Factura
{
    public int Id { get; set; }

    public string? Fecha { get; set; }

    public string? Tipo { get; set; }

    public double? Impuesto { get; set; }

    public double? Total { get; set; }

    public bool? Credito { get; set; }

    public virtual ICollection<Credito> Creditos { get; set; } = new List<Credito>();
}
