using System;
using System.Collections.Generic;

namespace rrhh_api.Models;

public partial class Articulo
{
    public string CodArticulo { get; set; } = null!;

    public int? CodFamilia { get; set; }

    public int? CodProveedor { get; set; }

    public string? NombreArticulo { get; set; }

    public string? Descripcion { get; set; }

    public string? Venta { get; set; }

    public string? Compra { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public int? Stock { get; set; }

    public string? Medida { get; set; }

    public byte[]? Foto { get; set; }

    public DateTime? UltimoIngreso { get; set; }

    public virtual Famila? CodFamiliaNavigation { get; set; }

    public virtual Proveedores? CodProveedorNavigation { get; set; }
}
