using System;
using System.Collections.Generic;

namespace rrhh_api.Models;

public partial class DetalleMovimiento
{
    public string? CodArticulo { get; set; }

    public int? NumeroDocumento { get; set; }

    public int NumeroLinea { get; set; }

    public int? Cantidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public string? Descripcion { get; set; }

    public virtual Articulo? CodArticuloNavigation { get; set; }

    public virtual Movimiento? NumeroDocumentoNavigation { get; set; }
}
