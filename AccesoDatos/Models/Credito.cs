using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Credito
{
    public int Id { get; set; }

    public string? Fecha { get; set; }

    public double? Monto { get; set; }

    public int? IdFactura { get; set; }

    public virtual Factura? IdFacturaNavigation { get; set; }
}
