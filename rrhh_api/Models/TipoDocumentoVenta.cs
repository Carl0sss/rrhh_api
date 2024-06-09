using System;
using System.Collections.Generic;

namespace rrhh_api.Models;

public partial class TipoDocumentoVenta
{
    public int CodTipoDoc { get; set; }

    public string? TipoDocVenta { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
