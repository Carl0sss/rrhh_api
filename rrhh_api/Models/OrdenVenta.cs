using System;
using System.Collections.Generic;

namespace rrhh_api.Models;

public partial class OrdenVenta
{
    public int CodOrdenVenta { get; set; }

    public int? CodCotizacion { get; set; }

    public string? CodUsuario { get; set; }

    public DateTime? FechaDocumento { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? Retencion { get; set; }

    public decimal? Total { get; set; }

    public string? Detalles { get; set; }

    public virtual Cotizacion? CodCotizacionNavigation { get; set; }

    public virtual Usuario? CodUsuarioNavigation { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
