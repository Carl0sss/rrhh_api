using System;
using System.Collections.Generic;

namespace rrhh_api.Models;

public partial class Cotizacion
{
    public int CodCotizacion { get; set; }

    public string? CodUsuario { get; set; }

    public DateTime? FechaDocumento { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? Retencion { get; set; }

    public decimal? Total { get; set; }

    public string? Detalles { get; set; }

    public virtual Usuario? CodUsuarioNavigation { get; set; }

    public virtual ICollection<OrdenVenta> OrdenVenta { get; set; } = new List<OrdenVenta>();
}
