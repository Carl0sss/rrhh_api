using System;
using System.Collections.Generic;

namespace rrhh_api.Models;

public partial class Proveedores
{
    public int CodProveedor { get; set; }

    public int? CodTipoSn { get; set; }

    public string? NombreComercial { get; set; }

    public string? RazonSocial { get; set; }

    public string? Nit { get; set; }

    public string? Nrc { get; set; }

    public string? Telefono { get; set; }

    public string? PersonaContacto { get; set; }

    public string? TelefonoContacto { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();

    public virtual TipoSn? CodTipoSnNavigation { get; set; }
}
