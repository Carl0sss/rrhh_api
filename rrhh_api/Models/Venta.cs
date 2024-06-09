using System;
using System.Collections.Generic;

namespace rrhh_api.Models;

public partial class Venta
{
    public int CodVenta { get; set; }

    public int? CodTipoDoc { get; set; }

    public int? CodOrdenVenta { get; set; }

    public string? CodUsuario { get; set; }

    public DateTime? FechaDocumento { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? Retencion { get; set; }

    public decimal? Total { get; set; }

    public string? Detalles { get; set; }

    public virtual OrdenVenta? CodOrdenVentaNavigation { get; set; }

    public virtual TipoDocumentoVenta? CodTipoDocNavigation { get; set; }

    public virtual Usuario? CodUsuarioNavigation { get; set; }
}
