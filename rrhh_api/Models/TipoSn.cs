using System;
using System.Collections.Generic;

namespace rrhh_api.Models;

public partial class TipoSn
{
    public int CodTipoSn { get; set; }

    public string? NombreTipoSn { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Proveedores> Proveedores { get; set; } = new List<Proveedores>();
}
