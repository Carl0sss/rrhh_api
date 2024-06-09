using System;
using System.Collections.Generic;

namespace rrhh_api.Models;

public partial class DetalleCotizacion
{
    public int? CodCotizacion { get; set; }

    public string? CodArticulo { get; set; }

    public int NumeroLinea { get; set; }

    public string? Descripcion { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public int? Cantidad { get; set; }

    public decimal? TotalLinea { get; set; }

    public virtual Articulo? CodArticuloNavigation { get; set; }

    public virtual Cotizacion? CodCotizacionNavigation { get; set; }
}
